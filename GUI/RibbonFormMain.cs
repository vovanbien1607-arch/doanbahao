using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class RibbonFormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        private Form isOpen(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }
        private void barButtonItemDSSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = isOpen(typeof(frmDSSV));
            if (frm == null)
            {
                frmDSSV f = new frmDSSV();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItemDSLOP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = isOpen(typeof(frmDSLOP));
            if (frm == null)
            {
                frmDSLOP f = new frmDSLOP();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItemHEDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = isOpen(typeof(frmHEDT));
            if (frm == null)
            {
                frmHEDT f = new frmHEDT();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }

        }

        private void barButtonItemTHUHP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = isOpen(typeof(frmTHUHP));
            if (frm == null)
            {
                frmTHUHP f = new frmTHUHP();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }

        }
    }
}