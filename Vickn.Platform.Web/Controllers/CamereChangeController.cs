using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp;
using Abp.Authorization;
using Abp.Json;
using Abp.Logging;
using Abp.Threading;
using Abp.Web.Models;
using Newtonsoft.Json;
using Vickn.Platform.Users;
using Vickn.Platform.Zero.Notifications;

namespace Vickn.Platform.Web.Controllers
{
    [AbpAllowAnonymous]
    public class CamereChangeController : PlatformControllerBase
    {
        private UserManager _userManager;
        private NotificationManager _notificationManager;

        public CamereChangeController(UserManager userManager, NotificationManager notificationManager)
        {
            _userManager = userManager;
            _notificationManager = notificationManager;
        }

        // GET: CamereChange
        [DontWrapResult]
        public async Task<ActionResult> Index(string policeNo, bool isIn, long time)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(time + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtResult = dtStart.Add(toNow);

            var obj = new
            {
                success = true,
                error = new
                {
                    policeNo = policeNo,
                    isIn = isIn,
                    time = dtResult.ToString("yyyy-MM-dd HH:mm:ss")
                }
            };

            LogHelper.Logger.Info(obj.ToJsonString());

            var user = await _userManager.Users.FirstOrDefaultAsync(p => p.PoliceNo == policeNo);
            if (user == null)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    success = false,
                    errMsg = "用户不存在，请检查警号"
                });
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            AsyncHelper.RunSync(async () => await _notificationManager.SendMessageAsync(new UserIdentifier(AbpSession.TenantId, user.Id), PlatformConsts.NotificationConstNames.CameraChange, PlatformConsts.NotificationConstNames.CameraChange, obj));

            return Json(new
            {
                success = true,
                errMsg = ""
            }, JsonRequestBehavior.AllowGet);
        }
    }
}