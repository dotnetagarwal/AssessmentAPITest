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
using System;
using ESOC.CLTPull.Assessment.Core.Specifications;

namespace CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints
{
    public class GetRequestInteractionByFilter : BaseAsyncEndpoint
        .WithRequest<GetRequestInteractionByFilterApiRequest>
        .WithResponse<GetRequestInteractionByFilterApiResponse>
    {
        private readonly IAsyncRepository<RequestInteraction> _itemRepository;
        private readonly IMapper _mapper;

        public GetRequestInteractionByFilter(IAsyncRepository<RequestInteraction> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("api/assessmentinteraction/{assessmentRequestInteractionKey}/{assessmentRequestInteractionValue}")]
        [SwaggerOperation(
            Summary = "Get Assessment  Request Interaction based on the filter passed",
            Description = "Get Assessment  Request Interaction based on the filter passed",
            OperationId = "assessments.GetRequestInteractionByFilter",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]
       
        public override async Task<ActionResult<GetRequestInteractionByFilterApiResponse>> HandleAsync([FromRoute] GetRequestInteractionByFilterApiRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetRequestInteractionByFilterApiResponse(request.CorrelationId());
            var assessmentRequestInteractionSpec = new AssessmentRequestInteractionSpecification(request.AssessmentRequestInteractionKey,request.AssessmentRequestInteractionValue);

            var requestInteractionList = await _itemRepository.ListAsync(assessmentRequestInteractionSpec);

            response.RequestInteractionList = (ICollection<RequestInteraction>)requestInteractionList;
            return Ok(response);
        }
    }
}
