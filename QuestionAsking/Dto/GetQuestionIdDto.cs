namespace QuestionAsking.Dto
{
    public class GetQuestionIdDto
    {
        public int Id { get; set; }
        public GetQuestionIdDto(int id) 
        {
            Id = id;
        }
        public GetQuestionIdDto()
        { 
        }
    }
}
