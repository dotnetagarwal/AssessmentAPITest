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

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionHistoryApiEndpoints
{
    public class GetRequestInteractionHistoryList : BaseAsyncEndpoint
         .WithoutRequest
         .WithResponse<GetRequestInteractionHistoryListResponse>
    {
        private readonly IRequestInteractionHistoryRepository _requestInteractionHistoryRepository;
     
        public GetRequestInteractionHistoryList(IRequestInteractionHistoryRepository requestInteractionHistoryRepository)
        {
            _requestInteractionHistoryRepository = requestInteractionHistoryRepository;
        }

        [HttpGet("api/assessment-requestinteractionhistorylist-all")]
        [SwaggerOperation(
            Summary = "GetRequestInteractionHistoryList All Assessment RequestInteractionHistory",
            Description = "GetRequestInteractionHistoryList All Assessment RequestInteractionHistory",
            OperationId = "assessments.GetRequestInteractionHistoryList",
            Tags = new[] { "AssessmentRequestInteractionHistoryWorkItemEndpoints" })
        ]

        public override async Task<ActionResult<GetRequestInteractionHistoryListResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<RequestInteractionHistoryListDataDTO> requestInteractionHistoryList = _requestInteractionHistoryRepository.GetRequestInteractionHistoryListData();
            if (requestInteractionHistoryList is null) return NotFound();
            GetRequestInteractionHistoryListResponse response = new GetRequestInteractionHistoryListResponse();
            response.RequestInteractionHistoryViewList = (ICollection<RequestInteractionHistoryListDataDTO>)requestInteractionHistoryList;
            return Ok(response);
        }
    }

    }
