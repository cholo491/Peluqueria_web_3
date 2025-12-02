using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BackendPeluqueria.Models
{
    [Table("peluquero")]
    public class Peluquero : BaseModel
    {
        [PrimaryKey("peluquero_id", false)]
        public int PeluqueroId { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("especialidad")]
        public string Especialidad { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("creado_en")]
        public DateTime CreadoEn { get; set; }
    }
}
