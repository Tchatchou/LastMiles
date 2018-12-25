using System.Threading.Tasks;
using LastMiles.API.BusinessLogic.Communication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LastMiles.API.BusinessLogic.Communication
{
    public interface IEmail
    {        
         void sendWelcomeEmailSendgrid(string emailTo, string nameTo, WelcomeEmail welcomeemail);  

         void sendResetPassswordEmailSendgrid(string emailTo, string nameTo, WelcomeEmail welcomeemail);            
    }
}