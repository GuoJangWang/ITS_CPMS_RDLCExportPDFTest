using RDLC_ExportTest.Lib;
using RDLC_ExportTest.Models;
using RDLC_ExportTest.Lib;

try
{

    Console.WriteLine($"開始時間{DateTime.Now}");

    List<RDLCTestModel> reports;

    reports = DBLib.GetDatas(10000);

    var rdlcPath = @$"C:\VS\GitHub\RDLC_ExportTest\RDLC_ExportTest\Report1.rdlc";
    var savePath = $"{AppDomain.CurrentDomain.BaseDirectory}File/Image{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
    ReportRDLC reportRDLC = new ReportRDLC(rdlcPath, savePath, ReportRDLC.FileType.Image);


    var datasetDic = new Dictionary<string, object>();
    //數據集1 “ReportModel”這個名字需要跟在rdlc模板裏定義好的名字相同
    datasetDic.Add("TT1", reports);


    reportRDLC.DataSources = datasetDic;

    //自定義參數列表
    var paramList = new List<Microsoft.Reporting.NETCore.ReportParameter>();
    paramList.Add(new Microsoft.Reporting.NETCore.ReportParameter("Title", "XXX報表"));//name 要與rdlc模板裏定義好的名字一樣
    reportRDLC.ReportParams = paramList;

    //reportRDLC.DeviceInfo = new ReportDeviceInfo { PageHeight = "10cm" };//定義報表頁面大小


    //修改類型 輸出PDF類型 文件後綴爲pdf
    reportRDLC.SaveType = ReportRDLC.FileType.PDF;

    Console.WriteLine(reportRDLC.SaveAsFile());
    Console.WriteLine(reportRDLC.RenderOut.MimeType);

    reportRDLC.Dispose();
    Console.WriteLine($"完畢");
    Console.WriteLine($"結束時間{DateTime.Now}");
    Console.Read();

}
catch
{

}

