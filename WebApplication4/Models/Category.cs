using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class CreateCategory : Category
    {

    }

    public class ReadCategory : Category
    {
        public ReadCategory(DataRow row)
        {
            CategoryId = Convert.ToInt32(row["CategoryId"]);
            CategoryName = row["CategoryName"].ToString();
        }

        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
    }
}
