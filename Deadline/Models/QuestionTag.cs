using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class QuestionTag
    {
        public int QuestionId { get; set; }
        public int TagId { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual Tag Tag { get; set; } = null!;
    }
}
