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
    public partial class LoginSQL : Form
    {
        public LoginSQL()
        {
            InitializeComponent();
        }

        private void openConnect()
        {
            if (ENTITY.Connect.myconnect.State == ConnectionState.Closed)
            {
                ENTITY.Connect.myconnect.Open();
              //  ENTITY.Connect.isConnect = true;
            }
        }

        private void closeConnect()
        {
            if (ENTITY.Connect.myconnect.State == ConnectionState.Open)
            {
                ENTITY.Connect.myconnect.Close();
                ENTITY.Connect.isConnect = false;
            }
        }

        private void intro_Load(object sender, EventArgs e)
        {
            ActiveControl = txtServerName;
            cbbAuthen.SelectedIndex = 0;


            if (cbbAuthen.SelectedIndex == 0)
            {
                this.txtLogin.Enabled = true;
                this.txtPass.Enabled = true;
                this.cbSaveInfo.Enabled = true;

            }
            else
            {

                this.txtLogin.Enabled = false;
                this.txtPass.Enabled = false;
                this.cbSaveInfo.Enabled = true;

            }
            ////////////////////////////////////// neu da ket noi thi login 
            if (ENTITY.Connect.isConnect)
            {
                this.Hide();
                if (!frmMain.isLogin)
                {
                   
                    GUI.frmLogin frm = new GUI.frmLogin();
                    frm.ShowDialog();
                    // Application.Exit();
                   
                }
                ////////////////////////////////////////
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbAuthen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbAuthen.SelectedIndex == 0)
            {
                this.txtLogin.Enabled = true;
                this.txtPass.Enabled = true;
                this.cbSaveInfo.Enabled = true;

            }
            else
            {

                this.txtLogin.Enabled = false;
                this.txtPass.Enabled = false;
                this.cbSaveInfo.Enabled = true;

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtServerName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn Phải Nhập ServerName!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl = txtServerName;
                    return;
                }

                if (this.txtDatabaseName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn Phải Nhập DataBase!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl = txtDatabaseName;
                    return;
                }
                if (cbbAuthen.SelectedIndex == 0)
                {
                    if (txtLogin.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn Phải Nhập User!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = txtLogin;
                        return;
                    }
                }

                ENTITY.ConnectString.DatabaseName = txtDatabaseName.Text;
                ENTITY.ConnectString.ServerName = txtServerName.Text;
                ENTITY.ConnectString.WinAuthentication = (cbbAuthen.SelectedIndex == 0 ? false : true);
                ENTITY.ConnectString.UserName = txtLogin.Text;
                ENTITY.ConnectString.Password = txtPass.Text;

                ENTITY.ConnectString.TaoChuoiKetNoi();
                //
                ENTITY.Connect.myconnect = new SqlConnection(ENTITY.ConnectString.StringConnect);
                try
                {
                    openConnect();
                    if (ENTITY.Connect.myconnect.State == ConnectionState.Open)
                    {
                        ENTITY.Connect.isConnect = true;
                    }
                    this.intro_Load(null, null);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

