using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autodesk
{
    namespace Revit
    {
        namespace ApplicationServices
        {
            public class Application 
            {
                //public Application();

                //public CitySet Cities { get; }
                public Autodesk.Revit.Creation.Application Create { get {return new Autodesk.Revit.Creation.Application() ;} }
                //public virtual DocumentSet Documents { get; }
                //public string FamilyTemplatePath { get; }
                //public bool IsQuiescent { get; }
                //public LanguageType Language { get; }
                //public StringStringMap LibraryPaths { get; set; }
                //public ObjectFactory ObjectFactory { get; }
                //public ProductType Product { get; }
                //public string RecordingJournalFilename { get; }
                //public string SharedParametersFilename { get; set; }
                //public string VersionBuild { get; }
                //public string VersionName { get; }
                //public string VersionNumber { get; }

                //public event EventHandler<DocumentChangedEventArgs> DocumentChanged;
                //public event EventHandler<DocumentClosedEventArgs> DocumentClosed;
                //public event EventHandler<DocumentClosingEventArgs> DocumentClosing;
                //public event EventHandler<DocumentCreatedEventArgs> DocumentCreated;
                //public event EventHandler<DocumentCreatingEventArgs> DocumentCreating;
                //public event EventHandler<DocumentOpenedEventArgs> DocumentOpened;
                //public event EventHandler<DocumentOpeningEventArgs> DocumentOpening;
                //public event EventHandler<DocumentPrintedEventArgs> DocumentPrinted;
                //public event EventHandler<DocumentPrintingEventArgs> DocumentPrinting;
                //public event EventHandler<DocumentSavedEventArgs> DocumentSaved;
                //public event EventHandler<DocumentSavedAsEventArgs> DocumentSavedAs;
                //public event EventHandler<DocumentSavingEventArgs> DocumentSaving;
                //public event EventHandler<DocumentSavingAsEventArgs> DocumentSavingAs;
                //public event EventHandler<DocumentSynchronizedWithCentralEventArgs> DocumentSynchronizedWithCentral;
                //public event EventHandler<DocumentSynchronizingWithCentralEventArgs> DocumentSynchronizingWithCentral;
                //public event EventHandler<FailuresProcessingEventArgs> FailuresProcessing;
                //public event EventHandler<FileExportedEventArgs> FileExported;
                //public event EventHandler<FileExportingEventArgs> FileExporting;
                //public event EventHandler<FileImportedEventArgs> FileImported;
                //public event EventHandler<FileImportingEventArgs> FileImporting;
                //public event EventHandler<ViewPrintedEventArgs> ViewPrinted;
                //public event EventHandler<ViewPrintingEventArgs> ViewPrinting;

                //public override sealed void Dispose();
                //protected virtual void Dispose(bool value);
                //public void ExtractPartAtomFromFamilyFile(string familyFilePath, string xmlFilePath);
                //public AssetSet get_Assets(AssetType value);
                //public static FailureDefinitionRegistry GetFailureDefinitionRegistry();
                //protected RevitApplication* getNativeObject();
                //public virtual Autodesk.Revit.DB.Document NewFamilyDocument(string templateFileName);
                //public virtual Autodesk.Revit.DB.Document NewProjectDocument(string templateFileName);
                //public virtual Autodesk.Revit.DB.Document NewProjectTemplateDocument(string templateFilename);
                //public virtual Autodesk.Revit.DB.Document OpenDocumentFile(string fileName);
                //public DefinitionFile OpenSharedParameterFile();
                //public static void RegisterFailuresProcessor(IFailuresProcessor processor);
                //protected virtual void ReleaseUnmanagedResources(bool disposing);
                //public void WriteJournalComment(string comment, bool timeStamp);
            }
        }
    }
}