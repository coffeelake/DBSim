namespace SimServer
{
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;

    using AssettoCorsaSharedMemory;

    using SimServer.Infrastructure.Services;
    using System.IO;
    using System.IO.Ports;
    public partial class Form1 : Form
    {
        private readonly IAcServerService _acServerService;

        private BackgroundWorker _acServerWorker;

        private SerialPort sp;

        public Form1()
        {
            this.InitializeComponent();
            this._acServerService = new AcServerService();
           // this._acServerService = new AcServerServiceFake();
            this.InitacServerJob();
           
                sp = new SerialPort();
                sp.BaudRate = 250000;
                sp.PortName = "COM3";
                sp.Open();
        }

        private void InitacServerJob()
        {
            this._acServerWorker?.Dispose();
            this._acServerWorker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            this._acServerWorker.DoWork += this.RunAcServerCollect;
            this._acServerWorker.RunWorkerCompleted += this.RunAcServerWorkerCompleted;
            this._acServerWorker.ProgressChanged += this.ProgressChanged;
            this._acServerWorker.RunWorkerAsync();
        }

        private void RunAcServerCollect(object sender, DoWorkEventArgs e)
        {
            if (this._acServerWorker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
             
                while (true)
                {
                   var physics = this._acServerService.GetPhysics();
                    var gearName = this._acServerService.MapGear(physics.Gear);
                    var result = new AcResultObject
                                     {
                                         GearName = gearName,
                                         CurrentLaptime = this._acServerService.GetGraphics().CurrentTime,
                                         BestLapTime = this._acServerService.GetGraphics().BestTime
                                     };
                    if (this._acServerService.GetGameStatus() == AC_STATUS.AC_LIVE)
                    {
                        this._acServerWorker.ReportProgress(0, result);
                    }

                    Thread.Sleep(10);
                }

            }
        }

        void RunAcServerWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // Display some message to the user that task has been
                // cancelled
            }
            else if (e.Error != null)
            {
                // Do something with the error
            }
        }

        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var result = (AcResultObject)e.UserState;

            this.gear.Text = result.GearName;

            this.lblCurenTime.Text = result.CurrentLaptime;

            this.lblBestTime.Text = result.BestLapTime;

            var curr = "";
            if (!string.IsNullOrEmpty(result.CurrentLaptime))
            {
                curr = result.CurrentLaptime;
            }
          
                string test = new SerialHelper().GetSerialString(result.GearName, curr); 
                sp.WriteLine(test);
       
        }
    }

    public class AcResultObject
    {
        public string GearName { get; set; }

        public string CurrentLaptime { get; set; }

        public string BestLapTime { get; set; }
    }

    public class SerialHelper
    {
        private string startToken = "<";
        private string endToken = ">";

        public string GetSerialString(string gear, string currentLap)
        {
            currentLap = currentLap.PadLeft(12, '-');
            return this.startToken + gear + currentLap + this.endToken;
        }
    }

}
