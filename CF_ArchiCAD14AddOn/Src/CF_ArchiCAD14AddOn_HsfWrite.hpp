#pragma once
#import "C:\Projects\CadFasterHSFWriterSDK\bin2\hsfwriterwrap.exe" no_namespace, raw_interfaces_only

class CF_ArchiCAD14AddOn_HsfWrite
{
public:
    CF_ArchiCAD14AddOn_HsfWrite(void);
    ~CF_ArchiCAD14AddOn_HsfWrite(void);
    bool A14A_InitWriter(void);
    bool checkLicense(BSTR licenseProductId, BSTR licenseKey, 
        BSTR signature, BSTR* out_daysLeft,  BSTR* out_licenseOwner);
    bool placeholderExists(BSTR str_FileName);
    bool partExists(BSTR str_FileName);
    bool addNode(BSTR PartName, BSTR ComName);
    bool CloseNode(BSTR ComName);
    bool write(BSTR str_FileName);
    bool writeExe(BSTR str_FileName);
    bool addpart(BSTR PartName, unsigned int U_FaceCount);
    bool addFaceRegion(BSTR PartName, 
        unsigned int UVertexCount, float* Vertices, 
        unsigned int UNormalsCount,float* Normals, 
        unsigned int UTextureCount,float* TextureCoords,
        unsigned int UIndexCount,unsigned int* Indices, 
        unsigned int UFeatureCount, unsigned int* Features);
    bool addComponent(BSTR PartName, BSTR componentId,BSTR imageId,  
        unsigned int uTransformationLength, double* dTransformation,
        unsigned int uComponentMaterialLength, double* dComponentMaterial, 
        unsigned int uFeatureMaterialsLength, double* dFeatureMaterials, 
        unsigned int uTextureMatrixLength, double* dTextureMatrix);
    bool addImage(BSTR imageId);
private:
    IHsfWriter* iHsfWriter;

    BSTR  MyStrNULL;
};
