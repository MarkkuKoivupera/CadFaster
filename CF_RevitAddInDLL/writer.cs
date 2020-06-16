using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Timers;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using hsfwriter;

namespace ExeWriter
{
    #region cl_DataStore Class
    class cl_DataStore
    {
        String m_Name;
        public String PartName
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        UInt32 m_UFaces;
        public UInt32 uPartFaceCount
        {
            get
            {
                return m_UFaces;
            }
            set
            {
                m_UFaces = value;
            }
        }
        float[] m_vertices;
        public float[] Vertices
        {
            get
            {
                return m_vertices;
            }
            set
            {
                m_vertices = value;
            }
        }
        float[] m_normals;
        public float[] Normals
        {
            get
            {
                return m_normals;
            }
            set
            {
                m_normals = value;
            }
        }
        float[] m_textureCoords;
        public float[] TextureCoords
        {
            get
            {
                return m_textureCoords;
            }
            set
            {
                m_textureCoords = value;
            }
        }
        uint[] m_indices;
        public uint[] Indices
        {
            get
            {
                return m_indices;
            }
            set
            {
                m_indices = value;
            }
        }
        uint[] m_features;
        public uint[] Features
        {
            get
            {
                return m_features;
            }
            set
            {
                m_features = value;
            }
        }
        UInt32 m_UvertexCount;
        public UInt32 UVertexCount
        {
            get
            {
                return m_UvertexCount;
            }
            set
            {
                m_UvertexCount = value;
            }
        }
        UInt32 m_UindexCount;
        public UInt32 UIndexCount
        {
            get
            {
                return m_UindexCount;
            }
            set
            {
                m_UindexCount = value;
            }
        }
        UInt32 m_UfeatureCount;
        public UInt32 UFeatureCount
        {
            get
            {
                return m_UfeatureCount;
            }
            set
            {
                m_UfeatureCount = value;
            }
        }
        String m_componentId;
        public String componentId
        {
            get
            {
                return m_componentId;
            }
            set
            {
                m_componentId = value;
            }
        }
        double[] m_transformation;
        public double[] transformation
        {
            get
            {
                return m_transformation;
            }
            set
            {
                m_transformation = value;
            }
        }
        double[] m_componentMaterial;
        public double[] componentMaterial
        {
            get
            {
                return m_componentMaterial;
            }
            set
            {
                m_componentMaterial = value;
            }
        }
        double[] m_featureMaterials;
        public double[] featureMaterials
        {
            get
            {
                return m_featureMaterials;
            }
            set
            {
                m_featureMaterials = value;
            }
        }
        uint m_ufeatureMaterialCount;
        public UInt32 u_featureMaterialCount
        {
            get
            {
                return m_ufeatureMaterialCount;
            }
            set
            {
                m_ufeatureMaterialCount = value;
            }
        }
        String m_imageId;
        public String imageId
        {
            get
            {
                return m_imageId;
            }
            set
            {
                m_imageId = value;
            }
        }
        double[] m_textureMatrix;
        public double[] textureMatrix
        {
            get
            {
                return m_textureMatrix;
            }
            set
            {
                m_textureMatrix = value;
            }
        }
        uint m_UdoubleSided;
        public UInt32 UdoubleSided
        {
            get
            {
                return m_UdoubleSided;
            }
            set
            {
                m_UdoubleSided = value;
            }
        }
    }
    #endregion Extra Class

    class Outwriter
    {
        #region Initalization
        #region Variables
        private ArrayList ArLi_RevitData;
        uint koponettimaara;
        hsfwriter.IHSFWriterImpl writer;
        #endregion Variables

