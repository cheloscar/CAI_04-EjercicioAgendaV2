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
        /// Método para agregar un contacto a la Agenda. Se verifica que no se exceda la Capacidad.
        /// No devuelve error.
        /// </summary>
        /// <param name="contacto">Persona o Empresa</param>
        public bool AgregarContacto(Contacto contacto)
        {
            if (_listaContactos.Count < _capacidad)
            {
                if (contacto is ContactoPersona)
                {
                    _idContactos++;
                    contacto.ActualizarID(_idContactos);
                    _listaContactos.Add(contacto);
                    return true;
                }
                else if (contacto is ContactoEmpresa)
                {
                    _idContactos++;
                    contacto.ActualizarID(_idContactos);
                    _listaContactos.Add(contacto);
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Método para agregar una Persona a la Agenda. Se verifica que no se exceda la Capacidad.
        /// No devuelve error.
        /// </summary>
        /// <param name="contacto">Persona</param>
        public bool AgregarContacto(ContactoPersona contacto)
        {
            if (_listaContactos.Count < _capacidad)
            {
                _idContactos++;
                contacto.ActualizarID(_idContactos);
                _listaContactos.Add(contacto);
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Método para agregar una Empresa a la Agenda. Se verifica que no se exceda la Capacidad.
        /// No devuelve error.
        /// </summary>
        /// <param name="contacto">Empresa</param>
        public bool AgregarContacto(ContactoEmpresa contacto)
        {
            if (_listaContactos.Count < _capacidad)
            {
                
                _idContactos++;
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
                    
                    if (contacto is ContactoPersona)
                    {
                        ContactoPersona _tempContacto = (ContactoPersona)contacto;
                        if (_tempContacto.Nombre.Contains(texto)) { resultados.Add(_tempContacto); }
                        else if (_tempContacto.Apellido.Contains(texto)) { resultados.Add(_tempContacto); }
                        else if (_tempContacto.Email.Contains(texto)) { resultados.Add(_tempContacto); }
                        else if (_tempContacto.Telefono.Contains(texto)) { resultados.Add(_tempContacto); }
                        else if (_tempContacto.Direccion.Contains(texto)) { resultados.Add(_tempContacto); }
                    }
                    else if (contacto is ContactoEmpresa)
                    {
                        ContactoEmpresa _tempContacto = (ContactoEmpresa)contacto;
                        if (_tempContacto.RazonSocial.Contains(texto)) { resultados.Add(_tempContacto); }
                        else if (_tempContacto.Email.Contains(texto)) { resultados.Add(_tempContacto); }
                        else if (_tempContacto.Telefono.Contains(texto)) { resultados.Add(_tempContacto); }
                        else if (_tempContacto.Direccion.Contains(texto)) { resultados.Add(_tempContacto); }
                    }
                    else { ; }
                }
            }
            return resultados;
        }
        /// <summary>
        /// Elimina el contacto que coincida con el id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TRUE si se puede eliminar, FALSE en caso contrario</returns>
        public bool EliminarContacto(int id)
        {
            if (_listaContactos.Remove(_listaContactos[_listaContactos.FindIndex(elemento => elemento.ID == id)])) { return true; }
            else { return false; }
        }

        public bool EditarContacto(Contacto contactoNew)
        {
            foreach (Contacto contacto in _listaContactos)
            {
                if (contacto.ID == contactoNew.ID)
                {
                    int indice = _listaContactos.FindIndex(elemento => elemento._id == contactoNew.ID);
                    if (contacto is ContactoPersona)
                    {
                        _listaContactos[indice] = contactoNew;
                        return true;
                    }
                    else if (contacto is ContactoEmpresa)
                    {
                        _listaContactos[indice] = contactoNew;
                        return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }


    }
}
