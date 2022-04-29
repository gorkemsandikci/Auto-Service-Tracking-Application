using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class QuestionCategory
    {
        public QuestionCategory()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int ChecklistId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Parent { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Checklist Checklist { get; set; } = null!;
        public virtual ICollection<Question> Questions { get; set; }
    }
}
