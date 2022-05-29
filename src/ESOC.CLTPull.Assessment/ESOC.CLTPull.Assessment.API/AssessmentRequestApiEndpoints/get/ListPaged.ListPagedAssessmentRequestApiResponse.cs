using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class ListPagedAssessmentRequestApiResponse : BaseResponse
    {
        public ListPagedAssessmentRequestApiResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListPagedAssessmentRequestApiResponse()
        {
        }

        public List<AssessementRequestDto> AssessmentRequestItems { get; set; } = new List<AssessementRequestDto>();
        public int PageCount { get; set; }
    }
}
