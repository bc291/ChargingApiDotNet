using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Charger.WebUI.Infrastructure.Abstract
{
    public interface IAuthProv
    {
        bool Authenticate(string username, string password);
    }
}