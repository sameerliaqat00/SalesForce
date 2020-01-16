using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Distributor
{
    public class Section
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string SectionDescription { get; set; }
        public int DistributorId { get; set; }
        public bool Status { get; set; }
    }
    public class SectionHandler
    {
        private string query = "";
        public int Insert(Section Section)
        {
            query = "insert into tbl_Section(SectionId,SectionDescription,DistributorId,Status)Values('";
            query = query + Section.SectionId + "','";
            query = query + Section.SectionDescription + "','";
            query = query + Section.DistributorId + "','";
            query = query + Section.Status + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Section Section)
        {
            query = "update tbl_Section set";
            query = query + " SectionDescription = '" + Section.SectionDescription + "',";
            query = query + " DistributorId = '" + Section.DistributorId + "',";
            query = query + " Status = '" + Section.Status + "'";
            query = query + " Where SectionId = '" + Section.SectionId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Section where SectionId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Section GetById(int id)
        {
            query = "select * from tbl_Section Where SectionId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Section = new Section();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Section.SectionId = Convert.ToInt32(dataRow["SectionId"]);
                    Section.SectionDescription = dataRow["SectionDescription"].ToString();
                    Section.DistributorId = Convert.ToInt32(dataRow["DistributorID"]);
                    Section.Status = Convert.ToBoolean(dataRow["Status"]);
                }

                return Section;
            }

            return null;
        }
        public List<Section> AllList()
        {
            query = "select * from tbl_Section";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Section = new Section();
                var Sectionlist = new List<Section>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Section.SectionId = Convert.ToInt32(dataRow["SectionId"]);
                    Section.SectionDescription = dataRow["SectionDescription"].ToString();
                    Section.DistributorId = Convert.ToInt32(dataRow["DistributorID"]);
                    Section.Status = Convert.ToBoolean(dataRow["Status"]);
                    Sectionlist.Add(Section);
                }

                return Sectionlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Sectionid),0) + 1 tbl_Section";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}