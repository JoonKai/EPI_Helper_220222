using HellsysLib.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsysLib.Helpers
{
    public class ExcelHelper
    {
        public List<string> GetExcelFiles(string path)
        {
            CopyExcelFiles copyXlFile = new CopyExcelFiles();
            return copyXlFile.GetExcelFiles(path);
        }
    }
}
