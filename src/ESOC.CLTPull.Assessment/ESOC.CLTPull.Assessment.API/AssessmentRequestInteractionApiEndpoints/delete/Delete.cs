using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;
using ESOC.CLTPull.Assessment.Core.Specifications;
using System.Collections.Generic;
using AutoMapper;
using System;

namespace CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    //[Authorize(Roles = Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteAssessmentRequestInteractionApiRequest>
        .WithoutResponse

    {
        private readonly IAsyncRepository<RequestInteraction> _itemRepository;
        private readonly IAsyncRepository<RequestInteractionHistory> _itemHistoryRepository;
        private readonly IMapper _mapper;
        public Delete(IAsyncRepository<RequestInteraction> itemRepository, IAsyncRepository<RequestInteractionHistory> itemHistoryRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _itemHistoryRepository = itemHistoryRepository;
            _mapper = mapper;
        }
      
        [HttpDelete("api/delete-requests-interaction/{requestInteractionId}")]
        [SwaggerOperation(
            Summary = "Delete an RequestInteraction",
            Description = "Delete an RequestInteraction",
            OperationId = "requestinteraction.Delete",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromRoute] DeleteAssessmentRequestInteractionApiRequest request,
            CancellationToken cancellationToken)
        {
            RequestInteraction existingItem = await _itemRepository.GetByIdAsync(request.RequestInteractionId);
            if (existingItem is null) return NotFound();

            //Now get latest record from RequestInteractionHistory table on the basis of LastAccessedTime
            //If we found history, Update that record into RequestInteraction table 
            //Else Delete that record from RequestInteraction table 

            // var response = new GetRequestInteractionByFilterApiResponse(request.CorrelationId());
            var assessmentRequestInteractionSpec = new AssessmentRequestInteractionHistorySpecification(request.RequestInteractionId);

            var requestInteractionHistoryItem = await _itemHistoryRepository.FirstOrDefaultAsync(assessmentRequestInteractionSpec);
            if (requestInteractionHistoryItem is null || requestInteractionHistoryItem?.LastAccessedDate is null)
                await _itemRepository.DeleteAsync(existingItem);
            else
            {
                existingItem.RequestId = requestInteractionHistoryItem.RequestId;
                existingItem.InteractionStatusId = requestInteractionHistoryItem.InteractionStatusId;
                existingItem.InteractionDescription = requestInteractionHistoryItem.InteractionDescription;
                existingItem.SourceServiceId = requestInteractionHistoryItem.SourceServiceId;
                existingItem.NonServiceDataSourceName = requestInteractionHistoryItem.NonServiceDataSourceName;
                existingItem.NonServiceDataDestinationName = requestInteractionHistoryItem.NonServiceDataDestinationName;
                existingItem.DestinationServiceId = requestInteractionHistoryItem.DestinationServiceId;
                existingItem.InteractionSpanId = requestInteractionHistoryItem.InteractionSpanId;
                existingItem.ObjectofInteractionId = requestInteractionHistoryItem.ObjectofInteractionId;
                existingItem.NotesOnObjectNaming = requestInteractionHistoryItem.NotesOnObjectNaming;
                existingItem.DataContentType = requestInteractionHistoryItem.DataContentType;
                existingItem.IsDataFileContainsHeaderTrailerFooterRecords = requestInteractionHistoryItem.IsDataFileContainsHeaderTrailerFooterRecords;
                existingItem.CompanionFileTypeId = requestInteractionHistoryItem.CompanionFileTypeId;
                existingItem.InteractionTriggerTypeId = requestInteractionHistoryItem.InteractionTriggerTypeId;
                existingItem.NotesOnTrigger = requestInteractionHistoryItem.NotesOnTrigger;
                existingItem.HelperAppOrTeamId = requestInteractionHistoryItem.HelperAppOrTeamId;
                existingItem.EcgconfigurationId = requestInteractionHistoryItem.EcgconfigurationId;
                existingItem.InteractionMechanismId = requestInteractionHistoryItem.InteractionMechanismId;
                existingItem.FrequencyIntervalId = requestInteractionHistoryItem.FrequencyIntervalId;
                existingItem.InstancesPerFrequencyIntervalId = requestInteractionHistoryItem.InstancesPerFrequencyIntervalId;
                existingItem.DailyIntervalDays = requestInteractionHistoryItem.DailyIntervalDays;
                existingItem.MonthlyIntervalMonths = requestInteractionHistoryItem.MonthlyIntervalMonths;
                existingItem.IsDataSentOnUsaholidays = requestInteractionHistoryItem.IsDataSentOnUsaholidays;
                existingItem.IsDataSentOnIndiaHolidays = requestInteractionHistoryItem.IsDataSentOnIndiaHolidays;
                existingItem.ExpectedTransmissionStartTimeCst = requestInteractionHistoryItem.ExpectedTransmissionStartTimeCst;
                existingItem.ExpectedMaximumTransmissionDurationInHours = requestInteractionHistoryItem.ExpectedMaximumTransmissionDurationInHours;
                existingItem.NotesOnFrequency = requestInteractionHistoryItem.NotesOnFrequency;
                existingItem.NotesOnSourceDataCreation = requestInteractionHistoryItem.NotesOnSourceDataCreation;
                existingItem.NotesOnDestinationDataArrivalAndValidation = requestInteractionHistoryItem.NotesOnDestinationDataArrivalAndValidation;
                existingItem.NotesOnDestinationDataLoadingAndFinalLocation = requestInteractionHistoryItem.NotesOnDestinationDataLoadingAndFinalLocation;
                existingItem.InteractionFailureModes = requestInteractionHistoryItem.InteractionFailureModes;
                existingItem.NotesOnReconciliationControls = requestInteractionHistoryItem.NotesOnReconciliationControls;
                existingItem.NotesOnTimeRelatedControls = requestInteractionHistoryItem.NotesOnTimeRelatedControls;
                existingItem.NotesOnThresholdControls = requestInteractionHistoryItem.NotesOnThresholdControls;
                existingItem.NotesOnOtherControls = requestInteractionHistoryItem.NotesOnOtherControls;
                existingItem.ReferralToOtherTeams = requestInteractionHistoryItem.ReferralToOtherTeams;
                existingItem.CreatedBy = requestInteractionHistoryItem.CreatedBy;
                existingItem.CreatedDate = requestInteractionHistoryItem.CreatedDate;
                existingItem.ModifiedBy = requestInteractionHistoryItem.ModifiedBy;
                existingItem.ModifiedDate = DateTime.Now;
                existingItem.IsActive = requestInteractionHistoryItem.IsActive;
                existingItem.InteractionAction = requestInteractionHistoryItem.InteractionAction;
                existingItem.InteractionReviewStatusId = requestInteractionHistoryItem.InteractionReviewStatusId;
                existingItem.ObjectDataFormatId = requestInteractionHistoryItem.ObjectDataFormatId;
                existingItem.LastAccessedDate = requestInteractionHistoryItem.LastAccessedDate;

                await _itemRepository.UpdateAsync(existingItem);

                await _itemHistoryRepository.DeleteAsync(requestInteractionHistoryItem); //Deleting extracted record from history
            }

            return Ok();
        }
    }
}
