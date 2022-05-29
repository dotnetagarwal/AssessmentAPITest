using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Entities.DTOs
{
    public class RequestListDataDTO
    {
        public int RequestId { get; set; }
        public int? RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDescription { get; set; }
        public string ProgramName { get; set; }
        public string ProgramManager { get; set; }
        public int? RequestChannelId { get; set; }
        public string RequestChannelName { get; set; }
        public DateTime? InitialRequestDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerInfo { get; set; }
        public string LineOfBusinessName { get; set; }
        public int? LineOfBusinessId { get; set; }
        public string FundingSource { get; set; }
        public string RequestLead { get; set; }
        public int? RequestServiceId { get; set; }
        public string RequestServiceName { get; set; }
        public bool? IsStartDateConfirmed { get; set; }
        public int? RequestStateId { get; set; }
        public string RequestStateName { get; set; }       
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
        public string ESOCAnalyst { get; set; }        
        public int? AssessmentScopeId { get; set; }
        public int? AssessmentStatusId { get; set; }
        public string AssessmentStatusName { get; set; }
        public string AssessmentScopeName { get; set; }
        public string AssessmentTC { get; set; }
        public string RequestServiceSLO { get; set; }        
        public DateTime? AssessmentTargetFinishDate { get; set; }
        public DateTime? AssessmentActualFinishDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
