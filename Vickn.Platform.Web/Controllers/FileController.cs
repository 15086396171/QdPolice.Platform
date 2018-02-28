using System;
using System.Drawing;
using System.IO;
using System.Web.Mvc;
using Abp.Auditing;
using Abp.Extensions;
using Abp.UI;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using Newtonsoft.Json;
using Vickn.Platform.Dtos;
using Vickn.Platform.MainTenance.AppFolders;
using Vickn.Platform.Web.Models.Files;

namespace Vickn.Platform.Web.Controllers
{
    [AbpMvcAuthorize]
    [DisableAuditing]
    public class FileController : PlatformControllerBase
    {
        private readonly IAppFolders _appFolders;

        public FileController(IAppFolders appFolders)
        {
            _appFolders = appFolders;
        }

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
        [DontWrapResult]
        public ActionResult UploadImg()
        {
            var file = Request.Files[0];
            var cropViewModel = JsonConvert.DeserializeObject<CropperViewModel>(Request["avatar_data"]);

            if (file == null || file.ContentLength == 0)
                return Json(new { message = "文件不存在", state = 404 });
            string filePath = string.Concat("/Files/", DateTime.Now.ToString("yyyyMMdd"), "/");
            string savePath = Server.MapPath(filePath);
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            if (!file.FileName.Contains(".") || !"jpg|gif|png|bmp".Contains(file.FileName.Substring(file.FileName.LastIndexOf(".") + 1)))
                return Json(new { message = "只能上传图片", state = 403 });

            var fileName = DateTime.Now.Ticks + "_" + file.FileName;
            Stream sm = file.InputStream;
            byte[] bt = new byte[sm.Length];
            sm.Read(bt, 0, file.ContentLength);

            Image bm = Image.FromStream(CropImageFile(bt, cropViewModel.x.To<int>(), cropViewModel.y.To<int>(), cropViewModel.width.To<int>(), cropViewModel.height.To<int>()), true);

            try
            {
                bm.Save(savePath + fileName);
                return Json(new
                {
                    result = filePath + fileName,
                    state = 200
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    message = "保存文件失败",
                    state = 500
                });
            }
            finally
            {
                bm.Dispose();
            }
        }
        //裁剪
        private MemoryStream CropImageFile(byte[] imageFile, int targetX, int targetY, int targetW, int targetH)
        {
            MemoryStream imgMemoryStream = new MemoryStream();
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(new MemoryStream(imageFile));


            Bitmap bmPhoto = new Bitmap(targetW, targetH, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(72, 72);


            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            try
            {
                grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, targetW, targetH), targetX, targetY, targetW, targetH, GraphicsUnit.Pixel);
                bmPhoto.Save(imgMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                imgPhoto.Dispose();
                bmPhoto.Dispose();
                grPhoto.Dispose();
            }
            return imgMemoryStream;
        }

        [DisableAbpAntiForgeryTokenValidation]
        [DontWrapResult]
        public string UploadWang()
        {
            var file = Request.Files[0];

            if (file == null || file.ContentLength == 0)
                return "文件不存在";
            string filePath = string.Concat("/Files/", DateTime.Now.ToString("yyyyMMdd"), "/");
            string savePath = Server.MapPath(filePath);
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            if (!file.FileName.Contains(".") ||
                !"jpg|gif|png|bmp".Contains(file.FileName.Substring(file.FileName.LastIndexOf(".") + 1)))
                return "只能上传图片";

            var fileName = DateTime.Now.Ticks + "_" + file.FileName;
            Stream sm = file.InputStream;
            byte[] bt = new byte[sm.Length];
            sm.Read(bt, 0, file.ContentLength);

            try
            {
                file.SaveAs(savePath + fileName);
                return filePath + fileName;
            }
            catch (Exception)
            {
                return "文件保存失败";
            }

        }
    }
}