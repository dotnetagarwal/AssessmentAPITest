using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using AutoMapper;

namespace CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints
{   
    public class Create : BaseAsyncEndpoint
           .WithRequest<CreateAssessmentRequestInteractionApiRequest>
           .WithResponse<CreateAssessmentRequestInteractionApiResponse>
    {
        private readonly IAsyncRepository<RequestInteraction> _requestItemRepository;
        private readonly IMapper _mapper;

        public Create(IAsyncRepository<RequestInteraction> requestItemRepository, IMapper mapper)
        {
            _requestItemRepository = requestItemRepository;
            _mapper = mapper;
        }

        [HttpPost("api/assessment-requests-interaction")]
        [SwaggerOperation(
            Summary = "Creates a new Assessment Request Item",
            Description = "Creates a new Assessment Request Item",
            OperationId = "assessment-requests-interaction.create",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<CreateAssessmentRequestInteractionApiResponse>> HandleAsync(CreateAssessmentRequestInteractionApiRequest apiRequest,
            CancellationToken cancellationToken)
        {
            var response = new CreateAssessmentRequestInteractionApiResponse(apiRequest.CorrelationId());
            var newItem = _mapper.Map<RequestInteraction>(apiRequest);

            newItem = await _requestItemRepository.AddAsync(newItem); 

            response = _mapper.Map<CreateAssessmentRequestInteractionApiResponse>(newItem);
            return Ok(response);
        }

    }
}
