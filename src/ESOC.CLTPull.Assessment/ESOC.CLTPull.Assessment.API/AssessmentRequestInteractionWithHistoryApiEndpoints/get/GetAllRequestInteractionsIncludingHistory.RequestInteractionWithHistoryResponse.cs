using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionWithHistoryApiEndpoints
{
    public class RequestInteractionWithHistoryResponse : BaseResponse
    {
        public RequestInteractionWithHistoryResponse(Guid correlationId) : base(correlationId)
        {

        }
        public RequestInteractionWithHistoryResponse()
        {
        }
        public ICollection<RequestInteractionListDataDTO> RequestInteractionWithHistoryViewList { get; set; }
    }
}
