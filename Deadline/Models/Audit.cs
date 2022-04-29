using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class Audit
    {
        public Audit()
        {
            Answers = new HashSet<Answer>();
            AuditsUsersRels = new HashSet<AuditsUsersRel>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int BranchId { get; set; }
        public int ChecklistId { get; set; }
        public int AuditTypeId { get; set; }
        public int? FollowUpAuditId { get; set; }
        public int AuditCategoryId { get; set; }
        public int? AuditPeriodId { get; set; }
        public int AuditStatusId { get; set; }
        public DateTime? StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Notes { get; set; }
        public double? Score { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual AuditCategory AuditCategory { get; set; } = null!;
        public virtual AuditPeriod? AuditPeriod { get; set; }
        public virtual AuditStatus AuditStatus { get; set; } = null!;
        public virtual AuditType AuditType { get; set; } = null!;
        public virtual CustomerBranch Branch { get; set; } = null!;
        public virtual Checklist Checklist { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<AuditsUsersRel> AuditsUsersRels { get; set; }
    }
}
