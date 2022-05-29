using ESOC.CLTPull.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    public class DisableAssessmentRequestInteractionApiRequest : BaseRequest 
    {
           public int RequestInteractionId { get; set; }
    }
}
