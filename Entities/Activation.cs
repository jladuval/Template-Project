namespace Entities
{
    using System;

    public class Activation
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public string ConfirmationToken { get; set; }

        public DateTime? ActivatedDate { get; set; }
    }
}
