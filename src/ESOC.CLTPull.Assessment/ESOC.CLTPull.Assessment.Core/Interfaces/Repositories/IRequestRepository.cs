using ESOC.CLTPull.Assessment.Core.Entities;
using System.Threading.Tasks;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using System.Collections.Generic;

namespace ESOC.CLTPull.Core.Contracts
{
    public interface IRequestRepository
    {
        Task<Request> GetByIdAsessmentRequestsAsync(int id);
        Task<RequestMasterDataDTO> GetRequestMasterData(); 
        List<RequestListDataDTO> GetRequestListData();
        Task<List<ServiceDetails>> GetServicesByTerm(string term);
    }
}
