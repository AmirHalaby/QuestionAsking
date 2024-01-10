namespace QuestionAsking.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public Question? Question { get; set; }
        public string Answer { get; set; }
        public int Vote { get; set; }

        public Answers(string answer) 
        {
            Answer = answer;
        }
    }
}
