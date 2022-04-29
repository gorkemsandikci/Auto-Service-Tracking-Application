using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class ChecklistType
    {
        public ChecklistType()
        {
            Checklists = new HashSet<Checklist>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Checklist> Checklists { get; set; }
    }
}
