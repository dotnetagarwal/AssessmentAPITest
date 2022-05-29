using Ardalis.ApiEndpoints;
using AutoMapper;
using ESOC.CLTPull.Assessment.API.AssessmentRequestApiEndpoints.get;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class GetRequestList : BaseAsyncEndpoint
         .WithoutRequest
         .WithResponse<GetRequestListAssessmentRequestApiResponse>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        public GetRequestList(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        [HttpGet("api/assessment-requestlist-all")]
        [SwaggerOperation(
            Summary = "GetRequestList All Assessment Request",
            Description = "GetRequestList All Assessment Request",
            OperationId = "assessments.GetRequestList",
            Tags = new[] { "AssessmentRequestWorkItemEndpoints" })
        ]

        public override async Task<ActionResult<GetRequestListAssessmentRequestApiResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<RequestListDataDTO> requestList = _requestRepository.GetRequestListData();
            if (requestList is null) return NotFound();            
            GetRequestListAssessmentRequestApiResponse response = new GetRequestListAssessmentRequestApiResponse();
            response.RequestViewList = (ICollection<RequestListDataDTO>)requestList;
            return Ok(response);
        }
    }
}
