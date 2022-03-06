using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsysLib.Helpers
{
    public static class Helper
    {
        public static ExcelHelper XL{ get; private set; }
        static Helper()
        {
            XL = new ExcelHelper();
        }
    }
}
