using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESOC.CLTPull.Assessment.API.AuthenticateAPIEndpoints
{
    public class UserDetailsDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MSID { get; set; }
        public List<string> Groups { get; set; }
        public Boolean Verified { get; set; }
    }
}
