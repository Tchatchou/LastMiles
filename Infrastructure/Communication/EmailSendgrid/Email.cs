using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using Flurl.Http;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using RestSharp;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.Communication.EmailSendgrid
{
    public class Email : IEmail
    {
       
        private readonly IConfiguration _config;      
        private readonly ILogger<Email> _logger;
       public Email(IConfiguration config, ILogger<Email> logger)
       {
            _config = config;
            _logger = logger;
        }

        public void sendResetPassswordEmailSendgrid(string emailTo, string nameTo, WelcomeEmail welcomeemail)
        {
            
            var email = new WelcomTemplateMail();

            email.from = new From()
            {

                email = "jonathan.nicanor@gmail.com",
                name = "Jonathan"
            };

            email.reply_to = new ReplyTo()
            {
                email = "jonathan.nicanor@gmail.com",
                name = "Jonathan"
            };

            var listTo = new List<To>();

            listTo.Add(new To { email = emailTo, name = nameTo });

        //    email.subject = "Bienvenu sur Delivery platforme de distribution";//obselet for template because it is set in template itself

            var listPersonalisation = new List<Personalization>();

            listPersonalisation.Add(new Personalization
            {
                to = listTo,
               
                dynamic_template_data = new DynamicTemplateData(){
                    subject ="Reconfiguration de votre mot de passe",
                    welcomeEmail = welcomeemail
                }

            });

            email.personalizations = listPersonalisation;

            email.template_id = _config.GetSection("Sendgrid:templatePasswordReset").Value;

        try{
            var mail ="https://api.sendgrid.com/v3/mail/send"
                      .WithHeaders(new
                      {
                          Authorization = "Bearer "+ _config.GetSection("Sendgrid:key").Value,
                          Content_Type = "application/json"
                      })
                      .PostJsonAsync(email)
                      .ReceiveString().Result;

                _logger.LogInformation("email sent");
            }
         catch (FlurlHttpException ex)
            {
                // ex.Message contains rich details, inclulding the URL, verb, response status,
                // and request and response bodies (if available)
                _logger.LogError("Fail to send mail" + ex.Message);
            }
        }

        public  void sendWelcomeEmailSendgrid(string emailTo, string nameTo, WelcomeEmail welcomeemail)     
        {


            var email = new WelcomTemplateMail();

            email.from = new From()
            {

                email = "jonathan.nicanor@gmail.com",
                name = "Jonathan"
            };

            email.reply_to = new ReplyTo()
            {
                email = "jonathan.nicanor@gmail.com",
                name = "Jonathan"
            };

            var listTo = new List<To>();

            listTo.Add(new To { email = emailTo, name = nameTo });
         
            var listPersonalisation = new List<Personalization>();

            listPersonalisation.Add(new Personalization
            {
                to = listTo,
               
                dynamic_template_data = new DynamicTemplateData(){
                    subject ="Bienvenu sur Delivery platforme de distribution",
                    welcomeEmail = welcomeemail
                }

            });

            email.personalizations = listPersonalisation;

            email.template_id = _config.GetSection("Sendgrid:templateWelcome").Value;

        try{
            var mail ="https://api.sendgrid.com/v3/mail/send"
                      .WithHeaders(new
                      {
                          Authorization = "Bearer "+ _config.GetSection("Sendgrid:key").Value,
                          Content_Type = "application/json"
                      })
                      .PostJsonAsync(email)
                      .ReceiveString().Result;

                _logger.LogInformation("email sent");
            }
         catch (FlurlHttpException ex)
            {
                // ex.Message contains rich details, inclulding the URL, verb, response status,
                // and request and response bodies (if available)
                _logger.LogError("Fail to get token from orange" + ex.Message);
            }
    }
    }
}