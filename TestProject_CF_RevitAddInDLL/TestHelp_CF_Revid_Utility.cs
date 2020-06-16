using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk
{
    namespace Revit
    {
        namespace Utility
        {
            public class AssetPropertyDoubleArray4d : AssetProperty
            {
                public Autodesk.Revit.DB.DoubleArray Value 
                { get { return new Autodesk.Revit.DB.DoubleArray();} }
            }
            public class Asset : AssetProperties
            {
                //public AssetType AssetType { get; }
                //public string LibraryName { get; }
                //public string Title { get; }
            }
            public class AssetProperties : AssetProperty
            {
                public int Size { get { return 0; } }

                public AssetProperty this[int index] { get { return new AssetProperty(); } }
                //public AssetProperty this[string name] { get; }
            }
            public class AssetProperty 
            {
                public string Name { get { return "AssetProperty_Name"; } }
                //public virtual AssetPropertyType Type { get; }

                //public static string GetTypeName(AssetPropertyType type);
                //protected override void ReleaseUnmanagedResources();
            }
        }
        namespace Creation
        {
            public class Application 
            {
                //public Arc NewArc(XYZ end0, XYZ end1, XYZ pointOnCurve);
                //public Arc NewArc(Plane plane, double radius, double startAngle, double endAngle);
                //public Arc NewArc(XYZ center, double radius, double startAngle, double endAngle, XYZ xAxis, XYZ yAxis);
                //public AreaCreationData NewAreaCreationData(ViewPlan areaView, UV point);
                //public Array NewArray();
                //public BoundingBoxUV NewBoundingBoxUV();
                //public BoundingBoxUV NewBoundingBoxUV(double min_u, double min_v, double max_u, double max_v);
                //public BoundingBoxXYZ NewBoundingBoxXYZ();
                //public BuildingSiteExportOptions NewBuildingSiteExportOptions();
                //public CategorySet NewCategorySet();
                //public Color NewColor();
                //public CombinableElementArray NewCombinableElementArray();
                //public CurveArrArray NewCurveArrArray();
                //public CurveArray NewCurveArray();
                //public CurveLoopsProfile NewCurveLoopsProfile(CurveArrArray curveLoops);
                //public DGNExportOptions NewDGNExportOptions();
                //public DoubleArray NewDoubleArray();
                //public DWFExportOptions NewDWFExportOptions();
                //public DWFXExportOptions NewDWFXExportOptions();
                //public DWGExportOptions NewDWGExportOptions();
                //public DWGImportOptions NewDWGImportOptions();
                //public DXFExportOptions NewDXFExportOptions();
                //public ElementArray NewElementArray();
                //public ElementId NewElementId();
                //public ElementSet NewElementSet();
                //public Ellipse NewEllipse(XYZ center, double radX, double radY, XYZ xVec, XYZ yVec, double param0, double param1);
                //public FaceArray NewFaceArray();
                //public FamilyInstanceCreationData NewFamilyInstanceCreationData(Face face, Line position, FamilySymbol symbol);
                //public FamilyInstanceCreationData NewFamilyInstanceCreationData(XYZ location, FamilySymbol symbol, StructuralType structuralType);
                //public FamilyInstanceCreationData NewFamilyInstanceCreationData(Curve curve, FamilySymbol symbol, Level level, StructuralType structuralType);
                //public FamilyInstanceCreationData NewFamilyInstanceCreationData(Face face, XYZ location, XYZ referenceDirection, FamilySymbol symbol);
                //public FamilyInstanceCreationData NewFamilyInstanceCreationData(XYZ location, FamilySymbol symbol, Element host, StructuralType structuralType);
                //public FamilyInstanceCreationData NewFamilyInstanceCreationData(XYZ location, FamilySymbol symbol, Level level, StructuralType structuralType);
                //public FamilyInstanceCreationData NewFamilyInstanceCreationData(XYZ location, FamilySymbol symbol, Element host, Level level, StructuralType structuralType);
                //public FamilyInstanceCreationData NewFamilyInstanceCreationData(XYZ location, FamilySymbol symbol, XYZ referenceDirection, Element host, StructuralType structuralType);
                //public FamilySymbolProfile NewFamilySymbolProfile(FamilySymbol familySymbol);
                //public FBXExportOptions NewFBXExportOptions();
                //public FillPatternSet NewFillPatternSet();
                //public GBXMLExportOptions NewGBXMLExportOptions();
                //public GBXMLImportOptions NewGBXMLImportOptions();
                public Autodesk.Revit.DB.Options NewGeometryOptions() { return new Autodesk.Revit.DB.Options(); }
                //public HermiteSpline NewHermiteSpline(IList<XYZ> ctrlPoints, bool bPeriodic);
                //public ImageImportOptions NewImageImportOptions();
                //public InstanceBinding NewInstanceBinding();
                //public InstanceBinding NewInstanceBinding(CategorySet categorySet);
                //public IntersectionResultArray NewIntersectionResultArray();
                //public InventorImportOptions NewInventorImportOptions();
                //public Line NewLine(XYZ point, XYZ endOrDirection, bool bound);
                //public Line NewLineBound(XYZ start, XYZ end);
                //public LinePatternSet NewLinePatternSet();
                //public Line NewLineUnbound(XYZ point, XYZ direction);
                //public LoadCaseArray NewLoadCaseArray();
                //public LoadCombinationArray NewLoadCombinationArray();
                //public LoadUsageArray NewLoadUsageArray();
                //public Map NewMap();
                //public MaterialSet NewMaterialSet();
                //public NurbSpline NewNurbSpline(IList<XYZ> ctrlPoints, DoubleArray weights, DoubleArray knots, int nDegree, bool bClosed, bool bRational);
                //public Plane NewPlane(CurveArray curveloop);
                //public Plane NewPlane(XYZ norm, XYZ origin);
                //public Plane NewPlane(XYZ xVec, XYZ yVec, XYZ origin);
                //public Point NewPoint(XYZ coord);
                //public PointOnEdge NewPointOnEdge(Reference edgeReference, double edgeParam);
                //public PointOnEdgeEdgeIntersection NewPointOnEdgeEdgeIntersection(Reference edgeReference1, Reference edgeReference2);
                //public PointOnEdgeFaceIntersection NewPointOnEdgeFaceIntersection(Reference edgeReference, Reference faceReference, bool orientWithEdge);
                //public PointOnFace NewPointOnFace(Reference faceReference, UV uv);
                //public PointOnPlane NewPointOnPlane(Reference planeReference, UV position, UV xvec, double offset);
                //public ProfiledWallCreationData NewProfiledWallCreationData(CurveArray profile, bool structural);
                //public ProfiledWallCreationData NewProfiledWallCreationData(CurveArray profile, WallType wallType, Level level, bool structural);
                //public ProfiledWallCreationData NewProfiledWallCreationData(CurveArray profile, WallType wallType, Level level, bool structural, XYZ normal);
                //public ProjectPosition NewProjectPosition(double ew, double ns, double elevation, double angle);
                //public RectangularWallCreationData NewRectangularWallCreationData(Curve curve, Level level, bool structural);
                //public RectangularWallCreationData NewRectangularWallCreationData(Curve curve, WallType wallType, Level level, double height, double offset, bool flip, bool structural);
                //public ReferenceArray NewReferenceArray();
                //public ReferencePointArray NewReferencePointArray();
                //public RoomCreationData NewRoomCreationData(Level level, UV point);
                //public SATExportOptions NewSATExportOptions();
                //public Set NewSet();
                //public SpaceSet NewSpaceSet();
                //public StringStringMap NewStringStringMap();
                //public SuspendUpdating NewSuspendUpdating(Autodesk.Revit.DB.Document document);
                //public TextNoteCreationData NewTextNoteCreationData(View theView, XYZ origin, XYZ baseVec, XYZ upVec, double lineWidth, TextAlignFlags textAlign, string strText);
                //public TextNoteCreationData NewTextNoteCreationData(View theView, XYZ origin, XYZ baseVec, XYZ upVec, double lineWidth, TextAlignFlags textAlign, TextNoteLeaderTypes leaderType, TextNoteLeaderStyles leaderStyle, XYZ leaderEnd, XYZ leaderElbow, string strText);
                //public TypeBinding NewTypeBinding();
                //public TypeBinding NewTypeBinding(CategorySet categorySet);
                //public UV NewUV();
                //public UV NewUV(UV uv);
                //public UV NewUV(double u, double v);
                //public VertexIndexPair NewVertexIndexPair(int iTop, int iBottom);
                //public VertexIndexPairArray NewVertexIndexPairArray();
                //public ViewSet NewViewSet();
                //public VolumeCalculationOptions NewVolumeCalculationOptions();
                //public XYZ NewXYZ();
                //public XYZ NewXYZ(XYZ xyz);
                //public XYZ NewXYZ(double x, double y, double z);
            }
        }
    }

}
