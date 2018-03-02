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
using System.Data;

namespace QL_NS.GUI
{
    public partial class frmLogin : Form
    {
        public static string ID_USER = "";
       private SqlConnection con = new SqlConnection("Data Source=DESKTOP-UN97D4V\\SQLEXPRESS;Initial Catalog=QL_NhanSu;Persist Security Info=True;User ID=sa; Password=icui4cu");
       // Data Source = DESKTOP - UN97D4V\SQLEXPRESS;Initial Catalog = QL_NhanSu; Persist Security Info=True;User ID = sa; Password=***********
        private void openConnect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        private void  closeConnect()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private string getID(string username, string pass)
        {
            string id = "";
            try
            {
                openConnect();
                SqlCommand cmd = new SqlCommand("Select * from tbl_users where user_name ='" + username + "' and pass ='" + pass + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt != null)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        id = dr["id_user"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sảy ra khi truy vấn dữ liệu hoặc kết nối tới server bị lỗi.\n Hãy kiểm tra lại.\n"+ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                closeConnect();
            }

            return id;

        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ID_USER = getID(txtUser.Text, txtPass.Text);
            if(ID_USER!= "")
            {
                frmMain.isLogin = true;
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else
            {
                frmMain.isLogin = false;
                MessageBox.Show("Taì khoản hoặc mật khẩu không đúng.\n Hãy kiểm tra lại.\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
