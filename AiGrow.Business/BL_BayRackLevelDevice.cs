﻿using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayRackLevelDevice
    {
        public bool insert(AiGrow.Model.ML_BayRackLevelDevice device)
        {
            return new DL_BayRackLevelDevice().insert(device);
        }

        public bool doesDeviceExist(string device)
        {
            return new DL_BayRackLevelDevice().doesDeviceExist(device);
        }

        //public System.Data.DataTable selectAllDevices(string id)
        //{
        //    return new DL_BayRackLevelDevice().selectAllDevices(id);
        //}
        public System.Data.DataTable selectAllDevices(string id)
        {
            return new DL_BayRackLevelDevice().selectAllDevices(id);
        }
    }
}
