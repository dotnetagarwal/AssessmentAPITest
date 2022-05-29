using ESOC.CLTPull.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    public class DeleteAssessmentRequestInteractionApiRequest : BaseRequest 
    {
           public int RequestInteractionId { get; set; }
    }
}
