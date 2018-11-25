using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using quiz_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend
{
    public class UserDBContext : IdentityDbContext<IdentityUser>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options){}
        //public DbSet<Question> Questions { get; set; }
        //public DbSet<Quiz> Quiz { get; set; }

    }
}
