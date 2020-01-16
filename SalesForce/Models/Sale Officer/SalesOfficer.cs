using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Sale_Officer
{
    public class SalesOfficer
    {
        public int Id { get; set; }
        public int SalesOfficerId { get; set; }
        public string SalesOfficerName { get; set; }
        public string SalesOfficerPhone{ get; set; }
        public string HeadType{ get; set; }
        public string HeadName{ get; set; }
        public int ZoneId { get; set; }
        public int CityId { get; set; }
        public int DistributorId { get; set; }

    }
    public class SalesOfficerHandler
    {
        private string query = "";
        public int Insert(SalesOfficer salesofficer)
        {
            query = "insert into tbl_SalesOfficer(SalesOfficerId,SalesOfficerName,SalesOfficerPhone,HeadType,Headname,ZoneId,CityId,DistributorId)Values('";
            query = query + salesofficer.SalesOfficerId + "','";
            query = query + salesofficer.SalesOfficerName + "','";
            query = query + salesofficer.SalesOfficerPhone + "','";
            query = query + salesofficer.HeadType + "','";
            query = query + salesofficer.HeadName + "','";
            query = query + salesofficer.ZoneId + "','";
            query = query + salesofficer.CityId + "','";
            query = query + salesofficer.DistributorId + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(SalesOfficer salesofficer)
        {
            query = "update tbl_SalesOfficer set";
            query = query + " SalesOfficerName = '" + salesofficer.SalesOfficerName + "',";
            query = query + " SalesOfficerPhone = '" + salesofficer.SalesOfficerPhone + "',";
            query = query + " HeadType = '" + salesofficer.HeadType + "',";
            query = query + " HeadName = '" + salesofficer.HeadName + "',";
            query = query + " ZoneId = '" + salesofficer.ZoneId + "',";
            query = query + " CityID = '" + salesofficer.CityId + "',";
            query = query + " DistributorId = '" + salesofficer.DistributorId + "'";
            query = query + " Where SalesOfficerId = '" + salesofficer.SalesOfficerId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_SalesOfficer where SalesOfficerId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public SalesOfficer GetById(int id)
        {
            query = "select * from tbl_SalesOfficer Where SalesOfficerId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var salesofficer = new SalesOfficer();
                foreach (DataRow dataRow in Data.Rows)
                {
                    salesofficer.SalesOfficerId = Convert.ToInt32(dataRow["SalesOfficerId"]);
                    salesofficer.SalesOfficerName = dataRow["SalesOfficerName"].ToString();
                    salesofficer.SalesOfficerPhone = dataRow["SalesOfficerPhone"].ToString();
                    salesofficer.HeadType = dataRow["HeadType"].ToString();
                    salesofficer.HeadName = dataRow["HeadName"].ToString();
                    salesofficer.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                    salesofficer.CityId = Convert.ToInt32(dataRow["CityId"]);
                    salesofficer.DistributorId = Convert.ToInt32(dataRow["DistributorId"]);
                }

                return salesofficer;
            }

            return null;
        }
        public List<SalesOfficer> AllList()
        {
            query = "select * from tbl_SalesOfficer";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var salesofficer = new SalesOfficer();
                var salesofficerlist = new List<SalesOfficer>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    salesofficer.SalesOfficerId = Convert.ToInt32(dataRow["SalesOfficerId"]);
                    salesofficer.SalesOfficerName = dataRow["SalesOfficerName"].ToString();
                    salesofficer.SalesOfficerPhone = dataRow["SalesOfficerPhone"].ToString();
                    salesofficer.HeadType = dataRow["HeadType"].ToString();
                    salesofficer.HeadName = dataRow["HeadName"].ToString();
                    salesofficer.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                    salesofficer.CityId = Convert.ToInt32(dataRow["CityId"]);
                    salesofficer.DistributorId = Convert.ToInt32(dataRow["DistributorId"]);
                    salesofficerlist.Add(salesofficer);
                }
                return salesofficerlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(SalesOfficerId),0) + 1 tbl_SalesOfficer";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}