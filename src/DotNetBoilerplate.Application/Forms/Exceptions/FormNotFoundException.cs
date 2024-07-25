using DotNetBoilerplate.Shared.Abstractions.Exceptions;


namespace DotNetBoilerplate.Application.Forms.Exceptions
{
    public class FormNotFoundException : CustomException
    {
        public FormNotFoundException(Guid formId) : base($"Form {formId} not found.")
        {

        }
    }
}
