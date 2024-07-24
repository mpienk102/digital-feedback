using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBoilerplate.Core.Questions
{
    public record QuestionTypeInForm
    {
        public enum Type
        {
            rating,
            text
        }
    }
}
