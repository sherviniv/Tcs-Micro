using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Identity.Domain.Models;

namespace Tcs.Identity.Api.Handler
{
    interface IJwtHandler
    {
        string Generate(ApplicationUser user);
    }
}
