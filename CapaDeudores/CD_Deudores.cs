using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDeudores
{
    public class CD_Deudores
    {
        public List<Deudores> Listar()
        {
            List<Deudores> lista = new List<Deudores>();

            try{
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select IdDeudor,Nombre,Paterno,Materno,Prestamo,Telefono,Email,FechaPrestamo,DiaCobro,Meses,Intereses from Deudores";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Deudores()
                                {
                                    IdDeudor = Convert.ToInt32(dr["IdDeudor"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Paterno = dr["Paterno"].ToString(),
                                    Materno = dr["Materno"].ToString(),
                                    Prestamo = Convert.ToInt32(dr["Prestamo"]),
                                    Telefono = dr["Telefono"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    FechaPrestamo = Convert.ToDateTime(dr["FechaPrestamo"]),
                                    DiaCobro = Convert.ToInt32(dr["DiaCobro"]),
                                    Meses = Convert.ToInt32(dr["Meses"]),
                                    Intereses = Convert.ToInt32(dr["Intereses"]),
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Deudores>();
            }

            return lista;
        }

        public int Registrar(Deudores obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Paterno", obj.Paterno);
                    cmd.Parameters.AddWithValue("Materno", obj.Materno);
                    cmd.Parameters.AddWithValue("Prestamo", obj.Prestamo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("FechaPrestamo", obj.FechaPrestamo);
                    cmd.Parameters.AddWithValue("DiaCobro", obj.DiaCobro);
                    cmd.Parameters.AddWithValue("Meses", obj.Meses);
                    cmd.Parameters.AddWithValue("Intereses", obj.Intereses);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch(Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }

        public bool Editar(Deudores obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("IdDeudor", obj.IdDeudor);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Paterno", obj.Paterno);
                    cmd.Parameters.AddWithValue("Materno", obj.Materno);
                    cmd.Parameters.AddWithValue("Prestamo", obj.Prestamo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("FechaPrestamo", obj.FechaPrestamo);
                    cmd.Parameters.AddWithValue("DiaCobro", obj.DiaCobro);
                    cmd.Parameters.AddWithValue("Meses", obj.Meses);
                    cmd.Parameters.AddWithValue("Pagos", obj.Pagos);
                    cmd.Parameters.AddWithValue("Intereses", obj.Intereses);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }


        public bool Eliminar (int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from deudores where IdDeudor = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch(Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

    }
}
