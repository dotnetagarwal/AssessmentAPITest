using ESOC.CLTPull.WebApi;
using System;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class UpdateAssessmentRequestApiResponse : BaseResponse
    {
        public UpdateAssessmentRequestApiResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UpdateAssessmentRequestApiResponse()
        {
        }

        public ESOC.CLTPull.Assessment.Core.Entities.Request Request { get; set; }
    }
}
