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

       
        private SqlConnection conn = null;
        private readonly string ctrConn =
            @"server=(localdb)\MSSQLLocalDB;Database=QuanLyThuHocPhi;Integrated Security=true";

        private RepositoryItemLookUpEdit repoKyHP = null;

        public frmDSSV()
        {
            InitializeComponent();

            conn = new SqlConnection(ctrConn);

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
                cboDIENUIT.Properties.Items.Clear();
                cboDIENUIT.Properties.Items.AddRange(new object[] { "CÓ", "KHÔNG" });
                cboDIENUIT.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                LoadKyHocPhi_ToLookUpEdit();
                LoadGridDSSV();
                DisableEdit();

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

        private void LoadKyHocPhi_ToLookUpEdit()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand("SELECT MAHP, KYHP FROM HOCPHI ORDER BY MAHP", conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                lkpKyHP.Properties.DataSource = dt;
                lkpKyHP.Properties.DisplayMember = "KYHP";
                lkpKyHP.Properties.ValueMember = "MAHP";
                lkpKyHP.Properties.NullText = "Chọn học kỳ...";
                lkpKyHP.Properties.ShowHeader = false;
                lkpKyHP.Properties.PopulateColumns();
                lkpKyHP.Properties.Columns["MAHP"].Visible = false;
                lkpKyHP.EditValue = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi load học kỳ: " + ex.Message, "Lỗi");
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void LoadGridDSSV()
        {
            var data = svBLL.GetListStaff();
            gcDSSV.DataSource = null;
            gcDSSV.DataSource = data;
            gvDSSV.PopulateColumns();
            SetupKyHocPhi_LookUpEdit_ForGrid();
            gcDSSV.RefreshDataSource();
            gvDSSV.BestFitColumns();

            gvDSSV.OptionsBehavior.Editable = false;
           
        }

        private void SetupKyHocPhi_LookUpEdit_ForGrid()
        {
            if (gvDSSV.Columns["MAHP"] == null) return;

            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                if (repoKyHP == null)
                {
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("SELECT MAHP, KYHP FROM HOCPHI ORDER BY MAHP", conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    repoKyHP = new RepositoryItemLookUpEdit
                    {
                        DataSource = dt,
                        DisplayMember = "KYHP",
                        ValueMember = "MAHP",
                        NullText = "",
                        ShowHeader = false
                    };
                    repoKyHP.PopulateColumns();
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
                if (conn.State == ConnectionState.Open) conn.Close();
            }
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

            var mahp = gvDSSV.GetFocusedRowCellValue("MAHP");
            lkpKyHP.EditValue = (mahp == null || mahp == DBNull.Value) ? null : mahp.ToString();
        }

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

            if (XtraMessageBox.Show("Bạn có chắc muốn xóa sinh viên này?\nTất cả dữ liệu thu học phí cũng sẽ bị xóa.", "Xác nhận",
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
                XtraMessageBox.Show("Không xóa được!\nChi tiết: " + ex.Message, "Lỗi");
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

            string selectedMAHP = lkpKyHP.EditValue?.ToString();

            try
            {
                if (isAdding)
                {
                    svBLL.Insert(sv, selectedMAHP);
                    XtraMessageBox.Show("Thêm sinh viên thành công!" +
                        (string.IsNullOrWhiteSpace(selectedMAHP) ? "" : "\nĐã tạo thu học phí cho kỳ được chọn."));
                }
                else
                {
                    svBLL.Update(sv, selectedMAHP);
                    XtraMessageBox.Show("Cập nhật thành công!" +
                        (string.IsNullOrWhiteSpace(selectedMAHP) ? "" : "\nĐã thêm kỳ học phí mới nếu chưa tồn tại."));
                }

                LoadGridDSSV();
                DisableEdit();

                int handle = gvDSSV.LocateByValue("MASV", sv.MASV);
                if (handle >= 0)
                {
                    gvDSSV.FocusedRowHandle = handle;
                    BindCurrentRowToControls();
                }
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

        private void ClearFields()
        {
            txtMASV.Text = "";
            txtHOTEN.Text = "";
            deNGAYSINH.EditValue = null;
            txtMaLop.Text = "";
            cboDIENUIT.EditValue = null;
            lkpKyHP.EditValue = null;
        }

        private void EnableEdit()
        {
            txtMASV.Enabled = true;
            txtHOTEN.Enabled = true;
            deNGAYSINH.Enabled = true;
            txtMaLop.Enabled = true;
            cboDIENUIT.Enabled = true;
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
                deNGAYSINH.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập mã lớp!");
                txtMaLop.Focus();
                return false;
            }

         

            return true;
        }
    }
}