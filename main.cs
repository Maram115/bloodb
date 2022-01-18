using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bloodb
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();

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

        private void label16_Click(object sender, EventArgs e)
        {

            donate Don = new donate();
            Don.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
