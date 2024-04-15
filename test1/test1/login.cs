using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace test1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        DatabaseInteract di = new DatabaseInteract();
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string database_link = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\ForInterview\App\test1\test1\employee.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection(database_link);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoginAuthentification";
            cmd.Parameters.AddWithValue("@Username",txt_Username.Text);
            cmd.Parameters.AddWithValue("@Password",txt_Password.Text);
            cmd.Connection = conn;
            conn.Open();
            object kq=cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            if(code == 1)
            {
                Form data = new Data();
                data.MdiParent = null;
                data.Show();
            }
            else
            {
                MessageBox.Show("wrong username/password");
            }
            conn.Close();
        }

        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            Form signin = new SignIn();
            signin.MdiParent = null;
            signin.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {

        }
    }
}
