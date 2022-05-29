using System;
using System.Collections.Generic;

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class LineOfBusiness
    {
        public LineOfBusiness()
        {
            Request = new HashSet<Request>();
        }

        public int LineOfBusinessId { get; set; }
        public string LineOfBusinessName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
