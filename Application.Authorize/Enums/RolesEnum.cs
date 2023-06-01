using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authorize.Enums
{
    public enum RolesEnum
    {
        [Description("-")] None,
        [Description("Админ")] Admin,
        [Description("Пользователь")] User
    }
}
