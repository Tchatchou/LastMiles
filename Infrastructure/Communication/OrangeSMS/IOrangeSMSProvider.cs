namespace Infrastructure.Communication.OrangeSMS
{
    public interface IOrangeSMSProvider
    {
         OrangeSMSBalance get_Balance();

         bool send_SMS(string to, string message);

    }
}