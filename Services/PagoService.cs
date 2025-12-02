using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendPeluqueria.Models;
using Supabase;

namespace BackendPeluqueria.Services
{
    public class PagoService
    {
        public async Task<List<Pago>> GetAll()
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Pago>().Get();
            
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron pagos en la base de datos.");
            }
            
            return response.Models;
        }

        public async Task<Pago> GetById(int id)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Pago>().Where(x => x.PagoId == id).Get();
            
            if (response.Model == null)
            {
                throw new KeyNotFoundException($"No se encontró el pago con ID {id}.");
            }
            
            return response.Model;
        }

        public async Task<Pago> Create(Pago pago)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Pago>().Insert(pago);
            return response.Model;
        }

        public async Task<Pago> Update(Pago pago)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Pago>().Update(pago);
            return response.Model;
        }

        public async Task Delete(int id)
        {
            var client = await Conexion.GetClient();
            await client.From<Pago>().Where(x => x.PagoId == id).Delete();
        }
    }
}
