using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_Data
    {
        public DataTable getTable(string device){
            return new DL_Data().getTable(device);
        }
    }
}
