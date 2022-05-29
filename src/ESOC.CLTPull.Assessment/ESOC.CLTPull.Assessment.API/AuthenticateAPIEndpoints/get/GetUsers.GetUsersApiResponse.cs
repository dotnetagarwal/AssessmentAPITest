using ESOC.CLTPull.WebApi;
using System.Collections.Generic;

namespace ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints
{
    public class GetUsersApiResponse : BaseResponse
    {
        public List<OptumUserDetail> UserDetail { get; set; }
    }
}
