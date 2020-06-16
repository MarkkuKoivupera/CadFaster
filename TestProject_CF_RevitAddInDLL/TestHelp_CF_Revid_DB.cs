using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Autodesk
{
    namespace Revit
    {
        namespace DB
        {
            public class XYZ
            {
                //public XYZ();
                //public XYZ(double x, double y, double z);

                //public static XYZ operator -(XYZ source);
                public static XYZ operator -(XYZ left, XYZ right) { return new XYZ(); }

                //public static XYZ operator *(double value, XYZ right);
                //public static XYZ operator *(XYZ left, double value);
                //public static XYZ operator /(XYZ left, double value);
                //public static XYZ operator +(XYZ left, XYZ right);

                //public static XYZ BasisX { get; }
                //public static XYZ BasisY { get; }
                //public static XYZ BasisZ { get; }
                public double X { get { return 0; } }
                public double Y { get { return 0; } }
                public double Z { get { return 0; } }
                //public static XYZ Zero { get; }

                //public double this[int idx] { get; }

                //public XYZ Add(XYZ source);
                //public double AngleOnPlaneTo(XYZ right, XYZ normal);
                //public double AngleTo(XYZ source);
                public XYZ CrossProduct(XYZ source) { return new XYZ(); }
                //public double DistanceTo(XYZ source);
                //public XYZ Divide(double value);
                //public double DotProduct(XYZ source);
                //public double GetLength();
                //public bool IsAlmostEqualTo(XYZ source);
                //public bool IsAlmostEqualTo(XYZ source, double tolerance);
                //public bool IsUnitLength();
                //public bool IsZeroLength();
                //public XYZ Multiply(double value);
                //public XYZ Negate();
                public XYZ Normalize() { return new XYZ(); }
                //public XYZ Subtract(XYZ source);
                //public override string ToString();
                //public double TripleProduct(XYZ middle, XYZ right);
            }
            public class APIObject 
            {
                //public virtual bool IsReadOnly { get; }

                public void Dispose() { }
                protected virtual void Dispose(bool value) { }
                //protected virtual void ReleaseManagedResources();
                //protected virtual void ReleaseUnmanagedResources();
            }
            public class GeometryObjectArray
            {
                public virtual int Size { get { return 0; } }
                public virtual IEnumerator GetEnumerator() { return null; }
            }
            public class GeometryElement : GeometryObject
            {
                //public Material MaterialElement { get; }
                public GeometryObjectArray Objects { get { return new GeometryObjectArray(); } }
            }
            public class GeometryObject : APIObject
            {
                //public Visibility Visibility { get; }

                //protected override void ReleaseUnmanagedResources();
            }
            public class Transform
            {
                public XYZ BasisX { get { return new XYZ(); } set { } }
                public XYZ BasisY { get { return new XYZ(); } set { } }
                public XYZ BasisZ { get { return new XYZ(); } set { } }
                public XYZ Origin { get { return new XYZ(); } set { } }
                public double Scale { get { return 0; } }
            }
            public class GeometryInstance : GeometryObject
            {
                public Element Symbol { get { return new Element(); } }
                public GeometryElement SymbolGeometry { get { return new GeometryElement(); } }
                public Transform Transform { get { return new Transform(); } }

                //public GeometryElement GetInstanceGeometry();
                //public GeometryElement GetInstanceGeometry(Transform transform);
                public GeometryElement GetSymbolGeometry(){ return new GeometryElement(); }
                //public GeometryElement GetSymbolGeometry(Transform transform);
            }
            public class Color
            {
                public byte Blue { get { return 0; } set { } }
                public byte Green { get { return 0; } set { } }
                public byte Red { get { return 0; } set { } }
            }
            public class Material : Element
            {
                public Color Color { get { return new Color(); } set { } }
                //public FillPattern CutPattern { get; set; }
                //public Color CutPatternColor { get; set; }
                //public bool Glow { get; set; }
                public Autodesk.Revit.Utility.Asset RenderAppearance { get { return new Autodesk.Revit.Utility.Asset(); } set { } }
                public int Shininess { get { return 0; } set {  } }
                public int Smoothness { get { return 0; } set { } }
                //public FillPattern SurfacePattern { get; set; }
                //public Color SurfacePatternColor { get; set; }
                public int Transparency { get { return 0; } set { } }

                //protected override void Dispose(bool value);
                //public abstract Material Duplicate(string name);
            }
            public class HostObject : Element
            {
                //protected override void Dispose(bool value);
            }
            public class MaterialSet
            {
                public virtual IEnumerator GetEnumerator() { return null; }
            }
            public class Element 
            {
                public Category Category { get { return new Category();} }
                //public DesignOption DesignOption { get; }
                public Document Document { get{ return new Document();} }
                //public Group Group { get; }
                public ElementId Id { get { return new ElementId(); } }
                //public Level Level { get; }
                //public virtual Location Location { get; }
                public MaterialSet Materials { get { return new MaterialSet(); } }
                public virtual string Name { get {return "Element_Name";} set{} }
                //[Obsolete("Use Element.GetTypeId() and Element.ChangeTypeId() instead.")]
                //public ElementType ObjectType { get; set; }
                //public ElementId OwnerViewId { get; }
                public ParameterSet Parameters { get { return new ParameterSet(); } }
                //public ParameterMap ParametersMap { get; }
                public Phase PhaseCreated { get { return new Phase();} }
                //public Phase PhaseDemolished { get; }
                //public bool Pinned { get; }
                //[Obsolete("Use Element.GetValidTypes() instead.")]
                //public virtual ElementSet SimilarObjectTypes { get; }
                //public string UniqueId { get; }
                //public bool ViewSpecific { get; }

                //public bool CanBeHidden(View pView);
                //public bool CanHaveAnalyticalModel();
                //public bool CanHaveTypeAssigned();
                //public static bool CanHaveTypeAssigned(Document document, ICollection<ElementId> elementIds);
                //public ElementId ChangeTypeId(ElementId typeId);
                //public static IDictionary<ElementId, ElementId> ChangeTypeId(Document document, ICollection<ElementId> elementIds, ElementId typeId);
                //public void Dispose() { }
                //protected virtual void Dispose(bool value){ }
                //public BoundingBoxXYZ get_BoundingBox(View value);
                public GeometryElement get_Geometry(Options options) { return new GeometryElement(); }
                //public Parameter get_Parameter(BuiltInParameter parameterId);
                //public Parameter get_Parameter(Definition definition);
                //public Parameter get_Parameter(Guid guid);
                //public Parameter get_Parameter(string paramName);
                //public AnalyticalModel GetAnalyticalModel();
                //protected virtual BoundingBoxXYZ getBoundingBox(View view);
                //public static ChangeType GetChangeTypeAny();
                //public static ChangeType GetChangeTypeElementAddition();
                //public static ChangeType GetChangeTypeElementDeletion();
                //public static ChangeType GetChangeTypeGeometry();
                //public static ChangeType GetChangeTypeParameter(Parameter param);
                //public DividedSurfaceData GetDividedSurfaceData();
                //public double GetMaterialArea(Material material);
                //public double GetMaterialVolume(Material material);
                //public IList<ElementId> GetMonitoredLinkElementIds();
                //public IList<ElementId> GetMonitoredLocalElementIds();
                //protected Element* getNativeObject();
                public ElementId GetTypeId() { return new ElementId(); }
                //public ICollection<ElementId> GetValidTypes();
                //public static ICollection<ElementId> GetValidTypes(Document document, ICollection<ElementId> elementIds);
                //public bool IsHidden(View pView);
                //public bool IsMonitoringLinkElement();
                //public bool IsMonitoringLocalElement();
                //public bool IsValidType(ElementId typeId);
                //public static bool IsValidType(Document document, ICollection<ElementId> elementIds, ElementId typeId);
                //protected virtual void ReleaseUnmanagedResources(bool disposing);
            }
            public class UV
            {
                public UV() { }
                public double U { get {return 0 ;} }
                public double V { get { return 0; } }
                public virtual IEnumerator GetEnumerator() { return null; }
            }
            public class Edge
            {
                public virtual IEnumerator GetEnumerator() { return null; }
                public IList<UV> TessellateOnFace(Face face) 
                { 
                    UV[] _contents = new UV[8];
                    return _contents; }
            }
            public class EdgeArray
            {
                public virtual IEnumerator GetEnumerator() { return null; }
            }
            public class EdgeArrayArray
            {
                public virtual IEnumerator GetEnumerator() { return null; }
            }
            public class Face : GeometryObject
            {
                //public double Area { get; }
                public EdgeArrayArray EdgeLoops { get{return new EdgeArrayArray();} }
                //public virtual bool IsTwoSided { get; }
                public Material MaterialElement { get { return new Material(); } }
                //public Reference Reference { get; }

                //public Transform ComputeDerivatives(UV point);
                //public XYZ ComputeNormal(UV point);
                //public XYZ Evaluate(UV @params);
                //public bool get_IsCyclic(int paramIdx);
                //public double get_Period(int paramIdx);
                //public BoundingBoxUV GetBoundingBox();
                //public SetComparisonResult Intersect(Curve curve);
                //public SetComparisonResult Intersect(Curve curve, out IntersectionResultArray results);
                //public bool IsInside(UV point);
                //public bool IsInside(UV point, out IntersectionResult result);
                //public IntersectionResult Project(XYZ point);
                public Mesh Triangulate() { return new Mesh(); }
            }
            public class MeshTriangle : APIObject
            {
                public uint get_Index(int idx) { return 0; }
                public XYZ get_Vertex(int idx) { return new XYZ(); }
            }
            public class Curve : GeometryObject
            {
            }
            public class Mesh : GeometryObject
            {
                public int NumTriangles { get { return 0; } }
                //public IList<XYZ> Vertices { get; }

                //protected override void Dispose(bool value);
                //public Mesh get_Transformed(Transform transform);
                public MeshTriangle get_Triangle(int idx) { return new MeshTriangle(); }
            }

            public class FaceArray
            {
                public virtual int Size { get { return 0; } }
                public virtual IEnumerator GetEnumerator() { return null; }
            }
            public class Solid : GeometryObject
            {
                //public EdgeArray Edges { get; }
                public FaceArray Faces { get { return new FaceArray(); } }
                //public double SurfaceArea { get; }
                //public double Volume { get; }
            }
            public class DoubleArray : APIObject, IEnumerable
            {
                //public DoubleArray();

                //public virtual bool IsEmpty { get; }
                public virtual int Size { get{return 0;} }

                //public virtual void Append(ref double item);
                //public virtual void Clear();
                //protected override void Dispose(bool value);
                //public virtual DoubleArrayIterator ForwardIterator();
                //public virtual double get_Item(int index);
                public virtual IEnumerator GetEnumerator() { return null; }
                //public virtual void Insert(ref double item, int index);
                //protected override void ReleaseUnmanagedResources();
                //public virtual DoubleArrayIterator ReverseIterator();
                //public virtual void set_Item(int index, double item);
            }
            public class View : Element
            {
                //public ElementId AnalysisDisplayStyleId { get; set; }
                //public bool CanBePrinted { get; }
                //public BoundingBoxXYZ CropBox { get; set; }
                //public bool CropBoxActive { get; set; }
                //public bool CropBoxVisible { get; set; }
                //public Level GenLevel { get; }
                //public bool IsTemplate { get; }
                //public XYZ Origin { get; }
                //public BoundingBoxUV Outline { get; }
                //public XYZ RightDirection { get; }
                //public int Scale { get; set; }
                //public SketchPlane SketchPlane { get; set; }
                //public SunAndShadowSettings SunAndShadowSettings { get; }
                //public XYZ UpDirection { get; }
                //public XYZ ViewDirection { get; }
                //public string ViewName { get; set; }
                //public ViewType ViewType { get; }

                //public void ApplyTemplate(View viewTemplate);
                //public Color get_CutColorOverrideByElement(ICollection<ElementId> ids);
                //public LinePattern get_CutLinePatternOverrideByElement(ICollection<ElementId> ids);
                //public int get_CutLineWeightOverrideByElement(ICollection<ElementId> ids);
                //public Color get_ProjColorOverrideByElement(ICollection<ElementId> ids);
                //public LinePattern get_ProjLinePatternOverrideByElement(ICollection<ElementId> ids);
                //public int get_ProjLineWeightOverrideByElement(ICollection<ElementId> ids);
                //protected override BoundingBoxXYZ getBoundingBox(View view);
                //public bool getVisibility(Category category);
                //public void Hide(ElementSet elemSet);
                //public void HideActiveWorkPlane();
                //public void Print();
                //public void Print(bool useCurrentPrintSettings);
                //public void Print(View viewTemplate);
                //public void Print(View viewTemplate, bool useCurrentPrintSettings);
                //public void set_CutColorOverrideByElement(ICollection<ElementId> ids, Color color);
                //public void set_CutLinePatternOverrideByElement(ICollection<ElementId> ids, LinePattern linePattern);
                //public void set_CutLineWeightOverrideByElement(ICollection<ElementId> ids, int weight);
                //public void set_ProjColorOverrideByElement(ICollection<ElementId> ids, Color color);
                //public void set_ProjLinePatternOverrideByElement(ICollection<ElementId> ids, LinePattern linePattern);
                //public void set_ProjLineWeightOverrideByElement(ICollection<ElementId> ids, int weight);
                //public void setVisibility(Category category, bool visible);
                //public void ShowActiveWorkPlane();
                //public void Unhide(ElementSet elemSet);
            }
            public class Document 
            {
                //public ProjectLocation ActiveProjectLocation { get; set; }
                //public View ActiveView { get; }
                //public AnnotationSymbolTypeSet AnnotationSymbolTypes { get; }
                //public Application Application { get; }
                //public BeamSystemTypeSet BeamSystemTypes { get; }
                //public ContFootingTypeSet ContFootingTypes { get; }
                //public Autodesk.Revit.Creation.Document Create { get; }
                //public CurtainSystemTypeSet CurtainSystemTypes { get; }
                //public FamilySymbolSet DeckProfiles { get; }
                //public DimensionTypeSet DimensionTypes { get; }
                //public DisplayUnit DisplayUnitSystem { get; }
                //public FamilySymbolSet ElectricalEquipmentTypes { get; }
                //public FamilyItemFactory FamilyCreate { get; }
                //public FamilyManager FamilyManager { get; }
                //public FasciaTypeSet FasciaTypes { get; }
                //public FloorTypeSet FloorTypes { get; }
                //public GridTypeSet GridTypes { get; }
                //public GutterTypeSet GutterTypes { get; }
                //public bool IsFamilyDocument { get; }
                //public bool IsModifiable { get; }
                //public bool IsModified { get; }
                //public bool IsReadOnly { get; }
                //public bool IsReadOnlyFile { get; }
                //public bool IsWorkshared { get; }
                //public LevelTypeSet LevelTypes { get; }
                //public FamilySymbolSet LightingDeviceTypes { get; }
                //public FamilySymbolSet LightingFixtureTypes { get; }
                //public FamilySymbolSet MechanicalEquipmentTypes { get; }
                //public MullionTypeSet MullionTypes { get; }
                //public Family OwnerFamily { get; }
                //public PanelTypeSet PanelTypes { get; }
                //public BindingMap ParameterBindings { get; }
                //public string PathName { get; }
                //public PhaseArray Phases { get; }
                //public PlanTopologySet PlanTopologies { get; }
                //public PrintManager PrintManager { get; }
                //public ElementSet PrintSettings { get; }
                //public ProjectInfo ProjectInformation { get; }
                //public ProjectLocationSet ProjectLocations { get; }
                //public ProjectUnit ProjectUnit { get; }
                //public bool ReactionsAreUpToDate { get; }
                //public RebarBarTypeSet RebarBarTypes { get; }
                //public RebarCoverTypeSet RebarCoverTypes { get; }
                //public RebarHookTypeSet RebarHookTypes { get; }
                //public RebarShapeSet RebarShapes { get; }
                //public RoofTypeSet RoofTypes { get; }
                //public RoomTagTypeSet RoomTagTypes { get; }
                //public Settings Settings { get; }
                //public SiteLocation SiteLocation { get; }
                //public SlabEdgeTypeSet SlabEdgeTypes { get; }
                //public SpaceTagTypeSet SpaceTagTypes { get; }
                //public SpotDimensionTypeSet SpotDimensionTypes { get; }
                //public TextNoteTypeSet TextNoteTypes { get; }
                public string Title { get { return "Ok";} }
                //public FamilySymbolSet TitleBlocks { get; }
                //public TrussTypeSet TrussTypes { get; }
                //public WallTypeSet WallTypes { get; }
                //public ViewSheetSets ViewSheetSets { get; }
                //public string WorksharingCentralFilename { get; }

                //public event EventHandler<DocumentClosingEventArgs> DocumentClosing;
                //public event EventHandler<DocumentPrintedEventArgs> DocumentPrinted;
                //public event EventHandler<DocumentPrintingEventArgs> DocumentPrinting;
                //public event EventHandler<DocumentSavedEventArgs> DocumentSaved;
                //public event EventHandler<DocumentSavedAsEventArgs> DocumentSavedAs;
                //public event EventHandler<DocumentSavingEventArgs> DocumentSaving;
                //public event EventHandler<DocumentSavingAsEventArgs> DocumentSavingAs;
                //public event EventHandler<ViewPrintedEventArgs> ViewPrinted;
                //public event EventHandler<ViewPrintingEventArgs> ViewPrinting;

                //public RadialArray Array(Element element, int number, bool moveToLast, double angle);
                //public LinearArray Array(Element element, int number, bool moveToLast, XYZ moveVec);
                //public RadialArray Array(ElementId elementId, int number, bool moveToLast, double angle);
                //public LinearArray Array(ElementId elementId, int number, bool moveToLast, XYZ moveVec);
                //public RadialArray Array(ElementSet elements, int number, bool moveToLast, double angle);
                //public LinearArray Array(ElementSet elements, int number, bool moveToLast, XYZ moveVec);
                //public RadialArray Array(ICollection<ElementId> elementIds, int number, bool moveToLast, double angle);
                //public LinearArray Array(ICollection<ElementId> elementIds, int number, bool moveToLast, XYZ moveVec);
                //public ElementSet ArrayWithoutAssociate(Element element, int number, bool moveToLast, double angle);
                //public ElementSet ArrayWithoutAssociate(Element element, int number, bool moveToLast, XYZ moveVec);
                //public ElementSet ArrayWithoutAssociate(ElementId elementId, int number, bool moveToLast, double angle);
                //public ElementSet ArrayWithoutAssociate(ElementId elementId, int number, bool moveToLast, XYZ moveVec);
                //public ElementSet ArrayWithoutAssociate(ElementSet elements, int number, bool moveToLast, double angle);
                //public ElementSet ArrayWithoutAssociate(ElementSet elements, int number, bool moveToLast, XYZ moveVec);
                //public ElementSet ArrayWithoutAssociate(ICollection<ElementId> elementIds, int number, bool moveToLast, double angle);
                //public ElementSet ArrayWithoutAssociate(ICollection<ElementId> elementIds, int number, bool moveToLast, XYZ moveVec);
                //public void AutoJoinElements();
                //public bool Close();
                //public bool Close(bool saveModified);
                //public GeomCombination CombineElements(CombinableElementArray members);
                //public ModelCurveArray ConvertDetailToModelCurves(View view, DetailCurveArray detailCurves);
                //public DetailCurveArray ConvertModelToDetailCurves(View view, ModelCurveArray modelCurves);
                //public SymbolicCurveArray ConvertModelToSymbolicCurves(View view, ModelCurveArray modelCurves);
                //public ModelCurveArray ConvertSymbolicToModelCurves(View view, SymbolicCurveArray symbolicCurve);
                //public ICollection<ElementId> Delete(Element element);
                //public ICollection<ElementId> Delete(ElementId id);
                //public ICollection<ElementId> Delete(ElementSet elements);
                //public ICollection<ElementId> Delete(ICollection<ElementId> ids);
                //public void Dispose() { }
                //protected virtual void Dispose(bool value) { }
                //public Document EditFamily(Family loadedFamily);
                //public bool Export(string folder, string name, GBXMLExportOptions options);
                //public bool Export(string folder, string name, IFCExportOptions options);
                //public bool Export(string folder, string name, ViewSet views, DGNExportOptions options);
                //public bool Export(string folder, string name, ViewSet views, DWFExportOptions options);
                //public bool Export(string folder, string name, ViewSet views, DWFXExportOptions options);
                //public bool Export(string folder, string name, ViewSet views, DWGExportOptions options);
                //public bool Export(string folder, string name, ViewSet views, DXFExportOptions options);
                //public bool Export(string folder, string name, ViewSet views, FBXExportOptions options);
                //public bool Export(string folder, string name, ViewSet views, SATExportOptions options);
                //public bool Export(string folder, string name, View3D view, ViewPlan grossAreaPlan, BuildingSiteExportOptions options);
                //public void ExportImage(ImageExportOptions options);
                //public ReferenceArray FindReferencesByDirection(XYZ pOrigin, XYZ pDirection, View3D pView);
                public Element get_Element(ElementId id) { return new Element(); }
                //public Element get_Element(string value);
                //public PlanTopologySet get_PlanTopologies(Phase phase);
                //public PlanTopology get_PlanTopology(Level level);
                //public PlanTopology get_PlanTopology(Level level, Phase phase);
                //public StorageType get_TypeOfStorage(BuiltInParameter value);
                //protected ADocument* getNativeObject();
                //public Room GetRoomAtPoint(XYZ point);
                //public Room GetRoomAtPoint(XYZ point, Phase phase);
                //public Space GetSpaceAtPoint(XYZ point);
                //public Space GetSpaceAtPoint(XYZ point, Phase phase);
                //public bool Import(string file, GBXMLImportOptions options);
                //public bool Import(string file, InventorImportOptions options);
                //public bool Import(string file, DWGImportOptions options, out Element element);
                //public bool Import(string file, ImageImportOptions options, out Element element);
                //public bool Link(string file, DWGImportOptions options, out Element element);
                //public Family LoadFamily(Document targetDocument);
                //public bool LoadFamily(string filename);
                //public Family LoadFamily(Document targetDocument, IFamilyLoadOptions familyLoadOptions);
                //public bool LoadFamily(string filename, out Family family);
                //public bool LoadFamily(string filename, IFamilyLoadOptions familyLoadOptions, out Family family);
                //public bool LoadFamilySymbol(string filename, string name);
                //public bool LoadFamilySymbol(string filename, string name, out FamilySymbol symbol);
                //public bool LoadFamilySymbol(string filename, string name, IFamilyLoadOptions familyLoadOptions, out FamilySymbol symbol);
                //public bool Mirror(Element element, Reference reference);
                //public bool Mirror(ElementId id, Reference reference);
                //public bool Mirror(ElementSet elements, Line line);
                //public bool Mirror(ElementSet elements, Reference reference);
                //public bool Mirror(ICollection<ElementId> ids, Reference reference);
                //public bool Move(Element element, XYZ translationVec);
                //public bool Move(ElementId id, XYZ translationVec);
                //public bool Move(ElementSet elements, XYZ translationVec);
                //public bool Move(ICollection<ElementId> ids, XYZ translationVec);
                //public FailureMessageKey PostFailure(FailureMessage failure);
                //public void Print(ViewSet views);
                //public void Print(ViewSet views, bool useCurrentPrintSettings);
                //public void Print(ViewSet views, View viewTemplate);
                //public void Print(ViewSet views, View viewTemplate, bool useCurrentPrintSettings);
                //public void Regenerate();
                //protected virtual void ReleaseUnmanagedResources(bool disposing);
                //protected virtual void ReleaseUnmanagedResources_(bool disposing);
                //public bool Rotate(Element element, Line axis, double angle);
                //public bool Rotate(ElementId id, Line axis, double angle);
                //public bool Rotate(ElementSet elements, Line axis, double angle);
                //public bool Rotate(ICollection<ElementId> ids, Line axis, double angle);
                //public bool Save();
                //public bool SaveAs();
                //public bool SaveAs(string fileName);
                //public bool SaveAs(string fileName, bool changeDocumentFilename);
                //public ElementId SaveToProjectAsImage(ImageExportOptions options);
                //public void SeparateElements(CombinableElementArray members);
                //public void UnpostFailure(FailureMessageKey messageKey);
            }
            public class ElementId
            {
                //public ElementId(BuiltInCategory categoryId);
                //public ElementId(BuiltInParameter parameterId);
                //public ElementId(int id);

                //public static bool operator !=(ElementId first, ElementId second);
                //public static bool operator <(ElementId elementId1, ElementId elementId2);
                //public static bool operator <=(ElementId elementId1, ElementId elementId2);
                //public static bool operator ==(ElementId first, ElementId second);
                //public static bool operator >(ElementId elementId1, ElementId elementId2);
                //public static bool operator >=(ElementId elementId1, ElementId elementId2);

                public int IntegerValue { get { return 0; } }
                //public static ElementId InvalidElementId { get; }

                //public int Compare(ElementId id);
                //public override bool Equals(object obj);
                //public override int GetHashCode();
                //public override string ToString();
            }
            public class FilteredElementCollector 
            {
                public FilteredElementCollector(Document document) { }
                //public FilteredElementCollector(Document document, ElementId viewId);
                //public FilteredElementCollector(Document document, ICollection<ElementId> elementIds);

                //public FilteredElementCollector ContainedInDesignOption(ElementId designOptionId);
                //public void Dispose() { }
                //protected virtual void Dispose(bool value) { }
                //public FilteredElementCollector Excluding(ICollection<ElementId> idsToExclude);
                //public Element FirstElement();
                //public ElementId FirstElementId();
                //public FilteredElementIdIterator GetElementIdIterator();
                //public FilteredElementIterator GetElementIterator();
                //public IEnumerator<Element> GetEnumerator()
                //{
                //    Element[] Se=new Element[2];
                //    foreach (Element s in Se)
                //    {
                //        yield return s;
                //    }
                //}
                //protected FilteredElementCollector* getNativeObject();
                //public FilteredElementCollector IntersectWith(FilteredElementCollector other);
                //public static bool IsViewValidForElementIteration(Document document, ElementId viewId);
                //public FilteredElementCollector OfCategory(BuiltInCategory category);
                //public FilteredElementCollector OfCategoryId(ElementId categoryId);
                //public FilteredElementCollector OfClass(Type type);
                //public FilteredElementCollector OwnedByView(ElementId viewId);
                //protected virtual void ReleaseUnmanagedResources(bool disposing);
                //public ICollection<ElementId> ToElementIds();
                public IList<Element> ToElements() 
                {
                    Element[] _Colle = new Element[8];

                    return _Colle; 
                }
                //public FilteredElementCollector UnionWith(FilteredElementCollector other);
                //public FilteredElementCollector WhereElementIsCurveDriven();
                //public FilteredElementCollector WhereElementIsElementType();
                public FilteredElementCollector WhereElementIsNotElementType() { return new FilteredElementCollector(new Document() ); }
                //public FilteredElementCollector WhereElementIsViewIndependent();
                //public FilteredElementCollector WherePasses(ElementFilter filter);
            }
            public class Options : APIObject
            {
                //public Options();
                //public Options(Options pOptions);

                //public bool ComputeReferences { get; set; }
                //public DetailLevels DetailLevel { get; set; }
                //public bool IncludeNonVisibleObjects { get; set; }
                //public View View { get; set; }

                //protected override void ReleaseUnmanagedResources();
            }
            public class Phase : Element
            {
            }
            public class FamilySymbol : Element
            {
                public Family Family { get{return new Family();} }
            //    public StructuralMaterialType StructuralMaterialType { get; }

            //    public IList<FamilyPointLocation> GetFamilyPointLocations();
            }
            public class Category : APIObject
            {
                //public bool AllowsBoundParameters { get; }
                //public bool CanAddSubcategory { get; }
                //public bool HasMaterialQuantities { get; }
                //public ElementId Id { get; }
                //public bool IsCuttable { get; }
                //public Color LineColor { get; set; }
                public Material Material { get {return new Material() ;} set { } }
                public string Name { get { return "Caterory_Name"; } }
                //public Category Parent { get; }
                //public CategoryNameMap SubCategories { get; }

                //public bool get_AllowsVisibilityControl(View view);
                //public bool get_Visible(View view);
                //public GraphicsStyle GetGraphicsStyle(GraphicsStyleType graphicsStyleType);
                //public override int GetHashCode();
                //public int? GetLineWeight(GraphicsStyleType graphicsStyleType);
                //protected override void ReleaseUnmanagedResources();
                //public void set_Visible(View view, bool visible);
                //public void SetLineWeight(int lineWeight, GraphicsStyleType graphicsStyleType);
            }
            public class Family : FamilyBase
            {
                //public double CurtainPanelHorizontalSpacing { get; set; }
                //public TilePatternsBuiltIn CurtainPanelTilePattern { get; }
                //public double CurtainPanelVerticalSpacing { get; set; }
                //public bool IsConceptualMassFamily { get; }
                //public bool IsCurtainPanelFamily { get; }
                //public bool IsEditable { get; }
                //public bool IsInPlace { get; }
                //public FamilySymbolSet Symbols { get; }

                //public void ExtractPartAtom(string xmlFilePath);
            }
            public class FamilyBase : Element
            {
                public Category FamilyCategory { get {return new Category() ;} }
                //public StructuralMaterialType StructuralMaterialType { get; }
            }
            public class TopographySurface : Element
            {
                //public void AddPoints(IList<XYZ> points);
            }
            public class ParameterSet 
            {
                //public ParameterSet();

                //public virtual bool IsEmpty { get; }
                //public virtual int Size { get; }

                //public virtual void Clear();
                //public virtual bool Contains(Parameter item);
                //protected override void Dispose(bool value);
                //public virtual int Erase(Parameter item);
                //public virtual ParameterSetIterator ForwardIterator();
                public virtual IEnumerator GetEnumerator() { return null; }
                //public virtual bool Insert(Parameter item);
                //protected override void ReleaseUnmanagedResources();
                //public virtual ParameterSetIterator ReverseIterator();
            }
            public class Parameter : APIObject
            {
                public Definition Definition { get { return new Definition(); } }
                //public DisplayUnitType DisplayUnitType { get; }
                //public Element Element { get; }
                //public Guid GUID { get; }
                //public ElementId Id { get; }
                //public override bool IsReadOnly { get; }
                //public bool IsShared { get; }
                //public StorageType StorageType { get; }

                //public double AsDouble();
                public ElementId AsElementId() { return new ElementId(); }
                //public int AsInteger();
                //public string AsString();
                //public string AsValueString();
                //protected override void Dispose(bool value);
                //protected virtual void ReleaseUnmanagedResources(bool disposing);
                //public bool Set(double value);
                //public bool Set(ElementId value);
                //public bool Set(int value);
                //public bool Set(string value);
                //public bool SetValueString(string valueString);
            }
            public class Definition 
            {
                public string Name { get { return "Definition_Name"; } }
                //public abstract BuiltInParameterGroup ParameterGroup { get; }
                //public abstract ParameterType ParameterType { get; }
            }
        }
    }
}
