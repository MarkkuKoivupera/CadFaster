using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Autodesk.Revit.DB;
namespace ExeWriter
{
    public class CF_WriterForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // <summary>
        /// File Name or Prefix to be used
        /// </summary>
        protected String m_exportFileName;
        public String ExportFileName
        {
            get
            {
                return m_exportFileName;
            }
            set
            {
                m_exportFileName = value;
            }
        }  

        /// <summary>
        /// Directory to store the exported file
        /// </summary>
        protected String m_exportFolder;
        public String ExportFolder
        {
            get
            {
                return m_exportFolder;
            }
            set
            {
                m_exportFolder = value;
            }
        }

        protected String m_title;
    
        public String Title
        {
            get
            {
                return m_title;
            }
        }

        /// <summary>
        /// The filter which will be used in file saving dialog
        /// </summary>
        protected String m_filter;
        public String Filter
        {
            get
            {
                return m_filter;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }//Dispose()

        public CF_WriterForm()
        {
            InitializeComponent();

            // get in array form so we can call normal processing code.
            //ArrayList objs = new ArrayList();
            //objs.Add(obj);
            //CommonInit(objs);
        }//ElementsForm()
        //public CF_WriterForm(System.Object obj)
        //{
        //    InitializeComponent();

        //    // get in array form so we can call normal processing code.
        //    ArrayList objs = new ArrayList();
        //    objs.Add(obj);
        //    CommonInit(objs);
        //}//ElementsForm()

        //public CF_WriterForm(ArrayList objs)
        //{
        //    InitializeComponent();
        //    CommonInit(objs);
        //}//ElementsForm()

        //public CF_WriterForm(ElementSet elemSet)
        //{
        //    InitializeComponent();
        //    CommonInit(elemSet);
        //}//ElementsForm()

        //protected void CommonInit(IEnumerable objs)
        //{
        //    m_tvObjs.BeginUpdate();

        //    AddObjectsToTree(objs);

        //    // if the tree isn't well populated, expand it and select the first item
        //    // so its not a pain for the user when there is only one relevant item in the tree
        //    if (m_tvObjs.Nodes.Count == 1)
        //    {
        //        m_tvObjs.Nodes[0].Expand();
        //        if (m_tvObjs.Nodes[0].Nodes.Count == 0)
        //            m_tvObjs.SelectedNode = m_tvObjs.Nodes[0];
        //        else
        //            m_tvObjs.SelectedNode = m_tvObjs.Nodes[0].Nodes[0];
        //    }

        //    m_tvObjs.EndUpdate();
        //}//CommonInit()

        //protected void AddObjectsToTree(IEnumerable objs)
        //{
        //    m_tvObjs.Sorted = true;

        //    // initialize the tree control
        //    foreach (Object tmpObj in objs)
        //    {
        //        // hook this up to the correct spot in the tree based on the object's type
        //        TreeNode parentNode = GetExistingNodeForType(tmpObj.GetType());
        //        if (parentNode == null)
        //        {
        //            parentNode = new TreeNode(tmpObj.GetType().Name);
        //            m_tvObjs.Nodes.Add(parentNode);

        //            // record that we've seen this one
        //            m_treeTypeNodes.Add(parentNode);
        //            m_types.Add(tmpObj.GetType());
        //        }


        //        // add the new node for this element
        //        TreeNode tmpNode = new TreeNode(ObjToLabelStr(tmpObj));
        //        tmpNode.Tag = tmpObj;
        //        parentNode.Nodes.Add(tmpNode);
        //    }
        //}//AddObjectsToTree()

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonBrowser = new System.Windows.Forms.Button();
            this.labelSaveAs = new System.Windows.Forms.Label();
            this.textBoxSaveAs = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBrowser
            // 
            this.buttonBrowser.Location = new System.Drawing.Point(391, 36);
            this.buttonBrowser.Name = "buttonBrowser";
            this.buttonBrowser.Size = new System.Drawing.Size(24, 20);
            this.buttonBrowser.TabIndex = 3;
            this.buttonBrowser.Text = "...";
            this.buttonBrowser.UseVisualStyleBackColor = true;
            this.buttonBrowser.Click += new System.EventHandler(this.buttonBrowser_Click);
            // 
            // labelSaveAs
            // 
            this.labelSaveAs.AutoSize = true;
            this.labelSaveAs.Location = new System.Drawing.Point(21, 36);
            this.labelSaveAs.Name = "labelSaveAs";
            this.labelSaveAs.Size = new System.Drawing.Size(50, 13);
            this.labelSaveAs.TabIndex = 4;
            this.labelSaveAs.Text = "Save As:";
            // 
            // textBoxSaveAs
            // 
            this.textBoxSaveAs.Location = new System.Drawing.Point(77, 33);
            this.textBoxSaveAs.Name = "textBoxSaveAs";
            this.textBoxSaveAs.Size = new System.Drawing.Size(308, 20);
            this.textBoxSaveAs.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(297, 68);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 21);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(212, 68);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 21);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // CF_WriterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 189);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSaveAs);
            this.Controls.Add(this.labelSaveAs);
            this.Controls.Add(this.buttonBrowser);
            this.Name = "CF_WriterForm";
            this.Text = "Save As";
            this.Shown += new System.EventHandler(this.CF_WriterForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }//InitializeComponent()

        #endregion

        //protected System.Windows.Forms.TreeView m_tvObjs;
        protected ArrayList m_treeTypeNodes = new ArrayList();
        private SaveFileDialog saveFileDialog1;
        private Button buttonBrowser;
        private Label labelSaveAs;
        private TextBox textBoxSaveAs;
        private Button buttonCancel;
        private Button buttonSave;
        protected ArrayList m_types = new ArrayList();
       //protected TreeNode GetExistingNodeForType(System.Type objType)
        //{
        //    int len = m_types.Count;
        //    for (int i = 0; i < len; i++)
        //    {
        //        if ((System.Type)m_types[i] == objType)
        //            return (TreeNode)m_treeTypeNodes[i];
        //    }

        //    return null;
        //}//GetExistingNodeForType()

        //public static string ObjToLabelStr(System.Object obj)
        //{
        //    if (obj == null)
        //        return "< null >";

        //    Autodesk.Revit.DB.Element elem = obj as Autodesk.Revit.DB.Element;
        //    if (elem != null)
        //    {
        //        // TBD: Exceptions are thrown in certain cases when accessing the Name property. 
        //        // Eg. for the RoomTag object. So we will catch the exception and display the exception message
        //        // arj - 1/23/07
        //        try
        //        {
        //            string nameStr = (elem.Name == string.Empty) ? "???" : elem.Name;		// use "???" if no name is set
        //            return string.Format("< {0}  {1} >", nameStr, elem.Id.IntegerValue.ToString());
        //        }
        //        catch (System.InvalidOperationException ex)
        //        {
        //            return string.Format("< {0}  {1} >", null, ex.Message);
        //        }
        //    }
        //    return string.Format("< {0} >", obj.GetType().Name);
        //}//ObjToLabelStr()
        public static DialogResult ShowSaveDialog(ref String returnFileName,
            ref int filterIndex)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Give a record file";
                saveDialog.InitialDirectory = "";
                saveDialog.FileName = returnFileName;
                saveDialog.Filter = "rvt files (*.rvt)|*.rvt|All files (*.*)|*.*";
                saveDialog.FilterIndex = filterIndex;
                saveDialog.RestoreDirectory = true;

                DialogResult result = saveDialog.ShowDialog();
                if (result != DialogResult.Cancel)
                {
                    returnFileName = saveDialog.FileName;
                    filterIndex = saveDialog.FilterIndex;
                }

                return result;
            }
        //ShowSaveDialog()
        }

        private void buttonBrowser_Click(object sender, EventArgs e)
        {
            String fileName = String.Empty;
            int filterIndex = -1;

            DialogResult result = ShowSaveDialog(ref fileName, ref filterIndex);
            if (result != DialogResult.Cancel)
            {
                textBoxSaveAs.Text = fileName;
                ExportFileName=fileName;
            }
        //buttonBrowser_Click()
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ExportFileName = textBoxSaveAs.Text;
            //Close();
            //buttonSave_Click()
        }

        private void CF_WriterForm_Shown(object sender, EventArgs e)
        {
            String StrTemp = ExportFileName;
            StrTemp=StrTemp.Replace(".", "_");
            //ExportFileName
            textBoxSaveAs.Text = StrTemp;
            textBoxSaveAs.Focus();
        }
    }//ElementsForm
}//namespace ExeWriter
