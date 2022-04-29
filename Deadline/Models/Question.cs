using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            Reasons = new HashSet<Reason>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int ChecklistId { get; set; }
        public int QuestionCategoryId { get; set; }
        public int QuestionType { get; set; }
        public string Question1 { get; set; } = null!;
        public string? Description { get; set; }
        public double Point { get; set; }
        public int? OrderNumber { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Checklist Checklist { get; set; } = null!;
        public virtual QuestionCategory QuestionCategory { get; set; } = null!;
        public virtual QuestionType QuestionTypeNavigation { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Reason> Reasons { get; set; }
    }
}
