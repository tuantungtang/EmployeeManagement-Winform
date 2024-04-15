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
