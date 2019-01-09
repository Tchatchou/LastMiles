using System.Threading.Tasks;



namespace Infrastructure.Communication.EmailSendgrid
{
    public interface IEmail
    {        
         void sendWelcomeEmailSendgrid(string emailTo, string nameTo, WelcomeEmail welcomeemail);  

         void sendResetPassswordEmailSendgrid(string emailTo, string nameTo, WelcomeEmail welcomeemail);            
    }
}