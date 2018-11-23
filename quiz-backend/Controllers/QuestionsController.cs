using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiz_backend.Models;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        readonly QuizDBContext _context;
        public QuestionsController(QuizDBContext context)
        {
            this._context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return _context.Questions;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }
    }
}