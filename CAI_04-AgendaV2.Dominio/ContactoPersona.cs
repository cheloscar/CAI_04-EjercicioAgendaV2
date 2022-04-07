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
        /// Con este constructor se crea un contacto completo con toda la información
        /// </summary>
        /// <param name="contacto"></param>
        public ContactoPersona(ContactoPersona contacto)
        : base (contacto.Email, contacto.Telefono, contacto.Direccion, contacto.ID)
        {
            _nombre = contacto.Nombre;
            _apellido = contacto.Apellido;
            _fechaNacimiento = contacto.FechaNacimiento;
        }

        /// <summary>
        /// Crear un ContactoPersona con todas las variables
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="email"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="fechaNac"></param>
        /// <param name="id"></param>
        public ContactoPersona(string nombre, string apellido, string email, string telefono, string direccion, DateTime fechaNac, int id)
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
