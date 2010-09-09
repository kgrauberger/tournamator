using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tournamator
{

    public partial class CurrentTournamentNameForm : Form
    {
        private string fileName;

        public CurrentTournamentNameForm()
        {
            InitializeComponent();
        }

        public string getFileName()
        {
            return fileName;
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            fileName = txtFileName.Text;

            if (fileName == "")
            {
                MessageBox.Show("File name cannot be blank");
                this.DialogResult = DialogResult.None;
            }
        }
    }

    
        
}
