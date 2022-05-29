using ESOC.CLTPull.Assessment.Core.Entities.DTOs;
using ESOC.CLTPull.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints.get
{
    public class GetServicesDetailsApiResponse: BaseResponse
    {
        public List<ServiceDetails> ServicesDetail { get; set; }
    }
}
