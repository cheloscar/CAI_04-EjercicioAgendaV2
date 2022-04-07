using System;
using System.Collections.Generic;

namespace CAI_02EjercicioAgendaV2
{
    public class Interacciones
    {
        /// <summary>
        /// Esté método solicita todos los datos necesarios para dar de alta un contacto.
        /// </summary>
        /// <param name="contacto">En este contacto tendrá los datos cargados por el usuario.</param>
        /// <returns>Devuelve un contacto con la info ingresada.</returns>
        public static ContactoPersona SolicitarDatosContacto(ContactoPersona contacto)
        {
            bool _continuar;
            DateTime _tempDT;

            Console.Clear();
            Console.WriteLine("A continuación se le solicitarán los datos necesarios, que son Nombre, Apellido e Email.");

            //Solicitud de nombre

            do
            {
                Console.WriteLine("Nombre:");
                contacto.ActualizarNombre(Console.ReadLine());
                //Se valida que el campo no esté vacío y que sea sólo texto
                if (contacto.Nombre != "" && Validadores.ValidarSoloTexto(contacto.Nombre))
                {
                    _continuar = false;
                }
                else
                {
                    Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                    _continuar = true;
                }
            } while (_continuar);

            //solicitud de apellido
            do
            {
                Console.WriteLine("Apellido:");
                contacto.ActualizarApellido(Console.ReadLine());
                //Se valida que el campo no esté vacío y que sea sólo texto
                if (contacto.Nombre != "" && Validadores.ValidarSoloTexto(contacto.Apellido))
                {
                    _continuar = false;
                }
                else
                {
                    Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                    _continuar = true;
                }
            } while (_continuar);

            //solicitud de email
            do
            {
                Console.WriteLine("Email:");
                contacto.ActualizarEmail(Console.ReadLine());
                //Se valida que el campo no esté vacío y que tenga un @
                if (contacto.Email != "" && contacto.Email.Contains("@"))
                {
                    _continuar = false;
                }
                else
                {
                    Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                    _continuar = true;
                }
            } while (_continuar);

            //Carga opcional de teléfono
            Console.WriteLine("¿Desea agregar el teléfono?");

            if (Menu.DeseaContinuar())
            {
                do
                {
                    Console.WriteLine("Teléfono:");
                    contacto.ActualizarTelefono(Console.ReadLine());
                    //Se verifica que el campo no esté vacío
                    if (contacto.Telefono != "")
                    {
                        _continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                        _continuar = true;
                    }
                } while (_continuar);
            } else { contacto.ActualizarTelefono("NN"); }

            //Carga opcional de la dirección
            Console.WriteLine("¿Desea agregar la dirección?");

            if (Menu.DeseaContinuar())
            {
                do
                {
                    Console.WriteLine("Dirección:");
                    contacto.ActualizarDireccion(Console.ReadLine());
                    //Se verifica que el campo no esté vacío
                    if (contacto.Direccion != "")
                    {
                        _continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                        _continuar = true;
                    }
                } while (_continuar);
            } else { contacto.ActualizarDireccion("NN"); }

            //Carga opcional de la fecha de nacimiento
            Console.WriteLine("¿Desea agregar la fecha de nacimiento?");

            if (Menu.DeseaContinuar())
            {
                do
                {
                    Console.WriteLine("Fecha de nacimiento:");
                    Console.WriteLine("El formato es DD/MM/AAAA");

                    //Se verifica que el campo no esté vacío y se encuentre en el formato correcto
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _tempDT))
                    {
                        contacto.ActualizarFechaNacimiento(_tempDT);
                        _continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                        _continuar = true;
                    }
                } while (_continuar);
            }

