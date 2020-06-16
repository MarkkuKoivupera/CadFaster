using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

using System.Reflection;
using Autodesk.Revit;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;



namespace ExeWriter
{

    class WriterUtils
    {
         
        
        public Result HandleData(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Retrieves the current active project.
                Autodesk.Revit.UI.UIApplication app = commandData.Application;
                UIDocument doc = app.ActiveUIDocument;

                //revitApp = app
                Autodesk.Revit.DB.View view = commandData.View;
                String ApplicationName = doc.Document.Title;
                String WievName = view.Document.Title;
                //Initialize RenderAppearancesForm
                CF_WriterForm form = new CF_WriterForm();
                form.ExportFileName = ApplicationName;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return Autodesk.Revit.UI.Result.Cancelled;
                }
                String ExportFileName;

                ExportFileName = form.ExportFileName;
                // Generate a object for Revit materials management.
                //MaterialsMgr materialsManager = new MaterialsMgr(doc, app);
                progressing fr_Progress = new progressing();
                // Feed a MaterialsMgr to a dialog
                fr_Progress.prosessProgressBar(ExportFileName);
                //fr_status.Close();
                // Revit need to do nothing.
                return Autodesk.Revit.UI.Result.Succeeded;

            }//try
            catch (Exception e)
            {
                // Exception rised, report it by revit error reporting mechanism. 
                message = "Execute fails for Reason:" + Environment.NewLine;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                message = e.ToString();
                //File.AppendAllText(@"C:\CadFaster\Revit\CF_WriterDLLs_log.txt", message);
                return Autodesk.Revit.UI.Result.Failed;
            }
        }
 

    //Class
    }
    //namebase
}
