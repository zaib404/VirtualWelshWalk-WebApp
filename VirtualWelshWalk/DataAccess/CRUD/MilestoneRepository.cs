using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Data;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.CRUD
{
    public class MilestoneRepository : IMilestoneRepository
    {
        readonly ApplicationDbContext dbContext;

        public MilestoneRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<VirtualMilestone> AddVirtualMilestones(VirtualMilestone VMilestone)
        {
            var result = await dbContext.VirtualMilestonesTBL.AddAsync(VMilestone);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteVirtualMilestones(int peopleID)
        {
            var result = await dbContext.VirtualMilestonesTBL.FirstOrDefaultAsync(v => v.PeopleId == peopleID);

            if (result != null)
            {
                dbContext.VirtualMilestonesTBL.RemoveRange(dbContext.VirtualMilestonesTBL.Where(v => v.PeopleId == peopleID));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<VirtualMilestone> GetVirtualMilestones(int peopleID, string VWalkName)
        {
            var result = await dbContext.VirtualMilestonesTBL.FirstOrDefaultAsync(v => v.PeopleId == peopleID && v.VirtualWalkName == VWalkName);
            return result;
        }

        public async Task<VirtualMilestone> UpdateVirtualMilestones(VirtualMilestone VMilestone)
        {
            var result = await dbContext.VirtualMilestonesTBL.FirstOrDefaultAsync(v => v.PeopleId == VMilestone.PeopleId && v.VirtualWalkName == VMilestone.VirtualWalkName);

            if (result != null)
            {
                await dbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}
