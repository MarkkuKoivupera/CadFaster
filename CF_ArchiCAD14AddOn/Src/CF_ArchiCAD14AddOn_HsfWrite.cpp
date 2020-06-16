//#import "C:\Projects\CadFasteriHsfWriterSDK\CFTranslatorForRevit\iHsfWriterWrap.interop.dll"
#include "CF_ArchiCAD14AddOn_HsfWrite.hpp"

CF_ArchiCAD14AddOn_HsfWrite::CF_ArchiCAD14AddOn_HsfWrite(void)
{
    MyStrNULL = SysAllocString(L"");
}

CF_ArchiCAD14AddOn_HsfWrite::~CF_ArchiCAD14AddOn_HsfWrite(void)
{
}
bool CF_ArchiCAD14AddOn_HsfWrite::A14A_InitWriter(void)
{
    iHsfWriter->InitWriter();
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::checkLicense(
    BSTR licenseProductId, BSTR licenseKey, 
    BSTR signature, 
    BSTR* out_daysLeft, BSTR* out_licenseOwner)
{
    iHsfWriter->checkLicense(licenseProductId,licenseKey,signature,out_daysLeft,out_licenseOwner);
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::placeholderExists(BSTR str_FileName)
{
    int iPlace=0;
    iHsfWriter->placeholderExist(str_FileName,&iPlace);
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::partExists(BSTR str_FileName)
{
    unsigned int iPlace=0;
    iHsfWriter->partExists(str_FileName,&iPlace);
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::addNode(BSTR PartName, BSTR ComName)
{
    if (!partExists(PartName))
    {
        addpart(PartName, 1);
       
    }
    double temp[1];
    iHsfWriter->addComponent(PartName, ComName,
        0, temp, 0, temp,0,temp, MyStrNULL, 0, temp,  0);
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::CloseNode(BSTR ComName)
{
    double temp[1];
            
    iHsfWriter->addComponent(SysAllocString(L"CloseSubAssembly"), ComName, 
        0, temp, 0, temp, 0, temp, MyStrNULL, 0, temp, 0);
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::write(BSTR str_FileName)
{
    //iHsfWriterWrap.interop.TesselationDataTypes.normals = 0 & Stripss = 1
    //int iTessNorm=0;
    unsigned int uLen=SysStringLen(str_FileName);
    BSTR ExtBSTR=SysAllocString(L".hsf");
    unsigned int uExtLen=SysStringLen(ExtBSTR);

    BSTR NewBSTR=SysAllocStringLen(str_FileName,uLen+uExtLen);
    memcpy(NewBSTR+uLen,ExtBSTR,uExtLen);
    iHsfWriter->write(NewBSTR, normals, 1, 0);
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::writeExe(BSTR str_FileName)
{
    unsigned int uLen=SysStringLen(str_FileName);
    BSTR ExtBSTR=SysAllocString(L".hsf");
    unsigned int uExtLen=SysStringLen(ExtBSTR);
    BSTR NewBSTR=SysAllocStringLen(str_FileName,uLen+uExtLen);
    memcpy(NewBSTR+uLen,ExtBSTR,uExtLen);
    BSTR ExeBSTR=SysAllocString(L".exe");
    unsigned int uExeLen=SysStringLen(ExeBSTR);
    BSTR NewexeBSTR=SysAllocStringLen(str_FileName,uLen+uExeLen);
    memcpy(NewexeBSTR+uLen,ExeBSTR,uExeLen);
    BSTR QPD_EXE=SysAllocString(L"quickstep_portable_directx.exe");
    iHsfWriter->writeExe(QPD_EXE, ExeBSTR, NewexeBSTR);
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::addpart(BSTR PartName, unsigned int U_FaceCount)
{
    iHsfWriter->addPart(PartName, U_FaceCount);
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::addFaceRegion(
    BSTR PartName, 
    unsigned int UVertexLen, float* Vertices, 
    unsigned int UNormalsLen,float* Normals, 
    unsigned int UTextureLen,float* TextureCoords,
    unsigned int UIndexLen,unsigned int* Indices, 
    unsigned int UFeatureLen, unsigned int* Features)
{
    unsigned int UFeatureCount = UFeatureLen; 
    unsigned int UVertexCount = UVertexLen/3;
    unsigned int UIndexCount = UIndexLen;
/*writer.addFaceRegion(PartName, Vertices, Normals, TextureCoords,
    Indices, UVertexCount, UIndexCount, Features, UFeatureCount);*/
    //texturecoords on null jatkapa tästä huomenna poika
    if (TextureCoords == NULL)
    {
        float apu[1];
        TextureCoords= apu;
        UTextureLen = 0;

    }
    iHsfWriter->addFaceRegion(PartName,
        UVertexLen, Vertices, 
        UNormalsLen, Normals, 
        UTextureLen,TextureCoords,
        UIndexLen, Indices, 
        UVertexCount, UIndexCount,  
        UFeatureCount,Features);
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::addComponent(
        BSTR PartName, BSTR componentId,BSTR imageId, 
        unsigned int uTransformationLength, double* dTransformation,
        unsigned int uComponentMaterialLength, double* dComponentMaterial, 
        unsigned int uFeatureMaterialsLength, double* dFeatureMaterials, 
        unsigned int uTextureMatrixLength, double* dTextureMatrix)
{
    
   
    if (partExists(PartName)==true)
         iHsfWriter->addComponent(PartName, componentId,
                        uTransformationLength, dTransformation, 
                        uComponentMaterialLength, dComponentMaterial,
                        uFeatureMaterialsLength, dFeatureMaterials,
                        imageId, 
                        uTextureMatrixLength, dTextureMatrix, 
                        0);
    
    return true;
}
bool CF_ArchiCAD14AddOn_HsfWrite::addImage(BSTR imageId)
{
    iHsfWriter->addImage(imageId);
    return true;
}
