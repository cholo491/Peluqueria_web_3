using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendPeluqueria.Models;
using Supabase;
namespace BackendPeluqueria.Services
{
    public class Login
    {
        public async Task<Usuario> Authenticate(string username, string password,int intentos)
        {

            var client = await Conexion.GetClient();
            var password = password;
            var hashedPassword = HashPassword(password);
            bool bruteForce = intentos > 5;
            if (bruteForce)
            {
                metodoPanic();
            }
            var response = await client.From<Usuario>()
                .Where(x => x.Username == username && x.Password == hashedPassword)
                .Get();

            return response.Models.Count > 0 ? response.Models[0] : null;
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
        private void metodoPanic()
        {
            throw new Exception("Demasiados intentos fallidos de inicio de sesion. Sistema bloqueado.");

        }
        private void cookies(var cookie)
        {
            var cookie = cookie;
            if(cookie == true)
            {
                //nose cookies :v
            }

        }
    }
}