using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class CustomerRegion
    {
        public CustomerRegion()
        {
            CustomerBranches = new HashSet<CustomerBranch>();
        }

        public int Id { get; set; }
        public string Guid { get; set; } = null!;
        public int CustomerId { get; set; }
        public int Parent { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<CustomerBranch> CustomerBranches { get; set; }
    }
}
