using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class GetAllAssessmentRequestApiResponse : BaseResponse
    {
        public GetAllAssessmentRequestApiResponse(Guid correlationId) : base(correlationId)
        {

        }

        public GetAllAssessmentRequestApiResponse()
        {
        }

        public ICollection<Request> RequestList { get; set; }
    }
}
