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
            var postData = "date=" + String.Join("-",dateTimePicker1.Value.Date.ToString().Split(' ')[0].Split('-').Reverse());
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string urlText = reader.ReadToEnd();
            //textBox1.Text = urlText;
            MessageBox.Show(urlText);
           
            string[] authorsList = urlText.Split(',');
            textBox1.Text = authorsList[0];
            textBox2.Text = authorsList[1];

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string Id = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                if (dataGridView1.SelectedRows[0].Cells[4].Value.Equals(1))
                {
                    string MyConnection2 = "datasource=karnex.in;database=karnexin_rahul;port=3306;username=karnexin_rahul;password=rahul";
                    string Query = "update license set activation_status='2' where id=" + Id;
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Data Updated");
                }
                else { MessageBox.Show("Data"); }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedItem != null)
            //{
            //    button1.Enabled = true;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Join("-", dateTimePicker1.Value.Date.ToString().Split(' ')[0].Split('-').Reverse()));
        }

       
    }
}






