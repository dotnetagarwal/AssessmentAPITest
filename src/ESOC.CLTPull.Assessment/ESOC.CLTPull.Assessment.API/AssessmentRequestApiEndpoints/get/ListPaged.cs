using Ardalis.ApiEndpoints;
using AutoMapper;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class ListPaged : BaseAsyncEndpoint.WithRequest<ListPagedAssessmentRequestApiRequest>
        .WithResponse<ListPagedAssessmentRequestApiResponse>
    {
        private readonly IAsyncRepository<Request> _itemRepository;
        private readonly IMapper _mapper;

        public ListPaged(IAsyncRepository<Request> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet("api/assessment-requests")]
        [SwaggerOperation(
            Summary = "List Assessment Requests (paged)",
            Description = "List Assessement Requests (paged)",
            OperationId = "assessment-requests.ListPaged",
            Tags = new[] { "AssessmentRequestWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<ListPagedAssessmentRequestApiResponse>> HandleAsync([FromQuery] ListPagedAssessmentRequestApiRequest request, 
            CancellationToken cancellationToken)
        {
            var response = new ListPagedAssessmentRequestApiResponse(request.CorrelationId());

            var filterSpec = new AssessmentRequestSpecification(request.AssessmentId.Value);
            int totalItems = await _itemRepository.CountAsync(filterSpec);

            var pagedSpec = new AssessmentRequestSpecification(request.AssessmentId.Value);

            var items = await _itemRepository.ListAsync(pagedSpec);
            response.AssessmentRequestItems.AddRange(items.Select(_mapper.Map<AssessementRequestDto>));
            response.PageCount = int.Parse(Math.Ceiling((decimal)totalItems / request.PageSize).ToString());
            return Ok(response);
        }
    }
}
