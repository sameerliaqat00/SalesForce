using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;
using SalesForce.Models.Setup;

namespace SalesForce.Models.Company
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Domain { get; set; }
        public string NTN { get; set; }
        public string GST { get; set; }
    }
    public class CompanyHandler
    {
        private string query = "";
        public int Insert(Company company)
        {
            query = "insert into tbl_Company(CompanyId,CompanyName,ShortName,Address,Phone,Fax,Website,Domain,NTN,GST)Values('";
            query = query + company.CompanyId + "','";
            query = query + company.CompanyName + "','";
            query = query + company.ShortName + "','";
            query = query + company.Address + "','";
            query = query + company.Phone + "','";
            query = query + company.Fax + "','";
            query = query + company.Website + "','";
            query = query + company.Domain + "','";
            query = query + company.NTN + "','";
            query = query + company.GST + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Company Company)
        {
            query = "update tbl_Company set";
            query = query + " CompanyName = '" + Company.CompanyName + "',";
            query = query + " ShortName = '" + Company.ShortName + "',";
            query = query + " Address = '" + Company.Address + "',";
            query = query + " Phone = '" + Company.Phone + "',";
            query = query + " Fax = '" + Company.Fax + "',";
            query = query + " Website = '" + Company.Website + "',";
            query = query + " Domain = '" + Company.Domain + "',";
            query = query + " NTN = '" + Company.NTN + "',";
            query = query + " GST = '" + Company.GST + "'";
            query = query + " Where CompanyId = '" + Company.CompanyId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Company where CompanyId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Company GetById(int id)
        {
            query = "select * from tbl_Company Where CompanyId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var Company = new Company();
                foreach (DataRow dataRow in Data.Rows)
                {
                    Company.CompanyId = Convert.ToInt32(dataRow["CompanyId"]);
                    Company.CompanyName = dataRow["CompanyName"].ToString();
                    Company.ShortName = dataRow["ShortName"].ToString();
                    Company.Address = dataRow["Address"].ToString();
                    Company.Phone = dataRow["Phone"].ToString();
                    Company.Fax = dataRow["Fax"].ToString();
                    Company.Website = dataRow["Website"].ToString();
                    Company.Domain = dataRow["Domain"].ToString();
                    Company.NTN = dataRow["NTN"].ToString();
                    Company.GST = dataRow["GST"].ToString();
                }

                return Company;
            }

            return null;
        }
        public List<Company> AllList()
        {
            query = "select * from tbl_Company";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
               
                var Companylist = new List<Company>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    var Company = new Company();
                    Company.CompanyId = Convert.ToInt32(dataRow["CompanyId"]);
                    Company.CompanyName = dataRow["CompanyName"].ToString();
                    Company.ShortName = dataRow["ShortName"].ToString();
                    Company.Address = dataRow["Address"].ToString();
                    Company.Phone = dataRow["Phone"].ToString();
                    Company.Fax = dataRow["Fax"].ToString();
                    Company.Website = dataRow["Website"].ToString();
                    Company.Domain = dataRow["Domain"].ToString();
                    Company.NTN = dataRow["NTN"].ToString();
                    Company.GST = dataRow["GST"].ToString();
                    Companylist.Add(Company);
                }

                return Companylist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(Companyid),0) + 1 from tbl_Company";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }

}