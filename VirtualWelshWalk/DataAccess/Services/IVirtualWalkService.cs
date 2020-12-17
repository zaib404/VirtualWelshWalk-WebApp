using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.Services
{
    public interface IVirtualWalkService
    {
        //Task<People> GetPersonVirtualWalk(int peopleID);

        Task<VirtualWalk> GetVirtualWalk(string virtualWalkName, int peopleID);

        Task UpdateVirtualWalk(VirtualWalk virtualWalk);

        Task DeleteVirtualWalk(int peopleID);

        Task AddVirtualWalk(VirtualWalk VWalk);
    }
}
