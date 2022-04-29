using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class AuditCategory
    {
        public AuditCategory()
        {
            Audits = new HashSet<Audit>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Audit> Audits { get; set; }
    }
}
