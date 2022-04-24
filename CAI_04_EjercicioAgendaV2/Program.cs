using System;
using System.Collections.Generic;
using System.Threading;


namespace CAI_02_EjercicioAgendaV2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string _propietario;
            int _capacidad;
            string _tipo;
            bool _continuar;
            Agenda _agenda;
            int _opcionMenu;
            int _tempInt;
            string _textoMenu = "PRINCIPAL";
            Contacto _tempContacto;
            string _tempString;
            List<Contacto> _listaContactosTemp;

            //Inicio del programa
            Menu.MenuBienvenida();
            
            //Solicitud de datos iniciales

            do
            {
                Console.WriteLine("A continuación ingrese la cantidad de registros que desea tener en su Agenda Digital.");
                Console.WriteLine("Recuerde que debe ser un número entero positivo mayor que cero e inferior a 100000.");
                Console.WriteLine("Cantidad de registros: ");

                if ((int.TryParse(Console.ReadLine(), out _capacidad)) == true && Validadores.ValidarLimites(_capacidad, 1, 100000) == true)
                {
                    Console.WriteLine("Valor aceptado.");
                    _continuar = false;
                }
                else
                {
                    Console.WriteLine("Ha ingresado un valor incorrecto. Se solicitarán de nuevos los datos.");
                    _continuar = true;
                }

            } while (_continuar);

            Console.WriteLine("A continuación ingrese un texto que describa el tipo de agenda.");
            Console.WriteLine("Tipo de agenda: ");

            _tipo = Console.ReadLine();

            do
            {
                Console.WriteLine("A continuación ingrese el nombre del propietario.");
                Console.WriteLine("Recuerde que sólo se aceptan letras.");
                Console.WriteLine("Propietario: ");

                if (Validadores.ValidarSoloTexto(_propietario = Console.ReadLine()))
                {
                    Console.WriteLine("Valor aceptado.");
                    _continuar = false;
                }
                else
                {
                    Console.WriteLine("Ha ingresado un valor incorrecto. Se solicitarán de nuevos los datos.");
                    _continuar = true;
                }
            } while (_continuar);
                
            //Inicialización de la agenda

            _agenda = new Agenda(_capacidad, _tipo, _propietario);

            //Menu de operación de la agenda.

            #region MENU_PRINCIPAL
            do
            {
                if (_textoMenu == "PRINCIPAL")
                {
                    Menu.MenuPrincipal();
                    if ((int.TryParse(Console.ReadLine(), out _opcionMenu)) == true && Validadores.ValidarLimites(_opcionMenu, 1, 6) == true)
                    {
                        if (_opcionMenu == 1)
                        {
                            //Opción 1: Agregar una Persona
                            //Se inicializa el contacto temporal para la carga
                            _tempContacto = new ContactoPersona("","","",0,"","", DateTime.Parse("01/01/1980"));
                            //Se llama al método que solicita los datos del contacto
                            _tempContacto = Interacciones.SolicitarDatosContacto(_tempContacto);
                            //Se carga el nuevo contacto
                            if ( _agenda.AgregarContacto(_tempContacto))
                            {
                                Console.WriteLine("Se ha cargado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Se alcanzó el límite.");
                            }
                            Thread.Sleep(2000);
                            _continuar = true;
                        }
                        if (_opcionMenu == 2)
                        {
                            //Opción 2: Agregar una Empresa
                            //Se inicializa el contacto temporal para la carga
                            _tempContacto = new ContactoEmpresa("","","",0,"", DateTime.Parse("01/01/1980"));
                            //Se llama al método que solicita los datos del contacto
                            _tempContacto = Interacciones.SolicitarDatosContacto(_tempContacto);
                            //Se carga el nuevo contacto
                            if (_agenda.AgregarContacto(_tempContacto))
                            {
                                Console.WriteLine("Se ha cargado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Se alcanzó el límite.");
                            }
                            Thread.Sleep(2000);
                            _continuar = true;
                        }
                        else if (_opcionMenu == 3)
                        {
                            //Opción 3: Buscar un contacto
                            _tempString = Interacciones.SolicitarTextoBusqueda();
                            _listaContactosTemp = _agenda.BuscarContacto(_tempString);
                            Menu.MostrarContactos(_listaContactosTemp);
                            Menu.Pausa();
                        }
                        else if (_opcionMenu == 4)
                        {
                            //Opción 4: Editar un contacto
                            //Primero armo la lista completa de contactos
                            _listaContactosTemp = _agenda.BuscarContacto("TODOS");
                            //Segundo, doy la opción de elegir el contacto que se quiere editar
                            _tempInt = Interacciones.SeleccionarContacto(_listaContactosTemp, _agenda.Contador);
                            //Si el valor es cero significa que la opción ingresada es inválida
                            if (_tempInt != 0)
                            {
                                //Busco el contacto que quiero editar para traer sus datos
                                _tempInt = _listaContactosTemp.FindIndex(elemento => elemento.ID == _tempInt);
                                //Asigno todos los datos del contacto a la variable temporal
                                _tempContacto = _listaContactosTemp[_tempInt];
                                //Envío los datos del contacto al método para editar, y los reasigno a la variable temporal
                                _tempContacto = Interacciones.EditarDatosContacto(_tempContacto);
                                
                                if (_agenda.EditarContacto(_tempContacto))
                                {
                                    Console.WriteLine("Modificación exitosa.");
                                }
                                else
                                {
                                    Console.WriteLine("No se hallaron coincidencias.");
                                }
                            }
                            Menu.Pausa();
                        }
                        else if (_opcionMenu == 5)
                        {
                            //Opción 5: Eliminar un contacto
                            //Primero armo la lista completa de contactos
                            _listaContactosTemp = _agenda.BuscarContacto("TODOS");
                            //Segundo, doy la opción de elegir el contacto que se quiere eliminar
                            _tempInt = Interacciones.SeleccionarContacto(_listaContactosTemp, _agenda.Contador);
                            //Intento borrar el contacto. Si el nro es 0 no hubo coincidencias
                            if (_tempInt != 0 && _agenda.EliminarContacto(_tempInt))
                            {
                                Console.WriteLine("Eliminación Exitosa.");
                            }
                            else
                            {
                                Console.WriteLine("No se hallaron coincidencias.");
                            }
                            Menu.Pausa();
                        }
                        else if (_opcionMenu == 6)
                        {
                            //Opción 6: Salir del sistema
                            Menu.Salir();
                            _continuar = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ha ingresado una opción inválida, intente de nuevo.");
                        _continuar = true;
                    }
                }

            } while (_continuar);

            #endregion

        }
    }
}
