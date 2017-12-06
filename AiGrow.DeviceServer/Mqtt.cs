//using System;
//using System.Security.Cryptography.X509Certificates;
//using System.Web;
//using System.Web.Script.Serialization;
//using uPLibrary.Networking.M2Mqtt;
//using uPLibrary.Networking.M2Mqtt.Messages;

//namespace AiGrow.DeviceServer
//{
//    public static class Mqtt
//    {

//        private const string IotEndpoint = "a2o8dyvqdg4v1r.iot.us-west-2.amazonaws.com";

//        private const int BrokerPort = 8883;

//        static string clientCert_path = "";
//        static string caCert_path = "";
//        static byte code;
//        public static void Subscribe()
//        {
//            string path = HttpContext.Current.Server.MapPath("/");
//            string path2 = HttpContext.Current.Server.MapPath("/root.pem");
//            X509Certificate2 clientCert = new X509Certificate2(path + "070bf213e6-certificate.pem.pfx", "", X509KeyStorageFlags.MachineKeySet);
//            X509Certificate caCert = X509Certificate.CreateFromSignedFile(path2);
//            var client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);

//            client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;

//            try
//            {
//                code = client.Connect("listener");
//            }
//            catch (Exception ex)
//            {
//                ApplicationUtilities.writeMsg("Exception:  " + System.DateTime.Now.ToString() + "\n" + ex.Message.ToString());
//            }


//            client.Subscribe(new[] { UniversalProperties.MQTT_topic }, new[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

//            ApplicationUtilities.writeMsg("\nsubscribed  " + System.DateTime.Now.ToString() + "\n");

//            /*
//            while (true)
//            {
//                //listen good!
//            }
//            */

//        }

//        public static void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
//        {
//            BaseResponse response = new BaseResponse();
//            bool msgSent = false;
//            string JSONMessage = System.Text.Encoding.UTF8.GetString(e.Message);
//            ApplicationUtilities.writeMsg("mqtt received  " + System.DateTime.Now.ToString());
//            try
//            {
//                BaseRequest request = new JavaScriptSerializer().Deserialize<BaseRequest>(JSONMessage);
//                if (request.command == null)
//                {
//                    return;
//                }

//                switch (request.command)
//                {
//                    case UniversalProperties.data:
//                        ApplicationUtilities.writeMsg("Data");
//                        int device_id = (request.deviceID).getDeviceID();
//                        if (device_id < 0)
//                        {
//                            response.errorMessage = UniversalProperties.UNKNOWN_COMPONENT;
//                            response.errorCode = UniversalProperties.EC_UnknownComponent;
//                            response.requestID = request.requestID;
//                            response.deviceID = request.deviceID;
//                            response.success = false;
//                        }
//                        else if (device_id == UniversalProperties.greenhouse_device)
//                        {
//                            BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
//                            new DatabaseUpdate().greenhouseDeviceDataEntry(dataRequest);
//                            response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.requestID = dataRequest.requestID;
//                            response.deviceID = dataRequest.deviceID;
//                        }
//                        else if (device_id == UniversalProperties.bay_device)
//                        {
//                            BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
//                            new DatabaseUpdate().bayDeviceDataEntry(dataRequest);
//                            response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.requestID = dataRequest.requestID;
//                            response.deviceID = dataRequest.deviceID;
//                        }
//                        else if (device_id == UniversalProperties.bay_line_device)
//                        {
//                            BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
//                            new DatabaseUpdate().bayLineDeviceDataEntry(dataRequest);
//                            response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.requestID = dataRequest.requestID;
//                            response.deviceID = dataRequest.deviceID;
//                        }
//                        else if (device_id == UniversalProperties.bay_rack_device)
//                        {
//                            BaseDeviceRequest dataRequest = new JavaScriptSerializer().Deserialize<BaseDeviceRequest>(JSONMessage);
//                            new DatabaseUpdate().bayRackDeviceDataEntry(dataRequest);
//                            response.message = UniversalProperties.DATA_ENTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.requestID = dataRequest.requestID;
//                            response.deviceID = dataRequest.deviceID;
//                        }

