using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Outlet
{
    public class OutletRequestForm
    {
        public int OutletId { get; set; }
        public string OutletName { get; set; }
        public string OutletClassification { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public int Latitude { get; set; }
        public int Longtitude { get; set; }
        public string Location { get; set; }
        public string ChannelType { get; set; }
        public string SubChannel { get; set; }
        public string RegisteredOutlet { get; set; }
        public string Tax { get; set; }
        public string Group { get; set; }
        public string MarketType { get; set; }
        public string Locality { get; set; }
        public string SubLocality { get; set; }

        //Owner Details
        public string ContactPerson { get; set; }
        public string FatherName { get; set; }
        public string CNIC { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhone { get; set; }
        public string NTN { get; set; }
        public string ContactPersonAddress { get; set; }

        //Distribution And OutletRequestForm Details
        public string DivisionName { get; set; }
        public string DistributorName { get; set; }
        public string OutletRequestFormName { get; set; }
        public string SectionName { get; set; }
        public string ShopType { get; set; }
        public string SpecialOutlet { get; set; }
        public string journeyPlan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //General Details
        public string LegacyCode { get; set; }
        public string AgreeSale { get; set; }
        public string EstimateSale { get; set; }
        public string CreditAllowed { get; set; }
        public string CheckGeoVerification { get; set; }
        public string GeoRadius { get; set; }

    }

    public class OutletRequestFormHandler
    {
        private string query = "";
        public int Insert(OutletRequestForm OutletRequestForm)
        {
            query = "insert into tbl_OutletRequestForm(OuletId,OutletName,OutletClassification,Status,Address,Latitude,Longtitude,Location,ChannelType,SubCahnnel,RegisteredOutlet,Tax,Group,MarketType,Locality,SubLocality,ContactPerson,FatherName,CNIC,PhoneNumber,CellPhone,NTN,ContactPersonAddress,DivisionName,DistributorName,OutletRequestFormName,SectionName,ShopType,SpecialOutlet,journeyPlan,StartDate,EndDate,LegacyCode,AgreeSale,EstimateSale,CreditAllowed,CheckGeoVerification,GeoRadius)Values('";
            query = query + OutletRequestForm.OutletId + "','";
            query = query + OutletRequestForm.OutletName + "','";
            query = query + OutletRequestForm.OutletClassification + "','";
            query = query + OutletRequestForm.Status + "','";
            query = query + OutletRequestForm.Address + "','";
            query = query + OutletRequestForm.Latitude + "','";
            query = query + OutletRequestForm.Longtitude + "','";
            query = query + OutletRequestForm.Location + "','";
            query = query + OutletRequestForm.ChannelType + "','";
            query = query + OutletRequestForm.SubChannel + "','";
            query = query + OutletRequestForm.RegisteredOutlet + "','";
            query = query + OutletRequestForm.Tax + "','";
            query = query + OutletRequestForm.Group + "','";
            query = query + OutletRequestForm.MarketType + "','";
            query = query + OutletRequestForm.Locality + "','";
            query = query + OutletRequestForm.SubLocality + "','";
            query = query + OutletRequestForm.ContactPerson + "','";
            query = query + OutletRequestForm.FatherName + "','";
            query = query + OutletRequestForm.CNIC + "','";
            query = query + OutletRequestForm.PhoneNumber + "','";
            query = query + OutletRequestForm.CellPhone + "','";
            query = query + OutletRequestForm.NTN + "','";
            query = query + OutletRequestForm.ContactPersonAddress + "','";
            query = query + OutletRequestForm.DivisionName + "','";
            query = query + OutletRequestForm.DistributorName + "','";
            query = query + OutletRequestForm.OutletRequestFormName + "','";
            query = query + OutletRequestForm.SectionName + "','";
            query = query + OutletRequestForm.ShopType + "','";
            query = query + OutletRequestForm.SpecialOutlet + "','";
            query = query + OutletRequestForm.journeyPlan + "','";
            query = query + OutletRequestForm.StartDate + "','";
            query = query + OutletRequestForm.EndDate + "','";
            query = query + OutletRequestForm.LegacyCode + "','";
            query = query + OutletRequestForm.AgreeSale + "','";
            query = query + OutletRequestForm.EstimateSale + "','";
            query = query + OutletRequestForm.CreditAllowed + "','";
            query = query + OutletRequestForm.CheckGeoVerification + "','";
            query = query + OutletRequestForm.GeoRadius + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
            
        }

        public int Update(OutletRequestForm OutletRequestForm)
        {
          
            query = "update tbl_OutletRequestForm set";
            query = query + " OutletName = '" + OutletRequestForm.OutletName + "',";
            query = query + " OutletClassification = '" + OutletRequestForm.OutletClassification + "',";
            query = query + " Status = '" + OutletRequestForm.Status + "',";
            query = query + " Address = '" + OutletRequestForm.Address + "',";
            query = query + " Latitude = '" + OutletRequestForm.Latitude + "',";
            query = query + " Longtitude = '" + OutletRequestForm.Longtitude + "',";
            query = query + " Location = '" + OutletRequestForm.Location + "',";
            query = query + " ChannelType = '" + OutletRequestForm.ChannelType + "',";
            query = query + " SubChannel = '" + OutletRequestForm.SubChannel + "',";
            query = query + " RegisteredOutlet = '" + OutletRequestForm.RegisteredOutlet + "',";
            query = query + " Tax = '" + OutletRequestForm.Tax + "',";
            query = query + " Group = '" + OutletRequestForm.Group + "',";
            query = query + " MarketType = '" + OutletRequestForm.MarketType + "',";
            query = query + " Locality = '" + OutletRequestForm.Locality + "',";
            query = query + " SubLocality = '" + OutletRequestForm.SubLocality + "',";
            query = query + " ContactPerson = '" + OutletRequestForm.ContactPerson + "',";
            query = query + " FatherName = '" + OutletRequestForm.FatherName + "',";
            query = query + " CNIC = '" + OutletRequestForm.CNIC + "',";
            query = query + " PhoneNumber = '" + OutletRequestForm.PhoneNumber + "',";
            query = query + " CellPhone = '" + OutletRequestForm.CellPhone + "',";
            query = query + " NTN = '" + OutletRequestForm.NTN + "',";
            query = query + " ContactPersonAddress = '" + OutletRequestForm.ContactPersonAddress + "',";
            query = query + " DivisionName = '" + OutletRequestForm.DivisionName + "',";
            query = query + " DistributorName = '" + OutletRequestForm.DistributorName + "',";
            query = query + " OutletRequestFormName = '" + OutletRequestForm.OutletRequestFormName + "',";
            query = query + " SectionName = '" + OutletRequestForm.SectionName + "',";
            query = query + " ShopType = '" + OutletRequestForm.ShopType + "',";
            query = query + " SpecialOutlet = '" + OutletRequestForm.SpecialOutlet + "',";
            query = query + " journeyPlan = '" + OutletRequestForm.journeyPlan + "',";
            query = query + " StartDate = '" + OutletRequestForm.StartDate + "',";
            query = query + " EndDate = '" + OutletRequestForm.EndDate + "',";
            query = query + " LegacyCode = '" + OutletRequestForm.LegacyCode + "',";
            query = query + " AgreeSale = '" + OutletRequestForm.AgreeSale + "',";
            query = query + " EstimateSale = '" + OutletRequestForm.EstimateSale + "',";
            query = query + " CreditAllowed = '" + OutletRequestForm.CreditAllowed + "',";
            query = query + " CheckGeoVerification = '" + OutletRequestForm.CheckGeoVerification + "',";
            query = query + " GeoRadius = '" + OutletRequestForm.GeoRadius + "'";
            query = query + " Where OutletId = '" + OutletRequestForm.OutletId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_OutletRequestForm where OutletId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public OutletRequestForm GetById(int id)
        {
            query = "select * from tbl_OutletRequestForm Where OutletId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var OutletRequestForm = new OutletRequestForm();
                foreach (DataRow dataRow in Data.Rows)
                {
                    OutletRequestForm.OutletId = Convert.ToInt32(dataRow["OutletId"]);
                    OutletRequestForm.OutletClassification = dataRow["OutletClassification"].ToString();
                    OutletRequestForm.Status = Convert.ToBoolean(dataRow["Status"]);
                    OutletRequestForm.Address = dataRow["Address"].ToString();
                    OutletRequestForm.Latitude = Convert.ToInt32(dataRow["Latitude"]);
                    OutletRequestForm.Longtitude = Convert.ToInt32(dataRow["Longtitude"]);
                    OutletRequestForm.Location = dataRow["Location"].ToString();
                    OutletRequestForm.ChannelType = dataRow["ChannelType"].ToString();
                    OutletRequestForm.SubChannel = dataRow["SubChannel"].ToString();
                    OutletRequestForm.RegisteredOutlet = dataRow["RegisteredOutlet"].ToString();
                    OutletRequestForm.Tax = dataRow["Tax"].ToString();
                    OutletRequestForm.Group = dataRow["Group"].ToString();
                    OutletRequestForm.MarketType = dataRow["MarketType"].ToString();
                    OutletRequestForm.Locality = dataRow["Locality"].ToString();
                    OutletRequestForm.SubLocality = dataRow["SubLocality"].ToString();
                    OutletRequestForm.ContactPerson = dataRow["ContactPerson"].ToString();
                    OutletRequestForm.FatherName = dataRow["FatherName"].ToString();
                    OutletRequestForm.CNIC = dataRow["CNIC"].ToString();
                    OutletRequestForm.PhoneNumber = dataRow["PhoneNumber"].ToString();
                    OutletRequestForm.CellPhone = dataRow["CellPhone"].ToString();
                    OutletRequestForm.NTN = dataRow["NTN"].ToString();
                    OutletRequestForm.ContactPersonAddress = dataRow["ContactPersonAddress"].ToString();
                    OutletRequestForm.DivisionName = dataRow["DivisionName"].ToString();
                    OutletRequestForm.DistributorName = dataRow["DistributorName"].ToString();
                    OutletRequestForm.OutletRequestFormName = dataRow["OutletRequestFormName"].ToString();
                    OutletRequestForm.SectionName = dataRow["SectionName"].ToString();
                    OutletRequestForm.ShopType = dataRow["ShopType"].ToString();
                    OutletRequestForm.SpecialOutlet = dataRow["SpecialOutlet"].ToString();
                    OutletRequestForm.journeyPlan = dataRow["journeyPlan"].ToString();
                    OutletRequestForm.StartDate =Convert.ToDateTime(dataRow["StartDate"]);
                    OutletRequestForm.EndDate = Convert.ToDateTime(dataRow["EndDate"]);
                    OutletRequestForm.LegacyCode = dataRow["LegacyCode"].ToString();
                    OutletRequestForm.AgreeSale = dataRow["AgreeSale"].ToString();
                    OutletRequestForm.EstimateSale = dataRow["EstimateSale"].ToString();
                    OutletRequestForm.CreditAllowed = dataRow["CreditAllowed"].ToString();
                    OutletRequestForm.CheckGeoVerification = dataRow["CheckGeoVerification"].ToString();
                    OutletRequestForm.GeoRadius = dataRow["GeoRadius"].ToString();

                }

                return OutletRequestForm;
            }

            return null;
        }
        public List<OutletRequestForm> AllList()
        {
            query = "select * from tbl_OutletRequestForm";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var OutletRequestForm = new OutletRequestForm();
                var OutletRequestFormlist = new List<OutletRequestForm>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    OutletRequestForm.OutletId = Convert.ToInt32(dataRow["OutletId"]);
                    OutletRequestForm.OutletClassification = dataRow["OutletClassification"].ToString();
                    OutletRequestForm.Status = Convert.ToBoolean(dataRow["Status"]);
                    OutletRequestForm.Address = dataRow["Address"].ToString();
                    OutletRequestForm.Latitude = Convert.ToInt32(dataRow["Latitude"]);
                    OutletRequestForm.Longtitude = Convert.ToInt32(dataRow["Longtitude"]);
                    OutletRequestForm.Location = dataRow["Location"].ToString();
                    OutletRequestForm.ChannelType = dataRow["ChannelType"].ToString();
                    OutletRequestForm.SubChannel = dataRow["SubChannel"].ToString();
                    OutletRequestForm.RegisteredOutlet = dataRow["RegisteredOutlet"].ToString();
                    OutletRequestForm.Tax = dataRow["Tax"].ToString();
                    OutletRequestForm.Group = dataRow["Group"].ToString();
                    OutletRequestForm.MarketType = dataRow["MarketType"].ToString();
                    OutletRequestForm.Locality = dataRow["Locality"].ToString();
                    OutletRequestForm.SubLocality = dataRow["SubLocality"].ToString();
                    OutletRequestForm.ContactPerson = dataRow["ContactPerson"].ToString();
                    OutletRequestForm.FatherName = dataRow["FatherName"].ToString();
                    OutletRequestForm.CNIC = dataRow["CNIC"].ToString();
                    OutletRequestForm.PhoneNumber = dataRow["PhoneNumber"].ToString();
                    OutletRequestForm.CellPhone = dataRow["CellPhone"].ToString();
                    OutletRequestForm.NTN = dataRow["NTN"].ToString();
                    OutletRequestForm.ContactPersonAddress = dataRow["ContactPersonAddress"].ToString();
                    OutletRequestForm.DivisionName = dataRow["DivisionName"].ToString();
                    OutletRequestForm.DistributorName = dataRow["DistributorName"].ToString();
                    OutletRequestForm.OutletRequestFormName = dataRow["OutletRequestFormName"].ToString();
                    OutletRequestForm.SectionName = dataRow["SectionName"].ToString();
                    OutletRequestForm.ShopType = dataRow["ShopType"].ToString();
                    OutletRequestForm.SpecialOutlet = dataRow["SpecialOutlet"].ToString();
                    OutletRequestForm.journeyPlan = dataRow["journeyPlan"].ToString();
                    OutletRequestForm.StartDate = Convert.ToDateTime(dataRow["StartDate"]);
                    OutletRequestForm.EndDate = Convert.ToDateTime(dataRow["EndDate"]);
                    OutletRequestForm.LegacyCode = dataRow["LegacyCode"].ToString();
                    OutletRequestForm.AgreeSale = dataRow["AgreeSale"].ToString();
                    OutletRequestForm.EstimateSale = dataRow["EstimateSale"].ToString();
                    OutletRequestForm.CreditAllowed = dataRow["CreditAllowed"].ToString();
                    OutletRequestForm.CheckGeoVerification = dataRow["CheckGeoVerification"].ToString();
                    OutletRequestForm.GeoRadius = dataRow["GeoRadius"].ToString();
                    OutletRequestFormlist.Add(OutletRequestForm);
                }

                return OutletRequestFormlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(OutletId),0) + 1 tbl_OutletRequestForm";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}