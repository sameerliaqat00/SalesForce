using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Product
{
    public class StockKeepingUnit
    {
        public int StockKeepingUnitId { get; set; }
        public string StockKeepingUnitName { get; set; }
        public string ShortName { get; set; }
        public bool Status { get; set; }
        public string CompanyName { get; set; }
        public string Division { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Brand { get; set; }
        public string Flavor { get; set; }
        public string Package { get; set; }
        public int SapCode { get; set; }
    }
    public class StockKeepingUnitHandler
    {
        private string query = "";
        public int Insert(StockKeepingUnit StockKeepingUnit)
        {
            query = "insert into tbl_StockKeepingUnit(StockKeepingUnitId,StockKeepingUnitName,ShortName,CompanyName,Division,Category,SubCategory,Brand,Flavor,Package,SapCode)Values('";
            query = query + StockKeepingUnit.StockKeepingUnitId + "','";
            query = query + StockKeepingUnit.StockKeepingUnitName + "','";
            query = query + StockKeepingUnit.ShortName + "','";
            query = query + StockKeepingUnit.CompanyName + "','";
            query = query + StockKeepingUnit.Division + "','";
            query = query + StockKeepingUnit.Category + "','";
            query = query + StockKeepingUnit.SubCategory + "','";
            query = query + StockKeepingUnit.Brand + "','";
            query = query + StockKeepingUnit.Flavor + "','";
            query = query + StockKeepingUnit.Package + "','";
            query = query + StockKeepingUnit.SapCode + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(StockKeepingUnit StockKeepingUnit)
        {
            query = "update tbl_StockKeepingUnit set";
            query = query + " StockKeepingUnitName = '" + StockKeepingUnit.StockKeepingUnitName + "',";
            query = query + " ShortName = '" + StockKeepingUnit.ShortName + "',";
            query = query + " CompanyName = '" + StockKeepingUnit.CompanyName + "',";
            query = query + " Division = '" + StockKeepingUnit.Division + "',";
            query = query + " Category = '" + StockKeepingUnit.Category + "',";
            query = query + " SubCategory = '" + StockKeepingUnit.SubCategory + "',";
            query = query + " Brand = '" + StockKeepingUnit.Brand + "',";
            query = query + " Flavor = '" + StockKeepingUnit.Flavor + "',";
            query = query + " Package = '" + StockKeepingUnit.Package + "',";
            query = query + " SapCode = '" + StockKeepingUnit.SapCode + "'";
            query = query + " Where StockKeepingUnitId = '" + StockKeepingUnit.StockKeepingUnitId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_StockKeepingUnit where StockKeepingUnitId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public StockKeepingUnit GetById(int id)
        {
            query = "select * from tbl_StockKeepingUnit Where StockKeepingUnitId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var StockKeepingUnit = new StockKeepingUnit();
                foreach (DataRow dataRow in Data.Rows)
                {
                    StockKeepingUnit.StockKeepingUnitId = Convert.ToInt32(dataRow["StockKeepingUnitId"]);
                    StockKeepingUnit.StockKeepingUnitName = dataRow["StockKeepingUnitName"].ToString();
                    StockKeepingUnit.ShortName = dataRow["ShoreName"].ToString();
                    StockKeepingUnit.CompanyName = dataRow["CompanyName"].ToString();
                    StockKeepingUnit.Division = dataRow["Division"].ToString();
                    StockKeepingUnit.Category = dataRow["Category"].ToString();
                    StockKeepingUnit.SubCategory = dataRow["SubCategory"].ToString();
                    StockKeepingUnit.Brand = dataRow["Brand"].ToString();
                    StockKeepingUnit.Flavor = dataRow["Flavor"].ToString();
                    StockKeepingUnit.Package = dataRow["Package"].ToString();
                    StockKeepingUnit.SapCode = Convert.ToInt32(dataRow["SapCode"]);
                }

                return StockKeepingUnit;
            }

            return null;
        }
        public List<StockKeepingUnit> AllList()
        {
            query = "select * from tbl_StockKeepingUnit";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var StockKeepingUnit = new StockKeepingUnit();
                var StockKeepingUnitlist = new List<StockKeepingUnit>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    StockKeepingUnit.StockKeepingUnitId = Convert.ToInt32(dataRow["StockKeepingUnitId"]);
                    StockKeepingUnit.StockKeepingUnitName = dataRow["StockKeepingUnitName"].ToString();
                    StockKeepingUnit.ShortName = dataRow["ShoreName"].ToString();
                    StockKeepingUnit.CompanyName = dataRow["CompanyName"].ToString();
                    StockKeepingUnit.Division = dataRow["Division"].ToString();
                    StockKeepingUnit.Category = dataRow["Category"].ToString();
                    StockKeepingUnit.SubCategory = dataRow["SubCategory"].ToString();
                    StockKeepingUnit.Brand = dataRow["Brand"].ToString();
                    StockKeepingUnit.Flavor = dataRow["Flavor"].ToString();
                    StockKeepingUnit.Package = dataRow["Package"].ToString();
                    StockKeepingUnit.SapCode = Convert.ToInt32(dataRow["SapCode"]);
                    StockKeepingUnitlist.Add(StockKeepingUnit);
                }

                return StockKeepingUnitlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(StockKeepingUnitId),0) + 1 tbl_StockKeepingUnit";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}