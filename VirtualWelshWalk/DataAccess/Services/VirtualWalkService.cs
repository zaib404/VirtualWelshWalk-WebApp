using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.CRUD;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.Services
{
    public class VirtualWalkService : IVirtualWalkService
    {
        readonly IVirtualWalkRepository virtualWalkRepository;

        public VirtualWalkService(IVirtualWalkRepository virtualWalkRepository)
        {
            this.virtualWalkRepository = virtualWalkRepository;
        }

        public async Task AddVirtualWalk(VirtualWalk VWalk)
        {
            await virtualWalkRepository.AddVirtualWalk(VWalk);
        }

        public Task DeleteVirtualWalk(int peopleID)
        {
            virtualWalkRepository.DeleteVirtualWalk(peopleID);
            return Task.CompletedTask;
        }

        public async Task<VirtualWalk> GetVirtualWalk(string virtualWalkName, int peopleID)
        {
            return await virtualWalkRepository.GetVirtualWalk(peopleID, virtualWalkName);
        }

        public async Task UpdateVirtualWalk(VirtualWalk virtualWalk)
        {
            await virtualWalkRepository.UpdateVirtualWalk(virtualWalk);
        }
    }
}
