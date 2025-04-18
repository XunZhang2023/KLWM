using DevExpress.Data.Filtering;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TrainLoadingRefactor.DataCore.DataModel;
using static DevExpress.Skins.SolidColorHelper;
using Image = System.Drawing.Image;

namespace KLWM.Auxiliary
{
    /// <summary>
    /// NPOI操作帮助类
    /// </summary>
    public class NpoiHelper
    {
        #region  NPOI DataGridView 导出 EXCEL
        /// <summary>
        ///  NPOI DataGridView 导出 EXCEL
        ///  03版Excel-xls最大行数是65536行,最大列数是256列
        ///  07版Excel-xlsx最大行数是1048576行,最大列数是16384列
        /// </summary>
        /// <param name="fileName">默认保存文件名</param>
        /// <param name="dgv">DataGridView</param>
        /// <param name="fontname">字体名称</param>
        /// <param name="fontsize">字体大小</param> 

        public static void ExportExcel(string fileName, DataGridView dgv, string fontname, short fontsize)
        {
            IWorkbook workbook;
            ISheet sheet;
            Stopwatch sw = null;

            //判断datagridview中内容是否为空
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("DataGridView中内容为空,请先导入数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //保存文件
            string saveFileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Excel文件保存路径";
            saveFileDialog.FileName = fileName;
            MemoryStream ms = new MemoryStream(); //MemoryStream
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //**程序开始计时**//
                sw = new Stopwatch();
                sw.Start();

                saveFileName = saveFileDialog.FileName;

                //检测文件是否被占用
                if (!CheckFiles(saveFileName))
                {
                    MessageBox.Show("文件被占用,请关闭文件" + saveFileName);
                    workbook = null;
                    ms.Close();
                    ms.Dispose();
                    return;
                }
            }
            else
            {
                workbook = null;
                ms.Close();
                ms.Dispose();
            }

            //*** 根据扩展名xls和xlsx来创建对象
            string fileExt = Path.GetExtension(saveFileName).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = null;
            }
            //***

            //创建Sheet
            if (workbook != null)
            {
                sheet = workbook.CreateSheet("Sheet1");//Sheet的名称  
            }
            else
            {
                return;
            }

            //设置单元格样式
            ICellStyle cellStyle = workbook.CreateCellStyle();
            //水平居中对齐和垂直居中对齐
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            //设置字体
            IFont font = workbook.CreateFont();
            font.FontName = fontname;//字体名称
            font.FontHeightInPoints = fontsize;//字号
            font.Color = NPOI.HSSF.Util.HSSFColor.Black.Index;//字体颜色
            cellStyle.SetFont(font);

            //添加列名
            IRow headRow = sheet.CreateRow(0);
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                //隐藏行列不导出
                if (dgv.Columns[i].Visible == true)
                {
                    headRow.CreateCell(i).SetCellValue(dgv.Columns[i].HeaderText);
                    headRow.GetCell(i).CellStyle = cellStyle;
                }
            }

