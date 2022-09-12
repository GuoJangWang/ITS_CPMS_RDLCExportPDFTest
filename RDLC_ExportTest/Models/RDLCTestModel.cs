using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDLC_ExportTest.Models
{
    public class RDLCTestModel
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
}
