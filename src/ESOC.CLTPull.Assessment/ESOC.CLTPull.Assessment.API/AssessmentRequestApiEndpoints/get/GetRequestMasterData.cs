using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;
using ESOC.CLTPull.Core.Contracts;
using AutoMapper;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class GetRequestMasterData : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<GetRequestMasterDataApiResponse>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        public GetRequestMasterData(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        [HttpGet("api/assessment-masterdata")]
        [SwaggerOperation(
            Summary = "Get Assessment Master Data",
            Description = "Get Assessment Request Master Data",
            OperationId = "assessments.GetRequestMasterData",
            Tags = new[] { "AssessmentRequestWorkItemEndpoints" })
        ]
       
        public override async Task<ActionResult<GetRequestMasterDataApiResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {

            var item = await _requestRepository.GetRequestMasterData();
            if (item is null) return NotFound();

            var response = _mapper.Map<GetRequestMasterDataApiResponse>(item);

            return Ok(response);
        }
    }
}
