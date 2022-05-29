using System;
using System.Collections.Generic;

#nullable disable

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class RequestType
    {
        public RequestType()
        {
            AssesmentRequests = new HashSet<Request>();
        }

        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Request> AssesmentRequests { get; set; }
    }
}
