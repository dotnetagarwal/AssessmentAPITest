using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using ESOC.CLTPull.Assessment.IntegrationTests.MasterData;
using ESOC.CLTPull.Infrastructure.Data;
using ESOC.CLTPull.WebApi;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace ESOC.CLTPull.Assessment.IntegrationTests
{
    public class RequestHistoryTest : BaseIntegrationTest, IClassFixture<WebTestFixture>
    {
        private readonly IAsyncRepository<RequestInteraction> _itemRequestInteractionRepository;
        private readonly IAsyncRepository<RequestInteractionHistory> _itemHistoryRepository;
        public readonly CLTPULLContext context;
        public RequestHistoryTest(WebTestFixture factory) : base(factory)
        {
            _itemRequestInteractionRepository = factory.Services.GetRequiredService<IAsyncRepository<RequestInteraction>>();
            _itemHistoryRepository = factory.Services.GetRequiredService<IAsyncRepository<RequestInteractionHistory>>();
            context = factory.Services.GetRequiredService<CLTPULLContext>();
        }

        [Fact]
        public async Task GivenRequestIntearctionRecordWithoutPublishHistory_WhenDelete_ThenRecordShouldBeDeleted()
        {
            //1.Add 2 records in Request 
            //2.Add record in Request Interaction and associate it with Request1 without Published Date
            //3.Modify  Request Interaction record and associate it with Request2
            //4.Verify Request1 Record should go to History table
            //5.Delete Record from Request Interaction
            //6.It should be deleted as Last Accessed Date not updated in History Record

            dynamic firstRequest = await GetRequestResponse();
            dynamic secondRequest = await GetRequestResponse();
            dynamic requestInteraction = await GetRequestInteractionResponse((Int32)firstRequest.requestId, InteractionReviewStatusEnum.InProgress);
            dynamic updatedRequestInteraction = await AssociateInteractionWithRequest((Int32)requestInteraction.requestInteractionId, (Int32)secondRequest.requestId);

            //Verify record should be in History table
            var requestInteractionHistories = await _itemHistoryRepository.ListAllAsync();
            var interactionHistories = requestInteractionHistories.Where(x => x.RequestId == (Int32)firstRequest.requestId);
            Assert.True(interactionHistories.Count() > 0);

            //Delete Record from RequestInteraction table
            var deleteInteractionResponse = await _httpClient.DeleteAsync(String.Format("api/delete-requests-interaction/{0}", requestInteraction.requestInteractionId));
            deleteInteractionResponse.EnsureSuccessStatusCode();

            //Fetch record from RequestInteraction table
            var deletedRequestInteractionId = await _itemRequestInteractionRepository.GetByIdAsync((Int32)requestInteraction.requestInteractionId);
            Assert.Null(deletedRequestInteractionId);
        }


        [Fact]
        public async Task GivenRequestIntearctionRecordWithPublishHistory_WhenDelete_ThenHistoryRecordDeletedAndShouldReplaceExistingRecord()
        {
            //1.Add 2 records in Request 
            //2.Add record in Request Interaction and associate it with Request1 with Published Date
            //3.Modify  Request Interaction record and associate it with Request2
            //4.Verify Request1 Record should go to History table
            //5.Delete Record from Request Interaction
            //6. History record with RequestId=1 should be updated in Request Interaction table

            dynamic firstRequest = await GetRequestResponse();
            dynamic secondRequest = await GetRequestResponse();
            dynamic requestInteraction = await GetRequestInteractionResponse((Int32)firstRequest.requestId, InteractionReviewStatusEnum.InProgress);

            //Publish above interaction
            await PublishInteractionWithRequest(new int[] { (Int32)requestInteraction.requestInteractionId });

            dynamic updatedRequestInteraction = await AssociateInteractionWithRequest((Int32)requestInteraction.requestInteractionId, (Int32)secondRequest.requestId);
  
            //Verify record should be in History table
            var requestInteractionHistories = await _itemHistoryRepository.ListAllAsync();
            var interactionHistories = requestInteractionHistories.Where(x => x.RequestId == (Int32)firstRequest.requestId);
            Assert.True(interactionHistories.Count() > 0);

            //Delete Record from RequestInteraction table
            var deleteInteractionResponse = await _httpClient.DeleteAsync(String.Format("api/delete-requests-interaction/{0}", requestInteraction.requestInteractionId));
            deleteInteractionResponse.EnsureSuccessStatusCode();

            //Fetch record from RequestInteraction table, it should be replaced from History
            var deletedRequestInteractionId = await _itemRequestInteractionRepository.GetByIdAsync((Int32)requestInteraction.requestInteractionId);
            Assert.NotNull(deletedRequestInteractionId);
            Assert.Equal((Int32)firstRequest.requestId, (Int32)requestInteraction.requestId);
        }

        [Fact]
        public async Task GivenRequestIntearctionRecordWithPublishHistory_WhenDelete_ThenHistoryRecordDeletedAndShouldReplaceWithLatestPublishedRecord()
        {
            //1.Add 3 records in Request 
            //2.Add record in Request Interaction and associate it with Request1 with Published Date
            //3.Modify  Request Interaction record and associate it with Request2
            //4.Verify Request1 Record should go to History table
            //5.Modify  Request Interaction record and associate it with Request3
            //6.Verify Request2 Record should go to History table
            //7.Delete Record from Request Interaction
            //8. It should be updated in Request Interaction table with RequestId=2 as it was latest publish record

            dynamic firstRequest = await GetRequestResponse();
            dynamic secondRequest = await GetRequestResponse();
            dynamic thirdRequest = await GetRequestResponse();
            dynamic requestInteraction = await GetRequestInteractionResponse((Int32)firstRequest.requestId, InteractionReviewStatusEnum.InProgress);

            //Publish above interaction
            await PublishInteractionWithRequest(new int[] { (Int32)requestInteraction.requestInteractionId });

            //Associate RequestInteraction With SecondRequest 
            dynamic updatedRequestInteraction = await AssociateInteractionWithRequest((Int32)requestInteraction.requestInteractionId, (Int32)secondRequest.requestId);


            //Verify first request record should be in History table
            var requestInteractionHistories = await _itemHistoryRepository.ListAllAsync();
            var interactionHistories = requestInteractionHistories.Where(x => x.RequestId == (Int32)firstRequest.requestId);
            Assert.True(interactionHistories.Count() > 0);

            //Publish interaction again
            await PublishInteractionWithRequest(new int[] { (Int32)requestInteraction.requestInteractionId });

            //Now Associate it with ThirdRequest
            updatedRequestInteraction = await AssociateInteractionWithRequest((Int32)requestInteraction.requestInteractionId, (Int32)thirdRequest.requestId);

            //Verify second request record should be in History table
            requestInteractionHistories = await _itemHistoryRepository.ListAllAsync();
            interactionHistories = requestInteractionHistories.Where(x => x.RequestId == (Int32)secondRequest.requestId);
            Assert.True(interactionHistories.Count() > 0);

            //Delete Record from RequestInteraction table
            var deleteInteractionResponse = await _httpClient.DeleteAsync(String.Format("api/delete-requests-interaction/{0}", requestInteraction.requestInteractionId));
            deleteInteractionResponse.EnsureSuccessStatusCode();

            //Fetch record from RequestInteraction table, it should be replaced from History with SecondRequest
            var updatedRequestInteractionAfterDeletion = await _itemRequestInteractionRepository.GetByIdAsync((Int32)requestInteraction.requestInteractionId);
            Assert.NotNull(updatedRequestInteractionAfterDeletion);
            Assert.Equal((Int32)secondRequest.requestId, (Int32)updatedRequestInteractionAfterDeletion.RequestId);
        }


        [Fact]
        public async Task GivenRequestIntearctionRecordWithInteractionStatusAsInternalReviewInProgress_WhenPublished_ThenRecordShouldBePublishedWithLastAccessedDate()
        {
            //1.Add 1 record in Request 
            //2.Add record in Request Interaction With InteractionStatus As InternalReviewInProgress 
            //3. Make this interaction Publish
            //4.Verify LastAccessedDate and InteractionReviewStatus as Published
          
            dynamic firstRequest = await GetRequestResponse();
            dynamic requestInteraction = await GetRequestInteractionResponse((Int32)firstRequest.requestId, InteractionReviewStatusEnum.InternalReviewInProgress);

            //Publish interaction 
            await PublishInteractionWithRequest(new int[] { (Int32)requestInteraction.requestInteractionId });

            //Fetch record from RequestInteraction table
            var publishedRequestInteraction = await _itemRequestInteractionRepository.GetByIdAsync((Int32)requestInteraction.requestInteractionId);
            Assert.NotNull(publishedRequestInteraction);
            Assert.NotNull(publishedRequestInteraction.LastAccessedDate);
            Assert.Equal((Int32)firstRequest.requestId, (Int32)publishedRequestInteraction.RequestId);
            Assert.Equal((Int32)InteractionReviewStatusEnum.Published, (Int32)publishedRequestInteraction.InteractionReviewStatusId);        
        }
    }
}
