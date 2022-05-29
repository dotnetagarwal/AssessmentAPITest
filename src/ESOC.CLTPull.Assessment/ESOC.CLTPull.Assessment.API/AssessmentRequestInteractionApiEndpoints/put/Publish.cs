using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints;
using ESOC.CLTPull.Core.Contracts;
using System;
using System.Linq;
using ESOC.CLTPull.Assessment.API;
using ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints;

namespace CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints
{
    public class Publish : BaseAsyncEndpoint
           .WithRequest<PublishApiRequest>
           .WithResponse<PublishApiResponse>
    {
        private readonly IRequestInteractionRepository _itemRepository;
        private readonly IAsyncRepository<RequestInteraction> _genericItemRepository;

        public Publish(IRequestInteractionRepository itemRepository, IAsyncRepository<RequestInteraction> genericItemRepository)
        {
            _itemRepository = itemRepository;
            _genericItemRepository = genericItemRepository;
        }

        [HttpPut("api/assessment-requests-interaction-publish")]
        [SwaggerOperation(
            Summary = "Publish Assessments Interactions",
            Description = "Publish Assessments Interactions with Request",
            OperationId = "assessment-requests-interaction.publish",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<PublishApiResponse>> HandleAsync(PublishApiRequest apiRequest, CancellationToken cancellationToken)
        {
            //needs to get records on the basis of RequestInteractionIds.
            //We only need to update Publish Status and LastAccessedDate.
            ApiResponse<string> apiResponse = new ApiResponse<string>();
            apiResponse.IsSuccess = true;
            var requestInteractions = await _itemRepository.GetRequestInteractionList(apiRequest.RequestInteractionIds);            
            foreach (var requestInteraction in requestInteractions)
            {
                if (requestInteraction.InteractionReviewStatusId != null && requestInteraction.InteractionReviewStatusId != (int)InteractionReviewStatusEnum.Published)
                {
                    var requestInteractionForComparison = await _itemRepository.GetRequestInteractionForComparison(requestInteraction);
                    bool IsDuplicatePresent = requestInteractionForComparison.Count()>0 ?true:false;
                    if (!IsDuplicatePresent)
                    {
                        requestInteraction.InteractionReviewStatusId = (int)InteractionReviewStatusEnum.Published;
                        requestInteraction.LastAccessedDate = DateTime.Now;
                        requestInteraction.ModifiedDate = DateTime.Now;
                        await _genericItemRepository.UpdateAsync(requestInteraction);
                    }
                    else
                    {
                        apiResponse.IsSuccess = false;
                        apiResponse.ErrorMessage += String.Format("The mandatory attributes of the interaction {0} are matching with another existing Interaction {1}.<br/>", requestInteraction.RequestInteractionId, String.Join(',',requestInteractionForComparison));
                    }
                }              
            }
            apiResponse.ErrorMessage += "Please check and update.";
           return Ok(apiResponse);
        }
    }
}
