using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class SignIn : Form
    {
        DatabaseInteract di = new DatabaseInteract();
        public SignIn()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text != txt_Password2.Text)
            {
                MessageBox.Show("Different password");
            }
            else
            {
                string sql = "insert into PersonalInformation (Id, Name, Username) values ('" +txt_Id.Text+"', '"+txt_FullName.Text+"','"+txt_Username.Text+
                    "')";
                string sql2 = "insert into UsernamePassword (Username, Password) values ('" +txt_Username.Text + "','"+txt_Password.Text+
                    "')";
                int kq1 = di.CRUD(sql), kq2 = di.CRUD(sql2);
                if (kq1 * kq2 == 1)
                {
                    MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("fail");
                }
                    
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are u sure ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
