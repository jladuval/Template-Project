namespace Domain.Mailing
{
    using Entities;

    public interface IEmailManager
    {
        void SendActivationEmail(User user, string activationToken);

        void SendWelcomeEmail(User user);
    }
}
