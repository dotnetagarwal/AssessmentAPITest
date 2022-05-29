using System.Threading.Tasks;
using ESOC.CLTPull.Infrastructure.Data.Repositories.BaseW;
using Microsoft.EntityFrameworkCore;
using ESOC.CLTPull.Assessment.Core.Entities;
using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using ESOC.CLTPull.Assessment.Core.Extensions;
using Microsoft.Extensions.Configuration;
using ESOC.CLTPull.Assessment.Core.Constants;
using ESOC.CLTPull.Assessment.Infrastructure.Data;

namespace ESOC.CLTPull.Infrastructure.Data.Repositories
{
    /// <inheritdoc />
    public sealed class RequestInteractionRepository : Repository<RequestInteraction>, IRequestInteractionRepository
    {
        protected readonly CLTPULLContext _dbContext;
        private readonly IConfiguration _configuration;
        public RequestInteractionRepository(CLTPULLContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _configuration = configuration;
        }
        public async Task<RequestInteractionMasterDataDTO> GetRequestInteractionMasterData()
        {
            RequestInteractionMasterDataDTO requestInteractionMasterDataDTO = new RequestInteractionMasterDataDTO
            {
                InteractionAction = await _dbContext.Set<InteractionAction>().ToListAsync(),
                HelperAppOrTeam = await _dbContext.Set<HelperAppOrTeam>().ToListAsync(),
                CompanionFileType = await _dbContext.Set<CompanionFileType>().ToListAsync(),
                SourceService = await _dbContext.Set<SourceService>().ToListAsync(),
                InstancesPerFrequencyInterval = await _dbContext.Set<InstancesPerFrequencyInterval>().ToListAsync(),
                FrequencyInterval = await _dbContext.Set<FrequencyInterval>().ToListAsync(),
                InteractionMechanism = await _dbContext.Set<InteractionMechanism>().ToListAsync(),
                InteractionTriggerType = await _dbContext.Set<InteractionTriggerType>().ToListAsync(),
                ObjectDataFormat = await _dbContext.Set<ObjectDataFormat>().ToListAsync(),
                ObjectofInteraction = await _dbContext.Set<ObjectofInteraction>().ToListAsync(),
                InteractionStatus = await _dbContext.Set<InteractionStatus>().ToListAsync(),
                InteractionSpan = await _dbContext.Set<InteractionSpan>().ToListAsync(),
                InteractionReviewStatus = await _dbContext.Set<InteractionReviewStatus>().ToListAsync(),
                DestinationService = await _dbContext.Set<DestinationService>().ToListAsync(),
                NonServiceDataSource = await _dbContext.Set<NonServiceDataSource>().ToListAsync(),
                NonServiceDataDestination = await _dbContext.Set<NonServiceDataDestination>().ToListAsync()
            };

            return requestInteractionMasterDataDTO;
        }
        public List<RequestInteractionListDataDTO> GetRequestInteractionListData()
        {
            string ConnectionString = _configuration.GetConnectionString(SqlConstants.cltpullDb);
            string query = SqlConstants.vw_GetAllRequestInteractionData;
            AdoHelper.Connect(ConnectionString);
            SqlDataReader reader = AdoHelper.ExecDataReader(query);
            List<RequestInteractionListDataDTO> requestInteractionListDataDTO = new List<RequestInteractionListDataDTO>();
            RequestInteractionListDataDTO requestInteractionDataDTO = null;

            while (reader.Read())
            {
                requestInteractionDataDTO = new RequestInteractionListDataDTO
                {
                    RequestInteractionId = reader.Value<Int32>("RequestInteractionId"),
                    RequestId = reader.Value<Int32?>("RequestId"),
                    InteractionStatusId = reader.Value<Int32?>("InteractionStatusId"),
                    InteractionStatusName = reader.Value<String>("InteractionStatusName"),
                    InteractionDescription = reader.Value<String>("InteractionDescription"),

                    SourceServiceId = reader.Value<Int32?>("SourceServiceId"),
                    SourceServiceName = reader.Value<String>("SourceServiceName"),

                    DestinationServiceId = reader.Value<Int32?>("DestinationServiceId"),
                    DestinationServiceName = reader.Value<String>("DestinationServiceName"),

                    InteractionSpanId = reader.Value<Int32?>("InteractionSpanId"),
                    InteractionSpanName = reader.Value<String>("InteractionSpanName"),

                    ObjectofInteractionId = reader.Value<Int32?>("ObjectofInteractionId"),
                    ObjectofInteractionName = reader.Value<String>("ObjectofInteractionName"),

                    NotesOnObjectNaming = reader.Value<String>("NotesOnObjectNaming"),
                    IsDataFileContainsHeaderTrailerFooterRecords = reader.Value<Boolean>("IsDataFileContainsHeaderTrailerFooterRecords"),
                    CompanionFileTypeId = reader.Value<Int32?>("CompanionFileTypeId"),
                    CompanionFileTypeName = reader.Value<String>("CompanionFileTypeName"),
                    InteractionTriggerTypeId = reader.Value<Int32?>("InteractionTriggerTypeId"),
                    InteractionTriggerTypeName = reader.Value<String>("InteractionTriggerTypeName"),
                    NotesOnTrigger = reader.Value<String>("NotesOnTrigger"),
                    HelperAppOrTeamId = reader.Value<Int32?>("HelperAppOrTeamId"),
                    HelperAppOrTeamName = reader.Value<String>("HelperAppOrTeamName"),

                    EcgconfigurationId = reader.Value<String>("EcgconfigurationId"),

                    InteractionMechanismId = reader.Value<Int32?>("InteractionMechanismId"),
                    InteractionMechanismName = reader.Value<String>("InteractionMechanismName"),

                    FrequencyIntervalId = reader.Value<Int32?>("FrequencyIntervalId"),
                    FrequencyIntervalName = reader.Value<String>("FrequencyIntervalName"),

                    InstancesPerFrequencyIntervalId = reader.Value<Int32?>("InstancesPerFrequencyIntervalId"),
                    InstancesPerFrequencyIntervalName = reader.Value<String>("InstancesPerFrequencyIntervalName"),

                    DailyIntervalDays = reader.Value<String>("DailyIntervalDays"),
                    MonthlyIntervalMonths = reader.Value<String>("MonthlyIntervalMonths"),
                    IsDataSentOnUsaholidays = reader.Value<Boolean?>("IsDataSentOnUsaholidays"),
                    IsDataSentOnIndiaHolidays = reader.Value<Boolean?>("IsDataSentOnIndiaHolidays"),
                    ExpectedTransmissionStartTimeCst = reader.Value<String>("ExpectedTransmissionStartTimeCst"),
                    ExpectedMaximumTransmissionDurationInHours = reader.Value<Int32?>("ExpectedMaximumTransmissionDurationInHours"),
                    NotesOnFrequency = reader.Value<String>("NotesOnFrequency"),
                    NotesOnSourceDataCreation = reader.Value<String>("NotesOnSourceDataCreation"),
                    NotesOnDestinationDataArrivalAndValidation = reader.Value<String>("NotesOnDestinationDataArrivalAndValidation"),
                    NotesOnDestinationDataLoadingAndFinalLocation = reader.Value<String>("NotesOnDestinationDataLoadingAndFinalLocation"),
                    InteractionFailureModes = reader.Value<String>("InteractionFailureModes"),
                    NotesOnReconciliationControls = reader.Value<String>("NotesOnReconciliationControls"),
                    NotesOnTimeRelatedControls = reader.Value<String>("NotesOnTimeRelatedControls"),
                    NotesOnThresholdControls = reader.Value<String>("NotesOnThresholdControls"),
                    NotesOnOtherControls = reader.Value<String>("NotesOnOtherControls"),
                    ReferralToOtherTeams = reader.Value<String>("ReferralToOtherTeams"),
                    LastAccessedDate = reader.Value<DateTime?>("LastAccessedDate"),
                    DataContentType = reader.Value<String>("DataContentType"),
                    InteractionAction = reader.Value<String>("InteractionAction"),

                    InteractionReviewStatusId = reader.Value<Int32?>("InteractionReviewStatusId"),
                    InteractionReviewStatusName = reader.Value<String>("InteractionReviewStatusName"),

                    ObjectDataFormatId = reader.Value<Int32?>("ObjectDataFormatId"),
                    ObjectDataFormatName = reader.Value<String>("ObjectDataFormatName"),

                    NonServiceDataSourceName = reader.Value<String>("NonServiceDataSourceName"),
                    NonServiceDataDestinationName = reader.Value<String>("NonServiceDataDestinationName"),
                    CreatedBy = reader.Value<String>("CreatedBy"),
                    CreatedDate = reader.Value<DateTime?>("CreatedDate"),
                    ModifiedBy = reader.Value<String>("ModifiedBy"),
                    ModifiedDate = reader.Value<DateTime?>("ModifiedDate"),
                    IsActive = reader.Value<Boolean?>("IsActive"),
                    TableType = "RequestInteraction"
                };
                requestInteractionListDataDTO.Add(requestInteractionDataDTO);
            }
            reader.Close();
            AdoHelper.Dispose(true);
            return requestInteractionListDataDTO;
        }

