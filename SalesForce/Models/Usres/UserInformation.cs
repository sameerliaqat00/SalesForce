using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Usres
{
    public class UserInformation
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string SapCode { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string Territory { get; set; }
        public string Town { get; set; }
        public string Distribution { get; set; }
        public string ReportingTo { get; set; }
    }

    public class UserInformationHandler
    {
       
            private string query = "";
            public int Insert(UserInformation UserInformation)
            {
                query = "insert into tbl_UserInformation(UserID,UserName,LastName,SapCode,CellPhone,Email,Password,Address,Company,Division,Region,Area,Territory,Town,Distribution,ReportingTo)Values('";
                query = query + UserInformation.UserId + "','";
                query = query + UserInformation.UserName + "','";
                query = query + UserInformation.LastName + "','";
                query = query + UserInformation.SapCode + "','";
                query = query + UserInformation.CellPhone + "','";
                query = query + UserInformation.Email + "','";
                query = query + UserInformation.Password + "','";
                query = query + UserInformation.Address + "','";
                query = query + UserInformation.Company + "','";
                query = query + UserInformation.Division + "','";
                query = query + UserInformation.Region + "','";
                query = query + UserInformation.Area + "','";
                query = query + UserInformation.Territory + "','";
                query = query + UserInformation.Town + "','";
                query = query + UserInformation.Distribution + "','";
                query = query + UserInformation.ReportingTo + "')";
                return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
            }

            public int Update(UserInformation UserInformation)
            {
                query = "update tbl_UserInformation set";
                query = query + " UserName = '" + UserInformation.UserName + "',";
                query = query + " LastName = '" + UserInformation.LastName + "',";
                query = query + " SapCode = '" + UserInformation.SapCode + "',";
                query = query + " CellPhone = '" + UserInformation.CellPhone + "',";
                query = query + " Email = '" + UserInformation.Email + "',";
                query = query + " Password = '" + UserInformation.Password + "',";
                query = query + " Address = '" + UserInformation.Address + "',";
                query = query + " Company = '" + UserInformation.Company + "',";
                query = query + " Division = '" + UserInformation.Division + "',";
                query = query + " Region = '" + UserInformation.Region + "',";
                query = query + " Area = '" + UserInformation.Area + "',";
                query = query + " Territory = '" + UserInformation.Territory + "',";
                query = query + " Town = '" + UserInformation.Town + "',";
                query = query + " Distribution = '" + UserInformation.Distribution + "',";
                query = query + " ReportingTo = '" + UserInformation.ReportingTo + "'";
                query = query + " Where UserId = '" + UserInformation.UserId + "'";
                return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
            }

            public int Delete(int id)
            {
                query = "delete from tbl_UserInformation where UserId = '" + id + "'";
                return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
            }

            public UserInformation GetById(int id)
            {
                query = "select * from tbl_UserInformation Where UserId = '" + id + "'";
                var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
                if (Data.Rows.Count > 0)
                {
                    var UserInformation = new UserInformation();
                    foreach (DataRow dataRow in Data.Rows)
                    {
                        UserInformation.UserId = Convert.ToInt32(dataRow["UserId"]);
                        UserInformation.UserName = dataRow["UserName"].ToString();
                        UserInformation.LastName = dataRow["LastName"].ToString();
                        UserInformation.SapCode = dataRow["SapCode"].ToString();
                        UserInformation.CellPhone = dataRow["CellPhone"].ToString();
                        UserInformation.Email = dataRow["Email"].ToString();
                        UserInformation.Password = dataRow["Password"].ToString();
                        UserInformation.Address = dataRow["Address"].ToString();
                        UserInformation.Company = dataRow["Company"].ToString();
                        UserInformation.Division = dataRow["Division"].ToString();
                        UserInformation.Region = dataRow["Region"].ToString();
                        UserInformation.Area = dataRow["Area"].ToString();
                        UserInformation.Territory = dataRow["Territory"].ToString();
                        UserInformation.Town = dataRow["Town"].ToString();
                        UserInformation.Distribution = dataRow["Distribution"].ToString();
                        UserInformation.ReportingTo = dataRow["ReportingTo"].ToString();
                    }

                    return UserInformation;
                }

                return null;
            }
            public List<UserInformation> AllList()
            {
                query = "select * from tbl_UserInformation";
                var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
                if (Data.Rows.Count > 0)
                {
                    var UserInformation = new UserInformation();
                    var UserInformationlist = new List<UserInformation>();
                    foreach (DataRow dataRow in Data.Rows)
                    {
                    UserInformation.UserId = Convert.ToInt32(dataRow["UserId"]);
                    UserInformation.UserName = dataRow["UserName"].ToString();
                    UserInformation.LastName = dataRow["LastName"].ToString();
                    UserInformation.SapCode = dataRow["SapCode"].ToString();
                    UserInformation.CellPhone = dataRow["CellPhone"].ToString();
                    UserInformation.Email = dataRow["Email"].ToString();
                    UserInformation.Password = dataRow["Password"].ToString();
                    UserInformation.Address = dataRow["Address"].ToString();
                    UserInformation.Company = dataRow["Company"].ToString();
                    UserInformation.Division = dataRow["Division"].ToString();
                    UserInformation.Region = dataRow["Region"].ToString();
                    UserInformation.Area = dataRow["Area"].ToString();
                    UserInformation.Territory = dataRow["Territory"].ToString();
                    UserInformation.Town = dataRow["Town"].ToString();
                    UserInformation.Distribution = dataRow["Distribution"].ToString();
                    UserInformation.ReportingTo = dataRow["ReportingTo"].ToString();
                    UserInformationlist.Add(UserInformation);
                    }
                    return UserInformationlist;
                }

                return null;
            }

            public int GetMaxId()
            {
                query = "select isnull(max(UserId),0) + 1 tbl_UserInformation";
                return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
            }
    }
}