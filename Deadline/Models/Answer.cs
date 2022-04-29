using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class Answer
    {
        public Answer()
        {
            AnswerPhotos = new HashSet<AnswerPhoto>();
            AnswerReasons = new HashSet<AnswerReason>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int QuestionId { get; set; }
        public int AuditId { get; set; }
        public short Answer1 { get; set; }
        public double PointTaken { get; set; }
        public int UserId { get; set; }
        public string? Comment { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual AnswerType Answer1Navigation { get; set; } = null!;
        public virtual Audit Audit { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<AnswerPhoto> AnswerPhotos { get; set; }
        public virtual ICollection<AnswerReason> AnswerReasons { get; set; }
    }
}
