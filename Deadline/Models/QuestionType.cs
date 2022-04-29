using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; }
    }
}
