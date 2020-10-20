namespace eClinica.Core.Configuration
{
    public class Enums
    {
        public enum CodigosResponse
        {
            Ok,
            Error,
            Advertencia,
            ErrorControlar
        }

        public enum EstadosAtencion
        {
            ESPERA,
            ATENCION,
            INTERRUMPIDA,
            ANULADA,
            FINALIZADA,
            TRUNCADO
        }

        public enum SubEstadoAtencion
        {
            ENFERMERIA,
            MEDICINA
        }

        public enum RetornoRepo
        {
            Ok = 0,
            Error = 1,
            Warning = 2
        }

        public enum RetornoMiddleware
        {
            Error,
            Ok,
            Revision
        }

        public enum RetornoSLAB
        {
            Error = 0,
            Ok = 1,
            Warning = 2
        }

        public enum RetornoRepoHHCC
        {
            Error = 1,
            Ok = 0,
            Warning = 2
        }


        public enum WSInterfaceAVL
        {
            Ok = 0
        }


        public enum RetornoVideoLlamada
        {
            Ok = 01,
            Error = 02
        }

        public enum ValoresTestPack
        {
            No,
            Positivo,
            Negativo,
            Dudoso
        }

        public enum TipoHistorias
        {
            GENERAL,
            CARDIOLOGIA,
            SINHISTORIA,
            OFTALMOLOGIA,
            FISIOTERAPIA,
            OTORRINOLARINGOLOGIA,
            GINECOLOGIA,
            UROLOGIA,
            GASTROENTEROLOGIA,
            RECEPCIONDESERVICIOVIACHAT,
            CHATDEORIENTACIONMEDICA,
            CHATDEORIENTACIONPEDIATRICA,
            LINEAMEDICA,
            VIDEOLLAMADADEORIENTACIONPEDIATRICA,
            MGT,
            CHATDEORIENTACIONMEDICAPEDIATRICA,
            VIDEOCHATDEORIENTACIONMEDICA,
            VIDEOCHATDEORIENTACIONPEDIATRICA,
            PEDIATRIAVIRTUAL,
            PEDIATRIAVIRTUALPROGRAMADA
        }

        public enum TipoHistoricoHistorias
        {
            CLINICA,
            MOVIL,
            PLACAS
        }

        public enum TipoGasto
        {
            CONSUMO,
            VENCIMIENTO,
            ROTURA,
            FALTANTE
        }

        public enum TipoServicio
        {
            LineaMedica = 3,
            MGT = 26
        }

        public enum Clinicas
        {
            AtenciónVirtual = 41,
            Movil = 40
        }

        public enum TipoEdad
        {
            Años = 1,
            Meses = 2,
            Días = 3
        }

        public enum TipoAtencion
        {
            ESPECIALIDAD,
            PEDIATRIA,
            ADULTO,
            VIRTUAL
        }

        public enum EstadoVom
        {
            SinEstado,
            SeEnviaMail,
            UsuarioComienzaLlamada,
            MedicoFinalizaLlamada,
            UsuarioCancelaLlamada
        }

        public enum TrazaComunicacionAccion
        {
            CREARPETICION,
            MODIFICARESTADOVOM,
            REENVIARLINK
        }

        public enum Sedes
        {
            URUGUAY,
            COLOMBIA
        }

    }
}
