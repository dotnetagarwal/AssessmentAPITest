using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    public class PublishApiResponse : BaseResponse
    {
        public PublishApiResponse(Guid correlationId) : base(correlationId)
        {
        }

        public PublishApiResponse()
        {
        }
        public ApiResponse<string> ApiResponse { get; set; }
    }
}
