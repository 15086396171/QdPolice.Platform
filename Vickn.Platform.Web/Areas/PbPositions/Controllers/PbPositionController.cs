/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions
* 类 名  称 :      PbPositionController 
* 版      本 :      v1.0.0.0
* 文 件  名 :     PbPositionController.cs
* 描      述 :     排班岗位控制器
* 创建时间 :     2018/5/6 15:09:44
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Vickn.Platform.PbManagement.PbPositions;
using Vickn.Platform.PbManagement.PbPositions.Authorization;
using Vickn.Platform.PbManagement.PbPositions.Dtos;
using Vickn.Platform.Web.Controllers;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using Vickn.Platform.PbManagement.PbTitles;
using Vickn.Platform.PbManagement.PositionPbs.Dtos;
using Vickn.Platform.PbManagement.PositionPbTimes;
using Vickn.Platform.PbManagement.PositionPbTimes.Dtos;
using Vickn.Platform.PbManagement.PositionPbs;
using Vickn.Platform.Users;
using Vickn.Platform.Users.Dtos;
using System.Linq;
using Vickn.Platform.PbManagement.PositionPbMaps.Dtos;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Web.Security.AntiForgery;
using System.IO;

namespace Vickn.Platform.Web.Areas.PbPositions.Controllers
{

    [AbpMvcAuthorize(PbPositionAppPermissions.PbPosition)]
    public class PbPositionController : PlatformControllerBase
    {
        private readonly IPbPositionAppService _pbPositionAppService;
        private readonly IPbTitleAppService _pbTitleAppService;
        private readonly IUserAppService _userAppService;
        private readonly IPositionPbAppService _positionPbAppService;

        public PbPositionController(IPbPositionAppService pbPositionAppService, IPbTitleAppService pbTitleAppService, IUserAppService userAppService, IPositionPbAppService positionPbAppService)
        {
            _pbPositionAppService = pbPositionAppService;
            _pbTitleAppService = pbTitleAppService;
            _userAppService = userAppService;
            _positionPbAppService = positionPbAppService;
        }

        public ActionResult Index(int pbTitleId)
        {
            ViewBag.pbTitleId = pbTitleId;
            return View();
        }

        public async Task<ActionResult> Import(int pbPostionId)
        {


            EntityDto<int> input = new EntityDto();
            input.Id = pbPostionId;
            var pbPosition = await _pbPositionAppService.GetByIdAsync(input);
            return View(pbPosition);
        }




        private async Task<ImportPositionPbTimeDto> PositionPbTime(IRow row, PositionPbEditDto positionPb, int index)
        {
            var namesStr = row.Cells[index * 3 + 1].ToString();

            if (string.IsNullOrWhiteSpace(namesStr))
                return null;

            // 班次1
            var names = namesStr.Split(new char[] { '、' }, StringSplitOptions.RemoveEmptyEntries);



            List<UserListDto> users = await _userAppService.GetUserslist();
            users = users.Where(p => names.Contains(p.UserName)).ToList();


            if (!users.Any())
                throw new NotImplementedException("未找到用户：" + namesStr);
            var startTimeStr = row.Cells[index * 3 + 2].ToString();
            var startTime = DateTime.Parse(startTimeStr);
            var endTime = DateTime.Parse(row.Cells[index * 3 + 3].ToString());

            ImportPositionPbTimeDto positionPbTime = new ImportPositionPbTimeDto()
            {

                StartTime = positionPb.DutyDate.Date.AddHours(startTime.Hour).AddMinutes(startTime.Minute),
                EndTime = positionPb.DutyDate.Date.AddHours(endTime.Hour).AddMinutes(endTime.Minute),

                UserId = users[0].Id,
                //RealName = string.Join(",", users.Select(p => p.RealName).ToList()),
                RealName = string.Join(",", users.Select(p => p.UserName).ToList()),

                PositionPbMaps = users.Select(p => new PositionPbMapDto()
                {
                    RealName = p.UserName,
                    UserId = p.Id,
                }).ToList()
            };
            // 跨天
            if (positionPbTime.EndTime <= positionPbTime.StartTime)
            {
                positionPbTime.EndTime = positionPbTime.EndTime.AddDays(1);
            }
            return positionPbTime;
        }

