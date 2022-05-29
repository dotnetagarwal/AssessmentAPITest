using ESOC.CLTPull.WebApi;
using System;

namespace CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints
{
    public class CreateAssessmentRequestInteractionApiRequest : BaseRequest
    {
        private DateTime? _createdDate;
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
        public string CreatedBy { get; set; }
        public int? InstancesPerFrequencyIntervalId { get; set; }

        public DateTime? CreatedDate
        {
            get
            {
                return this._createdDate.HasValue
                   ? this._createdDate.Value
                   : DateTime.Now;
            }

            set { this._createdDate = value; }

        }


    }

}
