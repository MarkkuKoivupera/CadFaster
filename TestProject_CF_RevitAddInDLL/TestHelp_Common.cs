using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace ExeWriter
//{
//    class WriterUtils
//    {
//        public Autodesk.Revit.UI.Result HandleData(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, Autodesk.Revit.UI.ElementSet elements)
//        {
//            return Autodesk.Revit.UI.Result.Succeeded;
//        }
//    }
//}
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