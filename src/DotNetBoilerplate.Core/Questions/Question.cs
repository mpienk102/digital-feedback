
using DotNetBoilerplate.Core.Forms;

namespace DotNetBoilerplate.Core.Questions
{
    public class Question
    {
        private Question() { }
        public Guid Id { get; private set; }
        public Guid FormId { get; private set; }
        public Guid CreatorId { get; private set; }
        public string QuestionText { get; private set; }
        public QuestionTypeInForm.Type QuestionType { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public static Question Create(
            Guid formId,
            Guid userId,
            string questionText,
            QuestionTypeInForm.Type questionType,
            DateTimeOffset now
            )
        {
            return new Question
            {
                Id = Guid.NewGuid(),
                FormId = formId,
                CreatorId = userId,
                QuestionText = questionText,
                QuestionType = questionType,
                CreatedAt = now
            };
        }
    }
}
