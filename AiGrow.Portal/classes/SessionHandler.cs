using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using AiGrow.Business;
using AiGrow.Classes;

namespace AiGrow
{
    public class SessionHandler : System.Web.UI.Page
    {

        public static void initiateLoginSession(string username, string type, string token, string userID,string loginID)
        {

            try
            {
                HttpContext.Current.Session.Timeout = AiGrow.Constants.SESSIONTIMEOUT;
                HttpContext.Current.Session["username"] = username.Trim();
                HttpContext.Current.Session["type"] = type.Trim();
                HttpContext.Current.Session["token"] = token.Trim();
                HttpContext.Current.Session["userID"] = userID.Trim();
                HttpContext.Current.Session["loginID"] = loginID.Trim();
            }
            catch 
            {

            }
        }

        public static Boolean doesSessionExist()
        {
            try
            {
                
                String username = (String)HttpContext.Current.Session["username"];
                String type = (String)HttpContext.Current.Session["type"];

                if (username.Trim() == null || type.Trim() == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch 
            {
                return false;
            }
        }

        public static void logout()
        {
            AiGrow.LoginResponse login = AiGrow.MyUser.validateUserLogout(SessionHandler.getLoggedInid(), SessionHandler.getToken());
            HttpContext.Current.Session["username"] = null;
            HttpContext.Current.Session["type"] = null;
        }

        public static Boolean isUserAdmin()
        {
            try
            {
                String type = (String)HttpContext.Current.Session["type"];
                if (type.Trim() != Constants.AIGROW_ADMIN)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }

        public static Boolean isUserCustomer()
        {
            try
            {
                String type = (String)HttpContext.Current.Session["type"];
                if (type.Trim() != Constants.AIGROW_CUSTOMER)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static Boolean isUserNetworkOwner()
        {
            try
            {
                String type = (String)HttpContext.Current.Session["type"];
                if (type.Trim() != Constants.CHG_NETWORK)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean isUserStationOwner()
        {
            try
            {
                String type = (String)HttpContext.Current.Session["type"];
                if (type.Trim() != Constants.CHG_OWNER)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }

        public static Boolean isUserStaff()
        {
            try
            {
                String type = (String)HttpContext.Current.Session["type"];
                if (type.Trim() != Constants.CHG_STAFF)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Boolean isUserAccountant()
        {
            try
            {
                String type = (String)HttpContext.Current.Session["type"];
                if (type.Trim() != Constants.CHG_ACCOUNTANT)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void initiateTestingLoginAdmin()
        {
            HttpContext.Current.Session["username"] = "vega";
            HttpContext.Current.Session["type"] = AiGrow.Constants.AIGROW_ADMIN;
            HttpContext.Current.Session["token"] = "CD57D9E647A3A31AF7235244E1F33C2966A77A7D";
        }
        public static void initiateTestingLoginAccountant()
        {
            HttpContext.Current.Session["username"] = "accounts";
            HttpContext.Current.Session["type"] = AiGrow.Constants.CHG_ACCOUNTANT;
            HttpContext.Current.Session["token"] = "522E46EC209137EC8E27C84BF56C6E45936ABA46";
        }
        public static void initiateTestingLoginStaff()
        {
            HttpContext.Current.Session["username"] = "staff";
            HttpContext.Current.Session["type"] = AiGrow.Constants.CHG_STAFF;
            HttpContext.Current.Session["token"] = "0F6A7C5616C3B9332146D92C5B8CEE30D346D3DB";
        }

        public static void initiateTestingLoginCustomer()
        {
            //HttpContext.Current.Session["username"] = "rashiga";
            //HttpContext.Current.Session["type"] = chargeNET.Constants.CHG_CUSTOMER;
        }

        public static String getLoggedInid()
        {
            try
            {
                if ((Boolean)SessionHandler.doesSessionExist())
                {
                    return (String)HttpContext.Current.Session["loginID"];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static String getLoggedInUsername()
        {
            try
            {
                if ((Boolean)SessionHandler.doesSessionExist())
                {
                    return (String)HttpContext.Current.Session["username"];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public static String getLoggedInUserID()
        {
            try
            {
                if ((Boolean)SessionHandler.doesSessionExist())
                {
                    return (String)HttpContext.Current.Session["userID"];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static string getToken()
        {
            try
            {
                if ((bool)SessionHandler.doesSessionExist())
                {
                    return (string)HttpContext.Current.Session["token"];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static String getLoggedInUserType()
        {
            try
            {
                if ((Boolean)SessionHandler.doesSessionExist())
                {
                    return (String)HttpContext.Current.Session["type"];
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static String getLoggedInUserTypeAlias()
        {
            try
            {
                if ((Boolean)SessionHandler.doesSessionExist())
                {
                    String type = (String)HttpContext.Current.Session["type"];
                    switch (type.Trim())
                    {
                        case Constants.AIGROW_ADMIN:
                            return "System Administrator";
                        case Constants.CHG_NETWORK:
                            return "Network Owner";
                        case Constants.CHG_OWNER:
                            return "Point Owner";
                        case Constants.AIGROW_CUSTOMER:
                            return "Charge Customer";
                        case Constants.CHG_STAFF:
                            return "chargeNET Staff";
                        case Constants.CHG_ACCOUNTANT:
                            return "Accountant";
                        default:
                            return "Unknown User";
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static String getLoggedInUserFullName()
        {
            try
            {
                DataTable dt = new BL_User().select(SessionHandler.getLoggedInUsername());
                return dt.Rows.Count >= 1 ? dt.Rows[0]["first_name"].ToString() + " " + dt.Rows[0]["last_name"].ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static String getLoggedInUserOrganization()
        {
            try
            {
                DataTable dt = new BL_User().select(SessionHandler.getLoggedInUsername());
                return dt.Rows.Count >= 1 ? dt.Rows[0]["organization_name"].ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}