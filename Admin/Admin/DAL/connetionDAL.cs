using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Admin.DAL
{
    internal class connetionDAL
    {
        public bool PruebaConectar()
            { 
            
            
            try {
                string servidor = "127.0.0.1"; //Nombre o ip del servidor de MySQL
                string bd = "printdb"; //Nombre de la base de datos
                string usuario = "root"; //Usuario de acceso a MySQL
                string password = "Root1234"; //Contraseña de usuario de acceso a MySQL


                //Crearemos la cadena de conexión concatenando las variables
                string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";
                MySqlConnection conexionBD = new MySqlConnection("");
                MySqlCommand comand = new MySqlCommand();

                comand.CommandText = "SELECT * FROM rutas";
                comand.Connection = conexionBD;
                conexionBD.Open();
                comand.ExecuteNonQuery();
                conexionBD.Close();

                return true;

            
            }
            catch {
                return false;
            
            }

        }
    }
}
