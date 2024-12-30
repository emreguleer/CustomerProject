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
            SqlCommand cmd = new SqlCommand("Execute CustomerListWithCity", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From TblCity", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbCity.ValueMember = "CityId";
            cmbCity.DisplayMember = "CityName";
            cmbCity.DataSource = dataTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into TblCustomer (CustomerName, CustomerSurname, CustomerCity, CustomerBalance, CustomerStatus) values (@customerName, @customerSurname, @customerCity, @customerBalance, @customerStatus)", conn);
            cmd.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            cmd.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            cmd.Parameters.AddWithValue("@customerCity", cmbCity.SelectedValue);
            cmd.Parameters.AddWithValue("@customerBalance", txtCustomerBalance.Text);
            if(rdbActive.Checked)
            {
                cmd.Parameters.AddWithValue("@customerStatus", true);
            }
            if (rdbPassive.Checked)
            {
                cmd.Parameters.AddWithValue("@customerStatus", false);
            }
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Müşteri Başarıyla Eklendi.");
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete From TblCustomer Where CustomerId=@customerId", conn);
            cmd.Parameters.AddWithValue("@customerId", txtCustomerId.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Müşteri silme başarılı.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update TblCustomer Set CustomerName=@customerName, CustomerSurname=@customerSurname, CustomerCity=@customerCity, CustomerBalance=@customerBalance, CustomerStatus=@customerStatus Where CustomerId=@customerId", conn);
            cmd.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            cmd.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            cmd.Parameters.AddWithValue("@customerCity", cmbCity.SelectedValue);
            cmd.Parameters.AddWithValue("@customerBalance", txtCustomerBalance.Text);
            cmd.Parameters.AddWithValue("@customerId", txtCustomerId.Text);
            if (rdbActive.Checked)
            {
                cmd.Parameters.AddWithValue("@customerStatus", true);
            }
            if (rdbPassive.Checked)
            {
                cmd.Parameters.AddWithValue("@customerStatus", false);
            }
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Müşteri Başarıyla Güncellendi.");
        }
    }
}
