using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.CRUD
{
    public interface IVirtualWalkRepository
    {
        Task<VirtualWalk> GetVirtualWalk(int peopleID, string VWalkName);

        Task<VirtualWalk> AddVirtualWalk(VirtualWalk VWalk);

        Task<VirtualWalk> UpdateVirtualWalk(VirtualWalk VWalk);

        Task DeleteVirtualWalk(int peopleID);
    }
}
