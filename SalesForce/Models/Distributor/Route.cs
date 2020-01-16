using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Distributor
{
    public class Route
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public string RouteDescription { get; set; }
        public bool Status { get; set; }
        public string JourneyPlans { get; set; }
        public int DistributorId { get; set; }
    }
    public class RouteHandler
    {
        private string query = "";
        public int Insert(Route Route)
        {
            query = "insert into tbl_Route(RouteId,RouteDescription,Status,journeyplans,DistributorId)Values('";
            query = query + Route.RouteId + "','";
            query = query + Route.RouteDescription + "','";
            query = query + Route.Status + "','";
            query = query + Route.JourneyPlans + "','";
            query = query + Route.DistributorId + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Route Route)
        {
            query = "update tbl_Route set";
            query = query + " RouteDescription = '" + Route.RouteDescription + "',";
            query = query + " Status = '" + Route.Status + "',";
            query = query + " journeyplans = '" + Route.JourneyPlans + "',";
            query = query + " DistributorId = '" + Route.DistributorId + "'";
            query = query + " Where RouteId = '" + Route.RouteId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Route where RouteId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Route GetById(int id)
        {
            query = "select * from tbl_Route Where RouteId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Route = new Route();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Route.RouteId = Convert.ToInt32(dataRow["RouteId"]);
                    Route.RouteDescription = dataRow["RouteDescription"].ToString();
                    Route.DistributorId = Convert.ToInt32(dataRow["DistributorID"]);
                    Route.Status = Convert.ToBoolean(dataRow["Status"]);
                    Route.JourneyPlans = dataRow["JourneyPlans"].ToString();

                }

                return Route;
            }

            return null;
        }
        public List<Route> AllList()
        {
            query = "select * from tbl_Route";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Route = new Route();
                var Routelist = new List<Route>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Route.RouteId = Convert.ToInt32(dataRow["RouteId"]);
                    Route.RouteDescription = dataRow["RouteDescription"].ToString();
                    Route.DistributorId = Convert.ToInt32(dataRow["DistributorID"]);
                    Route.Status = Convert.ToBoolean(dataRow["Status"]);
                    Route.JourneyPlans = dataRow["JourneyPlans"].ToString();
                    Routelist.Add(Route);
                }

                return Routelist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Routeid),0) + 1 tbl_Route";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}