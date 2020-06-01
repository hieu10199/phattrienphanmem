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
    public partial class Form1 : Form
    {
        QL_DangNhap CauHinh = new QL_DangNhap();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống "+lbUser.Text.ToLower());
                this.txtUser.Focus();
                return;
            }
            if(string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                MessageBox.Show("không được bỏ trống "+lbPass.Text.ToLower());
                this.txtPass.Focus();
                return;
            }
            int kq = CauHinh.Check_config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                //ProcessConfig();
            }
            if (kq == 2)
            { 
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
               ProcessConfig();
            }

        }

        private void ProcessConfig()
        {
            frmUpdate frm = new frmUpdate();
            frm.Show();
        }
        public void ProcessLogin()
        {
            int result;
            result = CauHinh.Check_User(txtUser.Text, txtPass.Text);
            if (result == 99)
            {
                MessageBox.Show("Sai " + lbUser.Text + " Hoặc " +lbPass.Text);
                    return;
            }
            else if (result == 100)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            if (Program.mainForm == null || Program.mainForm.IsDisposed)
            {
                Program.mainForm = new frmMain();
            }
            this.Visible = false;
            Program.mainForm.Show();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
        }
    }
}
