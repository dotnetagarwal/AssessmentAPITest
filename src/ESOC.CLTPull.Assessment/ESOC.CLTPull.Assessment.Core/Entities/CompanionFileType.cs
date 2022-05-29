using System;
using System.Collections.Generic;

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class CompanionFileType
    {
        public CompanionFileType()
        {
            RequestInteraction = new HashSet<RequestInteraction>();
        }
        public int CompanionFileTypeId { get; set; }
        public string CompanionFileTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<RequestInteraction> RequestInteraction { get; set; }

    }
}
