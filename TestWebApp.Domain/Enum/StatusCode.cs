using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApp.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        ServiceNotFound = 20,
        PhotographerNotFound = 400,
        Ok = 001,
        InternalServerError = 002

    }
}
