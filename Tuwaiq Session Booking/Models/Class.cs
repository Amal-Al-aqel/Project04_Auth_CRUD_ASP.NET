using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuwaiq_Session_Booking.Data;

namespace Tuwaiq_Session_Booking.Models
{
    public class Class
    {
        public int Id { set; get; }
        public string ClassName { set; get; }
        public string Floor { set; get; }
        public ICollection<Session> Sessions { set; get; }
    }

    public class ClassValidator : AbstractValidator<Class>
    {
        private readonly ApplicationDbContext _db;

        public ClassValidator(ApplicationDbContext context)
        {
            _db = context;
            RuleFor(x => x.ClassName).Must(BeUniqueName).WithMessage("Class already exists");
        }

        private bool BeUniqueName(string name)
        {
            return _db.Classes.FirstOrDefault(x => x.ClassName == name) == null;
        }
    }
}
