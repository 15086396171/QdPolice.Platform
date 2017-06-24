using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using Vickn.PlatfForm.Utils.Pager;
using Vickn.Platform.Auditing;
using Vickn.Platform.Auditing.Dto;
using Vickn.Platform.AuditLogs.Authorization;

namespace Vickn.Platform.Web.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AuditLogAppPermissions.AuditLog)]
    public class AuditLogsController : PlatformControllerBase
    {
        private IAuditLogAppService _auditLogAppService;

        public AuditLogsController(IAuditLogAppService auditLogAppService)
        {
            _auditLogAppService = auditLogAppService;
        }

        // GET: AuditLogs
        public ActionResult Index(GetAuditLogsInput input)
        {
            return View();
        }
    }
}