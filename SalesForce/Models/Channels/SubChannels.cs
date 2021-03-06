﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Channels
{
    public class SubChannels
    {
        public int Id { get; set; }
        public int SubchannelId { get; set; }
        public string SubchannelName { get; set; }
    }
    public class SubChannelsHandler
    {
        private string query = "";
        public int Insert(SubChannels SubChannels)
        {
            query = "insert into tbl_SubChannels(SubChannelId,SubChannelName)Values('";
            query = query + SubChannels.SubchannelId + "','";
            query = query + SubChannels.SubchannelName + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(SubChannels SubChannels)
        {
            query = "update tbl_SubChannels set";
            query = query + " SubChannelName = '" + SubChannels.SubchannelName + "'";
            query = query + " Where SubChannelId = '" + SubChannels.SubchannelId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_SubChannels where SubChannelId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public SubChannels GetById(int id)
        {
            query = "select * from tbl_SubChannels Where ChannelId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var SubChannels = new SubChannels();
                foreach (DataRow dataRow in Data.Rows)
                {
                    SubChannels.SubchannelId = Convert.ToInt32(dataRow["SubChannelId"]);
                    SubChannels.SubchannelName = dataRow["SubChannelName"].ToString();
                   
                }

                return SubChannels;
            }

            return null;
        }
        public List<SubChannels> AllList()
        {
            query = "select * from tbl_SubChannels";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                
                var SubChannelslist = new List<SubChannels>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    var SubChannels = new SubChannels();
                    SubChannels.SubchannelId = Convert.ToInt32(dataRow["SubChannelId"]);
                    SubChannels.SubchannelName = dataRow["SubChannelName"].ToString();
                    
                    SubChannelslist.Add(SubChannels);
                }

                return SubChannelslist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(SubChannelId),0) + 1 from tbl_SubChannels";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}