        [DisableAbpAntiForgeryTokenValidation]
        public async Task<ActionResult> PbImportXX(int pbPositionId)
        {
            string filePath = string.Concat("/FileRecords/", DateTime.Now.ToString("yyyyMMdd"), "/");
            string savePath = Server.MapPath(filePath);
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            var file = Request.Files[0];
            try
            {

                IWorkbook workbook = null;
                ISheet sheet = null;
                IRow row = null;
                ICell cell = null;
                int startRow = 1;

                if (file.FileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0)
                {
                    workbook = new XSSFWorkbook(file.InputStream);
                }
                else if (file.FileName.IndexOf(".xls", StringComparison.Ordinal) > 0)
                    workbook = new HSSFWorkbook(file.InputStream);
                else
                {
                    return Json(new { success = false, msg = "上传文件格式不正确！" });
                }

                sheet = workbook.GetSheetAt(0); //读取第一个sheet，当然也可以循环读取每个sheet  

                int rowCount = sheet.LastRowNum;//总行数  

                List<PositionPbEditDto> positionPbS = new List<PositionPbEditDto>();


                var pbPosition = await _pbPositionAppService.GetByIdAsync(new EntityDto<int> { Id = pbPositionId });

                var pbTitle = await _pbTitleAppService.GetByIdAsync(new EntityDto(pbPosition.PbTitleId));
                for (int i = 0; i < rowCount - 2; i++)
                {
                    row = sheet.GetRow(i + 2);

                    // 日期

                    var dateStr = row.Cells[0].ToString();
                    if (string.IsNullOrWhiteSpace(dateStr))
                    {
                        continue;
                    }

                    var date = Convert.ToInt32(dateStr);

                    PositionPbEditDto positionPb = new PositionPbEditDto()
                    {

                        PbPositionId = pbPositionId,
                        DutyDate = pbTitle.Month.Date.AddDays(1 - pbTitle.Month.Day - 1 + date),
                        PositionPbTimes = new List<ImportPositionPbTimeDto>()
                    };

                    for (int j = 0; j < 5; j++)
                    {
                        var positionPbTime = await PositionPbTime(row, positionPb, j);

                        if (positionPbTime != null)
                        {
                            positionPb.PositionPbTimes.Add(positionPbTime);
                        }
                    }
                    positionPbS.Add(positionPb);
                }

                // 生成其余空的天
                int days = System.Threading.Thread.CurrentThread.CurrentUICulture.Calendar.GetDaysInMonth(pbPosition.Month.Year, pbPosition.Month.Month);
                for (int i = 1; i < days + 1; i++)
                {
                    //var positionPb = positionPbS.FirstOrDefault(p => p.DutyDate.Day == i);
                    var positionPb = positionPbS.Find(p => p.DutyDate.Day == i);
                    if (positionPb == null)
                    {
                        positionPb = new PositionPbEditDto()
                        {
                            PositionId = pbPosition.Id,
                            PbPositionId = pbPositionId,

                            DutyDate = pbTitle.Month.Date.AddDays(1 - pbTitle.Month.Day - 1 + i),
                        };
                        positionPbS.Add(positionPb);
                    }
                }

                for (int i = 0; i < positionPbS.Count; i++)
                {
                    PositionPbEditDto entity = new PositionPbEditDto();
                    entity = positionPbS[i];
                    await _positionPbAppService.PbImportAsync(entity);
                }

            }

            catch (Exception exception)
            {
                return Json(new
                {
                    success = false,
                    msg = exception.Message
                });
            }

            return Json(new { msg = "导入成功" });

        }

    }
}