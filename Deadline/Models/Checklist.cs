using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class Checklist
    {
        public Checklist()
        {
            Audits = new HashSet<Audit>();
            QuestionCategories = new HashSet<QuestionCategory>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int ChecklistTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int? RevisionNumber { get; set; }
        public DateTime? RevisionDate { get; set; }
        public int IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ChecklistType ChecklistType { get; set; } = null!;
        public virtual ICollection<Audit> Audits { get; set; }
        public virtual ICollection<QuestionCategory> QuestionCategories { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
