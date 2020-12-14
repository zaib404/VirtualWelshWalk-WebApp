using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Virtual_Welsh_Walk.DataAccess.Data;
using Virtual_Welsh_Walk.DataAccess.Models;

[assembly: HostingStartup(typeof(Virtual_Welsh_Walk.Areas.Identity.IdentityHostingStartup))]
namespace Virtual_Welsh_Walk.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}