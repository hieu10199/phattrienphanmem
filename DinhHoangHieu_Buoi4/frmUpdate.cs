using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinhHoangHieu_Buoi4
{
    public partial class frmUpdate : Form
    {
        QL_DangNhap CauHinh = new QL_DangNhap();
        public frmUpdate()
        {
            InitializeComponent();
        }

        private void cbbServerName_DropDown(object sender, EventArgs e)
        {
            cbbServerName.DataSource = CauHinh.GetServerName();
            cbbServerName.DisplayMember = "ServerName";
        }

        private void cbbDatabase_DropDown(object sender, EventArgs e)
        {
            cbbDatabase.DataSource =CauHinh.GetDBName(cbbServerName.Text, txtUsername.Text, txtPassword.Text);
            cbbDatabase.DisplayMember = "name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CauHinh.SaveConfig(cbbServerName.Text, txtUsername.Text, txtPassword.Text,cbbDatabase.Text);
            this.Close();
        }
    }
}
