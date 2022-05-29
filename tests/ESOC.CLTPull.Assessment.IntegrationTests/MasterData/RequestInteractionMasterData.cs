using ESOC.CLTPull.Assessment.Core.Entities;
using System.Collections.Generic;

namespace ESOC.CLTPull.Assessment.IntegrationTests.MasterData
{
    public class RequestInteractionMasterData
    {
        internal IList<FrequencyInterval> GetFrequencyIntervalMasterData()
        {
            IList<FrequencyInterval> frequencyIntervalCollection = new List<FrequencyInterval>();
            AddFrequencyInterval(frequencyIntervalCollection, "Daily"); 
            AddFrequencyInterval(frequencyIntervalCollection, "Weekly");
            AddFrequencyInterval(frequencyIntervalCollection, "Every other week");
            AddFrequencyInterval(frequencyIntervalCollection, "Monthly");
            return frequencyIntervalCollection;
        }

        internal IList<InstancesPerFrequencyInterval> GetInstancesPerFrequencyIntervalMasterData()
        {
            IList<InstancesPerFrequencyInterval> requestInstancesPerFrequencyIntervalCollection = new List<InstancesPerFrequencyInterval>();
            AddInstancesPerFrequencyInterval(requestInstancesPerFrequencyIntervalCollection, "One time");
            AddInstancesPerFrequencyInterval(requestInstancesPerFrequencyIntervalCollection, "Two time");
            AddInstancesPerFrequencyInterval(requestInstancesPerFrequencyIntervalCollection, "Multiple times");
            return requestInstancesPerFrequencyIntervalCollection;
        }
        internal IList<InteractionAction> GetInteractionAction()
        {
            IList<InteractionAction> interactionActionCollection = new List<InteractionAction>();
            AddInteractionAction(interactionActionCollection, "Extraction/Creation/Packaging");
            AddInteractionAction(interactionActionCollection, "Transmission");
            AddInteractionAction(interactionActionCollection, "Receipt/Acknowledgment");
            AddInteractionAction(interactionActionCollection, "Validation");
            AddInteractionAction(interactionActionCollection, "Transformation/Processing");
            AddInteractionAction(interactionActionCollection, "Transformation/Processing");
            AddInteractionAction(interactionActionCollection, "Loading/Archiving");
            AddInteractionAction(interactionActionCollection, "Other");
            return interactionActionCollection;
        }
        internal IList<HelperAppOrTeam> GetHelperAppOrTeam()
        {
            IList<HelperAppOrTeam> helperAppOrTeamCollection = new List<HelperAppOrTeam>();
            AddHelperAppOrTeam(helperAppOrTeamCollection, "None (Direct)");
            AddHelperAppOrTeam(helperAppOrTeamCollection, "ECG");
            AddHelperAppOrTeam(helperAppOrTeamCollection, "UPM");
            AddHelperAppOrTeam(helperAppOrTeamCollection, "Optum DFM");
            return helperAppOrTeamCollection;
        }

