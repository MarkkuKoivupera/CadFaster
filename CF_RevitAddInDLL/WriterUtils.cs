using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Utility;



namespace ExeWriter
{

    class WriterUtils
    {

        #region Extra Members Implementation
        class cl_ElementData
        {
            double[] m_diffuse = new double[3];
            public double[] Diffuse
            {
                get
                {
                    return m_diffuse;
                }
                set
                {
                    m_diffuse = value;
                }
            }
            //UInt32 m_UFaces;
            //public UInt32 uPartFaceCount
            //{
            //    get
            //    {
            //        return m_UFaces;
            //    }
            //    set
            //    {
            //        m_UFaces = value;
            //    }
            //}

        }
        #endregion Extra Members Implementation
        #region const variables
        const int cAmbientR = 0;
        const int cDiffuseR = 3;
        const int cSpecularR = 6;
        const int cShininess = 9;
        const int cTransparency = 10;
        const int cEmissionR = 3;
        #endregion const variables
        #region IExternalCommand Members Implementation
        private String ExportFileName;
        private List<double> Lid_Vertices = new List<double>();
        private List<double> Lid_Normals = new List<double>();
        private List<double> Lid_TextureCoords = new List<double>();
        private List<double> Lid_FeatureMaterial = new List<double>();
        private List<uint> Liu_Indices = new List<uint>();
        private List<uint> Liu_FeatureIndex = new List<uint>();
        private List<String> Listr_Nodes = new List<String>();
        private Dictionary<String, cl_ElementData> Dic_MaterialElementData = new Dictionary<String, cl_ElementData>();
        private Outwriter writeData = new Outwriter();
        Frm_Progress fr_Progress = null;
        //private progress fr_status = new progress();
        #endregion IExternalCommand Members Implementation
        
        public Result HandleData(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Retrieves the current active project.
                Autodesk.Revit.UI.UIApplication app = commandData.Application;
                UIDocument doc = app.ActiveUIDocument;
                
                //revitApp = app
                Autodesk.Revit.DB.View view = commandData.View;
                String ApplicationName = doc.Document.Title;
                String WievName = view.Document.Title;
                //Initialize RenderAppearancesForm
                CF_WriterForm form = new CF_WriterForm();
                form.ExportFileName = ApplicationName;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return Autodesk.Revit.UI.Result.Cancelled;
                }
                
                ExportFileName = form.ExportFileName;
                // Generate a object for Revit materials management.
                //MaterialsMgr materialsManager = new MaterialsMgr(doc, app);
                fr_Progress = new Frm_Progress();
                // Feed a MaterialsMgr to a dialog
                
