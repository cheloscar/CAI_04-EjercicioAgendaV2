using System;
using System.Globalization;

namespace CAI_02EjercicioAgendaV2
{
    public class ContactoEmpresa : Contacto
    {

        //Variables de clase, por orden de importancia
        internal string _razonSocial;
        internal DateTime _fechaConstitucion;


        //Propiedades de clase
        public string RazonSocial
        {
            get { return _razonSocial; }
        }
        public DateTime FechaConstitucion
        {
            get { return _fechaConstitucion; }
        }

        //Constructores de clase

        /// <summary>
        /// Con este constructor se crea un contacto completo con toda la información
        /// </summary>
        /// <param name="contacto"></param>
        public ContactoEmpresa(ContactoEmpresa contacto)
        : base(contacto.Email, contacto.Telefono, contacto.Direccion, contacto.ID)
        {
            _razonSocial = contacto.RazonSocial;
            _fechaConstitucion = contacto.FechaConstitucion;
        }

        /// <summary>
        /// Cómo mínimo un contacto debe tener Nombre, Apellido e Email.
        /// El ID es asignado por la agenda.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="email"></param>
        public ContactoEmpresa(string razonSocial, string email, string telefono, string direccion, DateTime fechaConst, int id)
        : base(email, telefono, direccion, id)
        {
            _razonSocial = razonSocial;
            if (VerificarFechaIngresada(fechaConst))
            {
                _fechaConstitucion = fechaConst;
            }
            else
            {
                _fechaConstitucion = DateTime.Parse("01/01/1800");
            }
        }

        //Métodos de clase

        public int Antiguedad()
        {
            return Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(_fechaConstitucion.ToString("yyyy"));
        }

        public void ActualizarFechaConstitucion(DateTime fechaConst)
        {
            if (VerificarFechaIngresada(fechaConst))
            {
                _fechaConstitucion = fechaConst;
            }
            else
            {
                _fechaConstitucion = DateTime.Parse("01/01/1800");
            }
        }

        
    }
}
