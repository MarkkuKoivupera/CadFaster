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
    //[Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    //public class ExeWriter : IExternalCommand
    class ExeWriter : IRevit
    {
        #region IExternalCommand Members Implementation
        /// the operation.</returns>

        Outwriter writeData = new Outwriter();
        /*
        public void execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Retrieves the current active project.
                Autodesk.Revit.UI.UIApplication app = commandData.Application;
                UIDocument doc = app.ActiveUIDocument;
                
                //revitApp = app
                Autodesk.Revit.DB.View view  = commandData.View;
                String ApplicationName = doc.Document.Title;
                String WievName = view.Document.Title;
//Dim sMsg As String = "Application = " & app.VersionName & _
//" " & app.VersionNumber & vbCrLf
//sMsg += "Document path = " & doc.PathName & vbCrLf ' Empty if not saved
//sMsg += "Document title = " & doc.Title & vbCrLf
//sMsg += "View name = " & view.Name
//MsgBox(sMsg)
                //Initialize RenderAppearancesForm
                //RenderAppearancesFrom.Asssets = app.Application.get_Assets(Autodesk.Revit.Utility.AssetType.Appearance);

                // Generate a object for Revit materials management.
                //MaterialsMgr materialsManager = new MaterialsMgr(doc, app);

                // Feed a MaterialsMgr to a dialog.
                FilteredElementCollector collector = new FilteredElementCollector(doc.Document);
                ICollection<Element> founds = collector.WhereElementIsNotElementType().ToElements();

                ArrayList objs = new ArrayList();
                Autodesk.Revit.DB.GeometryElement GeomElem;
                Autodesk.Revit.DB.Options Opts= new Options();
                //writeData.Init(ref message);
                foreach (Element element in founds)
                {
                    Autodesk.Revit.DB.Phase phaseCreated = element.PhaseCreated;
                    if (null != phaseCreated)

                    {
                        GeomElem = element.get_Geometry(Opts);
                        foreach (GeometryObject geomObj in GeomElem.Objects)
                        {
                            uint ifaces = 0;
                            Solid geomSolid = geomObj as Solid;
                            if (null != geomSolid)
                            {
                                foreach (Face geomFace in geomSolid.Faces)
                                {
                                    ifaces++;
                                }
                                //writeData.addpart(element.Name.ToString(), ifaces);
                            }

                        }

                        objs.Add(element);
                    }                    

                }

                System.Diagnostics.Trace.WriteLine(founds.Count.ToString());
                CF_WriterForm form = new CF_WriterForm(objs);
                //form.ShowDialog();
                //using (MaterialsForm dlg = new MaterialsForm(materialsManager,commandData))
                //{
                form.ExportFileName = ApplicationName;
                if (form.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                    {
                        String ExportFileName = form.ExportFileName;
                        DataProcess(ref message);
                        // Revit need to do nothing.
                        //return Autodesk.Revit.UI.Result.Cancelled;
                    }
                    else
                    {
                        // Done some action, ask revit to execute it.
                        //return Autodesk.Revit.UI.Result.Succeeded;
                     }
                //}                
            }
            catch (Exception e)
            {
                // Exception rised, report it by revit error reporting mechanism. 
                message = e.ToString();
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }

        }
        private void DataProcess(ref string message)
        {
            try
            {
               writeData.SuoriraLoput(ref message);
            }
            catch (Exception e)
            {
                // Exception rised, report it by revit error reporting mechanism. 
                message = e.ToString();
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
        }
        */
        public void execute(string message)
        {
            try
            {
                writeData.SuoriraLoput(ref message);
            }
            catch (Exception e)
            {
                // Exception rised, report it by revit error reporting mechanism. 
                message = e.ToString();
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
        }

        //public static void invokeProcess(ref string message)
        //{
        //    // Initialize HSF Writer
        //    hsfwriter.IHSFWriterImpl writer = new hsfwriter.HSFWriterImpl();

        //    // Initialize data structures for the sample HSF file creation
        //    float[] vertices = { 0.0f, 0.0f, 0.0f, 10.0f, 0.0f, 0.0f, 10.0f, 10.0f, 0.0f, 0.0f, 10.0f, 0.0f, // Face1
        //                         0.0f, 0.0f, 10.0f, 10.0f, 0.0f, 10.0f, 10.0f, 10.0f, 10.0f, 0.0f, 10.0f, 10.0f // Face2
        //                       };
        //    float[] normals = { 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f,
        //                        0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f
        //                      };
        //    float[] texcoords = { 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, -1.0f,
        //                        0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, -1.0f
        //                        };
        //    uint[] indices = { 3, 0, 1, 2, 3, 2, 3, 0,
        //                       3, 4, 5, 6, 3, 6, 7, 4
        //                     };
        //    uint[] features = { 6, 6 };
        //    writer.addPart("SamplePart", 2);
        //    double[] transformation = {1.0, 0.0, 0.0, 0.0,
        //                               0.0, 1.0, 0.0, 0.0,
        //                               0.0, 0.0, 1.0, 0.0,
        //                               0.0, 0.0, -3.0, 1.0};
        //    double[] componentMaterial = { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0 }; // overrided by feature materials
        //    double[] featureMaterials = { 1.0, 0.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 0.0, 1.0, 1.0, 0.0, 0.0, 0.0,
        //                                 2.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 1.0, 1.0, 0.0, 0.0, 0.0};

        //    // Check that part placeholder exists in HSFWRITER (this is for demonstration purposes)
        //    int result = writer.placeholderExists("SamplePart");
        //    if (result != 0)
        //    {
        //        MessageBox.Show("Error while initializing part");
        //    }

        //    // Import geometry to the sample part (single triangle in this case
        //    writer.addFaceRegion("SamplePart", vertices, normals, texcoords, indices, 8, 16, features, 2);
        //    // Check that fully imported part exists in HSFWRITER (this is for demonstration purposes)
        //    result = writer.partExists("SamplePart");
        //    if (result != 0)
        //    {
        //        MessageBox.Show("Error while importing part's geometry part");
        //    }

        //    // Create a component (geometry instance) for SamplePart
        //    writer.addComponent("SamplePart", "SampleComponent", transformation, componentMaterial, featureMaterials, 2, "", transformation, 1);

        //    // Write imported data to a HSF file
        //    writer.write(@"C:\CadFaster\Revit\test.hsf", hsfwriter.TesselationDataType.Normal, 1, 0);

        //    // Create portable EXE from HSF data
        //    writer.writeExe(@"C:\CadFaster\Revit\quickstep_portable_directx.exe", @"C:\CadFaster\Revit\test.hsf", @"C:\CadFaster\Revit\test.exe");
        //}

        //public static void invokeProcess(ref string message)
        //{
        //    // load the assembly into a byte array. this way it WON'T lock the dll to disk
        //    byte[] assemblyBytes = File.ReadAllBytes(@"C:\CadFaster\Revit\Writer.dll");

        //    Assembly assembly = Assembly.Load(assemblyBytes);

        //    // Walk through each type in the assembly
        //    foreach (Type type in assembly.GetTypes())
        //    {
        //        // Pick up a class
        //        if (type.IsClass == true)
        //        {
        //            // If it does not implement the IRevit Interface, skip it
        //            if (type.GetInterface("ExeWriter.IWriter") == null)
        //            {
        //                continue;
        //            }

        //            // If however, it does implement the IRevit Interface,
        //            // create an instance of the object
        //            object ibaseObject = Activator.CreateInstance(type);

        //            // Create the parameter list of vars that were passed into us from 
        //            //  the calling class.   
        //            bool test = true;
        //            object[] arguments = new object[] { test, message };
        //            object result;
        //            try
        //            {

        //                // Dynamically Invoke the Object from the DLL                  
        //                result = type.InvokeMember("execute",
        //                                            BindingFlags.Default | BindingFlags.InvokeMethod,
        //                                            null,
        //                                            ibaseObject,
        //                                            arguments);
        //            }
        //            catch (Exception e)
        //            {
        //                // Exception rised, report it by revit error reporting mechanism. 
        //                message = e.ToString();
        //                //return Autodesk.Revit.UI.Result.Failed;
        //            }

        //        }
        //    }
        //}        

        #endregion IExternalCommand Members Implementation
    }
}
