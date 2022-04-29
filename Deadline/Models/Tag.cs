using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class Tag
    {
        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
