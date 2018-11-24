using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_backend;
using quiz_backend.Models;

namespace quiz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizesController : ControllerBase
    {
        private readonly QuizDBContext _context;

        public QuizesController(QuizDBContext context)
        {
            _context = context;
        }

        // GET: api/Quizes
        [HttpGet]
        public IEnumerable<Quiz> GetQuiz()
        {
            //return _context.Quiz;
            return new Models.Quiz[] {
                new Models.Quiz() { ID = 2, Title = "hello"},
                new Models.Quiz() { ID = 1, Title = "hi"}
            };
        }

        // GET: api/Quizes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await _context.Quiz.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        // PUT: api/Quizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz([FromRoute] int id, [FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quiz.ID)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Quizes
        [HttpPost]
        public async Task<IActionResult> PostQuiz([FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Quiz.Add(quiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuiz", new { id = quiz.ID }, quiz);
        }

        // DELETE: api/Quizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();

            return Ok(quiz);
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.ID == id);
        }
    }
}