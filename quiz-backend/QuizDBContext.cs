using Microsoft.EntityFrameworkCore;
using quiz_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend
{
    public class QuizDBContext : DbContext
    {
        public QuizDBContext(DbContextOptions<QuizDBContext> options) : base(options){}
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quiz { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Quiz>().HasData(
        //        new Quiz { ID = 1, Title = "Carson" },
        //        new Quiz { ID = 2, Title = "Carson2" }
        //        );
        //    modelBuilder.Entity<Question>().HasData(
        //        new Question { ID = 1, Text = "Carson", CorrectAnswer = "Alexander", Answer1 = "2005-09-01", QuizId = 1 },
        //        new Question { ID = 2, Text = "Carson2", CorrectAnswer = "Alexande2r", Answer1 = "2005-09-02", QuizId = 2 }
        //        );
        //}

    }
}
