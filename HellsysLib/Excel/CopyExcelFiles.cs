using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HellsysLib.Excel
{
    public class CopyExcelFiles
    {
        #region Props
        public DirectoryInfo DestExcelPath { get => new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "TempExcel"); }
        public DirectoryInfo SourceExcelPath { get; set; }
        public FileInfo[] Files { get; set; }
        public List<string> SourceExcelFileList = null;
        public List<string> DestExcelFileList = null;
        #endregion

        /// <summary>
        /// path 에서 모든 Excel File List를 얻어 온다.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> GetExcelFiles(string path)
        {
            SourceExcelFileList = new List<string>();
            DestExcelFileList = new List<string>();
            SourceExcelPath = new DirectoryInfo(path);

            if (!DestExcelPath.Exists)
                DestExcelPath.Create();
            Files = SourceExcelPath.GetFiles();
            if(Files.Length == 0)
            {
                MessageBox.Show("파일없음");
                return null;
            }
            else
            {
                foreach (FileInfo excelFile in SourceExcelPath.GetFiles())
                {
                    if(excelFile.Extension.ToLower().CompareTo(".xlsm")==0 && !excelFile.ToString().Contains("~"))
                    {
                        SourceExcelFileList.Add(SourceExcelPath.FullName + "\\" + excelFile.Name);
                    }
                }
                copyMyAppTempFolder(SourceExcelFileList);
                foreach (FileInfo excelFile in DestExcelPath.GetFiles())
                {
                    DestExcelFileList.Add(excelFile.FullName.ToString());
                }
            }
            return DestExcelFileList;
        }
        
        /// <summary>
        /// source => MyApp로 excel file을 copy한다.
        /// </summary>
        /// <param name="source"></param>
        private void copyMyAppTempFolder(List<string> source)
        {
            if (source == null)
                return;
            foreach (string excelFile in source)
            {
                File.Copy(excelFile, DestExcelPath + "\\" + Path.GetFileName(excelFile).ToString(), true);
            }
        }
    }
}
