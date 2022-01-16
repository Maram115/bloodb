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
    public partial class viewdonor : Form
    {
        public viewdonor()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\bloodbankdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string Query = "select * from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDgv.DataSource = ds.Tables[0];
            con.Close();
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void DonorDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewdonor_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            donor Donor = new donor();
            Donor.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

            donate Don = new donate();
            Don.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            viewdonor vDonor = new viewdonor();
            vDonor.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            patient Patient = new patient();
            Patient.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            viewpatient vPatient = new viewpatient();
            vPatient.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            bloodstock bs = new bloodstock();
            bs.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            main mn = new main();
            mn.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PNameTb_TextChanged(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            DNameTb.Text = "";
            DAgeTb.Text = "";
            DPhoneTb.Text = "";
            DAddressTb.Text = "";
            DGenCb.SelectedIndex = -1;
            DBGroupCb.SelectedIndex = -1;

        }
        int key=0;
        private void DonorDgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DNameTb.Text = DonorDgv.SelectedRows[0].Cells[1].Value.ToString();
            DAgeTb.Text = DonorDgv.SelectedRows[0].Cells[2].Value.ToString();
            DPhoneTb.Text = DonorDgv.SelectedRows[0].Cells[3].Value.ToString();
            DAddressTb.Text = DonorDgv.SelectedRows[0].Cells[4].Value.ToString();
            DGenCb.SelectedItem = DonorDgv.SelectedRows[0].Cells[5].Value.ToString();
            DBGroupCb.SelectedItem = DonorDgv.SelectedRows[0].Cells[6].Value.ToString();

            if (DNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DonorDgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void login1_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || DPhoneTb.Text == "" || DAgeTb.Text == "" || DGenCb.SelectedIndex == -1 || DBGroupCb.SelectedIndex == -1 || DAddressTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string query = "update DonorTbl set DName='" + DNameTb.Text + "', DAge=" + DAgeTb.Text + ",DPhone='" + DPhoneTb.Text + "',DGender='" + DGenCb.SelectedItem.ToString() + "',DBGroup='" + DBGroupCb.SelectedItem.ToString() + "',DAddress='" + DAddressTb.Text + "'where DNum=" + key + ";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Edited");
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("Select the Donor to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from DonorTbl where DNum=" + key + ";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Deleted");
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
