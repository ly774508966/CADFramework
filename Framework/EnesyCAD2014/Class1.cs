﻿//using System;
//using Enesy.CAD.Framework;
//using Autodesk.AutoCAD.ApplicationServices;
//using Autodesk.AutoCAD.DatabaseServices;
//using Autodesk.AutoCAD.EditorInput;
//using Enesy.CAD.Framework.Runtime;

//#if AUTOCAD14

//#endif

//namespace EnesyCAD2014.Test
//{
//    public partial class Commands
//    {
//        [EnesyCADCommandMethod(globalName: "WELLCOME", Description = "Just test", Author = "Enesy.vn", Email = "congnv@enesy.vn")]
//        public void Test1()
//        {
//            Enesy.CAD.Framework.Class1 cl = new Enesy.CAD.Framework.Class1();
//            Document doc = Application.DocumentManager.MdiActiveDocument;
//            Editor editor = doc.Editor;
//            editor.WriteMessage(cl.WellcomeMessage);
//        }

//        // Test call a method with 2 parameters from reference assembly
//        [EnesyCADCommandMethod(globalName: "CALLMETHOD", Description = "Just test", Author = "Enesy.vn", Email = "congnv@enesy.vn")]
//        public void TestCallMethod()
//        {
//            Enesy.CAD.Framework.Enesy.CAD.Commands.Test.AA("string1", "string2");
//        }
//    }
//}
