using System;
using System.Threading;
using System.Collections.Generic;

namespace CAI_02_EjercicioAgendaV2
{
    public class Menu
    {
        public static void MenuBienvenida()
        {
            Console.WriteLine("***   Bienvenido a su AGENDA DIGITAL   ***");
            Console.WriteLine();
            Console.WriteLine("Continuación se le solictarán los datos para iniciar su agenda");
            Console.WriteLine("Presione cualquier tecla para comenzar...");
            Console.WriteLine();
            Console.ReadKey();
        }


        public static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("***   Menú principal de su agenda digital   ***");
            Console.WriteLine();
            Console.WriteLine("1 - Agregar una Persona");
            Console.WriteLine("2 - Agregar una Empresa");
            Console.WriteLine("3 - Buscar un contacto");
            Console.WriteLine("4 - Editar un contacto");
            Console.WriteLine("5 - Eliminar un contacto");
            Console.WriteLine("6 - Salir del sistema");
            Console.WriteLine();
            Console.WriteLine("Su opción:");

        }

        public static bool DeseaContinuar()
        {
            Console.WriteLine("Presione 1 si desea continuar, sino cualquier tecla para salir.");
            if (Console.ReadLine() == "1")
            {
                return true;
            }
            else { return false; }
        }

        public static void Salir()
        {
            Console.Clear();
            Console.WriteLine(@" /\_/\");
            Console.WriteLine(@"(=^.^=)");
            Console.WriteLine("(\") (\")");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void MostrarContactos(List<Contacto> listaContactos)
        {
            Console.Clear();
            if (listaContactos.Count == 0)
            {
                Console.WriteLine("La búsqueda no ha encontrado resultados.");
            }
            else
            {
                Console.WriteLine("A continuación se muestran los resultados de la búsqueda.");
                Console.WriteLine("  NOMBRE   -   EMAIL   -   TELEFONO   -   DIRECCIÓN   -   ID");
                Console.WriteLine("");
                foreach (Contacto contacto in listaContactos)
                {
                    if (contacto is ContactoPersona)
                    {
                        ContactoPersona _tempContacto = (ContactoPersona)contacto;
                        Console.WriteLine(_tempContacto.Nombre + " - " + _tempContacto.Apellido + " - " + _tempContacto.Email + " - " + _tempContacto.Telefono + " - " + _tempContacto.Direccion + " - " + _tempContacto.ID);
                    }
                    else if (contacto is ContactoEmpresa)
                    {
                        ContactoEmpresa _tempContacto = (ContactoEmpresa)contacto;
                        Console.WriteLine(_tempContacto.RazonSocial + " - " + _tempContacto.Email + " - " + _tempContacto.Telefono + " - " + _tempContacto.Direccion + " - " + _tempContacto.ID);

                    }
                }
            }
        }

        public static void Pausa()
        {
            Console.WriteLine("");
            Console.WriteLine("Presione cualquier tecla para Continuar...");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
