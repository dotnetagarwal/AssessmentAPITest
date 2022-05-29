using Ardalis.ApiEndpoints;
using AutoMapper;
using ESOC.CLTPull.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    public class GetRequestInteractionMasterData : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<GetRequestInteractionMasterDataApiResponse>
    {
        private readonly IRequestInteractionRepository _requestRepository;
        private readonly IMapper _mapper;
        public GetRequestInteractionMasterData(IRequestInteractionRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        [HttpGet("api/request-interaction-masterdata")]
        [SwaggerOperation(
            Summary = "Get Assessment Request Interaction Master Data",
            Description = "Get Assessment Request Interaction Master Data",
            OperationId = "assessments.GetRequestInteractionMasterData",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<GetRequestInteractionMasterDataApiResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {

            var item = await _requestRepository.GetRequestInteractionMasterData();
            if (item is null) return NotFound();

            var response = _mapper.Map<GetRequestInteractionMasterDataApiResponse>(item);

            return Ok(response);
        }
    }
}
