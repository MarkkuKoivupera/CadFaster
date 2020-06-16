using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using hsfwriter;

namespace ExeWriter
{
    class Saveriter
    {
        String m_Name;
        public String Nimi
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
        public UInt32 UFACE
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
    }
    class Outwriter 
    {




        double[] transformation = {1.0, 0.0, 0.0, 0.0,
                                    0.0, 1.0, 0.0, 0.0,
                                    0.0, 0.0, 1.0, 0.0,
                                    0.0, 0.0, -3.0, 1.0};
        double[] componentMaterial = { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0 };
        double[] featureMaterials = { 1.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 1.0, 0.0, 0.0, 0.0 };
        ArrayList RevitData;
        hsfwriter.IHSFWriterImpl writer;
        public void Init(ref string message)
        {
            try
            {
                RevitData = new ArrayList();
                writer = new hsfwriter.HSFWriterImpl();
                
            }
            catch (Exception e)
            {
                // Exception rised, report it by revit error reporting mechanism. 
                message = e.ToString();
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
        }
        public void addpart(String PartName, UInt32 U_FaceCount)
        {
            if (U_FaceCount == 0)
                U_FaceCount = 0;
            bool bkatki = false;
            int i = 0;
            while (i < RevitData.Count && false==bkatki)
            {
                Saveriter temp = RevitData[i] as Saveriter;
                if (temp.Nimi == PartName)
                    bkatki = true;
                else
                    i++;
            }
            if (bkatki == false)
            {
                Saveriter OsaVarasto = new Saveriter();
                OsaVarasto.Nimi = PartName;
                OsaVarasto.UFACE = U_FaceCount;
                RevitData.Add(OsaVarasto);
            }
           // Initialize data structures for the sample HSF file creation
           
            writer.addPart("SamplePart", 1);
            

        }

        public void placeholderExists()
        {
            // Check that part placeholder exists in HSFWRITER (this is for demonstration purposes)
            int result = writer.placeholderExists("SamplePart");
            if (result != 0)
            {
                System.Windows.Forms.MessageBox.Show("Error while initializing part");
                
            }
            
        }
        float[] vertices = { 0.0f, 0.0f, 0.0f, 10.0f, 0.0f, 0.0f, 10.0f, 10.0f, 0.0f, 0.0f, 10.0f, 0.0f, // Face1
                                 0.0f, 0.0f, 10.0f, 10.0f, 0.0f, 10.0f, 10.0f, 10.0f, 10.0f, 0.0f, 10.0f, 10.0f // Face2
                               };
        float[] normals = { 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f,
                                0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f
                              };
        float[] textureCoords = { 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, -1.0f,
                                0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, 0.0f, -1.0f, 0.0f, -1.0f
                                };
        uint[] indices = { 3, 0, 1, 2, 3, 2, 3, 0,
                               3, 4, 5, 6, 3, 6, 7, 4
                             };
        uint[] features = { 6, 6 };
        public void addFaceRegion()
        {
            // Import geometry to the sample part (single triangle in this case
            //addFaceRegion("SamplePart", vertex, normals, textureCoords, indices, vertexCount, indexCount, features, 2);
            writer.addFaceRegion("SamplePart", vertices, normals, textureCoords, indices, 8, 16, features, 2);
            
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

        public void addComponent()
        {
            // Create a component (geometry instance) for SamplePart
            writer.addComponent("SamplePart", "SampleComponent", transformation, componentMaterial, featureMaterials, 1, "", transformation, 1);
            
        }
        public void write()
        {
            // Write imported data to a HSF file
            writer.write("C:\\CadFaster\\Revit\\test.hsf", hsfwriter.TesselationDataType.Normal, 1, 0);
            
        }
        public void writeExe()
        {
            // Create portable EXE from HSF data
            writer.writeExe("quickstep_portable_directx.exe", "C:\\CadFaster\\Revit\\test.hsf", "C:\\CadFaster\\Revit\\test.exe");
            
        }
        public void SuoriraLoput(ref string message)
        {
            // Create portable EXE from HSF data
            try
            {
                Init(ref message);
                addpart("est", 1);
                placeholderExists();
                addFaceRegion();
                partExists();
                addComponent();
                write();
                writeExe();
            }
                catch (Exception e)
            {
                
                // Exception rised, report it by revit error reporting mechanism. 
                message = e.ToString();
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);

                //return Autodesk.Revit.UI.Result.Failed;
            }        
         }
    }
}
