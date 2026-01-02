
namespace GUI
{
    partial class frmHEDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHEDT));
            this.gcHEDT = new DevExpress.XtraGrid.GridControl();
            this.gvHEDT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnexit = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHPCB = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMAHE = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTENHE = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHEDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHEDT)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHPCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAHE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENHE.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcHEDT
            // 
            this.gcHEDT.Location = new System.Drawing.Point(77, 206);
            this.gcHEDT.MainView = this.gvHEDT;
            this.gcHEDT.Name = "gcHEDT";
            this.gcHEDT.Size = new System.Drawing.Size(896, 369);
            this.gcHEDT.TabIndex = 55;
            this.gcHEDT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHEDT});
            // 
            // gvHEDT
            // 
            this.gvHEDT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvHEDT.GridControl = this.gcHEDT;
            this.gvHEDT.Name = "gvHEDT";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã Hệ Đào Tạo";
            this.gridColumn1.FieldName = "MAHE";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên Hệ Đào Tạo";
            this.gridColumn2.FieldName = "TENHE";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Hoc Phí Cơ Bản";
            this.gridColumn3.FieldName = "HPCB";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 94;
            // 
            // btnexit
            // 
            this.btnexit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.ImageOptions.Image")));
            this.btnexit.Location = new System.Drawing.Point(895, 40);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(106, 40);
            this.btnexit.TabIndex = 54;
            this.btnexit.Text = "Exit";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(734, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 41);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Cancel";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(573, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 41);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(412, 41);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(155, 41);
            this.btnUpdate.TabIndex = 51;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(251, 41);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(155, 41);
            this.btnDelete.TabIndex = 50;
            this.btnDelete.Text = "Delete";
            // 
            // btnAddNew
            // 
            this.btnAddNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.ImageOptions.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(90, 40);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(155, 41);
            this.btnAddNew.TabIndex = 49;
            this.btnAddNew.Text = "Add new";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHPCB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMAHE);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTENHE);
            this.groupBox1.Location = new System.Drawing.Point(90, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 101);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // txtHPCB
            // 
            this.txtHPCB.Location = new System.Drawing.Point(644, 32);
            this.txtHPCB.Name = "txtHPCB";
            this.txtHPCB.Size = new System.Drawing.Size(136, 22);
            this.txtHPCB.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Học Phí Cơ Bản";
            // 
            // txtMAHE
            // 
            this.txtMAHE.Location = new System.Drawing.Point(128, 34);
            this.txtMAHE.Name = "txtMAHE";
            this.txtMAHE.Size = new System.Drawing.Size(125, 22);
            this.txtMAHE.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mã Hệ Đào Tạo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên Hệ Đào Tạo";
            // 
            // txtTENHE
            // 
            this.txtTENHE.Location = new System.Drawing.Point(381, 34);
            this.txtTENHE.Name = "txtTENHE";
            this.txtTENHE.Size = new System.Drawing.Size(125, 22);
            this.txtTENHE.TabIndex = 2;
            // 
            // frmHEDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 506);
            this.Controls.Add(this.gcHEDT);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHEDT";
            this.Text = "frmHEDT";
            ((System.ComponentModel.ISupportInitialize)(this.gcHEDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHEDT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHPCB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAHE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENHE.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcHEDT;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHEDT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnexit;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtHPCB;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtMAHE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtTENHE;
    }
}