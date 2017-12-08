using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AiGrow.Business;
using System.IO;
using System.Web.Hosting;

namespace AiGrow.DeviceServer
{
    public static class ApplicationUtilities
    {
        public static bool IsEmpty(this string str)
        {
            return str == null ? string.IsNullOrEmpty(str) : string.IsNullOrEmpty(str.Trim());
        }
        //public static int getDeviceID(this string deviceID)
        //{
        //    #region unique id split

        //    //string[] components = deviceID.Split(':');
        //    //foreach (string id in components)
        //    //{
        //    //    string[] tokens = id.Split('_');
        //    //    switch (tokens[0])
        //    //    {
        //    //        case "G":
        //    //            if ((new AiGrow.Business.BL_Greenhouse().doesGreenhouseExist(id)))
        //    //                break;
        //    //            else
        //    //                return -1;

        //    //        case "B":
        //    //            if ((new AiGrow.Business.BL_Bay().doesBayExist(id)))
        //    //                break;
        //    //            else
        //    //                return -1;
        //    //        case "BL":
        //    //            if ((new AiGrow.Business.BL_BayLine().doesBayLineExist(id)))
        //    //                break;
        //    //            else
        //    //                return -1;
        //    //        case "GD":
        //    //            if ((new AiGrow.Business.BL_GreenhouseDevice().doesDeviceExist(id)))
        //    //                return 1;
        //    //            else
        //    //                return -1;

        //    //        case "BD":
        //    //            if ((new AiGrow.Business.BL_BayDevice().doesDeviceExist(id)))
        //    //                return 2;
        //    //            else
        //    //                return -1;
        //    //        case "BLD":
        //    //            if ((new AiGrow.Business.BL_BayLineDevice().doesDeviceExist(id)))
        //    //                return 3;
        //    //            else
        //    //                return -1;
        //    //        case "BR":
        //    //            if ((new AiGrow.Business.BL_BayRack().doesBayRackExist(id)))
        //    //                break;
        //    //            else
        //    //                return -1;
        //    //        case "BRD":
        //    //            if ((new AiGrow.Business.BL_BayRackDevice().doesDeviceExist(id)))
        //    //                return 4;
        //    //            else
        //    //                return -1;


        //    //        case "BLD":
        //    //            break;

        //    //        case "BL":
        //    //            break;

        //    //        case "BR":
        //    //            break;

        //    //        case "BRL":
        //    //            break;

        //    //        case "BRD":
        //    //            break;

        //    //        case "BRLD":
        //    //            break;

        //    //        case "BRLL":
        //    //            break;

        //    //        case "BRLLD":
        //    //            break;
        //    //        default:
        //    //            break;
        //    //    }
        //    //}
        //    //return -1; 
        //    #endregion
        //}
        public static string getUniqueID(this string deviceID)
        {
            string[] components = deviceID.Split(':');
            string device = components[components.Length - 1];
            return device;
        }
        public static void writeMsg(string msg)
        {
            using (StreamWriter testData = new StreamWriter(HostingEnvironment.MapPath("~/log.txt"), true))
            {
                testData.WriteLine(msg); // Write the file.
            }
        }
    }
}