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
        /// Constructor para crear un contacto del tipo Empresa a partir de la clase Empresa que se recibe como parámetro.
        /// </summary>
        /// <param name="contacto">Contacto del tipo Empresa</param>
        public ContactoEmpresa(ContactoEmpresa contacto)
        : base(contacto.Email, contacto.Telefono, contacto.Direccion, contacto.ID)
        {
            _razonSocial = contacto.RazonSocial;
            _fechaConstitucion = contacto.FechaConstitucion;
        }

        /// <summary>
        /// Constructor para crear un contacto del tipo Empresa a partir de todas las propiedades.
        /// Las primeras propiedades corresponden con la clase base.
        /// </summary>
        /// <param name="email">base</param>
        /// <param name="telefono">base</param>
        /// <param name="direccion">base</param>
        /// <param name="id">base</param>
        /// <param name="razonSocial">Empresa</param>
        /// <param name="fechaConst">Empresa</param>
        public ContactoEmpresa(string email, string telefono, string direccion, int id, string razonSocial, DateTime fechaConst)
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

        public void ActualizarRazonSocial(string razonSocial)
        {
            _razonSocial = razonSocial;
        }

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
