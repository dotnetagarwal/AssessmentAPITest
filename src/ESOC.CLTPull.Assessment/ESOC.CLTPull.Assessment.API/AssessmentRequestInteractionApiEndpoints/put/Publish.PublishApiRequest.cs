using ESOC.CLTPull.WebApi;
using System;

namespace CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    public class PublishApiRequest:BaseRequest
    {
        public int[] RequestInteractionIds { get; set; }
    }
}