        internal IList<CompanionFileType> GetCompanionFileDetails()
        {
            IList<CompanionFileType> companionFileTypeCollection = new List<CompanionFileType>();
            AddCompanionFileType(companionFileTypeCollection, "No");
            AddCompanionFileType(companionFileTypeCollection, "Yes - Control or audit file");
            AddCompanionFileType(companionFileTypeCollection, "Yes - Trigger file");
            AddCompanionFileType(companionFileTypeCollection, "Yes - Other companion file");
            return companionFileTypeCollection;
        }
        internal IList<SourceService> GetSourceService()
        {
            IList<SourceService> sourceServiceCollection = new List<SourceService>();
            AddSourceService(sourceServiceCollection, "A2D Analytics and Reporting");
            AddSourceService(sourceServiceCollection, "AB INITIO");
            AddSourceService(sourceServiceCollection, "BASICS - BROKER AND SALES");
            AddSourceService(sourceServiceCollection, "CARECORE");
            AddSourceService(sourceServiceCollection, "CLAIM PAYMENT SYSTEM (UMR)");
            AddSourceService(sourceServiceCollection, "Consumer Account Management System (CAMS)");
            AddSourceService(sourceServiceCollection, "UHCTS-UMR EDI Services - Gateway");
            AddSourceService(sourceServiceCollection, "SALES AUTOMATION MANAGER (SAM)");
            AddSourceService(sourceServiceCollection, "RSUITE - RENEWAL PACKAGES");
            AddSourceService(sourceServiceCollection, "B2B Provider Portal");
            AddSourceService(sourceServiceCollection, "BTB - BENEFIT TEMPLATE BUILDER");
            AddSourceService(sourceServiceCollection, "DOCSNET - DISABILITY OPERATIONAL CONTROL SYSTEM NETWORK");
            AddSourceService(sourceServiceCollection, "ENTERPRISE VOICE PORTAL (PROVIDER UHC)");
            AddSourceService(sourceServiceCollection, "HYPERION FINANCIAL REPORTS");
            AddSourceService(sourceServiceCollection, "TREASURY CHECK DATA");
            return sourceServiceCollection;
        }
        internal IList<InteractionMechanism> GetInteractionMechanism()
        {
            IList<InteractionMechanism> interactionMechanismCollection = new List<InteractionMechanism>();
            AddInteractionMechanism(interactionMechanismCollection, "File transfer tool (FTP, CFT, etc.)");
            AddInteractionMechanism(interactionMechanismCollection, "Messaging platform(MQ, Kafka, etc.)");
            AddInteractionMechanism(interactionMechanismCollection, "Web Service/ API");
            AddInteractionMechanism(interactionMechanismCollection, "Internal operating system copy");
            AddInteractionMechanism(interactionMechanismCollection, "Database / SQL action(via ODBC, JDBC, etc.)");
            AddInteractionMechanism(interactionMechanismCollection, "ETL product(DataStage, etc.)");
            return interactionMechanismCollection;

        }
        internal IList<InteractionTriggerType> GetInteractionTriggerType()
        {
            IList<InteractionTriggerType> interactionTriggerTypeCollection = new List<InteractionTriggerType>();
            AddInteractionTriggerType(interactionTriggerTypeCollection, "No");
            AddInteractionTriggerType(interactionTriggerTypeCollection, "Yes - Control or audit file");
            AddInteractionTriggerType(interactionTriggerTypeCollection, "Yes - Trigger file");
            AddInteractionTriggerType(interactionTriggerTypeCollection, "Yes - Other companion file");
            return interactionTriggerTypeCollection;
        }
        internal IList<ObjectDataFormat> GetObjectDataFormat()
        {
            IList<ObjectDataFormat> objectDataFormatCollection = new List<ObjectDataFormat>();
            AddObjectDataFormat(objectDataFormatCollection, "XML or HTML");
            AddObjectDataFormat(objectDataFormatCollection, "Delimited");
            AddObjectDataFormat(objectDataFormatCollection, "Fixed - length");
            AddObjectDataFormat(objectDataFormatCollection, "EDI(837, etc.)");
            AddObjectDataFormat(objectDataFormatCollection, "MS Office"); 
            AddObjectDataFormat(objectDataFormatCollection, "Other");
            return objectDataFormatCollection;
        }
        internal IList<ObjectofInteraction> GetObjectofInteraction()
        {
            IList<ObjectofInteraction> objectofInteractionCollection = new List<ObjectofInteraction>();
            AddObjectofInteraction(objectofInteractionCollection, "File (main data file and any control/trigger files)");
            AddObjectofInteraction(objectofInteractionCollection, "Transaction / Message");
            AddObjectofInteraction(objectofInteractionCollection, "Other");
            return objectofInteractionCollection;
        }
        internal IList<InteractionStatus> GetInteractionStatus()
        {
            IList<InteractionStatus> interactionStatusCollection = new List<InteractionStatus>();
            AddInteractionStatus(interactionStatusCollection, "1-In production / Active");
            AddInteractionStatus(interactionStatusCollection, "2-Not in production yet");
            AddInteractionStatus(interactionStatusCollection, "3-Retired");
            return interactionStatusCollection;
        }
        internal IList<InteractionSpan> GetInteractionSpan()
        {
            IList<InteractionSpan> interactionSpanCollection = new List<InteractionSpan>();
            AddInteractionSpan(interactionSpanCollection, "Nearest neighbor");
            AddInteractionSpan(interactionSpanCollection, "End-to-end");
            return interactionSpanCollection;
        }
        internal IList<InteractionReviewStatus> GetInteractionReviewStatus()
        {
            IList<InteractionReviewStatus> interactionReviewStatusCollection = new List<InteractionReviewStatus>();
            AddInteractionReviewStatus(interactionReviewStatusCollection, "Not Started");
            AddInteractionReviewStatus(interactionReviewStatusCollection, "In Progress");
            AddInteractionReviewStatus(interactionReviewStatusCollection, "Internal Review In Progress");
            AddInteractionReviewStatus(interactionReviewStatusCollection, "Review with Customer In Progress");
            AddInteractionReviewStatus(interactionReviewStatusCollection, "Published");
            AddInteractionReviewStatus(interactionReviewStatusCollection, "Cancelled");
            return interactionReviewStatusCollection;
        }
        internal IList<DestinationService> GetDestinationService()
        {
            IList<DestinationService> destinationServiceCollection = new List<DestinationService>();
            AddDestinationService(destinationServiceCollection, "A2D Analytics and Reporting");
            AddDestinationService(destinationServiceCollection, "AB INITIO");
            AddDestinationService(destinationServiceCollection, "BASICS - BROKER AND SALES");
            AddDestinationService(destinationServiceCollection, "CARECORE");
            AddDestinationService(destinationServiceCollection, "CLAIM PAYMENT SYSTEM (UMR)");
            AddDestinationService(destinationServiceCollection, "Consumer Account Management System (CAMS)");
            AddDestinationService(destinationServiceCollection, "UHCTS-UMR EDI Services - Gateway");
            AddDestinationService(destinationServiceCollection, "SALES AUTOMATION MANAGER (SAM)");
            AddDestinationService(destinationServiceCollection, "RSUITE - RENEWAL PACKAGES");
            AddDestinationService(destinationServiceCollection, "B2B Provider Portal");            
            return destinationServiceCollection;
        }
        internal IList<NonServiceDataSource> GetNonServiceDataSource()
        {
            IList<NonServiceDataSource> nonServiceDataSourceCollection = new List<NonServiceDataSource>();
            AddNonServiceDataSource(nonServiceDataSourceCollection, "DHub");
            AddNonServiceDataSource(nonServiceDataSourceCollection, "DataStaging (Standard Tables)");
            AddNonServiceDataSource(nonServiceDataSourceCollection, "DataStaging (Landing Tables)");
            AddNonServiceDataSource(nonServiceDataSourceCollection, "Application A");
            AddNonServiceDataSource(nonServiceDataSourceCollection, "CareServices IMDB");
            AddNonServiceDataSource(nonServiceDataSourceCollection, "WELLNESS PREVENTION INTERVENTION SERVICES");
            AddNonServiceDataSource(nonServiceDataSourceCollection, "Pre - HouseCalls CS_IM DB");
            
            return nonServiceDataSourceCollection;
        }
        internal IList<NonServiceDataDestination> GetNonServiceDataDestination()
        {
            IList<NonServiceDataDestination> nonServiceDataDestinationCollection = new List<NonServiceDataDestination>();
            AddNonServiceDataDestination(nonServiceDataDestinationCollection, "Pre/Post Housecalls");
            AddNonServiceDataDestination(nonServiceDataDestinationCollection, "3RDD");
            AddNonServiceDataDestination(nonServiceDataDestinationCollection, "AE");
            AddNonServiceDataDestination(nonServiceDataDestinationCollection, "AHN");
            AddNonServiceDataDestination(nonServiceDataDestinationCollection, "ALLWAYS - Neighborhood of Massasuetts ");
            AddNonServiceDataDestination(nonServiceDataDestinationCollection, "CDB Search and CDB history");
            return nonServiceDataDestinationCollection;
        }

