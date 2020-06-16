using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.IO;

namespace ExeWriter
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    class CF_RevitBridge : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData _commandData, ref string _message, ElementSet _elements)
        {
            try
            {
                // calls the class that does the actual reflection logic. pass in the data
                //  that revit provided.
                invokeProcess(_commandData, ref _message, _elements);              
            }
            catch (Exception e)
            {
                _message = e.Message;
                return Autodesk.Revit.UI.Result.Failed;
            }

            return Autodesk.Revit.UI.Result.Succeeded;
        }

        /// <summary>
        /// start the reflection process by looking up classes and methods of the loaded DLL
        /// </summary>        
        public static void invokeProcess(ExternalCommandData _commandData, ref string _message, ElementSet _elements)
        {
            // load the assembly into a byte array. this way it WON'T lock the dll to disk
            byte[] assemblyBytes = File.ReadAllBytes(@"C:\CadFaster\Revit\CF_WriterDLL.dll");

            Assembly assembly = Assembly.Load(assemblyBytes);
            
            // Walk through each type in the assembly
            foreach (Type type in assembly.GetTypes())
            {
                // Pick up a class
                if (type.IsClass == true)
                {
                    // If it does not implement the IRevit Interface, skip it
                    if (type.GetInterface("ExeWriter.IRevit") == null)
                    {
                        continue;
                    }

                    // If however, it does implement the IRevit Interface,
                    // create an instance of the object
                    object ibaseObject = Activator.CreateInstance(type);

                    // Create the parameter list of vars that were passed into us from 
                    //  the calling class.   
                    object[] arguments = new object[] { _commandData, _message, _elements};
                    object result;
                    
                    // Dynamically Invoke the Object from the DLL                  
                    result = type.InvokeMember("execute",
                                                BindingFlags.Default | BindingFlags.InvokeMethod,
                                                null,
                                                ibaseObject,
                                                arguments);

                }
            }
        }
    }
}
