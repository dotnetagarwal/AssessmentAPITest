using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public enum InteractionReviewStatusEnum
    {
        NotStarted = 1,
        InProgress = 2,
        InternalReviewInProgress = 3,
        ReviewWithCustomerInProgress = 4,
        Published = 5,
        Cancelled = 6,
        ReassessmentInProgress = 7
    }
}
