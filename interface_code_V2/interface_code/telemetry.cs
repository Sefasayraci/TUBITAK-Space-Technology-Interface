using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.IO.Ports;
using System.Drawing.Drawing2D;
using System.Runtime.ConstrainedExecution;

//**********************************************************//
//ApplicationDoevent(); Kasma Donma Durumu, https://uzmanim.net/soru/c-ile-yazdigim-uygulama-donuyor-sebebi-ne-olabilir/93332 , https://uzmanim.net/soru/application-doevents-nedir/93365
// Grafik çizdirme de sorun var.
// Pusula Sensörü lehimlenecek.
// GMAP Eklenebilir.
// Excell verş kaydetme sorunu düzelmelidir.
//**********************************************************//

namespace interface_code
{
    public partial class telemetry : Form
    {
        DateTime yeni = DateTime.Now;

        long maximum = 30;
        long minimum = 0;
        
        int zaman = 0;
        int satir = 1;
        int sutun = 1;
        int satirNo = 1;
        int k = 0;

        string[] portlar = SerialPort.GetPortNames();
        public telemetry()
        {
            InitializeComponent();
        }

        private void telemetry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void telemetry_Load(object sender, EventArgs e)
        {
            foreach (string port in portlar) // Veriler string geldi.
            {
                comboBox1.Items.Add(port);
                comboBox1.SelectedIndex = 0;
            }


            comboBox2.Items.Add("2400");
            comboBox2.Items.Add("4800");
            comboBox2.Items.Add("9600");
            comboBox2.Items.Add("14400");
            comboBox2.Items.Add("57600");
            comboBox2.Items.Add("115200");
            comboBox2.SelectedIndex = 1;
            label2.Text = "Disconnect";

        }
        Task ExcellKayit()
        {
            return Task.Run(() =>
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

                excel.Visible = true;

                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);

                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

                int StartCol = 1;

                int StartRow = 1;

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];

                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;

                }

                StartRow++;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {

                        try
                        {

                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];

                            myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;

                        }

