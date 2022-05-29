using Ardalis.ApiEndpoints;
using AutoMapper;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESOC.CLTPull.Assessment.Core.Specifications;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestApiEndpoints
{
    public class GetAllActiveRequests : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<GetAllActiveRequestsApiResponse>
    {
        private readonly IAsyncRepository<Request> _itemRepository;
        private readonly IMapper _mapper;
        public GetAllActiveRequests(IAsyncRepository<Request> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        [HttpGet("api/assessment-isactive-request")]
        [SwaggerOperation(
            Summary = "Get All Active Requests",
            Description = "Get All Active Request",
            OperationId = "assessments.GetAllActiveRequests",
            Tags = new[] { "AssessmentRequestWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<GetAllActiveRequestsApiResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var filterSpec = new AssessmentRequestSpecification(true);
            var requestList = await _itemRepository.ListAsync(filterSpec);
            if (requestList is null) return NotFound();
            GetAllActiveRequestsApiResponse response = new GetAllActiveRequestsApiResponse
            {
                RequestList = (ICollection<Request>)requestList
            };
            return Ok(response);
        }
    }
}
