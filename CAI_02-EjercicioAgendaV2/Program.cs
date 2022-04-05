using System;
using System.Collections.Generic;
using System.Threading;


namespace CAI_02EjercicioAgendaV2
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
                    if ((int.TryParse(Console.ReadLine(), out _opcionMenu)) == true && Validadores.ValidarLimites(_opcionMenu, 1, 5) == true)
                    {
                        if (_opcionMenu == 1)
                        {
                            //Opción 1: Agregar un contacto
                            //Se inicializa el contacto temporal para la carga
                            _tempContacto = new Contacto("", "", "", 0);
                            //Se llama al método que solicita los datos del contacto
                            Interacciones.SolicitarDatosContacto(_tempContacto);
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
                        else if (_opcionMenu == 2)
                        {
                            //Opción 2: Buscar un contacto
                            _tempString = Interacciones.SolicitarTextoBusqueda();
                            _listaContactosTemp = _agenda.BuscarContacto(_tempString);
                            Menu.MostrarContactos(_listaContactosTemp);
                            Menu.Pausa();
                        }
                        else if (_opcionMenu == 3)
                        {
                            //Opción 3: Editar un contacto
                            //Primero armo la lista completa de contactos
                            _listaContactosTemp = _agenda.BuscarContacto("TODOS");
                            //Segundo, doy la opción de elegir el contacto que se quiere editar
                            _tempContacto = Interacciones.SeleccionarContacto(_listaContactosTemp, _agenda.Contador);
                            //Verifico que el contacto existe antes de solicitar los nuevos valores
                            foreach (Contacto contacto in _listaContactosTemp)
                            {
                                if (contacto.ID == _tempContacto.ID)
                                {
                                    Interacciones.EditarDatosContacto(_tempContacto);
                                }
                            }
                            if (_agenda.EditarContacto(_tempContacto))
                            {
                                Console.WriteLine("Modificación exitosa.");
                            }
                            else
                            {
                                Console.WriteLine("No se hallaron coincidencias.");
                            }
                            Menu.Pausa();
                        }
                        else if (_opcionMenu == 4)
                        {
                            //Opción 4: Elimianr un contacto
                            //Primero armo la lista completa de contactos
                            _listaContactosTemp = _agenda.BuscarContacto("TODOS");
                            //Segundo, doy la opción de elegir el contacto que se quiere eliminar
                            _tempContacto = Interacciones.SeleccionarContacto(_listaContactosTemp, _agenda.Contador);
                            //Intento borrar el contacto
                            if (_agenda.EliminarContacto(_tempContacto))
                            {
                                Console.WriteLine("Eliminación Exitosa.");
                            }
                            else
                            {
                                Console.WriteLine("No se hallaron coincidencias.");
                            }
                            Menu.Pausa();
                        }
                        else if (_opcionMenu == 5)
                        {
                            //Opción 5: Salir del sistema
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
