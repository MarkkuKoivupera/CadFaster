using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hsfwriter
{
    public enum TesselationDataType { Normal, Strips }
    public class HSFWriterImpl : IHSFWriterImpl
    {
        public int partExists(String StrName)
        {
            if ("Ret_1" == StrName)
                return 1;
            else
                return 0;
        }

        public void addPart(String partId, uint featureCount)
        {
        }


        public void addComponent(String referencedPartId, String componentId, double[] transformation, double[] componentMaterial, double[] featureMaterials, uint featureMaterialCount, String imageId, double[] textureMatrix, int doubleSided)
        {
        }

        public void addFaceRegion(String referencedPartId, float[] vertices, float[] normals, float[] textureCoords, uint[] indices, uint vertexCount, uint indexCount, uint[] features, uint featureCount)
        {
        }

        public void write(String filename, TesselationDataType dataType, long textureQuality, int writeAscii)
        {
        }

        public void addImage(String imageId)
        {
        }

        public int placeholderExists(String StrName)
        {
            if ("Ret_1" == StrName)
                return 1;
            else
                return 0;
        }

        public void writeExe(String exeStubPath, String srcFileName, String dstFileName)
        {
        }

    }

    interface IHSFWriterImpl
    {

        int partExists(String partId);

        void addPart(String partId, uint featureCount);


        void addComponent(String referencedPartId, String componentId, double[] transformation, double[] componentMaterial, double[] featureMaterials, uint featureMaterialCount, String imageId, double[] textureMatrix, int doubleSided);

        void addFaceRegion(String referencedPartId, float[] vertices, float[] normals, float[] textureCoords, uint[] indices, uint vertexCount, uint indexCount, uint[] features, uint featureCount);

        void write(String filename, TesselationDataType dataType, long textureQuality, int writeAscii);

        void addImage(String imageId);

        int placeholderExists(String placeholderId);

        void writeExe(String exeStubPath, String srcFileName, String dstFileName);


    }
}

namespace ExeWriter
{
    [TestClass]
    public class TestWriter
    {
        #region Initalization
        [TestMethod]
        //bool Init(string str_FileName)
        public void Test_Init()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            bRetValue = target.Init("Test_Init");
            Assert.IsTrue(bRetValue);
        }
        #endregion Initalization

