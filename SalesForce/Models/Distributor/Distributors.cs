using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;
using SalesForce.Models.Item_Catalog;

namespace SalesForce.Models.Distributor
{
    public class Distributors
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public string DistributorName { get; set; }
        public bool Status { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }

        public string Lattitude { get; set; }
        public string Longtitude { get; set; }
        public string Division { get; set; }
        public string ParentType { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string  SapCode { get; set; }
        public string Location { get; set; }
        //Owner Details
        public string ContactPerson { get; set; }
        public string FatherName { get; set; }
        public string CNIC { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhone { get; set; }
        public string NTN { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Url { get; set; }
        public string ManageInventory { get; set; }
        public string ContactPersonAddress { get; set; }
        //Hierachical Details
        public int RegionId { get; set; }
        public int AreaId { get; set; }
        public int ZoneId { get; set; }
        public string Town { get; set; }
    }
    public class DistributorsHandler
    {
        private string query = "";
        public int Insert(Distributors distributors)
        {
            query = "insert into tbl_Distributors(DistributorId,DistributorName,Status,Logo,Address,lattitude,longtitude,division,parenttype,contractstartdate,contractenddate,registrationdate,sapcode,location,ContactPerson,FatherName,Cnic,PhoneNumber,CellPhone,NTN,Email,Fax,Url,ManageInventory,ContactPersonAddress,RegionId,AreaId,ZoneId,Town)Values('";
            query = query + distributors.DistributorId + "','";
            query = query + distributors.DistributorName + "','";
            query = query + distributors.Status + "','";
            query = query + distributors.Logo + "','";
            query = query + distributors.Address + "','";

            query = query + distributors.Lattitude + "','";
            query = query + distributors.Longtitude + "','";
            query = query + distributors.Division + "','";
            query = query + distributors.ParentType + "','";
            query = query + distributors.ContractStartDate + "','";
            query = query + distributors.ContractEndDate + "','";
            query = query + distributors.RegistrationDate + "','";
            query = query + distributors.SapCode + "','";
            query = query + distributors.Location + "','";

            query = query + distributors.ContactPerson + "','";
            query = query + distributors.FatherName + "','";
            query = query + distributors.CNIC + "','";
            query = query + distributors.PhoneNumber + "','";
            query = query + distributors.CellPhone + "','";
            query = query + distributors.NTN + "','";
            query = query + distributors.Email + "','";
            query = query + distributors.Fax + "','";
            query = query + distributors.Url + "','";
            query = query + distributors.ManageInventory + "','";
            query = query + distributors.ContactPersonAddress + "','";
            query = query + distributors.RegionId + "','";
            query = query + distributors.AreaId + "','";
            query = query + distributors.ZoneId + "','";
            query = query + distributors.Town + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Distributors distributors)
        {
            query = "update tbl_Distributors set";
            query = query + " DistributorName = '" + distributors.DistributorName + "',";
            query = query + " Status = '" + distributors.Status + "',";
            query = query + " Logo = '" + distributors.Logo + "',";
            query = query + " Address = '" + distributors.Address + "',";
            query = query + " Latitude = '" + distributors.Lattitude + "',";
            query = query + " Longtitude = '" + distributors.Longtitude + "',";
            query = query + " Division = '" + distributors.Division + "',";
            query = query + " ParentType = '" + distributors.ParentType + "',";
            query = query + " ContractStartDate = '" + distributors.ContactPersonAddress + "',";
            query = query + " ContractEndDate = '" + distributors.ContractEndDate + "',";
            query = query + " RegistrationDate = '" + distributors.RegistrationDate + "',";
            query = query + " SapCode = '" + distributors.SapCode + "',";
            query = query + " Location = '" + distributors.Location + "',";
            query = query + " ContactPerson = '" + distributors.ContactPerson + "',";
            query = query + " FatherName = '" + distributors.FatherName + "',";
            query = query + " CNIC = '" + distributors.CNIC + "',";
            query = query + " PhoneNumber = '" + distributors.PhoneNumber + "',";
            query = query + " CellPHone = '" + distributors.CellPhone + "',";
            query = query + " NTN = '" + distributors.NTN + "',";
            query = query + " Email = '" + distributors.Email + "',";
            query = query + " Fax = '" + distributors.Fax + "',";
            query = query + " Url = '" + distributors.Url + "',";
            query = query + " ManageInventory = '" + distributors.ManageInventory + "',";
            query = query + " ContactPersonAddress = '" + distributors.ContactPersonAddress + "',";
            query = query + " RgionId = '" + distributors.RegionId + "',";
            query = query + " AreaId = '" + distributors.AreaId + "',";
            query = query + " ZoneId = '" + distributors.ZoneId + "',";
            query = query + " Town = '" + distributors.Town + "'";
            query = query + " Where DistributorId = '" + distributors.DistributorId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Distributors where DistributorId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Distributors GetById(int id)
        {
            query = "select * from tbl_Distributors Where DistributorId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var distributors = new Distributors();
                foreach (DataRow dataRow in Data.Rows)
                {
                    distributors.DistributorId = Convert.ToInt32(dataRow["DistributorId"]);
                    distributors.DistributorName = dataRow["distributorName"].ToString();
                    distributors.Status = Convert.ToBoolean(dataRow["Status"]);
                    distributors.Logo = dataRow["Logo"].ToString();

                    distributors.Address = dataRow["Address"].ToString();
                    distributors.Address = dataRow["Latitude"].ToString();
                    distributors.Address = dataRow["Longtitude"].ToString();
                    distributors.Address = dataRow["Division"].ToString();
                    distributors.Address = dataRow["ParentType"].ToString();
                    distributors.Address = dataRow["ContractStartDate"].ToString();
                    distributors.Address = dataRow["ContractEndDate"].ToString();
                    distributors.Address = dataRow["RegistrationDate"].ToString();
                    distributors.Address = dataRow["SapCode"].ToString();
                    distributors.Address = dataRow["Location"].ToString();

                    distributors.ContactPerson = dataRow["ContactPerson"].ToString();
                    distributors.FatherName = dataRow["FatherName"].ToString();
                    distributors.CNIC = dataRow["CNIC"].ToString();
                    distributors.PhoneNumber = dataRow["PhoneNumber"].ToString();
                    distributors.CellPhone = dataRow["CellPHone"].ToString();
                    distributors.NTN = dataRow["NTN"].ToString();
                    distributors.Email = dataRow["Email"].ToString();
                    distributors.Fax = dataRow["Fax"].ToString();
                    distributors.Url = dataRow["Url"].ToString();
                    distributors.ManageInventory = dataRow["ManageInventory"].ToString();
                    distributors.ContactPersonAddress = dataRow["ContactPersonAddress"].ToString();
                    distributors.RegionId = Convert.ToInt32(dataRow["RegionId"]);
                    distributors.AreaId = Convert.ToInt32(dataRow["AreaId"]);
                    distributors.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                    distributors.Town = dataRow["Town"].ToString();
                   
                  
                }

                return distributors;
            }

            return null;
        }
        public List<Distributors> AllList()
        {
            query = "select * from tbl_Distributors";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var distributors = new Distributors();
                var distributorslist = new List<Distributors>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    distributors.DistributorId = Convert.ToInt32(dataRow["DistributorId"]);
                    distributors.DistributorName = dataRow["DistributorName"].ToString();
                    distributors.Status = Convert.ToBoolean(dataRow["Status"]);
                    distributors.Logo = dataRow["Logo"].ToString();
                    distributors.Address = dataRow["Address"].ToString();
                    distributors.Address = dataRow["Latitude"].ToString();
                    distributors.Address = dataRow["Longtitude"].ToString();
                    distributors.Address = dataRow["Division"].ToString();
                    distributors.Address = dataRow["ParentType"].ToString();
                    distributors.Address = dataRow["ContractStartDate"].ToString();
                    distributors.Address = dataRow["ContractEndDate"].ToString();
                    distributors.Address = dataRow["RegistrationDate"].ToString();
                    distributors.Address = dataRow["SapCode"].ToString();
                    distributors.Address = dataRow["Location"].ToString();

                    distributors.ContactPerson = dataRow["ContactPerson"].ToString();
                    distributors.FatherName = dataRow["FatherName"].ToString();
                    distributors.CNIC = dataRow["CNIC"].ToString();
                    distributors.PhoneNumber = dataRow["PhoneNumber"].ToString();
                    distributors.CellPhone = dataRow["CellPHone"].ToString();
                    distributors.NTN = dataRow["NTN"].ToString();
                    distributors.Email = dataRow["Email"].ToString();
                    distributors.Fax = dataRow["Fax"].ToString();
                    distributors.Url = dataRow["Url"].ToString();
                    distributors.ManageInventory = dataRow["ManageInventory"].ToString();
                    distributors.ContactPersonAddress = dataRow["ContactPersonAddress"].ToString();
                    distributors.RegionId = Convert.ToInt32(dataRow["RegionId"]);
                    distributors.AreaId = Convert.ToInt32(dataRow["AreaId"]);
                    distributors.ZoneId = Convert.ToInt32(dataRow["ZoneId"]);
                    distributors.Town = dataRow["Town"].ToString();

                    distributorslist.Add(distributors);
                }
                return distributorslist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(DistributorId),0) + 1 tbl_Distributors";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}