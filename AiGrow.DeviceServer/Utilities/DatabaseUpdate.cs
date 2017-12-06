using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AiGrow.Business;
using AiGrow.Model;
using AiGrow.DeviceServer;
using System.Web.Script.Serialization;

namespace AiGrow.DeviceServer
{
    public class DatabaseUpdate
    {
        public bool registerGreenhouseDevice(GreenhouseDeviceRequest greenhouseDevice)
        {

            if (!(new AiGrow.Business.BL_GreenhouseDevice().doesDeviceExist(greenhouseDevice.greenhouse_device_unique_id)))
            {
                new BL_GreenhouseDevice().insert(new ML_GreenhouseDevice()
                {
                 default_unit = greenhouseDevice.default_unit,
                 device_type = greenhouseDevice.device_type,
                 greenhouse_device_name = greenhouseDevice.greenhouse_device_name,
                 greenhouse_device_unique_id = greenhouseDevice.greenhouse_device_unique_id,
                 greenhouse_id = greenhouseDevice.greenhouse_id,
                 io_type = greenhouseDevice.io_type,
                 status = greenhouseDevice.status
                });
                return true;
            }
            else
            {
                BaseResponse response = new BaseResponse();
                response.success = false;
                response.errorMessage = UniversalProperties.DUPLICATE_GREENHOUSE_DEVICE;
                response.errorCode = UniversalProperties.EC_RegistrationError;
                response.requestID = greenhouseDevice.requestID;
                response.deviceID = greenhouseDevice.greenhouse_device_unique_id;
                string responseJSON = new JavaScriptSerializer().Serialize(response);
                new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseJSON);
                return false;
            }
        }

