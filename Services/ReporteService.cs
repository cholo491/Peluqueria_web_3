using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendPeluqueria.Models;
using Supabase;

namespace BackendPeluqueria.Services
{
    public class ReporteService
    {
        public async Task<List<Reporte>> GetAll()
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Reporte>().Get();
            
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron reportes en la base de datos.");
            }
            
            return response.Models;
        }

        public async Task<Reporte> GetById(int id)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Reporte>().Where(x => x.ReporteId == id).Get();
            
            if (response.Model == null)
            {
                throw new KeyNotFoundException($"No se encontró el reporte con ID {id}.");
            }
            
            return response.Model;
        }

        public async Task<Reporte> Create(Reporte reporte)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Reporte>().Insert(reporte);
            return response.Model;
        }

        public async Task<Reporte> Update(Reporte reporte)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Reporte>().Update(reporte);
            return response.Model;
        }

        public async Task Delete(int id)
        {
            var client = await Conexion.GetClient();
            await client.From<Reporte>().Where(x => x.ReporteId == id).Delete();
        }
    }
}
