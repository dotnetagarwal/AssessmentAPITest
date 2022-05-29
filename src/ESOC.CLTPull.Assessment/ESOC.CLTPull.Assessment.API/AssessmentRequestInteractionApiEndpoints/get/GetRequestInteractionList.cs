using Ardalis.ApiEndpoints;
using AutoMapper;
using ESOC.CLTPull.Assessment.API.AssessmentRequestApiEndpoints.get;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints.get
{
    public class GetRequestInteractionList : BaseAsyncEndpoint
         .WithoutRequest
         .WithResponse<GetRequestInteractionListApiResponse>
    {
        private readonly IRequestInteractionRepository _requestInteractionRepository;
        private readonly IMapper _mapper;
        public GetRequestInteractionList(IRequestInteractionRepository requestInteractionRepository, IMapper mapper)
        {
            _requestInteractionRepository = requestInteractionRepository;
            _mapper = mapper;
        }

        [HttpGet("api/assessment-requestinteractionlist-all")]
        [SwaggerOperation(
            Summary = "GetRequestInteractionList All Assessment RequestInteraction",
            Description = "GetRequestInteractionList All Assessment RequestInteraction",
            OperationId = "assessments.GetRequestInteractionList",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]

        public override async Task<ActionResult<GetRequestInteractionListApiResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<RequestInteractionListDataDTO> requestInteractionList =  _requestInteractionRepository.GetRequestInteractionListData();
            if (requestInteractionList is null) return NotFound();
            GetRequestInteractionListApiResponse response = new GetRequestInteractionListApiResponse();
            response.RequestInteractionViewList = (ICollection<RequestInteractionListDataDTO>)requestInteractionList;
            return Ok(response);
        }
    }
}