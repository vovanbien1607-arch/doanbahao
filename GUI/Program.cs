using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SkinManager.EnableFormSkins();

            //// Chọn skin (đổi tên theo ý bạn)
            //  SkinManager.EnableFormSkins();

            //// Chọn skin (đổi tên theo ý bạn)
            //UserLookAndFeel.Default.SetSkinStyle("Windows 7");
            //Application.Run(new frmDSLOP());
            //Application.Run(new RibbonFormMain());
            Application.Run(new FluentDesignForm_Main());
           // Application.Run(new frmHelp());

        }
    }
}
