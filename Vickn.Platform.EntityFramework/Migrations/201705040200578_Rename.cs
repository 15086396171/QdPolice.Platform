namespace Vickn.Platform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AbpAuditLogs", newName: "PlatformAuditLogs");
            RenameTable(name: "dbo.AbpBackgroundJobs", newName: "PlatformBackgroundJobs");
            RenameTable(name: "dbo.AbpFeatures", newName: "PlatformFeatures");
            RenameTable(name: "dbo.AbpEditions", newName: "PlatformEditions");
            RenameTable(name: "dbo.AbpLanguages", newName: "PlatformLanguages");
            RenameTable(name: "dbo.AbpLanguageTexts", newName: "PlatformLanguageTexts");
            RenameTable(name: "dbo.AbpNotifications", newName: "PlatformNotifications");
            RenameTable(name: "dbo.AbpNotificationSubscriptions", newName: "PlatformNotificationSubscriptions");
            RenameTable(name: "dbo.AbpOrganizationUnits", newName: "PlatformOrganizationUnits");
            RenameTable(name: "dbo.AbpPermissions", newName: "PlatformPermissions");
            RenameTable(name: "dbo.AbpRoles", newName: "PlatformRoles");
            RenameTable(name: "dbo.AbpUsers", newName: "PlatformUsers");
            RenameTable(name: "dbo.AbpUserClaims", newName: "PlatformUserClaims");
            RenameTable(name: "dbo.AbpUserLogins", newName: "PlatformUserLogins");
            RenameTable(name: "dbo.AbpUserRoles", newName: "PlatformUserRoles");
            RenameTable(name: "dbo.AbpSettings", newName: "PlatformSettings");
            RenameTable(name: "dbo.AbpTenantNotifications", newName: "PlatformTenantNotifications");
            RenameTable(name: "dbo.AbpTenants", newName: "PlatformTenants");
            RenameTable(name: "dbo.AbpUserAccounts", newName: "PlatformUserAccounts");
            RenameTable(name: "dbo.AbpUserLoginAttempts", newName: "PlatformUserLoginAttempts");
            RenameTable(name: "dbo.AbpUserNotifications", newName: "PlatformUserNotifications");
            RenameTable(name: "dbo.AbpUserOrganizationUnits", newName: "PlatformUserOrganizationUnits");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PlatformUserOrganizationUnits", newName: "AbpUserOrganizationUnits");
            RenameTable(name: "dbo.PlatformUserNotifications", newName: "AbpUserNotifications");
            RenameTable(name: "dbo.PlatformUserLoginAttempts", newName: "AbpUserLoginAttempts");
            RenameTable(name: "dbo.PlatformUserAccounts", newName: "AbpUserAccounts");
            RenameTable(name: "dbo.PlatformTenants", newName: "AbpTenants");
            RenameTable(name: "dbo.PlatformTenantNotifications", newName: "AbpTenantNotifications");
            RenameTable(name: "dbo.PlatformSettings", newName: "AbpSettings");
            RenameTable(name: "dbo.PlatformUserRoles", newName: "AbpUserRoles");
            RenameTable(name: "dbo.PlatformUserLogins", newName: "AbpUserLogins");
            RenameTable(name: "dbo.PlatformUserClaims", newName: "AbpUserClaims");
            RenameTable(name: "dbo.PlatformUsers", newName: "AbpUsers");
            RenameTable(name: "dbo.PlatformRoles", newName: "AbpRoles");
            RenameTable(name: "dbo.PlatformPermissions", newName: "AbpPermissions");
            RenameTable(name: "dbo.PlatformOrganizationUnits", newName: "AbpOrganizationUnits");
            RenameTable(name: "dbo.PlatformNotificationSubscriptions", newName: "AbpNotificationSubscriptions");
            RenameTable(name: "dbo.PlatformNotifications", newName: "AbpNotifications");
            RenameTable(name: "dbo.PlatformLanguageTexts", newName: "AbpLanguageTexts");
            RenameTable(name: "dbo.PlatformLanguages", newName: "AbpLanguages");
            RenameTable(name: "dbo.PlatformEditions", newName: "AbpEditions");
            RenameTable(name: "dbo.PlatformFeatures", newName: "AbpFeatures");
            RenameTable(name: "dbo.PlatformBackgroundJobs", newName: "AbpBackgroundJobs");
            RenameTable(name: "dbo.PlatformAuditLogs", newName: "AbpAuditLogs");
        }
    }
}
