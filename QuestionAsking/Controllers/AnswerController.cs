using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionAsking.HelpsClass;
using QuestionAsking.Models;

namespace QuestionAsking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly QuestionAskingContext _dbContext;
        private readonly ILogger<QuestionController> _logger;

        public AnswerController(QuestionAskingContext dbContext, ILogger<QuestionController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answers>>> GetVoteAnswers()
        {
            return Ok(await _dbContext.Answers.ToListAsync());
        }    
    }
}
