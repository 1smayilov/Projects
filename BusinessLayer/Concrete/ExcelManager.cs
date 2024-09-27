using BusinessLayer.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] ExcelList<T>(List<T> entity) where T : class
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Səhifə 1");
            workSheet.Cells["A1"].LoadFromCollection(entity,true,OfficeOpenXml.Table.TableStyles.Light10);
            return excel.GetAsByteArray();
        }
    }
}
