using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class AnswerPhoto
    {
        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int AnswerId { get; set; }
        public string Path { get; set; } = null!;
        public string? Comment { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Answer Answer { get; set; } = null!;
    }
}
