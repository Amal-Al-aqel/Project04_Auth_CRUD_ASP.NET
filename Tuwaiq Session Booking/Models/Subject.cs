using Abp.Runtime.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tuwaiq_Session_Booking.Data;

namespace Tuwaiq_Session_Booking.Models
{
    
    public class Subject
    {
        public int Id { set; get; }
        public string SubjectName { set; get; }
        public ICollection<Session> Sessions { set; get; }
    }

    public class SubjectValidator : AbstractValidator<Subject>
    {
        private readonly ApplicationDbContext _db;

        public SubjectValidator(ApplicationDbContext context)
        {
            _db = context;
            RuleFor(x => x.SubjectName).Must(BeUniqueName).WithMessage("Subject already exists");
        }

        private bool BeUniqueName(string name)
        {
            return  _db.Subjects.FirstOrDefault(x => x.SubjectName == name) == null;
        }
    }
}
