using Ardalis.Specification;
using AutoMapper;
using CLTPull.Assessment.Api.AssessmentWorkItemEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using ESOC.CLTPull.Assessment.Core.Specifications;
using CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints;

namespace ESOC.CLTPull.Assessment.UnitTests.ApiTests.AssessmentRequestTests
{
    public class AssessmentRequestInteractionApiTest
    {

        private readonly Mock<IAsyncRepository<RequestInteraction>> _mockAssessmentRequestInteractionRepo;
        private readonly Mock<IMapper> _mockMapper;

        public AssessmentRequestInteractionApiTest()
        {
            _mockAssessmentRequestInteractionRepo = new Mock<IAsyncRepository<RequestInteraction>>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Get_assessment_request_interaction_filter_success()
        {
            //Arrange

            var requestInteractionByFilterApiRequest = new GetRequestInteractionByFilterApiRequest() { AssessmentRequestInteractionKey = "InteractionDescription", AssessmentRequestInteractionValue = "Test Status Desc 1" };

            IReadOnlyList<RequestInteraction> requestInteractions = new List<RequestInteraction>
                                                                       {
                                                                          new RequestInteraction
                                                                          {
                                                                              RequestInteractionId = 1,
                                                                              InteractionStatusId = 1,
                                                                              InteractionDescription = "Test Status Desc 1"
                                                                          },
                                                                          new RequestInteraction
                                                                          {
                                                                              RequestInteractionId = 2,
                                                                              InteractionStatusId = 1,
                                                                              InteractionDescription = "Test Status Desc 2"
                                                                          }
                                                                        };

            CancellationToken cancellationToken = new CancellationToken(false);

            _mockAssessmentRequestInteractionRepo.Setup(x => x.ListAsync(It.IsAny<AssessmentRequestInteractionSpecification>()))
                .Returns(Task.FromResult(requestInteractions));

            var fakeresponse = new GetRequestInteractionByFilterApiResponse(requestInteractionByFilterApiRequest.CorrelationId());
            //Act
            var getByIdApi = new GetRequestInteractionByFilter(_mockAssessmentRequestInteractionRepo.Object, _mockMapper.Object);

            var actionResult = await getByIdApi.HandleAsync(requestInteractionByFilterApiRequest, cancellationToken);

            //Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as GetRequestInteractionByFilterApiResponse).RequestInteractionList.Count, requestInteractions.Count);
        }

        [Fact]
        public async Task Delete_assessment_request_interaction_success()
        {
            //Arrange

            var fakeAssessmentRequestIntearctionApiRequest = new DisableAssessmentRequestInteractionApiRequest() { RequestInteractionId = 8 };
            var fakeAssessmentRequestIntearction = new RequestInteraction()
            {
                RequestId = 1,
                InteractionDescription = "Test_Interaction_Description_First",
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            CancellationToken cancellationToken = new CancellationToken(false);

            _mockAssessmentRequestInteractionRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
              .Returns(Task.FromResult(fakeAssessmentRequestIntearction));

            //Act
            var deleteAssessmentRequestApiRequest = new CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints.Disable(_mockAssessmentRequestInteractionRepo.Object);

            var actionResult = await deleteAssessmentRequestApiRequest.HandleAsync(fakeAssessmentRequestIntearctionApiRequest, cancellationToken);

            Assert.Equal((actionResult as StatusCodeResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }


    }
}
