using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class GetRequestMasterDataApiResponse : BaseResponse
    {
        public GetRequestMasterDataApiResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetRequestMasterDataApiResponse()
        {
        }

        public  ICollection<LineOfBusiness> LineOfBusiness { get; set; }
        public  ICollection<RequestChannel> RequestChannel { get; set; }
        public  ICollection<RequestService> RequestService { get; set; }
        public  ICollection<RequestState> RequestState { get; set; }
        public  ICollection<RequestType> RequestType { get; set; }
        public  ICollection<AssessmentScope> AssessmentScope { get; set; }
        public  ICollection<AssessmentStatus> AssessmentStatus { get; set; }
        public ICollection<AssessmentDesigners> AssessmentDesigners { get; set; }

    }
}
