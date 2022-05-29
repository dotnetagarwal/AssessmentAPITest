using ESOC.CLTPull.Assessment.Core.Entities;
using System.Threading.Tasks;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using System.Collections.Generic;

namespace ESOC.CLTPull.Core.Contracts
{
    public interface IRequestInteractionRepository
    {
        Task<RequestInteractionMasterDataDTO> GetRequestInteractionMasterData();
        List<RequestInteractionListDataDTO> GetRequestInteractionListData();
        Task<List<RequestInteraction>> GetRequestInteractionList(int[] requestInteractionIds);
        Task<int[]> GetRequestInteractionForComparison(RequestInteraction requestInteractionIds);
    }
}
