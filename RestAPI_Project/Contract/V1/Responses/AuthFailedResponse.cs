using System.Collections.Generic;

namespace RestAPI_Project.Contract.V1.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
