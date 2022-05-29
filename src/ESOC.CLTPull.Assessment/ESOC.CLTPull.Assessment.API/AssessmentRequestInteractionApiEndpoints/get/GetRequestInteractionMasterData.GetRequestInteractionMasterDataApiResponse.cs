using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;

namespace ESOC.CLTPull.Assessment.API.AssessmentRequestInteractionApiEndpoints
{
    public class GetRequestInteractionMasterDataApiResponse : BaseResponse
    {
        public GetRequestInteractionMasterDataApiResponse(Guid correlationId) : base(correlationId)
        {
        }
        public GetRequestInteractionMasterDataApiResponse()
        {
        }
        public ICollection<InteractionAction> InteractionAction { get; set; }
        public ICollection<HelperAppOrTeam> HelperAppOrTeam { get; set; }
        public ICollection<SourceService> SourceService { get; set; }
        public ICollection<InstancesPerFrequencyInterval> InstancesPerFrequencyInterval { get; set; }
        public ICollection<FrequencyInterval> FrequencyInterval { get; set; }
        public ICollection<InteractionMechanism> InteractionMechanism { get; set; }
        public ICollection<InteractionTriggerType> InteractionTriggerType { get; set; }
        public ICollection<CompanionFileType> CompanionFileType { get; set; }
        public ICollection<ObjectDataFormat> ObjectDataFormat { get; set; }
        public ICollection<ObjectofInteraction> ObjectofInteraction { get; set; }
        public ICollection<InteractionStatus> InteractionStatus { get; set; }
        public ICollection<InteractionSpan> InteractionSpan { get; set; }
        public ICollection<InteractionReviewStatus> InteractionReviewStatus { get; set; }
        public ICollection<DestinationService> DestinationService { get; set; }
        public ICollection<NonServiceDataSource> NonServiceDataSource { get; set; }
        public ICollection<NonServiceDataDestination> NonServiceDataDestination { get; set; }

    }
}
