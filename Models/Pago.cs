using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BackendPeluqueria.Models
{
    [Table("pagos")]
    public class Pago : BaseModel
    {
        [PrimaryKey("pago_id", false)]
        public int PagoId { get; set; }

        [Column("reserva_id")]
        public int ReservaId { get; set; }

        [Column("monto")]
        public decimal Monto { get; set; }

        [Column("metodo")]
        public string Metodo { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("fecha_pago")]
        public DateTime? FechaPago { get; set; }
    }
}
