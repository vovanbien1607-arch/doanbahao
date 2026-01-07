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

            
            acDangNhap.Click += acDangNhap_Click;
            acDangKy.Click += acDangKy_Click;
            acDoiMK.Click += acDoiMK_Click;
            acDangXuat.Click += acDangXuat_Click;

    
            aceDssv.Click += aceDssv_Click;
            aceDSL.Click += aceDSL_Click;
            aceHedt.Click += aceHedt_Click;
            aceThhp.Click += aceThhp_Click;

            this.Load += FluentDesignForm_Main_Load;
        }

    
        private void FluentDesignForm_Main_Load(object sender, EventArgs e)
        {
            ApplyAuthUI();      

            ShowLogin();
        }

 
        private Form isOpen(Type ftype)
        {
            foreach (Control c in this.fluentDesignFormContainer1.Controls)
            {
                if (c.GetType() == ftype)
                    return c as Form;
            }
            return null;
        }

      
        private void OpenChildForm(Form f)
        {
           
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

    
        private void ApplyAuthUI()
        {
            bool logged = Session.IsLoggedIn;

        
            acGroupDanhMuc.Enabled = logged;

            acDangNhap.Enabled = !logged;
            acDangKy.Enabled = !logged;

            acDoiMK.Enabled = logged;
            acDangXuat.Enabled = logged;
        }

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
                    ApplyAuthUI();
                }
            }
        }

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

           
            Session.Clear();
            ApplyAuthUI();

           
            this.fluentDesignFormContainer1.Controls.Clear();

            XtraMessageBox.Show("Đã đăng xuất!");
            ShowLogin(); 
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc muốn thoát?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void acBaocaodoanhthu_Click(object sender, EventArgs e)
        {
            var report = new XtraReport_BaoCaoDoanhThu();
            var viewer = new frmReportViewer(report, "Báo Cáo Doanh Thu");
            viewer.ShowDialog(); 
        }

        private void acThongkehocphi_Click(object sender, EventArgs e)
        {
            var report = new XtraReport_ThuHocPhi();

            var viewer = new frmReportViewer(report, "Thống Kê Thu Học Phí");
            viewer.ShowDialog();
        }

        private void acDssvnohp_Click(object sender, EventArgs e)
        {
            var report = new XtraReport_DSSVnoHP();
            var viewer = new frmReportViewer(report, "Danh Sách Sinh Viên Nợ Học Phí");
            viewer.ShowDialog();
        }

        private void acHelp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHelp());
        }
    }
}
