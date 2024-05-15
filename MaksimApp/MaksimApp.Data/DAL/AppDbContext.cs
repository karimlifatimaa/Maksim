using MaksimApp.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksimApp.Data.DAL
{
    public class AppDbContext :IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Services> Services { get; set; }
        public DbSet<AppUser> AppUsers {  get; set; }   

    }
}
