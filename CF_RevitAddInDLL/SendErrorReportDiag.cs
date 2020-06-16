using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Configuration;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using System.Diagnostics;
using System.Net;
using System.Net.Configuration;
using System.Configuration;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace SolidworksAddin
{
    

    public partial class SendErrorReportDiag : Form
    {
        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        public static extern int MAPISendMail(IntPtr lhSession, IntPtr ulUIParam,
        MapiMessage lpMessage, uint flFlags, uint ulReserved);

        public SendErrorReportDiag()
        {
            InitializeComponent();
        }

        private void dontSendButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void sendErrorButton_Click(object sender, EventArgs e)
        {
            this.SendErrorReport();
        }

        private void SendErrorReport()
        {
            try
            {
                // TODO: Add error handling for invalid arguments
                /*RegistryKey regKey;
                RegistryKey tempKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, "");
                string subkey = "Software\\CadFaster\\SolidWorksAddIn\\Settings";
                regKey = tempKey.OpenSubKey(subkey);
                Object pathName = regKey.GetValue("PathName");
                string path = (string)pathName;*/
                String path = AddinUtils.GetApplicationPath();
                string[] filenames = new string[2];
                filenames[0] = path + "\\error.log";
                filenames[1] = path+ "\\dump.dmp";
                EmailController.SendMail(filenames, "CadFaster Translator for SolidWorks has been crashed", "support@cadfaster.com");



                //smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Dispose();
            }

        }
    }
}
