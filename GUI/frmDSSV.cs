using System;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DAL.Model;

namespace GUI
{
    public partial class frmDSSV : XtraForm
    {
        private bool isAdding = false;
        private readonly DSSV_BLL svBLL = new DSSV_BLL();

        public frmDSSV()
        {
            InitializeComponent();

            // Gắn sự kiện
            this.Load += frmDSSV_Load;
            gvDSSV.FocusedRowChanged += gvDSSV_FocusedRowChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

        }

        private void frmDSSV_Load(object sender, EventArgs e)
        {
            try
            {
                // Combo DIENUIT
                cboDIENUIT.Properties.Items.Clear();
                cboDIENUIT.Properties.Items.AddRange(new object[] { "CÓ", "KHÔNG" });
                cboDIENUIT.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                LoadGridDSSV();
                DisableEdit();

                // Focus dòng đầu
                if (gvDSSV.RowCount > 0)
                {
                    gvDSSV.FocusedRowHandle = 0;
                    BindCurrentRowToControls();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void LoadGridDSSV()
        {
            var data = svBLL.GetListStaff();   // dữ liệu join (có thể có TENLOP, TENHE...)

            gcDSSV.DataSource = null;
            gcDSSV.DataSource = data;

            gvDSSV.Columns.Clear();
            gvDSSV.PopulateColumns();

            gcDSSV.RefreshDataSource();
            gvDSSV.BestFitColumns();
        }

        private void gvDSSV_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvDSSV.FocusedRowHandle < 0) return;
            BindCurrentRowToControls();
        }

        private void BindCurrentRowToControls()
        {
            txtMASV.Text = gvDSSV.GetFocusedRowCellValue("MASV")?.ToString() ?? "";
            txtHOTEN.Text = gvDSSV.GetFocusedRowCellValue("HOTEN")?.ToString() ?? "";

            var ngaySinh = gvDSSV.GetFocusedRowCellValue("NGAYSINH");
            deNGAYSINH.EditValue = (ngaySinh == null || ngaySinh == DBNull.Value) ? null : ngaySinh;

            var malo = gvDSSV.GetFocusedRowCellValue("MALO");
            txtMaLop.Text = (malo == null || malo == DBNull.Value) ? "" : malo.ToString();

            var dienut = gvDSSV.GetFocusedRowCellValue("DIENUIT");
            cboDIENUIT.EditValue = (dienut == null || dienut == DBNull.Value) ? null : dienut.ToString();
        }

        // ===================== BUTTONS =====================

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            isAdding = true;

            ClearFields();
            EnableEdit();

            txtMASV.Enabled = true;     // cho nhập mã mới
            txtMASV.Focus();

            // Để tránh grid đổi dòng làm mất trạng thái add new
            gvDSSV.Focus();
            txtMASV.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMASV.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                return;
            }

            isAdding = false;
            EnableEdit();

            txtMASV.Enabled = false; // không cho sửa MASV
            txtHOTEN.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMASV.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            if (XtraMessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                // Nếu BLL bạn đang static: DSSV_BLL.Delete(txtMASV.Text.Trim());
                svBLL.Delete(txtMASV.Text.Trim());

                LoadGridDSSV();
                DisableEdit();

                if (gvDSSV.RowCount > 0)
                {
                    gvDSSV.FocusedRowHandle = 0;
                    BindCurrentRowToControls();
                }
                else
                {
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Không xóa được! Có thể sinh viên đã phát sinh THUHP.\n\nChi tiết: " + ex.Message, "Lỗi");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var sv = new DSSV
            {
                MASV = txtMASV.Text.Trim(),
                HOTEN = txtHOTEN.Text.Trim(),
                NGAYSINH = deNGAYSINH.DateTime,
                MALO = txtMaLop.Text.Trim(),
                DIENUIT = cboDIENUIT.EditValue?.ToString()
            };

            try
            {
                if (isAdding)
                {
                    // Nếu BLL bạn đang static: DSSV_BLL.Insert(sv);
                    svBLL.Insert(sv);
                    XtraMessageBox.Show("Thêm sinh viên thành công!");
                }
                else
                {
                    // Nếu BLL bạn đang static: DSSV_BLL.Update(sv);
                    svBLL.Update(sv);
                    XtraMessageBox.Show("Cập nhật thành công!");
                }

                LoadGridDSSV();
                DisableEdit();

                // focus lại đúng dòng vừa lưu
                int handle = gvDSSV.LocateByValue("MASV", sv.MASV);
                gvDSSV.FocusedRowHandle = (handle >= 0) ? handle : 0;
                BindCurrentRowToControls();
            }
            catch (Exception ex)
            {
                // Lỗi add new hay gặp:
                // - MASV trùng (PK)
                // - MALO không tồn tại (FK DSLOP)
                // - NGAYSINH null/format
                XtraMessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableEdit();

            if (gvDSSV.RowCount > 0 && gvDSSV.FocusedRowHandle >= 0)
                BindCurrentRowToControls();
            else
                ClearFields();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var rs = DevExpress.XtraEditors.XtraMessageBox.Show(
         "Bạn có chắc muốn thoát chương trình không?",
         "Xác nhận thoát",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Question
          );

            if (rs == DialogResult.Yes)
            {
                this.Close();


            }
        }
        // ===================== UI STATE =====================

        private void ClearFields()
        {
            txtMASV.Text = "";
            txtHOTEN.Text = "";
            deNGAYSINH.EditValue = null;
            txtMaLop.Text = "";
            cboDIENUIT.EditValue = null;
        }

        private void EnableEdit()
        {
            // Mở nhập liệu
            txtMASV.Enabled = true; // AddNew cần, Update sẽ disable lại
            txtHOTEN.Enabled = true;
            deNGAYSINH.Enabled = true;
            txtMaLop.Enabled = true;
            cboDIENUIT.Enabled = true;

            // Nút
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            btnAddNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void DisableEdit()
        {
            // Khóa nhập liệu
            txtMASV.Enabled = false;
            txtHOTEN.Enabled = false;
            deNGAYSINH.Enabled = false;
            txtMaLop.Enabled = false;
            cboDIENUIT.Enabled = false;

            // Nút
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            btnAddNew.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            isAdding = false;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMASV.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập mã sinh viên!");
                txtMASV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHOTEN.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập họ tên!");
                txtHOTEN.Focus();
                return false;
            }

            if (deNGAYSINH.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn ngày sinh!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập Mã Lớp!");
                txtMaLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboDIENUIT.EditValue?.ToString()))
            {
                XtraMessageBox.Show("Vui lòng chọn diện ưu tiên!");
                return false;
            }

            // Bắt buộc chỉ cho CÓ/KHÔNG
            var d = cboDIENUIT.EditValue?.ToString();
            if (d != "CÓ" && d != "KHÔNG")
            {
                XtraMessageBox.Show("Diện ưu tiên chỉ được chọn: CÓ hoặc KHÔNG!");
                cboDIENUIT.Focus();
                return false;
            }

            return true;
        }

       
    }
}