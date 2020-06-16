using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ExeWriter
{
    public partial class Frm_Progress : System.Windows.Forms.Form
    {
        private String ExportFileName;
        public Frm_Progress()
        {
            InitializeComponent();
        }
        public void StartProgressBar(int imaxValue)
        {
            ProBarElement.Value = 0;
            ProBarElement.Maximum = imaxValue;
        }
        public void AddValueProgressBar(int iValue)
        {
            try
            {
                ProBarElement.Value = iValue;
                this.LblProg.Text = String.Format("Progressing element: {0}/{1}", iValue, ProBarElement.Maximum);
                ProBarFace.Visible = false;
                ProBarData.Visible = false;
                ProBarObjects.Visible = false;
                this.LblFace.Visible = false;
                this.LblData.Visible = false;
                this.LblObjects.Visible = false;
                Refresh();
            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "AddValueProgressBar fails for Some Reason:" + Environment.NewLine + e.ToString(); ;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
            }
        }
        public void prosessProgressBar(string strFileName)
        {
            ExportFileName = strFileName;
            this.Text = "Data Progressing...->" + strFileName;


        }
        public void SetProBarFace(int iMaxValue)
        {
            ProBarFace.Value = 0;
            ProBarFace.Maximum = iMaxValue;
            ProBarFace.Visible = true;
            this.LblFace.Visible = true;
        }

        public void AddValueProBarFace(int iValue)
        {
            try
            {
                ProBarFace.Value = iValue;
                this.LblFace.Text = String.Format("Progressing faces: {0}/{1}", iValue, ProBarFace.Maximum);
                Refresh();
            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "AddValueProBarFace fails for Some Reason:" + Environment.NewLine + e.ToString(); ;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
            }
        }
        public void SetProBarData(int iMaxValue)
        {
            ProBarData.Value = 0;
            ProBarData.Maximum = iMaxValue;
            ProBarData.Visible = true;
            this.LblData.Visible = true;
        }

        public void AddValueProBarData(int iValue)
        {
            try
            {
                ProBarData.Value = iValue;
                this.LblData.Text = String.Format("Progressing Data: {0}/{1}", iValue, ProBarData.Maximum);
                Refresh();
            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "AddValueProBarData fails for Some Reason:" + Environment.NewLine + e.ToString(); ;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
            }
        }
        public void SetProBarObjects(int iMaxValue)
        {
            ProBarObjects.Value = 0;
            ProBarObjects.Maximum = iMaxValue;
            ProBarObjects.Visible = true;
            this.LblObjects.Visible = true;
        }

        public void AddValueProBarObjects(int iValue)
        {
            try
            {
                ProBarObjects.Value = iValue;
                this.LblObjects.Text = String.Format("Progressing Objects: {0}/{1}", iValue, ProBarObjects.Maximum);
                Refresh();
            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "AddValueProBarObjects fails for Some Reason:" + Environment.NewLine + e.ToString(); ;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
            }
        }
 
    }
}
