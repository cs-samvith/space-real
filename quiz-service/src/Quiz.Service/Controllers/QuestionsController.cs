using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using Quiz.Service.Data;
using Quiz.Service.Models;
// https://github.com/CodAffection/Quiz-App-with-React-Asp.Net-Core-API-Material-UI/tree/main/QuizAPI/QuizAPI/Controllers
// https://www.youtube.com/watch?v=rgrvOtCPS6Y&list=PLjC4UKOOcfDRIsN7PpvSKZG1L7GArAjgB&index=13
namespace Quiz.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuizDbContext _context;
        private readonly ILogger _logger;

        public QuestionsController(QuizDbContext context, ILogger<QuestionsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            //return await _context.Questions.ToListAsync();
            _logger.LogTrace($"LOGGGGGG");
            _logger.LogTrace($"MachineName,{ System.Environment.MachineName}");

            _logger.LogCritical($"api/Questions hit LogCritical",System.Environment.MachineName);
            _logger.LogError($"api/Questions hit LogError", System.Environment.MachineName);

            Console.WriteLine("api/Questions hit on {0}",System.Environment.MachineName);

            var random5Qns = await (_context.Questions
                             .Select(x => new
                             {
                                 QnId = x.QnId,
                                 QnInWords = x.QnInWords,
                                 ImageName = x.ImageName,
                                 Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
                             })
                             .OrderBy(y => Guid.NewGuid())
                             .Take(5)
                             ).ToListAsync();

            return Ok(random5Qns);

        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.QnId)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> RetrieveAnswers(int[] qnIds)
        {
            //_context.Questions.Add(question);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetQuestion", new { id = question.QnId }, question);

            var answers = await (_context.Questions
                            .Where(x => qnIds.Contains(x.QnId))
                            .Select(y => new
                            {
                                QnId = y.QnId,
                                QnInWords = y.QnInWords,
                                ImageName = y.ImageName,
                                Options = new string[] { y.Option1, y.Option2, y.Option3, y.Option4 },
                                Answer = y.Answer
                            })).ToListAsync();
            return Ok(answers);

        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.QnId == id);
        }
    }
}
