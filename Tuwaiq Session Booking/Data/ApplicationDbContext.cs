using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tuwaiq_Session_Booking.Models;

namespace Tuwaiq_Session_Booking.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Tuwaiq_Session_Booking.Models.ProjectRole> ProjectRole { get; set; }

        public void MarkAsModified(Subject item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
