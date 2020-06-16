// *****************************************************************************
// Common constants for ModelAccess Test Add-On
// API Development Kit 14; Mac/Win
//
// Namespaces:		Contact person:
//	   WRL
//
// [SG compatible] - Yes
// *****************************************************************************

#ifndef	_MATCOMMON_HPP_
#define	_MATCOMMON_HPP_

//----------------------------------- Includes ---------------------------------

#include "GSRoot.hpp"

//--------------------------------- Namespace WRL ------------------------------

namespace WRL {

//----------------------------------- Globals ----------------------------------

const short		MaxStringLength = 1024;
const Int32		PrefsVersion = 0x0001;

#ifdef WINDOWS
const char		Delimiter = '\\';
#endif

#ifdef macintosh
const char		Delimiter = ':';
#endif

//----------------------------------- Macros -----------------------------------

#define TEST_AND_THROW(errCode) if (errCode != NoError) throw GS::GeneralException ();
#define TEST_AND_RETURN(errCode) if (errCode != NoError) return errCode;

//---------------------------------- Exceptions --------------------------------

DECLARE_EXCEPTION_CLASS (
		Cancel,
		GS::RootException,
		Error,
		PLATFORM_DLL_EXPORT_RTTI
)

//--------------------------------- Namespace WRL ------------------------------

}

#endif
