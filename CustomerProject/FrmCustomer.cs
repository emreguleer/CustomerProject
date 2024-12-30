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

namespace CustomerProject
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=Desktop-17CL2RN;initial catalog=CustomerDb;integrated security=true");
        private void btnList_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select CustomerId, CustomerName, CustomerSurname, CustomerBalance, CustomerStatus, CityName From TblCustomer Inner Join TblCity On TblCity.CityId = TblCustomer.CustomerCity", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select CustomerId, CustomerName, CustomerSurname, CustomerBalance, CustomerStatus, CityName From TblCustomer Inner Join TblCity On TblCity.CityId = TblCustomer.CustomerCity", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
