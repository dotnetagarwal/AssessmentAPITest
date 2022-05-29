using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    public class UpdateAssessmentRequestInteractionApiResponse : BaseResponse
    {
        public UpdateAssessmentRequestInteractionApiResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UpdateAssessmentRequestInteractionApiResponse()
        {
        }

        public ESOC.CLTPull.Assessment.Core.Entities.RequestInteraction RequestInteraction { get; set; }
    }



}
