using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using SalesForce.Classes;
using IDataAdapter = System.Data.IDataAdapter;

namespace SalesForce.Models.Item_Catalog
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
       
    }

    public class ItemCategoryHandler
    {
        private string query = "";
        public int Insert(ItemCategory itemctCategory)
        {
            query = "insert into tbl_ItemCategory(ItemCategoryId,ItemCategoryName)Values('";
            query = query + itemctCategory.ItemCategoryId + "','";
            query = query + itemctCategory.ItemCategoryName + "')";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Update(ItemCategory itemCategory)
        {
            query = "update tbl_ItemCategory set";
            query = query + " ItemCategoryName = '" + itemCategory.ItemCategoryName + "'";
            query = query + " Where ItemCategoryId = '" + itemCategory.ItemCategoryId + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public int Delete(int id)
        {
            query = "delete from tbl_ItemCategory where ItemCategoryId = '" + id + "'";
            return SqlHelper.ExecuteNonQuery(HrGlobal.DbCon, CommandType.Text, query);
        }

        public ItemCategory GetById(int id)
        {
            query = "select * from tbl_ItemCategory Where ItemCategoryId = '" + id + "'";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var itemcategory = new ItemCategory();
                foreach (DataRow dataRow in Data.Rows)
                {
                    itemcategory.ItemCategoryId = Convert.ToInt32(dataRow["ItemCategoryId"]);
                    itemcategory.ItemCategoryName = dataRow["ItemCategoryName"].ToString();
                }

                return itemcategory;
            }

            return null;
        }
        public List<ItemCategory> AllList()
        {
            query = "select * from tbl_ItemCategory";
            var Data = SqlHelper.ExecuteDataset(HrGlobal.DbCon, CommandType.Text, query).Tables[0];
            if (Data.Rows.Count > 0)
            {
                var itemcategory = new ItemCategory();
                var itemcategorylist = new List<ItemCategory>();
                foreach (DataRow dataRow in Data.Rows)
                {
                    itemcategory.ItemCategoryId = Convert.ToInt32(dataRow["ItemCategoryId"]);
                    itemcategory.ItemCategoryName = dataRow["ItemCategoryName"].ToString();

                    itemcategorylist.Add(itemcategory);
                }

                return itemcategorylist;
            }

            return null;
        }

        public int GetMaxId()
        {
            query = "select max(isnull(itemcategoryid),0) + 1 tbl_ItemCategory";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(HrGlobal.DbCon, CommandType.Text, query));
        }
    }
}