using System;
using Enesy.CAD.Framework;
using Enesy.CAD.Framework.Runtime;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;

namespace EnesyCAD2007
{
    public partial class Commands : IExtensionApplication
    {
        private static CommandListManager _frm = null;

        public void Initialize()
        {
            DocumentCollection dwgCol = Application.DocumentManager;
            dwgCol.DocumentBecameCurrent += dwgCol_DocumentBecameCurrent;
            Document dwg = Application.DocumentManager.MdiActiveDocument;
            Editor ed = dwg.Editor;

            try
            {
                ed.WriteMessage("\nInitializing {0}...", this.GetType().Name);

                ed.WriteMessage("comleted\n");
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage("failed:\n{0}", ex.ToString());
            }

        }

        private void dwgCol_DocumentBecameCurrent(object sender, DocumentCollectionEventArgs e)
        {
            if (_frm == null) return;

            if (_frm.Visible)
            {
                //Reload drawing data to the form, when the form turns from
                //invisible to visible. To make the code more efficient,
                //we also check if the drawing information on the form points
                //to the same drawing that became current, and only refresh
                //information on the form when drawing is different
                //DrawingData data =
                //    DwgDataView.DrawingDataUtil.GetCurrentDrawingData();
                //_frm.SetDataView(data);
            }
        }

        public void Terminate()
        {
            if (_frm != null)
            {
                if (!_frm.IsDisposed) _frm.Dispose();
            }
        }

        [EnesyCADCommandMethod(globalName: "CEE", Description="Show Command Lists", Author="Enesy.vn", Email="contact@enesy.vn")]
        public static void ShowCommandList()
        {
            if (_frm == null)
            {
                _frm = new CommandListManager();
            }

            //DrawingData data =
            //    DwgDataView.DrawingDataUtil.GetCurrentDrawingData();
            //_frm.SetDataView(data);
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog(null, _frm, false);
        }
    }
}
