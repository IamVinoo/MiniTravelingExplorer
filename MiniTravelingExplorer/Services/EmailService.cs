using System;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using MiniTravelingExplorer.Utils;
using Hangfire;
using NLog;

namespace MiniTravelingExplorer.Services
{
    public static class EmailService
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        public static bool SendEmail(MailAddress To, string Subject, string Body)
        {
            bool isMailSent;

            var mailMessage = new MailMessage()
            {

                Subject = Subject,
                Body = Body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(To);
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings[Constant.SMPTP_CLIENT_CREDENTIALS_USERNAME_KEY], Constant.ADMINISTRATOR);
            mailMessage.Sender = To;


            SmtpClient smtpClient = new SmtpClient
            {
                Host = ConfigurationManager.AppSettings[Constant.SMPTP_CLIENT_HOST_KEY],
                Port = Convert.ToInt32(ConfigurationManager.AppSettings[Constant.SMPTP_CLIENT_PORT_KEY]),
                UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings[Constant.SMPTP_CLIENT_USE_DEFAULT_CREDENTIALS_KEY]),
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings[Constant.SMPTP_CLIENT_CREDENTIALS_USERNAME_KEY], ConfigurationManager.AppSettings[Constant.SMPTP_CLIENT_CREDENTIALS_PASSWORD_KEY]),
                EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings[Constant.SMPTP_CLIENT_ENABLE_SSL_KEY])
            };

            try
            {
                smtpClient.Send(mailMessage);
                isMailSent = true;
            }
            catch (Exception exception)
            {
                isMailSent = false;

                logger.Error(exception, UtilFunction.ConcatLogMessage(exception.Message));
            }

            return isMailSent;
        }

        public static void ScheduleEmail(string address, string displayName, string subject, string body, DateTime scheduledTime)
        {
            BackgroundJob.Schedule(() => SendScheduledEmail(address, displayName, subject, body), scheduledTime);
        }

        public static void SendScheduledEmail(string address, string displayName, string subject, string body)
        {
            MailAddress mailAddress = new MailAddress(address, displayName);
            SendEmail(mailAddress, subject, body);
        }
    }
}