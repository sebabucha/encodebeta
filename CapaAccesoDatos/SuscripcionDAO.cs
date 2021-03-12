using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class SuscripcionDAO
    {
        static string cadenaConexion = "Data Source=DESKTOP-BKO5AIN\\SQLEXPRESS";
        public static int idSuscriptor(int nroDocumento, string tipoDocumento)
        {
            int idSuscriptor = 0;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor  = new Suscriptor();

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT IdSuscriptor
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

                        idSuscriptor = Convert.ToInt32(dr.GetInt32(0));

                    }
                }


            }
            catch (Exception)
            {
                return idSuscriptor = 0;
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return idSuscriptor;
        }
        public static bool insertarSuscripcion(int idSuscriptor)
        {
            bool resultado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {

                SqlCommand cmd = new SqlCommand();

                string consultaSQL = "INSERT INTO Suscripcion(IdSuscriptor, FechaAlta) VALUES (@IdSuscriptor, GETDATE())";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@IdSuscriptor", idSuscriptor);


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
        public static Suscriptor buscarSuscriptorVigente(int nroDocumento, char tipoDocumento)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT sus.IdAsociacion,s.Nombre ,Apellido ,s.NumeroDocumento ,s.TipoDocumento ,s.Direccion ,s.Telefono ,s.Email ,s.NombreUsuario ,s.[Password]
                                       FROM Suscripcion sus JOIN Suscriptor s ON sus.IdAsociacion = s.IdSuscriptor 
                                       WHERE  s.NumeroDocumento = @NroDocumento AND s.TipoDocumento = @TipoDocumento";
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
                        suscriptor.NumeroDocumento = int.Parse(dr.GetString(3));
                        suscriptor.TipoDocumento = dr.GetString(4);
                        suscriptor.Direccion = dr.GetString(5);
                        suscriptor.Telefono = int.Parse(dr.GetString(5));
                        suscriptor.Email = dr.GetString(7);
                        suscriptor.NombreUsuario = dr.GetString(8);
                        suscriptor.Password = dr.GetString(9);
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return suscriptor;
        }
        public static Suscriptor buscarSuscriptorNoVigente(int nroDocumento, char tipoDocumento)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT sus.IdAsociacion,s.Nombre 'nombre',Apellido 'apellido',s.NumeroDocumento 'nroDoc',s.TipoDocumento 'tipoDocumento',s.Direccion 'direccion',s.Telefono 'telefono',s.Email 'email',s.Usuario 'user',s.[Password] 'pass'
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
        public static bool validarNroyTipoDoc(int nroDocumento, char tipoDocumento)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT IdSuscriptor,Nombre ,Apellido ,NumeroDocumento ,TipoDocumento, Direccion, Telefono , Email, Usuario ,[Password]
                                       FROM Suscriptor                                     
                                       WHERE  NumeroDocumento = @NroDocumento AND TipoDocumento = @TipoDocumento";
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
                        suscriptor.NumeroDocumento = int.Parse(dr.GetString(3));
                        suscriptor.TipoDocumento = dr.GetString(4);
                        suscriptor.Direccion = dr.GetString(5);
                        suscriptor.Telefono = int.Parse(dr.GetString(5));
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
        public static bool validarNombreUsuario(string Usuario)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT IdSuscriptor,Nombre ,Apellido ,NumeroDocumento ,TipoDocumento,Direccion,Telefono ,Email,NombreUsuario ,[Password]
                                       FROM Suscriptor                                     
                                       WHERE  NombreUsuario = @NombreUsuario";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@Usuario", Usuario);
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
                        suscriptor.NumeroDocumento = int.Parse(dr.GetString(3));
                        suscriptor.TipoDocumento = (dr.GetString(4);
                        suscriptor.Direccion = dr.GetString(5);
                        suscriptor.Telefono = int.Parse(dr.GetString(5));
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
