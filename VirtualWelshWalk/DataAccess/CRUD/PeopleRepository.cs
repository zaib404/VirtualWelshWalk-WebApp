using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Data;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.CRUD
{
    public class PeopleRepository : IPeopleRepository
    {

        readonly ApplicationDbContext dbContext;

        public PeopleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<People> AddPeople(People people)
        {
            var result = await dbContext.PeoplesTBL.AddAsync(people);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeletePeople(int peopleID)
        {
            var result = await dbContext.PeoplesTBL.FirstOrDefaultAsync(p => p.PeopleId==peopleID);

            if (result != null)
            {
                dbContext.PeoplesTBL.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async void DeletePeople(string peopleUserName)
        {
            var result = await dbContext.PeoplesTBL.FirstOrDefaultAsync(p => p.UserName == peopleUserName);

            if (result != null)
            {
                dbContext.PeoplesTBL.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<People> GetPeople(int peopleID)
        {
            var result = await dbContext.PeoplesTBL.FirstOrDefaultAsync(p => p.PeopleId == peopleID);
            return result;
        }

        public async Task<People> GetPeople(string peopleUserName)
        {
            var result = await dbContext.PeoplesTBL.FirstOrDefaultAsync(p => p.UserName == peopleUserName);
            return result;
        }

        public async Task<People> UpdatePeople(People people)
        {
            var result = await dbContext.PeoplesTBL.FirstOrDefaultAsync(p => p.PeopleId == people.PeopleId);

            if (result != null)
            {
                result.FirstName = people.FirstName;
                result.LastName = people.LastName;
                result.UserName = people.UserName;

                await dbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}
