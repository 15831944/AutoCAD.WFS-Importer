// (C) Copyright 2016 by Jericho Masigan 
using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

// This line is not mandatory, but improves loading performances
[assembly: CommandClass(typeof(WFSImporter.AutoCADcmd))]

namespace WFSImporter
{
    public class AutoCADcmd
    {
        [CommandMethod("NETMAPS", CommandFlags.Modal)]
        public void NetMaps()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed;
            if (doc != null)
            {
                ed = doc.Editor;
                MainUI ui = new MainUI();
                ui.ShowDialog();
            }
        }

    }

}
