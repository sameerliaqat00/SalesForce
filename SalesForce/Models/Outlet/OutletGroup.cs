using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Outlet
{
    public class OutletGroup
    {
        public int OutletId { get; set; }
        public string OutletName { get; set; }
        public string ShortName { get; set; }
    }
    public class OutletGroupHandler
    {
        private string query = "";
        public int Insert(OutletGroup OutletGroup)
        {
            query = "insert into tbl_OutletGroup(OutletId,OutletName,ShortName)Values('";
            query = query + OutletGroup.OutletId + "','";
            query = query + OutletGroup.OutletName + "','";
            query = query + OutletGroup.ShortName + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(OutletGroup OutletGroup)
        {
            query = "update tbl_OutletGroup set";
            query = query + " OutletName = '" + OutletGroup.OutletName + "',";
            query = query + " ShortName = '" + OutletGroup.ShortName + "'";
            query = query + " Where OutletId = '" + OutletGroup.OutletId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_OutletGroup where SubChannelId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public OutletGroup GetById(int id)
        {
            query = "select * from tbl_OutletGroup Where ChannelId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var OutletGroup = new OutletGroup();
                foreach (DataRow dataRow in Data.Rows)
                {
                    OutletGroup.OutletId = Convert.ToInt32(dataRow["Outletid"]);
                    OutletGroup.OutletName = dataRow["Outletname"].ToString();
                    OutletGroup.ShortName = dataRow["ShoreName"].ToString();
                }

                return OutletGroup;
            }

            return null;
        }
        public List<OutletGroup> AllList()
        {
            query = "select * from tbl_OutletGroup";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var OutletGroup = new OutletGroup();
                var OutletGrouplist = new List<OutletGroup>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    OutletGroup.OutletId = Convert.ToInt32(dataRow["Outletid"]);
                    OutletGroup.OutletName = dataRow["Outletname"].ToString();
                    OutletGroup.ShortName = dataRow["ShoreName"].ToString();
                    OutletGrouplist.Add(OutletGroup);
                }

                return OutletGrouplist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Outletid),0) + 1 tbl_OutletGroup";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}