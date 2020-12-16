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
        readonly IPeopleRepository peopleRepository;
        readonly IVirtualWalkRepository virtualWalkRepository;
        readonly AuthenticationStateProvider authenticationStateProvider;

        public VirtualWalkService(IPeopleRepository peopleRepository, IVirtualWalkRepository virtualWalkRepository, AuthenticationStateProvider authenticationStateProvider)
        {
            this.peopleRepository = peopleRepository;
            this.virtualWalkRepository = virtualWalkRepository;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<VirtualWalk> GetPersonVirtualWalk(string virtualWalkName, People person)
        {
            return await virtualWalkRepository.GetVirtualWalk(person.PeopleId, virtualWalkName);
        }

        public async Task<People> GetPerson()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var uName = user.Identity.Name;

            return await peopleRepository.GetPeople(uName);
        }


    }
}
