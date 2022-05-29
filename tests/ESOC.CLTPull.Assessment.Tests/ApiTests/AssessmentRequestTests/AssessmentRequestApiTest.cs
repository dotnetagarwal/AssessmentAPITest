using CLTPull.Assessment.Api.AssessmentWorkItemEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ESOC.CLTPull.Assessment.UnitTests.ApiTests.AssessmentRequestTests
{
    public class AssessmentRequestApiTest
    {

        private readonly Mock<IAsyncRepository<Request>> _mockAssessmentRequestRepo;

        public AssessmentRequestApiTest()
        {
            _mockAssessmentRequestRepo = new Mock<IAsyncRepository<Request>>();

        }

        [Fact]
        public async Task Get_assessment_requests_success()
        {
            //Arrange

            var fakeAssessmentRequestApiRequest = new GetByIdAssessmentRequestApiRequest() { RequestId = 123 };

            var fakeAssessmentRequest = new Request
            {
                RequestId = 123,
                RequestTitle = "test title",
                RequestDescription = "test request desc",
                CustomerName = "test customer name",
                RequestLead = "test lead",
                InitialRequestDate = DateTime.Now,
                ActualStartDate = DateTime.Now.AddDays(1)
            };

            CancellationToken cancellationToken = new CancellationToken(false);

            _mockAssessmentRequestRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(fakeAssessmentRequest));

            var fakeresponse = new GetByIdAssessmentRequestApiResponse(fakeAssessmentRequestApiRequest.CorrelationId());
            //Act
            var getByIdApi = new GetById(_mockAssessmentRequestRepo.Object);

            var actionResult = await getByIdApi.HandleAsync(fakeAssessmentRequestApiRequest, cancellationToken);

            //Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as GetByIdAssessmentRequestApiResponse).AssessmentRequestObject.RequestId, fakeAssessmentRequestApiRequest.RequestId);
        }


    }
}
