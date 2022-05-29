using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionHistoryApiEndpoints
{
    public class GetRequestInteractionHistoryListResponse : BaseResponse
    {
        public GetRequestInteractionHistoryListResponse(Guid correlationId) : base(correlationId)
        {

        }
        public GetRequestInteractionHistoryListResponse()
        {
        }
        public ICollection<RequestInteractionHistoryListDataDTO> RequestInteractionHistoryViewList { get; set; }
    }
}
