using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.Services
{
    public interface IPeopleService
    {
        Task<People> GetPeople(int peopleID);

        Task<People> GetPeople(string peopleUserName = null);

        Task AddPeople(People people);

        Task UpdatePeople(People people);

        Task DeletePeople(int peopleID);

        Task DeletePeople(string peopleUserName);
    }
}
