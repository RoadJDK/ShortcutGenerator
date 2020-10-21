using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using WSShell = IWshRuntimeLibrary.WshShell;
using WSShortcut = IWshRuntimeLibrary.IWshShortcut;

namespace ShortcutGenerator
{
    public partial class Form1 : Form
    {

        String linkName;
        String iconPath;
        bool checkbox;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void ckbxIcon_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbxIcon.Checked)
            {
                openFileDialog1.ShowDialog();
                iconPath = openFileDialog1.FileName;
                checkbox = true;
            }
            else
            {
                checkbox = true;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            linkName = txtInputName.Text;
            createShortcut(linkName, iconPath);
        }

        private void createShortcut(String link, String path)
        {
            string LNKF = System.Environment.GetFolderPath

            (System.Environment.SpecialFolder.DesktopDirectory)
            + "\\" + link + ".lnk";

            WSShell wsho = new WSShell();
            WSShortcut sc = (WSShortcut)wsho.CreateShortcut(LNKF);

            sc.TargetPath = txtInputShortcut.Text;
            sc.Description = Application.ProductName + " ausführen";
            sc.WorkingDirectory = Application.ProductName;
            if (checkbox == true)
            {
                sc.IconLocation = iconPath;
            }

            sc.Save();
        }

    }
}
