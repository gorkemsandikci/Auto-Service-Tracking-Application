using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class User
    {
        public User()
        {
            Answers = new HashSet<Answer>();
            AuditsUsersRels = new HashSet<AuditsUsersRel>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int BranchId { get; set; }
        public int UserTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PassWord { get; set; } = null!;
        public string? Signature { get; set; }
        public string? Tel { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual CustomerBranch Branch { get; set; } = null!;
        public virtual UserType UserType { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<AuditsUsersRel> AuditsUsersRels { get; set; }
    }
}
