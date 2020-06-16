using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;


namespace ExeWriter
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalCommand
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Cl_Exewriter : IExternalCommand
    {
        #region IExternalCommand Members Implementation
        private WriterUtils WriterUtils = new WriterUtils();
        #endregion IExternalCommand Members Implementation


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Retrieves the current active project.
                string ExecutingAssemblyPath = Assembly.GetExecutingAssembly().Location;
                string DllAssemblyPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Cl_Exewriter)).CodeBase);
                return WriterUtils.HandleData(commandData, ref message, elements);
            }
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
    }
}
