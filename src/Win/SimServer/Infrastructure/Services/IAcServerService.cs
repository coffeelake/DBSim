// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAcServerService.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IAcServerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimServer.Infrastructure.Services
{
    using AssettoCorsaSharedMemory;

    public interface IAcServerService
    {
         Physics GetPhysics();


         Graphics GetGraphics();


         StaticInfo GetStaticInfo();

        string MapGear(int gear);
    }
}