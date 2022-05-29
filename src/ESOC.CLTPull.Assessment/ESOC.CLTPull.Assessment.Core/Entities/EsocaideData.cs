using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Entities
{
    public partial class EsocaideData
    {
        public int Id { get; set; }
        public string AskId { get; set; }
        public string Name { get; set; }
        public string AliasNames { get; set; }
        public string Category { get; set; }
        public string LifecycleStatus { get; set; }
        public int? Cbaflag { get; set; }
        public string ServiceName { get; set; }
        public string ServiceWorkgroupName { get; set; }
        public string ServiceLob { get; set; }
        public string ServiceSubLob { get; set; }
        public string ServiceLobexec { get; set; }
        public string GlbusinessSegment { get; set; }
        public string ServiceOwnerName { get; set; }
        public string TechOwnerName { get; set; }
        public bool? IsControlUiactive { get; set; }
        public string EsocaliasNames { get; set; }
    }
}
