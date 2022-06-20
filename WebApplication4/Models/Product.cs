using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
    }
    public class CreateProduct : Product
    {

    }
    public class ReadProduct : Product
    {
        public ReadProduct(DataRow row)
        {
            ProductId = Convert.ToInt32(row["ProductID"]);
            ProductName = row["ProductName"].ToString();
            
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}