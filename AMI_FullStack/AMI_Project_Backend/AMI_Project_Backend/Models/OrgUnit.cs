using System.Collections.Generic;

namespace AMI_Project_Backend.Models
{
    public partial class OrgUnit
    {
        public int OrgUnitId { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? ParentId { get; set; }

        // Optional: for hierarchy
        public virtual OrgUnit? Parent { get; set; }
        public virtual ICollection<OrgUnit> Children { get; set; } = new List<OrgUnit>();
        public virtual ICollection<Consumer> Consumers { get; set; } = new List<Consumer>();
    }
}
