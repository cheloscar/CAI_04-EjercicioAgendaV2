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
        public static Contacto SolicitarDatosContacto(Contacto contacto)
        {
            bool _continuar;
            ContactoPersona _tempContactoPersona = new ContactoPersona("", "", "", 0, "", "", DateTime.Parse("01/01/1980"));
            ContactoEmpresa _tempContactoEmpresa;
            DateTime _tempDT;

            Console.Clear();
            Console.WriteLine("A continuación se le solicitarán los datos necesarios, que son Nombre/Razón Social e Email.");

            //Se evalúa el tipo de contacto que se cargará

            if (contacto is ContactoPersona)
            {
                #region Carga de datos Persona

                //Se cargan todoslos datos de un contacto del tipo Persona.

                _tempContactoPersona = (ContactoPersona)contacto;

                //Solicitud de nombre

                do
                {
                    Console.WriteLine("Nombre:");
                    _tempContactoPersona.ActualizarNombre(Console.ReadLine());
                    //Se valida que el campo no esté vacío y que sea sólo texto
                    if (_tempContactoPersona.Nombre != "" && Validadores.ValidarSoloTexto(_tempContactoPersona.Nombre))
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
                    _tempContactoPersona.ActualizarApellido(Console.ReadLine());
                    //Se valida que el campo no esté vacío y que sea sólo texto
                    if (_tempContactoPersona.Nombre != "" && Validadores.ValidarSoloTexto(_tempContactoPersona.Apellido))
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
                    _tempContactoPersona.ActualizarEmail(Console.ReadLine());
                    //Se valida que el campo no esté vacío y que tenga un @
                    if (_tempContactoPersona.Email != "" && _tempContactoPersona.Email.Contains("@"))
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
                        _tempContactoPersona.ActualizarTelefono(Console.ReadLine());
                        //Se verifica que el campo no esté vacío
                        if (_tempContactoPersona.Telefono != "")
                        {
                            _continuar = false;
                        }
                        else
                        {
                            Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                            _continuar = true;
                        }
                    } while (_continuar);
                }
                else
                {
                    _tempContactoPersona.ActualizarTelefono("NN");
                }

                //Carga opcional de la dirección
                Console.WriteLine("¿Desea agregar la dirección?");

                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Dirección:");
                        _tempContactoPersona.ActualizarDireccion(Console.ReadLine());
                        //Se verifica que el campo no esté vacío
                        if (_tempContactoPersona.Direccion != "")
                        {
                            _continuar = false;
                        }
                        else
                        {
                            Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                            _continuar = true;
                        }
                    } while (_continuar);
                }
                else
                {
                    _tempContactoPersona.ActualizarDireccion("NN");
                }

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
                            _tempContactoPersona.ActualizarFechaNacimiento(_tempDT);
                            _continuar = false;
                        }
                        else
                        {
                            Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                            _continuar = true;
                        }
                    } while (_continuar);
                }

                //Se termina la carga de datos del tipo Persona, se finaliza el proceso.

                return _tempContactoPersona;

                #endregion
            }
            else if (contacto is ContactoEmpresa)
            {
                #region Carga de datps Empresa

                //Se cargan todoslos datos de un contacto del tipo Empresa.

                _tempContactoEmpresa = (ContactoEmpresa)contacto;

                //Solicitud de razón social

                do
                {
                    Console.WriteLine("Razón Social:");
                    _tempContactoEmpresa.ActualizarRazonSocial(Console.ReadLine());
                    //Se valida que el campo no esté vacío. Se aceptan espacios
                    if (_tempContactoEmpresa.RazonSocial != "")
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
                    _tempContactoEmpresa.ActualizarEmail(Console.ReadLine());
                    //Se valida que el campo no esté vacío y que tenga un @
                    if (_tempContactoEmpresa.Email != "" && _tempContactoEmpresa.Email.Contains("@"))
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
                        _tempContactoEmpresa.ActualizarTelefono(Console.ReadLine());
                        //Se verifica que el campo no esté vacío
                        if (_tempContactoEmpresa.Telefono != "")
                        {
                            _continuar = false;
                        }
                        else
                        {
                            Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                            _continuar = true;
                        }
                    } while (_continuar);
                }
                else
                {
                    _tempContactoEmpresa.ActualizarTelefono("NN");
                }

                //Carga opcional de la dirección
                Console.WriteLine("¿Desea agregar la dirección?");

                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Dirección:");
                        _tempContactoEmpresa.ActualizarDireccion(Console.ReadLine());
                        //Se verifica que el campo no esté vacío
                        if (_tempContactoEmpresa.Direccion != "")
                        {
                            _continuar = false;
                        }
                        else
                        {
                            Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                            _continuar = true;
                        }
                    } while (_continuar);
                }
                else
                {
                    _tempContactoEmpresa.ActualizarDireccion("NN");
                }

                //Carga opcional de la fecha de constitución
                Console.WriteLine("¿Desea agregar la fecha de constitución?");

                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Fecha de constitución:");
                        Console.WriteLine("El formato es DD/MM/AAAA");

                        //Se verifica que el campo no esté vacío y se encuentre en el formato correcto
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _tempDT))
                        {
                            _tempContactoEmpresa.ActualizarFechaConstitucion(_tempDT);
                            _continuar = false;
                        }
                        else
                        {
                            Console.WriteLine("Ha ingresado un valor incorrecto, intente de nuevo.");
                            _continuar = true;
                        }
                    } while (_continuar);
                }

                //Se termina la carga de datos del tipo Persona, se finaliza el proceso.

                return _tempContactoEmpresa;

                #endregion
            }
            else
            {
                return contacto;
            }
            //Se terminó la carga de datos
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
        /// <returns>Devuelve el id del contacto que quiere operar, 0 si no hay coincidencias.</returns>
        public static int SeleccionarContacto(List<Contacto> listaContactos, int cantContador)
        {
            int _idBusqueda;
            
            Menu.MostrarContactos(listaContactos);
            Console.WriteLine("");
            Console.WriteLine("Ingrese el ID del contacto que desea operar:");
            if (listaContactos.Count > 0 && int.TryParse(Console.ReadLine(), out _idBusqueda) && Validadores.ValidarLimites(_idBusqueda, 1, cantContador))
            {
                foreach (Contacto contacto in listaContactos)
                {
                    if (contacto.ID == _idBusqueda)
                    {
                        return _idBusqueda;
                    }
                }
            }
            else
            {
                Console.WriteLine("Se ha ingresado una opción inválida, se cancela la operación.");
                return 0;
            }
            return 0;
        }
        /// <summary>
        /// Esté método solicita todos los datos del contacto y permite elegir cuáles editar.
        /// </summary>
        /// <param name="contacto">En este contacto tendrá los datos cargados por el usuario.</param>
        /// <returns>Devuelve un contacto con la info ingresada.</returns>
        public static Contacto EditarDatosContacto(Contacto contacto)
        {
            
            bool _continuar;
            DateTime _tempDT;
            string _tempString;

            Console.Clear();
            Console.WriteLine("***   Actualización de datos de contacto   ***");

            #region Editar Contacto Persona

            if (contacto is ContactoPersona)
            {
                ContactoPersona _tempContacto = (ContactoPersona)contacto;

                //Modificación opcional del nombre
                Console.WriteLine("¿Desea modificar el nombre?");
                Console.WriteLine("Valor actual: " + _tempContacto.Nombre);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Nombre:");
                        _tempString = Console.ReadLine();
                        //Se valida que el campo no esté vacío y que sea sólo texto
                        if (_tempString != "" && Validadores.ValidarSoloTexto(_tempContacto.Nombre))
                        {
                            _tempContacto.ActualizarNombre(_tempString);
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
                Console.WriteLine("Valor actual: " + _tempContacto.Apellido);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Apellido:");
                        _tempString = Console.ReadLine();
                        //Se valida que el campo no esté vacío y que sea sólo texto
                        if (_tempString != "" && Validadores.ValidarSoloTexto(_tempContacto.Apellido))
                        {
                            _tempContacto.ActualizarApellido(_tempString);
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
                Console.WriteLine("Valor actual: " + _tempContacto.Email);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Email:");
                        _tempString = Console.ReadLine();
                        //Se valida que el campo no esté vacío y que tenga un @
                        if (_tempString != "" && _tempString.Contains("@"))
                        {
                            _tempContacto.ActualizarEmail(_tempString);
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
                Console.WriteLine("Valor actual: " + _tempContacto.Telefono);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Teléfono:");
                        _tempString = Console.ReadLine();
                        //Se verifica que el campo no esté vacío
                        if (_tempString != "")
                        {
                            _tempContacto.ActualizarTelefono(_tempString);
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
                Console.WriteLine("Valor actual: " + _tempContacto.Direccion);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Dirección:");
                        _tempString = Console.ReadLine();
                        //Se verifica que el campo no esté vacío
                        if (_tempString != "")
                        {
                            _tempContacto.ActualizarDireccion(_tempString);
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
                Console.WriteLine("Valor actual: " + _tempContacto.FechaNacimiento);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Fecha de nacimiento:");
                        Console.WriteLine("El formato es DD/MM/AAAA");

                        //Se verifica que el campo no esté vacío y se encuentre en el formato correcto
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _tempDT))
                        {
                            _tempContacto.ActualizarFechaNacimiento(_tempDT);
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
                contacto = _tempContacto;
                return contacto;
            }

            #endregion

            #region Editar Contacto Empresa

            else if (contacto is ContactoEmpresa)
            {
                ContactoEmpresa _tempContacto = (ContactoEmpresa)contacto;

                //Modificación opcional de la Razón Social
                Console.WriteLine("¿Desea modificar la Razón Social?");
                Console.WriteLine("Valor actual: " + _tempContacto.RazonSocial);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Razón Social:");
                        _tempString = Console.ReadLine();
                        //Se valida que el campo no esté vacío. Se aceptan espacios.
                        if (_tempString != "")
                        {
                            _tempContacto.ActualizarRazonSocial(_tempString);
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
                Console.WriteLine("Valor actual: " + _tempContacto.Email);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Email:");
                        _tempString = Console.ReadLine();
                        //Se valida que el campo no esté vacío y que tenga un @
                        if (_tempString != "" && _tempString.Contains("@"))
                        {
                            _tempContacto.ActualizarEmail(_tempString);
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
                Console.WriteLine("Valor actual: " + _tempContacto.Telefono);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Teléfono:");
                        _tempString = Console.ReadLine();
                        //Se verifica que el campo no esté vacío
                        if (_tempString != "")
                        {
                            _tempContacto.ActualizarTelefono(_tempString);
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
                Console.WriteLine("Valor actual: " + _tempContacto.Direccion);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Dirección:");
                        _tempString = Console.ReadLine();
                        //Se verifica que el campo no esté vacío
                        if (_tempString != "")
                        {
                            _tempContacto.ActualizarDireccion(_tempString);
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
                Console.WriteLine("¿Desea agregar la fecha de constitución?");
                Console.WriteLine("Valor actual: " + _tempContacto.FechaConstitucion);
                if (Menu.DeseaContinuar())
                {
                    do
                    {
                        Console.WriteLine("Fecha de constitución:");
                        Console.WriteLine("El formato es DD/MM/AAAA");

                        //Se verifica que el campo no esté vacío y se encuentre en el formato correcto
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _tempDT))
                        {
                            _tempContacto.ActualizarFechaConstitucion(_tempDT);
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
                contacto = _tempContacto;
                return contacto;
            }
            #endregion
            //Se devuelve el contacto tal cual llegó
            else { return contacto; }
        }
    }
}
