using ESOC.CLTPull.WebApi;
using System;

namespace CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints
{
    public class CreateAssessmentRequestInteractionApiResponse : BaseResponse
    {
        public CreateAssessmentRequestInteractionApiResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateAssessmentRequestInteractionApiResponse()
        {
        }
        public int RequestInteractionId { get; set; }
        public int? RequestId { get; set; }
        public string InteractionDescription { get; set; }
        public int? SourceServiceId { get; set; }
        public string NonServiceDataSourceName { get; set; }
        public string NonServiceDataDestinationName { get; set; }
        public int? DestinationServiceId { get; set; }
        public string DataContentType { get; set; }
        public int? InteractionMechanismId { get; set; }
        public int? FrequencyIntervalId { get; set; }
        public int? InteractionReviewStatusId { get; set; }
        public int? InteractionSpanId { get; set; }
        public int? InstancesPerFrequencyIntervalId { get; set; }

    }
}
