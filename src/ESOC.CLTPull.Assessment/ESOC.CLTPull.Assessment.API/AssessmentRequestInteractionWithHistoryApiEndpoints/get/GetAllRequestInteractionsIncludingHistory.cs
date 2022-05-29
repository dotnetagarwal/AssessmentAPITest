using Ardalis.ApiEndpoints;
using AutoMapper;

using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionWithHistoryApiEndpoints
{
    public class GetAllRequestInteractionsIncludingHistory : BaseAsyncEndpoint
         .WithoutRequest
         .WithResponse<RequestInteractionWithHistoryResponse>
    {
        private readonly IRequestInteractionHistoryRepository _requestInteractionHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IRequestInteractionRepository _requestInteractionRepository;
        

        //private readonly IGetRequestInteractionListWithHistory _requestInteractionWithHistoryRepository;

        public GetAllRequestInteractionsIncludingHistory( IRequestInteractionHistoryRepository requestInteractionHistoryRepository, IMapper mapper, IRequestInteractionRepository requestInteractionRepository)
        {
            _requestInteractionHistoryRepository = requestInteractionHistoryRepository;
            _mapper = mapper;
            _requestInteractionRepository = requestInteractionRepository;

        }

        [HttpGet("api/assessment-all-interaction-including-history")]
        [SwaggerOperation(
            Summary = "Get all Request Interactions Including History",
            Description = "Get all Request Interactions Including History",
            OperationId = "assessments.GetRequestInteractionWithHistoryList",
            Tags = new[] { "AssessmentRequestInteractionWithHistoryWorkItemEndpoints" })
        ]

        public override async Task<ActionResult<RequestInteractionWithHistoryResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            List<RequestInteractionListDataDTO> requestInteractionList = _requestInteractionRepository.GetRequestInteractionListData();        
            List<RequestInteractionHistoryListDataDTO> requestInteractionHistoryList =  _requestInteractionHistoryRepository.GetRequestInteractionHistoryListData();     
            requestInteractionList.AddRange(requestInteractionHistoryList.Select(_mapper.Map<RequestInteractionListDataDTO>));
            return Ok(requestInteractionList);
        }
    }

}
