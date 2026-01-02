
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
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
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
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentDesignFormContainer2 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(260, 39);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(721, 462);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.acGroupDanhMuc,
            this.accordionControlElement3});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 462);
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
            this.acDangNhap.Name = "acDangNhap";
            this.acDangNhap.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acDangNhap.Text = "Đăng nhập";
            this.acDangNhap.Click += new System.EventHandler(this.acDangNhap_Click);
            // 
            // acDangKy
            // 
            this.acDangKy.Name = "acDangKy";
            this.acDangKy.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acDangKy.Text = "Đăng ký";
            this.acDangKy.Click += new System.EventHandler(this.acDangKy_Click);
            // 
            // acDoiMK
            // 
            this.acDoiMK.Name = "acDoiMK";
            this.acDoiMK.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acDoiMK.Text = "Đổi mật khẩu";
            this.acDoiMK.Click += new System.EventHandler(this.acDoiMK_Click);
            // 
            // acDangXuat
            // 
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
            this.acGroupDanhMuc.Expanded = true;
            this.acGroupDanhMuc.Name = "acGroupDanhMuc";
            this.acGroupDanhMuc.Text = "Danh Mục";
            // 
            // aceDssv
            // 
            this.aceDssv.Name = "aceDssv";
            this.aceDssv.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDssv.Text = "Danh sách sinh viên";
            this.aceDssv.Click += new System.EventHandler(this.aceDssv_Click);
            // 
            // aceDSL
            // 
            this.aceDSL.Name = "aceDSL";
            this.aceDSL.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDSL.Text = "Danh sách lớp";
            this.aceDSL.Click += new System.EventHandler(this.aceDSL_Click);
            // 
            // aceHedt
            // 
            this.aceHedt.Name = "aceHedt";
            this.aceHedt.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceHedt.Text = "Hệ đào tạo";
            this.aceHedt.Click += new System.EventHandler(this.aceHedt_Click);
            // 
            // aceThhp
            // 
            this.aceThhp.Name = "aceThhp";
            this.aceThhp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceThhp.Text = "Thu học phí";
            this.aceThhp.Click += new System.EventHandler(this.aceThhp_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Thoát";
            this.accordionControlElement3.Click += new System.EventHandler(this.accordionControlElement3_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(981, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentDesignFormContainer2
            // 
            this.fluentDesignFormContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer2.Location = new System.Drawing.Point(0, 39);
            this.fluentDesignFormContainer2.Name = "fluentDesignFormContainer2";
            this.fluentDesignFormContainer2.Size = new System.Drawing.Size(981, 462);
            this.fluentDesignFormContainer2.TabIndex = 3;
            // 
            // FluentDesignForm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 501);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
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
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
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
    }
}