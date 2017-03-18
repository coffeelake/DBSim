namespace SimServer
{
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;

    using SimServer.Infrastructure.Services;

    public partial class Form1 : Form
    {
        private readonly IAcServerService _acServerService;

        private BackgroundWorker _acServerWorker;

        public Form1()
        {
            this.InitializeComponent();
            this._acServerService = new AcServerService();
            this.InitacServerJob();

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

                        this._acServerWorker.ReportProgress(0, result);

                    Thread.Sleep(1);
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
        }
    }

    public class AcResultObject
    {
        public string GearName { get; set; }

        public string CurrentLaptime { get; set; }

        public string BestLapTime { get; set; }
    }

}
