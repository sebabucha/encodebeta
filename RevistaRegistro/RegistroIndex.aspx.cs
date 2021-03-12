using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogica;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CapaAccesoDatos;
using RevistaRegistro;




namespace RevistaRegistro
{
    public partial class RegistroIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                {

                }
            }
        }


        private Suscriptor GetEntity()
        {
            Suscriptor objSuscriptor = new Suscriptor();
            objSuscriptor.IdSuscriptor = 0;
            objSuscriptor.Nombre = txtNombre.Text;
            objSuscriptor.Apellido = txtApellido.Text;
            objSuscriptor.NumeroDocumento = (int)Convert.ToInt32(txtNumeroDocumento.Text);
            objSuscriptor.TipoDocumento = (ddlTipoDocumento.SelectedValue == "PASAPORTE") ? 'D' : 'P';
            objSuscriptor.Direccion = txtDireccion.Text;
            objSuscriptor.Telefono = (int)Convert.ToInt64(txtTelefono.Text);
            objSuscriptor.Email = txtEmail.Text;
            objSuscriptor.NombreUsuario = txtUsuario.Text;
            objSuscriptor.Password = txtContraseña.Text;

            return objSuscriptor;
        }


        private void limpiarCampos()
        {

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNumeroDocumento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";

        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            // Registro del paciente
            Suscriptor objSuscriptor = GetEntity();
            // enviar a la capa de logica de negocio
            bool response = SuscriptorLN.getInstance().RegistrarSuscriptor(objSuscriptor);
            if (response == true)
            {
                Response.Write("<script>alert('Usted se registro correctamente!')</script>");

            }
            else
            {
                Response.Write("<script>alert('Hubo un error en el registro, por favor verifique y vuelva a intentarlo')</script>");
            }
        }

        SuscriptorDAO susDAO = new SuscriptorDAO();

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Suscriptor suscriptor = GetEntity();
            Suscriptor suscriptor1 = new Suscriptor();
            suscriptor1 = SuscripcionDAO.buscarSuscriptorVigente(int.Parse(txtNumDocBuscar.Text), Convert.ToChar(dllTipoDocBuscar.Text));
            Suscriptor suscriptor2 = SuscripcionDAO.buscarSuscriptorNoVigente(int.Parse(txtNumDocBuscar.Text), Convert.ToChar(dllTipoDocBuscar.Text));
            txtNumeroDocumento.Enabled = false;
            ddlTipoDocumento.Enabled = false;
            txtUsuario.Enabled = false;
            if (suscriptor1 != null)
            {
                txtIdSuscriptor.Text = suscriptor1.IdSuscriptor.ToString();
                txtNombre.Text = suscriptor1.Nombre;
                txtApellido.Text = suscriptor1.Apellido;
                txtNumeroDocumento.Text = suscriptor1.NumeroDocumento.ToString();
                ddlTipoDocumento.Text = suscriptor1.TipoDocumento.ToString();
                txtDireccion.Text = suscriptor1.Direccion;
                txtTelefono.Text = suscriptor1.Telefono.ToString();
                txtEmail.Text = suscriptor1.Email;
                txtUsuario.Text = suscriptor1.NombreUsuario;
                txtContraseña.Text = suscriptor1.Password;



            }
            else if (suscriptor2 != null)
            {
                Response.Write("<script>alert('La suscripcion se dio de baja. Por favor registrese nuevamente')</script>");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Suscriptor suscriptor = GetEntity();

            int nroDocumento = Convert.ToInt32(txtNumeroDocumento.Text);
            Suscriptor TipoDocumento = Convert.ToChar(dllTipoDocBuscar.Text);

            int idSuscriptor = SuscripcionDAO.idSuscriptor(nroDocumento, Convert.ToChar(TipoDocumento);


            Suscriptor suscriptorVigente = SuscripcionDAO.buscarSuscriptorVigente(nroDocumento, TipoDocumento);
            if (suscriptor == null)
            {
                Response.Write("<script>alert('Aun no tiene suscripcion')</script>");
                Response.Write("<script>OnClientClick = return confirm ('¿Quiere modificar la suscripcion?')</script>");
                bool respuesta = SuscripcionDAO.insertarSuscripcion(idSuscriptor);
                if (respuesta == true)
                {
                    Response.Write("<script>alert('Usted se ha registrado correctamente en nuestra base de datos')</script>");
                    limpiarCampos();
                }
                else
                {
                    Response.Write("<script>alert('No se pudo registrar, verifique datos y vuelva a intentarlo')</script>");
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Suscriptor suscriptor = GetEntity();

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) || !string.IsNullOrWhiteSpace(txtApellido.Text) || !string.IsNullOrWhiteSpace(txtNumeroDocumento.Text) || !string.IsNullOrWhiteSpace(ddlTipoDocumento.Text)
             || !string.IsNullOrWhiteSpace(txtDireccion.Text) || !string.IsNullOrWhiteSpace(txtTelefono.Text) || !string.IsNullOrWhiteSpace(txtEmail.Text) || !string.IsNullOrWhiteSpace(txtUsuario.Text) || !string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                bool respuesta = SuscriptorDAO.actualizarSuscriptor(suscriptor, Convert.ToInt32(this.txtIdSuscriptor.Text));
                if (respuesta == true)
                {
                    Response.Write("<script>alert('Usted pudo actualizar sus datos correctamente')</script>");
                    limpiarCampos();
                }
                else
                {
                    Response.Write("<script>alert('No se pudo actualizar nuevos datos, por favor verifique y vuelva a intentarlo')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Usted posee campos vacios, por favor verifique y vuelva a intentarlo')</script>");
            }
        }
    }








}
