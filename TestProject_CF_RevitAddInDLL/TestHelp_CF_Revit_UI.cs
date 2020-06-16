using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Autodesk
{
    namespace Windows
    {
        class RibbonButton
        {
        }
    }
    namespace Revit
    {
        namespace UI
        {
            
            public interface IExternalApplication
            {
            }
            public class RibbonPanel
            {

                public RibbonItem AddItem(RibbonItemData itemData) { return new RibbonItem(); }
            }
            public class UIControlledApplication
            {

                public virtual RibbonPanel CreateRibbonPanel(string panelName) { return new RibbonPanel(); }
            }
            public enum Result
            {
                Failed = -1,
                Succeeded = 0,
                Cancelled = 1,
            }
            public class RibbonItemData
            {
             }
            public class ButtonData : RibbonItemData
            {
            }
            public class PulldownButtonData : ButtonData
            {
                public PulldownButtonData(string name, string text) { }
            }
            public enum RibbonItemType
            {
                PushButton = 0,
                PulldownButton = 1,
                SplitButton = 2,
                ToggleButton = 3,
                RadioButtonGroup = 4,
                ComboBoxMember = 5,
                ComboBox = 6,
                TextBox = 7,
            }
            public class RibbonItem
            {
                protected RibbonItemType m_ItemType;
                public bool Enabled 
                {
                    get { return true; }
                    set { } 
                }
                public string ItemText
                { 
                    get { return "Ok"; }
                    set { }
                }
                public RibbonItemType ItemType
                {
                    get { return m_ItemType; }
                }
                public string LongDescription
                {
                    get { return "Ok"; }
                    set { }
                }
                public string Name 
                 {
                    get { return "Ok"; }
                    set { }
                }
               public string ToolTip
                 {
                     get { return "Ok"; }
                    set { }
                }
               public ImageSource ToolTipImage
               {
                    get { return null; }
                    set { }
                }
                public bool Visible 
                {
                    get { return true; }
                    set { }
                }

                //public override bool Equals(object obj) { return true; }
                //protected virtual void setItemText(string text) { }

             }
            public class RibbonButton : RibbonItem
            {
                public System.Windows.Media.ImageSource Image
                 {
                    get { return null; }
                    set{}
                }
               public System.Windows.Media.ImageSource LargeImage 
                {
                    get { return null; }
                    set{}
                }
            }
            public class PulldownButton : RibbonButton
            {
                public PushButton AddPushButton(PushButtonData buttonData) { return new PushButton(); }
                public void AddSeparator(){}

            }
            public class PushButtonData : ButtonData
            {
                public PushButtonData(string name, string text, string assemblyName, string className) { }

            }
            public class PushButton : RibbonButton
            {
            }
            public interface IExternalCommand
            {
                Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements);
            }
            public class ExternalCommandData : APIObject
            {
                public UIApplication Application { get { return new UIApplication(); } set { } }
                //public StringStringMap Data { get; set; }
                public Autodesk.Revit.DB.View View { get { return new Autodesk.Revit.DB.View(); } set { } }
            }
            public class APIObject 
            {
            //    public virtual bool IsReadOnly { get; }

                //public  void Dispose() {}
            //    protected virtual void Dispose(bool value);
            //    protected virtual void ReleaseManagedResources();
            //    protected virtual void ReleaseUnmanagedResources();
            }
            public class ElementSet : APIObject, IEnumerable
            {
                //public ElementSet();

                //public virtual bool IsEmpty { get; }
                //public virtual int Size { get; }

                //public virtual void Clear();
                //public virtual bool Contains(Element item);
                //protected override void Dispose(bool value);
                //public virtual int Erase(Element item);
                //public virtual ElementSetIterator ForwardIterator();
                public virtual IEnumerator GetEnumerator() {return null;}
                //public virtual bool Insert(Element item);
                //protected override void ReleaseUnmanagedResources();
                //public virtual ElementSetIterator ReverseIterator();
            }
            public class UIApplication 
            {
                //public UIApplication(Application pApplication);

                //public AddInId ActiveAddInId { get; }
                public virtual UIDocument ActiveUIDocument { get { return new UIDocument(); } }
                public Autodesk.Revit.ApplicationServices.Application Application { get{return new Autodesk.Revit.ApplicationServices.Application();} }
                //public virtual Rectangle DrawingAreaExtents { get; }
                //public virtual ExternalApplicationArray LoadedApplications { get; }
                //public virtual Rectangle MainWindowExtents { get; }

                //public event EventHandler<ApplicationClosingEventArgs> ApplicationClosing;
                //public event EventHandler<DialogBoxShowingEventArgs> DialogBoxShowing;
                //public event EventHandler<IdlingEventArgs> Idling;
                //public event EventHandler<ViewActivatedEventArgs> ViewActivated;
                //public event EventHandler<ViewActivatingEventArgs> ViewActivating;

                //public virtual RibbonPanel CreateRibbonPanel(string panelName);
                //public virtual RibbonPanel CreateRibbonPanel(Tab tab, string panelName);
                //public void Dispose() { }
                //protected virtual void Dispose(bool value){ }
                //public virtual List<RibbonPanel> GetRibbonPanels();
                //public List<RibbonPanel> GetRibbonPanels(Tab tab);
            }
            public class UIDocument 
            {
                //public UIDocument(Document pDocument);

                //public UIApplication Application { get; }
                public Autodesk.Revit.DB.Document Document { get { return new Autodesk.Revit.DB.Document(); } }
                //public Autodesk.Revit.UI.Selection.Selection Selection { get; }

                //public void Dispose(){ }
                //protected virtual void Dispose(bool value){ }
                //public void PromptForFamilyInstancePlacement(FamilySymbol familySymbol);
                //public void RefreshActiveView();
                //public void ShowElements(Element element);
                //public void ShowElements(ElementId elementId);
                //public void ShowElements(ElementSet elements);
                //public void ShowElements(ICollection<ElementId> elementIds);
            }

        }
    }
}
