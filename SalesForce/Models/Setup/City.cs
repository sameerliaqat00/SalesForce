using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Setup
{
    public class City
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public int ZoneId { get; set; }
    }
    public class CityHandler
    {
        private string query = "";
        public int Insert(City city)
        {
            query = "insert into tbl_City(CityId,CityName,CityCode,ZoneId)Values('";
            query = query + city.CityId + "','";
            query = query + city.CityName + "','";
            query = query + city.CityCode + "','";
            query = query + city.ZoneId + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(City City)
        {
            query = "update tbl_City set";
            query = query + " CityName = '" + City.CityName + "',";
            query = query + " CityCode = '" + City.CityCode + "',";
            query = query + " ZoneId = '" + City.ZoneId + "'";
            query = query + " Where CityId = '" + City.CityId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_City where CityId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public City GetById(int id)
        {
            query = "select * from tbl_City Where CityId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var City = new City();
                foreach (DataRow dataRow in Data.Rows)
                {
                    City.CityId = Convert.ToInt32(dataRow["CityId"]);
                    City.CityName = dataRow["CityName"].ToString();
                    City.CityCode = dataRow["CityCode"].ToString();
                    City.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                }

                return City;
            }

            return null;
        }
        public List<City> AllList()
        {
            query = "select * from tbl_City";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var City = new City();
                var Citylist = new List<City>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    City.CityId = Convert.ToInt32(dataRow["CityId"]);
                    City.CityName = dataRow["CityName"].ToString();
                    City.CityCode = dataRow["CityCode"].ToString();
                    City.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                    Citylist.Add(City);
                }

                return Citylist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Cityid),0) + 1 tbl_City";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}