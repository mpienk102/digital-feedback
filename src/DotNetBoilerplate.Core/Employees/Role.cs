using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBoilerplate.Core.Employees
{
    public sealed record Role
    {
        public enum RoleInOrganization
        {
            None, // Defaultowy użytkownik bez uprawnień
            Moderator, // Uprawnienia do może dodawawania pracowników do projektu, może dodawać i edytować projekty
            Admin // Zarządza organizacją, projektami i ich członkami
        }
    }
}
