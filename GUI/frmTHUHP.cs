using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using BLL;
using DAL.Model;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class frmTHUHP : XtraForm
    {
        private bool isAdding = false;

        private THUHP_BLL thuhpBLL = new THUHP_BLL();
        private DSSV_Lookup_BLL svLookupBLL = new DSSV_Lookup_BLL();
        private HOCPHI_Lookup_BLL hpLookupBLL = new HOCPHI_Lookup_BLL();

        public frmTHUHP()
        {
            InitializeComponent();

            this.Load += frmTHUHP_Load;
            gvTHUHP.FocusedRowChanged += gvTHUHP_FocusedRowChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnexit.Click += btnExit_Click;
        }

        private void frmTHUHP_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLookupMASV();
                LoadLookupMAHP();
                LoadGridThuHP();

                DisableEdit();

                if (gvTHUHP.RowCount > 0)
                {
                    gvTHUHP.FocusedRowHandle = 0;
                    BindCurrentRowToControls();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi load: " + ex.Message, "Lỗi");
            }
        }

        private void LoadLookupMASV()
        {
            var list = svLookupBLL.GetLookup();

            lueMASV.Properties.DataSource = list;
            lueMASV.Properties.DisplayMember = "HOTEN";
            lueMASV.Properties.ValueMember = "MASV";
            lueMASV.Properties.NullText = "-- Chọn SV --";

            lueMASV.Properties.Columns.Clear();
            lueMASV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MASV", "Mã SV"));
            lueMASV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HOTEN", "Họ tên"));
            lueMASV.Properties.ShowHeader = true;
            lueMASV.Properties.DropDownRows = 10;
        }

        private void LoadLookupMAHP()
        {
            var list = hpLookupBLL.GetLookup();

            lueMAHP.Properties.DataSource = list;
            lueMAHP.Properties.DisplayMember = "KYHP";
            lueMAHP.Properties.ValueMember = "MAHP";
            lueMAHP.Properties.NullText = "-- Chọn kỳ HP --";

            lueMAHP.Properties.Columns.Clear();
            lueMAHP.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MAHP", "Mã HP"));
            lueMAHP.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KYHP", "Kỳ học phí"));
            lueMAHP.Properties.ShowHeader = true;
            lueMAHP.Properties.DropDownRows = 10;
        }

        private void LoadGridThuHP()
        {
            var data = thuhpBLL.GetListThuHP();

            gcTHUHP.DataSource = null;
            gcTHUHP.DataSource = data;

            gvTHUHP.Columns.Clear();
            gvTHUHP.PopulateColumns();

            gcTHUHP.RefreshDataSource();
            gvTHUHP.BestFitColumns();
        }

        private void gvTHUHP_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvTHUHP.FocusedRowHandle < 0) return;
            BindCurrentRowToControls();
        }

        private void BindCurrentRowToControls()
        {
            var masv = gvTHUHP.GetFocusedRowCellValue("MASV");
            lueMASV.EditValue = (masv == null || masv == DBNull.Value) ? null : masv.ToString();

            var mahp = gvTHUHP.GetFocusedRowCellValue("MAHP");
            lueMAHP.EditValue = (mahp == null || mahp == DBNull.Value) ? null : mahp.ToString();

            var ngayqd = gvTHUHP.GetFocusedRowCellValue("NGAYQD");
            deNGAYQD.EditValue = (ngayqd == null || ngayqd == DBNull.Value) ? null : ngayqd;

            var ngaythu = gvTHUHP.GetFocusedRowCellValue("NGAYTHU");
            deNGAYTHU.EditValue = (ngaythu == null || ngaythu == DBNull.Value) ? null : ngaythu;

            var sotien = gvTHUHP.GetFocusedRowCellValue("SOTIEN");
            txtSOTIEN.Text = (sotien == null || sotien == DBNull.Value) ? "" : sotien.ToString();
        }

        // ===== ADD NEW =====
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearFields();
            EnableEdit();

            // Add mới: cho chọn PK kép
            lueMASV.Enabled = true;
            lueMAHP.Enabled = true;

            lueMASV.Focus();
        }

        // ===== UPDATE =====
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lueMASV.EditValue == null || lueMAHP.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            isAdding = false;
            EnableEdit();

            // Update: KHÔNG cho đổi PK kép
            lueMASV.Enabled = false;
            lueMAHP.Enabled = false;
        }

        // ===== DELETE =====
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lueMASV.EditValue == null || lueMAHP.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (XtraMessageBox.Show("Bạn có chắc muốn xóa dòng thu học phí này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    thuhpBLL.Delete(lueMASV.EditValue.ToString(), lueMAHP.EditValue.ToString());

                    LoadGridThuHP();
                    DisableEdit();

                    if (gvTHUHP.RowCount > 0)
                    {
                        gvTHUHP.FocusedRowHandle = 0;
                        BindCurrentRowToControls();
                    }
                    else ClearFields();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // ===== SAVE =====
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var item = new THUHP
            {
                MASV = lueMASV.EditValue.ToString(),
                MAHP = lueMAHP.EditValue.ToString(),
                NGAYQD = deNGAYQD.DateTime,
                NGAYTHU = deNGAYTHU.DateTime,
                SOTIEN = int.Parse(txtSOTIEN.Text.Trim())
            };

            try
            {
                if (isAdding) thuhpBLL.Insert(item);
                else thuhpBLL.Update(item);

                LoadGridThuHP();
                DisableEdit();

                // Focus lại theo MASV (đủ dùng)
                int handle = gvTHUHP.LocateByValue("MASV", item.MASV);
                gvTHUHP.FocusedRowHandle = (handle >= 0) ? handle : 0;
                BindCurrentRowToControls();
            }
            catch (Exception ex)
            {
                // Lỗi hay gặp: trùng PK kép hoặc sai FK
                XtraMessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableEdit();
            if (gvTHUHP.FocusedRowHandle >= 0) BindCurrentRowToControls();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc muốn thoát?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ClearFields()
        {
            lueMASV.EditValue = null;
            lueMAHP.EditValue = null;
            deNGAYQD.EditValue = null;
            deNGAYTHU.EditValue = null;
            txtSOTIEN.Text = "";
        }

        private void EnableEdit()
        {
            // Cho phép nhập
            deNGAYQD.Enabled = true;
            deNGAYTHU.Enabled = true;
            txtSOTIEN.Enabled = true;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            btnAddNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void DisableEdit()
        {
            // Mặc định khóa hết
            lueMASV.Enabled = false;
            lueMAHP.Enabled = false;

            deNGAYQD.Enabled = false;
            deNGAYTHU.Enabled = false;
            txtSOTIEN.Enabled = false;

            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            btnAddNew.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private bool ValidateInput()
        {
            if (lueMASV.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn Sinh viên!");
                return false;
            }
            if (lueMAHP.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn Kỳ học phí!");
                return false;
            }
            if (deNGAYQD.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn Ngày quyết định!");
                return false;
            }
            if (deNGAYTHU.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn Ngày thu!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSOTIEN.Text) || !int.TryParse(txtSOTIEN.Text.Trim(), out _))
            {
                XtraMessageBox.Show("Số tiền phải là số!");
                txtSOTIEN.Focus();
                return false;
            }
            return true;
        }

        
    }
}
