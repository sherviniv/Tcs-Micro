using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Identity.Domain.Models;

namespace Tcs.Identity.Application.Handler
{
    interface IJwtHandler
    {
        string Generate(ApplicationUser user);
    }
}
