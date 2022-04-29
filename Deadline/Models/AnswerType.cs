using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class AnswerType
    {
        public AnswerType()
        {
            Answers = new HashSet<Answer>();
        }

        public short Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
