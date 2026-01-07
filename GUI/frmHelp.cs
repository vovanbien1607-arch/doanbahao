using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class frmHelp : XtraForm
    {
        private readonly Dictionary<string, string> _content = new Dictionary<string, string>();

        public frmHelp(string openKey = "gioithieu")
        {
            InitializeComponent();
            InitContent();
            InitTree();

            // mở đúng mục theo ngữ cảnh
            SelectTopic(openKey);
        }

        private void InitTree()
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(new TreeNode("Giới thiệu") { Name = "gioithieu" });

            var ht = new TreeNode("Hệ thống") { Name = "hethong" };
            ht.Nodes.Add(new TreeNode("Đăng nhập") { Name = "dangnhap" });
            ht.Nodes.Add(new TreeNode("Đăng ký") { Name = "dangky" });
            ht.Nodes.Add(new TreeNode("Đăng xuất") { Name = "dangxuat" });
            treeView1.Nodes.Add(ht);

            var dm = new TreeNode("Danh mục") { Name = "danhmuc" };
            dm.Nodes.Add(new TreeNode("Hệ đào tạo (HEDT)") { Name = "hedt" });
            dm.Nodes.Add(new TreeNode("Danh sách lớp (DSLOP)") { Name = "dslop" });
            dm.Nodes.Add(new TreeNode("Danh sách sinh viên (DSSV)") { Name = "dssv" });
            dm.Nodes.Add(new TreeNode("Thu học phí (THUHP)") { Name = "thuhp" });
            treeView1.Nodes.Add(dm);

            var rp = new TreeNode("Báo cáo") { Name = "report" };
            rp.Nodes.Add(new TreeNode("Phiếu thu học phí") { Name = "rpt_phieu" });
            rp.Nodes.Add(new TreeNode("SV còn nợ học phí") { Name = "rpt_no" });
            rp.Nodes.Add(new TreeNode("Tổng hợp doanh thu") { Name = "rpt_doanhthu" });
            treeView1.Nodes.Add(rp);

            treeView1.Nodes.Add(new TreeNode("Phím tắt") { Name = "phimtat" });
            treeView1.Nodes.Add(new TreeNode("Lỗi thường gặp") { Name = "loi" });

            treeView1.AfterSelect += (s, e) =>
            {
                var key = e.Node.Name;
                if (_content.ContainsKey(key))
                    richTextBox1.Text = _content[key];
            };

            treeView1.ExpandAll();
        }

        private void InitContent()
        {
            _content["gioithieu"] =
@"PHẦN MỀM QUẢN LÝ THU HỌC PHÍ
- Chức năng: Quản lý sinh viên, lớp, hệ đào tạo và thu học phí.
- Báo cáo: Phiếu thu, danh sách nợ, tổng hợp doanh thu.
- Phím F1: Mở trợ giúp theo màn hình hiện tại.";

            _content["dangnhap"] =
@"ĐĂNG NHẬP
1) Nhập tài khoản/mật khẩu.
2) Nhấn Đăng nhập.
3) Nếu đúng -> vào màn hình chính.";

            _content["dangky"] =
@"ĐĂNG KÝ
1) Nhập thông tin tài khoản mới.
2) Xác nhận mật khẩu.
3) Nhấn Đăng ký.";

            _content["dangxuat"] =
@"ĐĂNG XUẤT
- Trên Main chọn: Hệ thống -> Đăng xuất.
- Phần mềm sẽ đưa về màn hình đăng nhập.";

            _content["hedt"] =
@"HỆ ĐÀO TẠO (HEDT)
- Add new: nhập MAHE, TENHE, HPCB -> Save
- Update: chọn dòng -> Update -> sửa TENHE/HPCB -> Save
- Delete: chọn dòng -> Delete
Lưu ý: Không xóa được nếu đã có lớp (DSLOP) dùng MAHE.";

            _content["dslop"] =
@"DANH SÁCH LỚP (DSLOP)
- Add new: nhập MALO, TENLOP, chọn MAHE (LookUpEdit) -> Save
- Update: chọn dòng -> Update -> sửa TENLOP/MAHE -> Save
- Delete: chọn dòng -> Delete
Lưu ý: MAHE phải tồn tại trong HEDT.";

            _content["dssv"] =
@"DANH SÁCH SINH VIÊN (DSSV)
- Add new: nhập MASV, HOTEN, NGAYSINH, chọn MALO (LookUpEdit), chọn DIENUIT -> Save
- Update: chọn dòng -> Update -> sửa thông tin -> Save
- Delete: chọn dòng -> Delete
Lưu ý: MALO phải tồn tại trong DSLOP.";

            _content["thuhp"] =
@"THU HỌC PHÍ (THUHP)
- Add new: chọn MASV, MAHP, ngày QĐ, ngày thu, số tiền -> Save
- In phiếu: chọn dòng -> In Phiếu (truyền MASV, MAHP)
Lưu ý: THUHP khóa chính kép (MASV, MAHP) nên không được trùng.";

            _content["rpt_phieu"] =
@"BÁO CÁO: PHIẾU THU HỌC PHÍ
- Chọn sinh viên + học kỳ -> In phiếu.
- Report nhận tham số: pMASV, pMAHP.";

            _content["rpt_no"] =
@"BÁO CÁO: SINH VIÊN CÒN NỢ
- Logic: Nợ = HPCB - Số tiền đã đóng
- Group theo lớp, cuối report có tổng tiền nợ.";

            _content["rpt_doanhthu"] =
@"BÁO CÁO: TỔNG HỢP DOANH THU
- Group theo hệ đào tạo
- Sum doanh thu, Count SV đã đóng
- Có biểu đồ Pie theo hệ.";

            _content["phimtat"] =
@"PHÍM TẮT
- F1: mở Help theo màn hình hiện tại.
( Nếu muốn: Ctrl+N Add new, Ctrl+S Save )";

            _content["loi"] =
@"LỖI THƯỜNG GẶP
1) Lỗi lưu 'inner exception': thường do FK sai (MALO/MAHE không tồn tại) hoặc trùng PK.
2) Không thấy dữ liệu: kiểm tra connection string trong App.config.
3) Không in báo cáo: kiểm tra stored procedure / dataSource report / tham số.";
        }

        public void SelectTopic(string key)
        {
            foreach (TreeNode n in treeView1.Nodes)
            {
                var found = FindNode(n, key);
                if (found != null)
                {
                    treeView1.SelectedNode = found;
                    found.EnsureVisible();
                    return;
                }
            }
            // mặc định
            treeView1.SelectedNode = treeView1.Nodes[0];
        }

        private TreeNode FindNode(TreeNode root, string key)
        {
            if (root.Name == key) return root;
            foreach (TreeNode c in root.Nodes)
            {
                var f = FindNode(c, key);
                if (f != null) return f;
            }
            return null;
        }
    }
}
