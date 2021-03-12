using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class SuscriptorLN
    {
        #region "PATRON SINGLETON"
        private static SuscriptorLN objSuscriptor = null;
        private SuscriptorLN() { }
        public static SuscriptorLN getInstance()
        {
            if (objSuscriptor == null)
            {
                objSuscriptor = new SuscriptorLN();
            }
            return objSuscriptor;
        }
        #endregion

        public bool RegistrarSuscriptor(Suscriptor objSuscriptor)
        {
            try
            {
                return SuscriptorDAO.getInstance().RegistrarSuscriptor(objSuscriptor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

