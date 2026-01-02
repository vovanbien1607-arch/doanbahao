using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using BLL;
using DAL.Model;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;

namespace GUI
{
    public partial class frmDSSV : XtraForm
    {
        private bool isAdding = false;
        private readonly DSSV_BLL svBLL = new DSSV_BLL();

        // ====== SQL Connection ======
        private SqlConnection conn = null;
        private readonly string ctrConn =
            @"server=(localdb)\MSSQLLocalDB;Database=QuanLyThuHocPhi;Integrated Security=true";

        // ====== Lookup repo for Grid (MAHP -> KYHP) ======
        private RepositoryItemLookUpEdit repoKyHP = null;

        public frmDSSV()
        {
            InitializeComponent();

            // ✅ Khởi tạo connection
            conn = new SqlConnection(ctrConn);

            // Events
            this.Load += frmDSSV_Load;
            gvDSSV.FocusedRowChanged += gvDSSV_FocusedRowChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        // ===================== FORM LOAD =====================
        private void frmDSSV_Load(object sender, EventArgs e)
        {
            try
            {
                // Combo DIENUIT (DevExpress ComboBoxEdit)
                cboDIENUIT.Properties.Items.Clear();
                cboDIENUIT.Properties.Items.AddRange(new object[] { "CÓ", "KHÔNG" });
                cboDIENUIT.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                // ✅ Load học kỳ vào LookUpEdit trên form
                LoadKyHocPhi_ToLookUpEdit();

                // Load Grid + setup lookup MAHP trong grid (nếu có cột MAHP)
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

        // ===================== LOAD LOOKUPEDIT HỌC KỲ (TRÊN FORM) =====================
        // Control LookUpEdit trên form phải tên: lkpKyHP
        // Nếu bạn đặt tên khác (vd: cboHocKi) thì đổi lại trong code.
        private void LoadKyHocPhi_ToLookUpEdit()
        {
            try
            {
                if (conn == null) conn = new SqlConnection(ctrConn);
                if (conn.State != ConnectionState.Open) conn.Open();

                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand("SELECT MAHP, KYHP FROM HOCPHI ORDER BY MAHP", conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                // ====== LookUpEdit trên form ======
                lkpKyHP.Properties.DataSource = dt;
                lkpKyHP.Properties.DisplayMember = "KYHP";
                lkpKyHP.Properties.ValueMember = "MAHP";
                lkpKyHP.Properties.NullText = "";
                lkpKyHP.Properties.ShowHeader = false;

                lkpKyHP.Properties.PopulateColumns();
                if (lkpKyHP.Properties.Columns["MAHP"] != null)
                    lkpKyHP.Properties.Columns["MAHP"].Visible = false;

                lkpKyHP.EditValue = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi load học kỳ: " + ex.Message, "Lỗi");
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // ===================== LOAD GRID =====================
        private void LoadGridDSSV()
        {
            var data = svBLL.GetListStaff();   // nếu join THUHP thì sẽ có MAHP, KYHP...

            gcDSSV.DataSource = null;
            gcDSSV.DataSource = data;

            gvDSSV.Columns.Clear();
            gvDSSV.PopulateColumns();

            // ✅ Nếu datasource có MAHP thì setup lookup cho cột MAHP trong grid
            SetupKyHocPhi_LookUpEdit_ForGrid();

            gcDSSV.RefreshDataSource();
            gvDSSV.BestFitColumns();
        }

        // ===================== LOOKUPEDIT HỌC KỲ TRONG GRID (CỘT MAHP) =====================
        private void SetupKyHocPhi_LookUpEdit_ForGrid()
        {
            // Nếu data không có cột MAHP thì bỏ qua (không lỗi)
            if (gvDSSV.Columns["MAHP"] == null) return;

            try
            {
                if (conn == null) conn = new SqlConnection(ctrConn);
                if (conn.State != ConnectionState.Open) conn.Open();

                // tạo repo 1 lần
                if (repoKyHP == null)
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("SELECT MAHP, KYHP FROM HOCPHI ORDER BY MAHP", conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    repoKyHP = new RepositoryItemLookUpEdit();
                    repoKyHP.DataSource = dt;
                    repoKyHP.DisplayMember = "KYHP";
                    repoKyHP.ValueMember = "MAHP";
                    repoKyHP.NullText = "";
                    repoKyHP.ShowHeader = false;

                    repoKyHP.PopulateColumns();
                    if (repoKyHP.Columns["MAHP"] != null)
                        repoKyHP.Columns["MAHP"].Visible = false;

                    gcDSSV.RepositoryItems.Add(repoKyHP);
                }

                gvDSSV.Columns["MAHP"].Caption = "Học kỳ";
                gvDSSV.Columns["MAHP"].ColumnEdit = repoKyHP;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi setup học kỳ trong grid: " + ex.Message, "Lỗi");
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // ===================== GRID EVENTS =====================
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

            // ✅ Bind Học kỳ lên LookUpEdit (lkpKyHP)
            var mahp = gvDSSV.GetFocusedRowCellValue("MAHP");
            lkpKyHP.EditValue = (mahp == null || mahp == DBNull.Value) ? null : mahp.ToString();
        }


        // ===================== BUTTONS =====================
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            isAdding = true;

            ClearFields();
            EnableEdit();

            txtMASV.Enabled = true;
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

            txtMASV.Enabled = false;
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
                    svBLL.Insert(sv);
                    XtraMessageBox.Show("Thêm sinh viên thành công!");
                }
                else
                {
                    svBLL.Update(sv);
                    XtraMessageBox.Show("Cập nhật thành công!");
                }

                LoadGridDSSV();
                DisableEdit();

                int handle = gvDSSV.LocateByValue("MASV", sv.MASV);
                gvDSSV.FocusedRowHandle = (handle >= 0) ? handle : 0;
                BindCurrentRowToControls();
            }
            catch (Exception ex)
            {
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
            var rs = XtraMessageBox.Show(
                "Bạn có chắc muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
                this.Close();
        }

        // ===================== UI STATE =====================
        private void ClearFields()
        {
            txtMASV.Text = "";
            txtHOTEN.Text = "";
            deNGAYSINH.EditValue = null;
            txtMaLop.Text = "";
            cboDIENUIT.EditValue = null;

            // học kỳ (trên form)
            lkpKyHP.EditValue = null;
        }

        private void EnableEdit()
        {
            txtMASV.Enabled = true;
            txtHOTEN.Enabled = true;
            deNGAYSINH.Enabled = true;
            txtMaLop.Enabled = true;
            cboDIENUIT.Enabled = true;

            // học kỳ (trên form) - nếu bạn muốn cho phép chọn để lọc/thu hp
            lkpKyHP.Enabled = true;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            btnAddNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void DisableEdit()
        {
            txtMASV.Enabled = false;
            txtHOTEN.Enabled = false;
            deNGAYSINH.Enabled = false;
            txtMaLop.Enabled = false;
            cboDIENUIT.Enabled = false;

            // học kỳ (trên form)
            lkpKyHP.Enabled = false;

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

            return true;
        }
    }
}
