using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace SolidworksAddin
{
    public partial class SubscriptionWizardDlg : Form
    {
        
        RegistrationController regController;
        public bool pressCancel = false;


        public SubscriptionWizardDlg(ref hsfwriter.interop.IHSFWriterImpl writer, ref RegistrationController rCont)
        {
            InitializeComponent();
           
            regController = rCont;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            pressCancel = true;
        }

        

        private void pinTextBox_TextChanged(object sender, EventArgs e)
        {
            if (pinTextBox.TextLength == 5)
            {
                if (regController.GetAndCheckKeys(pinTextBox.Text))
                {
                    this.okButton.Enabled = true;
                    this.SubsInfoTextBox.Text = "Licenced to: " + regController.mLicenseOwner + "\r\n" + regController.mTimeStamp;
                }
            }
            else
            {
                if (this.okButton.Enabled == true)
                    this.okButton.Enabled = false;
                if (this.SubsInfoTextBox.Text!="")
                    this.SubsInfoTextBox.Text="";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            regController.PutRegistrationKeysToRegistry();
            this.Dispose();
            MessageBox.Show("CadFaster|Translator for SolidWorks 2010 has now been activated");
        }

       
    }
}
