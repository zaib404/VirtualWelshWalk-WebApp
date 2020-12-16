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

        Task<VirtualWalk> GetPersonVirtualWalk(string virtualWalkName, People people);

        Task<People> GetPerson();
    }
}
