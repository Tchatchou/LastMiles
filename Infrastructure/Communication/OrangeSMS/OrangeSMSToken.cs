using System;

namespace Infrastructure.Communication.OrangeSMS
{
    public class OrangeSMSToken
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string expires_in { get; set; }

        public DateTime retrieve_at {get;set;}
    }
}