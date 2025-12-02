using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendPeluqueria.Models;
using Supabase;

namespace BackendPeluqueria.Services
{
    public class ReservaService
    {
        public async Task<List<Reserva>> GetAll()
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Reserva>().Get();
            
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron reservas en la base de datos.");
            }
            
            return response.Models;
        }

        public async Task<Reserva> GetById(int id)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Reserva>().Where(x => x.ReservaId == id).Get();
            
            if (response.Model == null)
            {
                throw new KeyNotFoundException($"No se encontró la reserva con ID {id}.");
            }
            
            return response.Model;
        }

        public async Task<Reserva> Create(Reserva reserva)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Reserva>().Insert(reserva);
            return response.Model;
        }

        public async Task<Reserva> Update(Reserva reserva)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Reserva>().Update(reserva);
            return response.Model;
        }

        public async Task Delete(int id)
        {
            var client = await Conexion.GetClient();
            await client.From<Reserva>().Where(x => x.ReservaId == id).Delete();
        }
    }
}
