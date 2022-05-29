using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestApiEndpoints.get
{
    public class GetRequestListAssessmentRequestApiResponse : BaseResponse
    {
        public GetRequestListAssessmentRequestApiResponse(Guid correlationId) : base(correlationId)
        {

        }

        public GetRequestListAssessmentRequestApiResponse()
        {
        }
        public ICollection<RequestListDataDTO> RequestViewList { get; set; }
    }
}
