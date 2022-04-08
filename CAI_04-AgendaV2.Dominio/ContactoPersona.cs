using System;
using System.Globalization;

namespace CAI_02EjercicioAgendaV2
{
    public class ContactoPersona : Contacto
    {

        //Variables de clase, por orden de importancia
        internal string _nombre;
        internal string _apellido;
        internal DateTime _fechaNacimiento;


        //Propiedades de clase
        public string Nombre
        {
            get { return _nombre; }
        }
        public string Apellido
        {
            get { return _apellido; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
        }

        //Constructores de clase

        /// <summary>
        /// Constructor para crear un contacto del tipo Persona a partir de la clase Persona que se recibe como parámetro.
        /// </summary>
        /// <param name="contacto">Contacto del tipo Persona</param>
        public ContactoPersona(ContactoPersona contacto)
        : base (contacto.Email, contacto.Telefono, contacto.Direccion, contacto.ID)
        {
            _nombre = contacto.Nombre;
            _apellido = contacto.Apellido;
            _fechaNacimiento = contacto.FechaNacimiento;
        }

        /// <summary>
        /// Constructor para crear un contacto del tipo Persona a partir de todas las propiedades.
        /// Las primeras propiedades corresponden con la clase base.
        /// </summary>
        /// <param name="email">base</param>
        /// <param name="telefono">base</param>
        /// <param name="direccion">base</param>
        /// <param name="id">base</param>
        /// <param name="nombre">Persona</param>
        /// <param name="apellido">Persona</param>
        /// <param name="fechaNac">Persona</param>
        public ContactoPersona(string email, string telefono, string direccion, int id, string nombre, string apellido, DateTime fechaNac)
        : base (email, telefono, direccion, id)
        {
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechaNac;
        }


        //Métodos de clase

        public void ActualizarNombre(string nombre)
        {
            _nombre = nombre;
        }

        public void ActualizarApellido(string apellido)
        {
            _apellido = apellido;
        }

        public void ActualizarFechaNacimiento(DateTime fechaNac)
        {
            if (VerificarFechaIngresada(fechaNac))
            {
                _fechaNacimiento = fechaNac;
            }
            else
            {
                _fechaNacimiento = DateTime.Parse("01/01/1800");
            }
        }
        public int Edad()
        {
            return Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(_fechaNacimiento.ToString("yyyy"));
        }
    }
}
