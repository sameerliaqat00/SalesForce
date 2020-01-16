﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Setup
{
    public class Zone
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
    }
    public class ZoneHandler
    {
        private string query = "";
        public int Insert(Zone itemctCategory)
        {
            query = "insert into tbl_Zone(ZoneId,ZoneName,ZoneCode)Values('";
            query = query + itemctCategory.ZoneId + "','";
            query = query + itemctCategory.ZoneName + "','";
            query = query + itemctCategory.ZoneCode + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Zone Zone)
        {
            query = "update tbl_Zone set";
            query = query + " ZoneName = '" + Zone.ZoneName + "',";
            query = query + " ZoneCode = '" + Zone.ZoneCode + "'";
            query = query + " Where ZoneId = '" + Zone.ZoneId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Zone where ZoneId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Zone GetById(int id)
        {
            query = "select * from tbl_Zone Where ZoneId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Zone = new Zone();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Zone.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                    Zone.ZoneName = dataRow["ZoneName"].ToString();
                    Zone.ZoneCode = dataRow["ZoneCode"].ToString();
                }

                return Zone;
            }

            return null;
        }
        public List<Zone> AllList()
        {
            query = "select * from tbl_Zone";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Zone = new Zone();
                var Zonelist = new List<Zone>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Zone.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                    Zone.ZoneName = dataRow["ZoneName"].ToString();
                    Zone.ZoneCode = dataRow["ZoneCode"].ToString();
                    Zonelist.Add(Zone);
                }

                return Zonelist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Zoneid),0) + 1 tbl_Zone";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}