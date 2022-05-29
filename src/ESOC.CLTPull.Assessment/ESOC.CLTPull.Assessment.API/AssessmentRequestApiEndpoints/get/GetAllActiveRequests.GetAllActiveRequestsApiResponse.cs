using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestApiEndpoints
{
    public class GetAllActiveRequestsApiResponse : BaseResponse
    {
        public GetAllActiveRequestsApiResponse(Guid correlationId) : base(correlationId)
        {

        }

        public GetAllActiveRequestsApiResponse()
        {
        }

        public ICollection<Request> RequestList { get; set; }
    }
}
