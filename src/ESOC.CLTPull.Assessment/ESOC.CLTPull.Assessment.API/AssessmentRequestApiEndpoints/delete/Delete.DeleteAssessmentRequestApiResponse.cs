using ESOC.CLTPull.WebApi;
using System;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class DeleteAssessmentRequestApiResponse : BaseResponse
    {
        public DeleteAssessmentRequestApiResponse(Guid correlationId) : base(correlationId)
        {
        }

        public DeleteAssessmentRequestApiResponse()
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}
