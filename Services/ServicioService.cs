using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendPeluqueria.Models;
using Supabase;

namespace BackendPeluqueria.Services
{
    public class ServicioService
    {
        public async Task<List<Servicio>> GetAll()
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Servicio>().Get();
            
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron servicios en la base de datos.");
            }
            
            return response.Models;
        }

        public async Task<Servicio> GetById(int id)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Servicio>().Where(x => x.ServicioId == id).Get();
            
            if (response.Model == null)
            {
                throw new KeyNotFoundException($"No se encontró el servicio con ID {id}.");
            }
            
            return response.Model;
        }

        public async Task<Servicio> Create(Servicio servicio)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Servicio>().Insert(servicio);
            return response.Model;
        }

        public async Task<Servicio> Update(Servicio servicio)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Servicio>().Update(servicio);
            return response.Model;
        }

        public async Task Delete(int id)
        {
            var client = await Conexion.GetClient();
            await client.From<Servicio>().Where(x => x.ServicioId == id).Delete();
        }
    }
}
