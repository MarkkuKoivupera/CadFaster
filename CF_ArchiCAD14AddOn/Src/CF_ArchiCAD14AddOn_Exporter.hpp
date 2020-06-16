// *****************************************************************************
// Export ModelAccess Test files
// API Development Kit 14; Mac/Win
//
// Namespaces:		Contact person:
//	   WRL
//
// [SG compatible] - Yes
// *****************************************************************************

#ifndef	_MATEXPORT_HPP_
#define	_MATEXPORT_HPP_

//----------------------------------- Includes ---------------------------------

#include "CF_ArchiCAD14AddOn_Writer.hpp"

#include "APIEnvir.h"
#include "ACAPinc.h"

#include "Collection.hpp"
#include "Coord3D.h"
#include "String.hpp"

//-------------------------------- Predeclarations -----------------------------

namespace GSModeler {
	class Body;
	class Model;
}

namespace InputOutput { class Location; }

//--------------------------------- Namespace WRL ------------------------------

namespace WRL {

//------------------------------- Class definitions ----------------------------

//-------------------------------- Class MAExporter ----------------------------

class MAExporter {
private:
		// data members

	API_IOParams					ioParameters;
	GSModeler::Model*				model;
	GS::Collection<GS::String>		localizedStrings;
	MAWriter*						writer;
	GS::Collection<GS::String>		textureNames;
	IO::Location					textureLoc;

private:
		// export methods

	void				CreateTextures (void);
	void				RemoveExtension (char* fileName);
	void				CreateTextureFile (Int32 textureIndex, char* fullPathName);

	void				WriteHeader (void);
	void				CalcOrientation (const Coord3D& viewPoint, const Coord3D& targetPoint,
										 double rollAngle, Coord3D* axis, double* angle);
	void				CalcSceneLimits (Coord3D* minCoord, Coord3D* maxCoord);
	void				ExportCameraFromSaveAs3D  (void);
	void				ExportPerspectiveCamerasFromPlan (void);
	void				ExportLights (void);
	void				ExportBody (GSModeler::Body& body);
	void				ExportBodies (void);

		// resource handling methods

	void				LoadLocalizedStringResources (void);

public:

		// constructor / destructor

	MAExporter (GSModeler::Model* newModel, const API_IOParams* ioParams);
   ~MAExporter ();

		// export methods

	void				ExportScene (void);
};

//--------------------------------- Namespace WRL ------------------------------

}

#endif
