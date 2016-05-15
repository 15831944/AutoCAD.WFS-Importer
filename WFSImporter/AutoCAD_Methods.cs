using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Colors;

namespace WFSImporter
{
    class AutoCAD_Methods
    {
        /// <summary>
        /// Calls the AutoCAD command zoom extents
        /// </summary>
        public static void ZoomExtents()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("._z e ", true, false, false);
        }
        /// <summary>
        /// Creates a new layer in the drawing
        /// </summary>
        /// <param name="layerName">Name of the layer to be created</param>
        /// <param name="colour">colour index of the new layer</param>
        private static void CreateLayer(string layerName, short colour)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                LayerTable layerTable = (LayerTable)tr.GetObject(currentDB.LayerTableId, OpenMode.ForWrite);
                if(!layerTable.Has(layerName))
                {
                    LayerTableRecord layer = new LayerTableRecord();
                    layer.Name = layerName;
                    layer.Color = Color.FromColorIndex(ColorMethod.ByLayer, colour);
                    ObjectId layerID = layerTable.Add(layer);
                    tr.AddNewlyCreatedDBObject(layer, true);
                    tr.Commit();
                }
            }
        }
        ///<summary> 
        ///Plots list of x & y coordinates to a closed polyline
        ///</summary>
        ///<param name="polyList">List of x & y coordinates. Format : "X /newline Y /newline</param>
        public static void DrawPlineFromList(List<string> polyList)
        {
            string layerName = "LINZ Parcel";
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            CreateLayer(layerName, 150);
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                BlockTable blckTable = tr.GetObject(currentDB.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blockTableRec = tr.GetObject(blckTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                Polyline parcel = new Polyline();
                int j = 0; //counter for using pairs of coordinates in a single list.
                for(int i = 0; i < ((polyList.Count/ 2) - 1); i++)
                {
                    parcel.AddVertexAt(i, new Point2d(Convert.ToDouble(polyList[j]), Convert.ToDouble(polyList[j + 1])), 0, 0, 0);
                    j += 2;
                }
                parcel.Closed = true;   //Closes the polyline 
                parcel.Layer = layerName;           
                blockTableRec.AppendEntity(parcel); 
                tr.AddNewlyCreatedDBObject(parcel, true);
                tr.Commit();             
            }
        }
        public static Tuple<double, double> GetCentroid(List<string> vertices)
        {
            double lat = 0, lng = 0;
            double signedArea;
            double latC, lngC;
            int verticesCount = vertices.Count / 2;
            //signedArea = 0.5 * 
            return Tuple.Create(lat, lng);
        }
        /// <summary>
        /// Creates mtext labels inside a close polyline
        /// </summary>
        /// <param name="vertices">Vertices of polyline; lat/long seperated each by /n </param>
        public static void DrawLabelsInPoly(List<string> vertices, string label1, string label2 = null, string label3 = null)
        {

        }
    }
}
