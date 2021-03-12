using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Suscriptor
    {
        public int IdSuscriptor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Direccion { get; set; }
        public string NroDocumento { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }


        private int idAsociacion;
        private int idSuscriptor;
        private DateTime fechaAlta;
        private DateTime fechaFin;
        private string motivoFin;

        public Suscriptor(int idAsociacion, int idSuscriptor, DateTime fechaAlta, DateTime fechaFin, string motivoFin)
        {
            this.idAsociacion = idAsociacion;
            this.idSuscriptor = idSuscriptor;
            this.fechaAlta = fechaAlta;
            this.fechaFin = fechaFin;
            this.motivoFin = motivoFin;
        }
        public Suscriptor()
        {

        }
        public int IdAsociacion { get => idAsociacion; set => idAsociacion = value; }
        public int IdSuscritor { get => idSuscriptor; set => idSuscriptor = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string MotivoFin { get => motivoFin; set => motivoFin = value; }
    }
}



