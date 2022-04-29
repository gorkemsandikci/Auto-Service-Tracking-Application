using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class Reason
    {
        public Reason()
        {
            AnswerReasons = new HashSet<AnswerReason>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int QuestionId { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual ICollection<AnswerReason> AnswerReasons { get; set; }
    }
}
