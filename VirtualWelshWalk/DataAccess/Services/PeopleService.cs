using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWelshWalk.DataAccess.CRUD;
using VirtualWelshWalk.DataAccess.Models;

namespace VirtualWelshWalk.DataAccess.Services
{
    public class PeopleService : IPeopleService
    {
        readonly IPeopleRepository peopleRepository;
        readonly AuthenticationStateProvider authenticationStateProvider;

        public PeopleService(IPeopleRepository peopleRepository, AuthenticationStateProvider authenticationStateProvider)
        {
            this.peopleRepository = peopleRepository;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task AddPeople(People people)
        {
            await peopleRepository.AddPeople(people);
        }

        public async Task DeletePeople(int peopleID)
        {
            await peopleRepository.DeletePeople(peopleID);
            //return Task.CompletedTask;
        }

        public async Task DeletePeople(string peopleUserName)
        {
            await peopleRepository.DeletePeople(peopleUserName);
            //return Task.CompletedTask;
        }

        public async Task<People> GetPeople(int peopleID)
        {
            return await peopleRepository.GetPeople(peopleID);
        }

        public async Task<People> GetPeople(string peopleUserName)
        {
            return await peopleRepository.GetPeople(string.IsNullOrEmpty(peopleUserName) ? await GetUserName(peopleUserName) : peopleUserName);
        }

        public async Task UpdatePeople(People people)
        {
            await peopleRepository.UpdatePeople(people);
        }

        async Task<string> GetUserName(string UName)
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            UName = user.Identity.Name;

            return UName;
        }
    }
}
