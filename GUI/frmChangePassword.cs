using System;
using BLL;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class frmChangePassword : XtraForm
    {
        private readonly User_BLL bll = new User_BLL();

        public frmChangePassword()
        {
            InitializeComponent();

            btnChange.Click += btnChange_Click;
            btnBack.Click += (s, e) => this.Close();

            txtOldPass.Properties.UseSystemPasswordChar = true;
            txtNewPass.Properties.UseSystemPasswordChar = true;
            txtNewPass.Properties.UseSystemPasswordChar = true;

            // Nếu đã login thì fill sẵn username
            if (Session.IsLoggedIn)
            {
                txtUser.Text = Session.CurrentUser.USERNAME;
                txtUser.Enabled = false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string u = txtUser.Text.Trim();
            string oldP = txtOldPass.Text.Trim();
            string newP = txtNewPass.Text.Trim();
            string c = txtNewPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(u))
            {
                XtraMessageBox.Show("Vui lòng nhập Username!");
                txtUser.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(oldP) || string.IsNullOrWhiteSpace(newP))
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ mật khẩu!");
                return;
            }
            if (newP != c)
            {
                XtraMessageBox.Show("Xác nhận mật khẩu mới không khớp!");
                txtNewPass.Focus();
                return;
            }

            try
            {
                bool ok = bll.ChangePassword(u, oldP, newP);
                if (!ok)
                {
                    XtraMessageBox.Show("Sai mật khẩu cũ hoặc tài khoản không đúng!");
                    return;
                }

                XtraMessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi đổi mật khẩu: " + ex.Message);
            }
        }
    }
}
