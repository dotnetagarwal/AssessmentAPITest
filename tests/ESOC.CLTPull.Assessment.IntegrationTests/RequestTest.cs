using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ESOC.CLTPull.WebApi;
using System.Net.Http;
using System.Threading.Tasks;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using ESOC.CLTPull.Infrastructure.Data.Repositories.BaseW;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using ESOC.CLTPull.Infrastructure.Data;
using ESOC.CLTPull.Assessment.IntegrationTests.MasterData;
using Newtonsoft.Json;
using ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints.get;
using System.Collections.Generic;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;

namespace ESOC.CLTPull.Assessment.IntegrationTests
{
    public class RequestTest : BaseIntegrationTest, IClassFixture<WebTestFixture>
    {
        public readonly CLTPULLContext context;

        public RequestTest(WebTestFixture factory) : base(factory)
        {
            context = factory.Services.GetRequiredService<CLTPULLContext>();
        }
        [Fact]
        public async Task CreateRequest_ReturnSuccessStatusCode()
        {
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

            var jsonPostData = JsonContent.Create(newRequest);

            var response = await _httpClient.PostAsync("api/assessment-requests", jsonPostData);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            //test comment
            //Assert TODO
        }

        [Fact]
        public async Task UpdateRequest_ReturnSuccessStatusCode()
        {
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

            var jsonPostData = JsonContent.Create(newRequest);
            var response = await _httpClient.PostAsync("api/assessment-requests", jsonPostData);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            //Assert TODO

            dynamic data = JObject.Parse(stringResponse);
            Request updateRequest = new Request()
            {
                RequestId = data.requestId,
                RequestTitle = "UpdateReq",
                RequestDescription = "UpdateReq",
                CustomerInfo = "UpdateReq",
                IsStartDateConfirmed = true,
                ProgramName = "Test_Program_U",
                ProgramManager = "Test_Manager_U",
                EsocAnalyst = "Test_Analyst_U",
                AssessmentTc = "Test_AssissmentTC_U",
                RequestServiceSlo = "Test_ServiceSLO_U",
            };

            jsonPostData = JsonContent.Create(updateRequest);
            response = await _httpClient.PutAsync("api/assessments-requests", jsonPostData);
            response.EnsureSuccessStatusCode();
            stringResponse = await response.Content.ReadAsStringAsync();


            //Assert TODO

        }

        [Fact]
        public async Task GetServiceDetails()
        {
            RequestInteractionMasterData requestInteractionMasterData = new RequestInteractionMasterData();
            await context.AddRangeAsync(requestInteractionMasterData.GetESOCAideServiceData());
            await context.SaveChangesAsync();
            var response = await _httpClient.GetAsync("api/services/A");
            response.EnsureSuccessStatusCode();
            var x = response.Content.ReadAsStringAsync();
            var requestInteractionMasterDataApiResponse = JsonConvert.DeserializeObject<List<ServiceDetails>>(response.Content.ReadAsStringAsync().Result);
            Assert.True(requestInteractionMasterDataApiResponse.Count > 0);
        }
    }
}
