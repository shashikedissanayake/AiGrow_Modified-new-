using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_Login
    {
        public int insert(AiGrow.Model.ML_Login login)
        {
            return new DL_Login().insert(login);
        }
        public int logOut(AiGrow.Model.ML_Login login)
        {
            return new DL_Login().logOut(login);
        }
    }
}
