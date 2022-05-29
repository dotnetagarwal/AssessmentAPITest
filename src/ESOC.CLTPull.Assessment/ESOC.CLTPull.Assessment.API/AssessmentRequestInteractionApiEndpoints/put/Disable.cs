using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    //[Authorize(Roles = Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Disable : BaseAsyncEndpoint
        .WithRequest<DisableAssessmentRequestInteractionApiRequest>
        .WithoutResponse

    {
        private readonly IAsyncRepository<RequestInteraction> _requestInteractionRepository;

        public Disable(IAsyncRepository<RequestInteraction> requestInteractionRepository)
        {
            _requestInteractionRepository = requestInteractionRepository;
        }

        [HttpPut("api/disable-requests-interaction/{requestInteractionId}")]
        [SwaggerOperation(
            Summary = "Disable an RequestInteraction",
            Description = "Disable an RequestInteraction",
            OperationId = "requestinteraction.Disable",
            Tags = new[] { "AssessmentRequestInteractionWorkItemEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromRoute] DisableAssessmentRequestInteractionApiRequest request,
            CancellationToken cancellationToken)
        {
            RequestInteraction requestInteractionToUpdate = await _requestInteractionRepository.GetByIdAsync(request.RequestInteractionId);
            if (requestInteractionToUpdate is null) return NotFound();
            requestInteractionToUpdate.IsActive = false;
            await _requestInteractionRepository.UpdateAsync(requestInteractionToUpdate);

            return Ok();
        }
    }
}
