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
    public partial class donate : Form
    {
        public donate()
        {
            InitializeComponent();
            populate();
            bloodStock();
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



        private void bloodStock()
        {
            con.Open();
            string Query = "select * from BloodTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDgv.DataSource = ds.Tables[0];
            con.Close();
        }


        private void label6_Click(object sender, EventArgs e)
        {

            donate Don = new donate();
            Don.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void donate_Load(object sender, EventArgs e)
        {

        }

        private void DonorDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int oldstock;
        private void GetStock(string Bgroup)
        {
            con.Open();
            string query = "select * from BloodTbl where BGroup = '" + BGroupTb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());

            }

            con.Close();
        }

        private void DonorDgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DNameTb.Text = DonorDgv.SelectedRows[0].Cells[1].Value.ToString();
            BGroupTb.Text= DonorDgv.SelectedRows[0].Cells[6].Value.ToString();
            GetStock(BGroupTb.Text);
        }


        private void reset()
        {
            DNameTb.Text = "";
            BGroupTb.Text = "";
        }

        private void login1_Click(object sender, EventArgs e)
        {
            if(DNameTb.Text =="")
            {
                MessageBox.Show("Select a donor");
            }
            else
            {
                try
                {
                    int stock = oldstock+1;
                    string query = "update BloodTbl set BStock=" + stock + "  where BGroup='" + BGroupTb.Text + "';";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Sucessfull");
                    con.Close();
                    reset();
                    bloodStock();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {
            donor Donor = new donor();
            Donor.Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
