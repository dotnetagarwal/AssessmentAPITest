using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints.get
{
    public class GetInteractionsByRequestIdRequest : BaseRequest
    {
        public int RequestId { get; set; }
    }
}
