using Microsoft.EntityFrameworkCore;

namespace QuestionAsking.Models
{
    public class QuestionAskingContext : DbContext
    {
        public QuestionAskingContext(DbContextOptions<QuestionAskingContext> options) : base(options)
        {

        }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<TriviaQuestion> TriviaQuestion { get; set; }
    }
}