//                        break;

//                    case UniversalProperties.greenhouse:
//                        ApplicationUtilities.writeMsg("Greenhouse");
//                        GreenhouseRequest gr = new JavaScriptSerializer().Deserialize<GreenhouseRequest>(JSONMessage);

//                        foreach (GreenhouseDeviceRequest device in gr.listOfDevices)
//                        {
//                            device.requestID = gr.requestID;
//                            new DatabaseUpdate().registerGreenhouseDevice(device);
//                        }

//                        foreach (BayRequest bay in gr.listOfBays)
//                        {
//                            bay.requestID = gr.requestID;
//                            bool registered = new RegisterComponent().registerBay(bay);
//                            if (!registered)
//                            {
//                                response.errorMessage = UniversalProperties.bayNotRegsitered;
//                                response.errorCode = UniversalProperties.EC_RegistrationError;
//                                response.success = false;
//                                response.requestID = bay.requestID;
//                                response.deviceID = bay.bay_unique_id;
//                                string responseBayJSON = new JavaScriptSerializer().Serialize(response);
//                                new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseBayJSON);
//                                break;
//                            }
//                        }
//                        response.message = UniversalProperties.GREENHOUSE_REGISTERED_SUCCESSFULLY;
//                        response.success = true;
//                        response.requestID = gr.requestID;
//                        break;

//                    case UniversalProperties.greenhouseDevice:
//                        GreenhouseDeviceRequest greenhouseDevice = new JavaScriptSerializer().Deserialize<GreenhouseDeviceRequest>(JSONMessage);
//                        bool greenhouseDeviceRegistered = new DatabaseUpdate().registerGreenhouseDevice(greenhouseDevice);
//                        if (greenhouseDeviceRegistered)
//                        {
//                            response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.deviceID = greenhouseDevice.greenhouse_device_unique_id;
//                            response.requestID = greenhouseDevice.requestID;
//                        }
//                        else
//                        {
//                            msgSent = true;
//                        }
//                        break;

//                    case UniversalProperties.bay:
//                        BayRequest bayRequest = new JavaScriptSerializer().Deserialize<BayRequest>(JSONMessage);
//                        bool bayRegistered = new RegisterComponent().registerBay(bayRequest);
//                        if (!bayRegistered)
//                        {
//                            response.errorMessage = UniversalProperties.bayNotRegsitered;
//                            response.errorCode = UniversalProperties.EC_RegistrationError;
//                            response.requestID = bayRequest.requestID;
//                            response.deviceID = bayRequest.bay_unique_id;
//                            response.success = false;
//                            break;
//                        }
//                        else
//                        {
//                            response.message = UniversalProperties.BAY_REGISTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.deviceID = bayRequest.bay_unique_id;
//                            response.requestID = bayRequest.requestID;
//                            break;
//                        }
//                    case UniversalProperties.bayDevice:
//                        BayDeviceRequest bayDevice = new JavaScriptSerializer().Deserialize<BayDeviceRequest>(JSONMessage);
//                        bool bayDeviceRegistered = new DatabaseUpdate().registerBayDevice(bayDevice);
//                        if (bayDeviceRegistered)
//                        {
//                            response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.deviceID = bayDevice.bay_device_unique_id;
//                            response.requestID = bayDevice.requestID;
//                        }
//                        else
//                        {
//                            msgSent = true;
//                        }
//                        break;

//                    case UniversalProperties.bayLine:
//                        BayLineRequest bayLine = new JavaScriptSerializer().Deserialize<BayLineRequest>(JSONMessage);
//                        bool lineRegistered = new RegisterComponent().registerBayLine(bayLine);
//                        if (!lineRegistered)
//                        {
//                            response.errorMessage = UniversalProperties.lineNotRegsitered;
//                            response.errorCode = UniversalProperties.EC_RegistrationError;
//                            response.success = false;
//                            response.deviceID = bayLine.bay_line_unique_id;
//                            response.requestID = bayLine.requestID;
//                            break;
//                        }
//                        else
//                        {
//                            response.message = UniversalProperties.LINE_REGISTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.deviceID = bayLine.bay_line_unique_id;
//                            response.requestID = bayLine.requestID;
//                            break;
//                        }

