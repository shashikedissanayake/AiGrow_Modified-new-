﻿using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_Location
    {
        public bool insert(AiGrow.Model.ML_Location location)
        {
            return new DL_Location().insert(location);
        }

        public bool delete(AiGrow.Model.ML_Location loaction)
        {
            return new DL_Location().delete(loaction);
        }
        public int update(AiGrow.Model.ML_Location location)
        {
            return new AiGrow.Data.DL_Location().update(location);
        }
        public System.Data.DataTable getAllLocations(string user_id)
        {
            return new AiGrow.Data.DL_Location().getAllLocations(user_id);
        }
        public System.Data.DataTable getAllLocationsForAdmin(string user_id)
        {
            return new AiGrow.Data.DL_Location().getAllLocationsForAdmin(user_id);
        }
    }
}
