using ESOC.CLTPull.Assessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.IntegrationTests
{
    public class RequestTestData
    {
        public static Request GetTestRequestObject()
        {
            // Arrange - New Request 
            return new Request()
            {
                RequestTitle = "TestReq",
                RequestDescription = "TestReq",
                InitialRequestDate = DateTime.UtcNow,
                CustomerName = "TestReq",
                CustomerInfo = "TestReq",
                IsStartDateConfirmed = true,
                TargetStartDate = DateTime.UtcNow,
                ActualStartDate = DateTime.UtcNow,
                TargetFinishDate = DateTime.UtcNow,
                NumberOfInteractionsAssessed = 7,
                ActualFinishDate = DateTime.UtcNow,
                ProgramName = "Test_Program",
                ProgramManager = "Test_Manager",
                EsocAnalyst = "Test_Analyst",
                AssessmentTc = "Test_AssissmentTC",
                RequestServiceSlo = "Test_ServiceSLO",
                AssessmentTargetFinishDate = DateTime.UtcNow,
                AssessmentActualFinishDate = DateTime.UtcNow
            };
        }
    }
}
