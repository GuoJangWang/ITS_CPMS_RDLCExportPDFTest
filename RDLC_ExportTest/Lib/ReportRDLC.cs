using Microsoft.Reporting.NETCore;
using RDLC_ExportTest.Lib.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDLC_ExportTest.Lib
{
    public class ReportRDLC : IDisposable
    {
        #region 公共屬性
        /// <summary>
        /// 可生成的文件類型
        /// </summary>
        public enum FileType { Excel, PDF, Word, Image }
        /// <summary>
        /// *必填屬性 模板的絕對路徑 C:\TEST\REPORT.rdlc
        /// </summary>
        public string RdlcPath { get; set; }
        /// <summary>
        /// *必填屬性 文件生成後的保存路徑包括文件名,不需要後綴名（.xxx）,後綴名有代碼根據SaveType自動匹配（eg:保存成名字爲"MYFILE"的文件 C:\TEST\FILE\MYFILE）
        /// </summary>
        public string SavePath { get; set; }
        /// <summary>
        /// *必填屬性 需要生成的文件類型
        /// </summary>
        public FileType SaveType { get; set; }
        /// <summary>
        /// *可選屬性，假如你的rdlc模板不需要數據源  數據源 key對應數據集在模板裏面的數據集名字，value對應數據列表，一個rdlc允許有多個數據源
        /// </summary>
        public Dictionary<string, object> DataSources { get; set; }
        /// <summary>
        /// *可選屬性，假如你的rdlc模板不需要自定義參數  報表自定義參數 可以定義字符串 數字 布爾 直接把某個字段傳到報表裏面使用
        /// </summary>
        public List<ReportParameter> ReportParams { get; set; }
        /// <summary>
        /// *可選屬性 不設，使用默認 頁面大小格式設置
        /// </summary>
        public ReportDeviceInfo DeviceInfo { get; set; } = new ReportDeviceInfo();
        /// <summary>
        /// rdlc報表生成字節流時的一些輸出參數，執行GetStream(),SaveAsFile()方法後會進行賦值
        /// </summary>
        public ReportRenderOut RenderOut;
        #endregion
        public ReportRDLC(string rdlcPath, string savePaht, FileType saveType)
        {
            RdlcPath = rdlcPath;
            SavePath = savePaht;
            SaveType = saveType;
        }
        #region 公共方法
        /// <summary>
        /// 讀取本地rdlc模板，填充數據集和自定義的參數
        /// </summary>
        /// <returns>LocalReport</returns>
        public LocalReport GetLocalReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.EnableExternalImages = true;//設爲允許外部資源，不然無法加載圖片
            //localReport.DataSources.Clear();
            localReport.ReportPath = RdlcPath;
            if (ReportParams != null) localReport.SetParameters(ReportParams);
            //循環將數據集名字和數據源賦給報表主體對象 
            if (DataSources != null) foreach (var kvp in DataSources) localReport.DataSources.Add(new ReportDataSource(kvp.Key, kvp.Value));
            return localReport;
        }
        /// <summary>
        /// 根據SaveType，DeviceInfo，DataSources，ReportParams 返回字節流
        /// </summary>
        /// <returns></returns>
        public byte[] GetStream()
        {
            LocalReport localReport = GetLocalReport();
            try
            {
                //localReport.Refresh();
                string typeName = Enum.GetName(typeof(FileType), SaveType);
                string deviceInfo = $@"<DeviceInfo>
                                        <OutputFormat></OutputFormat>
                                        <PageWidth>{DeviceInfo.PageWidth ?? ""}</PageWidth>
                                        <PageHeight>{DeviceInfo.PageHeight ?? ""}</PageHeight>
                                        <MarginTop>{DeviceInfo.MarginTop ?? ""}</MarginTop>
                                        <MarginLeft>{DeviceInfo.MarginLeft ?? ""}</MarginLeft>
                                        <MarginRight>{DeviceInfo.MarginRight ?? ""}</MarginRight>
                                        <MarginBottom>{DeviceInfo.MarginBottom ?? ""}</MarginBottom>
                                       </DeviceInfo>";
                //Render方法介紹鏈接 https://docs.microsoft.com/zh-cn/previous-versions/ms252172(v=vs.140)
                //format Excel、PDF、Word 和 Image
                byte[] bytes = localReport.Render(typeName, deviceInfo, out RenderOut.MimeType, out RenderOut.Encoding, out RenderOut.Extension, out RenderOut.Streamids, out RenderOut.Warnings);
                return bytes;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif               
                return null;
            }
            finally
            {
                localReport.Dispose();
                localReport.ReleaseSandboxAppDomain();
                //System.GC.Collect();
            }
        }
        /// <summary>
        /// 根據SavePath，SaveType生成文件保存到硬盤
        /// </summary>
        /// <returns>返回保存結果</returns>
        public bool SaveAsFile()
        {
            var stream = GetStream();
            if (stream == null || stream.Length == 0) return false;
            var file = $"{SavePath}.{RenderOut.Extension}";
            var folder = Path.GetDirectoryName(file);
            if (!Directory.Exists(folder))//如果文件夾不存在則創建
            {
                Directory.CreateDirectory(folder);
            }
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                fs.Write(stream, 0, stream.Length);
                fs.Close();
            }
            return true;
        }
        #endregion

        public static string GetMd5(string md5string)
        {
            byte[] testEncrypt = Encoding.UTF8.GetBytes(md5string);
            //獲取加密服務  
            System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            //加密Byte[]數組  
            byte[] resultEncrypt = md5CSP.ComputeHash(testEncrypt);
            StringBuilder sub = new StringBuilder();
            for (int i = 0; i < resultEncrypt.Length; i++)
            {
                sub.Append(resultEncrypt[i].ToString("x2"));
            }

            return sub.ToString().ToUpper();
        }

        public void Dispose()
        {
            DataSources = null;
            ReportParams = null;
        }
    }
}
