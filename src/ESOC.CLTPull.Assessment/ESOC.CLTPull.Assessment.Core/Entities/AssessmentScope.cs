using System;
using System.Collections.Generic;

#nullable disable

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class AssessmentScope
    {
        public AssessmentScope()
        {
            Request = new HashSet<Request>();
            //RequestAssessment = new HashSet<RequestAssessment>();
        }

        public int AssessmentScopeId { get; set; }
        public string AssessmentScopeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        //public virtual ICollection<RequestAssessment> RequestAssessment { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}
