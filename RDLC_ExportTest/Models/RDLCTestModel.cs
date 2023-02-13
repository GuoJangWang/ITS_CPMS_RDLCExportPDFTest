using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RDLC_ExportTest.Models
{
    public class RDLCTestModel_PayTP
    {
        public decimal Amount { get; set; }

        public string ListID { get; set; }

        public string AccountNo { get; set; }

        public string ChannelID { get; set; }

        public string ShortName { get; set; }

        public string ParkingLotID { get; set; }
        public string PaymentID { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string PaymentDate { get; set; }
        public string TradeNo { get; set; }
    }

    public class RDLCTestModel_CPMS
    {
        /// <summary>
        /// 報表排程執行紀錄Id
        /// </summary>
        [Key]
        [Display(Name = "報表排程執行紀錄Id")]
        public long ControlSetId { get; set; }

        /// <summary>
        /// 排程Id
        /// </summary>
        [Display(Name = "排程Id")]
        public int? ReportConfigId { get; set; }

        ///// <summary>
        ///// 報表類別
        ///// </summary>
        //[Display(Name = "報表類別")]
        //[Required]
        //public SystemEnum.ReportCategory ReportCategory { get; set; }

        /// <summary>
        /// 報表種類
        /// </summary>
        [Display(Name = "報表種類")]
        [MaxLength(10)]
        [Required]
        public string ReportTypeId { get; set; }

        /// <summary>
        /// 報表代碼
        /// </summary>
        [Display(Name = "報表代碼")]
        [MaxLength(10)]
        [Required]
        public string ReportId { get; set; }

        /// <summary>
        /// 萬家代號
        /// </summary>
        [Display(Name = "萬家代號")]
        [MaxLength(5)]
        public string? CompanyId { get; set; }

        ///// <summary>
        ///// 負責系統
        ///// </summary>
        //[Display(Name = "負責系統")]
        //[Required]
        //public SystemEnum.ControlSystem ControlSystem { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        [Display(Name = "排序方式")]
        public int? SortType { get; set; }

        ///// <summary>
        ///// 產檔週期
        ///// </summary>
        //[Display(Name = "產檔週期")]
        //public SystemEnum.ScheduleType? MakeCycle { get; set; }

        /// <summary>
        /// 報表名稱
        /// </summary>
        [Display(Name = "報表名稱")]
        [MaxLength(100)]
        public string ReportName { get; set; }

        /// <summary>
        /// 執行狀態
        /// ControlSetStatusEnum
        /// BatchControlSetStatusEnum
        /// ReportControlSetStatusEnum
        /// </summary>
        [Display(Name = "執行狀態")]
        [Required]
        public int ControlSetStatusenum { get; set; }

        /// <summary>
        /// 重試流程狀態
        /// </summary>
        public int? RetryControlSetStatusenum { get; set; }

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        [Display(Name = "錯誤訊息")]
        public string? Message { get; set; }

        /// <summary>
        /// 入扣帳日期起
        /// </summary>
        [Display(Name = "入扣帳日期起")]
        public DateTime DueDateStart { get; set; }

        /// <summary>
        /// 入扣帳日期迄
        /// </summary>
        [Display(Name = "入扣帳日期迄")]
        public DateTime DueDateEnd { get; set; }

        /// <summary>
        /// 結果檔檔名
        /// </summary>
        [Display(Name = "結果檔檔名")]
        [MaxLength(50)]
        public string ResultFileName { get; set; }

        /// <summary>
        /// 檔案名稱
        /// </summary>
        [Display(Name = "檔案名稱")]
        [MaxLength(100)]
        public string FileName { get; set; }

        /// <summary>
        /// 媒體檔格式
        /// </summary>
        [Display(Name = "媒體檔格式")]
        [MaxLength(30)]
        public string FileTypeconst { get; set; }

        /// <summary>
        /// 業務流程
        /// </summary>
        [Display(Name = "業務流程")]
        [MaxLength(30)]
        public string FlowTypeenum { get; set; }

        /// <summary>
        /// 匯入流水號
        /// </summary>
        [MaxLength(30)]
        [Display(Name = "匯入流水號")]
        public string ImportBatchNo { get; set; }

        /// <summary>
        /// 產檔時間
        /// </summary>
        [Display(Name = "產檔時間")]
        public DateTime? ReportTime { get; set; }

        /// <summary>
        /// 批次代號(批次專用)
        /// </summary>
        [DisplayName("批次代號")]
        [MaxLength(6)]
        public string BatchAppEnum { get; set; }

        /// <summary>
        /// 審批狀態碼
        /// </summary>
        [Display(Name = "審批狀態碼")]
        [MaxLength(20)]
        public string? ApprovalStatusCode { get; set; }
        /// <summary>
        /// 核決編號
        /// </summary>
        [Display(Name = "核決編號")]
        public long? ApprovalDataId { get; set; }

        /// <summary>
        /// 核決時間
        /// </summary>
        [Display(Name = "核決時間")]
        public DateTime? ApprovalTime { get; set; }

        /// <summary>
        /// 輸出主機批號
        /// </summary>
        [MaxLength(30)]
        [Display(Name = "輸出主機批號")]
        public string ExportBatchNo { get; set; }

    }

}
