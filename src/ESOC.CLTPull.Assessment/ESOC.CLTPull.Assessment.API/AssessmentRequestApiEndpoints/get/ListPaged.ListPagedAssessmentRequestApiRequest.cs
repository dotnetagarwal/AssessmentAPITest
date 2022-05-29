using ESOC.CLTPull.WebApi;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class ListPagedAssessmentRequestApiRequest : BaseRequest 
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int? AssessmentId { get; set; }
        public int? AssessmentTypeId { get; set; }
    }
}
