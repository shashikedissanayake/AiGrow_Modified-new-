using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AiGrow.Classes
{
    public class Mailer
    {
        /*
         * Class to send emails.
         * All the settings are either loaded from web.config or passed via the method.
         */
        public string userName { get; set; }

        public string password { get; set; }

        public string host { get; set; }

        public int port { get; set; }
        public int timeout { get; set; }

        public SmtpDeliveryMethod deliveryMethod { get; set; }

        public bool enableSsl { get; set; }

        public bool useDefaultCredentials { get; set; }
        public Mailer()
        {
            this.host = System.Configuration.ConfigurationManager.AppSettings["E-Mail Host"];
            this.port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["E-Mail Port"]);
            this.deliveryMethod = SmtpDeliveryMethod.Network;
            this.enableSsl = false;
            this.useDefaultCredentials = false;
            this.timeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["E-Mail Timeout"]);
        }

        public Mailer(string userName, string password, bool isGoogle = false)
        {
            if (isGoogle)
            {
                this.host = System.Configuration.ConfigurationManager.AppSettings["E-Mail Host Google"];
                this.port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["E-Mail Port Google"]);
                this.enableSsl = true;
            }
            else
            {
                this.host = System.Configuration.ConfigurationManager.AppSettings["E-Mail Host chargeNET"];
                this.port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["E-Mail Port chargeNET"]);
                this.enableSsl = false;
            }
            this.deliveryMethod = SmtpDeliveryMethod.Network;
            this.useDefaultCredentials = false;
            this.timeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["E-Mail Timeout"]);
            this.userName = userName;
            this.password = password;
        }

        //"sidath213@!#"
        public void sendEmail(string from, string to, string subject, string content)
        {
            try
            {
                SmtpClient client = new SmtpClient()
          {
              Port = this.port,
              Host = this.host,
              EnableSsl = this.enableSsl,
              Timeout = this.timeout,
              DeliveryMethod = this.deliveryMethod,
              UseDefaultCredentials = this.useDefaultCredentials,
              Credentials = new NetworkCredential(this.userName, this.password)
          };

                MailMessage emailMessage = new MailMessage(from, to, subject, content)
                {
                    BodyEncoding = UTF8Encoding.UTF8,
                    DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure,
                    IsBodyHtml = true
                };
                client.Send(emailMessage);
            }
            catch 
            {
                
                //throw;
            }
        }
    }
}
