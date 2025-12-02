using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendPeluqueria.Models;
using Supabase;

namespace BackendPeluqueria.Services
{
    public class UsuarioService
    {
        public async Task<List<Usuario>> GetAll()
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Usuario>().Get();
            
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron usuarios en la base de datos.");
            }
            
            return response.Models;
        }

        public async Task<Usuario> GetById(int id)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Usuario>().Where(x => x.UsuarioId == id).Get();
            
            if (response.Model == null)
            {
                throw new KeyNotFoundException($"No se encontró el usuario con ID {id}.");
            }
            
            return response.Model;
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Usuario>().Insert(usuario);
            return response.Model;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Usuario>().Update(usuario);
            return response.Model;
        }

        public async Task Delete(int id)
        {
            var client = await Conexion.GetClient();
            await client.From<Usuario>().Where(x => x.UsuarioId == id).Delete();
        }
    }
}
