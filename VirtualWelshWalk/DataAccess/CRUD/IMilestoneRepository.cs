using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.CRUD
{
    public interface IMilestoneRepository
    {
        Task<VirtualMilestone> GetVirtualMilestones(int peopleID, string VMilestone);

        Task<VirtualMilestone> AddVirtualMilestones(VirtualMilestone VMilestone);

        Task<VirtualMilestone> UpdateVirtualMilestones(VirtualMilestone VMilestone);

        void DeleteVirtualMilestones(int peopleID);
    }
}
