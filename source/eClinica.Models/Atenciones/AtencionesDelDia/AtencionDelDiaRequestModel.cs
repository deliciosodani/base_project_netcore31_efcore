using System;

namespace eClinica.Models.Atenciones.AtencionesDelDia
{
    public class AtencionDelDiaRequestModel
    {
        public int NumeroHistoria { get; set; }
        public int NumeroDiario { get; set; }
        public string NumeroVida { get; set; }
        public string Documento { get; set; }
        public string NombreCliente { get; set; }
        public string TipoAtencion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
