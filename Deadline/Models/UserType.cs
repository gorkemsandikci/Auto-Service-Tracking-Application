using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
