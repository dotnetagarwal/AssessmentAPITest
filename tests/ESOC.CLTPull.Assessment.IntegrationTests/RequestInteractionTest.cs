using CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints;
using ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using ESOC.CLTPull.Assessment.IntegrationTests.MasterData;
using ESOC.CLTPull.Infrastructure.Data;
using ESOC.CLTPull.WebApi;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace ESOC.CLTPull.Assessment.IntegrationTests
{
    public class RequestInteractionTest : BaseIntegrationTest, IClassFixture<WebTestFixture>
    {
        private readonly IAsyncRepository<RequestInteraction> _itemRepository;
        public readonly CLTPULLContext context;
        public RequestInteractionTest(WebTestFixture factory) : base(factory)
        {
            _itemRepository = factory.Services.GetRequiredService<IAsyncRepository<RequestInteraction>>();
            context = factory.Services.GetRequiredService<CLTPULLContext>();
        }

        [Fact]
        public async Task GetRequestInteractionFilter_ReturnSuccessStatusCode()
        {
            RequestInteraction requestInteraction = new RequestInteraction()
            {
                InteractionDescription = "Test Status Desc 1",
                EcgconfigurationId = "123",
                NotesOnObjectNaming = "Nelson, Alison",
                DataContentType = "TestReq",
                HelperAppOrTeamId = 1,
                DailyIntervalDays = "Daily",
                NotesOnTrigger = "Test_Manager"
            };
            await _itemRepository.AddAsync(requestInteraction);
            requestInteraction = new RequestInteraction()
            {
                InteractionDescription = "Test Status Desc 2",
                EcgconfigurationId = "123",
                NotesOnObjectNaming = "Nelson, Alison",
                DataContentType = "TestReq",
                HelperAppOrTeamId = 1,
                DailyIntervalDays = "Daily",
                NotesOnTrigger = "Test_Manager"
            };
            await _itemRepository.AddAsync(requestInteraction);
            var response = await _httpClient.GetAsync("api/assessmentinteraction/InteractionDescription/Test Status Desc 1");
            var responseResult = JsonConvert.DeserializeObject<GetRequestInteractionByFilterApiResponse>(response.Content.ReadAsStringAsync().Result);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(1, responseResult.RequestInteractionList.Count);
        }
        [Fact]
        public async Task GetRequestInteractionMasterData_ReturnSuccessStatusCode()
        {
            RequestInteractionMasterData requestInteractionMasterData = new RequestInteractionMasterData();
            await context.AddRangeAsync(requestInteractionMasterData.GetHelperAppOrTeam());
            await context.AddRangeAsync(requestInteractionMasterData.GetCompanionFileDetails());
            await context.AddRangeAsync(requestInteractionMasterData.GetFrequencyIntervalMasterData());
            await context.AddRangeAsync(requestInteractionMasterData.GetInstancesPerFrequencyIntervalMasterData());
            await context.AddRangeAsync(requestInteractionMasterData.GetInteractionAction());
            await context.AddRangeAsync(requestInteractionMasterData.GetInteractionMechanism());
            await context.AddRangeAsync(requestInteractionMasterData.GetInteractionReviewStatus());
            await context.AddRangeAsync(requestInteractionMasterData.GetInteractionSpan());
            await context.AddRangeAsync(requestInteractionMasterData.GetInteractionStatus());
            await context.AddRangeAsync(requestInteractionMasterData.GetInteractionTriggerType());
            await context.AddRangeAsync(requestInteractionMasterData.GetObjectDataFormat());
            await context.AddRangeAsync(requestInteractionMasterData.GetObjectofInteraction());
            await context.AddRangeAsync(requestInteractionMasterData.GetSourceService());
            await context.AddRangeAsync(requestInteractionMasterData.GetDestinationService());
            await context.AddRangeAsync(requestInteractionMasterData.GetNonServiceDataDestination());
            await context.AddRangeAsync(requestInteractionMasterData.GetNonServiceDataSource());
            await context.SaveChangesAsync();
            var response = await _httpClient.GetAsync("api/request-interaction-masterdata");
            response.EnsureSuccessStatusCode();
            var requestInteractionMasterDataApiResponse = JsonConvert.DeserializeObject<GetRequestInteractionMasterDataApiResponse>(response.Content.ReadAsStringAsync().Result);
            Assert.True(requestInteractionMasterDataApiResponse.InteractionAction.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.HelperAppOrTeam.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.CompanionFileType.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.FrequencyInterval.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.InstancesPerFrequencyInterval.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.InteractionMechanism.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.InteractionReviewStatus.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.InteractionSpan.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.InteractionStatus.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.InteractionTriggerType.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.ObjectDataFormat.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.ObjectofInteraction.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.SourceService.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.DestinationService.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.NonServiceDataDestination.Count > 0);
            Assert.True(requestInteractionMasterDataApiResponse.NonServiceDataSource.Count > 0);
        }

        [Fact]
        public async Task DisableRequestInteraction_ReturnSuccessStatusCode()
        {
            // Arrange - New Request 
            Request newRequest = new Request()
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

            //Act - New Request
            var newJsonPostData = JsonContent.Create(newRequest);
            var createResponse = await _httpClient.PostAsync("api/assessment-requests", newJsonPostData);
            createResponse.EnsureSuccessStatusCode();
            var newStringResponse = await createResponse.Content.ReadAsStringAsync();

            dynamic newData = JObject.Parse(newStringResponse);

            // Assert - Request 

            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

            // Arrange - New Request Interaction

            RequestInteraction newRequestInteraction = new RequestInteraction()
            {
                RequestId = newData.requestId,
                InteractionDescription = "Test_Interaction_Description_First_Disable",
                SourceServiceId = 1,
                NonServiceDataSourceName = "BPM",
                NonServiceDataDestinationName = "CHWY",
                DestinationServiceId = 1,
                DataContentType = "Test_Interaction_DataContentType_First_Disable"
            };

            // Act - New Request Interaction

            var jsonPostData = JsonContent.Create(newRequestInteraction);
            var postResponse = await _httpClient.PostAsync("api/assessment-requests-interaction", jsonPostData);
            postResponse.EnsureSuccessStatusCode();

            var stringResponse = await postResponse.Content.ReadAsStringAsync();

            // Assert - New Request Interaction

            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);


            // Act - Disbale Request Interaction
            dynamic data = JObject.Parse(stringResponse);
            RequestInteraction disableRequestInteraction = new RequestInteraction()
            {
                RequestInteractionId = data.requestInteractionId
            };

            jsonPostData = JsonContent.Create(disableRequestInteraction);
            var disbaleResponse = await _httpClient.PutAsync("api/disable-requests-interaction/" + disableRequestInteraction.RequestInteractionId, jsonPostData);
            disbaleResponse.EnsureSuccessStatusCode();

            // Assert - Disable Request Interaction

            Assert.Equal(HttpStatusCode.OK, disbaleResponse.StatusCode);

        }


        [Fact]
        public async Task AssociateInteractionWithRequest_ReturnSuccessStatusCode()
        {
            // Arrange - New Request - 1
            Request newRequest1 = new Request()
            {
                RequestTitle = "TestReq_1",
                RequestDescription = "TestReq_1",
                InitialRequestDate = DateTime.UtcNow,
                CustomerName = "TestReq_1",
                CustomerInfo = "TestReq_1",
                IsStartDateConfirmed = true,
                TargetStartDate = DateTime.UtcNow,
                ActualStartDate = DateTime.UtcNow,
                TargetFinishDate = DateTime.UtcNow,
                NumberOfInteractionsAssessed = 7,
                ActualFinishDate = DateTime.UtcNow,
                ProgramName = "Test_Program_1",
                ProgramManager = "Test_Manager_1",
                EsocAnalyst = "Test_Analyst_1",
                AssessmentTc = "Test_AssissmentTC_1",
                RequestServiceSlo = "Test_ServiceSLO_1",
                AssessmentTargetFinishDate = DateTime.UtcNow,
                AssessmentActualFinishDate = DateTime.UtcNow
            };

            //Act - New Request - 1

            var newJsonPostData1 = JsonContent.Create(newRequest1);
            var createResponse1 = await _httpClient.PostAsync("api/assessment-requests", newJsonPostData1);
            createResponse1.EnsureSuccessStatusCode();
            var newStringResponse1 = await createResponse1.Content.ReadAsStringAsync();

            dynamic newData1 = JObject.Parse(newStringResponse1);

            // Assert - New Request  - 1 

            Assert.Equal(HttpStatusCode.OK, createResponse1.StatusCode);

            // Arrange - New Request - 2
            Request newRequest2 = new Request()
            {
                RequestTitle = "TestReq_2",
                RequestDescription = "TestReq_2",
                InitialRequestDate = DateTime.UtcNow,
                CustomerName = "TestReq_2",
                CustomerInfo = "TestReq_2",
                IsStartDateConfirmed = true,
                TargetStartDate = DateTime.UtcNow,
                ActualStartDate = DateTime.UtcNow,
                TargetFinishDate = DateTime.UtcNow,
                NumberOfInteractionsAssessed = 7,
                ActualFinishDate = DateTime.UtcNow,
                ProgramName = "Test_Program_2",
                ProgramManager = "Test_Manager_2",
                EsocAnalyst = "Test_Analyst_2",
                AssessmentTc = "Test_AssissmentTC_2",
                RequestServiceSlo = "Test_ServiceSLO_2",
                AssessmentTargetFinishDate = DateTime.UtcNow,
                AssessmentActualFinishDate = DateTime.UtcNow
            };

            //Act - New Request - 2
            var newJsonPostData2 = JsonContent.Create(newRequest2);
            var createResponse2 = await _httpClient.PostAsync("api/assessment-requests", newJsonPostData2);
            createResponse2.EnsureSuccessStatusCode();
            var newStringResponse2 = await createResponse1.Content.ReadAsStringAsync();

            dynamic newData2 = JObject.Parse(newStringResponse2);

            // Assert - New Request  - 2

            Assert.Equal(HttpStatusCode.OK, createResponse1.StatusCode);

            // Arrange Assocaite RequestInteraction with RequestId

            RequestInteraction requestInteraction1 = new RequestInteraction()
            {
                RequestId = newData1.requestId,
                InteractionDescription = "Test_Request_Interaction_Description_First",
            };
            RequestInteraction requestInteraction2 = new RequestInteraction()
            {
                RequestId = newData2.requestId,
                InteractionDescription = "Test_Request_Interaction_Description_Second",

            };

            // Act 
            var jsonPostDataRequest1 = JsonContent.Create(requestInteraction1);
            var response1 = await _httpClient.PostAsync("api/assessment-requests-interaction", jsonPostDataRequest1);
            response1.EnsureSuccessStatusCode();

            //Assert 
            Assert.Equal(HttpStatusCode.OK, response1.StatusCode);
            var jsonPostDataRequest2 = JsonContent.Create(requestInteraction2);
            var response2 = await _httpClient.PostAsync("api/assessment-requests-interaction", jsonPostDataRequest2);
            response2.EnsureSuccessStatusCode();

            //Assert 
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);

            // Arrange Assocaite RequestInteraction with RequestId
            dynamic data1 = JObject.Parse(await response1.Content.ReadAsStringAsync());
            dynamic data2 = JObject.Parse(await response2.Content.ReadAsStringAsync());

            var requestInteractionId1 = data1.requestInteractionId.Value;
            var requestInteractionId2 = data2.requestInteractionId.Value;

            List<int> requsetInteractionIds = new List<int>();
            requsetInteractionIds.Add(Convert.ToInt32(requestInteractionId1));
            requsetInteractionIds.Add(Convert.ToInt32(requestInteractionId2));

            // Act Assocaite RequestInteraction with RequestId

            AssociateRequestInteractionWithRequestApiRequest associcateRequestInteraction = new AssociateRequestInteractionWithRequestApiRequest
            {
                RequestId = newData1.requestId,
                RequestInteractionIds = requsetInteractionIds
            };

            var jsonPostAssocicateRequestInteraction = JsonContent.Create(associcateRequestInteraction);
            var response = await _httpClient.PutAsync("api/associate-interaction-with-request", jsonPostAssocicateRequestInteraction);
            response.EnsureSuccessStatusCode();

            // Assert Assocaite RequestInteraction with RequestId
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GivenRequestInteraction_WhenUpdated_ThenUpdatesInteractionWithNewValues()
        {
            dynamic newRequest = await GetRequestResponse();
            dynamic requestInteraction = await GetRequestInteractionResponse((Int32)newRequest.requestId, InteractionReviewStatusEnum.InProgress);
            dynamic updatedInteraction = await UpdateOrCloneInteraction((Int32)requestInteraction.requestInteractionId);
            Assert.Equal((Int32)requestInteraction.requestInteractionId, (Int32)updatedInteraction.requestInteraction.requestInteractionId);
        }
        [Fact]
        public async Task GivenRequestInteraction_WhenCopied_ThenCreatesNewInteractionSameAsRequestInteraction()
        {
            dynamic newRequest = await GetRequestResponse();
            dynamic requestInteraction = await GetRequestInteractionResponse((Int32)newRequest.requestId, InteractionReviewStatusEnum.InProgress);
            dynamic clonedInteraction = await UpdateOrCloneInteraction(0);
            Assert.NotEqual((Int32)requestInteraction.requestInteractionId, (Int32)clonedInteraction.requestInteraction.requestInteractionId);
        }
    }
}