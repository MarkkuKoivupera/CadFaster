using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk
{
    namespace Revit
    {
        namespace Attributes
        {
            public enum TransactionMode
            {
                Automatic = 0,
                Manual = 1,
                ReadOnly = 2,
            }

            public class TransactionAttribute : Attribute
            {
                public TransactionAttribute(TransactionMode mode){}

                //public TransactionMode Mode { get; }
            }
            public enum RegenerationOption
            {
                Manual = 0,
                //[Obsolete("Use of RegenerationOpton.Automatic is deprecated and will be removed in a future release. Autodesk recommends converting all Revit API code to use the RegenerationOption.Manual option.")]
                //Automatic = 1,
            }

            public class RegenerationAttribute : Attribute
            {
                public RegenerationAttribute(RegenerationOption option) { }

                //public RegenerationOption Option { get; }
            }

        }
    }
}
