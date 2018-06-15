﻿using Abp.Domain.Repositories;
using Microsoft.Owin.Security.Provider;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vickn.Platform.Attendances.KQDetails;
using Vickn.Platform.Attendances.KqShifts;
using Vickn.Platform.Attendences.KqShifts;
using Vickn.Platform.Attendences.KqShifts.Dtos;
using Vickn.Platform.Attendences.KqStatistics;
using Vickn.Platform.Attendences.KqStatistics.Dtos;
using Vickn.Platform.Web.Controllers;

namespace Vickn.Platform.Web.Areas.KqStatistics.Controllers
{
    public class KqStatisticController : PlatformControllerBase
    {
        private readonly IKqStatisticAppService _kqStatisticAppService;
        private readonly IKqShiftAppService _kqShiftAppService;

        public KqStatisticController(IKqStatisticAppService kqStatisticAppService, IKqShiftAppService kqShiftAppService)
        {
            _kqStatisticAppService = kqStatisticAppService;
            _kqShiftAppService = kqShiftAppService;
        }

        // GET: KqStatistics/KqStatistic
        public ActionResult Index()
        {
            DateTime now = DateTime.Today;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);

            ViewBag.StartTime = d1.ToString("yyyy-MM-dd");
            ViewBag.EndTime = d2.ToString("yyyy-MM-dd");


            KqShiftDto all = new KqShiftDto();
            all.Id = 0;
            all.ShiftName = "所有";
            var kqshiftList = _kqShiftAppService.GetAllAsync().Result.ToList();
            kqshiftList.Add(all);
            kqshiftList = kqshiftList.OrderBy(p => p.Id).ToList();

            List<string> IsUnusuallist = new List<string>();
            IsUnusuallist.Add("所有");
            IsUnusuallist.Add("正常");
            IsUnusuallist.Add("异常");
            ViewBag.IsUnusuallist = IsUnusuallist;

            ViewBag.KqShiftName = kqshiftList;
            return View();
        }

        public ActionResult Detail(string UserName = "", string StartTime = "", string EndTime = "", string IsUnusual = "", string KqShiftName = "")
        {
            if (string.IsNullOrEmpty(StartTime) || string.IsNullOrEmpty(EndTime))
            {
                DateTime now = DateTime.Today;
                DateTime d1 = new DateTime(now.Year, now.Month, 1);
                DateTime d2 = d1.AddMonths(1).AddDays(-1);

                ViewBag.StartTime = d1.ToString("yyyy-MM-dd");
                ViewBag.EndTime = d2.ToString("yyyy-MM-dd");
            }
            else
            {

                ViewBag.StartTime = StartTime;
                ViewBag.EndTime = EndTime;
            }
            ViewBag.UserName = UserName;

            ViewBag.IsUnusual = IsUnusual;
            List<string> IsUnusuallist = new List<string>();
            IsUnusuallist.Add("所有");
            IsUnusuallist.Add("正常");
            IsUnusuallist.Add("异常");
            ViewBag.IsUnusuallist = IsUnusuallist;

            ViewBag.KqShiftName = KqShiftName;

            KqShiftDto all = new KqShiftDto();
            all.Id = 0;
            all.ShiftName = "所有";
            var kqshiftList = _kqShiftAppService.GetAllAsync().Result.ToList();
            kqshiftList.Add(all);
            kqshiftList = kqshiftList.OrderBy(p => p.Id).ToList();


            ViewBag.KqShiftList = kqshiftList;

            return View();
        }

