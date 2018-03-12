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
using System.IO;

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
            /////////////// doc du lieu da luu
            FileStream fs = new FileStream("config.ini",FileMode.OpenOrCreate,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            try
            {
                int selectIndex;
                this.txtServerName.Text = sr.ReadLine();
                int.TryParse(sr.ReadLine(),out selectIndex);
                this.cbbAuthen.SelectedIndex = selectIndex;
                if (selectIndex == 0)
                {
                    this.txtLogin.Text = sr.ReadLine();
                    this.txtPass.Text = sr.ReadLine();
                    this.txtDatabaseName.Text = sr.ReadLine();
                }
                else
                {
                    this.txtDatabaseName.Text = sr.ReadLine();
                }
            }
            catch 
            {

            }
            finally
            {
                sr.Close();
                fs.Close();
            }
            //////////////////////
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
                
                ENTITY.Connect.myconnect = new SqlConnection(ENTITY.ConnectString.StringConnect);
                try
                {
                    openConnect();
                    if (ENTITY.Connect.myconnect.State == ConnectionState.Open)
                    {
                        ENTITY.Connect.isConnect = true;

                        if(cbSaveInfo.Checked)
                        {

                            //////////////luu du lieu vao file config.ini
                            FileStream fs = new FileStream("config.ini", FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(fs);
                            try
                            {
                               
                                sw.WriteLine(this.txtServerName.Text);
                                sw.WriteLine(this.cbbAuthen.SelectedIndex);
                                if (this.cbbAuthen.SelectedIndex == 0)
                                {
                                    sw.WriteLine(this.txtLogin.Text);
                                    sw.WriteLine(this.txtPass.Text);
                                    sw.WriteLine(this.txtDatabaseName.Text);
                                }
                                else
                                {
                                    sw.WriteLine(this.txtDatabaseName.Text);
                                }
                            }
                            catch
                            {

                            }
                            finally
                            {
                                sw.Close();
                                fs.Close();
                            }
                            ///////////////////////
                        }

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

