using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.CRUD
{
    public interface IPeopleRepository
    {
        //Task<IEnumerable<People>> GetPeople();

        Task<People> GetPeople(int peopleID);

        Task<People> GetPeople(string peopleUserName);

        Task<People> AddPeople(People people);

        Task<People> UpdatePeople(People people);

        void DeletePeople(int peopleID);

        void DeletePeople(string peopleUserName);

    }
}
