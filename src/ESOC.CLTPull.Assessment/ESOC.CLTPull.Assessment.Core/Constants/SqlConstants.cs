namespace ESOC.CLTPull.Assessment.Core.Constants
{
    public class SqlConstants
    {
        public const string vw_GetAllRequestInteractionData = "SELECT * FROM Vw_GetRequestInteractionListData order by RequestInteractionId desc";
        public const string vw_GetAllRequestInteractionHistoryData = "SELECT * FROM Vw_GetRequestInteractionHistoryListData order by RequestInteractionId desc";
        public const string vw_GetAllRequestData = "SELECT * FROM vw_GetRequestListData order by RequestId desc";
        public const string cltpullDb = "CLTPULL";
    }
}
