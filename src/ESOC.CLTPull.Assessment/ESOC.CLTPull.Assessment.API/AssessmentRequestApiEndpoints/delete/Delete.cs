using Ardalis.ApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Threading;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    //[Authorize(Roles = Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteAssessmentRequestApiRequest>
        .WithResponse<DeleteAssessmentRequestApiResponse>
      
    {
        private readonly IAsyncRepository<Request> _assessmentRepository;

        public Delete(IAsyncRepository<Request> assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
        }

        [HttpDelete("api/assessments/{assessmentid}")]
        [SwaggerOperation(
            Summary = "Deletes an assessment",
            Description = "Deletes an assessment",
            OperationId = "assessments.Delete",
            Tags = new[] { "AssessmentRequestWorkItemEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAssessmentRequestApiResponse>> HandleAsync([FromRoute] DeleteAssessmentRequestApiRequest request, 
            CancellationToken cancellationToken)
        {
            var response = new DeleteAssessmentRequestApiResponse(request.CorrelationId());

            var requestToDelete = await _assessmentRepository.GetByIdAsync(request.AssessmentId);
            if (requestToDelete is null) return NotFound();

            await _assessmentRepository.DeleteAsync(requestToDelete);

            return Ok(response);
        }
    }
}
