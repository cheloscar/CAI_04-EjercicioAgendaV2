using System;
using System.Globalization;

namespace CAI_02EjercicioAgendaV2
{
    public class Contacto
    {

        //Variables de clase, por orden de importancia
        private string _nombre;     // Dato #1
        private string _apellido;   // Dato #2
        private string _email;      // Dato #3 
        private string _telefono;   // Dato #4
        private string _direccion;  // Dato #5
        private DateTime _FechaNac; // Dato #6
        private int _id;            // Dato #7
        private int _contadorLlamadas;


        //Propiedades de clase
        public string Nombre
        {
            get { return _nombre; }
        }

        public string Apellido
        {
            get { return _apellido; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string Telefono
        {
            get { return _telefono; }
        }

        public string Direccion
        {
            get { return _direccion; }
        }

        public DateTime FechaNacimiento
        {
            get { return _FechaNac; }
        }

        public int ID
        {
            get { return _id; }
        }

        public int ContadorLlamadas
        {
            get { return _contadorLlamadas; }
        }


        //Constructores de clase

        /// <summary>
        /// Con este constructor se crea un contacto completo con toda la información
        /// </summary>
        /// <param name="contacto"></param>
        public Contacto(Contacto contacto)
        {
            _nombre = contacto.Nombre;
            _apellido = contacto.Apellido;
            _email = contacto.Email;
            _direccion = contacto.Direccion;
            _FechaNac = contacto.FechaNacimiento;
            _id = contacto.ID;
        }


        /// <summary>
        /// Cómo mínimo un contacto debe tener Nombre, Apellido e Email.
        /// El ID es asignado por la agenda.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="email"></param>
        public Contacto(string nombre, string apellido, string email, int id)
        {
            _nombre = nombre;
            _apellido = apellido;
            _email = email;
            _id = id;
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

        public void ActualizarEmail(string email)
        {
            _email = email;
        }

        public void ActualizarTelefono(string tel)
        {
            _telefono = tel;
        }

        public void ActualizarDireccion(string direccion)
        {
            _direccion = direccion;
        }

        public void ActualizarFechaNacimiento(DateTime fechaNac)
        {
            _FechaNac = fechaNac;
        }

        public void ActualizarID(int id)
        {
            _id = id;
        }
        /// <summary>
        /// Incrementa en una unidad el contador de llamadas del contacto
        /// </summary>
        public void IncrementarContLlamadas()
        {
            _contadorLlamadas++;
        }

    }
}
