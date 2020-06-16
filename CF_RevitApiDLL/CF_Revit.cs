using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows.Media.Imaging;
using System.Windows.Forms;

namespace ExeWriter
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class CF_RevitDLL : IExternalApplication
    {
        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel rvtRibbonPanel  = application.CreateRibbonPanel("CadFaster, Inc.");
            PulldownButtonData data = new PulldownButtonData("Options", "CadFaster, Inc.");
            string ExecutingAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            RibbonItem item = rvtRibbonPanel .AddItem(data);
            PulldownButton optionsBtn = item as PulldownButton;
            optionsBtn.AddPushButton(new PushButtonData("ExeWriter", "ExeWriter",
            ExecutingAssemblyPath, "ExeWriter.Cl_Exewriter"));

            //PushButton pushButton = ribbonPanel.AddPushButton("ExeWrite", "ExeWrite",
            //@"G:\Projects\reload_addin\RevitPlugin\Bridge\bin\Debug\Bridge.dll", "rev.Bridge");

            Uri uriImageMain = new Uri(@"C:\CadFaster\Revit\Images\Company.gif");
            BitmapImage largeImageMain = new BitmapImage(uriImageMain);
            optionsBtn.LargeImage = largeImageMain;

            return Autodesk.Revit.UI.Result.Succeeded;
        }

        public Autodesk.Revit.UI.Result OnShutdown(UIControlledApplication application)
        {
            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}
