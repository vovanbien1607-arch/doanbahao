using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using BLL;
using DAL.Model;

namespace GUI
{
    public partial class frmDSLOP : XtraForm
    {
        private bool isAdding = false;

        private readonly DSLOP_BLL lopBLL = new DSLOP_BLL();
        private readonly HEDT_BLL heBLL = new HEDT_BLL();

        public frmDSLOP()
        {
            InitializeComponent();

            // Gắn event (đảm bảo chạy)
            this.Load += frmDSLOP_Load;
            gvDSLOP.FocusedRowChanged += gvDSLOP_FocusedRowChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnexit.Click += btnExit_Click;
        }

        private void frmDSLOP_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLookUpMAHE();   
                LoadGridDSLOP();    
                DisableEdit();

                if (gvDSLOP.RowCount > 0)
                {
                    gvDSLOP.FocusedRowHandle = 0;
                    BindCurrentRowToControls();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi load: " + ex.Message, "Lỗi");
            }
        }

        // ===================== LOAD LOOKUP MAHE =====================
        private void LoadLookUpMAHE()
        {
            var listHe = heBLL.GetAll();
            lookUpEdit1.Properties.DataSource = listHe;
            lookUpEdit1.Properties.DisplayMember = "TENHE";
            lookUpEdit1.Properties.ValueMember = "MAHE";
            lookUpEdit1.Properties.NullText = "-- Chọn hệ --";

            lookUpEdit1.Properties.Columns.Clear();
            lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MAHE", "Mã hệ"));
            lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TENHE", "Tên hệ"));

            lookUpEdit1.Properties.ShowHeader = true;
            lookUpEdit1.Properties.DropDownRows = 10;
        }

      
        private void LoadGridDSLOP()
        {
            var data = lopBLL.GetListDSLOP(); // trả về {MALO, TENLOP, MAHE, TENHE}

            gcDSLOP.DataSource = null;
            gcDSLOP.DataSource = data;

            gvDSLOP.Columns.Clear();
            gvDSLOP.PopulateColumns();

            
            gcDSLOP.RefreshDataSource();
        }

        // ===================== BIND ROW -> CONTROLS =====================
        private void gvDSLOP_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvDSLOP.FocusedRowHandle < 0) return;
            BindCurrentRowToControls();
        }

        private void BindCurrentRowToControls()
        {
            txtMaLop.Text = gvDSLOP.GetFocusedRowCellValue("MALO")?.ToString() ?? "";
            txtTenLop.Text = gvDSLOP.GetFocusedRowCellValue("TENLOP")?.ToString() ?? "";

            var mahe = gvDSLOP.GetFocusedRowCellValue("MAHE");
            lookUpEdit1.EditValue = (mahe == null || mahe == DBNull.Value) ? null : mahe.ToString();
        }

        // ===================== ADD NEW =====================
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearFields();
            EnableEdit();

            txtMaLop.Enabled = true;   // thêm mới được nhập mã lớp
            txtMaLop.Focus();
        }

        // ===================== UPDATE =====================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn lớp cần sửa!");
                return;
            }

            isAdding = false;
            EnableEdit();
            txtMaLop.Enabled = false; // sửa thì KHÔNG cho đổi mã
        }

        // ===================== DELETE =====================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn lớp cần xóa!");
                return;
            }

            if (XtraMessageBox.Show("Bạn có chắc muốn xóa lớp này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    lopBLL.Delete(txtMaLop.Text.Trim());
                    LoadGridDSLOP();
                    DisableEdit();

                    if (gvDSLOP.RowCount > 0)
                    {
                        gvDSLOP.FocusedRowHandle = 0;
                        BindCurrentRowToControls();
                    }
                    else
                    {
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // ===================== SAVE =====================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var lop = new DSLOP
            {
                MALO = txtMaLop.Text.Trim(),
                TENLOP = txtTenLop.Text.Trim(),
                MAHE = lookUpEdit1.EditValue?.ToString()
            };

            try
            {
                if (isAdding) lopBLL.Insert(lop);
                else lopBLL.Update(lop);

                LoadGridDSLOP();
                DisableEdit();

                int handle = gvDSLOP.LocateByValue("MALO", lop.MALO);
                gvDSLOP.FocusedRowHandle = (handle >= 0) ? handle : 0;
                BindCurrentRowToControls();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        // ===================== CANCEL =====================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableEdit();
            if (gvDSLOP.FocusedRowHandle >= 0)
                BindCurrentRowToControls();
        }

        // ===================== EXIT =====================
        private void btnExit_Click(object sender, EventArgs e)
        {
            var rs = XtraMessageBox.Show("Bạn có chắc muốn thoát?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
                this.Close();
        }

        // ===================== UI HELPERS =====================
        private void ClearFields()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            lookUpEdit1.EditValue = null;
        }

        private void EnableEdit()
        {
            txtTenLop.Enabled = lookUpEdit1.Enabled = true;

            btnSave.Enabled = btnCancel.Enabled = true;
            btnAddNew.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
        }

        private void DisableEdit()
        {
            txtMaLop.Enabled = txtTenLop.Enabled = lookUpEdit1.Enabled = false;

            btnSave.Enabled = btnCancel.Enabled = false;
            btnAddNew.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập Mã lớp!");
                txtMaLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập Tên lớp!");
                txtTenLop.Focus();
                return false;
            }

            if (lookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn Mã hệ!");
                return false;
            }

            return true;
        }


    }
}
