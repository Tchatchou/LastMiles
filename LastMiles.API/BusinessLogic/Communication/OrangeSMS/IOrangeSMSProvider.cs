namespace LastMiles.API.BusinessLogic.Communication
{
    public interface IOrangeSMSProvider
    {
         OrangeSMSBalance get_Balance();

         bool send_SMS(string to, string message);

    }
}