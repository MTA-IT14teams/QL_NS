using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NS.GUI
{
    public partial class intro : Form
    {
        public intro()
        {
            InitializeComponent();
        }

        private void intro_Load(object sender, EventArgs e)
        {
            if (!frmMain.isLogin)
            {
                this.Hide();
                GUI.frmLogin frm = new GUI.frmLogin();
                frm.ShowDialog();
                // Application.Exit();
                this.Hide();
            }
        }
    }
}
