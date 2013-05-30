namespace Domain.Mailing
{
    using Entities;
    using Interfaces;
    using Mvc.Mailer;
    using System.Net.Mail;

    public class EmailBuilder : MailerBase, IEmailBuilder
    {
        public EmailBuilder()
        {
            MasterName = "_Layout";
        }

        public MailMessage Welcome(User user)
        {
            var mailMessage = new MailMessage {Subject = "Welcome"};

            ViewBag.FirstName = user.FirstName;
            ViewBag.LastName = user.LastName;

            mailMessage.To.Add(user.Email);

            PopulateBody(mailMessage, "Welcome", null);

            return mailMessage;
        }

        public MailMessage Activation(User user, string activationToken)
        {
            var mailMessage = new MailMessage {Subject = "Activation"};
            mailMessage.To.Add(user.Email);
            ViewBag.FirstName = user.FirstName;
            ViewBag.LastName = user.LastName;
            ViewBag.ActivationToken = activationToken;
            PopulateBody(mailMessage, "Activation", null);
            return mailMessage;
        }
    }
}
