namespace Data.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Activations",
                c => new
                    {
                        Id = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
                        UserId = c.Guid(nullable: false),
                        ConfirmationToken = c.String(maxLength: 128),
                        ActivatedDate = c.DateTime(storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SiteRegistrations",
                c => new
                    {
                        Id = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
                        Password = c.String(maxLength: 128),
                        LastPasswordChangedDate = c.DateTime(nullable: false, storeType: "datetime2"),
                        IsLockedOut = c.Boolean(nullable: false),
                        LastLockoutDate = c.DateTime(storeType: "datetime2"),
                        FailedPasswordAttemptCount = c.Int(nullable: false),
                        LastFailedPasswordAttemptDate = c.DateTime(storeType: "datetime2"),
                        FailedPasswordAttemptWindowStart = c.DateTime(storeType: "datetime2"),
                        PasswordResetToken = c.String(maxLength: 128),
                        PasswordResetTokenExpiredDate = c.DateTime(storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UsersInRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.SiteRegistrations", new[] { "Id" });
            DropIndex("dbo.Activations", new[] { "UserId" });
            DropForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UsersInRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.SiteRegistrations", "Id", "dbo.Users");
            DropForeignKey("dbo.Activations", "UserId", "dbo.Users");
            DropTable("dbo.UsersInRoles");
            DropTable("dbo.SiteRegistrations");
            DropTable("dbo.Activations");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
        }
    }
}
