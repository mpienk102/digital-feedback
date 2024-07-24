using DotNetBoilerplate.Api.Organizations;

namespace DotNetBoilerplate.Api.Questions
{
    internal static class QuestionsEndpoints
    {
        public const string BasePath = "questions";
        public const string Tags = "Questions";

        public static void MapQuestionsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(BasePath).WithTags(Tags);

            group
                .MapEndpoint<CreateQuestionEndpoint>();
        }
    }
}
