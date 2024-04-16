using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace test1
{
    class DatabaseInteract
    {
        string database_link = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\ForInterview\App\test1\test1\employee.mdf;Integrated Security=True";
        SqlConnection conn;
        public DatabaseInteract()
        {
            conn = new SqlConnection(database_link);
        }
        public int CRUD(string sql) {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            int kq = comm.ExecuteNonQuery();
            conn.Close();
            return kq;
        }
        public int add(string id, string name, string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddIntoPersonalInformation";
            cmd.Parameters.AddWithValue("@Id",id);
            cmd.Parameters.AddWithValue("@Name",name);
            cmd.Parameters.AddWithValue("@Username",username);
            cmd.Connection = conn;
            conn.Open();
            object re=cmd.ExecuteNonQuery();
            int ans = Convert.ToInt32(re);
            conn.Close();
            return ans;
        }
        public int delete(string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Delete";
            cmd.Parameters.AddWithValue("@Id",id);
            cmd.Connection = conn;
            conn.Open();
            object ans = cmd.ExecuteNonQuery();
            int value = Convert.ToInt32(ans);
            conn.Close();
            return value;
        }
        public int update(string id, string name, string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update";
            cmd.Parameters.AddWithValue("@Id",id);
            cmd.Parameters.AddWithValue("@Name",name);
            cmd.Parameters.AddWithValue("@Username",name);
            cmd.Connection = conn;
            conn.Open();
            object ans = cmd.ExecuteNonQuery();
            conn.Close();
            return Convert.ToInt32(ans);
        }
        public DataTable load(string sql)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            adap.Fill(table);
            return table;
        }
        public object getValues(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            object kq = comm.ExecuteScalar();
            conn.Close();
            return kq;
        }
    }
}
