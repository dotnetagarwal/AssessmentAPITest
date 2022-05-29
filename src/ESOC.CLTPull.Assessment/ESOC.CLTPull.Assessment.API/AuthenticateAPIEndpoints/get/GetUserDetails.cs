namespace ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints
{
    using Ardalis.ApiEndpoints;
    using CloudSdk.DirectoryServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize]
    public class GetUserDetails : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<GetUserDetailsApiResponse>
    {
        [HttpGet("api/auth/verify")]
        public async override Task<ActionResult<GetUserDetailsApiResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {

            var name = Request.HttpContext.User.Identity.Name;
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest();

            name = name.Replace("MS\\", string.Empty);
            UserDetailsDto user = GetDetails(name);
            GetUserDetailsApiResponse response = new GetUserDetailsApiResponse
            {
                userDetails = user
            };

            return Ok(response.userDetails);
        }

        UserDetailsDto GetDetails(string userName)
        {
            using (CloudSdkDirectory cloudSdk = new CloudSdkDirectory())
            {
                cloudSdk.UserAttributesToLoad |= DirectoryUserAttributes.BusinessArea | DirectoryUserAttributes.Division;
                DirectoryUser singleUser = cloudSdk.GetUserByUserId(userName);

                UserDetailsDto user = new UserDetailsDto
                {
                    Name = singleUser.DisplayName,
                    Email = singleUser.Email,
                    MSID = singleUser.DomainUserId,
                    Groups = singleUser.Groups.Select(x => x.GroupName.ToUpper()).ToList()
                };

                user.Verified = user.Groups.Any(x => x.Equals("ESOC_SPIDERMAN", StringComparison.OrdinalIgnoreCase));

                return user;
            }
        }
    }
}
