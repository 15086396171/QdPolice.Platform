using System;
using System.IO;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.UI;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using Vickn.Platform.Dtos;
using Vickn.Platform.MainTenance.AppFolders;

namespace Vickn.Platform.Web.Controllers
{
    public class FileController : PlatformControllerBase
    {
        private readonly IAppFolders _appFolders;

        public FileController(IAppFolders appFolders)
        {
            _appFolders = appFolders;
        }

        [AbpMvcAuthorize]
        [DisableAuditing]
        public ActionResult DownloadTempFile(FileDto file)
        {
            var filePath = Path.Combine(_appFolders.TempFileDownloadFolder, file.FileToken);
            if (!System.IO.File.Exists(filePath))
            {
                throw new UserFriendlyException(L("RequestedFileDoesNotExists"));
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            System.IO.File.Delete(filePath);
            return File(fileBytes, file.FileType, file.FileName);
        }
        [DisableAbpAntiForgeryTokenValidation]
        public string UploadImg()
        {
            if (Request.Files.Count == 0)
                return "error|文件不存在";
            string filePath = string.Concat("/FileRecords/", DateTime.Now.ToString("yyyyMMdd"), "/");
            string savePath = Server.MapPath(filePath);
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            string fileNo = Guid.NewGuid().ToString("N");

            var file = Request.Files[0];

            if (file == null || file.ContentLength == 0)
                return "error|文件不存在";

            if (!file.FileName.Contains(".") || !"jpg|gif|png|bmp".Contains(file.FileName.Substring(file.FileName.LastIndexOf(".") + 1)))
                return "error|只能上传图片";

            var fileName = DateTime.Now.Ticks + "_" + file.FileName;
            try
            {
                file.SaveAs(savePath + fileName);
                return filePath + fileName;
            }
            catch (Exception)
            {
                return "error|保存文件失败";
            }
        }
    }
}