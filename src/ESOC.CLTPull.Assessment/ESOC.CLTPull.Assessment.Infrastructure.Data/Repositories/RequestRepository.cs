using System.Threading.Tasks;
using ESOC.CLTPull.Infrastructure.Data.Repositories.BaseW;
using Microsoft.EntityFrameworkCore;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.Core.Contracts;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ESOC.CLTPull.Assessment.Core.Constants;
using ESOC.CLTPull.Assessment.Core.Extensions;
using ESOC.CLTPull.Assessment.Infrastructure.Data;
using System.Linq;

namespace ESOC.CLTPull.Infrastructure.Data.Repositories
{
    /// <inheritdoc />
    public sealed class RequestRepository : Repository<Request>, IRequestRepository
    {
        protected readonly CLTPULLContext _dbContext;
        private readonly IConfiguration _configuration;
        public RequestRepository(CLTPULLContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _configuration = configuration;

        }
        public Task<Request> GetByIdAsessmentRequestsAsync(int id)
        {
            return _dbContext.Request
                .Include(o => o.RequestInteraction)
                .FirstOrDefaultAsync(x => x.RequestId == id);
        }

        public async Task<List<ServiceDetails>> GetServicesByTerm(string term)
        {
            return await _dbContext.EsocaideData.Where(x => x.EsocaliasNames.Contains(term)).Select(x=>new ServiceDetails { Name= x.Name, Id=x.Id }).ToListAsync();
        }

        public async Task<RequestMasterDataDTO> GetRequestMasterData()
        {
            RequestMasterDataDTO requestMasterData = new RequestMasterDataDTO();
            requestMasterData.LineOfBusiness = await _dbContext.Set<LineOfBusiness>().ToListAsync();
            requestMasterData.RequestChannel = await _dbContext.Set<RequestChannel>().ToListAsync();
            requestMasterData.RequestService = await _dbContext.Set<RequestService>().ToListAsync();
            requestMasterData.RequestType = await _dbContext.Set<RequestType>().ToListAsync();
            requestMasterData.RequestState = await _dbContext.Set<RequestState>().ToListAsync();
            requestMasterData.AssessmentScope = await _dbContext.Set<AssessmentScope>().ToListAsync();
            requestMasterData.AssessmentStatus = await _dbContext.Set<AssessmentStatus>().ToListAsync();
            requestMasterData.AssessmentDesigners = await _dbContext.Set<AssessmentDesigners>().ToListAsync();
            return requestMasterData;
        }
        public List<RequestListDataDTO> GetRequestListData()
        {
            string ConnectionString = _configuration.GetConnectionString(SqlConstants.cltpullDb);
            string query = SqlConstants.vw_GetAllRequestData;
            AdoHelper.Connect(ConnectionString);
            SqlDataReader reader = AdoHelper.ExecDataReader(query);
            List<RequestListDataDTO> requestListDataDTO = new List<RequestListDataDTO>();
            RequestListDataDTO requestDataDTO = null;
            while (reader.Read())
            {
                requestDataDTO = new RequestListDataDTO
                {
                    RequestId = reader.Value<Int32>("RequestId"),
                    RequestTypeId = reader.Value<Int32?>("RequestTypeId"),
                    RequestTypeName = reader.Value<String>("RequestTypeName"),
                    RequestTitle = reader.Value<String>("RequestTitle"),
                    RequestDescription = reader.Value<String>("RequestDescription"),
                    ProgramName = reader.Value<String>("ProgramName"),
                    ProgramManager = reader.Value<String>("ProgramManager"),
                    RequestChannelId = reader.Value<Int32?>("RequestChannelId"),
                    RequestChannelName = reader.Value<String>("RequestChannelName"),
                    InitialRequestDate = reader.Value<DateTime?>("InitialRequestDate"),
                    CustomerName = reader.Value<String>("CustomerName"),
                    CustomerInfo = reader.Value<String>("CustomerInfo"),
                    LineOfBusinessName = reader.Value<String>("LineOfBusinessName"),
                    LineOfBusinessId = reader.Value<Int32?>("LineOfBusinessId"),
                    FundingSource = reader.Value<String>("FundingSource"),
                    RequestLead = reader.Value<String>("RequestLead"),
                    RequestServiceId = reader.Value<Int32?>("Id"),
                    RequestServiceName = reader.Value<String>("Name"),
                    IsStartDateConfirmed = reader.Value<Boolean?>("IsStartDateConfirmed"),
                    RequestStateId = reader.Value<Int32?>("RequestStateId"),
                    RequestStateName = reader.Value<String>("RequestStateName"),
                    AssessmentStatusId = reader.Value<Int32?>("AssessmentStatusId"),
                    AssessmentStatusName = reader.Value<String>("AssessmentStatusName"),
                    TargetStartDate = reader.Value<DateTime?>("TargetStartDate"),
                    ActualStartDate = reader.Value<DateTime?>("ActualStartDate"),
                    TargetFinishDate = reader.Value<DateTime?>("TargetFinishDate"),
                    NumberOfInteractionsAssessed = reader.Value<Int32?>("NumberOfInteractionsAssessed"),
                    ActualFinishDate = reader.Value<DateTime?>("ActualFinishDate"),
                    CancelDate = reader.Value<DateTime?>("CancelDate"),
                    Notes = reader.Value<String>("Notes"),
                    RequestDocumentation = reader.Value<String>("RequestDocumentation"),
                    PrjidorServiceNowTicket = reader.Value<String>("PrjidorServiceNowTicket"),
                    Prjname = reader.Value<String>("Prjname"),
                    ESOCAnalyst = reader.Value<String>("ESOCAnalyst"),
                    AssessmentScopeId = reader.Value<Int32?>("AssessmentScopeId"),
                    AssessmentScopeName = reader.Value<String>("AssessmentScopeName"),
                    RequestServiceSLO = reader.Value<String>("RequestServiceSLO"),
                    CreatedBy = reader.Value<String>("CreatedBy"),
                    CreatedDate = reader.Value<DateTime?>("CreatedDate"),
                    ModifiedBy = reader.Value<String>("ModifiedBy"),
                    ModifiedDate = reader.Value<DateTime?>("ModifiedDate"),
                    IsActive = reader.Value<Boolean?>("IsActive"),
                    AssessmentTC = reader.Value<String>("AssessmentTC"),
                    AssessmentActualFinishDate = reader.Value<DateTime?>("AssessmentActualFinishDate"),
                    AssessmentTargetFinishDate = reader.Value<DateTime?>("AssessmentTargetFinishDate"),
                };
                requestListDataDTO.Add(requestDataDTO);
            }
            reader.Close();
            AdoHelper.Dispose(true);
            return requestListDataDTO;
        }
    }
}