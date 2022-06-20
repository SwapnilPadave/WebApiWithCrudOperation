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
    public class CategoryController : ApiController
    {
        // GET api/<controller>
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        public IEnumerable<Category> Get()
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            DataTable _dt = new DataTable();
            var query = "Select * from Categories";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Category> Categories = new List<Models.Category>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach(DataRow CategoryRecord in _dt.Rows)
                {
                    Categories.Add(new ReadCategory(CategoryRecord));
                }
            }
            return Categories;
        }

        // GET api/<controller>/5
        public IEnumerable<Category> Get(int id)
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            DataTable _dt = new DataTable();
            var query = "Select * from Categories where CategoryId="+id;
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Category> Categories = new List<Models.Category>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow CategoryRecord in _dt.Rows)
                {
                    Categories.Add(new ReadCategory(CategoryRecord));
                }
            }
            return Categories;
        }

        // POST api/<controller>
        public string Post([FromBody] CreateCategory value)
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            var query = "insert into Categories (CategoryName) values(@CategoryName)";
            SqlCommand InsertCommand = new SqlCommand(query,_conn);
            InsertCommand.Parameters.AddWithValue("@CategoryName", value.CategoryName);
            _conn.Open();
            int result = InsertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Category Created Successfully..";
            }
            else
            {
                return "Category Created Failure..";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] CreateCategory value)
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            var query = "update Categories set CategoryName=@CategoryName where CategoryId="+id;
            SqlCommand InsertCommand = new SqlCommand(query, _conn);
            InsertCommand.Parameters.AddWithValue("@CategoryName", value.CategoryName);
            _conn.Open();
            int result = InsertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Category Updated Successfully..";
            }
            else
            {
                return "Category Updated Failure..";
            }
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            _conn = new SqlConnection("Data Source=DESKTOP-PGMBMI6\\MSSQLSERVER2019;Initial Catalog=Swapnil;Integrated Security=True");
            var query = "Delete From Categories where CategoryId=" + id;
            SqlCommand InsertCommand = new SqlCommand(query, _conn);
            
            _conn.Open();
            int result = InsertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Category Deleted Successfully..";
            }
            else
            {
                return "Category Deleted Failure..";
            }
        }
    }
}