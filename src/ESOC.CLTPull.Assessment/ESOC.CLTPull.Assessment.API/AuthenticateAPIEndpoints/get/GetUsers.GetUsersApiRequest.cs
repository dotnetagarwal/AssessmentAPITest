using ESOC.CLTPull.WebApi;
using System.Collections.Generic;

namespace ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints
{
    public class GetUsersApiRequest : BaseRequest
    {
        public string SearchText { get; set; }
    }
}
