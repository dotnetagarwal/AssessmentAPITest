using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints.get
{
    public class GetInteractionsByRequestId : BaseAsyncEndpoint
        .WithRequest<GetInteractionsByRequestIdRequest>
        .WithResponse<GetInteractionsByRequestIdResponse>
    {
        private readonly IRequestInteractionRepository _itemRepository;
        public GetInteractionsByRequestId(IRequestInteractionRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("api/interactions/{requestId}")]
        [SwaggerOperation(
            Summary = "Get all interactions by RequestId",
            Description = "Get all interactions by RequestId",
            OperationId = "assessments.GetInteractionsByRequestId",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<GetInteractionsByRequestIdResponse>> HandleAsync([FromRoute] GetInteractionsByRequestIdRequest request,
            CancellationToken cancellationToken)
        {
            IReadOnlyList<RequestInteractionListDataDTO> requestInteractionList = _itemRepository.GetRequestInteractionListData();
            if (requestInteractionList is null) return NotFound();
            GetInteractionsByRequestIdResponse response = new GetInteractionsByRequestIdResponse
            {
                RequestInteractionList = (ICollection<RequestInteractionListDataDTO>)(requestInteractionList.Where(b => b.RequestId == request.RequestId).OrderByDescending(b => b.RequestInteractionId).ToList())
            };
            return Ok(response);
        }
    }
}
