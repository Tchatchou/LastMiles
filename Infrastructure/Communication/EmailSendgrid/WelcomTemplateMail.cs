using System.Collections.Generic;

namespace Infrastructure.Communication.EmailSendgrid
{
    
    public class To
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class From
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class ReplyTo
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class DynamicTemplateData
    {
        public string subject {get;set;}
        public WelcomeEmail welcomeEmail { get; set; }
    }

    public class Personalization
    {
        public List<To> to { get; set; }

       
        public DynamicTemplateData dynamic_template_data { get; set; }
    }

    public class WelcomeEmail
{
    public string name { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string customerServiceEmail { get; set; }
    public string customerServiceNumber { get; set; }
}
    public class WelcomTemplateMail
    {
        public List<Personalization> personalizations { get; set; }
        public From from { get; set; }
        public ReplyTo reply_to { get; set; }
        public string template_id { get; set; }

    }


}