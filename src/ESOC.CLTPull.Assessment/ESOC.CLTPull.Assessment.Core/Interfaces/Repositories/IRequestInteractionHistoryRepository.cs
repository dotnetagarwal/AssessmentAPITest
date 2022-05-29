using ESOC.CLTPull.Assessment.Core.Entities;
using System.Threading.Tasks;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using System.Collections.Generic;

namespace ESOC.CLTPull.Core.Contracts
{
    public interface IRequestInteractionHistoryRepository
    {
        List<RequestInteractionHistoryListDataDTO> GetRequestInteractionHistoryListData();
    }
}
