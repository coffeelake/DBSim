// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcServerServiceFake.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AcServerServiceFake type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimServer.Infrastructure.Services
{
    using System;

    using AssettoCorsaSharedMemory;

    public class AcServerServiceFake : IAcServerService
    {
        private int gearUpdateIntervall = 301;

        private int selectedGear = 0;

        private int currentTimeSpan =0;

        public Physics GetPhysics()
        {
            this.gearUpdateIntervall--;
            if (this.gearUpdateIntervall == 300)
            {
                Random rnd = new Random();
                this.selectedGear = rnd.Next(0, 7);
                return new Physics { Gear = this.selectedGear};
            }
           
            if (this.gearUpdateIntervall == 0)
            {
                this.gearUpdateIntervall = 301;
            }
            return new Physics { Gear = this.selectedGear };
        }

        public Graphics GetGraphics()
        {
            this.currentTimeSpan++;
            var currstring = TimeSpan.FromTicks((this.currentTimeSpan * 100000)).ToString("g");
            return new Graphics {CurrentTime = currstring.Substring(2), BestTime = "1:12:123"};
        }

        public StaticInfo GetStaticInfo()
        {
            return new StaticInfo();
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

        public AC_STATUS GetGameStatus()
        {
            return AC_STATUS.AC_LIVE;
        }
    }
}
