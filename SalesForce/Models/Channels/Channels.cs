using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Channels
{
    public class Channels
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public bool Status { get; set; }
        public int SubchannelName { get; set; }
    }
    public class ChannelsHandler
    {
        private string query = "";
        public int Insert(Channels Channels)
        {
            query = "insert into tbl_Channels(ChannelId,ChannelName,SubChannelName)Values('";
            query = query + Channels.ChannelId + "','";
            query = query + Channels.ChannelName + "','";
            query = query + Channels.SubchannelName + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Channels Channels)
        {
            query = "update tbl_Channels set";
            query = query + " ChannelName = '" + Channels.ChannelName + "',";
            query = query + " SubChannelId = '" + Channels.SubchannelName + "'";
            query = query + " Where ChannelId = '" + Channels.ChannelId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Channels where ChannelId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Channels GetById(int id)
        {
            query = "select * from tbl_Channels Where ChannelId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Channels = new Channels();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Channels.ChannelId = Convert.ToInt32(dataRow["ChannelId"]);
                    Channels.ChannelName = dataRow["ChannelName"].ToString();
                    Channels.SubchannelName = Convert.ToInt32(dataRow["SubchannelName"]);
                }

                return Channels;
            }

            return null;
        }
        public List<Channels> AllList()
        {
            query = "select * from tbl_Channels";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                
                var Channelslist = new List<Channels>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    var Channels = new Channels();
                    Channels.ChannelId = Convert.ToInt32(dataRow["ChannelId"]);
                    Channels.ChannelName = dataRow["ChannelName"].ToString();
                    Channels.SubchannelName = Convert.ToInt32(dataRow["SubChannelName"]);
                    Channelslist.Add(Channels);
                }

                return Channelslist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Channelid),0) + 1 from tbl_Channels";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}