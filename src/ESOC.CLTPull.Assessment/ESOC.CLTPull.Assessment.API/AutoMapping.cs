using AutoMapper;
using CLTPull.Assessment.Api.AssessmentRequestInteractionApiEndpoints;
using CLTPull.Assessment.Api.AssessmentWorkItemEndpoints;
using ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints;
using ESOC.CLTPull.Assessment.API.AssessmentRequestApiEndpoints.get;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionWithHistoryApiEndpoints;
using ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints.get;

namespace ESOC.CLTPull.Assessment.API
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateAssessmentRequestApiRequest, Request>();
            CreateMap<RequestMasterDataDTO, GetRequestMasterDataApiResponse>();
            CreateMap<RequestInteractionMasterDataDTO, GetRequestInteractionMasterDataApiResponse>();
            CreateMap<GetRequestListAssessmentRequestApiResponse, RequestListDataDTO>();
            CreateMap<Request, CreateAssessmentRequestApiResponse>();
            CreateMap<CreateAssessmentRequestInteractionApiRequest, RequestInteraction>();
            CreateMap<RequestInteraction, CreateAssessmentRequestInteractionApiResponse>();
            CreateMap<RequestInteraction, RequestInteractionHistory>();
            CreateMap<RequestInteractionHistoryListDataDTO, RequestInteractionListDataDTO>();
            CreateMap<GetServicesDetailsApiResponse, List<ServiceDetails>>();
        }
    }
}
