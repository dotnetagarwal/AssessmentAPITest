using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Entities.DTOs
{
    public class RequestInteractionHistoryListDataDTO : RequestInteractionListDataDTO
    {
       public int RequestInteractionHistoryId { get; set; }
    }
}