                Application.DoEvents();
                //fr_Progress.progressing_Shown(this, what);
                fr_Progress.Show();
                fr_Progress.prosessProgressBar(ExportFileName);
                MakeConvertToHSF(app,doc);
                EndProsess();
                fr_Progress.Close();
                //fr_status.Close();
                // Revit need to do nothing.
                return Autodesk.Revit.UI.Result.Succeeded;

            }//try
            catch (Exception e)
            {
                fr_Progress.Close();
                // Exception rised, report it by revit error reporting mechanism. 
                message = "Execute/MakeConvertToHSF fails for Reason:" + Environment.NewLine + e.ToString(); ;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                return Autodesk.Revit.UI.Result.Failed;
            }
        }
        private void MakeConvertToHSF(UIApplication app, UIDocument doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc.Document);
            ICollection<Element> AllElements = collector.WhereElementIsNotElementType().ToElements();
            //fr_status.StartProgressBar(AllElements.Count);
            ArrayList objs = new ArrayList();
            Autodesk.Revit.DB.GeometryElement GeomElem = null;
            Autodesk.Revit.DB.GeometryElement CatElem = null;
            //Autodesk.Revit.DB.Options Opts= new Options();
            Autodesk.Revit.DB.Options geomOp = app.Application.Create.NewGeometryOptions();
            writeData.Init(ExportFileName);

            Autodesk.Revit.DB.GeometryInstance instance = null;
            Material materialElement = null;
            fr_Progress.StartProgressBar(AllElements.Count);
            int iElementCount = 0;

            foreach (Element element in AllElements)
            {
                fr_Progress.AddValueProgressBar(iElementCount++);
                instance = null;

                //fr_status.UpDateProgressBar(iCurrentElementCount++);
                Autodesk.Revit.DB.Phase phaseCreated = element.PhaseCreated;
                if (null != phaseCreated)
                {
                    if (element is TopographySurface)
                    {
                        //materialElement = element.Category.Material;
                        foreach (Parameter par in element.Parameters)
                        {
                            if ("Material" == par.Definition.Name)
                            {
                                ElementId Id = par.AsElementId();
                                if (-1 != Id.IntegerValue)
                                {
                                    Element eleMat = doc.Document.get_Element(Id);
                                    materialElement = eleMat as Material;
                                }
                                else
                                {
                                    materialElement = element.Category.Material;
                                }
                              //materialElement = materials.get_Item(Id);
                            }

                        }
                        
                    }
                    GeomElem = element.get_Geometry(geomOp);
                    if (null == GeomElem)
                    {
                        TopographySurface TyPo = element as TopographySurface;
                        if (null == TyPo)
                        {
                            HostObject HostOb = element as HostObject;
                            if (null == HostOb)
                            {
                            }//if (null == HostOb)
                            else
                                GeomElem = HostOb.get_Geometry(geomOp);
                        }//if (null == TyPo)
                        else
                            GeomElem = TyPo.get_Geometry(geomOp);
                    }//if (null == GeomElem)
                    if (null != GeomElem)
                    {
                        HandleGeometryElement(GeomElem, ref instance, doc, materialElement);
                    }//if (null != GeomElem)

                    if (null != GeomElem || null != CatElem)
                    {
                        SendData(element, instance);
                        //objs.Add(element);
                        Lid_Vertices.Clear();
                        Lid_Normals.Clear();
                        Lid_TextureCoords.Clear();
                        Lid_FeatureMaterial.Clear();
                        Liu_Indices.Clear();
                        Liu_FeatureIndex.Clear();
                    }//if (null != GeomElem)
                }//if (null != phaseCreated)
            }// foreach (Element element in AllElements)

            //System.Diagnostics.Trace.WriteLine(AllElements.Count.ToString());
            //CF_WriterForm form = new CF_WriterForm(objs);
            //form.ShowDialog();
            //using (MaterialsForm dlg = new MaterialsForm(materialsManager,commandData))
            //{
        }
        private void HandleGeometryElement(GeometryElement GeomElem, ref  GeometryInstance instance, UIDocument doc, Material materialElement)
        {
            //GeomElem = element.get_Geometry(Opts);
            int iObjectCount = 0;
            fr_Progress.SetProBarObjects(GeomElem.Objects.Size);
            Application.DoEvents();
            foreach (GeometryObject geomObj in GeomElem.Objects)
            {
                fr_Progress.AddValueProBarObjects(++iObjectCount);
                if (geomObj is Curve)
                {
                    continue;
                }

                if (geomObj is Mesh)
                {
                    AddFaceMaterial(materialElement, doc);
                    Mesh geomMesh = geomObj as Mesh;
                    MeshProcess(geomMesh);
                }
                if (geomObj is Solid)
                {
                    Solid geomSolid = geomObj as Solid;
                    SolidProcess(geomSolid, doc, materialElement);
                }

                if (geomObj is GeometryInstance)
                {
                    
                    instance = geomObj as GeometryInstance;
                    
                    foreach (GeometryObject InstanObj in instance.SymbolGeometry.Objects)
                    {
                        
                        if ("Window_Insert" == instance.Symbol.Name)
                        {

                            foreach (Material mats in instance.Symbol.Materials)
                                materialElement = mats;
                        }
                        if (InstanObj is Curve)
                        {
                            // transfrom the curve to make it in the instance's coordinate space 
                            continue;
                        }
                        if (InstanObj is Solid)
                        {
                            Solid geomSolid = InstanObj as Solid;
                            // transfrom the curve to make it in the instance's coordinate space 
                            SolidProcess(geomSolid, doc, materialElement);
                        }
                    }
                }
               
                    

            }
        }
        private void TextureCoord(Face geomFace)
        {
            //BoundingBoxUV boundBox = geomFace.GetBoundingBox();
            //UV minBounds=boundBox.get_Bounds(0);
            //Lid_TextureCoords.Add(minBounds.U);
            //Lid_TextureCoords.Add(minBounds.U);
            //UV maxBounds = boundBox.get_Bounds(1);
            //Lid_TextureCoords.Add(maxBounds.U);
            //Lid_TextureCoords.Add(maxBounds.U);
            foreach (EdgeArray geomEdges in geomFace.EdgeLoops)
            {
                foreach (Edge geomEdge in geomEdges)
                {
                    foreach (UV geomUV in geomEdge.TessellateOnFace(geomFace))
                    {
                        Lid_TextureCoords.Add(geomUV.U);
                        Lid_TextureCoords.Add(geomUV.V);
                    }
                }
            }
        }
        private XYZ NormVect(MeshTriangle triangle)
        {
            XYZ vertex0 = triangle.get_Vertex(0);
            XYZ vertex1 = triangle.get_Vertex(1);
            XYZ vertex2 = triangle.get_Vertex(2);
            XYZ VecPoi1 = vertex1 - vertex0;
            XYZ VecPoi2 = vertex2 - vertex0;
            XYZ CP = VecPoi1.CrossProduct(VecPoi2);
            XYZ Nor = CP.Normalize();
            return Nor;
        }


        private void MeshProcess(Mesh geomMesh)
        {
            try
            {
                uint iStartId = (uint)Lid_Vertices.Count;

                uint iNextId = iStartId / 3;
                fr_Progress.SetProBarData(geomMesh.NumTriangles);
                for (int i = 0; i < geomMesh.NumTriangles; i++)
                {
                    fr_Progress.AddValueProBarData(i+1);
                    MeshTriangle triangle = geomMesh.get_Triangle(i);
                    XYZ vertex = triangle.get_Vertex(0);
                    Liu_Indices.Add(3);
                    AddVertex(iStartId, vertex, iNextId++);
                    vertex = triangle.get_Vertex(1);
                    AddVertex(iStartId, vertex, iNextId++);
                    vertex = triangle.get_Vertex(2);
                    AddVertex(iStartId, vertex, iNextId++);
                    XYZ normal = NormVect(triangle);
                    for (int inorms = 0; inorms < 3; inorms++)
                    {
                        Lid_Normals.Add(normal.X);
                        Lid_Normals.Add(normal.Y);
                        Lid_Normals.Add(normal.Z);
                        //Lid_TextureCoords.Add(normal.X);
                        //Lid_TextureCoords.Add(normal.Y);
                        //Lid_TextureCoords.Add(normal.Z);
                    }
                }
                Liu_FeatureIndex.Add((uint)geomMesh.NumTriangles * 3);

            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "MeshProcess fails for Reason:" + Environment.NewLine;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                message = e.ToString();
                //File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
            //End of MeshProcess
        }
        private void SolidProcess(Solid geomSolid, UIDocument doc, Material materialElement)
        {
            try
            {
                int icount = 0;
                fr_Progress.SetProBarFace(geomSolid.Faces.Size);
                foreach (Face geomFace in geomSolid.Faces)
                {
                    fr_Progress.AddValueProBarFace(++icount);
                    RevolvedFace revolvedFace = geomFace as RevolvedFace;
                    if (null != revolvedFace)
                    {
                    }
                    ConicalFace conicalFace = geomFace as ConicalFace;
                    if (null != conicalFace)
                    {
                    }
                    CylindricalFace cylindricalFace = geomFace as CylindricalFace;
                    if (null != cylindricalFace)
                    {
                    }
                    HermiteFace hermiteFace = geomFace as HermiteFace;
                    if (null != hermiteFace)
                    {
                    }
                    RuledFace ruledFace = geomFace as RuledFace;
                    if (null != ruledFace)
                    {
                    }
                    if (null != geomFace.Reference)
                    {
                    }
                    Material materialElementNew = materialElement;
                    if (null != geomFace.MaterialElement)
                        materialElementNew = geomFace.MaterialElement as Material;
                    Mesh geomMesh = geomFace.Triangulate();
                    AddFaceMaterial(materialElementNew, doc);
                    MeshProcess(geomMesh);

                    TextureCoord(geomFace);
                }

            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "SolidProcess fails for Reason:" + Environment.NewLine;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                message = e.ToString();
                //File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
            //End of SolidProcess
        }

        private Double[] GetSystemArray(DoubleArray doubleArray)
        {
            double[] values = new double[doubleArray.Size];
            int index = 0;
            foreach (Double value in doubleArray)
            {
                values[index++] = value;
            }
            return values;
        }

        private void AddFaceMaterial(Material materialElement, UIDocument doc)
        {
            //string s = geomFace.MaterialElement.Name;
            //ElementId elementId = e.Id;
            //MaterialSet materials = e.Materials;
            //ElementId materialId = geomFace.MaterialElement.Id;
            //Material materialElement = doc.Document.get_Element(materialId) as Material;
            Asset m_asset = materialElement.RenderAppearance;
            double[] d_featureBase = { 1.0, 1.0, 1.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.0, 0.0, 0.0 };
            //shininess
            d_featureBase[cShininess] = (double)materialElement.Shininess / 128;
            d_featureBase[cTransparency] = 1.0 - (double)materialElement.Transparency / 100;
            d_featureBase[cAmbientR] = (double)materialElement.Color.Red / 255;
            d_featureBase[cAmbientR + 1] = (double)materialElement.Color.Green / 255;
            d_featureBase[cAmbientR + 2] = (double)materialElement.Color.Blue / 255;
            d_featureBase[cSpecularR] = (double)d_featureBase[cAmbientR] * materialElement.Smoothness / 100;
            d_featureBase[cSpecularR + 1] = (double)d_featureBase[cAmbientR+1] * materialElement.Smoothness / 100;
            d_featureBase[cSpecularR + 2] = (double)d_featureBase[cAmbientR+2] * materialElement.Smoothness / 100;
            Lid_FeatureMaterial.Add((double)Liu_FeatureIndex.Count + 1);
            cl_ElementData clED_Values;

            if (Dic_MaterialElementData.TryGetValue(materialElement.Name, out clED_Values))
            {
                for (int inex = 0; inex < 3; inex++)
                {
                    if (null != clED_Values)
                        d_featureBase[cDiffuseR + inex] = clED_Values.Diffuse[inex];
                }
            }
            else
            {
                clED_Values = new cl_ElementData();
                double[] ap = { 0.0, 0.0, 0.0 };
                clED_Values.Diffuse = ap;
                for (int index = 0; index < m_asset.Size; index++)
                {
                    AssetProperty m_assetProperty = m_asset[index];
                    if (null != m_assetProperty)
                    {
                        Type m_valueType;
                        Object m_value;
                        try
                        {
                            if (m_assetProperty is AssetPropertyDoubleArray4d)
                            {
                                AssetPropertyDoubleArray4d property = m_assetProperty as AssetPropertyDoubleArray4d;
                                //m_valueType = typeof(Double[]);
                                //m_value = GetSystemArray(property.Value); masonrycmu_color
                                if (m_assetProperty.Name == "generic_diffuse" ||
                                    m_assetProperty.Name == "masonrycmu_color" ||
                                    m_assetProperty.Name == "water_tint_color" ||
                                    m_assetProperty.Name == "ceramic_color" ||
                                    m_assetProperty.Name == "glazing_transmittance_map" ||
                                    m_assetProperty.Name == "concrete_color" ||
                                    m_assetProperty.Name == "plasticvinyl_color" ||
                                    m_assetProperty.Name == "hardwood_tint_color" ||
                                    m_assetProperty.Name == "metal_color" ||
                                    m_assetProperty.Name == "solidglass_transmittance_custom_color" ||
                                    m_assetProperty.Name == "wallpaint_color")
                                {
                                    double[] values = new double[property.Value.Size];
                                    int inro = 0;
                                    foreach (Double value in property.Value)
                                    {
                                        values[inro++] = value;
                                    }
                                    d_featureBase[cDiffuseR] = (double)d_featureBase[cAmbientR] * values[0];
                                    d_featureBase[cDiffuseR+1] = (double)d_featureBase[cAmbientR+1] * values[1];
                                    d_featureBase[cDiffuseR + 2] = (double)d_featureBase[cAmbientR+2] * values[2];
                                    for (int inex = 0; inex < 3; inex++)
                                    {
                                        //d_featureBase[cDiffuseR + inex] = values[inex];
                                        clED_Values.Diffuse[inex] = d_featureBase[cDiffuseR+inex];
                                    }
                                }
                            }
                            else if (m_assetProperty is AssetPropertyDoubleArray2d)
                            {
                                //Default, it is supported by PropertyGrid to display Double []
                                //Try to convert DoubleArray to Double []
                                AssetPropertyDoubleArray2d property = m_assetProperty as AssetPropertyDoubleArray2d;
                                m_valueType = typeof(Double[]);
                                m_value = GetSystemArray(property.Value);
                            }
                            else if (m_assetProperty is AssetPropertyDoubleArray3d)
                            {
                                AssetPropertyDoubleArray3d property = m_assetProperty as AssetPropertyDoubleArray3d;
                                m_valueType = typeof(Double[]);
                                m_value = GetSystemArray(property.Value);
                            }
                            else if (m_assetProperty is AssetPropertyDoubleMatrix44)
                            {
                                AssetPropertyDoubleMatrix44 property = m_assetProperty as AssetPropertyDoubleMatrix44;
                                m_valueType = typeof(Double[]);
                                m_value = GetSystemArray(property.Value);
                            }
                            else
                            {
                                //AssetPropertyTime property = m_assetProperty as AssetPropertyTime;
                                //m_valueType = typeof(DateTime);
                                //m_value = property.Value;
                            }
                        }
                        catch
                        {
                        }

                    }

                    //FOR
                }
                Dic_MaterialElementData.Add(materialElement.Name, clED_Values);
            }
            for (int i_i = 0; i_i < d_featureBase.Length; i_i++)
                Lid_FeatureMaterial.Add(d_featureBase[i_i]);

        }
        private void SendData(Element element, GeometryInstance instance)
        {
            //if no vertex, skip
            if (Lid_Vertices.Count == 0)
                return;
            try
            {
                double[] transformationMatrix = new double[16];
                if (null != instance)
                {
                    transformationMatrix[0] = instance.Transform.Scale * instance.Transform.BasisX.X;
                    transformationMatrix[1] = instance.Transform.Scale * instance.Transform.BasisX.Y;
                    transformationMatrix[2] = instance.Transform.Scale * instance.Transform.BasisX.Z;
                    transformationMatrix[3] = 0;
                    transformationMatrix[4] = instance.Transform.Scale * instance.Transform.BasisY.X;
                    transformationMatrix[5] = instance.Transform.Scale * instance.Transform.BasisY.Y;
                    transformationMatrix[6] = instance.Transform.Scale * instance.Transform.BasisY.Z;
                    transformationMatrix[7] = 0;
                    transformationMatrix[8] = instance.Transform.Scale * instance.Transform.BasisZ.X;
                    transformationMatrix[9] = instance.Transform.Scale * instance.Transform.BasisZ.Y;
                    transformationMatrix[10] = instance.Transform.Scale * instance.Transform.BasisZ.Z;
                    transformationMatrix[11] = 0;
                    transformationMatrix[12] = instance.Transform.Origin.X;
                    transformationMatrix[13] = instance.Transform.Origin.Y;
                    transformationMatrix[14] = instance.Transform.Origin.Z;
                    transformationMatrix[15] = 1;
                }
                else
                {
                    double[] d_TransformationTable = { 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0 };
                    transformationMatrix = d_TransformationTable;
                }
                String Kompo = element.GetType().Name;
                String Osa = element.Name.ToString() + " " + element.Id.ToString();

                writeData.addpart(Osa, (uint)Liu_FeatureIndex.Count);
                //int Str_Ok=-1;
                //Str_Ok = Listr_Nodes.IndexOf(Kompo);
                //if (-1 == Str_Ok)
                //{
                //    writeData.addNode(Osa, Kompo);
                //    Listr_Nodes.Add(Kompo);
                //}

                //writeData.addNode(Osa, Kompo);
                uint[] u_FeatureIndTable = new uint[Liu_FeatureIndex.Count];
                for (int k = 0; k < Liu_FeatureIndex.Count; k++)
                    u_FeatureIndTable[k] = (uint)Liu_FeatureIndex[k];



                float[] f_VerticesTable = new float[Lid_Vertices.Count];
                for (int k = 0; k < Lid_Vertices.Count; k++)
                    f_VerticesTable[k] = (float)Lid_Vertices[k];


                float[] f_NormalsTable = new float[Lid_Normals.Count];
                for (int k = 0; k < Lid_Normals.Count; k++)
                    f_NormalsTable[k] = (float)Lid_Normals[k];

                //float[] f_TextureCoordsTable = null;
                float[] f_TextureCoordsTable = new float[Lid_TextureCoords.Count];
                for (int k = 0; k < Lid_TextureCoords.Count; k++)
                    f_TextureCoordsTable[k] = (float)Lid_TextureCoords[k];

                //float[] TeCo = textureCoords.ToArray(typeof(float)) as float[];
                uint[] u_IndicesTable = new uint[Liu_Indices.Count];
                for (int k = 0; k < Liu_Indices.Count; k++)
                    u_IndicesTable[k] = (uint)Liu_Indices[k];
                //uint[] inx = indices.ToArray(typeof(uint)) as uint[];
                writeData.addFaceRegion(Osa, f_VerticesTable, f_NormalsTable,
                    f_TextureCoordsTable, u_IndicesTable, u_FeatureIndTable);
                double[] d_FeatureMaterialTable = new double[Lid_FeatureMaterial.Count];
                for (int k = 0; k < Lid_FeatureMaterial.Count; k++)
                    d_FeatureMaterialTable[k] = Lid_FeatureMaterial[k];
                double[] d_ComponentMaterialtable = { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0 };
                if (0 < d_FeatureMaterialTable.Length)
                    for (int k = 0; k < 14; k++)
                        d_ComponentMaterialtable[k] = d_FeatureMaterialTable[k + 1];
                double[] d_TextureMaterialTable = { 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0 };
                writeData.addComponent(Osa, Osa, /*d_TransformationTable*/transformationMatrix,
                    d_ComponentMaterialtable, d_FeatureMaterialTable, d_TextureMaterialTable);

            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "SendData fails for Reason:" + Environment.NewLine;
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                message = e.ToString();
                //File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
            //End of SendData
        }

        private void EndProsess()
        {
            try
            {
                //foreach (String StrTemp in Listr_Nodes)
                //    writeData.CloseNode(StrTemp);

                writeData.MakeEndProsess(ExportFileName);
                //writeData.write(ExportFileName);
                //writeData.writeExe(ExportFileName);
            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = "EndProsess fails for reason:" + Environment.NewLine;
                File.AppendAllText(@"C:\CadFaster\Revit\CF_RevitApiDll_log.txt", message);
                message = e.ToString();
                //File.AppendAllText(@"C:\CadFaster\Revit\CF_RevitApiDll_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
            //End of void EndProsess
        }
        private void AddVertex(uint Start, XYZ Vertex, uint NextId)
        {
            bool bfoundDublicate = false;
            Lid_Vertices.Add(Vertex.X);
            Lid_Vertices.Add(Vertex.Y);
            Lid_Vertices.Add(Vertex.Z);
            if (Lid_Vertices.Count > 0)
            {
                for (int i = (int)Start; i < Lid_Vertices.Count; i += 3)
                {
                    if (!bfoundDublicate)
                    {
                        if ((Lid_Vertices[i] == Vertex.X) && (Lid_Vertices[i + 1] == Vertex.Y) && (Lid_Vertices[i + 2] == Vertex.Z))
                        {
                            Liu_Indices.Add((uint)i / 3);
                            bfoundDublicate = true;
                        }
                    }
                }
            }
            // if (!bfoundDublicate)
            // {
            //     Liu_Indices.Add(NextId);
            //}
            //End of void AddVertex
        }


    //Class
    }
    //namebase
}