        internal IList<EsocaideData> GetESOCAideServiceData()
        {
            IList<EsocaideData> esocaideDataCollection = new List<EsocaideData>();
            AddEsocAideServiceData(esocaideDataCollection, "Pre/Post Housecalls");
            AddEsocAideServiceData(esocaideDataCollection, "3RDD");
            AddEsocAideServiceData(esocaideDataCollection, "AE");
            AddEsocAideServiceData(esocaideDataCollection, "AHN");
            AddEsocAideServiceData(esocaideDataCollection, "ALLWAYS - Neighborhood of Massasuetts ");
            AddEsocAideServiceData(esocaideDataCollection, "CDB Search and CDB history");
            return esocaideDataCollection;
        }

        private static void AddFrequencyInterval(IList<FrequencyInterval> frequencyIntervalCollection, string frequencyIntervalName)
        {
            FrequencyInterval frequencyInterval = new FrequencyInterval
            {
                FrequencyIntervalName = frequencyIntervalName
            };
            frequencyIntervalCollection.Add(frequencyInterval);
        }
        private static void AddInstancesPerFrequencyInterval(IList<InstancesPerFrequencyInterval> requestInstancesPerFrequencyIntervalCollection, string requestInstancesPerFrequencyIntervalName)
        {
            InstancesPerFrequencyInterval requestInstancesPerFrequencyInterval = new InstancesPerFrequencyInterval
            {
                InstancesPerFrequencyIntervalName = requestInstancesPerFrequencyIntervalName
            };
            requestInstancesPerFrequencyIntervalCollection.Add(requestInstancesPerFrequencyInterval);
        }
        private static void AddInteractionAction(IList<InteractionAction> interactionActionCollection, string interactionActionName)
        {
            InteractionAction interactionAction = new InteractionAction
            {
                InteractionActionName = interactionActionName
            };
            interactionActionCollection.Add(interactionAction);
        }
        private static void AddHelperAppOrTeam(IList<HelperAppOrTeam> helperAppOrTeamCollection, string helperAppOrTeamName)
        {
            HelperAppOrTeam helperAppOrTeam = new HelperAppOrTeam
            {
                HelperAppOrTeamName = helperAppOrTeamName
            };
            helperAppOrTeamCollection.Add(helperAppOrTeam);
        }
        private static void AddCompanionFileType(IList<CompanionFileType> companionFileTypeCollection, string companionFileTypeName)
        {
            CompanionFileType companionFileDetail = new CompanionFileType
            {
                CompanionFileTypeName = companionFileTypeName
            };
            companionFileTypeCollection.Add(companionFileDetail);
        }
        private static void AddSourceService(IList<SourceService> sourceServiceCollection, string sourceServiceName)
        {
            SourceService sourceService = new SourceService
            {
                SourceServiceName = sourceServiceName
            };
            sourceServiceCollection.Add(sourceService);
        }
        private static void AddInteractionMechanism(IList<InteractionMechanism> interactionMechanismCollection, string interactionMechanismName)
        {
            InteractionMechanism interactionMechanism = new InteractionMechanism
            {
                InteractionMechanismName = interactionMechanismName
            };
            interactionMechanismCollection.Add(interactionMechanism);
        }
        private static void AddInteractionTriggerType(IList<InteractionTriggerType> interactionTriggerTypeCollection, string interactionTriggerTypeName)
        {
            InteractionTriggerType interactionTriggerType = new InteractionTriggerType
            {
                InteractionTriggerTypeName = interactionTriggerTypeName
            };
            interactionTriggerTypeCollection.Add(interactionTriggerType);
        }
        private static void AddObjectDataFormat(IList<ObjectDataFormat> objectDataFormatCollection, string objectDataFormatName)
        {
            ObjectDataFormat objectDataFormat = new ObjectDataFormat
            {
                ObjectDataFormatName = objectDataFormatName
            };
            objectDataFormatCollection.Add(objectDataFormat);
        }
        private static void AddObjectofInteraction(IList<ObjectofInteraction> objectofInteractionCollection, string objectofInteractionName)
        {
            ObjectofInteraction objectofInteraction = new ObjectofInteraction
            {
                ObjectofInteractionName = objectofInteractionName
            };
            objectofInteractionCollection.Add(objectofInteraction);
        }
        private static void AddInteractionStatus(IList<InteractionStatus> interactionStatusCollection, string interactionStatusName)
        {
            InteractionStatus interactionStatus = new InteractionStatus
            {
                InteractionStatusName = interactionStatusName
            };
            interactionStatusCollection.Add(interactionStatus);
        }
        private static void AddInteractionSpan(IList<InteractionSpan> interactionSpanCollection, string interactionSpanName)
        {
            InteractionSpan interactionSpan = new InteractionSpan
            {
                InteractionSpanName = interactionSpanName
            };
            interactionSpanCollection.Add(interactionSpan);
        }
        private static void AddInteractionReviewStatus(IList<InteractionReviewStatus> interactionReviewStatusCollection, string interactionReviewStatusName)
        {
            InteractionReviewStatus interactionReviewStatus = new InteractionReviewStatus
            {
                InteractionReviewStatusName = interactionReviewStatusName
            };
            interactionReviewStatusCollection.Add(interactionReviewStatus);
        }
        private static void AddDestinationService(IList<DestinationService> destinationServiceCollection, string destinationServiceName)
        {
            DestinationService destinationService = new DestinationService
            {
                DestinationServiceName = destinationServiceName
            };
            destinationServiceCollection.Add(destinationService);
        }
        private static void AddNonServiceDataSource(IList<NonServiceDataSource> nonServiceDataSourceCollection, string nonServiceDataSourceName)
        {
            NonServiceDataSource nonServiceDataSource = new NonServiceDataSource
            {
                NonServiceDataSourceName = nonServiceDataSourceName
            };
            nonServiceDataSourceCollection.Add(nonServiceDataSource);
        }
        private static void AddNonServiceDataDestination(IList<NonServiceDataDestination> nonServiceDataDestinationCollection, string nonServiceDataDestinationName)
        {
            NonServiceDataDestination nonServiceDataDestination = new NonServiceDataDestination
            {
                NonServiceDataDestinationName = nonServiceDataDestinationName
            };
            nonServiceDataDestinationCollection.Add(nonServiceDataDestination);
        }

        private static void AddEsocAideServiceData(IList<EsocaideData> esocaideDataCollection, string esocaideDataName)
        {
            EsocaideData esocaideData = new EsocaideData
            {
                EsocaliasNames= esocaideDataName
            };
            esocaideDataCollection.Add(esocaideData);
        }
    }
}
