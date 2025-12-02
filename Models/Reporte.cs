using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BackendPeluqueria.Models
{
    [Table("reportes")]
    public class Reporte : BaseModel
    {
        [PrimaryKey("reporte_id", false)]
        public int ReporteId { get; set; }

        [Column("admin_id")]
        public int AdminId { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("fecha_generado")]
        public DateTime FechaGenerado { get; set; }
    }
}
