using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Setup
{
    public class Division
    {
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
    }
    public class DivisionHandler
    {
        private string query = "";
        public int Insert(Division division)
        {
            query = "insert into tbl_Division(DivisionId,DivisionName,CompanyName,CompanyCode)Values('";
            query = query + division.DivisionId + "','";
            query = query + division.DivisionName + "','";
            query = query + division.CompanyName + "','";
            query = query + division.CompanyCode + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Division Division)
        {
            query = "update tbl_Division set";
            query = query + " DivisionName = '" + Division.DivisionName + "',";
            query = query + " CompanyName = '" + Division.CompanyName + "',";
            query = query + " CompanyCode = '" + Division.CompanyCode + "'";
            query = query + " Where DivisionId = '" + Division.DivisionId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Division where DivisionId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Division GetById(int? id)
        {
            query = "select * from tbl_Division Where DivisionId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Division = new Division();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Division.DivisionId = Convert.ToInt32(dataRow["DivisionId"]);
                    Division.DivisionName = dataRow["DivisionName"].ToString();
                    Division.CompanyName = dataRow["CompanyName"].ToString();
                    Division.CompanyCode = dataRow["CompanyCode"].ToString();
                }

                return Division;
            }

            return null;
        }
        public List<Division> AllList()
        {
            query = "select * from tbl_Division";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                Division Division;
                var Divisionlist = new List<Division>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Division = new Division();
                    Division.DivisionId = Convert.ToInt32(dataRow["DivisionId"]);
                    Division.DivisionName = dataRow["DivisionName"].ToString();
                    Division.CompanyName = dataRow["CompanyName"].ToString();
                    Division.CompanyCode = dataRow["CompanyCode"].ToString();
                    Divisionlist.Add(Division);
                }

                return Divisionlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Divisionid),0) + 1 from tbl_Division";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}