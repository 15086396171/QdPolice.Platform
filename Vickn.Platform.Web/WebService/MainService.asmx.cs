using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using Abp;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Abp.Threading;
using Newtonsoft.Json;
using Vickn.Platform.Users;
using Vickn.Platform.Zero.Notifications;

namespace Vickn.Platform.Web.WebService
{
    /// <summary>
    /// MainService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MainService : System.Web.Services.WebService, ITransientDependency
    {
        private readonly NotificationManager _notificationManager;
        private readonly UserManager _userManager;
        private IUnitOfWorkManager _unitOfWorkManager;
        public IAbpSession AbpSession { get; set; }

        public MainService()
        {
            _notificationManager = IocManager.Instance.Resolve<NotificationManager>();
            _userManager = IocManager.Instance.Resolve<UserManager>();
            _unitOfWorkManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();
            AbpSession = IocManager.Instance.Resolve<IAbpSession>();

        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public void CameraChange()
        {
            var policeNo = HttpContext.Current.Request["PoliceNo"];
            var isIn = bool.Parse(HttpContext.Current.Request["IsIn"]);
            var d = long.Parse(HttpContext.Current.Request["time"]);
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(d + "0000");
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

            StreamWriter sw = File.AppendText("D:\\haikangceshi.txt");
            string w = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + JsonConvert.SerializeObject(obj, Formatting.None) + System.Environment.NewLine;
            sw.Write(w);
            sw.Close();
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {

                var user = AsyncHelper.RunSync(async () => await _userManager.Users.FirstOrDefaultAsync(p => p.PoliceNo == policeNo));
                if (user == null)
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        success = false,
                        errMsg = "用户不存在，请检查警号"
                    });
                    HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
                    HttpContext.Current.Response.Write(json);
                    HttpContext.Current.Response.End();
                    return;
                }

                AsyncHelper.RunSync(async () => await _notificationManager.SendMessageAsync(new UserIdentifier(AbpSession.TenantId, user.Id), PlatformConsts.NotificationConstNames.CameraChange, PlatformConsts.NotificationConstNames.CameraChange, obj));
                unitOfWork.Complete();
                var returnObj = new
                {
                    success = true,
                    errMsg = ""
                };

                HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
                HttpContext.Current.Response.Write(returnObj);
                HttpContext.Current.Response.End();
            }
        }
    }
}
