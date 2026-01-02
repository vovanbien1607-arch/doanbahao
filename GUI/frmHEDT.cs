using System;
using System.Windows.Forms;
using BLL;
using DAL.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace GUI
{
    public partial class frmHEDT : XtraForm
    {
        private bool isAdding = false;
        private readonly HEDT_BLL heBLL = new HEDT_BLL();

        public frmHEDT()
        {
            InitializeComponent();

            // gắn event
            this.Load += frmHEDT_Load;
            gvHEDT.FocusedRowChanged += gvHEDT_FocusedRowChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnexit.Click += btnExit_Click;
        }

        private void frmHEDT_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
                DisableEdit();

                if (gvHEDT.RowCount > 0)
                {
                    gvHEDT.FocusedRowHandle = 0;
                    BindCurrentRowToControls();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi load: " + ex.Message, "Lỗi");
            }
        }

        private void LoadGrid()
        {
            var data = heBLL.GetAll();

            gcHEDT.DataSource = null;
            gcHEDT.DataSource = data;

            gvHEDT.Columns.Clear();
            gvHEDT.PopulateColumns();



            gvHEDT.BestFitColumns();
        }

        private void gvHEDT_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvHEDT.FocusedRowHandle < 0) return;
            BindCurrentRowToControls();
        }

        private void BindCurrentRowToControls()
        {
            txtMAHE.Text = gvHEDT.GetFocusedRowCellValue("MAHE")?.ToString() ?? "";
            txtTENHE.Text = gvHEDT.GetFocusedRowCellValue("TENHE")?.ToString() ?? "";

            var hpcb = gvHEDT.GetFocusedRowCellValue("HPCB");
            txtHPCB.Text = (hpcb == null || hpcb == DBNull.Value) ? "" : hpcb.ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearFields();
            EnableEdit();
            txtMAHE.Enabled = true;
            txtMAHE.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMAHE.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn hệ cần sửa!");
                return;
            }

            isAdding = false;
            EnableEdit();
            txtMAHE.Enabled = false; // không cho sửa MAHE
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMAHE.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn hệ cần xóa!");
                return;
            }

            if (XtraMessageBox.Show("Bạn có chắc muốn xóa hệ này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    heBLL.Delete(txtMAHE.Text.Trim());
                    LoadGrid();
                    DisableEdit();

                    if (gvHEDT.RowCount > 0)
                    {
                        gvHEDT.FocusedRowHandle = 0;
                        BindCurrentRowToControls();
                    }
                    else ClearFields();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var he = new HEDT
            {
                MAHE = txtMAHE.Text.Trim(),
                TENHE = txtTENHE.Text.Trim(),
                HPCB = int.Parse(txtHPCB.Text.Trim())
            };

            try
            {
                if (isAdding) heBLL.Insert(he);
                else heBLL.Update(he);

                LoadGrid();
                DisableEdit();

                int handle = gvHEDT.LocateByValue("MAHE", he.MAHE);
                gvHEDT.FocusedRowHandle = (handle >= 0) ? handle : 0;
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
            if (gvHEDT.RowCount > 0 && gvHEDT.FocusedRowHandle >= 0)
                BindCurrentRowToControls();
            else
                ClearFields();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn thoát không?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ClearFields()
        {
            txtMAHE.Text = "";
            txtTENHE.Text = "";
            txtHPCB.Text = "";
        }

        private void EnableEdit()
        {
            txtTENHE.Enabled = txtHPCB.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = true;

            btnAddNew.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
        }

        private void DisableEdit()
        {
            txtMAHE.Enabled = txtTENHE.Enabled = txtHPCB.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = false;

            btnAddNew.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMAHE.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập MAHE!");
                txtMAHE.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTENHE.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập TENHE!");
                txtTENHE.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHPCB.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập HPCB!");
                txtHPCB.Focus();
                return false;
            }

            if (!int.TryParse(txtHPCB.Text.Trim(), out int hpcb) || hpcb < 0)
            {
                XtraMessageBox.Show("HPCB phải là số nguyên >= 0!");
                txtHPCB.Focus();
                return false;
            }

            return true;
        }
    }
}
