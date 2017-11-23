using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Extensions;
using Abp.UI;
using Abp.Web.Security.AntiForgery;
using Vickn.Platform.FileRecords;
using Vickn.Platform.FileRecords.Dtos;
using Vickn.Platform.Web.Models.FileRecord;

namespace Vickn.Platform.Web.Controllers
{
    [DisableAuditing]
    public class FileRecordController : PlatformControllerBase
    {
        private readonly IFileRecordAppService _fileRecordAppService;

        public FileRecordController(IFileRecordAppService fileRecordAppService)
        {
            _fileRecordAppService = fileRecordAppService;
        }

        [DisableAbpAntiForgeryTokenValidation]
        public ActionResult SimpleUpload()
        {
            if (Request.Files.Count == 0)
                throw new UserFriendlyException("文件不存在");
            string filePath = string.Concat("/FileRecords/", DateTime.Now.ToString("yyyyMMdd"), "/");
            string savePath = Server.MapPath(filePath);
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);
            var file = Request.Files[0];

            if (file == null || file.ContentLength == 0)
                throw new UserFriendlyException("文件不存在");

            if (!file.FileName.Contains(".") ||
                !"jpg|gif|png|bmp".Contains(file.FileName.Substring(file.FileName.LastIndexOf(".", StringComparison.Ordinal) + 1)))
                throw new UserFriendlyException("文件不存在");

            var fileName = DateTime.Now.Ticks  + file.FileName.Substring(file.FileName.LastIndexOf(".", StringComparison.Ordinal));
            try
            {
                file.SaveAs(savePath + fileName);
                return Json(new
                {
                    url = filePath + fileName
                });
            }
            catch (Exception)
            {
                throw new UserFriendlyException("保存文件失败");
            }
        }

        [DisableAbpAntiForgeryTokenValidation]
        public async Task<ActionResult> UploadImgWithId(FileUploadViewModel model)
        {
            if (Request.Files.Count == 0)
                throw new UserFriendlyException("文件不存在");
            string filePath = string.Concat("/FileRecords/", DateTime.Now.ToString("yyyyMMdd"), "/");
            string savePath = Server.MapPath(filePath);
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            if (model.FileId.IsNullOrEmpty())
                throw new UserFriendlyException("文件编号不能为空");

            try
            {
                foreach (string fileNo in Request.Files)
                {
                    var file = Request.Files[fileNo];
                    if (!file.FileName.Contains(".") || !"jpg|gif|png|bmp".Contains(file.FileName.Substring(file.FileName.LastIndexOf(".", StringComparison.Ordinal) + 1)))
                        throw new UserFriendlyException("文件格式不正确");

                    var fileName = DateTime.Now.Ticks + file.FileName.Substring(file.FileName.LastIndexOf(".", StringComparison.Ordinal));

                    file.SaveAs(savePath + fileName);

                    var result = await _fileRecordAppService.CreateAsync(new FileRecordForEdit()
                    {
                        FileRecordEditDto = new FileRecordEditDto()
                        {
                            FileId = model.FileId,
                            Name = "",
                            Url = filePath + fileName
                        }
                    });
                }

                return Json(new
                {
                    success = true,
                });
            }
            catch (Exception)
            {
                throw new UserFriendlyException("保存文件失败");
            }
        }
    }
}