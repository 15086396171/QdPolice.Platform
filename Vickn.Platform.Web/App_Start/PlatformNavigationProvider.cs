using Abp.Application.Navigation;
using Abp.Localization;
using Vickn.Platform.Announcements.Authorization;
using Vickn.Platform.Attendances.KqMachines;
using Vickn.Platform.Attendances.KqMachines.Authorization;
using Vickn.Platform.Attendances.KqShifts.Authorization;
using Vickn.Platform.AuditLogs.Authorization;
using Vickn.Platform.Authorization;
using Vickn.Platform.Authorization.Roles.Authorization;
using Vickn.Platform.DataDictionaries.Authorization;
using Vickn.Platform.HandheldTerminals.AppWhiteLists.Authorization;
using Vickn.Platform.HandheldTerminals.Devices.Authorization;
using Vickn.Platform.OrganizationUnits.Authorization;
using Vickn.Platform.Users.Authorization;

namespace Vickn.Platform.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class PlatformNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            //考勤管理（一级菜单）
            var attendance = new MenuItemDefinition(
                AppPermissions.Pages_AttendanceManage,
                L(AppPermissions.Pages_AttendanceManage),
                icon: "icon-grid"
                );

            //考勤班次（二级菜单）
            var kqshift = new MenuItemDefinition(KqShiftAppPermissions.KqShift, L("KqShift"),
                url: "KqShifts/KqShift",
                icon: "icon-grid",
                requiredPermissionName: KqShiftAppPermissions.KqShift);

            //考勤机信息（二级菜单）
            var kqmachine = new MenuItemDefinition(KqMachineAppPermissions.KqMachine, L("KqMachine"),
            url: "KqMachines/KqMachine",
                icon: "icon-grid",
            requiredPermissionName: KqMachineAppPermissions.KqMachine);


            //考勤管理增加二级菜单
            attendance.AddItem(kqshift) //考勤班次
                      .AddItem(kqmachine);//考勤机信息


            //手持终端管理（一级菜单）
            var device = new MenuItemDefinition(
                AppPermissions.Pages_HandheldTerminal,
                L(AppPermissions.Pages_HandheldTerminal),
                icon: "icon-grid"
            );
            //视频对讲（二级菜单）
            var videoCall = new MenuItemDefinition("VideoCall", L("VideoCall"),
                url: "/Devices/Device/VideoCall",
                requiredPermissionName: AppPermissions.Pages_HandheldTerminal_VideoCall);

            //应用白名单（二级菜单）
            var appWhiteList = new MenuItemDefinition(
                AppWhiteListAppPermissions.AppWhiteList,
                L("AppWhiteList"),
                url: "/AppWhiteLists/AppWhiteList",
                icon: "icon-grid",
                requiredPermissionName: AppWhiteListAppPermissions.AppWhiteList
            );

            //一级菜单手持终端管理下的二级菜单包括应用白名单、视频对讲
            device.AddItem(
                new MenuItemDefinition(
                    DeviceAppPermissions.Device,
                    L("Device"),
                    "icon-star",
                    url: "/Devices/Device",
                    requiredPermissionName: DeviceAppPermissions.Device))
                    .AddItem(appWhiteList)
                    .AddItem(videoCall)
                    ;

            //通知公告管理（一级菜单）
            var announcement = new MenuItemDefinition(
                AnnouncementAppPermissions.Announcement,
                L("Announcement"),
                icon: "icon-grid"
            );

            announcement.AddItem(
                new MenuItemDefinition(
                    AnnouncementAppPermissions.Announcement,
                    L("Announcement"),
                    "icon-star",
                    "announcements/announcement",
                    requiredPermissionName: AnnouncementAppPermissions.Announcement));

            //所有的一级菜单
            context.Manager.MainMenu
                .AddItem(device)
                .AddItem(announcement)
                .AddItem(attendance)

            #region 系统管理
                .AddItem(
                    new MenuItemDefinition(
                        "SystemManage",
                        L("SystemManage"),
                        icon: "fa fa-gear",
                        requiredPermissionName: AppPermissions.Pages_SystemManage
                        )
                        .AddItem(
                    new MenuItemDefinition(
                        "User",
                        L("User"),
                        url: "Users",
                        requiredPermissionName: UserAppPermissions.User
                        ))
                         .AddItem(
                    new MenuItemDefinition(
                        "Role",
                        L("Role"),
                        url: "Roles",
                        requiredPermissionName: RoleAppPermissions.Role
                        ))
                          .AddItem(
                    new MenuItemDefinition(
                        "OrganizationUnit",
                        L("OrganizationUnit"),
                        url: "OrganizationUnits",
                        requiredPermissionName: OrganizationUnitAppPermissions.OrganizationUnit
                        ))
                        .AddItem(
                    new MenuItemDefinition(
                        "DataDictionaries",
                        L("DataDictionary"),
                        url: "DataDictionaries",
                        requiredPermissionName: DataDictionaryAppPermissions.DataDictionary
                        ))
                    .AddItem(
                    new MenuItemDefinition(
                        "AuditLog",
                        L("AuditLog"),
                        url: "AuditLogs",
                        requiredPermissionName: AuditLogAppPermissions.AuditLog
                        ))
                        .AddItem(
                    new MenuItemDefinition(
                        "MainTenance",
                        L("Maintenance"),
                        url: "MainTenance",
                        requiredPermissionName: AppPermissions.Pages_Maintenance
                        ))
                        )

                //                        .AddItem(
                //new MenuItemDefinition(
                //    "DatatableApi",
                //    L("DatatableApi"),
                //    url: "Document/DataTable",
                //    requiredPermissionName: AppPermissions.Pages_Api
                //    ))
                // end:SystemManage

            #endregion

                ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
