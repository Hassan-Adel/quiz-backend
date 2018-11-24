using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{quizId}")]
        public IEnumerable<Question> Get([FromRoute] int quizId)
        {
            return _context.Questions.Where(question => question.QuizId == quizId);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question question)
        {
            var resultQuiz = _context.Quiz.SingleOrDefault(q => q.ID == question.QuizId);

            if (resultQuiz == null)
                return NotFound(question);

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            //returns question with the Id
            return Ok(question);
        }

        /*
         Why I changed these functions from asynchronous to synchronous, and is one better than the other. There's usually not a general answer for that, it depends on the situation. 
         So depending on the web server you're using, such as IIS, it might be able to handle a lot more threads or requests than the database we're trying to access.

         In that case the bottleneck won't be in the web server itself, but possibly in the database, and so async won't be that valuable in that case. 
         But with the modern database server, it might make sense to use async inside our controllers so that we can handle more simultaneous requests. 
         And that needs to be assessed based on your project or on a per-controller or per-call basis.
         With this, I just wanted to show you that there are two possible options you can use whether it's synchronous or asynchronous.
             */
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Question question)
        {
            //------First way to update-------------
            //var resultQuestion = _context.Questions.SingleOrDefault(q => q.ID == id);
            //if (resultQuestion != null)
            //{
            //    resultQuestion.Text = "Some new value";
            //    _context.SaveChanges();
            //}
            //--------------------------------------

            // if we thought we were trying to modify question two, but instead we actually had the data for question one, we would get back some error
            // if we thought we were trying to modify question two, but instead we actually had the data for question one, we would get back some error
            if (id != question.ID)
                return BadRequest();
            //takes the id from the object(Context dot entry, on the other hand, uses the ID from the model itself, not the ID parameter we pass in.)
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(question);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}