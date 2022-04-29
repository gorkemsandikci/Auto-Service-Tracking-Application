using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class AnswerReason
    {
        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int AnswerId { get; set; }
        public int ReasonId { get; set; }
        public string? Comment { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Answer Answer { get; set; } = null!;
        public virtual Reason Reason { get; set; } = null!;
    }
}
