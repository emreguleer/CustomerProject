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
    public partial class FrmCity : Form
    {
        public FrmCity()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=Desktop-17CL2RN;initial catalog=CustomerDb;integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Select * From TblCity", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into TblCity(CityName, CityCountry) values (@cityName, @cityCountry)", conn);
            cmd.Parameters.AddWithValue("@cityName", txtCityName.Text);
            cmd.Parameters.AddWithValue("@cityCountry", txtCountry.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Şehir başarılı bir şekilde eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete From TblCity Where CityId=@cityId", conn);
            cmd.Parameters.AddWithValue("@cityId", txtCityId.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Şehir silme başarılı.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update TblCity Set CityName=@cityName, CityCountry=@cityCountry where CityId=@cityId", conn);
            cmd.Parameters.AddWithValue("@cityName", txtCityName);
            cmd.Parameters.AddWithValue("@cityNCountryName", txtCountry);
            cmd.Parameters.AddWithValue("@cityId", txtCityId);
            cmd.Parameters.AddWithValue("@cityId", txtCityId);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Şehir güncelleme başarılı.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From TblCity Where CityName=@cityName", conn);
            cmd.Parameters.AddWithValue("@cityName", txtCityName);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
