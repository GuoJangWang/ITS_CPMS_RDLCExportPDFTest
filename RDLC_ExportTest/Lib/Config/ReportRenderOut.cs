using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDLC_ExportTest.Lib.Config
{
    public struct ReportRenderOut
    {
        /// <summary>
        /// 警告信息
        /// </summary>
        public Microsoft.Reporting.NETCore.Warning[] Warnings;
        public string[] Streamids;
        /// <summary>
        /// 文件頭類型
        /// </summary>
        public string MimeType;
        /// <summary>
        /// 編碼格式
        /// </summary>
        public string Encoding;
        /// <summary>
        /// 文件後綴名
        /// </summary>
        public string Extension;
    }
}
