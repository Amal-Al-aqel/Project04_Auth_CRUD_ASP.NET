using Microsoft.AspNetCore.Identity;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuwaiq_Session_Booking.Data;

namespace Tuwaiq_Session_Booking.Models
{
    public class Profile
    {
        //UserManager<IdentityUser> TheUserManager;
        //UserManager.GetUserId(User);
        public int Id { get; set; }
        public int ImageSize { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
/*        public HttpPostedFileBase ImageFile {get; set;}
*/
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        //public TheUserManager;
        //public int InstructorId { set; get; }
    }
}
