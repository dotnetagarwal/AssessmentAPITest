using ESOC.CLTPull.Assessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.IntegrationTests
{
    public class RequestInteractionTestData
    {
        public static RequestInteraction GetRequestInteractionTestObject(int requestId, InteractionReviewStatusEnum interactionReviewStatus)
        {
            return new RequestInteraction()
            {
                RequestId = requestId,
                InteractionDescription = "Test_Interaction_Description_First_Disable",
                SourceServiceId = 1,
                NonServiceDataSourceName = Guid.NewGuid().ToString(),
                NonServiceDataDestinationName = "CHWY",
                DestinationServiceId = 1,
                DataContentType = "Test_Interaction_DataContentType_First_Disable",
                InteractionReviewStatusId = (int)interactionReviewStatus,
                
            };
        }
    }
}
