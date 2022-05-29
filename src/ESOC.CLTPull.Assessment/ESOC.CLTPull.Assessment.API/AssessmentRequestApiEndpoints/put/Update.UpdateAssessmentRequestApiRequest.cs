using ESOC.CLTPull.WebApi;
using System.ComponentModel.DataAnnotations;
using System;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class UpdateAssessmentRequestApiRequest : BaseRequest
    {

        public int RequestId { get; set; }
        public int? RequestTypeId { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDescription { get; set; }
        //public int? ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramManager { get; set; }
        public string RequestServiceSlo { get; set; }
        public string EsocAnalyst { get; set; }
        public string AssessmentTc { get; set; }

        public int? RequestChannelId { get; set; }
        public DateTime? InitialRequestDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerInfo { get; set; }
        public int? LineOfBusinessId { get; set; }
        public string FundingSource { get; set; }
        public string RequestLead { get; set; }
        public int? RequestServiceId { get; set; }
        public bool? IsStartDateConfirmed { get; set; }
        public int? RequestStateId { get; set; }
        public int? RequestAssessmentId { get; set; }
        public DateTime? TargetStartDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? TargetFinishDate { get; set; }
        public int? NumberOfInteractionsAssessed { get; set; }
        public DateTime? ActualFinishDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public string Notes { get; set; }
        public string RequestDocumentation { get; set; }
        public string PrjidorServiceNowTicket { get; set; }
        public string Prjname { get; set; }
        public int? AssessmentScopeId { get; set; }
        public int? AssessmentStatusId { get; set; }       
        public DateTime? AssessmentTargetFinishDate { get; set; }
        public DateTime? AssessmentActualFinishDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
