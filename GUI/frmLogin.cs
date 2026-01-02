using System;
using System.Windows.Forms;
using BLL;
using DAL.Model;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class frmLogin : XtraForm
    {
        private readonly User_BLL bll = new User_BLL();

        public frmLogin()
        {
            InitializeComponent();

            btnLogin.Click += btnLogin_Click;
            btnExit.Click += (s, e) => Application.Exit();

            // Link sang đăng ký
            linkRegister.Click += (s, e) =>
            {
                using (var f = new frmRegister())
                {
                    f.ShowDialog();
                }
            };

            // (Tuỳ chọn) link đổi mật khẩu
            linkChangePass.Click += (s, e) =>
            {
                using (var f = new frmChangePassword())
                {
                    f.ShowDialog();
                }
            };

            // Ẩn ký tự mật khẩu
            txtPass.Properties.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string u = txtUser.Text.Trim();
            string p = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(u))
            {
                XtraMessageBox.Show("Vui lòng nhập Username!");
                txtUser.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(p))
            {
                XtraMessageBox.Show("Vui lòng nhập Password!");
                txtPass.Focus();
                return;
            }

            USERS user = bll.Login(u, p);
            if (user == null)
            {
                XtraMessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                return;
            }

            Session.SetUser(user);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
