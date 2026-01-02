using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class FluentDesignForm_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FluentDesignForm_Main()
        {
            InitializeComponent();
            // REMOVE THIS LINE: FluentDesignForm does not support standard MDI
            // this.IsMdiContainer = true; 
        }

        // 1. Updated isOpen to check the Container controls instead of MdiChildren
        private Form isOpen(Type ftype)
        {
            // Check inside the Fluent Container
            foreach (Control c in this.fluentDesignFormContainer1.Controls)
            {
                if (c.GetType() == ftype)
                {
                    return c as Form;
                }
            }
            return null;
        }

        // 2. Helper method to avoid repeating code
        private void OpenChildForm(Form f)
        {
            Form existing = isOpen(f.GetType());

            if (existing == null)
            {
                f.TopLevel = false;                  // Important: Allows form to be inside another
                f.FormBorderStyle = FormBorderStyle.None; // Remove border/title bar
                f.Dock = DockStyle.Fill;             // Fill the container

                this.fluentDesignFormContainer1.Controls.Add(f); // Add to container
                this.fluentDesignFormContainer1.Tag = f;         // Optional: Track active form

                f.Show();
                f.BringToFront();
            }
            else
            {
                existing.BringToFront();             // Bring existing form to view
                // existing.Activate() doesn't work well with embedded forms, use BringToFront
            }
        }

        private void aceThhp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTHUHP());
        }

        private void aceHedt_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHEDT());
        }

        private void aceDSL_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDSLOP());
        }

        private void aceDssv_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDSSV());
        }
    }
}