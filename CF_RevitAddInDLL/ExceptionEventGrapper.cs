using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.ExceptionServices;
using System.Diagnostics;

namespace SolidworksAddin
{
    public static class ExceptionEventGrapper
    {
        public static void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
        {
            
            //Debug.WriteLine(e.Exception.GetType().Name);
            if (e.Exception.GetType().Name != "UserAbortException") 
            {
                string path = AddinUtils.GetApplicationPath();
                string outputFileName = path + "\\dump.dmp"; //"c:\\projs\\dump.dmp";
                Utility.MiniDump.TryDump(outputFileName, Utility.MiniDumpType.Normal);
            }
        }

    }
}
