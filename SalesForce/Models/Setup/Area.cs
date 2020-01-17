using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;
using SalesForce.Models.Item_Catalog;

namespace SalesForce.Models.Setup
{
    public class Area
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string AreaCode { get; set; }
        public string Zone { get; set; }
        public string City { get; set; }
    }
    public class AreaHandler
    {
        private string query = "";
        public int Insert(Area area)
        {
            query = "insert into tbl_Area(AreaId,AreaName,AreaCode,Zone,City)Values('";
            query = query + area.AreaId + "','";
            query = query + area.AreaName + "','";
            query = query + area.AreaCode + "','";
            query = query + area.Zone + "','";
            query = query + area.City + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Area Area)
        {
            query = "update tbl_Area set";
            query = query + " AreaName = '" + Area.AreaName + "',";
            query = query + " AreaCode = '" + Area.AreaCode + "',";
            query = query + " Zone = '" + Area.Zone + "',";
            query = query + " City = '" + Area.City + "'";
            query = query + " Where AreaId = '" + Area.AreaId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Area where AreaId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Area GetById(int id)
        {
            query = "select * from tbl_Area Where AreaId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Area = new Area();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Area.AreaId = Convert.ToInt32(dataRow["AreaId"]);
                    Area.AreaName = dataRow["AreaName"].ToString();
                    Area.AreaCode = dataRow["AreaCode"].ToString();
                    Area.Zone = dataRow["Zone"].ToString();
                    Area.City = dataRow["City"].ToString();
                }

                return Area;
            }

            return null;
        }
        public List<Area> AllList()
        {
            query = "select * from tbl_Area";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                
                var Arealist = new List<Area>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    var Area = new Area();
                    Area.AreaId = Convert.ToInt32(dataRow["AreaId"]);
                    Area.AreaName = dataRow["AreaName"].ToString();
                    Area.AreaCode = dataRow["AreaCode"].ToString();
                    Area.Zone = dataRow["Zone"].ToString();
                    Area.City = dataRow["City"].ToString();
                    Arealist.Add(Area);
                }

                return Arealist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Areaid),0) + 1 from tbl_Area";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}