using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_User
    {
        public bool doesUserExist(string userName)
        {
            return new DL_User().doesUserExist(userName);
        }
        public System.Data.DataTable selectByUserName(AiGrow.Model.ML_User user)
        {
            return new DL_User().selectByUserName(user);

        }
        public int validateToken(string loginToken)
        {
            return new DL_User().validateToken(loginToken);

        }
        public System.Data.DataTable getUserSalt(AiGrow.Model.ML_User user)
        {
            return new DL_User().getUserSalt(user);

        }
        public System.Data.DataTable checkLoginSecure(AiGrow.Model.ML_User user)
        {
            return new DL_User().checkLoginSecure(user);

        }
        public int insert(AiGrow.Model.ML_User user)
        {
            return new DL_User().insert(user);
        }
        public System.Data.DataTable getRoleID(string userType)
        {
            return new DL_User().getRoleID(userType);
        }
        public string getUserIDByReference(string uniqueID)
        {
            return new AiGrow.Data.DL_User().getUserIDByReference(uniqueID);
        }
        public System.Data.DataTable selectCustomer(AiGrow.Model.ML_User user, string token)
        {
            return new DL_User().selectCustomer(user, token);
        }
        public int update(AiGrow.Model.ML_User user)
        {
            return new AiGrow.Data.DL_User().update(user);
        }
        public string getUserIDByUserName(string userName)
        {
            return new AiGrow.Data.DL_User().getUserIDByUserName(userName);
        }
        public bool doesEmailExist(string email)
        {
            return new DL_User().doesEmailExist(email);
        }
        public System.Data.DataTable selectRecordsByEmail(string email)
        {
            return new DL_User().selectRecordsByEmail(email);
        }
        public System.Data.DataTable selectByUserID(AiGrow.Model.ML_User user)
        {
            return new AiGrow.Data.DL_User().selectByUserID(user);
        }

        public System.Data.DataTable select(string userName)
        {
            return new AiGrow.Data.DL_User().select(userName);
        }
    }
}
