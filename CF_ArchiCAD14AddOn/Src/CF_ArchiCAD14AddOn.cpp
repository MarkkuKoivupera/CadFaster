// *****************************************************************************
// Source code for the ModelAccess Test Add-On
// API Development Kit 14; Mac/Win
//
// Namespaces:			Contact person:
//
//
// [SG compatible] - Yes
// *****************************************************************************

// ---------------------------------- Includes ---------------------------------

#include "APIEnvir.h"
#include "ACAPinc.h"

#include "Location.hpp"
#include "FileSystem.hpp"
#include "EXP.h"
#include "Model3D/Model3DMain.hpp"
#include "Model.hpp"

#include "CF_ArchiCAD14AddOn_Common.hpp"
#include "CF_ArchiCAD14AddOn_Exporter.hpp"
#include "CF_ArchiCAD14AddOn_Resources.hpp"
#include "Sight.hpp"

#if defined (_MSC_VER)
#pragma warning (disable: 4702)		// unreachable code
#endif

// ---------------------------- Function definitions ---------------------------

namespace WRL {
IMPLEMENT_EXCEPTION_CLASS (
		Cancel,
		GS::RootException,
		Error
)
}

GSErrCode	__ACENV_CALL	StartExport (const API_IOParams* ioParams, GSModel3D::SightPtr sight);


static GSErrCode	Handle3DModel (bool fromSaveAs, const API_IOParams* ioParams, GSModel3D::SightPtr sight)
{
	GSErrCode	err=NoError;
	GSModeler::Model model;
	short	sOrigSight = 0, sNewSight;
	API_IOParams	ioParameters;
    GSModel3D::SightPtr Sightprt;

	GSModeler::ModelFuncTable*	funcTable = EXPGetModelFunctionTable ();
	if (funcTable == NULL)
		return APIERR_GENERAL;

	GSModeler::Model::SetFuncTable (funcTable);

	if (!fromSaveAs) {		// we must switch to the 3D Window's sight
		sNewSight = (short) API_PlanSight;
		err = ACAPI_3D_SelectSight (&sNewSight, &sOrigSight);
		if (err != NoError) {
			DBPrintf  ("Cannot switch to the 3D sight", err);
			return err;

		}
		//HOX:: Here must make file ask form
		IO::Location   TempLoc;
		ioParameters.fileLoc = &TempLoc;
	}
	else
	{
        ioParameters= *ioParams;
        Sightprt=sight;
	}


	EXPGetModel (Sightprt, &model);

	try {
		WRL::MAExporter	exporter (&model, ioParams);
		exporter.ExportScene ();
	}

	catch (WRL::Cancel) {
		IO::Location	fileLoc;
		fileLoc = *ioParams->fileLoc;
		IO::fileSystem.Delete (fileLoc);

		return APIERR_CANCEL;
	}

	catch (...) {
		IO::Location	fileLoc;
		fileLoc = *ioParams->fileLoc;
		IO::fileSystem.Delete (fileLoc);

		return APIERR_GENERAL;
	}

	return err;
}
// -----------------------------------------------------------------------------
// show_About : Show About form and customer Info
// -----------------------------------------------------------------------------
static void show_About (void)
{
	//Do_ShowAbout();
	return;
}		// Do_About
// -----------------------------------------------------------------------------
// MenuCommandHandler : Handles menu commands
// -----------------------------------------------------------------------------
GSErrCode __ACENV_CALL MenuCommandHandler (const API_MenuParams *menuParams)
{
	GSErrCode err = ACAPI_OpenUndoableSession ("Colloborate Function");
	if (err != NoError) {
		DBPrintf ("ElementsTrick cannot open undoable session: %d\n", err);
		return err;
	}

	switch (menuParams->menuItemRef.menuResID) {
		case 32500:
			switch (menuParams->menuItemRef.itemIndex) {
				case 1:		show_About ();		break;
				case 2:		Handle3DModel (false,NULL,NULL);			break;
			}
			break;
	}

	ACAPI_CloseUndoableSession ();

	return NoError;
}		/* ElementsTrick */


// =============================================================================
//
// Required functions
//
// =============================================================================

#ifdef __APPLE__
#pragma mark -
#endif
// -----------------------------------------------------------------------------
// Start the export
// -----------------------------------------------------------------------------
GSErrCode	__ACENV_CALL	StartExport (const API_IOParams* ioParams, GSModel3D::SightPtr sight)
{
	GSErrCode	err = Handle3DModel (true,ioParams,sight);
	return err;
}		// StartExport
// -----------------------------------------------------------------------------
// Dependency definitions
// -----------------------------------------------------------------------------
API_AddonType	__ACENV_CALL	CheckEnvironment (API_EnvirParams* envir)
{
	GSResModule saveResModule = ACAPI_UseOwnResModule ();
	RSGetIndString (envir->addOnInfo.name, WRL::AddonInfoStringTable, WRL::AddonName);
	RSGetIndString (envir->addOnInfo.description, WRL::AddonInfoStringTable, WRL::AddonDescription);
	ACAPI_ResetResModule (saveResModule);

	return APIAddon_Normal;
}


// -----------------------------------------------------------------------------
// Interface definitions
// -----------------------------------------------------------------------------
GSErrCode	__ACENV_CALL	RegisterInterface (void)
{
	GSErrCode	errCode = NoError;
	errCode = ACAPI_Register_Menu (32500, 0, MenuCode_UserDef, MenuFlag_SeparatorBefore);
	if (errCode == NoError)
		errCode = ACAPI_Register_FileType (1, 'EXE', 'HSF', "exe;", 0, 32501, 1, SaveAs3DSupported);
	return errCode;
}


// -----------------------------------------------------------------------------
// Called when the Add-On has been loaded into memory
// to perform an operation
// -----------------------------------------------------------------------------
GSErrCode	__ACENV_CALL	Initialize	(void)
{
	GSErrCode errCode = ACAPI_Install_MenuHandler (32500, MenuCommandHandler);
	if (errCode != NoError)
		DBPrintf ("3D_Test:: Initialize () ACAPI_Install_MenuHandler failed\n");

	errCode = ACAPI_Install_FileTypeHandler3D (1, StartExport);
	if (errCode != NoError)
		DBPrintf ("3D_Test:: Initialize () ACAPI_Install_FileTypeHandler failed\n");

	return errCode;
}


// -----------------------------------------------------------------------------
// FreeData
//		called when the Add-On is going to be unloaded
// -----------------------------------------------------------------------------
GSErrCode __ACENV_CALL		FreeData (void)
{
	return NoError;
}
