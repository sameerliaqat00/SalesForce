using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Setup
{
    public class Town
    {
        public int TownId { get; set; }
        public string TownName { get; set; }
    }

    public class TownHandler
    {
        private string query = "";
        public int Insert(Town Town)
        {
            query = "insert into tbl_Town(TownId,TownName)Values('";
            query = query + Town.TownId + "','";
            query = query + Town.TownName + "')";
            
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Town Town)
        {
            query = "update tbl_Town set";
            query = query + " TownName = '" + Town.TownName + "'";
            
            query = query + " Where TownId = '" + Town.TownId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Town where TownId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Town GetById(int? id)
        {
            query = "select * from tbl_Town Where TownId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Town = new Town();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Town.TownId = Convert.ToInt32(dataRow["TownId"]);
                    Town.TownName = dataRow["TownName"].ToString();
                    
                }

                return Town;
            }

            return null;
        }
        public List<Town> AllList()
        {
            query = "select * from tbl_Town";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                Town Town;
                var Townlist = new List<Town>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Town = new Town();
                    Town.TownId = Convert.ToInt32(dataRow["TownId"]);
                    Town.TownName = dataRow["TownName"].ToString();
                   
                    Townlist.Add(Town);
                }

                return Townlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Townid),0) + 1 from tbl_Town";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}