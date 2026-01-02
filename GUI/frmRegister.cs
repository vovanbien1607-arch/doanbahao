using System;
using System.Windows.Forms;
using BLL;
using DAL.Model;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class frmRegister : XtraForm
    {
        private readonly User_BLL bll = new User_BLL();

        public frmRegister()
        {
            InitializeComponent();

            btnRegister.Click += btnRegister_Click;
            btnBack.Click += (s, e) => this.Close();

            txtPass.Properties.UseSystemPasswordChar = true;
            txtConfirm.Properties.UseSystemPasswordChar = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string u = txtUser.Text.Trim();
            string p = txtPass.Text.Trim();
            string c = txtConfirm.Text.Trim();
            string full = txtFullName.Text.Trim();

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
            if (p != c)
            {
                XtraMessageBox.Show("Xác nhận mật khẩu không khớp!");
                txtConfirm.Focus();
                return;
            }
            if (bll.Exists(u))
            {
                XtraMessageBox.Show("Username đã tồn tại!");
                txtUser.Focus();
                return;
            }

            try
            {
                bll.Register(new USERS
                {
                    USERNAME = u,
                    PASSWORD = p,
                    FULLNAME = full,
                    ROLE = "User"
                });

                XtraMessageBox.Show("Đăng ký thành công! Quay lại đăng nhập.");
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi đăng ký: " + ex.Message);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            var rs = XtraMessageBox.Show(
                "Bạn có chắc muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
                this.Close();
        }
    }
}
