namespace DotNetBoilerplate.Api.Answers
{
    internal static class AnswersEndpoints
    {
        public const string BasePath = "answers";
        public const string Tags = "Answers";

        public static void MapAnswersEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(BasePath).WithTags(Tags);

            group
                .MapEndpoint<BrowseAnswersEndpoint>()
                .MapEndpoint<AddAnswerToQuestionEndpoint>();
        }
    }
}
