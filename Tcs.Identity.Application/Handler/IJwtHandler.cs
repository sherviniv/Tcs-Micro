using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Identity.Domain.Models;

namespace Tcs.Identity.Application.Handler
{
    public interface IJwtHandler
    {
        string Generate(ApplicationUser user);
    }
}
