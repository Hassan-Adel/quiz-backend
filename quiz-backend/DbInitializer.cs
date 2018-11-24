using Microsoft.EntityFrameworkCore;
using quiz_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend
{
    public static class DbInitializer
    {
        public static void Initialize(QuizDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Questions.
            if (context.Questions.Any())
            {
                return;   // DB has been seeded
            }

            var quizs = new Quiz[]
            {
            new Quiz{Title="Carson"},
            new Quiz{Title="Carson2"}

            };
            foreach (Quiz qu in quizs)
            {
                context.Quiz.Add(qu);
            }
            context.SaveChanges();

            var questions = new Question[]
            {
            new Question{Text="Carson",CorrectAnswer="Alexander",Answer1="2005-09-01", QuizId=1},
            new Question{Text="Carson2",CorrectAnswer="Alexande2r",Answer1="2005-09-02", QuizId=2}

            };
            foreach (Question q in questions)
            {
                context.Questions.Add(q);
            }
            context.SaveChanges();

            
        }
    }
}
