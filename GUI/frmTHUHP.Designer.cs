
namespace GUI
{
    partial class frmTHUHP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTHUHP));
            this.gcTHUHP = new DevExpress.XtraGrid.GridControl();
            this.gvTHUHP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnexit = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deNGAYTHU = new DevExpress.XtraEditors.DateEdit();
            this.lueMAHP = new DevExpress.XtraEditors.LookUpEdit();
            this.lueMASV = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSOTIEN = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deNGAYQD = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcTHUHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTHUHP)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYTHU.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYTHU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMAHP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMASV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOTIEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYQD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYQD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTHUHP
            // 
            this.gcTHUHP.Location = new System.Drawing.Point(67, 201);
            this.gcTHUHP.MainView = this.gvTHUHP;
            this.gcTHUHP.Name = "gcTHUHP";
            this.gcTHUHP.Size = new System.Drawing.Size(976, 407);
            this.gcTHUHP.TabIndex = 39;
            this.gcTHUHP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTHUHP});
            // 
            // gvTHUHP
            // 
            this.gvTHUHP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvTHUHP.GridControl = this.gcTHUHP;
            this.gvTHUHP.Name = "gvTHUHP";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã Sinh Viên";
            this.gridColumn1.FieldName = "MASV";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã Học Phí";
            this.gridColumn2.FieldName = "MAHP";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "NGAYQD";
            this.gridColumn3.FieldName = "NGAYQD";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 94;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ngày Thu";
            this.gridColumn4.FieldName = "NGAYTHU";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 94;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Số Tiền";
            this.gridColumn5.FieldName = "SOTIEN";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 94;
            // 
            // btnexit
            // 
            this.btnexit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.ImageOptions.Image")));
            this.btnexit.Location = new System.Drawing.Point(885, 35);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(106, 40);
            this.btnexit.TabIndex = 38;
            this.btnexit.Text = "Exit";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(724, 36);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 41);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(563, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 41);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(402, 36);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(155, 41);
            this.btnUpdate.TabIndex = 35;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(241, 36);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(155, 41);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "Delete";
            // 
            // btnAddNew
            // 
            this.btnAddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.ImageOptions.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(80, 35);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(155, 41);
            this.btnAddNew.TabIndex = 33;
            this.btnAddNew.Text = "Add new";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deNGAYTHU);
            this.groupBox1.Controls.Add(this.lueMAHP);
            this.groupBox1.Controls.Add(this.lueMASV);
            this.groupBox1.Controls.Add(this.txtSOTIEN);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.deNGAYQD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(80, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 101);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // deNGAYTHU
            // 
            this.deNGAYTHU.EditValue = null;
            this.deNGAYTHU.Location = new System.Drawing.Point(324, 50);
            this.deNGAYTHU.Name = "deNGAYTHU";
            this.deNGAYTHU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNGAYTHU.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNGAYTHU.Size = new System.Drawing.Size(125, 22);
            this.deNGAYTHU.TabIndex = 20;
            // 
            // lueMAHP
            // 
            this.lueMAHP.Location = new System.Drawing.Point(93, 50);
            this.lueMAHP.Name = "lueMAHP";
            this.lueMAHP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMAHP.Size = new System.Drawing.Size(125, 22);
            this.lueMAHP.TabIndex = 19;
            // 
            // lueMASV
            // 
            this.lueMASV.Location = new System.Drawing.Point(93, 20);
            this.lueMASV.Name = "lueMASV";
            this.lueMASV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMASV.Size = new System.Drawing.Size(125, 22);
            this.lueMASV.TabIndex = 18;
            // 
            // txtSOTIEN
            // 
            this.txtSOTIEN.Location = new System.Drawing.Point(529, 18);
            this.txtSOTIEN.Name = "txtSOTIEN";
            this.txtSOTIEN.Size = new System.Drawing.Size(125, 22);
            this.txtSOTIEN.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "SOTIEN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "NGAYQD";
            // 
            // deNGAYQD
            // 
            this.deNGAYQD.EditValue = null;
            this.deNGAYQD.Location = new System.Drawing.Point(324, 16);
            this.deNGAYQD.Name = "deNGAYQD";
            this.deNGAYQD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNGAYQD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNGAYQD.Size = new System.Drawing.Size(125, 22);
            this.deNGAYQD.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "NGAYTHU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "MAHP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã SV";
            // 
            // frmTHUHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 497);
            this.Controls.Add(this.gcTHUHP);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTHUHP";
            this.Text = "frmTHUHP";
            ((System.ComponentModel.ISupportInitialize)(this.gcTHUHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTHUHP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYTHU.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYTHU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMAHP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMASV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOTIEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYQD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYQD.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTHUHP;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTHUHP;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnexit;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtSOTIEN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit deNGAYQD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lueMAHP;
        private DevExpress.XtraEditors.LookUpEdit lueMASV;
        private DevExpress.XtraEditors.DateEdit deNGAYTHU;
    }
}