using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tuwaiq_Session_Booking.Models;

namespace Tuwaiq_Session_Booking.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string HomeTown { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Session> Sessions { set; get; }

       
    }    
}
