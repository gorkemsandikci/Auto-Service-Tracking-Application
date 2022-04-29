using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class AuditPeriod
    {
        public AuditPeriod()
        {
            Audits = new HashSet<Audit>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Audit> Audits { get; set; }
    }
}
