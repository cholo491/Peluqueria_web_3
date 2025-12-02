using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendPeluqueria.Models;
using Supabase;
namespace BackendPeluqueria.Services
{
    public class Registro
    {
        public async Task<Usuario> Register(string username, string password, string email)
        {

            var client = await Conexion.GetClient();
            var hashedPassword = HashPassword(password);
            bool exists = (await client.From<Usuario>()
                .Where(x => x.Username == username || x.Email == email)
                .Get()).Models.Count > 0;
            if (exists)
            {
                throw new Exception("El nombre de usuario o correo electrónico ya está en uso.");
            }

            var nuevoUsuario = new Usuario
            {
                Username = username,
                Password = hashedPassword,
                Email = email
            };

            var response = await client.From<Usuario>().Insert(nuevoUsuario);
            return response.Model;
        }
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}