using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BackendPeluqueria.Models
{
    [Table("servicios")]
    public class Servicio : BaseModel
    {
        [PrimaryKey("servicio_id", false)]
        public int ServicioId { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("duracion_min")]
        public int DuracionMin { get; set; }

        [Column("precio_base")]
        public decimal PrecioBase { get; set; }

        [Column("estado")]
        public string Estado { get; set; }
    }
}