                        catch
                        {



                        }


                    }

                }
            });

        }
        private void connect_Click(object sender, EventArgs e)
        {
            connect.Enabled = false;
            disconnect.Enabled = true;
            timer1.Start();
            if (serialPort1.IsOpen == false)
            {
                if (comboBox1.Text == "")
                    return;
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Convert.ToInt16(comboBox2.Text);

                try
                {
                    serialPort1.Open();
                    label2.Text = "Connect";
                }
                catch (Exception syntax)
                {
                    MessageBox.Show("Error:" + syntax.Message);

                }
               // serialPort1.DiscardInBuffer();
            }

            else
            {
                label2.Text = "Connected";
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            groupBox3.ForeColor = Color.White;
            dataGridView1.ForeColor= Color.Black;

            // X ekseni değer etiketlerini görünür yapma
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            // X ekseni değer rengini değiştirme
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White; ////////////////////////////////////////////////////////////////////////////////////Kontrol Edilecek.


            // Y ekseni değer etiketlerini görünür yapma
            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            // Y ekseni değer rengini değiştirme
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;





            // X ekseni değer etiketlerini görünür yapma
            chart2.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            // X ekseni değer rengini değiştirme
            chart2.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White; ////////////////////////////////////////////////////////////////////////////////////Kontrol Edilecek.


            // Y ekseni değer etiketlerini görünür yapma
            chart2.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            // Y ekseni değer rengini değiştirme
            chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;





            // X ekseni değer etiketlerini görünür yapma
            chart3.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            // X ekseni değer rengini değiştirme
            chart3.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White; ////////////////////////////////////////////////////////////////////////////////////Kontrol Edilecek.


            // Y ekseni değer etiketlerini görünür yapma
            chart3.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            // Y ekseni değer rengini değiştirme
            chart3.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;





            // X ekseni değer etiketlerini görünür yapma
            chart4.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            // X ekseni değer rengini değiştirme
            chart4.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White; ////////////////////////////////////////////////////////////////////////////////////Kontrol Edilecek.


            // Y ekseni değer etiketlerini görünür yapma
            chart4.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            // Y ekseni değer rengini değiştirme
            chart4.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;



            //Chart1
            chart1.ChartAreas[0].AxisX.Minimum = minimum;
            chart1.ChartAreas[0].AxisX.Maximum = maximum;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 50;

            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(minimum, maximum);

            //Chart2
            chart2.ChartAreas[0].AxisX.Minimum = minimum;
            chart2.ChartAreas[0].AxisX.Maximum = maximum;

            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 10000;

            chart2.ChartAreas[0].AxisX.ScaleView.Zoom(minimum, maximum);

            //Chart3
            chart3.ChartAreas[0].AxisX.Minimum = minimum;
            chart3.ChartAreas[0].AxisX.Maximum = maximum;

            chart3.ChartAreas[0].AxisY.Minimum = 0;
            chart3.ChartAreas[0].AxisY.Maximum = 100000;

            chart3.ChartAreas[0].AxisX.ScaleView.Zoom(minimum, maximum);

            //Chart4
            chart4.ChartAreas[0].AxisX.Minimum = minimum;
            chart4.ChartAreas[0].AxisX.Maximum = maximum;

            chart4.ChartAreas[0].AxisY.Minimum = 0;
            chart4.ChartAreas[0].AxisY.Maximum = 500;

            chart4.ChartAreas[0].AxisX.ScaleView.Zoom(minimum, maximum);


            //System.Threading.Thread.Sleep(1000);

            try
            {
                string data = serialPort1.ReadLine();
                string[] series = data.Split('/');
                //label1.Text = data + "";

                textBox1.Text = series[0];
                textBox2.Text = series[1];
                textBox3.Text = series[2];
                textBox4.Text = series[3];
                textBox5.Text = series[4];
                textBox6.Text = series[5];
                textBox7.Text = series[6];
                textBox8.Text = series[7];
                textBox9.Text = series[8];
                textBox10.Text = series[9];/*
                textBox11.Text = series[10];
                textBox12.Text = series[11];*/


                this.chart1.Series[0].Points.AddXY((minimum + maximum) / 2, series[0]);
                this.chart2.Series[0].Points.AddXY((minimum + maximum) / 2, series[2]);
                this.chart3.Series[0].Points.AddXY((minimum + maximum) / 2, series[1]);///////////////////////////////////////////////////////////--
                this.chart4.Series[0].Points.AddXY((minimum + maximum) / 2, series[9]);
                //System.Threading.Thread.Sleep(1000);

                maximum++;
                minimum++;

                dataGridView1.Invoke(new Action(() =>
                {
                
                    satir = dataGridView1.Rows.Add(data);

                dataGridView1.Rows[satir].Cells[0].Value = satirNo;

                dataGridView1.Rows[satir].Cells[3].Value = series[0];
                dataGridView1.Rows[satir].Cells[4].Value = series[1];
                dataGridView1.Rows[satir].Cells[5].Value = series[2];
                dataGridView1.Rows[satir].Cells[6].Value = series[3];
                dataGridView1.Rows[satir].Cells[7].Value = series[4];
                dataGridView1.Rows[satir].Cells[8].Value = series[5];
                dataGridView1.Rows[satir].Cells[9].Value = series[6];
                dataGridView1.Rows[satir].Cells[10].Value = series[7];
                dataGridView1.Rows[satir].Cells[11].Value = series[8];
                dataGridView1.Rows[satir].Cells[12].Value = series[9];/*
                dataGridView1.Rows[satir].Cells[11].Value = series[10];
                dataGridView1.Rows[satir].Cells[12].Value = series[11];
                */

                dataGridView1.Rows[satir].Cells[1].Value = DateTime.Now.ToLongTimeString();    // EN BAŞA STRİNG OLARAK EKLEDİĞİMİZ KOD KISMINDA SÜRE İLERLEMEDİĞİ İÇİN UZUN ZAMAN ZARFI OLARAK DATATİME I BURAYA EKLEDİM
                dataGridView1.Rows[satir].Cells[2].Value = yeni.ToShortDateString();


                satir++;
                satirNo++;

                }));

                /*Thread is process with background because deleting data.*/
                System.Threading.Thread.Sleep(1000);
                //System.Threading.Thread.Sleep(1500);////////////////////////////////////////////////////////////////////Buraya bakılacak
                Application.DoEvents();

                serialPort1.DiscardInBuffer();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                timer1.Stop();
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            disconnect.Enabled = false;
            connect.Enabled = true;

            timer1.Stop();

            System.Threading.Thread.Sleep(1000);
            //System.Threading.Thread.Sleep(1500);
            Application.DoEvents();

            serialPort1.DiscardInBuffer();
            
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
                label2.Text = "Disconnect";
            }

        }
       
        private void telemetry_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }

            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        private async void excellsaved_Click(object sender, EventArgs e)
        {
            await ExcellKayit();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////
        private void excell_clear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
        
    }
}

