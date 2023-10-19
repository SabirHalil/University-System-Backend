using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class User
    {

        public int Id { get; set; }
        public long IdCard { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = null!;
        public int StatusId { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string DadName { get; set; } = null!;
        public string MomName { get; set; } = null!;

    }
}
