using System;
using System.Collections.Generic;

namespace Deadline.Models
{
    public partial class Customer
    {
        public Customer()
        {
            AuditCategories = new HashSet<AuditCategory>();
            AuditPeriods = new HashSet<AuditPeriod>();
            CustomerBranches = new HashSet<CustomerBranch>();
            CustomerRegions = new HashSet<CustomerRegion>();
        }

        public int Id { get; set; }
        public string? Guid { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<AuditCategory> AuditCategories { get; set; }
        public virtual ICollection<AuditPeriod> AuditPeriods { get; set; }
        public virtual ICollection<CustomerBranch> CustomerBranches { get; set; }
        public virtual ICollection<CustomerRegion> CustomerRegions { get; set; }
    }
}
