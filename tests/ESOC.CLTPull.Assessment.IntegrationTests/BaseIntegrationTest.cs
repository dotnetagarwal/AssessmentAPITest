using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.IntegrationTests;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ESOC.CLTPull.WebApi
{
    /// <summary>
    /// Base class used by API responses
    /// </summary>
    public class BaseIntegrationTest
    {
        protected readonly HttpClient _httpClient;
        public BaseIntegrationTest(WebTestFixture factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("http://localhost:53706/");
            _httpClient = factory.CreateClient();
        }

        public async Task<dynamic> GetRequestResponse()
        {
            var requestJson = JsonContent.Create(RequestTestData.GetTestRequestObject());
            var requestResponse = await _httpClient.PostAsync("api/assessment-requests", requestJson);
            requestResponse.EnsureSuccessStatusCode();
            dynamic request = JObject.Parse(await requestResponse.Content.ReadAsStringAsync());
            return request;
        }

        public async Task<dynamic> GetRequestInteractionResponse(int requestId, InteractionReviewStatusEnum interactionReviewStatus)
        {
            var requestInteractionJson = JsonContent.Create(RequestInteractionTestData.GetRequestInteractionTestObject(requestId, interactionReviewStatus));
            var requestInteractionResponse = await _httpClient.PostAsync("api/assessment-requests-interaction", requestInteractionJson);
            requestInteractionResponse.EnsureSuccessStatusCode();
            dynamic requestInteraction = JObject.Parse(await requestInteractionResponse.Content.ReadAsStringAsync());
            return requestInteraction;
        }

        
        public async Task<dynamic> AssociateInteractionWithRequest(int requestInteractionId, int requestId)
        {
            RequestInteraction requestInteraction = new RequestInteraction()
            {
                RequestId = requestId,
                RequestInteractionId= requestInteractionId,
                InteractionDescription = "Updated Request Id",
                ModifiedDate = DateTime.Now
            };

            var jsonPutDataRequest = JsonContent.Create(requestInteraction);
            var requestInteractionResponse = await _httpClient.PutAsync("api/assessment-requests-interaction", jsonPutDataRequest);
            requestInteractionResponse.EnsureSuccessStatusCode();
            dynamic updatedRequestInteraction = JObject.Parse(await requestInteractionResponse.Content.ReadAsStringAsync());
            return updatedRequestInteraction;
        }
        public async Task<dynamic> UpdateOrCloneInteraction(int requestInteractionId)
        {
            RequestInteraction requestInteraction = new RequestInteraction()
            {
                RequestInteractionId = requestInteractionId,
                InteractionDescription = "Updated Interaction",
                ModifiedDate = DateTime.Now
            };

            var jsonPutDataRequest = JsonContent.Create(requestInteraction);
            var requestInteractionResponse = await _httpClient.PutAsync("api/assessment-requests-interaction", jsonPutDataRequest);
            requestInteractionResponse.EnsureSuccessStatusCode();
            dynamic updatedRequestInteraction = JObject.Parse(await requestInteractionResponse.Content.ReadAsStringAsync());
            return updatedRequestInteraction;
        }

        public async Task PublishInteractionWithRequest(int[] requestInteractionIds)
        {
            var postData = new
            {
                RequestInteractionIds = requestInteractionIds
            };
            var requestInteractionResponse = await _httpClient.PutAsync("api/assessment-requests-interaction-publish", JsonContent.Create(postData));
            requestInteractionResponse.EnsureSuccessStatusCode();
        }

    }
}
