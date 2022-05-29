using ESOC.CLTPull.Assessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.IntegrationTests.MasterData
{
    public class RequestMasterData
    {
        RequestType requestType = new RequestType();

        IList<RequestType> GetRequestTypeMasterData()
        {
            IList<RequestType> requestTypeCollection = new List<RequestType>();
            AddRequestType(requestTypeCollection, "1-Assessment & Remediation");
            AddRequestType(requestTypeCollection, "2-Tool Enhancement");
            AddRequestType(requestTypeCollection, "3-Testing or Analysis-Only");
            AddRequestType(requestTypeCollection, "4-Misc./Other");

            return requestTypeCollection;
        }

        IList<RequestState> GetRequestStateMasterData()
        {
            IList<RequestState> requestStateCollection = new List<RequestState>();
            AddRequestState(requestStateCollection, "1-Not Started");
            AddRequestState(requestStateCollection, "2-In Progress");
            AddRequestState(requestStateCollection, "3-On Hold");
            AddRequestState(requestStateCollection, "4-Completed");
            AddRequestState(requestStateCollection, "5-Canceled");

            return requestStateCollection;
        }

        IList<AssessmentStatus> GetAssessmentStatusMasterData()
        {
            IList<AssessmentStatus> assessmentStatusCollection = new List<AssessmentStatus>();
            AddAssessmentStatus(assessmentStatusCollection, "1-Tentatively planned");
            AddAssessmentStatus(assessmentStatusCollection, "2-Committed and scheduled");
            AddAssessmentStatus(assessmentStatusCollection, "3-In progress (Green)");
            AddAssessmentStatus(assessmentStatusCollection, "4-In progress (Yellow)");
            AddAssessmentStatus(assessmentStatusCollection, "5-In progress (Red)");
            AddAssessmentStatus(assessmentStatusCollection, "6-Completed");
            AddAssessmentStatus(assessmentStatusCollection, "7-Canceled");
            AddAssessmentStatus(assessmentStatusCollection, "8-On hold");

            return assessmentStatusCollection;
        }

        IList<AssessmentScope> GetAssessmentScopeMasterData()
        {
            IList<AssessmentScope> assessmentScopesCollection = new List<AssessmentScope>();
            AddAssessmentScope(assessmentScopesCollection, "1-Individual interaction(s)");
            AddAssessmentScope(assessmentScopesCollection, "2-Whole application or platform");
            AddAssessmentScope(assessmentScopesCollection, "3-Other");
            return assessmentScopesCollection;
        }

        IList<RequestChannel> GetRequestChannelMasterData()
        {
            IList<RequestChannel> requestChannelsCollection = new List<RequestChannel>();
            AddRequestChannel(requestChannelsCollection, "1-Annual Control Assessment Program");
            AddRequestChannel(requestChannelsCollection, "2-Production Incident");
            AddRequestChannel(requestChannelsCollection, "3-Normal Capital Project Impact");
            AddRequestChannel(requestChannelsCollection, "4-Special Program/Request");
            AddRequestChannel(requestChannelsCollection, "5-Initial idea / Casual mention");

            return requestChannelsCollection;
        }

        IList<RequestService> GetRequestServiceMasterData()
        {
            IList<RequestService> requestServicesCollection = new List<RequestService>();
            AddRequestService(requestServicesCollection, "A2D Analytics and Reporting", " ");
            AddRequestService(requestServicesCollection, "AB INITIO", " ");
            AddRequestService(requestServicesCollection, "BASICS - BROKER AND SALES", " ");
            AddRequestService(requestServicesCollection, "CARECORE", " ");
            AddRequestService(requestServicesCollection, "CLAIM PAYMENT SYSTEM (UMR)", " ");
            AddRequestService(requestServicesCollection, "Consumer Account Management System (CAMS)", " ");
            AddRequestService(requestServicesCollection, "UHCTS-UMR EDI Services - Gateway", " ");
            AddRequestService(requestServicesCollection, "SALES AUTOMATION MANAGER (SAM)", " ");
            AddRequestService(requestServicesCollection, "RSUITE - RENEWAL PACKAGES", " ");
            AddRequestService(requestServicesCollection, "B2B Provider Portal", " ");
            AddRequestService(requestServicesCollection, "BTB - BENEFIT TEMPLATE BUILDER", " ");
            AddRequestService(requestServicesCollection, "DOCSNET - DISABILITY OPERATIONAL CONTROL SYSTEM NETWORK", " ");
            AddRequestService(requestServicesCollection, "ENTERPRISE VOICE PORTAL (PROVIDER UHC)", " ");
            AddRequestService(requestServicesCollection, "HYPERION FINANCIAL REPORTS", " ");
            AddRequestService(requestServicesCollection, "TREASURY CHECK DATA", " ");

            return requestServicesCollection;
        }

        IList<LineOfBusiness> GetLineOfBusinessMasterData()
        {
            IList<LineOfBusiness> lineOfBusinessCollection = new List<LineOfBusiness>();
            AddLineOfBusiness(lineOfBusinessCollection, "Optum Technology");
            AddLineOfBusiness(lineOfBusinessCollection, "Shared Service-Clinical");
            AddLineOfBusiness(lineOfBusinessCollection, "Shared Service-Eligibility");
            AddLineOfBusiness(lineOfBusinessCollection, "Shared Service-Provider");
            AddLineOfBusiness(lineOfBusinessCollection, "Shared Service-CHiEF");
            AddLineOfBusiness(lineOfBusinessCollection, "PEDS");
            AddLineOfBusiness(lineOfBusinessCollection, "Polaris");
            AddLineOfBusiness(lineOfBusinessCollection, "UHC-E&I");
            AddLineOfBusiness(lineOfBusinessCollection, "UHC-M&R");
            AddLineOfBusiness(lineOfBusinessCollection, "UHC-C&S");
            AddLineOfBusiness(lineOfBusinessCollection, "UHC-M&V");
            AddLineOfBusiness(lineOfBusinessCollection, "UHC-Other");
            AddLineOfBusiness(lineOfBusinessCollection, "UHG Corporate");
            AddLineOfBusiness(lineOfBusinessCollection, "OptumHealth/CSG");
            AddLineOfBusiness(lineOfBusinessCollection, "Optum-Other");
            return lineOfBusinessCollection;
        }
        private static void AddRequestType(IList<RequestType> requestTypeCollection, string requestTypeName)
        {
            RequestType requestType = new RequestType
            {
                RequestTypeName = requestTypeName
            };
            requestTypeCollection.Add(requestType);
        }
        private static void AddRequestState(IList<RequestState> requestStateCollection, string requestStateName)
        {
            RequestState requestState = new RequestState
            {
                RequestStateName = requestStateName
            };
            requestStateCollection.Add(requestState);
        }
        private static void AddAssessmentStatus(IList<AssessmentStatus> assessmentStatusCollection, string assessmentStatusName)
        {
            AssessmentStatus assessmentStatus = new AssessmentStatus
            {
                AssessmentStatusName = assessmentStatusName
            };
            assessmentStatusCollection.Add(assessmentStatus);
        }

        private static void AddAssessmentScope(IList<AssessmentScope> assessmentScopesCollection, string assessmentScopeName)
        {
            AssessmentScope assessmentScope = new AssessmentScope
            {
                AssessmentScopeName = assessmentScopeName
            };
            assessmentScopesCollection.Add(assessmentScope);
        }


        private static void AddRequestChannel(IList<RequestChannel> requestChannelsCollection, string requestChannelName)
        {
            RequestChannel requestChannel = new RequestChannel
            {
                RequestChannelName = requestChannelName
            };
            requestChannelsCollection.Add(requestChannel);
        }

        private static void AddRequestService(IList<RequestService> requestServicesCollection, string requestServiceName, string requestServiceSlo)
        {
            RequestService requestService = new RequestService()
            {
                RequestServiceName = requestServiceName
                //RequestServiceSlo = requestServiceSlo
            };
            requestServicesCollection.Add(requestService);
        }

        private static void AddLineOfBusiness(IList<LineOfBusiness> lineOfBusinessesCollection, string lineOfBusinessName)
        {
            LineOfBusiness lineOfBusiness = new LineOfBusiness
            {
                LineOfBusinessName = lineOfBusinessName
            };
            lineOfBusinessesCollection.Add(lineOfBusiness);
        }
    }
}
