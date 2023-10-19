using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class UserIban
    {
        public int Id { get; set; }
        public string Iban { get; set; } = null!;
    }
}