            //Se terminó la carga de datos
            return contacto;
        }

        /// <summary>
        /// Solicita al usuario un texto para realizar la búsqueda
        /// </summary>
        /// <returns>Devuelve un string no vacío</returns>
        public static string SolicitarTextoBusqueda()
        {
            string _textoTemp = "";
            bool _continuar;
            do
            {
                if (_textoTemp == "")
                {
                    Console.WriteLine("A continuación ingrese el texto que desee buscar entre la información de los contactos.");
                    Console.WriteLine("Ingrese 'TODOS' para mostrar todos los contactos");
                    Console.WriteLine("Texto:");
                    _textoTemp = Console.ReadLine();
                    _continuar = false;
                }
                else { _continuar = false; }
            } while (_continuar);
            return _textoTemp;
        }
        /// <summary>
        /// Este método muestra la lista de contactos para que el usuario pueda elegirlo mediante el ID.
        /// </summary>
        /// <param name="listaContactos">La lista de contactos que se operará</param>
        /// <param name="cantContador">El contador de ID de la agenda.</param>
        /// <returns>Devuelve un contacto que coincide el ID, o un contacto vacío si no hay coincidencias.</returns>
        public static ContactoPersona SeleccionarContacto(List<ContactoPersona> listaContactos, int cantContador)
        {
            int _idTemp;
            ContactoPersona _tempContacto = new Contacto("", "", "", 0);

            Menu.MostrarContactos(listaContactos);
            Console.WriteLine("");
            Console.WriteLine("Ingrese el ID del contacto que desea operar:");
            if (listaContactos.Count > 0 && int.TryParse(Console.ReadLine(), out _idTemp) && Validadores.ValidarLimites(_idTemp, 1, cantContador))
            {
                foreach (ContactoPersona contacto in listaContactos)
                {
                    if (contacto.ID == _idTemp)
                    {
                        _tempContacto = contacto;
                        return _tempContacto;
                    }
                }
            }
            else
            {
                Console.WriteLine("Se ha ingresado una opción inválida, se cancela la operación.");
            }
            return _tempContacto;
        }
        /// <summary>
        /// Esté método solicita todos los datos del contacto y permite elegir cuáles editar.
        /// </summary>
        /// <param name="contacto">En este contacto tendrá los datos cargados por el usuario.</param>
        /// <returns>Devuelve un contacto con la info ingresada.</returns>
        public static ContactoPersona EditarDatosContacto(ContactoPersona contacto)
        {
            bool _continuar;
            DateTime _tempDT;
            string _tempString;

            Console.Clear();
            Console.WriteLine("***   Actualización de datos de contacto   ***");

            //Modificación opcional del nombre
            Console.WriteLine("¿Desea modificar el nombre?");
            Console.WriteLine("Valor actual: " + contacto.Nombre);
            if (Menu.DeseaContinuar())
            {
                do
                {
                    Console.WriteLine("Nombre:");
                    _tempString = Console.ReadLine();
                    //Se valida que el campo no esté vacío y que sea sólo texto
                    if (_tempString != "" && Validadores.ValidarSoloTexto(contacto.Nombre))
                    {
                        contacto.ActualizarNombre(_tempString);
                        _continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                        _continuar = true;
                    }
                } while (_continuar);
            }

            //Modificación opcional del apellido
            Console.WriteLine("¿Desea modificar el apellido?");
            Console.WriteLine("Valor actual: " + contacto.Apellido);
            if (Menu.DeseaContinuar())
            {
                do
                {
                    Console.WriteLine("Apellido:");
                    _tempString = Console.ReadLine();
                    //Se valida que el campo no esté vacío y que sea sólo texto
                    if (_tempString != "" && Validadores.ValidarSoloTexto(contacto.Apellido))
                    {
                        contacto.ActualizarApellido(_tempString);
                        _continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                        _continuar = true;
                    }
                } while (_continuar);
            }

            //Modificación opcional del email
            Console.WriteLine("¿Desea modificar el email?");
            Console.WriteLine("Valor actual: " + contacto.Email);
            if (Menu.DeseaContinuar())
            {
                do
                {
                    Console.WriteLine("Email:");
                    _tempString = Console.ReadLine();
                    //Se valida que el campo no esté vacío y que tenga un @
                    if (_tempString != "" && _tempString.Contains("@"))
                    {
                        contacto.ActualizarEmail(_tempString);
                        _continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                        _continuar = true;
                    }
                } while (_continuar);
            }

            //Carga opcional de teléfono
            Console.WriteLine("¿Desea modificar el teléfono?");
            Console.WriteLine("Valor actual: " + contacto.Telefono);
            if (Menu.DeseaContinuar())
            {
                do
                {
                    Console.WriteLine("Teléfono:");
                    _tempString = Console.ReadLine();
                    //Se verifica que el campo no esté vacío
                    if (_tempString != "")
                    {
                        contacto.ActualizarTelefono(_tempString);
                        _continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                        _continuar = true;
                    }
                } while (_continuar);
            }

            //Carga opcional de la dirección
            Console.WriteLine("¿Desea modificar la dirección?");
            Console.WriteLine("Valor actual: " + contacto.Direccion);
            if (Menu.DeseaContinuar())
            {
                do
                {
                    Console.WriteLine("Dirección:");
                    _tempString = Console.ReadLine();
                    //Se verifica que el campo no esté vacío
                    if (_tempString != "")
                    {
                        contacto.ActualizarDireccion(_tempString);
                        _continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                        _continuar = true;
                    }
                } while (_continuar);
            }

            //Carga opcional de la fecha de nacimiento
            Console.WriteLine("¿Desea agregar la fecha de nacimiento?");
            Console.WriteLine("Valor actual: " + contacto.FechaNacimiento);
            if (Menu.DeseaContinuar())
            {
                do
                {
                    Console.WriteLine("Fecha de nacimiento:");
                    Console.WriteLine("El formato es DD/MM/AAAA");

                    //Se verifica que el campo no esté vacío y se encuentre en el formato correcto
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _tempDT))
                    {
                        contacto.ActualizarFechaNacimiento(_tempDT);
                        _continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                        _continuar = true;
                    }
                } while (_continuar);
            }

            //Se terminó la carga de datos
            return contacto;
        }
    }
}
