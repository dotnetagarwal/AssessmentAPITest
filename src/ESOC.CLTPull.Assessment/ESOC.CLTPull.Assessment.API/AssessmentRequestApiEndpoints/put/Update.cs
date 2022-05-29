using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    //  [Authorize(Roles = Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Update : BaseAsyncEndpoint.WithRequest<UpdateAssessmentRequestApiRequest>
        .WithResponse<UpdateAssessmentRequestApiResponse>
    {
        private readonly IAsyncRepository<Request> _itemRepository;

        public Update(IAsyncRepository<Request> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPut("api/assessments-requests")]
        [SwaggerOperation(
            Summary = "Updates an assessment request",
            Description = "Updates an assessment request",
            OperationId = "assessments-requests.update",
            Tags = new[] { "AssessmentRequestWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAssessmentRequestApiResponse>> HandleAsync(UpdateAssessmentRequestApiRequest apiRequest, CancellationToken cancellationToken)
        {
            var response = new UpdateAssessmentRequestApiResponse(apiRequest.CorrelationId());

            Request existingItem = await _itemRepository.GetByIdAsync(apiRequest.RequestId);
            existingItem.RequestDescription = apiRequest.RequestDescription;
            existingItem.RequestTitle = apiRequest.RequestTitle;
            existingItem.ActualFinishDate = apiRequest.ActualFinishDate;
            existingItem.ActualStartDate = apiRequest.ActualStartDate;
            existingItem.AssessmentScopeId = apiRequest.AssessmentScopeId;
            existingItem.AssessmentStatusId = apiRequest.AssessmentStatusId;
            existingItem.CancelDate = apiRequest.CancelDate;
            existingItem.CustomerInfo = apiRequest.CustomerInfo;
            existingItem.CustomerName = apiRequest.CustomerName;
            existingItem.FundingSource = apiRequest.FundingSource;
            existingItem.InitialRequestDate = apiRequest.InitialRequestDate;
            existingItem.IsStartDateConfirmed = apiRequest.IsStartDateConfirmed;
            existingItem.LineOfBusinessId = apiRequest.LineOfBusinessId;
            existingItem.Notes = apiRequest.Notes;
            existingItem.NumberOfInteractionsAssessed = apiRequest.NumberOfInteractionsAssessed;
            existingItem.PrjidorServiceNowTicket = apiRequest.PrjidorServiceNowTicket;
            existingItem.Prjname = apiRequest.Prjname;
            //existingItem.ProgramId = apiRequest.ProgramId;

            existingItem.ProgramName = apiRequest.ProgramName;
            existingItem.ProgramManager = apiRequest.ProgramManager;
            existingItem.RequestServiceSlo = apiRequest.RequestServiceSlo;
            existingItem.EsocAnalyst = apiRequest.EsocAnalyst;
            existingItem.AssessmentTc = apiRequest.AssessmentTc;

            existingItem.RequestChannelId = apiRequest.RequestChannelId;
            existingItem.RequestDocumentation = apiRequest.RequestDocumentation;
            existingItem.RequestLead = apiRequest.RequestLead;
            existingItem.RequestServiceId = apiRequest.RequestServiceId;
            existingItem.RequestStateId = apiRequest.RequestStateId;
            existingItem.RequestTypeId = apiRequest.RequestTypeId;
            existingItem.TargetFinishDate = apiRequest.TargetFinishDate;
            existingItem.TargetStartDate = apiRequest.TargetStartDate;
            existingItem.ModifiedBy = apiRequest.ModifiedBy;
            existingItem.ModifiedDate = DateTime.Now;
            existingItem.AssessmentActualFinishDate = apiRequest.AssessmentActualFinishDate;
            existingItem.AssessmentTargetFinishDate = apiRequest.AssessmentTargetFinishDate;

            int noOfRowsUpdated = await _itemRepository.UpdateAsync(existingItem); //TODO Needs to move the same in Services under core
            if (noOfRowsUpdated > 0)
                response.Request = existingItem;
            return Ok(response);
        }
    }
}
