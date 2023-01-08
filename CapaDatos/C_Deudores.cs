using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDeudores;
using CapaEntidad;

namespace CapaDatos
{
    public class C_Deudores
    {
        private CD_Deudores objCapaDato = new CD_Deudores();

        public List<Deudores> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Deudores obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if(string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del usuario no puede estar vacío";
            }
            if (string.IsNullOrEmpty(obj.Paterno) || string.IsNullOrWhiteSpace(obj.Paterno))
            {
                Mensaje = "El apellido paterno del usuario no puede estar vacío";
            }
            if (string.IsNullOrEmpty(obj.Materno) || string.IsNullOrWhiteSpace(obj.Materno))
            {
                Mensaje = "El apellido materno del usuario no puede estar vacío";
            }
            if (obj.Prestamo.Equals(0) || obj.Prestamo.Equals(null))
            {
                Mensaje = "La cantidad prestada no puede estar vacía";
            }
            if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
            {
                Mensaje = "El correo del usuario no puede estar vacío";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Deudores obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del usuario no puede estar vacío";
            }
            if (string.IsNullOrEmpty(obj.Paterno) || string.IsNullOrWhiteSpace(obj.Paterno))
            {
                Mensaje = "El apellido paterno del usuario no puede estar vacío";
            }
            if (string.IsNullOrEmpty(obj.Materno) || string.IsNullOrWhiteSpace(obj.Materno))
            {
                Mensaje = "El apellido materno del usuario no puede estar vacío";
            }
            if (obj.Prestamo.Equals(0) || obj.Prestamo.Equals(null))
            {
                Mensaje = "La cantidad prestada no puede estar vacía";
            }
            if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
            {
                Mensaje = "El correo del usuario no puede estar vacío";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
