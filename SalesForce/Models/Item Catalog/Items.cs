using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;

namespace SalesForce.Models.Item_Catalog
{
    public class Items
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public int ItemPrice { get; set; }
        public int ItemPacking { get; set; }
        public int ItemSortOrder { get; set; }
        public int ItemCategoryId { get; set; }

    }
    public class ItemsHandler
    {
        private string query = "";
        public int Insert(Items items)
        {
            query = "insert into tbl_Items(ItemId,ItemName,ItemCode,ItemPrice,ItemPacking,ItemSortOrder,ItemCategoryId)Values('";
            query = query + items.ItemCategoryId + "','";
            query = query + items.ItemName + "','";
            query = query + items.ItemCode + "','";
            query = query + items.ItemPrice + "','";
            query = query + items.ItemPacking + "','";
            query = query + items.ItemSortOrder + "','";
            query = query + items.ItemCategoryId + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(Items items)
        {
            query = "update tbl_Items set";
            query = query + " ItemName = '" + items.ItemName + "',";
            query = query + " ItemCode = '" + items.ItemCode + "',";
            query = query + " ItemPrice = '" + items.ItemPrice + "',";
            query = query + " ItemPacking = '" + items.ItemPacking + "',";
            query = query + " ItemSortOrder = '" + items.ItemSortOrder + "',";
            query = query + " ItemCategoryId = '" + items.ItemCategoryId + "'";
            query = query + " Where ItemId = '" + items.ItemId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_Items where ItemId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public Items GetById(int id)
        {
            query = "select * from tbl_Items Where ItemId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var items = new Items();
                foreach (DataRow dataRow in Data.Rows)
                {
                    items.ItemCategoryId = Convert.ToInt32(dataRow["ItemId"]);
                    items.ItemName = dataRow["ItemName"].ToString();
                    items.ItemCode = dataRow["ItemCode"].ToString();
                    items.ItemPrice = Convert.ToInt32(dataRow["ItemPrice"]);
                    items.ItemPacking = Convert.ToInt32(dataRow["ItemPacking"]);
                    items.ItemSortOrder = Convert.ToInt32(dataRow["ItemSortOrder"]);
                    items.ItemCategoryId = Convert.ToInt32(dataRow["ItemCategoryId"]);
                  
                }

                return items;
            }

            return null;
        }
        public List<Items> AllList()
        {
            query = "select * from tbl_Items";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var items = new Items();
                var itemslist = new List<Items>();
               
                foreach (DataRow dataRow in Data.Rows)
                {
                    items.ItemCategoryId = Convert.ToInt32(dataRow["ItemId"]);
                    items.ItemName = dataRow["ItemName"].ToString();
                    items.ItemCode = dataRow["ItemCode"].ToString();
                    items.ItemPrice = Convert.ToInt32(dataRow["ItemPrice"]);
                    items.ItemPacking = Convert.ToInt32(dataRow["ItemPacking"]);
                    items.ItemSortOrder = Convert.ToInt32(dataRow["ItemSortOrder"]);
                    items.ItemCategoryId = Convert.ToInt32(dataRow["ItemCategoryId"]);
                    itemslist.Add(items);
                }
                return itemslist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select max(isnull(itemid),0) + 1 tbl_Items";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}