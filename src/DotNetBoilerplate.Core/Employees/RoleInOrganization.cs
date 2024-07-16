using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBoilerplate.Core.Employees
{
    public record RoleInOrganization
    {
        public enum Role
        {
            None,
            Moderator,
            Admin
        };
    }
}
