using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmReportViewer : XtraForm
    {
        public frmReportViewer(XtraReport report, string title = "Báo cáo")
        {
            InitializeComponent();

            if (report == null)
                throw new ArgumentNullException(nameof(report));

            this.Text = title;

            // Gán report vào DocumentViewer
            documentViewer1.DocumentSource = report;

            // Tạo document (background để mượt hơn)
            report.CreateDocument(true);

            // === SỬA LỖI Ở ĐÂY: DocumentViewer không có ZoomMode ===
            // Thay vì dùng ZoomMode, dùng ExecCommand để set zoom
            documentViewer1.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToPageWidth);

            // Hoặc các lệnh zoom khác nếu muốn:
            // ZoomToPageWidth  : Fit theo chiều rộng trang
            // ZoomToWholePage  : Hiển thị toàn bộ 1 trang
            // ZoomToTwoPages   : Hiển thị 2 trang
            // Zoom, new object[] { 100 } : Zoom 100%
        }

        protected override void OnClosed(EventArgs e)
        {
            if (documentViewer1.DocumentSource is XtraReport report)
            {
                report.Dispose();
                documentViewer1.DocumentSource = null;
            }
            base.OnClosed(e);
        }
    }
}