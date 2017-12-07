using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_Greenhouse
    {
        public bool insert(AiGrow.Model.ML_Greenhouse greenhouse)
        {
            return new DL_Greenhouse().insert(greenhouse);
        }
        public bool doesGreenhouseExist(string greenhouse)
        {
            return new DL_Greenhouse().doesGreenhouseExist(greenhouse);
        }


        public System.Data.DataTable selectAllGreenhouses()
        {
            return new DL_Greenhouse().select();
        }

        public System.Data.DataSet selectComponentsByNetworkID(string greenHouseID)
        {
            return new AiGrow.Data.DL_Greenhouse().selectComponentsByGreenHouseID(greenHouseID);
        }

        public System.Data.DataTable selectDevicesByTableName(string tableName)
        {
            return new DL_Greenhouse().selectDevicesByTableName(tableName);
        }

        public System.Data.DataTable selectUniqueIdsByTableName(string tableName)
        {
            switch(tableName)
            {
                case "bay_line":
                    return new DL_BayLine().selectAllBayLines();
                    
                case "greenhouse":
                    return new DL_Greenhouse().selectAllGreenhouses();
                    
                case "level":
                    return new DL_BayRackLevel().selectAllLevels();
                    
                case "level_line":
                    return new DL_BayRackLevelLine().selectAllLevellines();
                    
                case "rack":
                    return new DL_BayRack().selectAllRacks();
                    
                case "bay" :
                    return new DL_Bay().selectAllBays();

                default :
                    return null;
            }
            
        }
        public System.Data.DataTable select()
        {
            return new AiGrow.Data.DL_Greenhouse().select();
        }
    }
}
