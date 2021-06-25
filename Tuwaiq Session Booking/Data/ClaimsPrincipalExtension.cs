using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tuwaiq_Session_Booking.Data
{
    public static class ClaimsPrincipalExtension
    {

        public static string GetHomeTown(this ClaimsPrincipal principal)
        {
            var homeTown = principal.Claims.FirstOrDefault(c => c.Type == "HomeTown");
            return homeTown?.Value;
        }

        public static string GetFirstName(this ClaimsPrincipal principal)
        {
            var firstName = principal.Claims.FirstOrDefault(c => c.Type == "FirstName");
            return firstName?.Value;
        }

        public static string GetLastName(this ClaimsPrincipal principal)
        {
            var lastName = principal.Claims.FirstOrDefault(c => c.Type == "LastName");
            return lastName?.Value;
        }
    }
}
