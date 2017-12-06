using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_Configurations
    {
        public System.Data.DataTable getConfigValue(string configName)
        {
            return new DL_Configurations().getConfigValue(configName);
        }
        public System.Data.DataTable select()
        {
            return new DL_Configurations().select();
        }
    }
}
