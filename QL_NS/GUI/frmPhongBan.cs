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

    public partial class frmPhongBan : Form
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }

        private void KetNoi()
        {
            try
            {
                string sql = "select *from PhongBan";
                SqlCommand cmd = new SqlCommand(sql, ENTITY.Connect.myconnect);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                dtgPhongBan.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            txtMaPB.DataBindings.Clear();  // xóa dữ liệu có sẵn trong textbox
            txtMaPB.DataBindings.Add("Text", dtgPhongBan.DataSource, "MaPB");

            txtTenPB.DataBindings.Clear();
            txtTenPB.DataBindings.Add("Text", dtgPhongBan.DataSource, "TenPB");

            txtMaTP.DataBindings.Clear();
            txtMaTP.DataBindings.Add("Text", dtgPhongBan.DataSource, "MaTP");

            txtDiaDiem.DataBindings.Clear();
            txtDiaDiem.DataBindings.Add("Text", dtgPhongBan.DataSource, "DiaDiem");

            
        }


        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
        }

        private void dtgPhongBan_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dtgPhongBan.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dtgPhongBan_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dtgPhongBan.CurrentRow.Selected = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string them = "insert into PhongBan values ('" + txtMaPB.Text + "', N'" + txtTenPB.Text + "', '" + txtMaTP.Text + "', N'" + txtDiaDiem.Text + "','" + dtpNgayNC.Text + "')";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.ExecuteReader();
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!" + ex.Message);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string sua = "update PhongBan set MaPB = '" + txtMaPB.Text + "', TenPB = N'" + txtTenPB.Text + "',MaTP = '" + txtMaTP.Text + "',DiaDiem = N'" + txtDiaDiem.Text + "',NgayNC = '" + dtpNgayNC.Text + "' where MaPB = '" + txtMaPB.Text + "'";
                SqlCommand commandSua = new SqlCommand(sua, conn);
                commandSua.ExecuteNonQuery();
                KetNoi();
                LoadData();
            }
            catch
            {
                MessageBox.Show("Lỗi, Không sửa được! Vui lòng kiểm tra lại");
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string xoa = "delete PhongBan where MaPB = '" + txtMaPB.Text + "'";
                SqlCommand commandXoa = new SqlCommand(xoa, conn);
                commandXoa.ExecuteNonQuery();
                KetNoi();
                LoadData();
            }
            catch
            {
                MessageBox.Show("Lỗi, Không sửa được! Vui lòng kiểm tra lại");
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
                string sqlTimKiem = "SELECT *FROM PhongBan where MaPB = '" + txtTimKiem.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlTimKiem, conn);
                cmd.Parameters.AddWithValue("MaNV", txtTimKiem.Text.Trim());
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dtgPhongBan.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgPhongBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
