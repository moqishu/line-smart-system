using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace LINE.SMA.Infrastructure
{
    public class NPOIExcel
    {
        public static bool DataSetToExcel(DataSet ds, string Path)
        {
            bool result = false;
            FileStream fs = null;
            XSSFWorkbook workbook = new XSSFWorkbook();
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet(ds.Tables[i].TableName);

                XSSFCellStyle dateStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFDataFormat format = (XSSFDataFormat)workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                int rowIndex = 0;

                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 0)
                {
                    #region 列头及样式
                    {
                        XSSFRow headerRow = (XSSFRow)sheet.CreateRow(0);
                        XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                        //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        XSSFFont font = (XSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        ////自定义表头
                        string name = ds.Tables[i].TableName;
                        //for (var j = 0; j < dataList[name].ToArray().Count(); j++)
                        //{
                        //    headerRow.CreateCell(j).SetCellValue(dataList[name].ToArray()[j]);
                        //    headerRow.GetCell(j).CellStyle = headStyle;
                        //}
                    }
                    #endregion

                    rowIndex = 1;
                }
                #endregion

                foreach (DataRow row in ds.Tables[i].Rows)
                {
                    XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                    #region 填充内容
                    foreach (DataColumn column in ds.Tables[i].Columns)
                    {
                        XSSFCell newCell = (XSSFCell)dataRow.CreateCell(column.Ordinal);
                        string type = row[column].GetType().FullName.ToString();
                        newCell.SetCellValue(GetValue(row[column].ToString(), type));
                    }
                    #endregion
                    rowIndex++;
                }
            }

            using (fs = File.OpenWrite(Path))
            {
                workbook.Write(fs);//向打开的这个xls文件中写入数据
                result = true;
            }
            return result;
        }

        private static string GetValue(string cellValue, string type)
        {
            object value = string.Empty;
            switch (type)
            {
                case "System.String"://字符串类型
                    value= cellValue;
                    break;
                case "System.DateTime"://日期类型
                    System.DateTime dateV;
                    System.DateTime.TryParse(cellValue, out dateV);
                    value=dateV;
                    break;
                case "System.Boolean"://布尔型
                    bool boolV = false;
                    bool.TryParse(cellValue, out boolV);
                    value = boolV;
                    break;
                case "System.Int16"://整型
                case "System.Int32":
                case "System.Int64":
                case "System.Byte":
                    int intV = 0;
                    int.TryParse(cellValue, out intV);
                    value=intV;
                    break;
                case "System.Decimal"://浮点型
                case "System.Double":
                    double doubV = 0;
                    double.TryParse(cellValue, out doubV);
                    value=doubV;
                    break;
                case "System.DBNull"://空值处理
                    value = string.Empty;
                    break;
                default:
                    value = string.Empty;
                    break;
            }
            return value.ToString();
        }
    }
}
