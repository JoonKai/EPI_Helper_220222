using HellsysLib.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Hellsys.Hell_UnitControls
{
    /// <summary>
    /// HellsysLineGrid.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HellsysLineGrid : UserControl
    {

        public List<string> ExcelList { get; set; }

        public HellsysLineGrid()
        {
            InitializeComponent();
        }

        private void btnLoadWorkLog_Click(object sender, RoutedEventArgs e)
        {
            GetExcelFiles();
        }

        private void GetExcelFiles()
        {
            ExcelList = Helper.XL.GetExcelFiles(@"T:\01_EPI생산팀\01_EPI제조파트\01_업무관리\01_업무인수인계일지\01_업무인수인계일지OP용");

            if (ExcelList == null)
                return;

            lbxExcelFIleList = null;
            foreach (var item in ExcelList)
            {
                lbxExcelFIleList.Items.Add(Path.GetFileName(item).ToString());
            }
        }
    }
}
