// -------------------------------------------------public -------------------------------------------------------------------
// <copyright file="ACServerService.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ACServerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimServer.Infrastructure.Services
{
    using AssettoCorsaSharedMemory;

    public class AcServerService : IAcServerService
    {
       public AcServerService()
       {
            var ac = new AssettoCorsa { StaticInfoInterval = 1000, GraphicsInterval = 10, PhysicsInterval = 10};
            ac.StaticInfoUpdated += this.AC_StaticInfoUpdated; // Add event listener for StaticInfo
            ac.GraphicsUpdated += this.AC_GraphicInfoUpdated;
            ac.PhysicsUpdated += this.AC_PhysicsUpdated;
            ac.Start(); // Connect to shared memory and start interval timers 
        }

        private Physics _physics;

        private Graphics _graphics;

        private StaticInfo _staticInfo;

        public Physics GetPhysics()
        {
            return this._physics;
        }

        public Graphics GetGraphics()
        {
            return this._graphics;
        }

        public StaticInfo GetStaticInfo()
        {
            return this._staticInfo;
        }

        public string MapGear(int input)
        {

           var gear = string.Empty;
            switch (input)
            {
                case 0:
                    gear = "R";
                    break;
                case 1:
                    gear = "N";
                    break;
                case 2:
                    gear = "1";
                    break;
                case 3:
                    gear = "2";
                    break;
                case 4:
                    gear = "3";
                    break;
                case 5:
                    gear = "4";
                    break;
                case 6:
                    gear = "5";
                    break;
                case 7:
                    gear = "6";
                    break;
                case 8:
                    gear = "7";
                    break;
            }
            return gear;
        }

        private void AC_PhysicsUpdated(object sender, PhysicsEventArgs e)
        {
            this._physics = e.Physics;
            // Console.WriteLine("StaticInfo\r\n");
        }


        private void AC_GraphicInfoUpdated(object sender, GraphicsEventArgs e)
        {

        this._graphics = e.Graphics;
            //  Console.WriteLine("StaticInfo\r\n");
        }

        private void AC_StaticInfoUpdated(object sender, StaticInfoEventArgs e)
        {
       this._staticInfo = e.StaticInfo;
            // Print out some data from StaticInfo

            //  Console.WriteLine("StaticInfo\r\n");
            //  Console.WriteLine("  Car Model: " + e.StaticInfo.CarModel + "\r\n");
            //  Console.WriteLine("  Track:     " + e.StaticInfo.Track + "\r\n");
            //  Console.WriteLine("  Max RPM:   " + e.StaticInfo.MaxRpm + "\r\n");
        }
    }
}
