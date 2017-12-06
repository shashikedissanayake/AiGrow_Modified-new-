using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_GreenHouses
    {

        public System.Data.DataTable select()
        {
            return new AiGrow.Data.DL_Greenhouse().select();
        }



    }


}
