using System;
using System.Collections.Generic;

#nullable disable

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class AssessmentStatus
    {
        public AssessmentStatus()
        {
            //RequestAssessment = new HashSet<RequestAssessment>();
            Request = new HashSet<Request>();
        }

        public int AssessmentStatusId { get; set; }
        public string AssessmentStatusName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        //public virtual ICollection<RequestAssessment> RequestAssessment { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}