            //根据类型写入内容
            for (int rowNum = 0; rowNum < dgv.Rows.Count; rowNum++)
            {
                ///跳过第一行,第一行为列名
                IRow dataRow = sheet.CreateRow(rowNum + 1);
                for (int columnNum = 0; columnNum < dgv.Columns.Count; columnNum++)
                {
                    int columnWidth = (int)sheet.GetColumnWidth(columnNum) / 256; //列宽

                    //隐藏行列不导出
                    if (dgv.Rows[rowNum].Visible == true && dgv.Columns[columnNum].Visible == true)
                    {
                        //防止行列超出Excel限制
                        if (fileExt == ".xls")
                        {
                            //03版Excel最大行数是65536行,最大列数是256列
                            if (rowNum > 65536)
                            {
                                MessageBox.Show("行数超过Excel限制!");
                                return;
                            }
                            if (columnNum > 256)
                            {
                                MessageBox.Show("列数超过Excel限制!");
                                return;
                            }
                        }
                        else if (fileExt == ".xlsx")
                        {
                            //07版Excel最大行数是1048576行,最大列数是16384列
                            if (rowNum > 1048576)
                            {
                                MessageBox.Show("行数超过Excel限制!");
                                return;
                            }
                            if (columnNum > 16384)
                            {
                                MessageBox.Show("列数超过Excel限制!");
                                return;
                            }
                        }

                        ICell cell = dataRow.CreateCell(columnNum);
                        if (dgv.Rows[rowNum].Cells[columnNum].Value == null)
                        {
                            cell.SetCellType(CellType.Blank);
                        }
                        else
                        {
                            if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Int32"))
                            {
                                cell.SetCellValue(Convert.ToInt32(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.String"))
                            {
                                cell.SetCellValue(dgv.Rows[rowNum].Cells[columnNum].Value.ToString());
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Byte[]"))
                            {
                                // 检查是否为byte[]类型的图片数据
                                if (dgv.Rows[rowNum].Cells[columnNum].Value is byte[] byteArray && IsImage(byteArray))
                                {
                                    // 将byte[]转换为Image并插入Excel
                                    using (MemoryStream mm = new MemoryStream(byteArray))
                                    {
                                        Image img = Image.FromStream(mm);
                                        AddImageToSheet(workbook, sheet, img, rowNum + 1, columnNum);
                                    }
                                }
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Single"))
                            {
                                cell.SetCellValue(Convert.ToSingle(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Double"))
                            {
                                cell.SetCellValue(Convert.ToDouble(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Decimal"))
                            {
                                cell.SetCellValue(Convert.ToDouble(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.DateTime"))
                            {
                                cell.SetCellValue(Convert.ToDateTime(dgv.Rows[rowNum].Cells[columnNum].Value).ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.DBNull"))
                            {
                                cell.SetCellValue("");
                            }
                        }

                        //设置列宽
                        IRow currentRow;
                        if (sheet.GetRow(rowNum) == null)
                        {
                            currentRow = sheet.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = sheet.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;

                            if (columnWidth < length)
                            {
                                columnWidth = length + 10; //设置列宽数值
                            }
                        }
                        sheet.SetColumnWidth(columnNum, columnWidth * 256);

                        //单元格样式
                        dataRow.GetCell(columnNum).CellStyle = cellStyle;
                    }
                }
            }

            //保存为Excel文件                  
            workbook.Write(ms);
            FileStream file = new FileStream(saveFileName, FileMode.Create);
            workbook.Write(file);
            file.Close();
            workbook = null;
            ms.Close();
            ms.Dispose();

            //**程序结束计时**//
            sw.Stop();
            double totalTime = sw.ElapsedMilliseconds / 1000.0;

            MessageBox.Show(fileName + " 导出成功\n耗时" + totalTime + "s", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void AddImageToSheet(IWorkbook workbook, ISheet sheet, Image image, int rowNum, int colNum)
        {
            // 将Image转换为byte数组
            byte[] imageData;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                imageData = ms.ToArray();
            }

            // 获取图片索引
            int pictureIndex = workbook.AddPicture(imageData, GetPictureType(image.RawFormat));

            // 创建绘图容器
            IDrawing drawing = sheet.CreateDrawingPatriarch();

            // 创建锚点
            IClientAnchor anchor = new HSSFClientAnchor(0, 0, 0, 0, colNum, rowNum, colNum + 1, rowNum + 1);

            // 添加图片
            IPicture picture = drawing.CreatePicture(anchor, pictureIndex);

            // 调整图片大小以适应单元格
            picture.Resize();
        }

        private static PictureType GetPictureType(System.Drawing.Imaging.ImageFormat format)
        {
            if (format == System.Drawing.Imaging.ImageFormat.Jpeg)
                return PictureType.JPEG;
            if (format == System.Drawing.Imaging.ImageFormat.Png)
                return PictureType.PNG;
            if (format == System.Drawing.Imaging.ImageFormat.Bmp)
                return PictureType.BMP;
            if (format == System.Drawing.Imaging.ImageFormat.Gif)
                return PictureType.GIF;
            if (format == System.Drawing.Imaging.ImageFormat.Emf)
                return PictureType.EMF;
            if (format == System.Drawing.Imaging.ImageFormat.Wmf)
                return PictureType.WMF;

            return PictureType.JPEG; // 默认
        }

        private static bool IsImage(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    Image.FromStream(ms).Dispose();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion


        #region 检测文件是否被占用 
        /// <summary>
        /// 判定文件是否打开
        /// </summary>   
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);

        /// <summary>
        /// 检测文件被占用 
        /// </summary>
        /// <param name="FileNames">要检测的文件路径</param>
        /// <returns></returns>
        public static bool CheckFiles(string FileNames)
        {
            if (!File.Exists(FileNames))
            {
                //文件不存在
                return true;
            }
            IntPtr vHandle = _lopen(FileNames, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (vHandle == HFILE_ERROR)
            {
                //文件被占用
                return false;
            }
            //文件没被占用
            CloseHandle(vHandle);
            return true;
        }
        #endregion

        ////合法文件扩展名
        //private static List<string> extName = new List<string>() { ".xls", ".xlsx" };
        ///// <summary>
        ///// 导入Excel内容读取到List<T>中
        ///// </summary>
        ///// <param name="file">导入Execl文件</param>
        ///// <param name="sheetName">指定读取excel工作薄sheet的名称</param>
        ///// <returns>List<T></returns>
        //public static List<T> InputExcel(string file, string sheetName = null)
        //{
        //    //获取文件后缀名
        //    string type = Path.GetExtension(file.FileName);
        //    //判断是否导入合法文件
        //    if (!extName.Contains(type))
        //    {
        //        return null;
        //    }
        //    //转成为文件流
        //    MemoryStream ms = new MemoryStream();
        //    file.CopyTo(ms);
        //    ms.Seek(0, SeekOrigin.Begin);
        //    //实例化T数组
        //    List<T> list = new List<T>();
        //    //获取数据
        //    list = InputExcel(ms, sheetName);
        //    return list;
        //}

        /// <summary>
        /// 将Excel文件内容读取到List<T>中
        /// </summary>
        /// <param name="fileName">文件完整路径名</param>
        /// <param name="sheetName">指定读取excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名：true=是，false=否</param>
        /// <returns>List<T></returns>
        public static List<WStores> InputExcel(string fileName, string sheetName = null)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            //根据指定路径读取文件
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //实例化T数组
            List<WStores> list = new List<WStores>();
            //获取数据
            list = InputExcel(fs, sheetName);

            return list;
        }

        /// <summary>
        /// 将Excel文件内容读取到List<T>中
        /// </summary>
        /// <param name="fileStream">文件流</param>
        /// <param name="sheetName">指定读取excel工作薄sheet的名称</param>
        /// <returns>List<T></returns>
        private static List<WStores> InputExcel(Stream fileStream, string sheetName = null)
        {
            //创建Excel数据结构
            IWorkbook workbook = WorkbookFactory.Create(fileStream);
            //如果有指定工作表名称
            ISheet sheet = null;
            if (!string.IsNullOrEmpty(sheetName))
            {
                sheet = workbook.GetSheet(sheetName);
                //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                if (sheet == null)
                {
                    sheet = workbook.GetSheetAt(0);
                }
            }
            else
            {
                //如果没有指定的sheetName，则尝试获取第一个sheet
                sheet = workbook.GetSheetAt(0);
            }
            //实例化T数组
            List<WStores> list = new List<WStores>();
            if (sheet != null)
            {
                //一行最后一个cell的编号 即总的列数
                IRow cellNum = sheet.GetRow(0);
                int num = cellNum.LastCellNum;
                //获取泛型对象T的所有注解
                PropertyInfo[] peroperties = typeof(WStores).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                //每行转换为单个T对象
                for (int i = 1; i < sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    WStores obj = new WStores();
                    for (int j = 0; j < num; j++)
                    {
                        //行名称
                        var colName = cellNum.GetCell(j) + "";
                        string propName = "";
                        //去找注解对应的对象字段名
                        foreach (PropertyInfo property in peroperties)
                        {
                            object[] objs = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
                            if (objs.Length > 0 && ((DescriptionAttribute)objs[0]).Description == colName)
                            {
                                propName = property.Name;
                                //没有数据的单元格都默认是null
                                ICell cell = row.GetCell(j);
                                if (cell != null)
                                {
                                    var value = row.GetCell(j).ToString();
                                    //获取对象的属性类型
                                    //string str = property.PropertyType.FullName;                                        
                                    var propType = property.PropertyType;
                                    if (propType == typeof(string))
                                    {
                                        typeof(WStores).GetProperty(propName).SetValue(obj, value, null);
                                    }
                                    else if (propType == typeof(DateTime) || propType == typeof(DateTime?))
                                    {
                                        //如果等于空
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            typeof(WStores).GetProperty(propName).SetValue(obj, null, null);
                                        }
                                        else
                                        {
                                            DateTime pdt = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
                                            typeof(WStores).GetProperty(propName).SetValue(obj, pdt, null);
                                        }
                                    }
                                    else if (propType == typeof(bool))
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            typeof(WStores).GetProperty(propName).SetValue(obj, null, null);
                                        }
                                        else
                                        {
                                            bool pb = Convert.ToBoolean(value);
                                            typeof(WStores).GetProperty(propName).SetValue(obj, pb, null);
                                        }

                                    }
                                    else if (propType == typeof(Int16) || propType == typeof(Int16?))
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            typeof(WStores).GetProperty(propName).SetValue(obj, null, null);
                                        }
                                        else
                                        {
                                            short pi16 = Convert.ToInt16(value);
                                            typeof(WStores).GetProperty(propName).SetValue(obj, pi16, null);
                                        }
                                    }
                                    else if (propType == typeof(Int32) || propType == typeof(Int32?))
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            typeof(WStores).GetProperty(propName).SetValue(obj, null, null);
                                        }
                                        else
                                        {
                                            int pi32 = Convert.ToInt32(value);
                                            typeof(WStores).GetProperty(propName).SetValue(obj, pi32, null);
                                        }

                                    }
                                    else if (propType == typeof(Double) || propType == typeof(Double?))
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            typeof(WStores).GetProperty(propName).SetValue(obj, null, null);
                                        }
                                        else
                                        {
                                            Double pi32 = Convert.ToDouble(value);
                                            typeof(WStores).GetProperty(propName).SetValue(obj, pi32, null);
                                        }

                                    }
                                    else if (propType == typeof(Int64) || propType == typeof(Int64?))
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            typeof(WStores).GetProperty(propName).SetValue(obj, null, null);
                                        }
                                        else
                                        {
                                            long pi64 = Convert.ToInt64(value);
                                            typeof(WStores).GetProperty(propName).SetValue(obj, pi64, null);
                                        }
                                    }
                                    else if (propType == typeof(byte[]))
                                    {
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            typeof(WStores).GetProperty(propName).SetValue(obj, null, null);
                                        }
                                        else
                                        {
                                            long pi64 = Convert.ToInt64(value);
                                            typeof(WStores).GetProperty(propName).SetValue(obj, pi64, null);
                                        }
                                    }
                                    else if (propType == typeof(byte))
                                    {
                                        byte pb = Convert.ToByte(value);
                                        typeof(WStores).GetProperty(propName).SetValue(obj, pb, null);
                                    }
                                    else
                                    {
                                        typeof(WStores).GetProperty(propName).SetValue(obj, null, null);
                                    }
                                }
                            }

                        }
                    }
                    list.Add(obj);
                }
            }
            return list;
        }

    }
}
