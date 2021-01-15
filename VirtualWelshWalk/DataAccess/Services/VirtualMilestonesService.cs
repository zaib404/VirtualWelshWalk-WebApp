using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.CRUD;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.Services
{
    public class VirtualMilestonesService : IVirtualMilestonesService
    {
        readonly IMilestoneRepository virtualMilestoneRepository;

        public VirtualMilestonesService(IMilestoneRepository virtualWalkRepository)
        {
            this.virtualMilestoneRepository = virtualWalkRepository;
        }

        public async Task AddVirtualMilestones(VirtualMilestone VMilestones)
        {
            await virtualMilestoneRepository.AddVirtualMilestones(VMilestones);
        }

        public Task DeleteVirtualMilestones(int peopleID)
        {
            virtualMilestoneRepository.DeleteVirtualMilestones(peopleID);
            return Task.CompletedTask;
        }

        public async Task<VirtualMilestone> GetVirtualMilestones(string virtualMilestones, int peopleID)
        {
            return await virtualMilestoneRepository.GetVirtualMilestones(peopleID, virtualMilestones);
        }

        public async Task UpdateVirtualMilestones(VirtualMilestone virtualMilestones)
        {
            await virtualMilestoneRepository.UpdateVirtualMilestones(virtualMilestones);
        }
    }
}
