using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BackendPeluqueria.Models
{
    [Table("reservas")]
    public class Reserva : BaseModel
    {
        [PrimaryKey("reserva_id", false)]
        public int ReservaId { get; set; }

        [Column("peluquero_id")]
        public int PeluqueroId { get; set; }

        [Column("cliente_id")]
        public int? ClienteId { get; set; }

        [Column("admin_id")]
        public int AdminId { get; set; }

        [Column("servicio_id")]
        public int? ServicioId { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("hora_inicio")]
        public TimeSpan HoraInicio { get; set; }

        [Column("hora_fin")]
        public TimeSpan HoraFin { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("fecha_creada")]
        public DateTime FechaCreada { get; set; }
    }
}
