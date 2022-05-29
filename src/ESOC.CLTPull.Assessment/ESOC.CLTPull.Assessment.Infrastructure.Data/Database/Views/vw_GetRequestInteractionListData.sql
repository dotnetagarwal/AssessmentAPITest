CREATE VIEW [dbo].[vw_GetRequestInteractionListData]
AS
SELECT
 RequestInteractionId
,ri.RequestId
,iss.InteractionStatusId
,iss.InteractionStatusName
,ri.InteractionDescription
,ss.SourceServiceId
,ss.SourceServiceName
,ds.DestinationServiceId
,ds.DestinationServiceName
,isp.InteractionSpanId
,isp.InteractionSpanName
,oi.ObjectofInteractionId
,oi.ObjectofInteractionName
,ri.NotesOnObjectNaming
,ri.DataContentType
,ri.IsDataFileContainsHeaderTrailerFooterRecords
,it.InteractionTriggerTypeId
,it.InteractionTriggerTypeName
,ri.NotesOnTrigger
,h.HelperAppOrTeamId
,h.HelperAppOrTeamName
,ri.ECGConfigurationId
,im.InteractionMechanismId
,im.InteractionMechanismName
,fi.FrequencyIntervalId
,fi.FrequencyIntervalName
,i.InstancesPerFrequencyIntervalId
,i.InstancesPerFrequencyIntervalName
,ri.DailyIntervalDays
,ri.MonthlyIntervalMonths
,ri.IsDataSentOnUSAHolidays
,ri.IsDataSentOnIndiaHolidays
,ri.ExpectedTransmissionStartTimeCST
,ri.ExpectedMaximumTransmissionDurationInHours
,ri.NotesOnFrequency
,ri.NotesOnSourceDataCreation
,ri.NotesOnDestinationDataArrivalAndValidation
,ri.NotesOnDestinationDataLoadingAndFinalLocation
,ri.InteractionFailureModes
,ri.NotesOnReconciliationControls
,ri.NotesOnTimeRelatedControls
,ri.NotesOnThresholdControls
,ri.NotesOnOtherControls
,ri.ReferralToOtherTeams
,ri.CreatedBy
,ri.CreatedDate
,ri.ModifiedBy
,ri.ModifiedDate
,ri.IsActive
,ri.InteractionAction
,irs.InteractionReviewStatusId
,irs.InteractionReviewStatusName
,o.ObjectDataFormatId
,o.ObjectDataFormatName
,ri.LastAccessedDate
,ri.NonServiceDataSourceName
,ri.NonServiceDataDestinationName
,c.CompanionFileTypeId
,c.CompanionFileTypeName

FROM RequestInteraction ri
LEFT OUTER JOIN HelperAppOrTeam h
ON ri.HelperAppOrTeamId = h.HelperAppOrTeamId
LEFT OUTER JOIN SourceService ss
ON ri.SourceServiceId = ss.SourceServiceId
LEFT OUTER JOIN DestinationService ds
ON ri.DestinationServiceId = ds.DestinationServiceId
LEFT OUTER JOIN InstancesPerFrequencyInterval i
ON ri.InstancesPerFrequencyIntervalId = i.InstancesPerFrequencyIntervalId
LEFT OUTER JOIN FrequencyInterval fi
ON ri.FrequencyIntervalId = fi.FrequencyIntervalId
LEFT OUTER JOIN InteractionMechanism im
ON ri.InteractionMechanismId = im.InteractionMechanismId
LEFT OUTER JOIN InteractionTriggerType it
ON ri.InteractionTriggerTypeId = it.InteractionTriggerTypeId
LEFT OUTER JOIN ObjectDataFormat o
ON ri.ObjectDataFormatId = o.ObjectDataFormatId
LEFT OUTER JOIN ObjectofInteraction oi
ON ri.ObjectofInteractionId = oi.ObjectofInteractionId
LEFT OUTER JOIN InteractionStatus iss
ON ri.InteractionStatusId = iss.InteractionStatusId
LEFT OUTER JOIN InteractionSpan isp
ON ri.InteractionSpanId = isp.InteractionSpanId
LEFT OUTER JOIN InteractionReviewStatus irs
ON ri.InteractionReviewStatusId = irs.InteractionReviewStatusId
LEFT OUTER JOIN CompanionFileType c
ON ri.CompanionFileTypeId = c.CompanionFileTypeId
WHERE ri.IsActive=1