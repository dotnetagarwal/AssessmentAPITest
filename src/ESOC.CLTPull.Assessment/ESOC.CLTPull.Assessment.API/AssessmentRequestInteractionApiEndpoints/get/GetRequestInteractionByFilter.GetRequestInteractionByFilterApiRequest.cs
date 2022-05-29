using ESOC.CLTPull.WebApi;

namespace CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints
{
    public class GetRequestInteractionByFilterApiRequest : BaseRequest
    {
        public string AssessmentRequestInteractionKey { get; set; }
        public string AssessmentRequestInteractionValue { get; set; }
    }
}