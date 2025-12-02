using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BackendPeluqueria.Models
{
    [Table("usuarios")]
    public class Usuario : BaseModel
    {
        [PrimaryKey("usuario_id", false)]
        public int UsuarioId { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("apellido")]
        public string Apellido { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("rol")]
        public string Rol { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("creado_en")]
        public DateTime CreadoEn { get; set; }
    }
}
