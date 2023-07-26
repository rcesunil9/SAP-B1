using SAPWeb.App_Start;
using SAPWeb.Models;
using SAPWeb.Repository.Interface;
using SAPWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPWeb.Repository.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        string SAPErrMsg = "";

        #region UserProperty
        SQL_CONN_Class objCon = new SQL_CONN_Class();
        #endregion

        #region CheckLoginData()

        public UserDefault CheckLogin(UserLogin model)
        {
            UserDefault ObjUser = new UserDefault();
            ObjUser.User = new List<User>();
            try
            {
                var Data = objCon.ByQueryReturnDataTable(@"select * from [@A_USER] Where U_Pass = '" + model.Password + "' AND Name='" + model.UserName + "'");
                if (Data != null && Data.Rows.Count > 0)
                {
                    ObjUser.User = Data.ConvertToList<User>();
                    ObjUser.errorCode = "1";
                    ObjUser.errorMsg = "";
                }
                else
                {
                    ObjUser.errorCode = "0";
                    ObjUser.errorMsg = "Wrong Username/Password.";
                }
            }
            catch (Exception ex)
            {
                ObjUser.errorCode = "0";
                ObjUser.errorMsg = ex.Message;
                return ObjUser;
            }
            return ObjUser; 
           /* try
            {
                string ParamName = "@USERNAME|@PASSWORD|@DEVICEID";
                string ParamVal = model.UserName.Trim() + "|" + model.Password.Trim() + "|" + model.DeviceID;
                var Data = objCon.ByProcedureReturnDataTable_New("A_CHECK_USERLOGINDATA", 3, ParamName, ParamVal).ToList();

                if (Data[0] == "Success")
                {
                    if (Data[1] != null)
                    {
                        if (Data[1].Rows.Count > 0)
                        {
                            User UserData = new User();
                            UserData.Name = Convert.ToString(Data[1].Rows[0]["NAME"]);
                            UserData.UserName = Convert.ToString(Data[1].Rows[0]["USERNAME"]);
                            UserData.UserID = Convert.ToString(Data[1].Rows[0]["EMPID"]);
                            UserData.EmpID = Convert.ToString(Data[1].Rows[0]["EMPID"]);
                            UserData.Password = Convert.ToString(Data[1].Rows[0]["PASSWORD"]);
                            UserData.ParentID = Convert.ToString(Data[1].Rows[0]["PARENTID"]);
                            UserData.Position = Convert.ToString(Data[1].Rows[0]["POSITION"]);
                            UserData.PositionID = Convert.ToString(Data[1].Rows[0]["POSITIONID"]);
                            UserData.ManagerName = Convert.ToString(Data[1].Rows[0]["MANAGERNAME"]);
                            UserData.SlpID = Convert.ToString(Data[1].Rows[0]["SlpID"]);
                            UserData.SapSourceAttachPath = Convert.ToString(Data[1].Rows[0]["SAPSOURCEATTACHPATH"]);
                            UserData.BranchCode = Convert.ToString(Data[1].Rows[0]["BRANCHCODE"]);
                            UserData.BranchName = Convert.ToString(Data[1].Rows[0]["BRANCHNAME"]);
                            UserData.Mobile = Convert.ToString(Data[1].Rows[0]["MOBILE"]);
                            UserData.Email = Convert.ToString(Data[1].Rows[0]["EMAIL"]);
                            UserData.StateCode = Convert.ToString(Data[1].Rows[0]["STATECODE"]);
                            UserData.CountryCode = Convert.ToString(Data[1].Rows[0]["COUNTRYCODE"]);
                            UserData.AttachmentPath = Convert.ToString(Data[1].Rows[0]["ATTACHMENTPATH"]);

                            UserData.ISAPPROVER = Convert.ToString(Data[1].Rows[0]["ISAPPROVER"]);


                            ObjUser.errorCode = "1";
                            ObjUser.errorMsg = "";
                            ObjUser.User.Add(UserData);
                        }
                        else
                        {
                            ObjUser.errorCode = "0";
                            ObjUser.errorMsg = "Wrong Username/Password.";
                        }
                    }
                    else
                    {
                        ObjUser.errorCode = "0";
                        ObjUser.errorMsg = "Wrong Username/Password.";
                    }
                }
                else
                {
                    ObjUser.errorCode = "0";
                    ObjUser.errorMsg = "Wrong Username/Password..";
                }
            }
            catch (Exception ex)
            {
                ObjUser.errorCode = "0";
                ObjUser.errorMsg = ex.Message;
                return ObjUser;
            }
            return ObjUser;
            */
        }
        #endregion
    }
}