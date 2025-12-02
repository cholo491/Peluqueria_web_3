using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendPeluqueria.Models;
using Supabase;

namespace BackendPeluqueria.Services
{
    public class NotificacionService
    {
        public async Task<List<Notificacion>> GetAll()
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Notificacion>().Get();
            
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron notificaciones en la base de datos.");
            }
            
            return response.Models;
        }

        public async Task<Notificacion> GetById(int id)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Notificacion>().Where(x => x.NotificacionId == id).Get();
            
            if (response.Model == null)
            {
                throw new KeyNotFoundException($"No se encontró la notificación con ID {id}.");
            }
            
            return response.Model;
        }

        public async Task<Notificacion> Create(Notificacion notificacion)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Notificacion>().Insert(notificacion);
            return response.Model;
        }

        public async Task<Notificacion> Update(Notificacion notificacion)
        {
            var client = await Conexion.GetClient();
            var response = await client.From<Notificacion>().Update(notificacion);
            return response.Model;
        }

        public async Task Delete(int id)
        {
            var client = await Conexion.GetClient();
            await client.From<Notificacion>().Where(x => x.NotificacionId == id).Delete();
        }
    }
}
