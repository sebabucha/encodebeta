using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class SuscriptorDAO
    {
        #region "PATRON SINGLETON"
        public static SuscriptorDAO daoSuscriptor = null;
        public SuscriptorDAO() { }
        public static SuscriptorDAO getInstance()
        {
            if (daoSuscriptor == null)
            {
                daoSuscriptor = new SuscriptorDAO();
            }
            return daoSuscriptor;
        }
        #endregion

       static string cadenaConexion = "Data Source=DESKTOP-BKO5AIN\\SQLEXPRESS";
        public bool RegistrarSuscriptor(Suscriptor objSuscriptor)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarSuscriptor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombre", objSuscriptor.Nombre);
                cmd.Parameters.AddWithValue("@prmApellido", objSuscriptor.Apellido);
                cmd.Parameters.AddWithValue("@prmNumeroDocumento", objSuscriptor.NumeroDocumento);
                cmd.Parameters.AddWithValue("@prmTipoDocumento", objSuscriptor.TipoDocumento);
                cmd.Parameters.AddWithValue("@prmDireccion", objSuscriptor.Direccion);
                cmd.Parameters.AddWithValue("@prmTelefono", objSuscriptor.Telefono);
                cmd.Parameters.AddWithValue("@prmEmail", objSuscriptor.Email);
                cmd.Parameters.AddWithValue("@prmNombreUsuario", objSuscriptor.NombreUsuario);
                cmd.Parameters.AddWithValue("@prmPassword", objSuscriptor.Password);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public static bool actualizarSuscriptor(Suscriptor suscriptor, int id)
        {
            bool resultado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consultaSQL = @"UPDATE Suscriptor 
                                      SET Nombre = @Nombre,Apellido=  @Apellido, NumeroDocumento = @NumeroDocumento,
                                      TipoDocumento= @TipoDocumento,Direccion = @Direccion, Telefono = @Telefono,Email = @Email,
                                      NombreUsuario = @NombreUsuario,Password = @Password 
                                      WHERE IdSuscriptor = @IdSuscriptor";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Nombre", suscriptor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", suscriptor.Apellido);
                cmd.Parameters.AddWithValue("@NumeroDocumento", suscriptor.NumeroDocumento);
                cmd.Parameters.AddWithValue("@TipoDocumento", suscriptor.TipoDocumento);
                cmd.Parameters.AddWithValue("@Direccion", suscriptor.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", suscriptor.Telefono);
                cmd.Parameters.AddWithValue("@Email", suscriptor.Email);
                cmd.Parameters.AddWithValue("@NombreUsuario", suscriptor.NombreUsuario);
                cmd.Parameters.AddWithValue("@Password", suscriptor.Password);
                cmd.Parameters.AddWithValue("@IdSuscriptor", id);

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = consultaSQL;

                conexion.Open();

                cmd.Connection = conexion;

                cmd.ExecuteNonQuery();

                resultado = true;
            }
            catch (Exception ex)
            {
                return resultado = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }

        public static Suscriptor buscarSuscriptor(int nroDocumento, char tipoDocumento)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT IdSuscriptor,Nombre ,Apellido ,NumeroDocumento ,TipoDocumento,Direccion,Telefono ,Email,NombreUsuario ,[Password]
                                       FROM Suscriptor                                     
                                       WHERE  NumeroDocumento = @NumeroDocumento AND TipoDocumento = @TipoDocumento";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@NumeroDocumento", nroDocumento);
                cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSQL;
                conexion.Open();
                cmd.Connection = conexion;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        suscriptor.IdSuscriptor = Convert.ToInt32(dr.GetInt32(0));
                        suscriptor.Nombre = dr.GetString(1);
                        suscriptor.Apellido = dr.GetString(2);
                        suscriptor.NumeroDocumento = Convert.ToInt32(dr.GetString(3));
                        suscriptor.TipoDocumento = dr.GetString(4);
                        suscriptor.Direccion = dr.GetString(5);
                        suscriptor.Telefono = Convert.ToInt32(dr.GetString(5));
                        suscriptor.Email = dr.GetString(7);
                        suscriptor.NombreUsuario = dr.GetString(8);
                        suscriptor.Password = dr.GetString(9);

                    }
                }


            }
            catch (Exception)
            {
                return suscriptor = null;
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return suscriptor;
        }

        public static bool validarNroyTipoDoc(int nroDocumento, char tipoDocumento)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT IdSuscriptor,Nombre ,Apellido ,NumeroDocumento ,TipoDocumento ,Direccion, Telefono ,Email, Usuario ,[Password]
                                       FROM Suscriptor                                     
                                       WHERE  NumeroDocumento = @NumeroDocumento AND TipoDocumento = @TipoDocumento";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@NumeroDocumento", nroDocumento);
                cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSQL;
                conexion.Open();
                cmd.Connection = conexion;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        suscriptor.IdSuscriptor = Convert.ToInt32(dr.GetInt32(0));
                        suscriptor.Nombre = dr.GetString(1);
                        suscriptor.Apellido = dr.GetString(2);
                        suscriptor.NumeroDocumento = Convert.ToInt32(dr.GetString(3));
                        suscriptor.TipoDocumento = dr.GetString(4);
                        suscriptor.Direccion = dr.GetString(5);
                        suscriptor.Telefono = Convert.ToInt32(dr.GetString(5));
                        suscriptor.Email = dr.GetString(7);
                        suscriptor.NombreUsuario = dr.GetString(8);
                        suscriptor.Password = dr.GetString(9);

                        return resultado = true;
                    }
                }


            }
            catch (Exception)
            {
                return resultado = false;
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }

        public static Suscriptor buscarSuscriptorNoVigente(string nroDocumento, string tipoDocumento)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT sus.IdAsociacion,s.Nombre 'nombre',Apellido 'apellido',s.NumeroDocumento 'nroDocumento',s.TipoDocumento 'tipoDocumento',s.Direccion 'direccion',s.Telefono 'telefono',s.Email 'email',s.Usuario 'user',s.[Password] 'pass'
                                       FROM Suscripcion sus JOIN Suscriptor s ON sus.IdAsociacion = s.IdSuscriptor 
                                       WHERE  s.NumeroDocumento = @NroDocumento AND s.TipoDocumento = @TipoDocumento AND FechaAlta IS NULL";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@NroDocumento", nroDocumento);
                cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSQL;
                conexion.Open();
                cmd.Connection = conexion;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        suscriptor.IdSuscriptor = Convert.ToInt32(dr.GetInt32(0));
                        suscriptor.Nombre = dr.GetString(1);
                        suscriptor.Apellido = dr.GetString(2);
                        suscriptor.NumeroDocumento = Convert.ToInt32(dr.GetString(3));
                        suscriptor.TipoDocumento = dr.GetString(4);
                        suscriptor.Direccion = dr.GetString(5);
                        suscriptor.Telefono = Convert.ToInt32(dr.GetString(5));
                        suscriptor.Email = dr.GetString(7);
                        suscriptor.NombreUsuario = dr.GetString(8);
                        suscriptor.Password = dr.GetString(9);

                    }
                }


            }
            catch (Exception)
            {
                return suscriptor = null;
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return suscriptor;
        }

        public static bool validarNombreUsuario(string nameUsuario)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT IdSuscriptor,Nombre ,Apellido ,NumeroDocumento ,TipoDocumento,Direccion,Telefono ,Email,NombreUsuario ,[Password]
                                       FROM Suscriptor                                     
                                       WHERE  NombreUsuario = @Usuario";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@Usuario", nameUsuario);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSQL;
                conexion.Open();
                cmd.Connection = conexion;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        suscriptor.IdSuscriptor = Convert.ToInt32(dr.GetInt32(0));
                        suscriptor.Nombre = dr.GetString(1);
                        suscriptor.Apellido = dr.GetString(2);
                        suscriptor.NumeroDocumento = Convert.ToInt32(dr.GetString(3));
                        suscriptor.TipoDocumento = Convert.ToChar(dr.GetString(4));
                        suscriptor.Direccion = dr.GetString(5);
                        suscriptor.Telefono = Convert.ToInt32(dr.GetString(5));
                        suscriptor.Email = dr.GetString(7);
                        suscriptor.NombreUsuario = dr.GetString(8);
                        suscriptor.Password = dr.GetString(9);

                        return resultado = true;
                    }
                }


            }
            catch (Exception)
            {
                return resultado = false;
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }


    }


}
