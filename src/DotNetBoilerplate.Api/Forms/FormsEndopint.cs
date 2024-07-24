namespace DotNetBoilerplate.Api.Forms
{
    internal static class FormsEndopint
    {
        public const string BasePath = "forms";
        public const string Tags = "Forms";

        public static void MapFormsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(BasePath).WithTags(Tags);

            group
                .MapEndpoint<CreateFormEndpoint>();
        }
    }
}
