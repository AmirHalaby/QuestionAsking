using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QuestionAsking.Models
{
    public class TriviaQuestion
    {
        public int Id { get; set; }
        public Answers Answer { get; set; }
    }
}