        #region Extra HSFWriter functions
        [TestMethod]
        //bool placeholderExists(String StrPart)
        public void Test_placeholderExists()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            bRetValue = target.placeholderExists("Ret_1");
            Assert.IsFalse(bRetValue);
            bRetValue = target.Init("Test_placeholderExists");
            Assert.IsTrue(bRetValue);
            bRetValue = target.placeholderExists("Ret_1");
            Assert.IsFalse(bRetValue);
            bRetValue = target.placeholderExists("Test_placeholderExists");
            Assert.IsTrue(bRetValue);

        }
        [TestMethod]
        //bool partExists(String StrPart)
        public void Test_partExists()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            bRetValue = target.partExists("Ret_1");
            Assert.IsFalse(bRetValue);
            bRetValue = target.Init("Test_partExists");
            Assert.IsTrue(bRetValue);
            bRetValue = target.partExists("Ret_1");
            Assert.IsFalse(bRetValue);
            bRetValue = target.partExists("Test_placeholderExists");
            Assert.IsTrue(bRetValue);
        }
        [TestMethod]
        //bool addNode(String PartName, String ComName)
        public void Test_addNode()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            string strPartName = String.Empty;
            string strComponetName = String.Empty;
            bRetValue = target.addNode(strPartName, strComponetName);
            Assert.IsFalse(bRetValue);
            strPartName = "strPartName";
            bRetValue = target.addNode(strPartName, strComponetName);
            Assert.IsFalse(bRetValue);
            strPartName = String.Empty;
            strComponetName = "strComponetName";
            bRetValue = target.addNode(strPartName, strComponetName);
            Assert.IsFalse(bRetValue);
            strPartName = "strPartName";
            bRetValue = target.Init("Test_addNode");
            Assert.IsTrue(bRetValue);
            bRetValue = target.partExists("Ret_1");
            Assert.IsFalse(bRetValue);
        }
        [TestMethod]
        //bool CloseNode(String ComName)
        public void Test_CloseNode()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            bRetValue = target.CloseNode("Text");
            Assert.IsFalse(bRetValue);
            bRetValue = target.Init("Test_CloseNode");
            Assert.IsTrue(bRetValue);
            bRetValue = target.CloseNode("Text");
            Assert.IsTrue(bRetValue);
        }
        #endregion Extra HSFWriter functions

        #region cl_DataStore Functions
        [TestMethod]
        //bool addpart(String PartName, UInt32 U_FaceCount)
        public void Test_addpart()
        {
            bool bRetValue;
            string strPartName = String.Empty;
            uint uFace = 0;

            Outwriter target = new Outwriter();
            cl_DataStore TargetData = new cl_DataStore();
            bRetValue = target.Init("Test_addpart");
            Assert.IsTrue(bRetValue);
            strPartName = "Test_addpart";
            bRetValue = target.addpart(strPartName, uFace);
            Assert.IsTrue(bRetValue);
        }
        [TestMethod]
        //bool addFaceRegion(String PartName, float[] Vert, float[] Nor, float[] TC, uint[] Ind, uint[] FeaC)
        public void Test_addFaceRegion()
        {
            bool bRetValue;
            string strPartName = "Test_addFaceRegion";
            float[] Vert = { 0.1f };
            float[] Nor = { 0.1f };
            float[] TC = { 0.2f };
            uint[] Ind = { 3 };
            uint[] FeaC = { 4 };
            Outwriter target = new Outwriter();
            cl_DataStore TargetData = new cl_DataStore();
            bRetValue = target.Init("Test_addFaceRegion");
            uint uFace = 0;
            bRetValue = target.addpart(strPartName, uFace);
            Assert.IsTrue(bRetValue);

            bRetValue = target.addFaceRegion(strPartName, Vert, Nor, TC, Ind, FeaC);
            Assert.IsTrue(bRetValue);
        }
        [TestMethod]
        //bool addComponent(String PartName, String ComName, double[] trans, double[] ComMat, double[] FeaMat, double[] TexMat)
        public void Test_addComponent()
        {
            bool bRetValue;
            string strPartName = "Test_addComponent"; ;
            String ComName = "Test_addComponent 1";
            double[] trans = { 0.1 };
            double[] ComMat = { 0.2 };
            double[] FeaMat = { 0.3 };
            double[] TexMat = { 0.4 };


            Outwriter target = new Outwriter();
            cl_DataStore TargetData = new cl_DataStore();
            bRetValue = target.Init("Test_addComponent");
            uint uFace = 0;
            bRetValue = target.addpart(strPartName, uFace);
            Assert.IsTrue(bRetValue);
            bRetValue = target.addComponent(strPartName, ComName, trans, ComMat, FeaMat, TexMat);
            Assert.IsTrue(bRetValue);
        }

        #endregion cl_DataStore Functions
        [TestMethod]
        //bool HSFaddpart(cl_DataStore SaveData)
        public void Test_HSFaddpart()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            bRetValue = target.HSFaddpart(null);
            Assert.IsFalse(bRetValue);
            cl_DataStore TargetData = new cl_DataStore();
            bRetValue = target.Init("Test_HSFaddpart");
            Assert.IsTrue(bRetValue);
            bRetValue = target.HSFaddpart(TargetData);
            Assert.IsTrue(bRetValue);
            TargetData.PartName = "PartName";
            bRetValue = target.HSFaddpart(TargetData);
            Assert.IsTrue(bRetValue);
            TargetData.uPartFaceCount = 1;
            bRetValue = target.HSFaddpart(TargetData);
            Assert.IsTrue(bRetValue);
        }
        [TestMethod]
        //bool HSFaddFaceRegion(cl_DataStore SaveData, String str_FileName)
        public void Test_HSFaddFaceRegion()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            String str_FileName = String.Empty;
            bRetValue = target.HSFaddFaceRegion(null, str_FileName);
            Assert.IsFalse(bRetValue);
            cl_DataStore TargetData = new cl_DataStore();
            bRetValue = target.Init("Test_HSFaddFaceRegion");
            Assert.IsTrue(bRetValue);
            bRetValue = target.HSFaddFaceRegion(TargetData, str_FileName);
            Assert.IsTrue(bRetValue);
            TargetData.PartName = "PartName";
            float[] fData = { 0.1f };
            TargetData.Vertices = fData;
            TargetData.Normals = fData;
            TargetData.TextureCoords = fData;
            uint[] uData = { 1 };
            TargetData.Indices = uData;
            TargetData.Features = uData;
            str_FileName = "Test_HSFaddFaceRegion";
            bRetValue = target.HSFaddFaceRegion(TargetData, str_FileName);
            Assert.IsTrue(bRetValue);
        }
        [TestMethod]
        //bool HSFaddComponent(cl_DataStore SaveData, String str_FileName)
        public void Test_HSFaddComponent()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            String str_FileName = String.Empty;
            bRetValue = target.HSFaddComponent(null, str_FileName);
            Assert.IsFalse(bRetValue);
            cl_DataStore TargetData = new cl_DataStore();
            bRetValue = target.Init("Test_HSFaddComponent");
            Assert.IsTrue(bRetValue);
            bRetValue = target.HSFaddComponent(TargetData, str_FileName);
            Assert.IsTrue(bRetValue);
            TargetData.PartName = "PartName";
            double[] dData = { 0.2 };
            TargetData.transformation = dData;
            TargetData.componentMaterial = dData;
            TargetData.featureMaterials = dData;
            TargetData.textureMatrix = dData;

            str_FileName = "Test_HSFaddComponent";
            bRetValue = target.HSFaddComponent(TargetData, str_FileName);
            Assert.IsTrue(bRetValue);
        }
        [TestMethod]
        //bool write(string FileName)
        public void Test_write()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            String str_FileName = String.Empty;
            bRetValue = target.write(str_FileName);
            Assert.IsFalse(bRetValue);

            bRetValue = target.Init("Test_write");
            Assert.IsTrue(bRetValue);
            str_FileName = "Test_write";
            bRetValue = target.write(str_FileName);
            Assert.IsTrue(bRetValue);

        }
        [TestMethod]
        //bool writeExe(string FileName)
        public void Test_writeExe()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            String str_FileName = String.Empty;
            bRetValue = target.writeExe(str_FileName);
            Assert.IsFalse(bRetValue);

            bRetValue = target.Init("Test_writeExe");
            Assert.IsTrue(bRetValue);
            str_FileName = "Test_writeExe";
            bRetValue = target.writeExe(str_FileName);
            Assert.IsTrue(bRetValue);

        }
        [TestMethod]
        //bool WriteData(string str_FileName)
        public void Test_WriteData()
        {
            bool bRetValue;

            Outwriter target = new Outwriter();
            String strPartName = String.Empty;
            uint uFace = 0;
            float[] Vert = { 0.1f };
            float[] Nor = { 0.1f };
            float[] TC = { 0.2f };
            uint[] Ind = { 3 };
            uint[] FeaC = { 4 };
            String ComName = "Test_addComponent 1";
            double[] trans = { 0.1 };
            double[] ComMat = { 0.2 };
            double[] FeaMat = { 0.3 };
            double[] TexMat = { 0.4 };
            cl_DataStore SaveData = new cl_DataStore();
            bRetValue = target.Init("Test_WriteData");
            bRetValue = target.addpart(strPartName, uFace);
            bRetValue = target.addFaceRegion(strPartName, Vert, Nor, TC, Ind, FeaC);
            bRetValue = target.addComponent(strPartName, ComName, trans, ComMat, FeaMat, TexMat);
            Assert.IsTrue(bRetValue);
            bRetValue = target.WriteData(strPartName);
            Assert.IsTrue(bRetValue);

        }
        [TestMethod]
        //public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        public void Test_OnStartup()
        {
            CF_RevitDLL target = new CF_RevitDLL();
            Autodesk.Revit.UI.Result ARU_Result;
            Autodesk.Revit.UI.UIControlledApplication UIContApp=null;
            
            ARU_Result = target.OnStartup(UIContApp);
            Assert.AreEqual(ARU_Result, Autodesk.Revit.UI.Result.Succeeded);
        }
        [TestMethod]
        //Autodesk.Revit.UI.Result OnShutdown(UIControlledApplication application)
        public void Test_OnShutdown()
        {
            CF_RevitDLL target = new CF_RevitDLL();
            Autodesk.Revit.UI.Result ARU_Result;
            Autodesk.Revit.UI.UIControlledApplication UIContApp = null;
            ARU_Result = target.OnShutdown(UIContApp);
            Assert.AreEqual(ARU_Result, Autodesk.Revit.UI.Result.Succeeded);

        }
    }
}