using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using Vickn.Platform.Authorization;
using Vickn.Platform.Users;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Users)]
    public class UsersController : PlatformControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index(GetUserInput input)
        {
            var output = await _userAppService.GetPagedUsersAsync(input);
            return View(output);
        }

        public async Task<ActionResult> Create(int? id)
        {
            return View();
        }

        [HttpPost]
        [DisableAbpAntiForgeryTokenValidation]
        public async Task<ActionResult> Create(UserEditDto input)
        {
            return JavaScript("parent.location.reload()");
        } 
    }
}