using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Authorization
{
    public class MinimumTimeWork : IAuthorizationRequirement
    {
        public int MinimumMounth { get;  }

        public MinimumTimeWork(int minimumMounth)
        {
            MinimumMounth = minimumMounth;
        }
    }
}
