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
            documentViewer1.DocumentSource = report;
            report.CreateDocument(true);
            documentViewer1.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.ZoomToPageWidth);

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