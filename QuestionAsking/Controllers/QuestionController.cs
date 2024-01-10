using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionAsking.Dto;
using QuestionAsking.HelpsClass;
using QuestionAsking.Models;
using System;
using System.Linq;

namespace QuestionAsking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionAskingContext _dbContext;
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(QuestionAskingContext dbContext, ILogger<QuestionController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Question>> GetQuestionAndAnswers(string title, int currentPage)
        {
            var questions = new List<Question>(); 
            try
            {
                // Another way to do Pagination through the SQL procedure so we don't have to take a lot of data from SQL and save it in memory, I think It's better.
                questions = await _dbContext.Question.Where(q => q.Title.Contains(title)).ToListAsync();
                await _dbContext.Answers.ToListAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
            var pagination = (questions.Count / Constants.PAGE_SIZE >= currentPage) ?
              new Pager(questions.Count, currentPage)
               :
              new Pager(questions.Count, (int)questions.Count / Constants.PAGE_SIZE);
            
            return Ok(questions.Skip(pagination.StartIndex).Take(pagination.EndIndex - pagination.StartIndex + Constants.MORE_QUESTION).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestionAndAnswers(int id)
        {
            var Question = await _dbContext.Question.Where(q => q.Id == id).ToListAsync();
            await _dbContext.Answers.Where(q => q.Question.Id == id).ToListAsync();

            return Ok(Question);
        }

        [HttpPost]
        public async Task<ActionResult<GetQuestionIdDto>> PostQuestion(QuestionDto question)
        {
            var questionId = new GetQuestionIdDto();
            try
            {
                var answers = new List<Answers>();
                for (var i = 0; i < question.Answers.Count; i++)
                {
                    answers.Add(new Answers(question.Answers[i]));
                }

                _dbContext.Question.Add(new Question(question.Title, answers));
               questionId = new GetQuestionIdDto(await _dbContext.SaveChangesAsync());
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception.Message);
                NotFound(exception.Message);
            }
            return Ok(questionId);
        }    
    }
}
