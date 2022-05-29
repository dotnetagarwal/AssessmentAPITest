using ESOC.CLTPull.WebApi;
using System;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class CreateAssessmentRequestApiResponse : BaseResponse
    {
        public CreateAssessmentRequestApiResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateAssessmentRequestApiResponse()
        {
        }
        public int RequestId { get; set; }
        public int? RequestTypeId { get; set; }
        public string RequestTitle { get; set; }
        public string ProgramName { get; set; }
        public string ProgramManager { get; set; }
        public int? RequestChannelId { get; set; }
        public DateTime? InitialRequestDate { get; set; }
        public string RequestLead { get; set; }
        public int? RequestStateId { get; set; }
        public string RequestDocumentation { get; set; }
        public string EsocAnalyst { get; set; }
        public int? AssessmentStatusId { get; set; }

    }
}
