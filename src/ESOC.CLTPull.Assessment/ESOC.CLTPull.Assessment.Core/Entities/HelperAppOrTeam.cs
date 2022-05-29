using System;
using System.Collections.Generic;

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class HelperAppOrTeam
    {
        public HelperAppOrTeam()
        {
            RequestInteraction = new HashSet<RequestInteraction>();
        }

        public int HelperAppOrTeamId { get; set; }
        public string HelperAppOrTeamName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<RequestInteraction> RequestInteraction { get; set; }
    }
}