        public void Init(string str_FileName)
        {
            try
            {
                koponettimaara = 0;
                ArLi_RevitData = new ArrayList();
                writer = new hsfwriter.HSFWriterImpl();
                string message = "CadFaster Log file:" + Environment.NewLine;
                File.WriteAllText(@"C:\CadFaster\Revit\" + str_FileName + ".txt", message);
 
                
            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "Init fails for Reason:" + Environment.NewLine;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                message = e.ToString();
                //File.AppendAllText(@"C:\CadFaster\Revit\CF_RevitAddInDLL_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
        }
        #endregion Initalization

        #region Extra HSFWriter functions
        public void placeholderExists()
        {
            // Check that part placeholder exists in HSFWRITER (this is for demonstration purposes)
            int result = writer.placeholderExists("SamplePart");
            if (result != 0)
            {
                System.Windows.Forms.MessageBox.Show("Error while initializing part");

            }

        }
        public void partExists()
        {
            // Check that fully imported part exists in HSFWRITER (this is for demonstration purposes)
            int result = writer.partExists("SamplePart");
            if (result != 0)
            {
                System.Windows.Forms.MessageBox.Show("Error while importing part's geometry part");

            }

        }
        public void addNode(String PartName, String ComName)
        {
            writer.addComponent(PartName, ComName, null, null, null, 1, "", null, 0);
        }
        public void CloseNode(String ComName)
        {
            writer.addComponent("CloseSubAssembly", ComName, null, null, null, 0, null, null, 0);
        }


        #endregion Extra HSFWriter functions

        #region Working HSFWriter functions

        public void HSFaddpart(cl_DataStore SaveData)
        {

            writer.addPart(SaveData.PartName, SaveData.uPartFaceCount);
        }

        public void HSFaddFaceRegion(cl_DataStore SaveData, String str_FileName)
        {
            string message;
            try
            {

                koponettimaara++;
                if (koponettimaara == 82)
                    koponettimaara = 82;
                writer.addFaceRegion(SaveData.PartName, SaveData.Vertices, SaveData.Normals, SaveData.TextureCoords,
                    SaveData.Indices, SaveData.UVertexCount, SaveData.UIndexCount, SaveData.Features, SaveData.UFeatureCount);
                //message = "       AddFaceRegion :" + SaveData.PartName +
                //    " VER: " + SaveData.Vertices.Length.ToString() +
                //    " Nor: " + SaveData.Normals.Length.ToString() +
                //    "  TC: " + SaveData.TextureCoords.Length.ToString() +
                //    " Ind: " + SaveData.Indices.Length.ToString() +
                //    " FeaC: " + SaveData.Features.Length.ToString() +
                //    " nro: " + koponettimaara + Environment.NewLine;
                //File.AppendAllText(@"C:\CadFaster\Revit\" + str_FileName + ".txt", message);
            }
            catch (Exception e)
            {

                // Exception rised, report it by revit error reporting mechanism. 
                message = "ERROR: AddFaceRegion " + SaveData.PartName +
                    " VER: " + SaveData.Vertices.Length.ToString() +
                    " Nor: " + SaveData.Normals.Length.ToString() +
                    "  TC: " + SaveData.TextureCoords.Length.ToString() +
                    " Ind: " + SaveData.Indices.Length.ToString() +
                    " FeaC: " + SaveData.Features.Length.ToString() +
                    " nro: " + koponettimaara + Environment.NewLine;
                File.AppendAllText(@"C:\CadFaster\Revit\" + str_FileName + ".txt", message);
                message = e.ToString();
            }
        }

        public void HSFaddComponent(cl_DataStore SaveData, String str_FileName)
        {

            string message;
            try
            {

                if (koponettimaara == 82)
                    koponettimaara = 82;
                // Create a component (geometry instance) for SamplePart
                //System.Threading.Thread.Sleep(200);
                writer.addComponent(SaveData.PartName, SaveData.componentId,
                                    SaveData.transformation, SaveData.componentMaterial,
                                    SaveData.featureMaterials, SaveData.u_featureMaterialCount, "", SaveData.textureMatrix, 0);
                writer.addComponent("CloseSubAssembly", SaveData.componentId, null, null, null, 0, null, null, 0);
                //message = "       AddComponent  :" + SaveData.PartName +
                //    " trans: " + SaveData.transformation.Length.ToString() +
                //    " ComMat: " + SaveData.componentMaterial.Length.ToString() +
                //    " FeaMat: " + SaveData.featureMaterials.Length.ToString() +
                //    " TexMat: " + SaveData.textureMatrix.Length.ToString() +
                //    " nro: " + koponettimaara + Environment.NewLine;
                //File.AppendAllText(@"C:\CadFaster\Revit\" + str_FileName + ".txt", message);

            }
            catch (Exception e)
            {
                //string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "ERROR: AddComponent  :" + SaveData.PartName +
                    " trans: " + SaveData.transformation.Length.ToString() +
                    " ComMat: " + SaveData.componentMaterial.Length.ToString() +
                    " FeaMat: " + SaveData.featureMaterials.Length.ToString() +
                    " TexMat: " + SaveData.textureMatrix.Length.ToString() +
                    " nro: " + koponettimaara + Environment.NewLine;
                File.AppendAllText(@"C:\CadFaster\Revit\" + str_FileName + ".txt", message);
                message = e.ToString();
                //File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
        }

        public void write(string FileName)
        {
            // Write imported data to a HSF file
            writer.write("C:\\CadFaster\\Revit\\" + FileName + ".hsf", hsfwriter.TesselationDataType.Normal, 1, 0);

        }

        public void writeExe(string FileName)
        {
            // Create portable EXE from HSF data               C:\\CadFaster\\Revit\\CFRevitApiDll.hsf
            writer.writeExe("C:\\Projects\\CadFasterHSFWriterSDK\\bin\\quickstep_portable_directx.exe",
                "C:\\CadFaster\\Revit\\" + FileName + ".hsf", "C:\\CadFaster\\Revit\\" + FileName + ".exe");

        }

        public void WriteData(string str_FileName)
        {
            foreach (cl_DataStore cl_record in ArLi_RevitData)
            {
                HSFaddpart(cl_record);
                HSFaddFaceRegion(cl_record, str_FileName);
                HSFaddComponent(cl_record, str_FileName);
            }
            ArLi_RevitData.Clear();
        }

        public void MakeEndProsess(string str_FileName)
        {
            // Create portable EXE from HSF data
            try
            {
                foreach (cl_DataStore reco in ArLi_RevitData)
                {
                    HSFaddpart(reco);
                    HSFaddFaceRegion(reco, str_FileName);
                    HSFaddComponent(reco, str_FileName);
                }

                write(str_FileName);
                writeExe(str_FileName);
                ArLi_RevitData.Clear();
            }
                catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "SuoriraLoput fails " + str_FileName + " Reason:" + Environment.NewLine; ;
                message = e.ToString();
                //File.AppendAllText(@"C:\CadFaster\Revit\CF_RevitApiDll_log.txt", message);

                //return Autodesk.Revit.UI.Result.Failed;
            }        
         }

        #endregion Working HSFWriter functions

        #region cl_DataStore Functions
        public void addpart(String PartName, UInt32 U_FaceCount)
        {

            //writer.addPart(PartName, U_FaceCount);
            bool bkatki = false;
            int i = 0;
            while (i < ArLi_RevitData.Count && false == bkatki)
            {
                cl_DataStore temp = ArLi_RevitData[i] as cl_DataStore;
                if (temp.PartName == PartName)
                    bkatki = true;
                else
                    i++;
            }
            if (bkatki == false)
            {
                cl_DataStore OsaVarasto = new cl_DataStore();
                OsaVarasto.PartName = PartName;
                OsaVarasto.uPartFaceCount = U_FaceCount;
                ArLi_RevitData.Add(OsaVarasto);
            }

        }

        public void addFaceRegion(String PartName, float[] Vert, float[] Nor, float[] TC, uint[] Ind, uint[] FeaC)
        {
            bool bkatki = false;
            int i = 0;
            while (i < ArLi_RevitData.Count && false == bkatki)
            {
                cl_DataStore temp = ArLi_RevitData[i] as cl_DataStore;
                if (temp.PartName == PartName)
                    bkatki = true;
                else
                    i++;
            }
            if (bkatki == true)
            {
                cl_DataStore temp = ArLi_RevitData[i] as cl_DataStore;
                temp.Vertices = Vert;
                temp.Normals = Nor;
                temp.TextureCoords = TC;
                temp.Indices = Ind;
                temp.Features = FeaC;
                temp.UVertexCount = (uint)Vert.Length / 3;
                temp.UIndexCount = (uint)Ind.Length;
                temp.UFeatureCount = (uint)FeaC.Length;
            }

        }

        public void addComponent(String PartName, String ComName, double[] trans, double[] ComMat, double[] FeaMat, double[] TexMat)
        {
            bool bkatki = false;
            int i = 0;
            while (i < ArLi_RevitData.Count && false == bkatki)
            {
                cl_DataStore temp = ArLi_RevitData[i] as cl_DataStore;
                if (temp.PartName == PartName)
                    bkatki = true;
                else
                    i++;
            }
            if (bkatki == true)
            {
                cl_DataStore temp = ArLi_RevitData[i] as cl_DataStore;
                temp.componentId = ComName;
                temp.transformation = trans;
                temp.componentMaterial = ComMat;
                temp.featureMaterials = FeaMat;
                temp.u_featureMaterialCount = (uint)FeaMat.Length;
                temp.imageId = "";
                temp.textureMatrix = TexMat;
                temp.UdoubleSided = 0;
            }

        }
        #endregion cl_DataStore Functions
        
    }
}
