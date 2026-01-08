
namespace GUI
{
    partial class FluentDesignForm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FluentDesignForm_Main));
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acDangNhap = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acDangKy = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acDoiMK = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acDangXuat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acGroupDanhMuc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDssv = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDSL = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceHedt = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceThhp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acGroupThongKe = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acThongkehocphi = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acsvnohp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.dsbaocaodoanhthu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.dssvconnohp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acquanlythuhocphi = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acbchptheolop = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acthongkedienmiengiam = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acHelp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentDesignFormContainer2 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acdssvnhp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.acGroupDanhMuc,
            this.acGroupThongKe,
            this.acthongkedienmiengiam,
            this.acHelp,
            this.accordionControlElement3});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 701);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.acDangNhap,
            this.acDangKy,
            this.acDoiMK,
            this.acDangXuat});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Hệ thống";
            // 
            // acDangNhap
            // 
            this.acDangNhap.ImageOptions.SvgImage = global::GUI.Properties.Resources.bo_lead;
            this.acDangNhap.Name = "acDangNhap";
            this.acDangNhap.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acDangNhap.Text = "Đăng nhập";
            this.acDangNhap.Click += new System.EventHandler(this.acDangNhap_Click);
            // 
            // acDangKy
            // 
            this.acDangKy.ImageOptions.Image = global::GUI.Properties.Resources.bodetails_32x32;
            this.acDangKy.Name = "acDangKy";
            this.acDangKy.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acDangKy.Text = "Đăng ký";
            this.acDangKy.Click += new System.EventHandler(this.acDangKy_Click);
            // 
            // acDoiMK
            // 
            this.acDoiMK.ImageOptions.Image = global::GUI.Properties.Resources.borole_32x32;
            this.acDoiMK.Name = "acDoiMK";
            this.acDoiMK.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acDoiMK.Text = "Đổi mật khẩu";
            this.acDoiMK.Click += new System.EventHandler(this.acDoiMK_Click);
            // 
            // acDangXuat
            // 
            this.acDangXuat.ImageOptions.Image = global::GUI.Properties.Resources.bouser_32x32;
            this.acDangXuat.Name = "acDangXuat";
            this.acDangXuat.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acDangXuat.Text = "Đăng xuất";
            this.acDangXuat.Click += new System.EventHandler(this.acDangXuat_Click);
            // 
            // acGroupDanhMuc
            // 
            this.acGroupDanhMuc.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceDssv,
            this.aceDSL,
            this.aceHedt,
            this.aceThhp});
            this.acGroupDanhMuc.Name = "acGroupDanhMuc";
            this.acGroupDanhMuc.Text = "Danh Mục";
            // 
            // aceDssv
            // 
            this.aceDssv.ImageOptions.Image = global::GUI.Properties.Resources.team_32x32;
            this.aceDssv.Name = "aceDssv";
            this.aceDssv.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDssv.Text = "Danh sách sinh viên";
            this.aceDssv.Click += new System.EventHandler(this.aceDssv_Click);
            // 
            // aceDSL
            // 
            this.aceDSL.ImageOptions.Image = global::GUI.Properties.Resources.copy_32x32;
            this.aceDSL.Name = "aceDSL";
            this.aceDSL.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDSL.Text = "Danh sách lớp";
            this.aceDSL.Click += new System.EventHandler(this.aceDSL_Click);
            // 
            // aceHedt
            // 
            this.aceHedt.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.aceHedt.Name = "aceHedt";
            this.aceHedt.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceHedt.Text = "Hệ đào tạo";
            this.aceHedt.Click += new System.EventHandler(this.aceHedt_Click);
            // 
            // aceThhp
            // 
            this.aceThhp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceThhp.ImageOptions.Image")));
            this.aceThhp.Name = "aceThhp";
            this.aceThhp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceThhp.Text = "Thu học phí";
            this.aceThhp.Click += new System.EventHandler(this.aceThhp_Click);
            // 
            // acGroupThongKe
            // 
            this.acGroupThongKe.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.acThongkehocphi,
            this.acsvnohp,
            this.dsbaocaodoanhthu,
            this.dssvconnohp,
            this.acquanlythuhocphi,
            this.acbchptheolop});
            this.acGroupThongKe.Expanded = true;
            this.acGroupThongKe.ImageOptions.Image = global::GUI.Properties.Resources.product_32x32;
            this.acGroupThongKe.Name = "acGroupThongKe";
            this.acGroupThongKe.Text = "Thống kê";
            // 
            // acThongkehocphi
            // 
            this.acThongkehocphi.ImageOptions.Image = global::GUI.Properties.Resources.bofileattachment_32x32;
            this.acThongkehocphi.Name = "acThongkehocphi";
            this.acThongkehocphi.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acThongkehocphi.Text = "In phiếu thu học phí";
            this.acThongkehocphi.Click += new System.EventHandler(this.acThongkehocphi_Click);
            // 
            // acsvnohp
            // 
            this.acsvnohp.ImageOptions.Image = global::GUI.Properties.Resources.bofileattachment_32x321;
            this.acsvnohp.Name = "acsvnohp";
            this.acsvnohp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acsvnohp.Text = "Sinh viên còn nợ học phí";
            this.acsvnohp.Click += new System.EventHandler(this.acsvnohp_Click_1);
            // 
            // dsbaocaodoanhthu
            // 
            this.dsbaocaodoanhthu.ImageOptions.Image = global::GUI.Properties.Resources.bofileattachment_32x324;
            this.dsbaocaodoanhthu.Name = "dsbaocaodoanhthu";
            this.dsbaocaodoanhthu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.dsbaocaodoanhthu.Text = "Báo cáo doanh thu";
            this.dsbaocaodoanhthu.Click += new System.EventHandler(this.dsbaocaodoanhthu_Click);
            // 
            // dssvconnohp
            // 
            this.dssvconnohp.ImageOptions.Image = global::GUI.Properties.Resources.bofileattachment_32x325;
            this.dssvconnohp.Name = "dssvconnohp";
            this.dssvconnohp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.dssvconnohp.Text = "DSSV còn nợ học phi";
            this.dssvconnohp.Click += new System.EventHandler(this.dssvconnohp_Click);
            // 
            // acquanlythuhocphi
            // 
            this.acquanlythuhocphi.ImageOptions.Image = global::GUI.Properties.Resources.bofileattachment_32x327;
            this.acquanlythuhocphi.Name = "acquanlythuhocphi";
            this.acquanlythuhocphi.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acquanlythuhocphi.Text = "Quản lý thu học phí";
            this.acquanlythuhocphi.Click += new System.EventHandler(this.acquanlythuhocphi_Click);
            // 
            // acbchptheolop
            // 
            this.acbchptheolop.ImageOptions.Image = global::GUI.Properties.Resources.bofileattachment_32x328;
            this.acbchptheolop.Name = "acbchptheolop";
            this.acbchptheolop.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acbchptheolop.Text = "Báo cáo học phí theo lớp";
            this.acbchptheolop.Click += new System.EventHandler(this.acbchptheolop_Click);
            // 
            // acthongkedienmiengiam
            // 
            this.acthongkedienmiengiam.ImageOptions.Image = global::GUI.Properties.Resources.bofileattachment_32x326;
            this.acthongkedienmiengiam.Name = "acthongkedienmiengiam";
            this.acthongkedienmiengiam.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acthongkedienmiengiam.Text = "Thống kê diện miễn giảm";
            this.acthongkedienmiengiam.Click += new System.EventHandler(this.acthongkedienmiengiam_Click);
            // 
            // acHelp
            // 
            this.acHelp.ImageOptions.Image = global::GUI.Properties.Resources.index_32x32;
            this.acHelp.Name = "acHelp";
            this.acHelp.Text = "Help";
            this.acHelp.Click += new System.EventHandler(this.acHelp_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.ImageOptions.Image = global::GUI.Properties.Resources.cancel_32x32;
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Thoát";
            this.accordionControlElement3.Click += new System.EventHandler(this.accordionControlElement3_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1476, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentDesignFormContainer2
            // 
            this.fluentDesignFormContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer2.Location = new System.Drawing.Point(0, 39);
            this.fluentDesignFormContainer2.Name = "fluentDesignFormContainer2";
            this.fluentDesignFormContainer2.Size = new System.Drawing.Size(1476, 701);
            this.fluentDesignFormContainer2.TabIndex = 3;
            // 
            // accordionControlElement5
            // 
            this.accordionControlElement5.Name = "accordionControlElement5";
            this.accordionControlElement5.Text = "Element5";
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Text = "Element4";
            // 
            // acdssvnhp
            // 
            this.acdssvnhp.ImageOptions.Image = global::GUI.Properties.Resources.bofileattachment_32x323;
            this.acdssvnhp.Name = "acdssvnhp";
            this.acdssvnhp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acdssvnhp.Text = "DSSV còn nợ học phí";
            // 
            // FluentDesignForm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 740);
            this.ControlContainer = this.fluentDesignFormContainer2;
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormContainer2);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "FluentDesignForm_Main";
            this.NavigationControl = this.accordionControl1;
            this.Text = "FluentDesignForm_Main";
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acGroupDanhMuc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDssv;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDSL;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceHedt;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceThhp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acDangNhap;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acDangKy;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acDoiMK;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acDangXuat;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acGroupThongKe;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acThongkehocphi;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acsvnohp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acHelp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acdssvnhp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement dsbaocaodoanhthu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement dssvconnohp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acthongkedienmiengiam;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acquanlythuhocphi;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acbchptheolop;
    }
}