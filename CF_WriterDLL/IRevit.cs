using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace ExeWriter
{
    interface IRevit
    {
        // signature that uses Revit vars
        //void execute(ExternalCommandData commandData, ref string message, ElementSet elements);
        void execute(String message);
    }
}
