using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Http;
using System.Net;
using System.IO;

namespace WindowsFormsApp2
{

    public partial class Form2 : Form
    {

        public Form2()
        {

            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            comboBox1.Items.Add("TRAIL");
            comboBox1.Items.Add("1 YEAR");
            comboBox1.Items.Add("6 MONTHS");
            comboBox1.SelectedItem = "TRAIL";
            comboBox1.SelectedIndex = comboBox1.FindStringExact("test3");
        }

        private void gENERATEKEYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void vIEWRECORDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            string MyConnection2 = "datasource=karnex.in;database=karnexin_rahul;port=3306;username=karnexin_rahul;password=rahul";
            string Query = "select *from license;";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand2;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            dataGridView1.DataSource = dTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest request = HttpWebRequest.Create("http://127.0.0.1:8081/newkey");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string urlText = reader.ReadToEnd();
            textBox1.Text = urlText;

        }


    }
}






