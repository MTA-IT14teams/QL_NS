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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        public void KetNoi()
        {
            SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
            conn.Open();
            string sql = "select *from NhanVien";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhanVien.DataSource = dt;
        }

        public void LoadData()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dgvNhanVien.DataSource, "MaNV");

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", dgvNhanVien.DataSource, "TenNV");

            cbxGioiTinh.DataBindings.Clear();
            cbxGioiTinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "GioiTinh");

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "NgaySinh");

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvNhanVien.DataSource, "DiaChi");

            txtLuong.DataBindings.Clear();
            txtLuong.DataBindings.Add("Text", dgvNhanVien.DataSource, "Luong");

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", dgvNhanVien.DataSource, "TenNV");

            txtMaNGS.DataBindings.Clear();
            txtMaNGS.DataBindings.Add("Text", dgvNhanVien.DataSource, "MaNGS");

            txtMaPB.DataBindings.Clear();
            txtMaPB.DataBindings.Add("Text", dgvNhanVien.DataSource, "MaPB");
        }


        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string them = "insert into NhanVien values ('" + txtMaNV.Text.Trim() + "', N'" + txtTenNV.Text.Trim() + "', '" + cbxGioiTinh.Text.Trim() + "', '" + dtpNgaySinh.Text.Trim() + "',N'" + txtDiaChi.Text.Trim() + "', '" + txtLuong.Text.Trim() + "', '" + txtMaNGS.Text.Trim() + "', '" + txtMaPB.Text.Trim() + "')";
                SqlCommand comm = new SqlCommand(them, conn);
                SqlDataAdapter daThem = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daThem.Fill(dt);
                dgvNhanVien.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string sua = "update NhanVien set MaNV = '" + txtMaNV.Text.Trim() + "',TenNV = N'" + txtTenNV.Text.Trim() + "',GioiTinh = '" + cbxGioiTinh.Text.Trim() + "',NgaySinh = '" + dtpNgaySinh.Text.Trim() + "',DiaChi = N'" + txtDiaChi.Text.Trim() + "', Luong = '" + txtLuong.Text.Trim() + "',MaNGS = '" + txtMaNGS.Text.Trim() + "',MaPB = '" + txtMaPB.Text.Trim() + "' where  MaNV = '" + txtMaNV.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sua, conn);
                SqlDataAdapter daSua = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daSua.Fill(dt);
                dgvNhanVien.DataSource = dt;
                KetNoi();
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
                xoa = "delete NhanVien where MaNV = '" + txtMaNV.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(xoa, conn);
                SqlDataAdapter daXoa = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daXoa.Fill(dt);
                dgvNhanVien.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string sqlTimKiem = "SELECT *FROM NhanVien where MaNV = '" + txtTimKiem.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlTimKiem, conn);
                cmd.Parameters.AddWithValue("MaNV", txtTimKiem.Text.Trim());
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvNhanVien.CurrentRow.Selected = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
