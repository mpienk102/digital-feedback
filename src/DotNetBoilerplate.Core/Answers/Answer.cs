namespace DotNetBoilerplate.Core.Answers;
public class Answer
{
    private Answer() { }
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid FormId { get; private set; }
    public Guid QuestionId { get; private set; }
    public int? RatingAnswer {  get; private set; }
    public string? TextAnswer { get; private set; }

    public static Answer Create (
        Guid userId,
        Guid formId,
        Guid questionId,
        int? ratingAnswer,
        string? textAnswer
    )
    {
        return new Answer
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            FormId = formId,
            QuestionId = questionId,
            RatingAnswer = ratingAnswer,
            TextAnswer = textAnswer
        };
    }
}

