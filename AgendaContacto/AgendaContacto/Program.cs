using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContacto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var AgendaC = new AgendaContacto();

            Dictionary<string,int> Agenda = new Dictionary<string, int>() 
            {
                {"Miguel", 379},
                {"Daniel", 257},
                {"Juan", 654},
                {"Claudia", 258}
            };
        
            Console.WriteLine("=== AGENDA === \n");
            Console.WriteLine("Oprime el numero correspondiente para cada accion \n \n 1. Buscar Contacto \n 2. Insertar Contacto \n 3. Actualizar Contacto \n 4. Eliminar Contacto \n");
            string accion = Console.ReadLine();

            if (accion == "1") 
            {
                Console.WriteLine("Introdusca el Contacto a buscar");
                string Name = Console.ReadLine();
                Console.WriteLine(AgendaC.BusquedaContacto(Name,Agenda));



            }
        }

        class AgendaContacto 
        {
            



            public string AgregarContacto(string Name, int Number, Dictionary<string,int> Agenda)
            {
                Agenda.Add(Name, Number);
                return $"Se a agredado el contacto {Name}";
            }

            public string BusquedaContacto(string Name, Dictionary<string, int> Agenda)
            {
               if (Agenda.ContainsKey(Name)) return Agenda[Name].ToString();
               return $"No existe el contacto {Name}";
            }
          
            public string BorrarContacto(string Name, Dictionary<string, int> Agenda) 
            {
                if (Agenda.ContainsKey(Name))
                {
                    Agenda.Remove(Name);
                    return $"Se a boorado el contacto{Name}"; 
                };
                return "No existe el contacto";
            }

            public string ModificarContacto(string Name, int Number, Dictionary<string, int> Agenda) 
            {
                if (!Agenda.ContainsKey(Name)) return $"No se ha encontrado el contacto{Name}";

                else
                {
                    Agenda[Name] = Number;
                    return $"Se ha actualizado el contacto {Name} con el numero {Number}";
                }
            }

            public bool CheckNumber(string Number)
            {
                if (Number.Length >= 11)
                {
                    return false;
                }

                else if (Number.Length <= 1) return false;
                else if (int.TryParse(Number, out _)) return true ;
                else return false ;
            }

            
        }
    }
}
