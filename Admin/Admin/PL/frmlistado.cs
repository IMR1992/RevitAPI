using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin.BLL;
using Admin.DAL;


namespace Admin.PL
{
    public partial class frmlistado : Form
    {
        public frmlistado()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Otener infirma cion de la presentacion
 
        }

        private void RecuperarInformacion()
        {
            RutaBLL oRuta = new RutaBLL();
            int ID = 0; int.TryParse(txtID.Text, out ID);

            oRuta.ID = ID;

            oRuta.Path = txtFilePath.Text;

            oRuta.User = txtUser.Text;

            oRuta.Conjunto = cbxConjunto.Text;

            MessageBox.Show(oRuta.ID.ToString());

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RecuperarInformacion();
            connetionDAL connetion = new connetionDAL();
            MessageBox.Show("Conectado .. " + connetion.PruebaConectar());



        }
    }
}
