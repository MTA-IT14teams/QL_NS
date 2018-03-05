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
           // SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
           // SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2R414VO\SQLEXPRESS;Initial Catalog=NhanVien;Integrated Security=True");
           // ENTITY.Connect.myconnect.Open();
           // conn.Open();
            try
            {
                string sql = "select *from PhongBan";
                SqlCommand cmd = new SqlCommand(sql, ENTITY.Connect.myconnect);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void LoadData()
        {
            txtMaPB.DataBindings.Clear();  // xóa dữ liệu có sẵn trong textbox
            txtMaPB.DataBindings.Add("Text", dataGridView1.DataSource, "MaPB");

            txtTenPB.DataBindings.Clear();
            txtTenPB.DataBindings.Add("Text", dataGridView1.DataSource, "TenPB");

            txtMaTP.DataBindings.Clear();
            txtMaTP.DataBindings.Add("Text", dataGridView1.DataSource, "MaTP");

            txtDiaDiem.DataBindings.Clear();
            txtDiaDiem.DataBindings.Add("Text", dataGridView1.DataSource, "DiaDiem");

           // dtpNgayNC.DataBindings.Clear();
           // dtpNgayNC.DataBindings.Add("Text", dataGridView1.DataSource, "NgayNC");
        }


        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
        }

        string them;
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                them = "insert into PhongBan values ('" + txtMaPB.Text + "', N'" + txtTenPB.Text + "', '" + txtMaTP.Text + "', N'" + txtDiaDiem.Text + "','"+txtNgayNC.Text+"')";
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

        string sua;
        private void btnSua_Click(object sender, EventArgs e)
        {
             try{
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                sua = "update PhongBan set MaPB = '" + txtMaPB.Text + "', TenPB = N'" + txtTenPB.Text + "',MaTP = '" + txtMaTP.Text + "',DiaDiem = N'" + txtDiaDiem.Text + "',NgayNC = '" + txtNgayNC.Text + "' where MaPB = '" + txtMaPB.Text + "'";
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

        string xoa;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                xoa = "delete PhongBan where MaPB = '"+txtMaPB.Text+"'";
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
    }
}
