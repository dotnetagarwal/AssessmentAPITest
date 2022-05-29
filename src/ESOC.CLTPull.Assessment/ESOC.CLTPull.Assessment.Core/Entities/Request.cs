namespace ESOC.CLTPull.Assessment.Core.Entities
{
    using Ardalis.GuardClauses;
    using System;
    using System.Collections.Generic;

    public partial class Request : BaseEntity
    {
        public Request()
        {
            RequestInteraction = new HashSet<RequestInteraction>();
        }

        public int RequestId { get; set; }
        public int? RequestTypeId { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDescription { get; set; }
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
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public string ProgramName { get; set; }
        public string ProgramManager { get; set; }
        public string RequestServiceSlo { get; set; }
        public string EsocAnalyst { get; set; }
        public string AssessmentTc { get; set; }
        public DateTime? AssessmentTargetFinishDate {get;set;}
        public DateTime? AssessmentActualFinishDate { get; set; }
        public virtual AssessmentScope AssessmentScope { get; set; }
        public virtual AssessmentStatus AssessmentStatus { get; set; }
        public virtual LineOfBusiness LineOfBusiness { get; set; }
        public virtual RequestChannel RequestChannel { get; set; }
        public virtual RequestService RequestService { get; set; }
        public virtual RequestState RequestState { get; set; }
        public virtual RequestType RequestType { get; set; }
        public virtual ICollection<RequestInteraction> RequestInteraction { get; set; }
        public void UpdateDetails(string assessmentype, string description)
        {
            Guard.Against.NullOrEmpty(assessmentype, nameof(assessmentype));
            Guard.Against.NullOrEmpty(description, nameof(description));
            RequestDescription = description;
        }

    }
}
