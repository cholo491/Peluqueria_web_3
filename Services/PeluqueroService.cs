using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendPeluqueria.Models;
using Supabase;

namespace BackendPeluqueria.Services
{
    public class PeluqueroService
    {
        public async Task<List<Peluquero>> GetAll()
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Peluquero>().Get();
            
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron peluqueros en la base de datos.");
            }
            
            return response.Models;
        }

        public async Task<Peluquero> GetById(int id)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Peluquero>().Where(x => x.PeluqueroId == id).Get();
            
            if (response.Model == null)
            {
                throw new KeyNotFoundException($"No se encontró el peluquero con ID {id}.");
            }
            
            return response.Model;
        }

        public async Task<Peluquero> Create(Peluquero peluquero)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Peluquero>().Insert(peluquero);
            return response.Model;
        }

        public async Task<Peluquero> Update(Peluquero peluquero)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Peluquero>().Update(peluquero);
            return response.Model;
        }

        public async Task Delete(int id)
        {
            var client = await Conexion.GetClient();
            await client.From<Peluquero>().Where(x => x.PeluqueroId == id).Delete();
        }
    }
}
