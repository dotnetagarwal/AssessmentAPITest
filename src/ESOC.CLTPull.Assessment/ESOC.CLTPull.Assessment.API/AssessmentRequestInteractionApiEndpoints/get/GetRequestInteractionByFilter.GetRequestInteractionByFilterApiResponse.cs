using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;

namespace CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints
{
    public class GetRequestInteractionByFilterApiResponse : BaseResponse
    {
        public GetRequestInteractionByFilterApiResponse()
        {

        }
        public GetRequestInteractionByFilterApiResponse(Guid correlationId) : base(correlationId)
        {
        }
        public ICollection<RequestInteraction> RequestInteractionList { get; set; }
    }
}