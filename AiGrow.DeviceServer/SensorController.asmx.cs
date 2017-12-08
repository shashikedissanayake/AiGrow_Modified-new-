using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace AiGrow.DeviceServer
{
    /// <summary>
    /// Summary description for SensorController
    /// </summary>
    [WebService(Namespace = "http://aigrow.lk/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SensorController : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string AddDeviceToBayLine(string deviceID, string status)
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetDeviceJSONTest()
        {
            BaseDeviceRequest request = new BaseDeviceRequest();
            request.data = "1.2";
            request.deviceID = "BR_009:BRL_003:BRLL_001:BRLLD_002";
            request.command = "dataEntry";
            request.requestID = "0000072";
            request.received_time = "2017-12-33 21:32:43";

            //List<BayRequest> baylist1 = new List<BayRequest>();
            //List<BayDeviceRequest> devicelist1 = new List<BayDeviceRequest>();
            //List<BayLineRequest> linelist1 = new List<BayLineRequest>();
            //List<BayLineDeviceRequest> lineDevicelist1 = new List<BayLineDeviceRequest>();
            //List<BayRackRequest> racklist1 = new List<BayRackRequest>();
            //List<GreenhouseDeviceRequest> grDevicelist1 = new List<GreenhouseDeviceRequest>();
            //List<BayRackDeviceRequest> bayRackDevicelist1 = new List<BayRackDeviceRequest>();
            //List<BayRackLevelRequest> bayRackLevellist1 = new List<BayRackLevelRequest>();
            //List<BayRackLevelDeviceRequest> bayRacklevelDeviceList1 = new List<BayRackLevelDeviceRequest>();
            //List<BayRackLevelLineRequest> bayRackLevelLinelist1 = new List<BayRackLevelLineRequest>();
            //List<BayRackLevelLineDeviceRequest> bayRacklevelLineDevicelist1 = new List<BayRackLevelLineDeviceRequest>();

            //GreenhouseRequest gr1 = new GreenhouseRequest();
            //GreenhouseDeviceRequest gdr1 = new GreenhouseDeviceRequest();
            //GreenhouseDeviceRequest gdr2 = new GreenhouseDeviceRequest();
            //BayRequest br1 = new BayRequest();
            //BayRequest br2 = new BayRequest();
            //BayDeviceRequest bdr1 = new BayDeviceRequest();
            //BayDeviceRequest bdr2 = new BayDeviceRequest();
            //BayLineDeviceRequest bldr1 = new BayLineDeviceRequest();
            //BayLineDeviceRequest bldr2 = new BayLineDeviceRequest();
            //BayLineRequest blr1 = new BayLineRequest();
            //BayLineRequest blr2 = new BayLineRequest();
            //BayRackRequest brr1 = new BayRackRequest();
            //BayRackRequest brr2 = new BayRackRequest();
            //BayRackDeviceRequest brdr1 = new BayRackDeviceRequest();
            //BayRackLevelRequest brlr1 = new BayRackLevelRequest();
            //BayRackLevelRequest brlr2 = new BayRackLevelRequest();
            //BayRackLevelDeviceRequest brld1 = new BayRackLevelDeviceRequest();
            //BayRackLevelDeviceRequest brld2 = new BayRackLevelDeviceRequest();
            //BayRackLevelLineRequest brllr1 = new BayRackLevelLineRequest();
            //BayRackLevelLineDeviceRequest brlldr1 = new BayRackLevelLineDeviceRequest();
            //BayRackLevelLineDeviceRequest brlldr2 = new BayRackLevelLineDeviceRequest();

            //brllr1.level_line_unique_id = "BR_009:BRL_003:BRLL_001";
            //brllr1.level_id = 4;
            //brllr1.listOfBayRackLevelLineDevices = bayRacklevelLineDevicelist1;
            //bayRackLevelLinelist1.Add(brllr1);

            //brlldr1.default_unit = "zxc";
            //brlldr1.device_type = "pump";
            //brlldr1.device_unique_id = "BR_009:BRL_003:BRLL_001:BRLLD_001";
            //brlldr1.io_type = "out";
            //brlldr1.line_id = 1;
            //brlldr1.status = "active";
            //brlldr2.default_unit = "zxc";
            //brlldr2.device_type = "pump";
            //brlldr2.device_unique_id = "BR_009:BRL_003:BRLL_001:BRLLD_002";
            //brlldr2.io_type = "out";
            //brlldr2.line_id = 1;
            //brlldr2.status = "active";
            //bayRacklevelLineDevicelist1.Add(brlldr1);
            //bayRacklevelLineDevicelist1.Add(brlldr2);

            //brld1.command = "registerBayRackLineDevice";
            //brld1.default_unit = "zxc";
            //brld1.device_type = "pump";
            //brld1.level_device_unique_id = "BR_009:BRL_003:BRLD_001";
            //brld1.io_type = "out";
            //brld1.level_id = 4;
            //brld1.status = "active";
            //brld2.default_unit = "zxc";
            //brld2.device_type = "pump";
            //brld2.level_device_unique_id = "BR_009:BRL_003:BRLD_002";
            //brld2.io_type = "out";
            //brld2.level_id = 4;
            //brld2.status = "active";
            //bayRacklevelDeviceList1.Add(brld1);
            //bayRacklevelDeviceList1.Add(brld2);

            //brlr1.bay_rack_level_unique_id = "BR_009:BRL_003";
            //brlr1.rack_id = 11;
            //brlr1.listOfLevelDevices = bayRacklevelDeviceList1;
            //brlr1.listOfLevelLines = bayRackLevelLinelist1;
            //brlr2.bay_rack_level_unique_id = "BR_009:BRL_004";
            //brlr2.rack_id = 11;
            //brlr2.listOfLevelDevices = bayRacklevelDeviceList1;
            //brlr2.listOfLevelLines = bayRackLevelLinelist1;
            //bayRackLevellist1.Add(brlr1);
            //bayRackLevellist1.Add(brlr2);

            //brdr1.command = "registerBayRackDevice";
            //brdr1.default_unit = "zxc";
            //brdr1.device_type = "pump";
            //brdr1.device_unique_id = "BRD_005";
            //brdr1.io_type = "out";
            //brdr1.rack_id = 1;
            //brdr1.status = "active";
            //brdr1.requestID = "request_111";
            //bayRackDevicelist1.Add(brdr1);

            //gdr1.greenhouse_device_unique_id = "GD_007";
            //gdr1.greenhouse_device_name = "light intensity sensor";
            //gdr1.device_type = "sensor";
            //gdr1.io_type = "in";
            //gdr1.default_unit = "asd";
            //gdr1.greenhouse_id = 2;
            //gdr1.status = "up";
            //gdr2.greenhouse_device_unique_id = "GD_008";
            //gdr2.greenhouse_device_name = "light intensity sensor";
            //gdr2.device_type = "sensor";
            //gdr2.io_type = "in";
            //gdr2.default_unit = "asd";
            //gdr2.greenhouse_id = 2;
            //gdr2.status = "up";

            //grDevicelist1.Add(gdr1);
            //grDevicelist1.Add(gdr2);

            //brr1.command = "registerBayRack";
            //brr1.bay_id = 4;
            //brr1.bay_rack_unique_id = "BR_009";
            //brr2.command = "registerBayRack";
            //brr2.bay_id = 4;
            //brr2.bay_rack_unique_id = "BR_005";
            //brr1.listOfRackDevices = bayRackDevicelist1;
            //brr1.listOfRackLevels = bayRackLevellist1;
            //brr2.listOfRackDevices = bayRackDevicelist1;

            //bldr1.bay_line_device_name = "pump";
            //bldr1.bay_line_id = 3;
            //bldr1.bay_line_device_unique_id = "BLD_008";
            //bldr1.device_type = "actuator";
            //bldr1.io_type = "out";
            //bldr1.status = "down";
            //bldr1.command = "registerBayLineDevice";
            //bldr1.default_unit = "litres";
            //bldr2.bay_line_device_name = "pump";
            //bldr2.bay_line_id = 3;
            //bldr2.bay_line_device_unique_id = "BLD_00677";
            //bldr2.device_type = "actuator";
            //bldr2.io_type = "out";
            //bldr2.status = "down";
            //bldr2.command = "registerBayLineDevice";
            //bldr2.default_unit = "litres";

            //bdr1.bay_device_unique_id = "BD_0034";
            //bdr1.bay_device_name = "sensor_2";
            //bdr1.device_type = "humiditySensor";
            //bdr1.io_type = "in";
            //bdr1.bay_id = 4;
            //bdr1.status = "up";
            //bdr2.bay_device_unique_id = "BD_0023";
            //bdr2.bay_device_name = "sensor_2";
            //bdr2.device_type = "humiditySensor";
            //bdr2.io_type = "in";
            //bdr2.bay_id = 4;
            //bdr2.status = "up";

            //br1.greenhouse_id = 1;
            //br1.bay_unique_id = "B_0022";
            //br1.listOfBayDevices = devicelist1;
            //br2.greenhouse_id = 1;
            //br2.bay_unique_id = "B_0034";
            //br2.listOfBayDevices = devicelist1;


            //blr1.bay_id = 4;
            //blr1.bay_line_unique_id = "BL_0023";
            //blr1.command = "registerBayLine";

            //blr2.bay_id = 4;
            //blr2.bay_line_unique_id = "BL_00254";
            //blr2.command = "registerBayLine";

            //gr1.command = "registerGreenhouse";

            //devicelist1.Add(bdr1);
            //devicelist1.Add(bdr2);

            //linelist1.Add(blr2);
            //linelist1.Add(blr1);

            //lineDevicelist1.Add(bldr1);
            //lineDevicelist1.Add(bldr2);

            //racklist1.Add(brr2);
            //racklist1.Add(brr1);

            //br1.listOfBayRacks = racklist1;
            //br2.listOfBayRacks = racklist1;

            //blr1.listOfBayLineDevices = lineDevicelist1;
            //blr2.listOfBayLineDevices = lineDevicelist1;

            //br1.listOfBayDevices = devicelist1;
            //br2.listOfBayDevices = devicelist1;
            //br1.listOfBayLines = linelist1;
            //br2.listOfBayLines = linelist1;

            //baylist1.Add(br1);
            //baylist1.Add(br2);


            //gr1.listOfBays = baylist1;
            //gr1.listOfDevices = grDevicelist1;
            //gr1.requestID = "000001";
            //brdr1.requestID = "asd";
            //brr1.requestID = "request 0021";
            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(request));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void AddDeviceTest()
        {
            GreenhouseRequest gr = new GreenhouseRequest();
            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new GreenhouseRequest() { }));
        }
    }
}
