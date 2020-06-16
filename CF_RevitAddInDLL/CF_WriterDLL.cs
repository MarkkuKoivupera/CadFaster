using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;


namespace ExeWriter
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalCommand
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    //[Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    //public class ExeWriter : IExternalCommand
    class ExeWriter : IRevit
    {
        #region IExternalCommand Members Implementation
        private String ExportFileName;
        private List<double> d_VerticesList = new List<double>();
        private List<double> d_NormalsList = new List<double>();
        private List<double> d_TextureCoordsList = new List<double>();
        private List<double> d_FeatureMaterialList = new List<double>();
        private List<uint> u_IndicesList = new List<uint>();
        private List<uint> u_FeaturesIndList = new List<uint>();
        private Outwriter writeData = new Outwriter();
        #endregion IExternalCommand Members Implementation

        public void execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Retrieves the current active project.
                Autodesk.Revit.UI.UIApplication app = commandData.Application;
                UIDocument doc = app.ActiveUIDocument;
                
                string ExecutingAssemblyPath = Assembly.GetExecutingAssembly().Location;
                string DllAssemblyPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ExeWriter)).CodeBase);
                //revitApp = app
                Autodesk.Revit.DB.View view  = commandData.View;
                String ApplicationName = doc.Document.Title;
                String WievName = view.Document.Title;
                //Initialize RenderAppearancesForm
                //RenderAppearancesFrom.Asssets = app.Application.get_Assets(Autodesk.Revit.Utility.AssetType.Appearance);

                // Generate a object for Revit materials management.
                //MaterialsMgr materialsManager = new MaterialsMgr(doc, app);

                // Feed a MaterialsMgr to a dialog.
                FilteredElementCollector collector = new FilteredElementCollector(doc.Document);
                ICollection<Element> AllElements = collector.WhereElementIsNotElementType().ToElements();

                ArrayList objs = new ArrayList();
                Autodesk.Revit.DB.GeometryElement GeomElem;
                //Autodesk.Revit.DB.Options Opts= new Options();
                Autodesk.Revit.DB.Options geomOp = app.Application.Create.NewGeometryOptions();
                writeData.Init(ref message);
                Autodesk.Revit.DB.GeometryInstance instance = null;
                foreach (Element element in AllElements)
                {
                    Autodesk.Revit.DB.Phase phaseCreated = element.PhaseCreated;
                    if (null != phaseCreated)
                    {
                        //Get Geometry element
                        GeomElem = element.get_Geometry(geomOp);
                        if (null == GeomElem)
                        {
                            TopographySurface TyPo = element as TopographySurface;
                            if (null == TyPo)
                            {
                                HostObject HostOb = element as HostObject;
                                if (null == HostOb)
                                {
                                }
                                else
                                    GeomElem = HostOb.get_Geometry(geomOp);
                            }
                            else
                                GeomElem = TyPo.get_Geometry(geomOp);
                        }
                        //Geometry must be
                        if (null != GeomElem)
                        {
                            //GeomElem = element.get_Geometry(Opts);
                            foreach (GeometryObject geomObj in GeomElem.Objects)
                            {
                                uint uCurves = 0;
                                Solid geomSolid = geomObj as Solid;
                                Curve geomCurve = geomObj as Curve;
                                Mesh geomMesh = geomObj as Mesh;
                                Edge geomEdge = geomObj as Edge;
                                instance = geomObj as Autodesk.Revit.DB.GeometryInstance;

                                if (null != instance)
                                {
                                    foreach (GeometryObject InstanObj in instance.SymbolGeometry.Objects)
                                    {
                                        geomSolid = InstanObj as Solid;
                                        geomMesh = InstanObj as Mesh;
                                        geomEdge = InstanObj as Edge;
                                        geomCurve = InstanObj as Curve;
                                        if (geomCurve != null)
                                        {
                                            // transfrom the curve to make it in the instance's coordinate space 
                                            geomCurve = geomCurve.get_Transformed(instance.Transform);
                                        }
                                        if (geomSolid != null)
                                        {
                                            // transfrom the curve to make it in the instance's coordinate space 
                                            DataProcess(geomSolid, instance);
                                        }
                                    }
                                }
                                if (null != geomCurve)
                                {
                                    uCurves++;
                                }
                                if (null != geomSolid)
                                {
                                    DataProcess(geomSolid, instance);
                                }

                            }

                            SendData(element, instance);
                            objs.Add(element);
                            d_VerticesList.Clear();
                            d_NormalsList.Clear();
                            d_TextureCoordsList.Clear();
                            d_FeatureMaterialList.Clear();
                            u_IndicesList.Clear();
                            u_FeaturesIndList.Clear();
                        }
                   }                    

                }

                System.Diagnostics.Trace.WriteLine(AllElements.Count.ToString());
                CF_WriterForm form = new CF_WriterForm(objs);
                //form.ShowDialog();
                //using (MaterialsForm dlg = new MaterialsForm(materialsManager,commandData))
                //{
                form.ExportFileName = ApplicationName;
                if (form.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                    {
                        ExportFileName = form.ExportFileName;
                        EndProsess(ref message);
                        // Revit need to do nothing.
                        //return Autodesk.Revit.UI.Result.Cancelled;
                    }
                    else
                    {
                        // Done some action, ask revit to execute it.
                        //return Autodesk.Revit.UI.Result.Succeeded;
                     }
                //}                
            }
            catch (Exception e)
            {
                // Exception rised, report it by revit error reporting mechanism. 
                message = e.ToString();
                File.AppendAllText(@"C:\CadFaster\Revit\CF_WriterDLLs_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }

        }
        private void DataProcess(Solid geomSolid, GeometryInstance instance)
        {
            try
            {
                uint ufaces = 0;
                uint uVertices = 0;
                uint uPoints = 0;
                uint iStartId = (uint)d_VerticesList.Count;
                foreach (Face geomFace in geomSolid.Faces)
                {
                    iStartId = (uint)d_VerticesList.Count;
                    bool bNewFace = true;
                    ufaces++;
                    Mesh mesh = geomFace.Triangulate();
                    foreach (XYZ ii in mesh.Vertices)
                    {
                        uVertices++;

                        XYZ point = ii;
                        if (null != instance)
                        {
                            Transform instTransform = instance.Transform;
                            XYZ transformedPoint = instTransform.OfPoint(point);
                        }

                    }
                    uint iNextId = 0;
                    for (int i = 0; i < mesh.NumTriangles; i++)
                    {
                        MeshTriangle triangle = mesh.get_Triangle(i);
                        XYZ vertex = triangle.get_Vertex(0);
                        if (bNewFace)
                        {
                            iNextId = iStartId/3;
                            bNewFace = false; 
                        }

                        u_IndicesList.Add(3);
                        AddVertex(iStartId, vertex, iNextId++);
                        vertex = triangle.get_Vertex(1);
                        AddVertex(iStartId, vertex, iNextId++);
                        vertex = triangle.get_Vertex(2);
                        AddVertex(iStartId, vertex, iNextId++);
                    }
                    XYZ origin = new XYZ(0, 0, 0);
                    XYZ normal = new XYZ(0, 0, 0);
                    XYZ vector = new XYZ(0, 0, 0);
                    PlanarFace planarFace = geomFace as PlanarFace;
                    if (null != planarFace)
                    {
                        origin = planarFace.Origin;
                        normal = planarFace.Normal;
                        vector = planarFace.get_Vector(0);
                    }
                    ConicalFace ConFace = geomFace as ConicalFace;
                    if (null != ConFace)
                    {
                        origin = ConFace.Origin;
                        normal = ConFace.Axis;
                        vector = ConFace.get_Radius(0);
                    }

                    HermiteFace HermiteFace = geomFace as HermiteFace;
                    if (null != HermiteFace)
                    {
                        origin = new XYZ(0, 0, 0);//HermiteFace.Points;
                        normal = new XYZ(0, 0, 0);//HermiteFace.TaAxis;
                        vector = new XYZ(0, 0, 0);//HermiteFace.get_Tangents(0);
                    }
                    RevolvedFace RevolFace = geomFace as RevolvedFace;
                    if (null != RevolFace)
                    {
                        origin = RevolFace.Origin;
                        normal = RevolFace.Axis;
                        vector = RevolFace.get_Radius(0);
                    }
                    RuledFace RulFace = geomFace as RuledFace;
                    if (null != RulFace)
                    {
                        origin = new XYZ( 0, 0, 0 );// RulFace.get_Point;
                        normal = new XYZ( 0, 0, 0 );///RulFace.Axis;
                        vector = RulFace.get_Point(0);
                    }
                    CylindricalFace CylinFace = geomFace as CylindricalFace;
                    if (null != CylinFace)
                    {
                        origin = CylinFace.Origin;
                        normal = CylinFace.Axis;
                        vector = CylinFace.get_Radius(0);
                    }
                    uint featuresCount = 0;
                    for (int s = d_NormalsList.Count; s < d_VerticesList.Count; s += 3)
                    {
                        d_NormalsList.Add(normal.X);
                        d_NormalsList.Add(normal.Y);
                        d_NormalsList.Add(normal.Z);
                        d_TextureCoordsList.Add(normal.X);
                        d_TextureCoordsList.Add(normal.Y);
                        d_TextureCoordsList.Add(normal.Z);
                        featuresCount++;
                    }
                    u_FeaturesIndList.Add(featuresCount);
                }
               
                foreach (Edge edge in geomSolid.Edges)
                {
                    foreach (XYZ ii in edge.Tessellate())
                    {
                        uPoints++;
                        XYZ point = ii;
                        if (null != instance)
                        {
                            Transform instTransform = instance.Transform;
                            XYZ transformedPoint = instTransform.OfPoint(point);
                        }

                    }

                }//foreach (Face geomFace in geomSolid.Faces)
                //string Osa = element.Name.ToString() + element.Id.ToString();
           }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = e.ToString();
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
            //End of DataProcess
        }
        private void SendData(Element element, GeometryInstance instance)
        {
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

                string Osa = element.Name.ToString() + " " + element.Id.ToString();
                writeData.addpart(Osa, (uint)u_FeaturesIndList.Count);
                double[] d_featureBase = { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 1.0, 0.0, 0.0, 0.0 };
                for (double d_Ind = 0; d_Ind < (double)u_FeaturesIndList.Count; d_Ind++)
                {
                    d_FeatureMaterialList.Add(d_Ind);
                    for (int i_i = 0; i_i < d_featureBase.Length; i_i++)
                        d_FeatureMaterialList.Add(d_featureBase[i_i]);
                }
                uint[] u_FeatureIndTable = new uint[u_FeaturesIndList.Count];
                for (int k = 0; k < u_FeaturesIndList.Count; k++)
                    u_FeatureIndTable[k] = (uint)u_FeaturesIndList[k];



                float[] f_VerticesTable = new float[d_VerticesList.Count];
                for (int k = 0; k < d_VerticesList.Count; k++)
                    f_VerticesTable[k] = (float)d_VerticesList[k];
                //float[] vert = vertices.ToArray(typeof(float)) as float[];
                float[] f_NormalsTable = new float[d_NormalsList.Count];
                for (int k = 0; k < d_NormalsList.Count; k++)
                    f_NormalsTable[k] = (float)d_NormalsList[k];
                //float[] norm = normals.ToArray(typeof(float)) as float[];
                float[] f_TextureCoordsTable = new float[d_TextureCoordsList.Count];
                for (int k = 0; k < d_TextureCoordsList.Count; k++)
                    f_TextureCoordsTable[k] = (float)d_TextureCoordsList[k];
                //float[] TeCo = textureCoords.ToArray(typeof(float)) as float[];
                uint[] u_IndicesTable = new uint[u_IndicesList.Count];
                for (int k = 0; k < u_IndicesList.Count; k++)
                    u_IndicesTable[k] = (uint)u_IndicesList[k];
                //uint[] inx = indices.ToArray(typeof(uint)) as uint[];
                writeData.addFaceRegion(Osa, f_VerticesTable, f_NormalsTable,
                    f_TextureCoordsTable, u_IndicesTable, u_FeatureIndTable);
                double[] d_FeatureMaterialTable = new double[d_FeatureMaterialList.Count];
                for (int k = 0; k < d_FeatureMaterialList.Count; k++)
                    d_FeatureMaterialTable[k] = (uint)d_FeatureMaterialList[k];
                double[] d_ComponentMaterialtable = { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0 };
                double[] d_TextureMaterialTable = { 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0 };
                writeData.addComponent(Osa, element.UniqueId.ToString(), /*d_TransformationTable*/transformationMatrix,
                    d_ComponentMaterialtable, d_FeatureMaterialTable, d_TextureMaterialTable);
            }
            catch (Exception e)
            {
                string message;
                // Exception rised, report it by revit error reporting mechanism. 
                message = e.ToString();
                File.AppendAllText(@"C:\CadFaster\Revit\ExeWriter_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
            //End of SendData
        }

        private void EndProsess(ref string message)
        {
            try
            {
                writeData.write(ExportFileName);
                writeData.writeExe(ExportFileName);
            }
            catch (Exception e)
            {
                // Exception rised, report it by revit error reporting mechanism. 
                message = e.ToString();
                File.AppendAllText(@"C:\CadFaster\Revit\CF_RevitApiDll_log.txt", message);
                //return Autodesk.Revit.UI.Result.Failed;
            }
            //End of void EndProsess
        }
        private void AddVertex(uint Start, XYZ Vertex, uint NextId)
        {
            //bool bfoundDublicate = false;
            //if (d_VerticesList.Count > 0)
            //{
            //    for (int i = (int)Start; i < d_VerticesList.Count; i += 3)
            //    {
            //        if (!bfoundDublicate)
            //        {
            //            if ((d_VerticesList[i] == Vertex.X) && (d_VerticesList[i + 1] == Vertex.Y) && (d_VerticesList[i + 2] == Vertex.Z))
            //            {
            //                u_IndicesList.Add((uint)i / 3);
            //                bfoundDublicate = true;
            //            }
            //        }
            //    }
            //}
            //if (!bfoundDublicate)
            {
                u_IndicesList.Add(NextId);
                d_VerticesList.Add(Vertex.X);
                d_VerticesList.Add(Vertex.Y);
                d_VerticesList.Add(Vertex.Z);
           }
            //End of void AddVertex
        }

    }
}
