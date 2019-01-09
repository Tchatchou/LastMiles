using System.Net;
using System.Text;
using System.Web;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Communication.OrangeSMS
{
    public class OrangeSMSProvider : IOrangeSMSProvider
    {

        private readonly IConfiguration _Config;
        private IMemoryCache _memoryCache;
        private readonly ILogger<OrangeSMSProvider> _logger;

        public OrangeSMSProvider(IConfiguration config, IMemoryCache memoryCache, ILogger<OrangeSMSProvider> logger)
        {
            _Config = config;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public OrangeSMSBalance get_Balance()
        {

            try
            {

                var balance = "https://api.orange.com/sms/admin/v1/contracts"
                                .WithOAuthBearerToken(get_Token())
                                .GetAsync()
                                .ReceiveJson<OrangeSMSBalance>().Result;

                    _logger.LogInformation("Orange sms balance :" + balance.partnerContracts.contracts[0].serviceContracts[0].availableUnits);
                    
                return balance;
            }
            catch (FlurlHttpException ex)
            {
                // ex.Message contains rich details, inclulding the URL, verb, response status,
                // and request and response bodies (if available)
                _logger.LogError("Orange SMS token fail" + ex.Message);
            }

             return null;
        }

        private string get_Token()
        {
            // check token in store if old get a new one store and sendback else send the current token
        
            var tokenStore = _memoryCache.Get<OrangeSMSToken>("orangeSmsToken");

            if (tokenStore == null )
            {

            try{
                        var Authorization = _Config.GetSection("OrangeSMSAuthorizationHeader:header").Value;

                        var new_token= "https://api.orange.com/oauth/v2/token"
                                        .WithHeaders(new { Authorization = Authorization,
                                                            Content_Type = "application/x-www-form-urlencoded" })
                                        .PostUrlEncodedAsync(new {grant_type = "client_credentials"})
                                        .ReceiveJson<OrangeSMSToken>().Result;
                                        
                        MemoryCacheEntryOptions options =new MemoryCacheEntryOptions();
                        options.AbsoluteExpiration = DateTime.Now.AddDays(26); // cache object to be automatically remove after 26 days
                        options.SlidingExpiration = TimeSpan.FromDays(26); //cache object to be remove after 26 days being idle
                        
                        new_token.retrieve_at = DateTime.Now;

                        _memoryCache.Set<OrangeSMSToken>("orangeSmsToken", new_token, options);
                        
                    return new_token.access_token;
                }
                catch (FlurlHttpException ex) {
                    // ex.Message contains rich details, inclulding the URL, verb, response status,
                    // and request and response bodies (if available)
                    _logger.LogError("Fail to get token from orange" + ex.Message);
                }
              
            }

            return tokenStore.access_token;
        }

        public bool send_SMS(string to, string message)
        {

         try{
            var sms = "https://api.orange.com/smsmessaging/v1/outbound/tel%3A%2B237690664965/requests"
              .WithHeaders(new { Authorization = "Bearer " + get_Token(), Content_Type = "application/json" })
              .PostJsonAsync(new
              {
                  outboundSMSMessageRequest = new OutboundSMSMessageRequest()
                  {
                      address = "tel:+237" + to,
                      senderAddress = "tel:+237690664965",
                      senderName = "Nicanor",
                      outboundSMSTextMessage = new OutboundSMSTextMessage()
                      {
                          message = message
                      }
                  }
              })
              .ReceiveString().Result;

                _logger.LogInformation("Orange sms should have been sent to  :" + to);
                  
               return true;
            }
            catch (FlurlHttpException ex) {
                    // ex.Message contains rich details, inclulding the URL, verb, response status,
                    // and request and response bodies (if available)
                    
                    
                    _logger.LogError("Fail to send sms via orange" + ex.Message);
                }
              
            return false;
        }
    }
}