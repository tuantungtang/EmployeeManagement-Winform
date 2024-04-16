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
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
        }

        public void Data_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'employeeDataSet.PersonalInformation' table. You can move, or remove it, as needed.
            this.personalInformationTableAdapter.Fill(this.employeeDataSet.PersonalInformation);
            
        }
        DatabaseInteract di = new DatabaseInteract();

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int result = di.add(txt_Id.Text, txt_Name.Text, txt_Username.Text);
            if (result == 1)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Something wrong");
            }
            dataGridView1.Update();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int result = di.delete(txt_Id.Text);
            if (result == 1)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            int result = di.update(txt_Id.Text,txt_Name.Text,txt_Username.Text);
            if (result == 1)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
