using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Type { get; set; }
        public DateTime Date { get; set; }
    }
}
