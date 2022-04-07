using System;
using System.Collections.Generic;

namespace CAI_02EjercicioAgendaV2
{
    public class Agenda
    {
        //Variables de clase
        private int _capacidad;
        private string _tipo;
        private string _propietario;
        private List<ContactoPersona> _listaPersonas;
        private List<ContactoEmpresa> _listaEmpresas;
        private int _idContactos; //Contador de contactos, para facilitar la edición


        //Propiedades de clase
        public int Capacidad
        {
            get { return _capacidad; }
        }

        public string Tipo
        {
            get { return _tipo; }
        }

        public string Propietario
        {
            get { return _propietario; }
        }
        public int Contador
        {
            get { return _idContactos; }
        }


        //Constructor de clase
        /// <summary>
        /// Se solicitan los datos necesarios para iniciarlizar la agenda
        /// </summary>
        /// <param name="capacidad">La cantidad de elementos contactos que tendrá la agenda</param>
        /// <param name="tipo"></param>
        /// <param name="propietario"></param>
        public Agenda(int capacidad, string tipo, string propietario)
        {
            _capacidad = capacidad;
            _tipo = tipo;
            _propietario = propietario;
            _listaPersonas = new List<ContactoPersona>();
        }


        //Métodos de clase

        /// <summary>
        /// Con este método se agrega un contacto a la Agenda. Se verifica que no se exceda la Capacidad.
        /// No devuelve error.
        /// </summary>
        /// <param name="contacto"></param>
        public bool AgregarContacto(Contacto contacto)
        {
            if ((_listaPersonas.Count + _listaEmpresas.Count) < _capacidad)
            {
                if (contacto is ContactoPersona)
                {
                    _idContactos++;
                    contacto.ActualizarID(_idContactos);
                    _listaPersonas.Add((ContactoPersona)contacto);
                    return true;
                }
                else if (contacto is ContactoEmpresa)
                {
                    _idContactos++;
                    contacto.ActualizarID(_idContactos);
                    _listaEmpresas.Add((ContactoEmpresa)contacto);
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Se busca el "texto" en los campos Nombre, Apellido, Email, Teléfono y Dirección.
        /// Si el texto ingresado es un asterisco devuelve la toda la lista completa.
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="texto"></param>
        /// <returns>Devuelve una lista con las coincidencias, vacía si no hubo coincidencias</returns>
        public List<ContactoPersona> BuscarContacto(string texto)
        {
            List<ContactoPersona> resultados = new List<ContactoPersona>();

            if (texto == "TODOS")
            {
                resultados = _listaPersonas;
            }
            else
            {
                foreach (ContactoPersona contacto in _listaPersonas)
                {
                    if (contacto.Nombre.Contains(texto)) { resultados.Add(contacto); }
                    else if (contacto.Apellido.Contains(texto)) { resultados.Add(contacto); }
                    else if (contacto.Email.Contains(texto)) { resultados.Add(contacto); }
                    else if (contacto.Telefono.Contains(texto)) { resultados.Add(contacto); }
                    else if (contacto.Direccion.Contains(texto)) { resultados.Add(contacto); }
                }
            }
            return resultados;
        }

        public bool EliminarContacto(ContactoPersona contacto)
        {
            if (_listaPersonas.Remove(contacto)) { return true; }
            else { return false; }
        }

        public bool EditarContacto(ContactoPersona contactoNew)
        {
            foreach (ContactoPersona contacto in _listaPersonas)
            {
                if (contacto.ID == contactoNew.ID)
                {
                    contacto.ActualizarNombre(contactoNew.Nombre);
                    contacto.ActualizarApellido(contactoNew.Apellido);
                    contacto.ActualizarEmail(contactoNew.Email);
                    contacto.ActualizarTelefono(contactoNew.Telefono);
                    contacto.ActualizarDireccion(contactoNew.Direccion);
                    return true;
                }
            }
            return false;
        }


    }
}
