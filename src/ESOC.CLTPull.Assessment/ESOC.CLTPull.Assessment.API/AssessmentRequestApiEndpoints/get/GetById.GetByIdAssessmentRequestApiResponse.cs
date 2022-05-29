using ESOC.CLTPull.WebApi;
using System;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class GetByIdAssessmentRequestApiResponse : BaseResponse
    {
        public GetByIdAssessmentRequestApiResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetByIdAssessmentRequestApiResponse()
        {
        }

        public AssessementRequestDto AssessmentRequestObject { get; set; }
    }
}
