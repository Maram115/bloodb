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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();

           



        }

        private void login1_Click(object sender, EventArgs e)
        {
            if(APassTb.Text=="")
            {
                MessageBox.Show("Enter Admin Password");



            }
            else if(APassTb.Text=="1234")
            {
                Employee emp = new Employee();
                emp.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Wrong Password");
                APassTb.Text = "";

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
