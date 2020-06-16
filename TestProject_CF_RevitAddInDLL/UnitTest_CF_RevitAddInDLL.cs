using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExeWriter
{
    [TestClass]
    public class UnitTest_CF_RevitAddInDLL
    {
        #region Outwriter
        [Priority(1), TestMethod]
        //public bool Init(string str_FileName)
        public void Test_001_Init()
        {
            ExeWriter.Outwriter Target = new ExeWriter.Outwriter();

            string str_FileName = null;
            bool bResult=Target.Init(str_FileName);
            Assert.IsFalse(bResult);
            str_FileName = "Test_Init";
            bResult = Target.Init(str_FileName);
            Assert.IsTrue(bResult);
            Assert.AreSame(Target.StrLogfile, str_FileName);
        }
        [Priority(2), TestMethod]
        //public bool addpart(String PartName, UInt32 U_FaceCount)
        public void Test_003_addpart()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        [Priority(3), TestMethod]
        //public bool addFaceRegion(String PartName, float[] Vertices, float[] Normals, float[] TextureCoords,uint[] Indices, uint[] Features)
        public void Test_005_addFaceRegion()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        [Priority(4), TestMethod]
        //public bool addComponent(String PartName, String componentId, double[] transformation,double[] componentMaterial, double[] featureMaterials, double[] textureMatrix)
        public void Test_007_addComponent()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        [Priority(6), TestMethod]
        //public bool placeholderExists(string str_FileName)
        public void Test_009_placeholderExists()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        [Priority(8), TestMethod]
        //public bool partExists(string str_FileName)
        public void Test_011_partExists()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        [Priority(9), TestMethod]
        //public bool addNode(String PartName, String ComName)
        public void Test_013_addNode()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        [Priority(7), TestMethod]
        //public bool CloseNode(String ComName)
        public void Test_015_CloseNode()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        [Priority(10), TestMethod]
        //public bool write(string str_FileName)
        public void Test_017_write()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        [Priority(11), TestMethod]
        //public bool writeExe(string str_FileName)
        public void Test_019_writeExe()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        #endregion

        #region CF_WriterForm

        [Priority(101), TestMethod]
        //public CF_WriterForm()
        public void Test_101_CF_WriterForm()
        {
            ExeWriter.CF_WriterForm Target = new ExeWriter.CF_WriterForm();
        }
        [Priority(102), TestMethod]
        //public DialogResult ShowSaveDialog(ref String ShowSaveDialog)
        public void Test_103_ShowSaveDialog()
        {
            ExeWriter.CF_WriterForm Target = new ExeWriter.CF_WriterForm();
            String ShowSaveDialog = "Show Dialog";
            System.Windows.Forms.DialogResult ShowSaveDialogresuly = Target.ShowSaveDialog(ref ShowSaveDialog);
            Assert.AreEqual(ShowSaveDialogresuly, System.Windows.Forms.DialogResult.OK);
        }
        #endregion

        #region Frm_Progress
        [Priority(201), TestMethod]
        //public Frm_Progress()
        public void Test_201_Frm_Progress()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            Assert.IsNotNull(Target);
        }
        [Priority(202), TestMethod]
        //public void prosessProgressBar(string strFileName)
        public void Test_203_prosessProgressBar()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            string strFileName = "Test";
            Target.prosessProgressBar(strFileName);
            string strNewText = Target.Text;
            strFileName = "Data Progressing...->" + strFileName;
            Assert.AreEqual(strNewText, strFileName);
        }
        [Priority(203), TestMethod]
        //public void SetProBarFamily(int iMaxValue)
        public void Test_205_SetProBarFamily()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.SetProBarFamily(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(204), TestMethod]
        //public void AddValueProBarFamily(int iValue,bool bScan)
        public void Test_207_AddValueProBarFamily()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.AddValueProBarFamily(iMaxValue, true);
            iMaxValue = 23;
            Target.AddValueProBarFamily(iMaxValue, false);
            Assert.IsNotNull(Target);
        }
        [Priority(205), TestMethod]
        //public void SetProBarSymbol(int iMaxValue)
        public void Test_209_SetProBarSymbol()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.SetProBarSymbol(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(206), TestMethod]
        //public void AddValueProBarSymbol(int iValue)
        public void Test_211_AddValueProBarSymbol()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.AddValueProBarSymbol(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(207), TestMethod]
        //public void SetProBarElement(int imaxValue)
        public void Test_213_SetProBarElement()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.SetProBarElement(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(208), TestMethod]
        //public void AddValueProBarElement(int iValue)
        public void Test_215_AddValueProBarElement()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.AddValueProBarElement(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(209), TestMethod]
        //public void SetProBarObjects(int iMaxValue)
        public void Test_217_SetProBarObjects()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.SetProBarObjects(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(210), TestMethod]
        //public void AddValueProBarObjects(int iValue)
        public void Test_219_AddValueProBarObjects()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.AddValueProBarObjects(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(211), TestMethod]
        //public void SetProBarInstance(int iMaxValue)
        public void Test_221_SetProBarInstance()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.SetProBarInstance(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(212), TestMethod]
        //public void AddValueProBarInstance(int iValue)
        public void Test_223_AddValueProBarInstance()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.AddValueProBarInstance(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(213), TestMethod]
        //public void SetProBarFace(int iMaxValue)
        public void Test_225_SetProBarFace()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.SetProBarFace(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(214), TestMethod]
        //public void AddValueProBarFace(int iValue)
        public void Test_227_AddValueProBarFace()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.AddValueProBarFace(iMaxValue);
            Assert.IsNotNull(Target);
        }
        [Priority(215), TestMethod]
        //public void SetProBarData(int iMaxValue)
        public void Test_229_SetProBarData()
        {
            ExeWriter.Frm_Progress Target = new ExeWriter.Frm_Progress();
            int iMaxValue = 100;
            Target.SetProBarData(iMaxValue);
            Assert.IsNotNull(Target);
        }
        #endregion

        #region CF_WriterUtils
        [Priority(301), TestMethod]
        //private void AddVertex(uint Start, XYZ Vertex, uint NextId)
        public void Test_301_AddVertex()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            uint Start=0;
            Autodesk.Revit.DB.XYZ Vertex=new Autodesk.Revit.DB.XYZ();
            
            uint NextId=0;
            Target.AddVertex(Start, Vertex, NextId);
            Assert.IsNotNull(Target);
        }
        [Priority(302), TestMethod]
        //private void AddFaceMaterial(Material materialElement, UIDocument doc)
        public void Test_303_AddFaceMaterial()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Autodesk.Revit.DB.Material materialElement = new Autodesk.Revit.DB.Material();
            Autodesk.Revit.UI.UIDocument doc = new Autodesk.Revit.UI.UIDocument();
            Target.AddFaceMaterial(materialElement, doc);
            Assert.IsNotNull(Target);
        }
        [Priority(320), TestMethod]
        // public Result HandleData(ExternalCommandData commandData, ref string message, ElementSet elements)
        public void Test_399_HandleData()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            string message = null;
            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            Autodesk.Revit.UI.Result ARUIResult = Target.HandleData(commandData, ref message, elements);
            Assert.IsNotNull(Target);
        }
        [Priority(315), TestMethod]
        //private void MakeConvertToHSF(UIApplication app, UIDocument doc)
        public void Test_381_MakeConvertToHSFr()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        [Priority(313), TestMethod]
        //private void HandleGeometryElement(GeometryElement GeomElem, ref  GeometryInstance instance, UIDocument doc, Material materialElement)
        public void Test_391_HandleGeometryElement()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        [Priority(304), TestMethod]
        //private void TextureCoord(Face geomFace)
        public void Test_303_TextureCoord()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        [Priority(308), TestMethod]
        //private XYZ NormVect(MeshTriangle triangle)
        public void Test_305_NormVect()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        [Priority(305), TestMethod]
        // private void MeshProcess(Mesh geomMesh)
        public void Test_307_MeshProcess()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        [Priority(306), TestMethod]
        //private void SolidProcess(Solid geomSolid, UIDocument doc, Material materialElement)
        public void Test_311_SolidProcess()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        [Priority(307), TestMethod]
        //private Double[] GetSystemArray(DoubleArray doubleArray)
        public void Test_309_GetSystemArray()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        [Priority(309), TestMethod]
        //private void SendFaceToWriter(Element element, GeometryInstance instance)
        public void Test_351_SendFaceToWriter()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        [Priority(311), TestMethod]
        //private void SendComponentToWriter(Element element, GeometryInstance instance)
        public void Test_361_SendComponentToWriter()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        [Priority(312), TestMethod]
        //private bool EndProsess()
        public void Test_365_EndProsess()
        {
            ExeWriter.CF_WriterUtils Target = new ExeWriter.CF_WriterUtils();
            Assert.IsNotNull(Target);
        }
        #endregion
        #region CF_RevitAddInDLL_Tests
        [Priority(401), TestMethod]
        //public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        public void Test_401_Execute()
        {
            ExeWriter.Cl_Exewriter Target = new ExeWriter.Cl_Exewriter();

            Autodesk.Revit.UI.ExternalCommandData commandData = new Autodesk.Revit.UI.ExternalCommandData();
            string message = null;
            Autodesk.Revit.UI.ElementSet elements = new Autodesk.Revit.UI.ElementSet();
            Autodesk.Revit.UI.Result ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Failed);
            ARUResult = Target.Execute(commandData, ref message, elements);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        #endregion
        #region CF_Revit_Tests
        [Priority(501), TestMethod]
        //public Autodesk.Revit.UI.Result OnShutdown(UIControlledApplication application)
        public void Test_501_OnShutdown()
        {
            ExeWriter.CF_RevitDLL Target = new ExeWriter.CF_RevitDLL();
            Autodesk.Revit.UI.UIControlledApplication application = new Autodesk.Revit.UI.UIControlledApplication();
            Autodesk.Revit.UI.Result ARUResult = Target.OnShutdown(application);
            Assert.AreEqual(ARUResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        [Priority(502), TestMethod]
        //public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        public void Test_503_OnStartup()
        {
            ExeWriter.CF_RevitDLL Target = new ExeWriter.CF_RevitDLL();
            Autodesk.Revit.UI.UIControlledApplication application = new Autodesk.Revit.UI.UIControlledApplication();
            Autodesk.Revit.UI.Result ARUIResult = Target.OnStartup(application);
            Assert.AreEqual(ARUIResult, Autodesk.Revit.UI.Result.Succeeded);
        }
        #endregion
    }
}
