using ESOC.CLTPull.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace CLTPull.Assessment.Api.AssessmentWorkItemEndpoints
{
    public class DeleteAssessmentRequestApiRequest : BaseRequest 
    {
           public int AssessmentId { get; set; }
    }
}
