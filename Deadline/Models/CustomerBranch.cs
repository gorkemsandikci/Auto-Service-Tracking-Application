using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class CustomerBranch
    {
        public CustomerBranch()
        {
            Audits = new HashSet<Audit>();
            ContactPeople = new HashSet<ContactPerson>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int CustomerId { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; } = null!;
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual CustomerRegion Region { get; set; } = null!;
        public virtual ICollection<Audit> Audits { get; set; }
        public virtual ICollection<ContactPerson> ContactPeople { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
