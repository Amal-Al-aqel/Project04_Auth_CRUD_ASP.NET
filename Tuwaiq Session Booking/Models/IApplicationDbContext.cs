using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuwaiq_Session_Booking.Models
{
    interface IApplicationDbContext : IDisposable
    {
        DbSet<Subject> Subjects { get; }
        int SaveChanges();
        void MarkAsModified(Subject item);
    }
    
}
