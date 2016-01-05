using System;
using Enesy.CAD.Framework.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace Enesy.CAD.Framework.Enesy.CAD.Commands
{
    public static class Test
    {
        
        public static void AA(string s1, string s2)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor editor = doc.Editor;
            editor.WriteMessage("This is two string: {0} and {1}", s1, s2);
        }
    }
}
