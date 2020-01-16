using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;
using SalesForce.Models.Distributor;

namespace SalesForce.Models.Retailer
{
    public class Retailers
    {
        public int Id { get; set; }
        public int RetailerId { get; set; }
        public string RetailerName { get; set; }
        public string RetailerCode { get; set; }
        public string ShopName { get; set; }
        public string CNIC { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string HeadType { get; set; }
        public string HeadName { get; set; }
        public int ZoneId { get; set; }
        public int SalesOfficerId { get; set; }
        public int AreaId { get; set; }
    }
    public class RetailersHandler
    {
        private string query = "";
        public int Insert(Retailers retailers)
        {
            query = "insert into tbl_Retailers(RetailerId,RetailerName,RetailerCode,ShopName,CNIC,Email,Address,Phone,HeadType,Headname,ZoneId,SalesOfficerId,AreaId)Values('";
            query = query + retailers.RetailerId + "','";
            query = query + retailers.RetailerName + "','";
            query = query + retailers.RetailerCode + "','";
            query = query + retailers.ShopName + "','";
            query = query + retailers.CNIC + "','";
            query = query + retailers.Email + "','";
            query = query + retailers.Address + "','";
            query = query + retailers.Phone + "','";
            query = query + retailers.HeadType + "','";
            query = query + retailers.HeadName + "','";
            query = query + retailers.ZoneId + "','";
            query = query + retailers.SalesOfficerId + "','";
            query = query + retailers.AreaId + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Retailers retailers)
        {
            query = "update tbl_Retailers set";
            query = query + " RetailerName = '" + retailers.RetailerName + "',";
            query = query + " RetailerCode = '" + retailers.RetailerCode + "',";
            query = query + " ShopName = '" + retailers.ShopName + "',";
            query = query + " CNIC = '" + retailers.CNIC + "',";
            query = query + " Email = '" + retailers.Email + "',";
            query = query + " Address = '" + retailers.Address + "',";
            query = query + " Phone = '" + retailers.Phone + "',";
            query = query + " HeadType = '" + retailers.HeadType + "',";
            query = query + " Headname = '" + retailers.HeadName + "',";
            query = query + " ZoneId = '" + retailers.ZoneId + "',";
            query = query + " SalesOfficerId = '" + retailers.SalesOfficerId + "',";
            query = query + " AreaId = '" + retailers.AreaId + "'";
            query = query + " Where RetailerId = '" + retailers.RetailerId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Retailers where RetailerId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Retailers GetById(int id)
        {
            query = "select * from tbl_Retailers Where RetailerId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Retailers = new Retailers();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Retailers.RetailerId = Convert.ToInt32(dataRow["Retailerid"]);
                    Retailers.RetailerName = dataRow["RetailerName"].ToString();
                    Retailers.RetailerCode = dataRow["RetailerCode"].ToString();
                    Retailers.ShopName = dataRow["ShopName"].ToString();
                    Retailers.CNIC = dataRow["CNIC"].ToString();
                    Retailers.Email = dataRow["Email"].ToString();
                    Retailers.Address = dataRow["Address"].ToString();
                    Retailers.Phone = dataRow["Phone"].ToString();
                    Retailers.HeadType = dataRow["HeadType"].ToString();
                    Retailers.HeadName = dataRow["HeadName"].ToString();
                    Retailers.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                    Retailers.SalesOfficerId = Convert.ToInt32(dataRow["SalesOfficerId"]);
                    Retailers.AreaId = Convert.ToInt32(dataRow["AreaId"]);
                   
                }

                return Retailers;
            }

            return null;
        }
        public List<Retailers> AllList()
        {
            query = "select * from tbl_Retailers";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var retailers = new Retailers();
                var retailerslist = new List<Retailers>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    retailers.RetailerId = Convert.ToInt32(dataRow["Retailerid"]);
                    retailers.RetailerName = dataRow["RetailerName"].ToString();
                    retailers.RetailerCode = dataRow["RetailerCode"].ToString();
                    retailers.ShopName = dataRow["ShopName"].ToString();
                    retailers.CNIC = dataRow["CNIC"].ToString();
                    retailers.Email = dataRow["Email"].ToString();
                    retailers.Address = dataRow["Address"].ToString();
                    retailers.Phone = dataRow["Phone"].ToString();
                    retailers.HeadType = dataRow["HeadType"].ToString();
                    retailers.HeadName = dataRow["HeadName"].ToString();
                    retailers.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                    retailers.SalesOfficerId = Convert.ToInt32(dataRow["SalesOfficerId"]);
                    retailers.AreaId = Convert.ToInt32(dataRow["AreaId"]);
                    retailerslist.Add(retailers);
                }
                return retailerslist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Retailerid),0) + 1 tbl_Retailers";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}