        //考勤明细导出
        public void KqDetailExport(GetExportKqStatisticDto input)
        {
            //获取数据
            var dt = _kqStatisticAppService.ExportKqDetailStatisticAsync(input);

            //创建一个excel表格
            HSSFWorkbook book = new HSSFWorkbook();
            //创建一个sheet
            HSSFSheet sheet1 = book.CreateSheet("考勤明细记录") as HSSFSheet;




            //设置标题（相合）样式
            ICellStyle titleStyle = book.CreateCellStyle();
            titleStyle.BorderTop = BorderStyle.Thin;//给单元格上半部分加边框
            titleStyle.BorderLeft = BorderStyle.Thin;
            titleStyle.BorderRight = BorderStyle.Thin;
            titleStyle.BorderBottom = BorderStyle.Thin;
            titleStyle.VerticalAlignment = VerticalAlignment.Center;//单元格垂直居中
            titleStyle.Alignment = HorizontalAlignment.Center;//单元格水平居中
            IFont titlefont = book.CreateFont();//新建一个字体样式对象
            titlefont.FontHeightInPoints = 22;//字号
            titlefont.FontName = "宋体";//设置字体
            titlefont.IsBold = true;//加粗
            titleStyle.SetFont(titlefont);

            //设置内容样式
            ICellStyle ContentStyle = book.CreateCellStyle();
            ContentStyle.BorderTop = BorderStyle.Thin;
            ContentStyle.BorderLeft = BorderStyle.Thin;
            ContentStyle.BorderRight = BorderStyle.Thin;
            ContentStyle.BorderBottom = BorderStyle.Thin;
            ContentStyle.VerticalAlignment = VerticalAlignment.Center;//单元格垂直居中
            ContentStyle.Alignment = HorizontalAlignment.Center;//单元格水平居中
            ContentStyle.WrapText = true;//设置换行这个要先设置
            IFont Contentfont = book.CreateFont();
            Contentfont.FontHeightInPoints = 10;//字号
            Contentfont.FontName = "宋体";//设置字体
            ContentStyle.SetFont(Contentfont);

            //设置列的宽度
            int sheetWidthNum = 0;
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 100);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 100);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 100);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 100);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 100);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 250);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 250);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 100);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 250);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 250);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 100);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 100);

            #region 第一行

            //设置标题名称
            string titleName = "考勤明细记录";

            string date = "";
            //判断时间是否为null
            if (input.EndTime == null || input.StartTime == null)
            {
                date = "日期:所有日期";
            }
            else
            {
                input.EndTime = input.EndTime.Value.AddDays(-1);
                string date1 = input.StartTime.Value.ToString("yyyy-MM-dd");

                string date2 = input.EndTime.Value.ToString("yyyy-MM-dd");
                date = "日期:" + date1 + "至" + date2;
            }


            //创建第一行
            HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
            row0.Height = 30 * 20;//设置单元格的高度
            //在第一行中创建第一列
            var cellTitl = row0.CreateCell(0);
            //给第一行中的第一列赋值
            cellTitl.SetCellValue(titleName);


            var cellTitl2 = row0.CreateCell(9);

            cellTitl2.SetCellValue(date);

            //解决标题只有第一列有部分边框的问题

            CellRangeAddress region = new CellRangeAddress(0, 0, 0, 8);
            for (int i = region.FirstRow; i <= region.LastRow; i++)
            {
                IRow row1 = HSSFCellUtil.GetRow(i, sheet1);

                for (int j = region.FirstColumn; j <= region.LastColumn; j++)
                {
                    ICell singleCell = HSSFCellUtil.GetCell(row1, (short)j);
                    singleCell.CellStyle = titleStyle;
                }
            }


            //设置一个合并单元格区域，使用上下左右定义CellRangeAddress区域
            //CellRangeAddress四个参数为：起始行，结束行，起始列，结束列
            //--sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 34));
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 8));

            CellRangeAddress region2 = new CellRangeAddress(0, 0, 9, 10);
            for (int i = region2.FirstRow; i <= region2.LastRow; i++)
            {
                IRow row2 = HSSFCellUtil.GetRow(i, sheet1);

                for (int j = region2.FirstColumn; j <= region2.LastColumn; j++)
                {
                    ICell singleCell2 = HSSFCellUtil.GetCell(row2, (short)j);
                    singleCell2.CellStyle = ContentStyle;
                }
            }
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 9, 10));

            #endregion



            //创建第2行
            IRow tableTitleRow = sheet1.CreateRow(1);
            //创建第2行中的第一列
            var cell = tableTitleRow.CreateCell(0);
            //给第2行中的第一列赋值
            cell.SetCellValue("姓名");
            //添加样式
            cell.CellStyle = ContentStyle;

            int cellNum = 1;
            var cell2 = tableTitleRow.CreateCell(cellNum++);
            cell2.SetCellValue("所属部门");
            cell2.CellStyle = ContentStyle;

            var cell3 = tableTitleRow.CreateCell(cellNum++);
            cell3.SetCellValue("班次名称");
            cell3.CellStyle = ContentStyle;

            var cell4 = tableTitleRow.CreateCell(cellNum++);
            cell4.SetCellValue("签到日期");
            cell4.CellStyle = ContentStyle;

            var cell5 = tableTitleRow.CreateCell(cellNum++);
            cell5.SetCellValue("上班时间");
            cell5.CellStyle = ContentStyle;

            var cell6 = tableTitleRow.CreateCell(cellNum++);
            cell6.SetCellValue("上班外出事由");
            cell6.CellStyle = ContentStyle;

            var cell7 = tableTitleRow.CreateCell(cellNum++);
            cell7.SetCellValue("上班打卡位置");
            cell7.CellStyle = ContentStyle;

            var cell8 = tableTitleRow.CreateCell(cellNum++);
            cell8.SetCellValue("下班时间");
            cell8.CellStyle = ContentStyle;

            var cell9 = tableTitleRow.CreateCell(cellNum++);
            cell9.SetCellValue("下班外出事由");
            cell9.CellStyle = ContentStyle;

            var cell10 = tableTitleRow.CreateCell(cellNum++);
            cell10.SetCellValue("下班打卡位置");
            cell10.CellStyle = ContentStyle;

            var cell11 = tableTitleRow.CreateCell(cellNum++);
            cell11.SetCellValue("签到类型");
            cell11.CellStyle = ContentStyle;

            //遍历数据
            for (int i = 0; i < dt.Result.Count; i++)
            {
                int col = 0;
                //创建行（初始从第3行开始创建）
                IRow row = sheet1.CreateRow(i + 2);
                //创建列（初始从第0列开始创建）
                var rowCell1 = row.CreateCell(col++);
                //赋值
                rowCell1.SetCellValue(dt.Result[i].UserName);
                //添加样式
                rowCell1.CellStyle = ContentStyle;

                var rowCell2 = row.CreateCell(col++);
                rowCell2.SetCellValue(dt.Result[i].GroupName);
                rowCell2.CellStyle = ContentStyle;

                var rowCell3 = row.CreateCell(col++);
                rowCell3.SetCellValue(dt.Result[i].KqShiftName);
                rowCell3.CellStyle = ContentStyle;

                var rowCell4 = row.CreateCell(col++);
                rowCell4.SetCellValue(dt.Result[i].DateYMD);
                rowCell4.CellStyle = ContentStyle;

                var rowCell5 = row.CreateCell(col++);
                rowCell5.SetCellValue(dt.Result[i].DateWork);
                rowCell5.CellStyle = ContentStyle;

                var rowCell6 = row.CreateCell(col++);
                rowCell6.SetCellValue(dt.Result[i].OutgoingCauseWork);
                rowCell6.CellStyle = ContentStyle;

                var rowCell7 = row.CreateCell(col++);
                rowCell7.SetCellValue(dt.Result[i].QDPostionWork);
                rowCell7.CellStyle = ContentStyle;

                var rowCell8 = row.CreateCell(col++);
                rowCell8.SetCellValue(dt.Result[i].DateColsing);
                rowCell8.CellStyle = ContentStyle;

                var rowCell9 = row.CreateCell(col++);
                rowCell9.SetCellValue(dt.Result[i].OutgoingCauseClosing);
                rowCell9.CellStyle = ContentStyle;

                var rowCell10 = row.CreateCell(col++);
                rowCell10.SetCellValue(dt.Result[i].QDPostionClosing);
                rowCell10.CellStyle = ContentStyle;

                var rowCell11 = row.CreateCell(col++);
                rowCell11.SetCellValue(dt.Result[i].QDType);
                rowCell11.CellStyle = ContentStyle;
            }

            //创建一个ms流对象
            MemoryStream ms = new MemoryStream();
            //将book从缓冲区写入ms流对象
            book.Write(ms);
            //最终生产excel的名称
            string fileName = $"{titleName}.xls";
            //定义输出类型为excel
            Response.ContentType = "application/vnd.ms-excel";
            //区分浏览器导出转码格式
            if (Request.ServerVariables["http_user_agent"].ToString().IndexOf("Firefox") != -1)
            {
                fileName = "=?UTF-8?B?" + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(fileName)) + "?=";
            }
            else
            {
                fileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
                fileName = fileName.Replace("+", "%20");
            }

            //判断浏览器分开处理
            //确保浏览器弹出下载对话框
            Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
            //为程序加速
            Response.Buffer = true;
            //删除缓冲区中的所有 HTML 输出,注：如果没有Response.Buffer = true,Response.Clear()将导致运行时错误
            Response.Clear();
            Response.BinaryWrite(ms.GetBuffer());
            //如果 Response.Buffer 已设置为 TRUE，则调用 Response.End 将缓冲输出
            Response.End();
        }



        //考勤统计导出
        public void KqStatictisExport(GetExportKqStatisticDto input)
        {
            //获取数据
            var dt = _kqStatisticAppService.ExportKqStatisticAsync(input);

            //创建一个excel表格
            HSSFWorkbook book = new HSSFWorkbook();
            //创建一个sheet
            HSSFSheet sheet1 = book.CreateSheet("考勤统计记录") as HSSFSheet;




            //设置标题（相合）样式
            ICellStyle titleStyle = book.CreateCellStyle();
            titleStyle.BorderTop = BorderStyle.Thin;//给单元格上半部分加边框
            titleStyle.BorderLeft = BorderStyle.Thin;
            titleStyle.BorderRight = BorderStyle.Thin;
            titleStyle.BorderBottom = BorderStyle.Thin;
            titleStyle.VerticalAlignment = VerticalAlignment.Center;//单元格垂直居中
            titleStyle.Alignment = HorizontalAlignment.Center;//单元格水平居中
            IFont titlefont = book.CreateFont();//新建一个字体样式对象
            titlefont.FontHeightInPoints = 22;//字号
            titlefont.FontName = "宋体";//设置字体
            titlefont.IsBold = true;//加粗
            titleStyle.SetFont(titlefont);

            //设置内容样式
            ICellStyle ContentStyle = book.CreateCellStyle();
            ContentStyle.BorderTop = BorderStyle.Thin;
            ContentStyle.BorderLeft = BorderStyle.Thin;
            ContentStyle.BorderRight = BorderStyle.Thin;
            ContentStyle.BorderBottom = BorderStyle.Thin;
            ContentStyle.VerticalAlignment = VerticalAlignment.Center;//单元格垂直居中
            ContentStyle.Alignment = HorizontalAlignment.Center;//单元格水平居中
            ContentStyle.WrapText = true;//设置换行这个要先设置
            IFont Contentfont = book.CreateFont();
            Contentfont.FontHeightInPoints = 10;//字号
            Contentfont.FontName = "宋体";//设置字体
            ContentStyle.SetFont(Contentfont);

            //设置列的宽度
            int sheetWidthNum = 0;
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 250);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);
            sheet1.SetColumnWidth(sheetWidthNum++, 30 * 150);

            #region 第一行

            //设置标题名称
            string titleName = "考勤统计记录";

            string date = "";
            //判断时间是否为null
            if (input.EndTime == null || input.StartTime == null)
            {
                date = "日期:所有日期";
            }
            else
            {
                input.EndTime = input.EndTime.Value.AddDays(-1);

                string date1 = input.StartTime.Value.ToString("yyyy-MM-dd");

                string date2 = input.EndTime.Value.ToString("yyyy-MM-dd");
                date = "日期:" + date1 + "至" + date2;
            }


            //创建第一行
            HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
            row0.Height = 30 * 20;//设置单元格的高度
            //在第一行中创建第一列
            var cellTitl = row0.CreateCell(0);
            //给第一行中的第一列赋值
            cellTitl.SetCellValue(titleName);


            var cellTitl2 = row0.CreateCell(6);

            cellTitl2.SetCellValue(date);

            //解决标题只有第一列有部分边框的问题

            CellRangeAddress region = new CellRangeAddress(0, 0, 0, 5);
            for (int i = region.FirstRow; i <= region.LastRow; i++)
            {
                IRow row1 = HSSFCellUtil.GetRow(i, sheet1);

                for (int j = region.FirstColumn; j <= region.LastColumn; j++)
                {
                    ICell singleCell = HSSFCellUtil.GetCell(row1, (short)j);
                    singleCell.CellStyle = titleStyle;
                }
            }


            //设置一个合并单元格区域，使用上下左右定义CellRangeAddress区域
            //CellRangeAddress四个参数为：起始行，结束行，起始列，结束列
            //--sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 34));
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 5));

            CellRangeAddress region2 = new CellRangeAddress(0, 0, 6, 7);
            for (int i = region2.FirstRow; i <= region2.LastRow; i++)
            {
                IRow row2 = HSSFCellUtil.GetRow(i, sheet1);

                for (int j = region2.FirstColumn; j <= region2.LastColumn; j++)
                {
                    ICell singleCell2 = HSSFCellUtil.GetCell(row2, (short)j);
                    singleCell2.CellStyle = ContentStyle;
                }
            }
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 6, 7));

            #endregion



            //创建第2行2
            IRow tableTitleRow = sheet1.CreateRow(1);
            //创建第2行中的第一列
            var cell = tableTitleRow.CreateCell(0);
            //给第2行中的第一列赋值
            cell.SetCellValue("姓名");
            //添加样式
            cell.CellStyle = ContentStyle;

            int cellNum = 1;
            var cell2 = tableTitleRow.CreateCell(cellNum++);
            cell2.SetCellValue("所属部门");
            cell2.CellStyle = ContentStyle;

            var cell3 = tableTitleRow.CreateCell(cellNum++);
            cell3.SetCellValue("考勤班次名称");
            cell3.CellStyle = ContentStyle;

            var cell4 = tableTitleRow.CreateCell(cellNum++);
            cell4.SetCellValue("正常天数");
            cell4.CellStyle = ContentStyle;

            var cell5 = tableTitleRow.CreateCell(cellNum++);
            cell5.SetCellValue("迟到天数");
            cell5.CellStyle = ContentStyle;

            var cell6 = tableTitleRow.CreateCell(cellNum++);
            cell6.SetCellValue("早退");
            cell6.CellStyle = ContentStyle;

            var cell7 = tableTitleRow.CreateCell(cellNum++);
            cell7.SetCellValue("缺勤");
            cell7.CellStyle = ContentStyle;

            var cell8 = tableTitleRow.CreateCell(cellNum++);
            cell8.SetCellValue("缺卡");
            cell8.CellStyle = ContentStyle;





            //遍历数据
            for (int i = 0; i < dt.Result.Count; i++)
            {
                int col = 0;
                //创建行（初始从第3行开始创建）
                IRow row = sheet1.CreateRow(i + 2);
                //创建列（初始从第0列开始创建）
                var rowCell1 = row.CreateCell(col++);
                //赋值
                rowCell1.SetCellValue(dt.Result[i].UserName);
                //添加样式
                rowCell1.CellStyle = ContentStyle;

                var rowCell2 = row.CreateCell(col++);
                rowCell2.SetCellValue(dt.Result[i].GroupName);
                rowCell2.CellStyle = ContentStyle;

                var rowCell3 = row.CreateCell(col++);
                rowCell3.SetCellValue(dt.Result[i].KqShiftName);
                rowCell3.CellStyle = ContentStyle;

                var rowCell4 = row.CreateCell(col++);
                rowCell4.SetCellValue(dt.Result[i].NormalDay);
                rowCell4.CellStyle = ContentStyle;

                var rowCell5 = row.CreateCell(col++);
                rowCell5.SetCellValue(dt.Result[i].LateDay);
                rowCell5.CellStyle = ContentStyle;

                var rowCell6 = row.CreateCell(col++);
                rowCell6.SetCellValue(dt.Result[i].LeaveEarlyDay);
                rowCell6.CellStyle = ContentStyle;

                var rowCell7 = row.CreateCell(col++);
                rowCell7.SetCellValue(dt.Result[i].AbsenteeismDay);
                rowCell7.CellStyle = ContentStyle;

                var rowCell8 = row.CreateCell(col++);
                rowCell8.SetCellValue(dt.Result[i].AbnormalDay);
                rowCell8.CellStyle = ContentStyle;



            }

            //创建一个ms流对象
            MemoryStream ms = new MemoryStream();
            //将book从缓冲区写入ms流对象
            book.Write(ms);
            //最终生产excel的名称
            string fileName = $"{titleName}.xls";
            //定义输出类型为excel
            Response.ContentType = "application/vnd.ms-excel";
            //区分浏览器导出文件名转码格式
            if (Request.ServerVariables["http_user_agent"].ToString().IndexOf("Firefox") != -1)
            {
                fileName = "=?UTF-8?B?" + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(fileName)) + "?=";
            }
            else
            {
                fileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
                fileName = fileName.Replace("+", "%20");
            }
            //确保浏览器弹出下载对话框
            Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
            //为程序加速
            Response.Buffer = true;
            //删除缓冲区中的所有 HTML 输出,注：如果没有Response.Buffer = true,Response.Clear()将导致运行时错误
            Response.Clear();
            Response.BinaryWrite(ms.GetBuffer());
            //如果 Response.Buffer 已设置为 TRUE，则调用 Response.End 将缓冲输出
            Response.End();
        }

    }
}