using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Outlet
{
    public class OutletClassification
    {
        public int OutletId { get; set; }
        public string OutletName { get; set; }
        public string ShortName { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }

    public class OutletClassificationHandler
    {
        private string query = "";
        public int Insert(OutletClassification OutletClassification)
        {
            query = "insert into tbl_OutletClassification(OutletId,OutletName,ShortName,MinValue,MaxValue)Values('";
            query = query + OutletClassification.OutletId + "','";
            query = query + OutletClassification.OutletName + "','";
            query = query + OutletClassification.ShortName + "','";
            query = query + OutletClassification.MinValue + "','";
            query = query + OutletClassification.MaxValue + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(OutletClassification OutletClassification)
        {
            query = "update tbl_OutletClassification set";
            query = query + " OutletName = '" + OutletClassification.OutletName + "',";
            query = query + " ShortName = '" + OutletClassification.ShortName + "',";
            query = query + " MinValue = '" + OutletClassification.MinValue + "',";
            query = query + " MaxValue = '" + OutletClassification.MaxValue + "'";
            query = query + " Where OutletId = '" + OutletClassification.OutletId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_OutletClassification where OutletId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public OutletClassification GetById(int id)
        {
            query = "select * from tbl_OutletClassification Where OutletId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var OutletClassification = new OutletClassification();
                foreach (DataRow dataRow in Data.Rows)
                {
                    OutletClassification.OutletId = Convert.ToInt32(dataRow["Outletid"]);
                    OutletClassification.OutletName = dataRow["Outletname"].ToString();
                    OutletClassification.ShortName = dataRow["ShoreName"].ToString();
                    OutletClassification.MinValue = Convert.ToInt32(dataRow["MinValue"]);
                    OutletClassification.MaxValue = Convert.ToInt32(dataRow["MaxValue"]);
                }

                return OutletClassification;
            }

            return null;
        }
        public List<OutletClassification> AllList()
        {
            query = "select * from tbl_OutletClassification";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var OutletClassification = new OutletClassification();
                var OutletClassificationlist = new List<OutletClassification>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    OutletClassification.OutletId = Convert.ToInt32(dataRow["Outletid"]);
                    OutletClassification.OutletName = dataRow["Outletname"].ToString();
                    OutletClassification.ShortName = dataRow["ShoreName"].ToString();
                    OutletClassification.MinValue = Convert.ToInt32(dataRow["MinValue"]);
                    OutletClassification.MaxValue = Convert.ToInt32(dataRow["MaxValue"]);
                    OutletClassificationlist.Add(OutletClassification);
                }

                return OutletClassificationlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Outletid),0) + 1 tbl_OutletClassification";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}