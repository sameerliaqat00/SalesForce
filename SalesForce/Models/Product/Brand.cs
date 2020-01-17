using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Product
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ShorDescription { get; set; }
        public string MarketPlayer { get; set; }
        public string Division { get; set; }
        public string ProductGroup { get; set; }
        public string Category { get; set; }
        public string Package { get; set; }
        public int SapCode { get; set; }

    }
    public class BrandHandler
    {
        private string query = "";
        public int Insert(Brand Brand)
        {
            query = "insert into tbl_Brand(BrandId,BrandName,ShortDescription,MarketPlayer,Division,ProductGroup,Category,Package,SapCode)Values('";
            query = query + Brand.BrandId + "','";
            query = query + Brand.BrandName + "','";
            query = query + Brand.ShorDescription + "','";
            query = query + Brand.MarketPlayer + "','";
            query = query + Brand.Division + "','";
            query = query + Brand.ProductGroup + "','";
            query = query + Brand.Category + "','";
            query = query + Brand.Package + "','";
            query = query + Brand.SapCode + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Brand Brand)
        {
            query = "update tbl_Brand set";
            query = query + " BrandName = '" + Brand.BrandName + "',";
            query = query + " ShorDescription = '" + Brand.ShorDescription + "',";
            query = query + " MarketPlayer = '" + Brand.MarketPlayer + "',";
            query = query + " Division = '" + Brand.Division + "',";
            query = query + " ProductGroup = '" + Brand.ProductGroup + "',";
            query = query + " Category = '" + Brand.Category + "',";
            query = query + " Package = '" + Brand.Package + "',";
            query = query + " SapCode = '" + Brand.SapCode + "'";
            query = query + " Where BrandId = '" + Brand.BrandId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Brand where BrandId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Brand GetById(int id)
        {
            query = "select * from tbl_Brand Where BrandId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Brand = new Brand();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Brand.BrandId = Convert.ToInt32(dataRow["BrandId"]);
                    Brand.BrandName = dataRow["BrandName"].ToString();
                    Brand.ShorDescription = dataRow["ShorDescription"].ToString();
                    Brand.MarketPlayer = dataRow["MarketPlayer"].ToString();
                    Brand.Division = dataRow["Division"].ToString();
                    Brand.ProductGroup = dataRow["ProductGroup"].ToString();
                    Brand.Category = dataRow["Category"].ToString();
                    Brand.Package = dataRow["Package"].ToString();
                    Brand.SapCode = Convert.ToInt32(dataRow["SapCode"]);
                }

                return Brand;
            }

            return null;
        }
        public List<Brand> AllList()
        {
            query = "select * from tbl_Brand";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Brand = new Brand();
                var Brandlist = new List<Brand>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Brand.BrandId = Convert.ToInt32(dataRow["BrandId"]);
                    Brand.BrandName = dataRow["BrandName"].ToString();
                    Brand.ShorDescription = dataRow["ShorDescription"].ToString();
                    Brand.MarketPlayer = dataRow["MarketPlayer"].ToString();
                    Brand.Division = dataRow["Division"].ToString();
                    Brand.ProductGroup = dataRow["ProductGroup"].ToString();
                    Brand.Category = dataRow["Category"].ToString();
                    Brand.Package = dataRow["Package"].ToString();
                    Brand.SapCode = Convert.ToInt32(dataRow["SapCode"]);
                    Brandlist.Add(Brand);
                }

                return Brandlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(BrandId),0) + 1 tbl_Brand";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}