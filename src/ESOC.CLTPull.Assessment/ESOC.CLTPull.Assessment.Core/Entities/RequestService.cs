using System;
using System.Collections.Generic;

#nullable disable

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class RequestService
    {
        public RequestService()
        {
            AssesmentRequests = new HashSet<Request>();
        }

        public int RequestServiceId { get; set; }
        public string RequestServiceName { get; set; }
        //public string RequestServiceSlo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Request> AssesmentRequests { get; set; }
    }
}