        public bool registerBayDevice(BayDeviceRequest bayDevice)
        {

            if (!(new AiGrow.Business.BL_BayDevice().doesDeviceExist(bayDevice.bay_device_unique_id)))
            {
                new BL_BayDevice().insert(new ML_BayDevice()
                {
                    bay_device_unique_id = bayDevice.bay_device_unique_id,
                    bay_device_name = bayDevice.bay_device_name,
                    device_type = bayDevice.device_type,
                    io_type = bayDevice.io_type,
                    bay_id = bayDevice.bay_id,
                    default_unit = bayDevice.default_unit,
                    status = bayDevice.status
                });
                return true;
            }
            else
            {
                BaseResponse response = new BaseResponse();
                response.success = false;
                response.errorMessage = UniversalProperties.DUPLICATE_BAY_DEVICE;
                response.errorCode = UniversalProperties.EC_RegistrationError;
                response.requestID = bayDevice.requestID;
                response.deviceID = bayDevice.bay_device_unique_id;
                string responseJSON = new JavaScriptSerializer().Serialize(response);
                new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseJSON);
                return false;
            }
        }

        public void registerBay(BayRequest bay)
        {

            if (!(new AiGrow.Business.BL_Bay().doesBayExist(bay.bay_unique_id)))
            {
                new BL_Bay().insert(new ML_Bay()
                {
                    bay_unique_id = bay.bay_unique_id,
                    greenhouse_id = bay.greenhouse_id
                });
            }
            else
            {
                BaseResponse response = new BaseResponse();
                response.success = false;
                response.errorMessage = UniversalProperties.DUPLICATE_BAY;
                response.errorCode = UniversalProperties.EC_RegistrationError;
                response.requestID = bay.requestID;
                response.deviceID = bay.bay_unique_id;
                string responseJSON = new JavaScriptSerializer().Serialize(response);
                new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseJSON);
            }
        }
        public void registerBayLine(BayLineRequest bayLine)
        {

            if (!(new AiGrow.Business.BL_BayLine().doesBayLineExist(bayLine.bay_line_unique_id)))
            {
                new BL_BayLine().insert(new ML_BayLine()
                {
                    bay_line_unique_id = bayLine.bay_line_unique_id,
                    bay_id = bayLine.bay_id
                });
            }
            else
            {
                BaseResponse response = new BaseResponse();
                response.success = false;
                response.errorMessage = UniversalProperties.DUPLICATE_BAY_LINE;
                response.errorCode = UniversalProperties.EC_RegistrationError;
                response.deviceID = bayLine.bay_line_unique_id;
                response.requestID = bayLine.requestID;
                string responseJSON = new JavaScriptSerializer().Serialize(response);
                new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseJSON);
            }
        }
        public void registerBayRack(BayRackRequest bayRack)
        {

            if (!(new AiGrow.Business.BL_BayRack().doesBayRackExist(bayRack.bay_rack_unique_id)))
            {
                new BL_BayRack().insert(new ML_BayRack()
                {
                    bay_id = bayRack.bay_id,
                    rack_unique_id = bayRack.bay_rack_unique_id
                });
            }
            else
            {
                BaseResponse response = new BaseResponse();
                response.success = false;
                response.errorMessage = UniversalProperties.DUPLICATE_BAY_RACK;
                response.requestID = bayRack.requestID;
                response.deviceID = bayRack.bay_rack_unique_id;
                response.errorCode = UniversalProperties.EC_RegistrationError;
                string responseJSON = new JavaScriptSerializer().Serialize(response);
                new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseJSON);
            }
        }
        public bool registerBayRackDevice(BayRackDeviceRequest rackDevice)
        {

            if (!(new AiGrow.Business.BL_BayRackDevice().doesDeviceExist(rackDevice.device_unique_id)))
            {
                new BL_BayRackDevice().insert(new ML_BayRackDevice()
                {
                 default_unit = rackDevice.default_unit,
                 device_type = rackDevice.device_type,
                 device_unique_id = rackDevice.device_unique_id,
                 io_type = rackDevice.io_type,
                 rack_id = rackDevice.rack_id,
                 status = rackDevice.status
                });
                return true;
            }
            else
            {
                BaseResponse response = new BaseResponse();
                response.success = false;
                response.errorMessage = UniversalProperties.DUPLICATE_BAY_RACK_DEVICE;
                response.errorCode = UniversalProperties.EC_RegistrationError;
                response.requestID = rackDevice.requestID;
                response.deviceID = rackDevice.device_unique_id;
                string responseJSON = new JavaScriptSerializer().Serialize(response);
                new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseJSON);
                return false;
            }
        }
        public bool registerBayLineDevice(BayLineDeviceRequest bayLineDevice)
        {

            if (!(new AiGrow.Business.BL_BayLineDevice().doesDeviceExist(bayLineDevice.bay_line_device_unique_id)))
            {
                new BL_BayLineDevice().insert(new ML_BayLineDevice()
                {
                    bay_line_device_unique_id = bayLineDevice.bay_line_device_unique_id,
                    bay_line_device_name = bayLineDevice.bay_line_device_name,
                    default_unit = bayLineDevice.default_unit,
                    device_type = bayLineDevice.device_type,
                    io_type = bayLineDevice.io_type,
                    line_id = bayLineDevice.bay_line_id,
                    status = bayLineDevice.status
                });
                return true;
            }
            else
            {
                BaseResponse response = new BaseResponse();
                response.success = false;
                response.errorMessage = UniversalProperties.DUPLICATE_BAY_LINE_DEVICE;
                response.errorCode = UniversalProperties.EC_RegistrationError;
                response.requestID = bayLineDevice.requestID;
                response.deviceID = bayLineDevice.bay_line_device_unique_id;
                string responseJSON = new JavaScriptSerializer().Serialize(response);
                new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseJSON);
                return false;
            }
        }
        public void bayDeviceDataEntry(BaseDeviceRequest data)
        {
            string device = (data.deviceID).getUniqueID();
            DateTime t = DateTime.Now;
            string time = t.ToString(UniversalProperties.MySQLDateFormat);
            new BL_BayDeviceData().insert(new ML_BayDeviceData()
            {
                received_time = time,
                device_unique_id = device,
                data = data.data,
                data_unit = data.data_unit
            });
        }

        public void greenhouseDeviceDataEntry(BaseDeviceRequest data)
        {
            string device = (data.deviceID).getUniqueID();
            DateTime t = DateTime.Now;
            string time = t.ToString(UniversalProperties.MySQLDateFormat);
            new BL_GreenhouseDeviceData().insert(new ML_GreenhouseDeviceData()
            {
                received_time = time,
                device_unique_id = device,
                data = data.data,
                data_unit = data.data_unit
            });
        }
        public void bayLineDeviceDataEntry(BaseDeviceRequest data)
        {
            string device = (data.deviceID).getUniqueID();
            DateTime t = DateTime.Now;
            string time = t.ToString(UniversalProperties.MySQLDateFormat);
            new BL_BayLineDeviceData().insert(new ML_BayLineDeviceData()
            {
                received_time = time,
                device_unique_id = device,
                data = data.data,
                data_unit = data.data_unit
            });
        }
        public void bayRackDeviceDataEntry(BaseDeviceRequest data)
        {
            string device = (data.deviceID).getUniqueID();
            DateTime t = DateTime.Now;
            string time = t.ToString(UniversalProperties.MySQLDateFormat);
            new BL_BayRackDeviceData().insert(new ML_BayRackDeviceData()
            {
                received_time = time,
                device_unique_id = device,
                data = data.data,
                data_unit = data.data_unit
            });
        }

    }
}