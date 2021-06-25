using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tuwaiq_Session_Booking.Data;

namespace Tuwaiq_Session_Booking.Models
{
    public class Session
    {
        public int Id { set; get; }

        public bool Confirmed { set; get; }
        public bool Passed { set; get; }

        [DataType(DataType.Date)]
        public DateTime SessionTime { set; get; }
        public float Duration { set; get; }
        public string Location { set; get; }

        public Subject Subject { set; get; }
        public int SubjectId { set; get; }

        public Class Class { set; get; }
        public int ClassId { set; get; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
