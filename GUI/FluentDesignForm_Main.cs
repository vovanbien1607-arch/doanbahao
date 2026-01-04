using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FluentDesignForm_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FluentDesignForm_Main()
        {
            InitializeComponent();

            // Gắn sự kiện click menu hệ thống (nếu bạn chưa gắn trong designer)
            acDangNhap.Click += acDangNhap_Click;
            acDangKy.Click += acDangKy_Click;
            acDoiMK.Click += acDoiMK_Click;
            acDangXuat.Click += acDangXuat_Click;

            // Gắn sự kiện click danh mục
            aceDssv.Click += aceDssv_Click;
            aceDSL.Click += aceDSL_Click;
            aceHedt.Click += aceHedt_Click;
            aceThhp.Click += aceThhp_Click;

            this.Load += FluentDesignForm_Main_Load;
        }

        // ===================== FORM LOAD: mở login luôn =====================
        private void FluentDesignForm_Main_Load(object sender, EventArgs e)
        {
            ApplyAuthUI();       // khóa danh mục trước

            // ✅ mở form đăng nhập ngay khi chạy chương trình
            ShowLogin();
        }

        // ===================== KIỂM TRA FORM ĐANG MỞ =====================
        private Form isOpen(Type ftype)
        {
            foreach (Control c in this.fluentDesignFormContainer1.Controls)
            {
                if (c.GetType() == ftype)
                    return c as Form;
            }
            return null;
        }

        // ===================== MỞ FORM CON =====================
        private void OpenChildForm(Form f)
        {
            // ✅ bắt buộc login mới mở được danh mục
            if (!Session.IsLoggedIn)
            {
                XtraMessageBox.Show("Vui lòng đăng nhập để sử dụng chức năng Danh mục!");
                ShowLogin();
                return;
            }

            Form existing = isOpen(f.GetType());

            if (existing == null)
            {
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;

                this.fluentDesignFormContainer1.Controls.Add(f);
                this.fluentDesignFormContainer1.Tag = f;

                f.Show();
                f.BringToFront();
            }
            else
            {
                existing.BringToFront();
            }
        }

        // ===================== KHÓA / MỞ MENU THEO LOGIN =====================
        private void ApplyAuthUI()
        {
            bool logged = Session.IsLoggedIn;

            // ✅ Khóa/Mở group Danh Mục
            // !!! ĐỔI "acGroupDanhMuc" đúng tên group Danh Mục của bạn trong Designer
            acGroupDanhMuc.Enabled = logged;

            // Hệ thống
            acDangNhap.Enabled = !logged;
            acDangKy.Enabled = !logged;

            acDoiMK.Enabled = logged;
            acDangXuat.Enabled = logged;
        }

        // ===================== HIỆN FORM LOGIN =====================
        private void ShowLogin()
        {
            using (var f = new frmLogin())
            {
                var rs = f.ShowDialog();

                if (rs == DialogResult.OK)
                {
                    ApplyAuthUI();
                    XtraMessageBox.Show("Đăng nhập thành công!");
                }
                else
                {
                    // Nếu user bấm đóng login mà chưa đăng nhập -> vẫn khóa danh mục
                    ApplyAuthUI();
                }
            }
        }

        // ===================== CLICK DANH MỤC =====================
        private void aceThhp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTHUHP());
        }

        private void aceHedt_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHEDT());
        }

        private void aceDSL_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDSLOP());
        }

        private void aceDssv_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDSSV());
        }

       
        private void acDangNhap_Click(object sender, EventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                XtraMessageBox.Show("Bạn đã đăng nhập rồi!");
                return;
            }
            ShowLogin();
        }

        private void acDangKy_Click(object sender, EventArgs e)
        {
            using (var f = new frmRegister())
            {
                f.ShowDialog();
            }
        }

        private void acDoiMK_Click(object sender, EventArgs e)
        {
            using (var f = new frmChangePassword())
            {
                f.ShowDialog();
            }
        }

        private void acDangXuat_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn) return;

            if (XtraMessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // logout
            Session.Clear();
            ApplyAuthUI();

            // đóng hết form con đang mở
            this.fluentDesignFormContainer1.Controls.Clear();

            XtraMessageBox.Show("Đã đăng xuất!");
            ShowLogin(); // nếu bạn muốn logout là bắt login lại ngay
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acBaocaodoanhthu_Click(object sender, EventArgs e)
        {
           
            XtraReport rpt = new XtraReport_BaoCaoDoanhThu();
            OpenChildForm(new frmReportViewer(rpt, "BÁO CÁO DOANH THU"));
        }

        private void acThongkehocphi_Click(object sender, EventArgs e)
        {
           

           
            XtraReport rpt = new XtraReport_ThuHocPhi();
            OpenChildForm(new frmReportViewer(rpt, "BÁO CÁO THU HỌC PHÍ"));
        }

        private void acDssvnohp_Click(object sender, EventArgs e)
        {
           
            XtraReport rpt = new XtraReport_DSSVnoHP();
            OpenChildForm(new frmReportViewer(rpt, "DANH SÁCH SV CÒN NỢ HỌC PHÍ"));
        }
    }
}
