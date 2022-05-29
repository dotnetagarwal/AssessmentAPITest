CREATE VIEW [dbo].[vw_GetRequestListData]
AS
SELECT
RequestId
,rt.RequestTypeId
,rt.RequestTypeName
,r.RequestTitle
,r.RequestDescription
,rc.RequestChannelId
,rc.RequestChannelName
,r.InitialRequestDate
,r.CustomerName
,r.CustomerInfo
,lob.LineOfBusinessId
,lob.LineOfBusinessName
,r.FundingSource
,r.RequestLead
,rs.RequestServiceId
,rs.RequestServiceName
,r.IsStartDateConfirmed
,rst.RequestStateId
,rst.RequestStateName
,r.TargetStartDate
,r.ActualStartDate
,r.TargetFinishDate
,r.NumberOfInteractionsAssessed
,r.ActualFinishDate
,r.CancelDate
,r.Notes
,r.RequestDocumentation
,r.PRJIDOrServiceNowTicket
,r.PRJName
,asp.AssessmentScopeId
,asp.AssessmentScopeName
,ast.AssessmentStatusId
,ast.AssessmentStatusName
,r.CreatedBy
,r.CreatedDate
,r.ModifiedBy
,r.ModifiedDate
,r.IsActive
,r.ProgramName
,r.ProgramManager
,r.RequestServiceSLO
,r.EsocAnalyst
,r.AssessmentTC
,r.AssessmentTargetFinishDate
,r.AssessmentActualFinishDate

FROM Request r
LEFT OUTER JOIN RequestType rt
ON r.RequestTypeId = rt.RequestTypeId
LEFT OUTER JOIN RequestChannel rc
ON r.RequestChannelId = rc.RequestChannelId
LEFT OUTER JOIN LineOfBusiness lob
ON r.LineOfBusinessId = lob.LineOfBusinessId
LEFT OUTER JOIN RequestService rs
ON r.RequestServiceId = rs.RequestServiceId
LEFT OUTER JOIN RequestState rst
ON r.RequestStateId = rst.RequestStateId
LEFT OUTER JOIN AssessmentScope asp
ON r.AssessmentScopeId = asp.AssessmentScopeId
LEFT OUTER JOIN AssessmentStatus ast
ON r.AssessmentStatusId = ast.AssessmentStatusId

where r.isActive = 1