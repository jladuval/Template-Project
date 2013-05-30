namespace Entities
{
    using System;
    using System.Collections.Generic;

    public class Role
    {
        public Guid Id { get; set; }

        public String RoleName { get; set; }

        public String Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
