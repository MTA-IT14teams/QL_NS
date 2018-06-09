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
using QL_NS.ENTITY;
namespace QL_NS.GUI
{
    public partial class frm_DuAn : Form
    {
        DataTable dt;
        bool themmoi = false;
        int dong = -1;
        public frm_DuAn()
        {
            InitializeComponent();
        }
        public void Mo_txt()
        {
            //các txt mở lại để nhập
            txtMaDA.ReadOnly = false;
            txtTenDA.ReadOnly = false;
            txtDiaDiem.ReadOnly = false;            
        }
        public void Khoa_btn()
        {
            //các txt khóa, ko cho nhập 
            txtMaDA.ReadOnly = true;
            txtTenDA.ReadOnly = true;
            txtDiaDiem.ReadOnly = true;            
        }
        public void LoadGV()
        {
            SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
            conn.Open();
            string sql = "Select *from DuAn";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            dgvDA.DataSource = dt;
            conn.Close();
        }
        public void SetNull()
        {
            //txtMaDA.Text = "";
            txtTenDA.Text = "";
            txtDiaDiem.Text = "";            
        }
        private void show_cb_PB()
        {
            SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
            conn.Open();
            string strSQL = "select * from PhongBan";
            dt = new DataTable();
            SqlDataAdapter sqlDa = new SqlDataAdapter(strSQL, conn);
            sqlDa.Fill(dt);
            cbTenPB.DataSource = dt;
            cbTenPB.DisplayMember = "TenPB";
            cbTenPB.ValueMember = "MaPB";
            conn.Close();
        }
        public void LoadDuAn()
        {
            SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
            conn.Open();
            string sql = "Select * from DuAn";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            dgvDA.DataSource = dt;
            conn.Close();
        }
        private void frm_DuAn_Load(object sender, EventArgs e)
        {
            Khoa_btn();
            LoadDuAn();
        }
        private void dgvDA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dong = e.RowIndex;
                txtMaDA.Text = dgvDA.Rows[dong].Cells[0].Value.ToString();
                txtTenDA.Text = dgvDA.Rows[dong].Cells[1].Value.ToString();
                txtDiaDiem.Text = dgvDA.Rows[dong].Cells[3].Value.ToString();
                // hiển thị comboBox
                SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                conn.Open();
                string strSQL = "select * from PhongBan where MaPB = '" + dgvDA.Rows[dong].Cells[3].Value.ToString() + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDa = new SqlDataAdapter(strSQL, conn);
                sqlDa.Fill(dt);
                cbTenPB.DataSource = dt;
                cbTenPB.ValueMember = "MaPB";
                cbTenPB.DisplayMember = "TenPB";

                Khoa_btn();
            }
            catch { }
        }
        public string TangMa()
        {
            SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
            conn.Open();
            string sql = "select MaDA from DuAn";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "001";
            }
            else
            {
                int k;
                ma = "0";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                {
                    if (dt.Rows.Count < 10)
                    {
                        ma = ma + "0";
                    }
                    else if (dt.Rows.Count < 20)
                    {
                        ma = ma + "1";
                    }
                    else if (dt.Rows.Count < 30)
                    {
                        ma = ma + "2";
                    }
                    else if (dt.Rows.Count < 40)
                    {
                        ma = ma + "3";
                    }

                }

                ma = ma + k.ToString();
            }            
            return ma;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            themmoi = true;
            //Mở nút lưu 
            txtMaDA.Enabled = false;

            txtMaDA.Text = TangMa();

            txtMaDA.Focus();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            
            Mo_txt();
            SetNull();
            // hiển thị ds phòng ban
            show_cb_PB();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            if (dong < 0)
            {
                MessageBox.Show("Chưa chọn dự án để sửa!");
                return;
            }
            Mo_txt();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            //hienthi ds Ma Mon
            show_cb_PB();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {             
            if (txtMaDA.Text == "" || txtTenDA.Text == "")
            {
                MessageBox.Show("Xin mời nhập đầy đủ thông tin");
                Khoa_btn();
                return;
            }
            else
            {
                //Them DA
                #region
                if (themmoi == true)
                {
                    try
                    {
                        SqlConnection connT = new SqlConnection(ENTITY.ConnectString.StringConnect);
                        connT.Open();
                        SqlCommand cmd = new SqlCommand("THEMDUAN", connT);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter("@MaDA", txtMaDA.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@TenDA", txtTenDA.Text);
                        cmd.Parameters.Add(p);                 
                                                
                        p = new SqlParameter("@DiaDiem", txtDiaDiem.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@MaPB", cbTenPB.SelectedValue.ToString());
                        cmd.Parameters.Add(p);

                        cmd.ExecuteNonQuery();
                        //Hiển thị lại thông tin sau khi thêm và thông báo
                        LoadDuAn();
                        //MessageBox.Show("Thêm mới thành công");
                        //
                        txtMaDA.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        SetNull();
                        connT.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                #endregion

                //Sua DA
                #region
                else
                {
                    try
                    {
                        SqlConnection connX = new SqlConnection(ENTITY.ConnectString.StringConnect);
                        connX.Open();
                        SqlCommand cmd2 = new SqlCommand("SUADA", connX);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter("@MaDA", txtMaDA.Text);
                        cmd2.Parameters.Add(p);
                        p = new SqlParameter("@TenDA", txtTenDA.Text);
                        cmd2.Parameters.Add(p);

                        p = new SqlParameter("@DiaDiem", txtDiaDiem.Text);
                        cmd2.Parameters.Add(p);

                        p = new SqlParameter("@MaPB", cbTenPB.SelectedValue.ToString());
                        cmd2.Parameters.Add(p);

                        cmd2.ExecuteNonQuery();

                        //Hiển thị lại thông tin sau khi thêm và thông báo
                        //MessageBox.Show("Thay đổi thông tin dự án thành công");
                        btnThem.Enabled = true;
                        btnLuu.Enabled = false;
                        btnXoa.Enabled = true;
                        SetNull();
                        Khoa_btn();/*không cho thao tác*/
                        LoadGV();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                #endregion                
            }
        
    }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ENTITY.ConnectString.StringConnect);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("XOADUAN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@MaDA", txtMaDA.Text);
                    cmd.Parameters.Add(p);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadDuAn();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void txt_TenDuAn_Click(object sender, EventArgs e)
        {
            txt_TenDuAn.Text = "";
        }

        private void txt_MaDuAn_Click(object sender, EventArgs e)
        {
            txt_MaDuAn.Text = "";
        }

        private void txt_TenDuAn_TextChanged(object sender, EventArgs e)
        {
            string tenda = string.Format("[TenDA] like '%{0}%'", txt_TenDuAn.Text);
            dt.DefaultView.RowFilter = tenda;
        }

        private void txt_MaDuAn_TextChanged(object sender, EventArgs e)
        {
            string mada = string.Format("[MaDA] like '%{0}%'", txt_MaDuAn.Text);
            dt.DefaultView.RowFilter = mada;
        }
        public static void ExportToExcel(DataGridView dtgr)
        {
            // Creating a Excel object.
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column.
                for (int i = -1; i < dtgr.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dtgr.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dtgr.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dtgr.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                worksheet.Columns.AutoFit();
                //Getting the location and file name of the excel to save from user.
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvDA);
        }
    }
}
