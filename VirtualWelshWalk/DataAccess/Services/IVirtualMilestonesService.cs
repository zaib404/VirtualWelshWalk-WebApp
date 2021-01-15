using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.Services
{
    public interface IVirtualMilestonesService
    {
        Task<VirtualMilestone> GetVirtualMilestones(string virtualMilestones, int peopleID);

        Task UpdateVirtualMilestones(VirtualMilestone virtualMilestones);

        Task DeleteVirtualMilestones(int peopleID);

        Task AddVirtualMilestones(VirtualMilestone VMilestones);
    }
}
