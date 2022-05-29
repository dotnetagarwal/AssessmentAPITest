using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Entities.DTOs
{
    public class RequestMasterDataDTO
    {
        public virtual ICollection<LineOfBusiness> LineOfBusiness { get; set; }
        public virtual ICollection<RequestChannel> RequestChannel { get; set; }
        public virtual ICollection<RequestService> RequestService { get; set; }
        public virtual ICollection<RequestState> RequestState { get; set; }
        public virtual ICollection<RequestType> RequestType { get; set; }
        public virtual ICollection<AssessmentScope> AssessmentScope { get; set; }
        public virtual ICollection<AssessmentStatus> AssessmentStatus { get; set; }
        public virtual ICollection<AssessmentDesigners> AssessmentDesigners { get; set; }
    }
}
