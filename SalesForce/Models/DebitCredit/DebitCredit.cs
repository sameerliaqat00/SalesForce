using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.DebitCredit
{
    public class DebitCredit
    {
        public int DebitCreditId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public string Reason { get; set; }
        public string ClaimReference { get; set; }
        public string SCN { get; set; }
        public string ManualReference { get; set; }
        public string InvoiceRemarks { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Van { get; set; }
        public string SalesMan { get; set; }
        public string SupplyMan { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Doc { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
    }
    public class DebitCreditHandler
    {
        private string query = "";
        public int Insert(DebitCredit DebitCredit)
        {
            query = "insert into tbl_DebitCredit(DebitCreditId,Date,Type,Amount,reason,Claimreference,SCN,ManualReference,InvoiceRemarks,Customercode,CustomerName,Van,SalesMan,SupplyMan,Company,Branch,Doc,LoginId,UserName)Values('";
            query = query + DebitCredit.DebitCreditId + "','";
            query = query + DebitCredit.Date + "','";
            query = query + DebitCredit.Type + "','";
            query = query + DebitCredit.Amount + "','";
            query = query + DebitCredit.Reason + "','";
            query = query + DebitCredit.ClaimReference + "','";
            query = query + DebitCredit.SCN + "','";
            query = query + DebitCredit.ManualReference + "','";
            query = query + DebitCredit.InvoiceRemarks + "','";
            query = query + DebitCredit.CustomerCode + "','";
            query = query + DebitCredit.CustomerName + "','";
            query = query + DebitCredit.Van + "','";
            query = query + DebitCredit.SalesMan + "','";
            query = query + DebitCredit.SupplyMan + "','";
            query = query + DebitCredit.Company + "','";
            query = query + DebitCredit.Branch + "','";
            query = query + DebitCredit.Doc + "','";
            query = query + DebitCredit.LoginId + "','";
            query = query + DebitCredit.UserName + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(DebitCredit DebitCredit)
        {
            query = "update tbl_DebitCredit set";
            query = query + " Date = '" + DebitCredit.Date + "',";
            query = query + " Type = '" + DebitCredit.Type + "',";
            query = query + " Amount = '" + DebitCredit.Amount + "',";
            query = query + " Reason = '" + DebitCredit.Reason + "',";
            query = query + " ClaimReference = '" + DebitCredit.ClaimReference + "',";
            query = query + " SCN = '" + DebitCredit.SCN + "',";
            query = query + " ManualReference = '" + DebitCredit.ManualReference + "',";
            query = query + " InvoiceRemarks = '" + DebitCredit.InvoiceRemarks + "',";
            query = query + " CustomerCode = '" + DebitCredit.CustomerCode + "',";
            query = query + " CustomerName = '" + DebitCredit.CustomerName + "',";
            query = query + " Van = '" + DebitCredit.Van + "',";
            query = query + " SalesMan = '" + DebitCredit.SalesMan + "',";
            query = query + " SupplyMan = '" + DebitCredit.SupplyMan + "',";
            query = query + " Company = '" + DebitCredit.Company + "',";
            query = query + " Branch = '" + DebitCredit.Branch + "',";
            query = query + " Doc = '" + DebitCredit.Doc + "',";
            query = query + " LoginId = '" + DebitCredit.LoginId + "',";
            query = query + " UserName = '" + DebitCredit.UserName + "'";
            query = query + " Where DebitCreditId = '" + DebitCredit.DebitCreditId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }
        public int Delete(int id)
        {
            query = "delete from tbl_DebitCredit where DebitCreditId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }
        public DebitCredit GetById(int id)
        {
            query = "select * from tbl_DebitCredit Where DebitCreditId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var DebitCredit = new DebitCredit();
                foreach (DataRow dataRow in Data.Rows)
                {
                    DebitCredit.DebitCreditId = Convert.ToInt32(dataRow["DebitCreditId"]);
                    DebitCredit.Date = Convert.ToDateTime(dataRow["Date"]);
                    DebitCredit.Type = dataRow["Type"].ToString();
                    DebitCredit.Amount = Convert.ToInt32(dataRow["Amount"]);
                    DebitCredit.Reason = dataRow["Reason"].ToString();
                    DebitCredit.ClaimReference = dataRow["ClaimReference"].ToString();
                    DebitCredit.SCN = dataRow["SCN"].ToString();
                    DebitCredit.ManualReference = dataRow["ManualReference"].ToString();
                    DebitCredit.InvoiceRemarks = dataRow["InvoiceRemarks"].ToString();
                    DebitCredit.CustomerCode = dataRow["CustomerCode"].ToString();
                    DebitCredit.CustomerName = dataRow["CustomerName"].ToString();
                    DebitCredit.Van = dataRow["Van"].ToString();
                    DebitCredit.SalesMan = dataRow["SalesMan"].ToString();
                    DebitCredit.SupplyMan = dataRow["SupplyMan"].ToString();
                    DebitCredit.Company = dataRow["Company"].ToString();
                    DebitCredit.Branch = dataRow["Branch"].ToString();
                    DebitCredit.Doc = dataRow["Doc"].ToString();
                    DebitCredit.LoginId = dataRow["LoginId"].ToString();
                    DebitCredit.UserName = dataRow["UserName"].ToString();
                }

                return DebitCredit;
            }

            return null;
        }
        public List<DebitCredit> AllList()
        {
            query = "select * from tbl_DebitCredit";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var DebitCredit = new DebitCredit();
                var DebitCreditlist = new List<DebitCredit>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    DebitCredit.DebitCreditId = Convert.ToInt32(dataRow["DebitCreditId"]);
                    DebitCredit.Date = Convert.ToDateTime(dataRow["Date"]);
                    DebitCredit.Type = dataRow["Type"].ToString();
                    DebitCredit.Amount = Convert.ToInt32(dataRow["Amount"]);
                    DebitCredit.Reason = dataRow["Reason"].ToString();
                    DebitCredit.ClaimReference = dataRow["ClaimReference"].ToString();
                    DebitCredit.SCN = dataRow["SCN"].ToString();
                    DebitCredit.ManualReference = dataRow["ManualReference"].ToString();
                    DebitCredit.InvoiceRemarks = dataRow["InvoiceRemarks"].ToString();
                    DebitCredit.CustomerCode = dataRow["CustomerCode"].ToString();
                    DebitCredit.CustomerName = dataRow["CustomerName"].ToString();
                    DebitCredit.Van = dataRow["Van"].ToString();
                    DebitCredit.SalesMan = dataRow["SalesMan"].ToString();
                    DebitCredit.SupplyMan = dataRow["SupplyMan"].ToString();
                    DebitCredit.Company = dataRow["Company"].ToString();
                    DebitCredit.Branch = dataRow["Branch"].ToString();
                    DebitCredit.Doc = dataRow["Doc"].ToString();
                    DebitCredit.LoginId = dataRow["LoginId"].ToString();
                    DebitCredit.UserName = dataRow["UserName"].ToString();
                    DebitCreditlist.Add(DebitCredit);
                }

                return DebitCreditlist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select isnull(max(DebitCreditid),0) + 1 tbl_DebitCredit";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }

}