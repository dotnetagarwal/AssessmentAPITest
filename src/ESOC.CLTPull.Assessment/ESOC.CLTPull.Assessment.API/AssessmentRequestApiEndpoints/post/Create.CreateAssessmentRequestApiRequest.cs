using ESOC.CLTPull.WebApi;
using System;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class CreateAssessmentRequestApiRequest : BaseRequest 
    {
        private DateTime? _createdDate;
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
        public string CreatedBy { get; set; }
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
