using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetPeople();
    }
}
