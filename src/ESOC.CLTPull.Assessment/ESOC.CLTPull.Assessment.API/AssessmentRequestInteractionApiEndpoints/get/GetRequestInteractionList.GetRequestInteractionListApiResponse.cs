using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints.get
{
    public class GetRequestInteractionListApiResponse : BaseResponse
    {
        public GetRequestInteractionListApiResponse(Guid correlationId) : base(correlationId)
        {

        }

        public GetRequestInteractionListApiResponse()
        {
        }
        public ICollection<RequestInteractionListDataDTO> RequestInteractionViewList { get; set; }
    }
}