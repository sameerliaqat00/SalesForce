using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;
using SalesForce.Models.Distributor;

namespace SalesForce.Models.Regional_Head
{
    public class RegionalHead
    {
        public int Id { get; set; }
        public int RegionalHeadId { get; set; }
        public string RegionalHeadName { get; set; }
        public string Phone { get; set; }
        public string HeadId { get; set; }
        public string RegionId { get; set; }
    }
    public class RegionalHeadHandler
    {
        private string query = "";
        public int Insert(RegionalHead regionalhead)
        {
            query = "insert into tbl_RegionalHead(RegionalHeadId,RegionalHeadName,Phone,HeadId,RegionId)Values('";
            query = query + regionalhead.RegionalHeadId + "','";
            query = query + regionalhead.RegionalHeadName + "','";
            query = query + regionalhead.Phone + "','";
            query = query + regionalhead.HeadId + "','";
            query = query + regionalhead.RegionId + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(RegionalHead regionalhead)
        {
            query = "update tbl_RegionalHead set";
            query = query + " RegionalHeadName = '" + regionalhead.RegionalHeadName + "',";
            query = query + " Phone = '" + regionalhead.Phone + "',";
            query = query + " HeadId = '" + regionalhead.HeadId + "',";
            query = query + " RegionId = '" + regionalhead.RegionId + "'";
            query = query + " Where RegionalHeadId = '" + regionalhead.RegionalHeadId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_RegionalHead where RegionalHeadId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public RegionalHead GetById(int id)
        {
            query = "select * from tbl_RegionalHead Where DistributorId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var regionalhead = new RegionalHead();
                foreach (DataRow dataRow in Data.Rows)
                {
                    regionalhead.RegionalHeadId = Convert.ToInt32(dataRow["RegionalHeadId"]);
                    regionalhead.RegionalHeadName = dataRow["RegionalHeadName"].ToString();
                    regionalhead.Phone = dataRow["Phone"].ToString();
                    regionalhead.HeadId = dataRow["HeadId"].ToString();
                    regionalhead.RegionId = dataRow["RegionId"].ToString();
                }

                return regionalhead;
            }

            return null;
        }
        public List<RegionalHead> AllList()
        {
            query = "select * from tbl_RegionalHead";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var regionalhead = new RegionalHead();
                var regionalheadlist = new List<RegionalHead>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    regionalhead.RegionalHeadId = Convert.ToInt32(dataRow["RegionalHeadId"]);
                    regionalhead.RegionalHeadName = dataRow["RegionalHeadName"].ToString();
                    regionalhead.Phone = dataRow["Phone"].ToString();
                    regionalhead.HeadId = dataRow["HeadId"].ToString();
                    regionalhead.RegionId = dataRow["RegionId"].ToString();
                    regionalheadlist.Add(regionalhead);
                }
                return regionalheadlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select max(isnull(RegionalHeadId),0) + 1 tbl_RegionalHead";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}