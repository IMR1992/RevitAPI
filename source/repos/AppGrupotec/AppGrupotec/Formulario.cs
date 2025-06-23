using System;
using System.Collections.Generic;
using System.Linq;
using AppGrupotec;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace AppGrupotec
{
    public partial class Formulario : System.Windows.Forms.Form
    {
        ExternalCommandData commandData;
        string message;
        ElementSet elements;

        public Formulario(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements) 
        {
            InitializeComponent();

            this.commandData = commandData;
            this.message = message;
            this.elements = elements;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            AddCategories(doc);
        }

        private void AddCategories(Document doc)
        {
            Categories categories = doc.Settings.Categories;

            List<string> categoriesList = new List<string>();
            foreach (Category category in categories)
            {
                categoriesList.Add(category.Name);
            }
            categoriesList.Sort();
            foreach (string category in categoriesList)
            {
                clbCategories.Items.Add(category);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var selected = clbCategories.CheckedItems;
            List<object> l = new List<object>();
            foreach (var item in selected)
            {
                l.Add(item);
            }
            l.Select(x => x.ToString());
            TaskDialog.Show("Seleccionadas", string.Join("\n", l));


            if (l.FindIndex(x => x.ToString() == "Tuberías") >= 0)
            {
                CodigoTuberias ct = new CodigoTuberias();
                ct.Execute(commandData, ref message, elements);
            }

            if (l.FindIndex(x => x.ToString() == "Accesorios de tuberías") >= 0)
            {
                CodigoValvulas ct = new CodigoValvulas();
                ct.Execute(commandData, ref message, elements);
            }

            if (l.FindIndex(x => x.ToString() == "Muros") >= 0)
            {
                CodigoMuro ct = new CodigoMuro();
                ct.Execute(commandData, ref message, elements);
            }

            if (l.FindIndex(x => x.ToString() == "Puertas") >= 0)
            {
                CodigoPuertas ct = new CodigoPuertas();
                ct.Execute(commandData, ref message, elements);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbCategories.Items.Count; i++)
            {
                clbCategories.SetItemChecked(i, false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
