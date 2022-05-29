using ESOC.CLTPull.WebApi;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class GetByIdAssessmentRequestApiRequest : BaseRequest 
    {
        public int RequestId { get; set; }
    }
}
