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
    public partial class viewpatient : Form
    {
        public viewpatient()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\bloodbankdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string Query = "select * from PatientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientDgv.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Reset()
        {
            PNameTb.Text = "";
            PAgeTb.Text = "";
            PPhoneTb.Text = "";
            PAddressTb.Text = "";
            PGenCb.SelectedIndex = -1;
            PBGroupCb.SelectedIndex = -1;

        }

        int key = 0;
        //private void PatientDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    PNameTb.Text = PatientDgv.SelectedRows[0].Cells[1].Value.ToString();
        //    PAgeTb.Text = PatientDgv.SelectedRows[0].Cells[2].Value.ToString();
        //    PPhoneTb.Text = PatientDgv.SelectedRows[0].Cells[3].Value.ToString();
        //    PGenCb.SelectedItem = PatientDgv.SelectedRows[0].Cells[4].Value.ToString();
        //    PBGroupCb.SelectedItem = PatientDgv.SelectedRows[0].Cells[5].Value.ToString();
        //    PAddressTb.Text = PatientDgv.SelectedRows[0].Cells[6].Value.ToString();
        //    if (PNameTb.Text == "")
        //    {
        //        key = 0;
        //    }
        //    else
        //    {
        //        key = Convert.ToInt32(PatientDgv.SelectedRows[0].Cells[0].Value.ToString());
        //    }




        //    if (key == 0)
        //    {
        //        MessageBox.Show("Select the patient to Delete");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            string query = "Delete from PatientTbl where PNum=" + key + ";";
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Patient Successfully Deleted");
        //            con.Close();
        //            Reset();
        //            populate();

        //        }
        //        catch (Exception Ex)
        //        {
        //            MessageBox.Show(Ex.Message);

        //        }
        //    }

        //}

        private void PatientDgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PNameTb.Text = PatientDgv.SelectedRows[0].Cells[1].Value.ToString();
            PAgeTb.Text = PatientDgv.SelectedRows[0].Cells[2].Value.ToString();
            PPhoneTb.Text = PatientDgv.SelectedRows[0].Cells[3].Value.ToString();
            PAddressTb.Text = PatientDgv.SelectedRows[0].Cells[4].Value.ToString();
            PGenCb.SelectedItem = PatientDgv.SelectedRows[0].Cells[5].Value.ToString();
            PBGroupCb.SelectedItem = PatientDgv.SelectedRows[0].Cells[6].Value.ToString();
            
            if (PNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientDgv.SelectedRows[0].Cells[0].Value.ToString());
            }




            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the patient to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from PatientTbl where PNum=" + key + ";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Deleted");
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

        private void label3_Click(object sender, EventArgs e)
        {
            patient pat = new patient();
            pat.Show();
            this.Hide();
        }

        private void login1_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PPhoneTb.Text == "" || PAgeTb.Text == "" || PGenCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 || PAddressTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string query = "update PatientTbl set PName='"+PNameTb.Text+"', PAge="+PAgeTb.Text+ ",PPhone='" + PPhoneTb.Text + "',PGender='" + PGenCb.SelectedItem.ToString() + "',PBGroup='" + PBGroupCb.SelectedItem.ToString() + "',PAddress='" + PAddressTb.Text + "'where PNum="+key+";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Edited");
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

        private void viewpatient_Load(object sender, EventArgs e)
        {

        }

        private void PatientDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    




       

       
        

       
       