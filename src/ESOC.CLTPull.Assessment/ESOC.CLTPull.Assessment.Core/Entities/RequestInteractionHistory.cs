using System;
using System.Collections.Generic;

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class RequestInteractionHistory: BaseEntity
    {
        public int RequestInteractionHistoryId { get; set; }
        public int RequestInteractionId { get; set; }
        public int? RequestId { get; set; }
        public int? InteractionStatusId { get; set; }
        public string InteractionDescription { get; set; }
        public int? SourceServiceId { get; set; }
        public int? DestinationServiceId { get; set; }
        public int? InteractionSpanId { get; set; }
        public int? ObjectofInteractionId { get; set; }
        public string NotesOnObjectNaming { get; set; }
        public string DataContentType { get; set; }
        public bool? IsDataFileContainsHeaderTrailerFooterRecords { get; set; }
        public int? InteractionTriggerTypeId { get; set; }
        public string NotesOnTrigger { get; set; }
        public int? HelperAppOrTeamId { get; set; }
        public string EcgconfigurationId { get; set; }
        public int? InteractionMechanismId { get; set; }
        public int? FrequencyIntervalId { get; set; }
        public int? InstancesPerFrequencyIntervalId { get; set; }
        public string DailyIntervalDays { get; set; }
        public string MonthlyIntervalMonths { get; set; }
        public bool? IsDataSentOnUsaholidays { get; set; }
        public bool? IsDataSentOnIndiaHolidays { get; set; }
        public string ExpectedTransmissionStartTimeCst { get; set; }
        public int? ExpectedMaximumTransmissionDurationInHours { get; set; }
        public string NotesOnFrequency { get; set; }
        public string NotesOnSourceDataCreation { get; set; }
        public string NotesOnDestinationDataArrivalAndValidation { get; set; }
        public string NotesOnDestinationDataLoadingAndFinalLocation { get; set; }
        public string InteractionFailureModes { get; set; }
        public string NotesOnReconciliationControls { get; set; }
        public string NotesOnTimeRelatedControls { get; set; }
        public string NotesOnThresholdControls { get; set; }
        public string NotesOnOtherControls { get; set; }
        public string ReferralToOtherTeams { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public string InteractionAction { get; set; }
        public int? InteractionReviewStatusId { get; set; }
        public int? ObjectDataFormatId { get; set; }
        public DateTime? LastAccessedDate { get; set; }
        public string NonServiceDataDestinationName { get; set; }
        public string NonServiceDataSourceName { get; set; }
        public int? CompanionFileTypeId { get; set; }
    }
}
