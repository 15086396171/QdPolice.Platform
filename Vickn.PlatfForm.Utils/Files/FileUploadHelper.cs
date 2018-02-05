// ===============================================================================
// 命名空间 :     NanNingSSO.Common.Static
// 类 名  称 :     FileHelper
// 版      本 :      v1.0.0.0
// 文 件  名 :     FileHelper
// 描      述 :      
// 作      者 :      dark_yx-i
// 创建时间 :     2016-07-14 15:55:11
// 修 改  人 :     dark_yx-i
// 修改时间 :     2016-07-14 15:55:11
// ===============================================================================
// Copyright © DARK_YX-I-PC 2016 . All rights reserved.
// ===============================================================================

using System.IO;
using System.Web;

namespace Vickn.PlatfForm.Utils.Files
{
    public static class FileUploadHelper
    {
        /// <summary>
        ///  从上传文件流中获取文件
        /// </summary>
        /// <param name="finalPath"></param>
        /// <param name="fileName"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static bool SaveFile(string finalPath, string fileName,HttpContext httpContext)
        {
            int offset = 0; // 偏移量
            long length = httpContext.Request.InputStream.Length;

            if (length > int.MaxValue)
            {
                return false;
            }

            FileStream fs = new FileStream(finalPath + fileName, FileMode.Append, FileAccess.Write);
            Stream stream = httpContext.Request.InputStream;
            try
            {
                while (length - offset > 0)
                {
                    long bytsLength = length - offset;
                    // 如果长度小于20M时只读取长度
                    bytsLength = bytsLength > 104857600 ? 104857600 : bytsLength;
                    byte[] byts = new byte[bytsLength];
                    int read = stream.Read(byts, 0, byts.Length);
                    fs.Write(byts, 0, byts.Length);
                    offset += byts.Length;
                }
            }
            finally
            {
                fs.Dispose();
            }
            return true;
        }
    }
}
