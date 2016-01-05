using System;
using Enesy.CAD.Framework;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Enesy.CAD.Framework.Runtime;

namespace EnesyCAD2007.Test
{
    public partial class Commands
    {
        [EnesyCADCommandMethod(globalName: "WELLCOME", Description = "Just test", Author = "Enesy.vn", Email = "congnv@enesy.vn")]
        public void Test1()
        {
            Enesy.CAD.Framework.Class1 cl = new Enesy.CAD.Framework.Class1();
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor editor = doc.Editor;
            editor.WriteMessage(cl.WellcomeMessage);
        }

        // Test call a method with 2 parameters from reference assembly
        [EnesyCADCommandMethod(globalName: "TESTFORM", Description = "Just test", Author = "Enesy.vn", Email = "congnv@enesy.vn")]
        public void TestCallMethod()
        {
            //TestForm.Form1 f = new TestForm.Form1();
            //f.Show();
            Enesy.CAD.Framework.Enesy.CAD.Framework.Controls.TestYoutube t = new Enesy.CAD.Framework.Enesy.CAD.Framework.Controls.TestYoutube();
            t.Show();
        }
    }
}
