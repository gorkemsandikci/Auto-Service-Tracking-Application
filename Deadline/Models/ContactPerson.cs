using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class ContactPerson
    {
        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public string? Position { get; set; }
        public int BranchId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual CustomerBranch Branch { get; set; } = null!;
    }
}