        public async Task<List<RequestInteraction>> GetRequestInteractionList(int[] requestInteractionIds)
        {
            var interactionsList = await _dbContext.RequestInteraction.Where(x => requestInteractionIds.Contains(x.RequestInteractionId)).ToListAsync();
            return interactionsList;
        }

        public async Task<int[]> GetRequestInteractionForComparison(RequestInteraction requestInteraction)
        {
            var interactionsListdata = await _dbContext.RequestInteraction.AsQueryable().Where(x => x.InteractionReviewStatusId == ((int)InteractionReviewStatusEnum.Published)
                    && x.SourceServiceId == requestInteraction.SourceServiceId
                    && x.DestinationServiceId == requestInteraction.DestinationServiceId
                    && x.NonServiceDataSourceName.Equals(requestInteraction.NonServiceDataSourceName)
                    && x.NonServiceDataDestinationName.Equals(requestInteraction.NonServiceDataDestinationName)
                    && x.DataContentType.Equals(requestInteraction.DataContentType)
                    && x.FrequencyIntervalId == requestInteraction.FrequencyIntervalId
                    && x.InteractionSpanId == requestInteraction.InteractionSpanId
                    && x.InteractionMechanismId == requestInteraction.InteractionMechanismId).Select(x=>x.RequestInteractionId).ToArrayAsync();

            return interactionsListdata;
        }
    }
}
