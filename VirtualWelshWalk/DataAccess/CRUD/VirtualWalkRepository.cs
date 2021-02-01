using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Data;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.CRUD
{
    public class VirtualWalkRepository : IVirtualWalkRepository
    {
        readonly ApplicationDbContext dbContext;

        public VirtualWalkRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<VirtualWalk> AddVirtualWalk(VirtualWalk VWalk)
        {
            var result = await dbContext.VirtualWalksTBL.AddAsync(VWalk);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteVirtualWalk(int peopleID)
        {
            var result = await dbContext.VirtualWalksTBL.FirstOrDefaultAsync(v => v.PeopleId == peopleID);

            if (result != null)
            {
                dbContext.VirtualWalksTBL.RemoveRange(dbContext.VirtualWalksTBL.Where(v => v.PeopleId == peopleID));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<VirtualWalk> GetVirtualWalk(int peopleID, string VWalkName)
        {
            var result = await dbContext.VirtualWalksTBL.FirstOrDefaultAsync(v => v.PeopleId == peopleID && v.VirtualWalkName == VWalkName);
            return result;
        }

        public async Task<VirtualWalk> UpdateVirtualWalk(VirtualWalk VWalk)
        {
            var result = await dbContext.VirtualWalksTBL.FirstOrDefaultAsync(v => v.PeopleId == VWalk.PeopleId && v.VirtualWalkName == VWalk.VirtualWalkName);

            if (result != null)
            {
                await dbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}
