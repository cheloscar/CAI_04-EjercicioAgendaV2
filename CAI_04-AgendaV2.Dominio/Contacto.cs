using System;
using System.Globalization;

namespace CAI_02EjercicioAgendaV2
{
    public abstract class Contacto
    {

        //Variables de clase, por orden de importancia
        internal string _email;
        internal string _telefono;
        internal string _direccion;
        internal int _id;
        internal int _contadorLlamadas;


        //Propiedades de clase
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
            _email = contacto.Email;
            _telefono = contacto.Telefono;
            _direccion = contacto.Direccion;
            _id = contacto.ID;
            _contadorLlamadas = contacto.ContadorLlamadas;
        }

        /// <summary>
        /// Datos necesarios para inicializar la clase.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="id"></param>
        public Contacto(string email, string telefono, string direccion, int id)
        {
            _email = email;
            _telefono = telefono;
            _direccion = direccion;
            _id = id;
        }

        
        //Métodos de clase

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
        public void ActualizarID(int id)
        {
            _id = id;
        }
        /// <summary>
        /// Incrementa en una unidad el contador de llamadas del contacto
        /// </summary>
        public void Llamar()
        {
            _contadorLlamadas++;
        }
        /// <summary>
        /// Esté método evalúa la fecha ingresada y la compara con la fecha de HOY
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>True si la fecha ingresada es menor a hoy, de lo contrario false</returns>
        internal bool VerificarFechaIngresada(DateTime fecha)
        {
            if (Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(fecha.ToString("yyyy")) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
