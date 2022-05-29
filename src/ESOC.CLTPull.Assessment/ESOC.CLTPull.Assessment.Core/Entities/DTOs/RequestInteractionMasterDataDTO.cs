using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Entities.DTOs
{
    public class RequestInteractionMasterDataDTO
    {
        public virtual ICollection<InteractionAction> InteractionAction { get; set; }
        public virtual ICollection<HelperAppOrTeam> HelperAppOrTeam { get; set; }
        public virtual ICollection<SourceService> SourceService { get; set; }
        public virtual ICollection<InstancesPerFrequencyInterval> InstancesPerFrequencyInterval { get; set; }
        public virtual ICollection<FrequencyInterval> FrequencyInterval { get; set; }
        public virtual ICollection<InteractionMechanism> InteractionMechanism { get; set; }
        public virtual ICollection<InteractionTriggerType> InteractionTriggerType { get; set; }
        public virtual ICollection<CompanionFileType> CompanionFileType { get; set; }
        public virtual ICollection<ObjectDataFormat> ObjectDataFormat { get; set; }
        public virtual ICollection<ObjectofInteraction> ObjectofInteraction { get; set; }
        public virtual ICollection<InteractionStatus> InteractionStatus { get; set; }
        public virtual ICollection<InteractionSpan> InteractionSpan { get; set; }
        public virtual ICollection<InteractionReviewStatus> InteractionReviewStatus { get; set; }
        public virtual ICollection<DestinationService> DestinationService { get; set; }
        public virtual ICollection<NonServiceDataSource> NonServiceDataSource { get; set; }
        public virtual ICollection<NonServiceDataDestination> NonServiceDataDestination { get; set; }
    }
}
