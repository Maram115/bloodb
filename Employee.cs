using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bloodb
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\bloodbankdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string Query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDgv.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();


        }
        private void Reset()
        {
            ENameTb.Text = "";
            EPassTb.Text = "";
            key = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ENameTb.Text == "" || EPassTb.Text == "" )
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string query = "insert into EmployeeTbl values('" + ENameTb.Text + "','" + EPassTb.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Saved");
                    con.Close();
                    Reset();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }

        }
        int key = 0;
        private void EmployeeDgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ENameTb.Text = EmployeeDgv.SelectedRows[0].Cells[1].Value.ToString();
            EPassTb.Text = EmployeeDgv.SelectedRows[0].Cells[2].Value.ToString();
            

            if (ENameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmployeeDgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("Select Employee to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from EmployeeTbl where EmpNum=" + key + ";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Deleted");
                    con.Close();
                    Reset();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void EditEmp_Click(object sender, EventArgs e)
        {
            if (ENameTb.Text == "" || EPassTb.Text == "" )
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string query = "update EmployeeTbl set EmpId='" + ENameTb.Text + "', EmpPass='" + EPassTb.Text + "'where EmpNum=" + key + ";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Edited");
                    con.Close();
                    Reset();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }
    }
}
