using System;
using System.Collections.Generic;

#nullable disable

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class FrequencyInterval
    {
        public FrequencyInterval()
        {
            RequestInteraction = new HashSet<RequestInteraction>();
        }

        public int FrequencyIntervalId { get; set; }
        public string FrequencyIntervalName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<RequestInteraction> RequestInteraction { get; set; }
    }
}
