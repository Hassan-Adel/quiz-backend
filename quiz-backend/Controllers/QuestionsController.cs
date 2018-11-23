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
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return new Question[] {
                new Question(){Text = "First Question"},
                new Question(){Text = "Second Question"},
                new Question(){Text = "Third Question"},
            };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Question question)
        {
        }
    }
}