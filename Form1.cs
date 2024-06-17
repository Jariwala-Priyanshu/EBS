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

namespace EBS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=EBSdb;Integrated Security=True;Encrypt=False");

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into bill values(@Client_ID,@Client_Name,@Unit,@Unit_Price,@Total)", con);

            cnn.Parameters.AddWithValue("@Client_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Client_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@Unit", int.Parse(textBox3.Text));

            cnn.Parameters.AddWithValue("@Unit_Price", textBox4.Text);

            cnn.Parameters.AddWithValue("@Total", int.Parse(textBox5.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            SqlCommand cnn = new SqlCommand("select * from bill", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            double d1, d2;

            d1 = double.Parse(textBox6.Text);

            d2 = double.Parse(textBox7.Text);

            textBox8.Text = (d1 * d2).ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=EBSdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete bill where client_id=@client_id", con);

            cnn.Parameters.AddWithValue("@Client_ID", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cnn = new SqlCommand("select * from bill", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}
