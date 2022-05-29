using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetByIdAssessmentRequestApiRequest>
        .WithResponse<GetByIdAssessmentRequestApiResponse>
    {
        private readonly IAsyncRepository<Request> _itemRepository;
        public GetById(IAsyncRepository<Request> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("api/assessments/{assessmentId}")]
        [SwaggerOperation(
            Summary = "Get an Assessment by Id",
            Description = "Gets an Assessment by Id",
            OperationId = "assessments.GetById",
            Tags = new[] { "AssessmentRequestWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAssessmentRequestApiResponse>> HandleAsync([FromRoute] GetByIdAssessmentRequestApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAssessmentRequestApiResponse(request.CorrelationId());

            var item = await _itemRepository.GetByIdAsync(request.RequestId);
            if (item is null) return NotFound();

            response.AssessmentRequestObject = new AssessementRequestDto
            {
                RequestId = item.RequestId,
              
            };
            return Ok(response);
        }
    }
}
