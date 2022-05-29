using Ardalis.ApiEndpoints;
using CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints;
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
    public class AssociateRequestInteractionWithRequest : BaseAsyncEndpoint.WithRequest<AssociateRequestInteractionWithRequestApiRequest>.WithoutResponse
    {
        private readonly IAsyncRepository<RequestInteraction> _itemRepository;

        public AssociateRequestInteractionWithRequest(IAsyncRepository<RequestInteraction> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPut("api/associate-interaction-with-request")]
        [SwaggerOperation(
            Summary = "Update RequestInteraction table with RequestId for every RequestInteraction",
            Description = "Update RequestInteraction table with RequestId for every RequestInteraction ",
            OperationId = "assessment-requests-associate-interaction-with-request",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync(AssociateRequestInteractionWithRequestApiRequest apiRequest, CancellationToken cancellationToken)
        {
            bool isUpdated = false;
            foreach (var requestInteractionId in apiRequest.RequestInteractionIds)
            {
                RequestInteraction existingItem = await _itemRepository.GetByIdAsync(requestInteractionId);
                existingItem.RequestId = apiRequest.RequestId;
                var recordCount= await _itemRepository.UpdateAsync(existingItem);
                isUpdated = recordCount > 0 ? true : false;
            }
            return Ok(isUpdated);
        }

    }
}
