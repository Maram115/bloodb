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
    public partial class bloodstock : Form
    {
        public bloodstock()
        {
            InitializeComponent();
            GetData();
        }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\bloodbankdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetData()
        {
            con.Open();
            //total num of bloodstock
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from BloodTbl",con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            int Bstock = Convert.ToInt32(dt1.Rows[0][0].ToString());
            Totalbl.Text = "" + Bstock;
            //total num of A+ 
            SqlDataAdapter sda2 = new SqlDataAdapter("select BStock from BloodTbl where BGroup = '"+"A+"+"' ", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            
            aplus.Text = dt2.Rows[0][0].ToString();

            //total num of A-
            SqlDataAdapter sda3 = new SqlDataAdapter("select BStock from BloodTbl where BGroup = '" + "A-" + "' ", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);

            aminus.Text = dt3.Rows[0][0].ToString();

            //total num of B+
            SqlDataAdapter sda4 = new SqlDataAdapter("select BStock from BloodTbl where BGroup = '" + "B+" + "' ", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);

            bplus.Text = dt4.Rows[0][0].ToString();

            //total num of B-
            SqlDataAdapter sda5 = new SqlDataAdapter("select BStock from BloodTbl where BGroup = '" + "B-" + "' ", con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);

            bminus.Text = dt5.Rows[0][0].ToString();

            //total num of AB+
            SqlDataAdapter sda6 = new SqlDataAdapter("select BStock from BloodTbl where BGroup = '" + "AB+" + "' ", con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);

            abplus.Text = dt6.Rows[0][0].ToString();

            //total num of AB-
            SqlDataAdapter sda7 = new SqlDataAdapter("select BStock from BloodTbl where BGroup = '" + "AB-" + "' ", con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);

            abminus.Text = dt7.Rows[0][0].ToString();

            //total num of O+
            SqlDataAdapter sda8 = new SqlDataAdapter("select BStock from BloodTbl where BGroup = '" + "O+" + "' ", con);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);

            oplus.Text = dt8.Rows[0][0].ToString();

            //total num of O-
            SqlDataAdapter sda9 = new SqlDataAdapter("select BStock from BloodTbl where BGroup = '" + "O-" + "' ", con);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);

            ominus.Text = dt9.Rows[0][0].ToString();



            con.Close();
        }


        private void bloodstock_Load(object sender, EventArgs e)
        {

        }
        public void allDonorCount()
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            donor Donor = new donor();
            Donor.Show();
            this.Hide();
        }

        private void label33_Click(object sender, EventArgs e)
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
    }
}
