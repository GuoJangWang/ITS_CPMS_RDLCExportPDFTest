using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDLC_ExportTest.Lib.Config
{
    public class ReportDeviceInfo
    {
        /// <summary>
        /// 頁面寬度 (單位 cm\in)
        /// </summary>
        public string PageWidth { get; set; }// = "8.5in";
        /// <summary>
        /// 頁面高度 (單位 cm\in)
        /// </summary>
        public string PageHeight { get; set; }// = "8.27in";
        /// <summary>
        /// 左邊距 (單位 cm\in)
        /// </summary>
        public string MarginLeft { get; set; } //= "0.2in";
        /// <summary>
        /// 右邊距 (單位 cm\in)
        /// </summary>
        public string MarginRight { get; set; }// = "0.2in";
        /// <summary>
        /// 上邊距 (單位 cm\in)
        /// </summary>
        public string MarginTop { get; set; } //= "0.2in";
        /// <summary>
        /// 下邊距 (單位 cm\in)
        /// </summary>
        public string MarginBottom { get; set; }// = "0.2in";
    }
}
