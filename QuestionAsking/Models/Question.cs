using QuestionAsking.Dto;

namespace QuestionAsking.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Answers> Answers { get; set; }

        public Question(string title, List<Answers> answers)
        {
            Title = title;
            Answers = answers;
        }
        public Question(string title)
        {
            Title = title;
        }
        public Question() { }
    }
}
