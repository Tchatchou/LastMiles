namespace Infrastructure.Communication.OrangeSMS
{

    public class OutboundSMSTextMessage
    {
        public string message { get; set; }
    }

    public class OutboundSMSMessageRequest
    {
        public string address { get; set; }
        public string senderAddress { get; set; }

        public string senderName {get;set;}
        public OutboundSMSTextMessage outboundSMSTextMessage { get; set; }

       
        public string resourceURL {get;set;}  
    }

    public class SMSSendingOrange
    {
        public OutboundSMSMessageRequest outboundSMSMessageRequest { get; set; }
    }
}