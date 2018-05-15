using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Vickn.Platform.DataDictionaries;
using Vickn.Platform.DataDictionaries.Dtos;
using Vickn.Platform.Users;
using Vickn.Platform.Users.Authorization;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize(UserAppPermissions.User)]
    public class UsersController : PlatformControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IDataDictionaryAppService _dataDictionaryAppService;

        public UsersController(IUserAppService userAppService, IDataDictionaryAppService dataDictionaryAppService)
        {
            _userAppService = userAppService;
            _dataDictionaryAppService = dataDictionaryAppService;
        }

        public ActionResult Index(long? ouId)
        {
            ViewBag.ouId = ouId;
            return View();
        }

        [AbpMvcAuthorize(UserAppPermissions.User_CreateUser, UserAppPermissions.User_EditUser)]
        public async Task<ActionResult> Create(long? id, long? ouId)
        {
            var result = await _userAppService.GetUserForEditAsync(new NullableIdDto<long>(id));
            if (!result.UserEditDto.Id.HasValue)

                result.OuId = ouId;

            var dataName = "Post.Rank";
            GetDataDictoryItemsByDicKeyInput input = new GetDataDictoryItemsByDicKeyInput();
            input.DicKey = dataName;
            result.DataDictionaryItems = await _dataDictionaryAppService.GetDataDictionaryItemsByDicName(input);
            var userList = result.DataDictionaryItems;
            ViewBag.Position = new SelectList(userList.Items, "DisplayName", "DisplayName");

          
            //if (result.UserEditDto.Id.HasValue)
            //{
            //    List<SelectListItem> list = new List<SelectListItem> {
            //        new SelectListItem { Text = result.UserEditDto.Position, Value = "0",Selected = true},

            //        ViewBag.Position = new SelectList(userList.Items, "Value", "DisplayName");

            //}


            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GetUserForEdit dto)
        {
            dto.UserEditDto.Position = Request["Position"];
            if (!CheckModelState(await _userAppService.CheckErrorAsync(dto)))
                return View(dto);

            await _userAppService.CreateOrUpdateUserAsync(dto);
            return RedirectToAction("Index", new { ouId = dto.OuId });
        }

        public async Task<ActionResult> ChangeProfilePic()
        {
            return View(await _userAppService.GetMyInfoAsync());
        }


        public async Task<ActionResult> MyInfo()
        {
            return View("_MyInfo", await _userAppService.GetMyInfoAsync());
        }

        [DisableAbpAntiForgeryTokenValidation]
        public async Task<ActionResult> Import()
        {
            string filePath = string.Concat("/FileRecords/", DateTime.Now.ToString("yyyyMMdd"), "/");
            string savePath = Server.MapPath(filePath);
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            string fileNo = Guid.NewGuid().ToString("N");

            var file = Request.Files[0];

            var fileName = DateTime.Now.Ticks + "_" + file.FileName;
            try
            {
                file.SaveAs(savePath + fileName);
                //  return filePath + fileName;
            }
            catch (Exception)
            {
                return Json(new { });
            }
            FileStream fs = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 1;

            List<UserEditDtoWithPassword> userEditDtos = new List<UserEditDtoWithPassword>();
            var userEditDto1 = new UserEditDtoWithPassword();
            int value;
            try
            {
                using (fs = System.IO.File.OpenRead(savePath + fileName))
                {
                    if ((savePath + fileName).IndexOf(".xlsx") > 0)
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if ((savePath + fileName).IndexOf(".xls", StringComparison.Ordinal) > 0)
                        workbook = new HSSFWorkbook(fs);

                    sheet = workbook.GetSheetAt(0); //读取第一个sheet，当然也可以循环读取每个sheet  

                    int rowCount = sheet.LastRowNum;//总行数  

                    for (int i = 0; i < rowCount; i++)
                    {
                        value = i;
                        row = sheet.GetRow(i + 1);
                        if (row.Cells[0].ToString().IsNullOrEmpty())
                        {
                            continue;
                        }
                        userEditDto1 = new UserEditDtoWithPassword()
                        {
                            Name = row.Cells[1].ToString().Trim(),
                            UserName = row.Cells[2].ToString().Trim(),
                            Password = row.Cells[3].ToString().Trim(),
                            PoliceNo = row.Cells[4].ToString().Trim(),
                            PhoneNumber = row.Cells[5].ToString().Trim(),
                            Landline = row.Cells[6].ToString().Trim(),
                            // 默认字段
                            ShouldChangePasswordOnNextLogin = true,
                            IsActive = true,
                        };
                        userEditDtos.Add(userEditDto1);
                    }
                }
            }
            catch (Exception ex)
            {
                fs?.Close();
                return Json(new { error = ex.Message + userEditDto1.UserName });
            }

            List<string> notImportUsers = new List<string>();
            foreach (var userEditDto in userEditDtos)
            {
                try
                {
                    userEditDto1 = userEditDto;
                    if (!userEditDto.UserName.IsNullOrEmpty())
                        await _userAppService.CreateManyWithPassword(userEditDto);
                }
                catch
                {
                    return Json(new { error = userEditDto1.UserName });
                }
            }
            return Json(new { success = true });
        }

        public async Task<ActionResult> SetRoles()
        {
            await _userAppService.SetDefaultRolesAsync();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}