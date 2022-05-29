using Ardalis.ApiEndpoints;
using AutoMapper;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    public class Update : BaseAsyncEndpoint.WithRequest<UpdateAssessmentRequestInteractionApiRequest>
        .WithResponse<UpdateAssessmentRequestInteractionApiResponse>
    {
        private readonly IAsyncRepository<RequestInteraction> _itemRepository;
        private readonly IAsyncRepository<RequestInteractionHistory> _itemHistoryRepository;
        private readonly IMapper _mapper;

        public Update(IAsyncRepository<RequestInteraction> itemRepository, IAsyncRepository<RequestInteractionHistory> itemHistoryRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _itemHistoryRepository = itemHistoryRepository;
            _mapper = mapper;
        }

        [HttpPut("api/assessment-requests-interaction")]
        [SwaggerOperation(
            Summary = "Updates an assessment request interaction",
            Description = "Updates an assessment request interaction",
            OperationId = "assessment-requests-interaction.update",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAssessmentRequestInteractionApiResponse>> HandleAsync(UpdateAssessmentRequestInteractionApiRequest apiRequest, CancellationToken cancellationToken)
        {
            RequestInteraction requestInteractionItem;
            var response = new UpdateAssessmentRequestInteractionApiResponse(apiRequest.CorrelationId());
            if (apiRequest.RequestInteractionId != 0)
            {
                requestInteractionItem = await _itemRepository.GetByIdAsync(apiRequest.RequestInteractionId);
                var historyItem = _mapper.Map<RequestInteractionHistory>(requestInteractionItem);
                requestInteractionItem = PopulateRequestInteractionItem(apiRequest, requestInteractionItem);
                if (null != apiRequest?.RequestId && null != requestInteractionItem?.RequestId && historyItem.RequestId != apiRequest.RequestId)
                {
                    requestInteractionItem.InteractionReviewStatusId = (int)InteractionReviewStatusEnum.ReassessmentInProgress;
                    requestInteractionItem.LastAccessedDate = null;

                    //Add the existing snapshot to RequestInteractionHistory table
                    await _itemHistoryRepository.AddAsync(historyItem);
                }
                int noOfRowsUpdated = await _itemRepository.UpdateAsync(requestInteractionItem);
                if (noOfRowsUpdated > 0)
                    response.RequestInteraction = requestInteractionItem;
            }
            else
            {
                requestInteractionItem = new RequestInteraction();
                requestInteractionItem = PopulateRequestInteractionItem(apiRequest, requestInteractionItem);
                requestInteractionItem = await _itemRepository.AddAsync(requestInteractionItem);
                response.RequestInteraction = requestInteractionItem;
            }
            return Ok(response);
        }
        private static RequestInteraction PopulateRequestInteractionItem(UpdateAssessmentRequestInteractionApiRequest apiRequest, RequestInteraction requestInteractionItem)
        {
            requestInteractionItem.RequestId = apiRequest.RequestId;
            requestInteractionItem.InteractionStatusId = apiRequest.InteractionStatusId;
            requestInteractionItem.InteractionDescription = apiRequest.InteractionDescription;
            requestInteractionItem.SourceServiceId = apiRequest.SourceServiceId;
            requestInteractionItem.NonServiceDataSourceName = apiRequest.NonServiceDataSourceName;
            requestInteractionItem.NonServiceDataDestinationName = apiRequest.NonServiceDataDestinationName;
            requestInteractionItem.DestinationServiceId = apiRequest.DestinationServiceId;
            requestInteractionItem.InteractionSpanId = apiRequest.InteractionSpanId;
            requestInteractionItem.ObjectofInteractionId = apiRequest.ObjectofInteractionId;
            requestInteractionItem.NotesOnObjectNaming = apiRequest.NotesOnObjectNaming;
            requestInteractionItem.DataContentType = apiRequest.DataContentType;
            requestInteractionItem.IsDataFileContainsHeaderTrailerFooterRecords = apiRequest.IsDataFileContainsHeaderTrailerFooterRecords;
            requestInteractionItem.CompanionFileTypeId = apiRequest.CompanionFileTypeId;
            requestInteractionItem.InteractionTriggerTypeId = apiRequest.InteractionTriggerTypeId;
            requestInteractionItem.NotesOnTrigger = apiRequest.NotesOnTrigger;
            requestInteractionItem.HelperAppOrTeamId = apiRequest.HelperAppOrTeamId;
            requestInteractionItem.EcgconfigurationId = apiRequest.EcgconfigurationId;
            requestInteractionItem.InteractionMechanismId = apiRequest.InteractionMechanismId;
            requestInteractionItem.FrequencyIntervalId = apiRequest.FrequencyIntervalId;
            requestInteractionItem.InstancesPerFrequencyIntervalId = apiRequest.InstancesPerFrequencyIntervalId;
            requestInteractionItem.DailyIntervalDays = apiRequest.DailyIntervalDays;
            requestInteractionItem.MonthlyIntervalMonths = apiRequest.MonthlyIntervalMonths;
            requestInteractionItem.IsDataSentOnUsaholidays = apiRequest.IsDataSentOnUsaholidays;
            requestInteractionItem.IsDataSentOnIndiaHolidays = apiRequest.IsDataSentOnIndiaHolidays;
            requestInteractionItem.ExpectedTransmissionStartTimeCst = apiRequest.ExpectedTransmissionStartTimeCst;
            requestInteractionItem.ExpectedMaximumTransmissionDurationInHours = apiRequest.ExpectedMaximumTransmissionDurationInHours;
            requestInteractionItem.NotesOnFrequency = apiRequest.NotesOnFrequency;
            requestInteractionItem.NotesOnSourceDataCreation = apiRequest.NotesOnSourceDataCreation;
            requestInteractionItem.NotesOnDestinationDataArrivalAndValidation = apiRequest.NotesOnDestinationDataArrivalAndValidation;
            requestInteractionItem.NotesOnDestinationDataLoadingAndFinalLocation = apiRequest.NotesOnDestinationDataLoadingAndFinalLocation;
            requestInteractionItem.InteractionFailureModes = apiRequest.InteractionFailureModes;
            requestInteractionItem.NotesOnReconciliationControls = apiRequest.NotesOnReconciliationControls;
            requestInteractionItem.NotesOnTimeRelatedControls = apiRequest.NotesOnTimeRelatedControls;
            requestInteractionItem.NotesOnThresholdControls = apiRequest.NotesOnThresholdControls;
            requestInteractionItem.NotesOnOtherControls = apiRequest.NotesOnOtherControls;
            requestInteractionItem.ReferralToOtherTeams = apiRequest.ReferralToOtherTeams;
            requestInteractionItem.CreatedBy = apiRequest.CreatedBy;
            requestInteractionItem.CreatedDate = apiRequest.CreatedDate;
            requestInteractionItem.ModifiedBy = apiRequest.ModifiedBy;
            requestInteractionItem.ModifiedDate = DateTime.Now;
            requestInteractionItem.IsActive = apiRequest.IsActive;
            requestInteractionItem.InteractionAction = apiRequest.InteractionAction;
            requestInteractionItem.InteractionReviewStatusId = apiRequest.InteractionReviewStatusId;
            requestInteractionItem.ObjectDataFormatId = apiRequest.ObjectDataFormatId;
            requestInteractionItem.LastAccessedDate = apiRequest.LastAccessedDate;
            return requestInteractionItem;
        }
    }
}
