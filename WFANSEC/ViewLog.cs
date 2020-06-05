using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFANSEC
{
    public partial class ViewLog : Form
    {
        public ViewLog()
        {
            InitializeComponent();
            pafap_files pf = new pafap_files();
            readLogFile(pafap_global.Init.logfile);
            
        }
        public void readLogFile(string fn)
        {
            StreamReader srf = new StreamReader(fn);
            try
            {
                txtlog.Text = srf.ReadToEnd();
                srf.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
