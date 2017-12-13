using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using System.Web.Script.Serialization;
using System.Text;
using System.Threading;

namespace AiGrow.DeviceServer
{
    public class MQTTHandler
    {
        MqttClient client;
        //called in global.asax
        public void Initiate()
        {
            ApplicationUtilities.writeMsg("Initiating...");
            Subscribe();
        }
        public void Subscribe()
        {
            try
            {
                string IotEndpoint = "a2o8dyvqdg4v1r.iot.us-west-2.amazonaws.com";
                int BrokerPort = 8883;

                string path = System.Web.Hosting.HostingEnvironment.MapPath("/");
                string path2 = System.Web.Hosting.HostingEnvironment.MapPath("/root.pem");

                X509Certificate2 clientCert = new X509Certificate2(path + "070bf213e6-certificate.pem.pfx", "", X509KeyStorageFlags.MachineKeySet);
                X509Certificate caCert = X509Certificate.CreateFromSignedFile(path2);


                client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);
                //var client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);

                client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;
                client.ConnectionClosed += client_ConnectionClosed;
                //client.Settings.TimeoutOnReceiving = 1;

                client.Connect("listener");


                client.Subscribe(new[] { UniversalProperties.MQTT_topic }, new[] { uPLibrary.Networking.M2Mqtt.Messages.MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                ApplicationUtilities.writeMsg("subscribed: " + DateTime.Now.ToString());

                //while (true)  
                //{
                //    //listen good!
                //}
            }
            catch (Exception ex)
            {
                //ApplicationUtilities.writeMsg("ERROR: 1 " + ex.Message.ToString());
                //client.Disconnect();
                ApplicationUtilities.writeMsg("ERROR: " + ex.Message.ToString());
                Thread.Sleep(3000);

                Initiate();
            }
        }
        private void client_ConnectionClosed(object sender, EventArgs e)
        {
            ApplicationUtilities.writeMsg("Connection closed: " + DateTime.Now.ToString());
            ApplicationUtilities.writeMsg("***********************************************\n ");
            //((MqttClient)sender).Disconnect();
            Subscribe();
        }

        public void ClientMqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            BaseResponse response = new BaseResponse();
            bool msgSent = false;
            string JSONMessage = System.Text.Encoding.UTF8.GetString(e.Message);
            ApplicationUtilities.writeMsg("\nreceived: " + DateTime.Now.ToString());
            try
            {
                BaseRequest request = new JavaScriptSerializer().Deserialize<BaseRequest>(JSONMessage);
                if (request.requestID == "response")
                {
                    return;
                }
                if (request.requestID == null)
                {
                    response.errorMessage = UniversalProperties.invalidMqttRequest;
                    response.errorCode = UniversalProperties.EC_InvalidMqttRequest;
                    response.success = false;
                    response.requestID = "response";
                    string responseJSON = new JavaScriptSerializer().Serialize(response);
                    new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseJSON);
                    return;
                }
                if (request.command == null)
                {
                    return;
                }

                switch (request.command)
                {
                    case UniversalProperties.data:
                        #region identifying device
                        //int device_id = (request.deviceID).getDeviceID();
                        //if (device_id < 0)
                        //{
                        //    response.errorMessage = UniversalProperties.UNKNOWN_COMPONENT;
                        //    response.errorCode = UniversalProperties.EC_UnknownComponent;
                        //    response.requestID = request.requestID;
                        //    response.deviceID = request.deviceID;
                        //    response.success = false;
                        //}
                        //else if (device_id == UniversalProperties.greenhouse_device)
                        //{
                        //    BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                        //    new DatabaseUpdate().greenhouseDeviceDataEntry(dataRequest);
                        //    response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                        //    response.success = true;
                        //    response.requestID = dataRequest.requestID;
                        //    response.deviceID = dataRequest.deviceID;
                        //}
                        //else if (device_id == UniversalProperties.bay_device)
                        //{
                        //    BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                        //    new DatabaseUpdate().bayDeviceDataEntry(dataRequest);
                        //    response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                        //    response.success = true;
                        //    response.requestID = dataRequest.requestID;
                        //    response.deviceID = dataRequest.deviceID;
                        //}
                        //else if (device_id == UniversalProperties.bay_line_device)
                        //{
                        //    BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                        //    new DatabaseUpdate().bayLineDeviceDataEntry(dataRequest);
                        //    response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                        //    response.success = true;
                        //    response.requestID = dataRequest.requestID;
                        //    response.deviceID = dataRequest.deviceID;
                        //}
                        //else if (device_id == UniversalProperties.bay_rack_device)
                        //{
                        //    BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                        //    new DatabaseUpdate().bayRackDeviceDataEntry(dataRequest);
                        //    response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                        //    response.success = true;
                        //    response.requestID = dataRequest.requestID;
                        //    response.deviceID = dataRequest.deviceID;
                        //}
                        #endregion
                        string table = new DatabaseUpdate().getTable(request.deviceID);
                        switch (table)
                        {
                            case "device not found":
                                response.errorMessage = UniversalProperties.UNKNOWN_COMPONENT;
                                response.errorCode = UniversalProperties.EC_UnknownComponent;
                                response.requestID = request.requestID;
                                response.deviceID = request.deviceID;
                                response.success = false;
                                break;
                            case "greenhouse_device":
                                BaseDeviceRequest greenhouseDataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                                new DatabaseUpdate().greenhouseDeviceDataEntry(greenhouseDataRequest);
                                response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                                response.success = true;
                                response.requestID = greenhouseDataRequest.requestID;
                                response.deviceID = greenhouseDataRequest.deviceID;
                                break;
                            case "bay_device":
                                BaseDeviceRequest bayDataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                                new DatabaseUpdate().bayDeviceDataEntry(bayDataRequest);
                                response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                                response.success = true;
                                response.requestID = bayDataRequest.requestID;
                                response.deviceID = bayDataRequest.deviceID;
                                break;
                            case "bay_line_device":
                                BaseDeviceRequest bayLineDataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                                new DatabaseUpdate().bayLineDeviceDataEntry(bayLineDataRequest);
                                response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                                response.success = true;
                                response.requestID = bayLineDataRequest.requestID;
                                response.deviceID = bayLineDataRequest.deviceID;
                                break;
                            case "rack_device":
                                BaseDeviceRequest rackDataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                                new DatabaseUpdate().bayRackDeviceDataEntry(rackDataRequest);
                                response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                                response.success = true;
                                response.requestID = rackDataRequest.requestID;
                                response.deviceID = rackDataRequest.deviceID;
                                break;
                            case "level_device":
                                BaseDeviceRequest rackLevelDataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                                new DatabaseUpdate().bayRackLevelDeviceDataEntry(rackLevelDataRequest);
                                response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                                response.success = true;
                                response.requestID = rackLevelDataRequest.requestID;
                                response.deviceID = rackLevelDataRequest.deviceID;
                                break;
                            case "level_line_device":
                                BaseDeviceRequest rackLevelLineDataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
                                new DatabaseUpdate().bayRackLevelLineDeviceDataEntry(rackLevelLineDataRequest);
                                response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
                                response.success = true;
                                response.requestID = rackLevelLineDataRequest.requestID;
                                response.deviceID = rackLevelLineDataRequest.deviceID;
                                break;
                            default:
                                response.errorMessage = UniversalProperties.UNKNOWN_COMPONENT;
                                response.errorCode = UniversalProperties.EC_UnknownComponent;
                                response.success = false;
                                response.requestID = request.requestID;
                                response.deviceID = request.deviceID;
                                break;
                        }
                        break;

                    case UniversalProperties.greenhouse:

                        GreenhouseRequest gr = new JavaScriptSerializer().Deserialize<GreenhouseRequest>(JSONMessage);

                        foreach (GreenhouseDeviceRequest device in gr.listOfDevices)
                        {
                            device.requestID = gr.requestID;
                            new DatabaseUpdate().registerGreenhouseDevice(device);
                        }

                        foreach (BayRequest bay in gr.listOfBays)
                        {
                            bay.requestID = gr.requestID;
                            bool registered = new RegisterComponent().registerBay(bay);
                            if (!registered)
                            {
                                response.errorMessage = UniversalProperties.bayNotRegsitered;
                                response.errorCode = UniversalProperties.EC_RegistrationError;
                                response.success = false;
                                response.requestID = bay.requestID;
                                response.deviceID = bay.bay_unique_id;
                                string responseBayJSON = new JavaScriptSerializer().Serialize(response);
                                Publish(UniversalProperties.MQTT_topic, responseBayJSON);
                                break;
                            }
                        }
                        response.message = UniversalProperties.GREENHOUSE_REGISTERED_SUCCESSFULLY;
                        response.success = true;
                        response.requestID = gr.requestID;
                        break;

                    case UniversalProperties.greenhouseDevice:
                        GreenhouseDeviceRequest greenhouseDevice = new JavaScriptSerializer().Deserialize<GreenhouseDeviceRequest>(JSONMessage);
                        bool greenhouseDeviceRegistered = new DatabaseUpdate().registerGreenhouseDevice(greenhouseDevice);
                        if (greenhouseDeviceRegistered)
                        {
                            response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
                            response.success = true;
                            response.deviceID = greenhouseDevice.greenhouse_device_unique_id;
                            response.requestID = greenhouseDevice.requestID;
                        }
                        else
                        {
                            msgSent = true;
                        }
                        break;

                    case UniversalProperties.bay:
                        BayRequest bayRequest = new JavaScriptSerializer().Deserialize<BayRequest>(JSONMessage);
                        bool bayRegistered = new RegisterComponent().registerBay(bayRequest);
                        if (!bayRegistered)
                        {
                            response.errorMessage = UniversalProperties.bayNotRegsitered;
                            response.errorCode = UniversalProperties.EC_RegistrationError;
                            response.requestID = bayRequest.requestID;
                            response.deviceID = bayRequest.bay_unique_id;
                            response.success = false;
                            break;
                        }
                        else
                        {
                            response.message = UniversalProperties.BAY_REGISTERED_SUCCESSFULLY;
                            response.success = true;
                            response.deviceID = bayRequest.bay_unique_id;
                            response.requestID = bayRequest.requestID;
                            break;
                        }
                    case UniversalProperties.bayDevice:
                        BayDeviceRequest bayDevice = new JavaScriptSerializer().Deserialize<BayDeviceRequest>(JSONMessage);
                        bool bayDeviceRegistered = new DatabaseUpdate().registerBayDevice(bayDevice);
                        if (bayDeviceRegistered)
                        {
                            response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
                            response.success = true;
                            response.deviceID = bayDevice.bay_device_unique_id;
                            response.requestID = bayDevice.requestID;
                        }
                        else
                        {
                            msgSent = true;
                        }
                        break;

                    case UniversalProperties.bayLine:
                        BayLineRequest bayLine = new JavaScriptSerializer().Deserialize<BayLineRequest>(JSONMessage);
                        bool lineRegistered = new RegisterComponent().registerBayLine(bayLine);
                        if (!lineRegistered)
                        {
                            response.errorMessage = UniversalProperties.lineNotRegsitered;
                            response.errorCode = UniversalProperties.EC_RegistrationError;
                            response.success = false;
                            response.deviceID = bayLine.bay_line_unique_id;
                            response.requestID = bayLine.requestID;
                            break;
                        }
                        else
                        {
                            response.message = UniversalProperties.LINE_REGISTERED_SUCCESSFULLY;
                            response.success = true;
                            response.deviceID = bayLine.bay_line_unique_id;
                            response.requestID = bayLine.requestID;
                            break;
                        }

                    case UniversalProperties.bayLineDevice:
                        BayLineDeviceRequest bayLineDevice = new JavaScriptSerializer().Deserialize<BayLineDeviceRequest>(JSONMessage);
                        bool bayLineDeviceRegistered = new DatabaseUpdate().registerBayLineDevice(bayLineDevice);
                        if (bayLineDeviceRegistered)
                        {
                            response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
                            response.success = true;
                            response.deviceID = bayLineDevice.bay_line_device_unique_id;
                            response.requestID = bayLineDevice.requestID;
                        }
                        else
                        {
                            msgSent = true;
                        }
                        break;


                    case UniversalProperties.bayRack:
                        BayRackRequest bayRack = new JavaScriptSerializer().Deserialize<BayRackRequest>(JSONMessage);
                        bool rackRegistered = new RegisterComponent().registerBayRack(bayRack);
                        if (!rackRegistered)
                        {
                            response.errorMessage = UniversalProperties.rackNotRegsitered;
                            response.errorCode = UniversalProperties.EC_RegistrationError;
                            response.requestID = bayRack.requestID;
                            response.deviceID = bayRack.bay_rack_unique_id;
                            response.success = false;
                            break;
                        }
                        else
                        {
                            response.message = UniversalProperties.RACK_REGISTERED_SUCCESSFULLY;
                            response.success = true;
                            response.requestID = bayRack.requestID;
                            response.deviceID = bayRack.bay_rack_unique_id;
                            break;
                        }
                    case UniversalProperties.bayRackDevice:
                        BayRackDeviceRequest bayRackDevice = new JavaScriptSerializer().Deserialize<BayRackDeviceRequest>(JSONMessage);
                        bool bayRackDeviceRegistered = new DatabaseUpdate().registerBayRackDevice(bayRackDevice);
                        if (bayRackDeviceRegistered)
                        {
                            response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
                            response.success = true;
                            response.deviceID = bayRackDevice.device_unique_id;
                            response.requestID = bayRackDevice.requestID;
                        }
                        else
                        {
                            msgSent = true;
                        }
                        break;
                    case UniversalProperties.bayRackLevel:
                        BayRackLevelRequest bayRackLevel = new JavaScriptSerializer().Deserialize<BayRackLevelRequest>(JSONMessage);
                        bool rackLevelRegistered = new RegisterComponent().registerBayRackLevel(bayRackLevel);
                        if (!rackLevelRegistered)
                        {
                            response.errorMessage = UniversalProperties.rackLevelNotRegsitered;
                            response.errorCode = UniversalProperties.EC_RegistrationError;
                            response.requestID = bayRackLevel.requestID;
                            response.deviceID = bayRackLevel.bay_rack_level_unique_id;
                            response.success = false;
                            break;
                        }
                        else
                        {
                            response.message = UniversalProperties.RACK_LEVEL_REGISTERED_SUCCESSFULLY;
                            response.success = true;
                            response.requestID = bayRackLevel.requestID;
                            response.deviceID = bayRackLevel.bay_rack_level_unique_id;
                            break;
                        }

                    //*****************************USE DEVICE ENTRY FOR ALL OTHER QUERIES***********************

                    default:
                        break;
                }
            }
            catch (Exception exep)
            {
                ApplicationUtilities.writeMsg(exep.Source);
                ApplicationUtilities.writeMsg(exep.Message);
                ApplicationUtilities.writeMsg(exep.StackTrace);
                response.errorMessage = UniversalProperties.unknownError;
                response.errorCode = UniversalProperties.EC_UnhandledError;
                response.success = false;
                response.requestID = "response";
            }
            if (!msgSent)
            {
                string responseJSON = new JavaScriptSerializer().Serialize(response);
                Publish(UniversalProperties.MQTT_topic, responseJSON);
            }
        }
        public void Publish(string Topic, string content)
        {
            try
            {
                string IotEndpoint = "a2o8dyvqdg4v1r.iot.us-west-2.amazonaws.com";
                int BrokerPort = 8883;

                string path = System.Web.Hosting.HostingEnvironment.MapPath("/070bf213e6-certificate.pem.pfx");

                string path2 = System.Web.Hosting.HostingEnvironment.MapPath("/root.pem");

                X509Certificate2 clientCert = new X509Certificate2(path, "", X509KeyStorageFlags.MachineKeySet);
                X509Certificate caCert = X509Certificate.CreateFromSignedFile(path2);

                var client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);
                var message = "Insert your message here";
                client.Connect("clientid1");
                client.Publish(Topic, Encoding.UTF8.GetBytes(content));

                if (client.IsConnected)
                {
                    Debug.WriteLine("SUCCESS!");
                }
               // client1.Disconnect();
            }
            catch (Exception ex)
            {
                ApplicationUtilities.writeMsg("mqtt publish exception" + System.DateTime.Now.ToString());
                //throw;
            }
            ApplicationUtilities.writeMsg("mqtt published  " + System.DateTime.Now.ToString());

        }

    }
}
