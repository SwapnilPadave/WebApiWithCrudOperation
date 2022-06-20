using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        public IEnumerable<Product> Get()
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            DataTable _dt = new DataTable();
            var query = "Select * from Products";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Product> Products = new List<Models.Product>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow ProductRecords in _dt.Rows)
                {
                    Products.Add(new ReadProduct(ProductRecords));
                }
            }
            return Products;
        }

        // GET api/<controller>/5
        public IEnumerable<Product> Get(int id)
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            DataTable _dt = new DataTable();
            var query = "Select * from Products where ProductId=" + id;
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Product> Products = new List<Models.Product>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow ProductRecords in _dt.Rows)
                {
                    Products.Add(new ReadProduct(ProductRecords));
                }
            }
            return Products;
        }

        // POST api/<controller>
        public string Post([FromBody] CreateProduct value)
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            var query = "insert into Products (ProductName) values(@ProductName)";
            SqlCommand InsertCommand = new SqlCommand(query, _conn);
            InsertCommand.Parameters.AddWithValue("@ProductName", value.ProductName);
            
            _conn.Open();
            int result = InsertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Product Created Successfully..";
            }
            else
            {
                return "Product Created Failure..";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] CreateProduct value)
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            var query = "update Products set ProductName=@ProductName where ProductID=" + id;
            SqlCommand InsertCommand = new SqlCommand(query, _conn);
            InsertCommand.Parameters.AddWithValue("@ProductName", value.ProductName);
            _conn.Open();
            int result = InsertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Product Updated Successfully..";
            }
            else
            {
                return "Product Updated Failure..";
            }
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            var query = "Delete From Products where ProductId=" + id;
            SqlCommand InsertCommand = new SqlCommand(query, _conn);

            _conn.Open();
            int result = InsertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Product Deleted Successfully..";
            }
            else
            {
                return "Product Deleted Failure..";
            }
        }
    }
}