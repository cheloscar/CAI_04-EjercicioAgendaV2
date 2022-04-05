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
        private List<Contacto> _listaContactos;
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
            _listaContactos = new List<Contacto>();
        }


        //Métodos de clase

        /// <summary>
        /// Con este método se agrega un contacto a la Agenda. Se verifica que no se exceda la Capacidad.
        /// No devuelve error.
        /// </summary>
        /// <param name="contacto"></param>
        public bool AgregarContacto(Contacto contacto)
        {
            if (_listaContactos.Count < _capacidad)
            {
                _idContactos ++;
                contacto.ActualizarID(_idContactos);
                _listaContactos.Add(contacto);
                return true;
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
        public List<Contacto> BuscarContacto(string texto)
        {
            List<Contacto> resultados = new List<Contacto>();

            if (texto == "TODOS")
            {
                resultados = _listaContactos;
            }
            else
            {
                foreach (Contacto contacto in _listaContactos)
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

        public bool EliminarContacto(Contacto contacto)
        {
            if (_listaContactos.Remove(contacto)) { return true; }
            else { return false; }
        }

        public bool EditarContacto(Contacto contactoNew)
        {
            foreach (Contacto contacto in _listaContactos)
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
