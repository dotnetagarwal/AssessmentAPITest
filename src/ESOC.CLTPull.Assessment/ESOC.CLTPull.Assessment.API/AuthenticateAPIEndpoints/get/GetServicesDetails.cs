using Ardalis.ApiEndpoints;
using AutoMapper;
using ESOC.CLTPull.Core.Contracts;
using ESOC.CLTPull.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints.get
{
    public class GetServicesDetails : BaseAsyncEndpoint
        .WithRequest<GetServicesDetailsApiRequest>
        .WithResponse<GetServicesDetailsApiResponse>
    {
        protected readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public GetServicesDetails(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        [HttpGet("api/services/{searchText}")]
        [SwaggerOperation(
            Summary = "Get display service names",
            Description = "Gets services based on search text",
            OperationId = "users.GetServices",
            Tags = new[] { "ServicesWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<GetServicesDetailsApiResponse>> HandleAsync([FromRoute] GetServicesDetailsApiRequest request, CancellationToken cancellationToken = default)
        {
            GetServicesDetailsApiResponse response = new GetServicesDetailsApiResponse();
            response.ServicesDetail = await _requestRepository.GetServicesByTerm(request.SearchText);
            
            if (response.ServicesDetail is null) 
                return NotFound();

            return Ok(response.ServicesDetail);
        }
    }
}
