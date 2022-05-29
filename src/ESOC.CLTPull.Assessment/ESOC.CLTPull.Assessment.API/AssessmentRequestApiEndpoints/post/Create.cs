using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Ardalis.ApiEndpoints;
//using ESOC.CLTPull.Assessment.Core.EFEntities;
using ESOC.CLTPull.Assessment.Core.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using AutoMapper;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{

    // [Authorize(Roles = Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Create : BaseAsyncEndpoint
           .WithRequest<CreateAssessmentRequestApiRequest>
           .WithResponse<CreateAssessmentRequestApiResponse>
    {
        private readonly IAsyncRepository<Request> _requestItemRepository;
        private readonly IMapper _mapper;

        public Create(IAsyncRepository<Request> requestItemRepository, IMapper mapper)
        {
            _requestItemRepository = requestItemRepository;
            _mapper = mapper;
        }

        [HttpPost("api/assessment-requests")]
        [SwaggerOperation(
            Summary = "Creates a new Assessment Item",
            Description = "Creates a new Assessment Item",
            OperationId = "assessment-requests.create",
            Tags = new[] { "AssessmentRequestWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<CreateAssessmentRequestApiResponse>> HandleAsync(CreateAssessmentRequestApiRequest apiRequest,
            CancellationToken cancellationToken)
        {
            var response = new CreateAssessmentRequestApiResponse(apiRequest.CorrelationId());
            var newItem = _mapper.Map<Request>(apiRequest);

            newItem = await _requestItemRepository.AddAsync(newItem); //TODO Needs to move the same in Services under core

            response = _mapper.Map<CreateAssessmentRequestApiResponse>(newItem);
            return Ok(response);
        }

    }
    }
