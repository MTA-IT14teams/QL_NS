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

namespace QL_NS.GUI
{
    public partial class PhanCong : Form
    {
        public PhanCong()
        {
            InitializeComponent();
        }
        public void Ketnoi()
        {
            SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
            conn.Open();
            string sql = "Select *from PhanCong";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPC.DataSource = dt;

        }

        public void LoadData()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dgvPC.DataSource, "MaNV");

            txtMaDA.DataBindings.Clear();
            txtMaDA.DataBindings.Add("Text", dgvPC.DataSource, "MaDA");

            txtSoGio.DataBindings.Clear();
            txtSoGio.DataBindings.Add("Text", dgvPC.DataSource, "SoGio");

        }
        private void PhanCong_Load(object sender, EventArgs e)
        {
            Ketnoi();
            LoadData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string them = "insert into PhanCong values '" + txtMaNV.Text.Trim() + "', '" + txtMaDA.Text.Trim() + "', '" + txtSoGio.Text.Trim() + "',";
                SqlCommand comm = new SqlCommand(them, conn);
                SqlDataAdapter daThem = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daThem.Fill(dt);
                dgvPC.DataSource = dt;
                Ketnoi();
                LoadData();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void dgvPC_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvPC.CurrentRow.Selected = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string sua = "update PhanCong set MaNV = '" + txtMaNV.Text.Trim() + "',MaDA = '" + txtMaDA.Text.Trim() + "',SoGio = '" + txtSoGio.Text.Trim() + "' where  MaNV = '" + txtMaNV.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sua, conn);
                SqlDataAdapter daSua = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daSua.Fill(dt);
                dgvPC.DataSource = dt;
                Ketnoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string xoa;
                xoa = "delete PhanCong where MaNV = '" + txtMaNV.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(xoa, conn);
                SqlDataAdapter daXoa = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daXoa.Fill(dt);
                dgvPC.DataSource = dt;
                Ketnoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Ketnoi();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string sqlTimKiem = "SELECT *FROM PhanCong where MaNV = '" + txtTimKiem.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlTimKiem, conn);
                cmd.Parameters.AddWithValue("MaNV", txtTimKiem.Text.Trim());
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvPC.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
