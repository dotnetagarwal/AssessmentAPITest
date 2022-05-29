using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;
using ESOC.CLTPull.Core.Contracts;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    [Authorize]
    public class GetAll : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<GetAllAssessmentRequestApiResponse>
    {
        private readonly IAsyncRepository<Request> _itemRepository;
        private readonly IMapper _mapper;
        public GetAll(IAsyncRepository<Request> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet("api/assessment-request-all")]
        [SwaggerOperation(
            Summary = "Get All Assessment Request",
            Description = "Get All Assessment Request",
            OperationId = "assessments.GetAll",
            Tags = new[] { "AssessmentRequestWorkItemEndpoints" })
        ]

        public override async Task<ActionResult<GetAllAssessmentRequestApiResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Request> requestList = await _itemRepository.ListAllAsync();
            if (requestList is null) return NotFound();

            GetAllAssessmentRequestApiResponse response = new GetAllAssessmentRequestApiResponse();
            response.RequestList = (ICollection<Request>)requestList;
            return Ok(response);
        }
    }
}