//                    case UniversalProperties.bayLineDevice:
//                        BayLineDeviceRequest bayLineDevice = new JavaScriptSerializer().Deserialize<BayLineDeviceRequest>(JSONMessage);
//                        bool bayLineDeviceRegistered = new DatabaseUpdate().registerBayLineDevice(bayLineDevice);
//                        if (bayLineDeviceRegistered)
//                        {
//                            response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.deviceID = bayLineDevice.bay_line_device_unique_id;
//                            response.requestID = bayLineDevice.requestID;
//                        }
//                        else
//                        {
//                            msgSent = true;
//                        }
//                        break;


//                    case UniversalProperties.bayRack:
//                        BayRackRequest bayRack = new JavaScriptSerializer().Deserialize<BayRackRequest>(JSONMessage);
//                        bool rackRegistered = new RegisterComponent().registerBayRack(bayRack);
//                        if (!rackRegistered)
//                        {
//                            response.errorMessage = UniversalProperties.rackNotRegsitered;
//                            response.errorCode = UniversalProperties.EC_RegistrationError;
//                            response.requestID = bayRack.requestID;
//                            response.deviceID = bayRack.bay_rack_unique_id;
//                            response.success = false;
//                            break;
//                        }
//                        else
//                        {
//                            response.message = UniversalProperties.RACK_REGISTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.requestID = bayRack.requestID;
//                            response.deviceID = bayRack.bay_rack_unique_id;
//                            break;
//                        }
//                    case UniversalProperties.bayRackDevice:
//                        BayRackDeviceRequest bayRackDevice = new JavaScriptSerializer().Deserialize<BayRackDeviceRequest>(JSONMessage);
//                        bool bayRackDeviceRegistered = new DatabaseUpdate().registerBayRackDevice(bayRackDevice);
//                        if (bayRackDeviceRegistered)
//                        {
//                            response.message = UniversalProperties.DEVICE_REGISTERED_SUCCESSFULLY;
//                            response.success = true;
//                            response.deviceID = bayRackDevice.device_unique_id;
//                            response.requestID = bayRackDevice.requestID;
//                        }
//                        else
//                        {
//                            msgSent = true;
//                        }
//                        break;


//                    //*****************************USE DEVICE ENTRY FOR ALL OTHER QUERIES***********************

//                    default:
//                        break;
//                }
//            }
//            catch
//            {
//                response.errorMessage = UniversalProperties.unknownError;
//                response.errorCode = UniversalProperties.EC_UnhandledError;
//                response.success = false;
//            }
//            if (!msgSent)
//            {
//                string responseJSON = new JavaScriptSerializer().Serialize(response);
//                new MQTTHandler().Publish(UniversalProperties.MQTT_topic, responseJSON);
//            }
//        }
//        //public static void Publish(string Topic, string content)
//        //{
//        //    //convert to pfx using openssl - see confluence
//        //    //you'll need to add these two files to the project and copy them to the output (not included in source control deliberately!)
//        //    //X509Certificate2 clientCert2 = new X509Certificate2(clientCert_path, "");
//        //    //X509Certificate caCert2 = X509Certificate.CreateFromSignedFile(caCert_path);

//        //    var client = new MqttClient(IotEndpoint, BrokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);
//        //    //message to publish - could be anything
//        //    var message = "Insert your message here";
//        //    //client naming has to be unique if there was more than one publisher
//        //    client.Connect("clientid1");
//        //    //publish to the topic
//        //    client.Publish(Topic, Encoding.UTF8.GetBytes(content));
//        //    //this was in for debug purposes but it's useful to see something in the console
//        //    if (client.IsConnected)
//        //    {
//        //        Debug.WriteLine("SUCCESS!");
//        //    }
//        //    //wait so that we can see the outcome


//        //}
//    }
//}