using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class AuditsUsersRel
    {
        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int AuditId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Audit Audit { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
