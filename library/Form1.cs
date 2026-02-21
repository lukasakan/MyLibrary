using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace library
{
    
    public partial class Form1 : Form
    {
        string connections = "Server=DESKTOP-S630PSO;Database=Mylibrary;Integrated Security=True";//input name of your server instead of Your_server_name
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connections);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                "Insert Into Books(Name,Arthur,Page,Pages,[Starting Date],[Finishing Date])" +
                "Values(@Name,@Arthur,@Page,@Pages,@StartingDate,@FinishingDate)";
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200);
            cmd.Parameters.Add("@Arthur", SqlDbType.NVarChar, 150);
            cmd.Parameters.Add("@Page", SqlDbType.Int);
            cmd.Parameters.Add("@Pages", SqlDbType.Int);
            cmd.Parameters.Add("@StartingDate", SqlDbType.DateTime, 8);
            cmd.Parameters.Add("@FinishingDate", SqlDbType.DateTime, 8);
            cmd.Parameters["@Name"].Value = textBox1.Text;
            cmd.Parameters["@Arthur"].Value = textBox2.Text;
            cmd.Parameters["@Page"].Value = textBox3.Text;
            cmd.Parameters["@Pages"].Value = textBox4.Text;
            cmd.Parameters["@StartingDate"].Value = dateTimePicker1.Value;
            cmd.Parameters["@FinishingDate"].Value = dateTimePicker2.Value;
            int row = cmd.ExecuteNonQuery();
            label1.Text = row.ToString();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connections);
            conn.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter("SELECT * FROM Books", conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(myadapter);
            DataSet ds = new DataSet();
            myadapter.Fill(ds, "Books");
            dataGridView1.DataMember = "Books";
            dataGridView1.DataSource = ds;

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int find_key = Convert.ToInt32(textBox5.Text);
            SqlConnection conn = new SqlConnection(connections); 
            conn.Open();
            SqlDataAdapter myadpter = new SqlDataAdapter("Select * from Books", conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(myadpter);
            DataSet DS = new DataSet();
            myadpter.Fill(DS, "Books");
            DataColumn[] keys = new DataColumn[2];
            keys[0] = DS.Tables["Books"].Columns["Id"];
            DS.Tables["Books"].PrimaryKey = keys;
            DataRow findrow = DS.Tables["Books"].Rows.Find(find_key);
            if (findrow != null)
            {
                findrow.Delete();
                myadpter.Update(DS, "Books");
                label1.Text = "row got deleted";

            }
            else label1.Text = "couldnt find row";
            conn.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
    }

