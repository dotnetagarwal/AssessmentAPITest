using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints.get
{
    public class GetServicesDetailsApiRequest: BaseRequest
    {
        public string SearchText { get; set; }
    }
}
