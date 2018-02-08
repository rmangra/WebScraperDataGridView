using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSDatagridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetCustomerList();
        }
        private DataTable GetCustomerList()
        {
            var dtCustomers = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["NWDataGridView.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            using (var con = new SqlConnection(connString))
            {

                using (var cmd = new SqlCommand("SELECT * FROM CryptoCurrencies", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtCustomers.Load(reader);

                }

                return dtCustomers;
            }
        }
    }
}
