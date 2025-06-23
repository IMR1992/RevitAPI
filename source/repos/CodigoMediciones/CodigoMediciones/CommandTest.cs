#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace CodigoMediciones
{
    [Transaction(TransactionMode.Manual)]
    public class CommandTest : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            Formulario f = new Formulario(commandData, ref message, elements);
            f.ShowDialog();

            return Result.Succeeded;
        }
    }
}
