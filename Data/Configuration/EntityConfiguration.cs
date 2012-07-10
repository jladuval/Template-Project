namespace Data.Configuration
{
    using System.ComponentModel.DataAnnotations;

    using System.Data.Entity.ModelConfiguration;

    using Entities;

    internal class EntityConfiguration : EntityTypeConfiguration<Entity>
    {
        public EntityConfiguration()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
