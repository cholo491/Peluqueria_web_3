using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BackendPeluqueria.Models
{
    [Table("notificaciones")]
    public class Notificacion : BaseModel
    {
        [PrimaryKey("notificacion_id", false)]
        public int NotificacionId { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("mensaje")]
        public string Mensaje { get; set; }

        [Column("enviado_en")]
        public DateTime EnviadoEn { get; set; }
    }
}
