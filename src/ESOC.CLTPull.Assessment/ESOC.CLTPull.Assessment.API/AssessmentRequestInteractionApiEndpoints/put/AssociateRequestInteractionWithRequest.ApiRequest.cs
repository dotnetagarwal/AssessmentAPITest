using CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    public class AssociateRequestInteractionWithRequestApiRequest : BaseRequest
    {
        public int RequestId { get; set; }
        public IEnumerable<int> RequestInteractionIds { get; set; }

    }
}
