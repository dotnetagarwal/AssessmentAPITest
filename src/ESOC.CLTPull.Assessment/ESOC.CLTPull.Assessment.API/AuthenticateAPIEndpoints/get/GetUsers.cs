namespace ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints
{
    using Ardalis.ApiEndpoints;
    using CloudSdk.DirectoryServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize]
    public class GetUsers : BaseAsyncEndpoint
        .WithRequest<GetUsersApiRequest>
        .WithResponse<GetUsersApiResponse>
    {
        [HttpGet("api/users/{searchText}")]
        [SwaggerOperation(
            Summary = "Get display user names",
            Description = "Gets users based on search text",
            OperationId = "users.GetUsers",
            Tags = new[] { "UserWorkItemEndpoints" })
        ]
        public async override Task<ActionResult<GetUsersApiResponse>> HandleAsync([FromRoute] GetUsersApiRequest request, CancellationToken cancellationToken = default)
        {
            GetUsersApiResponse response = new GetUsersApiResponse();
            
            response.UserDetail = GetNames(request.SearchText);
            return Ok(response.UserDetail);
        }



        List<OptumUserDetail> GetNames(string searchText)
        {
            using (CloudSdkDirectory cloudSdk = new CloudSdkDirectory())
            {
                List<OptumUserDetail> optumUserDetails = null;
                cloudSdk.UserAttributesToLoad |= DirectoryUserAttributes.BusinessArea | DirectoryUserAttributes.Division;
                optumUserDetails = cloudSdk.GetUsersByName(null, searchText, null)?.Select(m => new OptumUserDetail { OptumUserName = m.DisplayName }).ToList(); //Use SearchText for FirstName
                optumUserDetails ??= new List<OptumUserDetail>();
                var serachByFirstName = cloudSdk.GetUsersByName(searchText, null, null)?.Select(m => new OptumUserDetail { OptumUserName = m.DisplayName }).ToList();
                if (serachByFirstName != null)
                    optumUserDetails.AddRange(serachByFirstName);
               
                return optumUserDetails;
            }
        }
    }
}
