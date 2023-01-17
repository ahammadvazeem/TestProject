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

namespace TestProject
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=VAZEEM-PC;Initial Catalog=Employment;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                string query = "INSERT INTO Employee(Emp_name,Emp_code,Emp_address,Emp_phone,Department) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + comboBox1.Text + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                label7.Text = "Registration Success";
                refresh();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void combo()
        {
            string sql = "select * from Department";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Department";
            comboBox1.ValueMember = "Depart_name";

        }

        private void Reg_Load(object sender, EventArgs e)
        {
            combo();
        }

        public void refresh()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }


    }
}
