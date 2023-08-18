using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interface_code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            telemetry form = new telemetry();
            form.Show();
            this.Hide();
            /*

            if (textBox1.Text=="tubitakuzay" && textBox2.Text=="123")
            {
                telemetry form = new telemetry();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error","Error");
                textBox1.Clear();
                textBox2.Clear();
            }        */
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Text = "";
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
