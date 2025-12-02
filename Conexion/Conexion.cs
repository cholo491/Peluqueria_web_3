using Supabase;
using System;
using System.Threading.Tasks;
using BackendPeluqueria.Modelos;
namespace BackendPeluqueria
{
    public static class Conexion
    {
        private static Supabase.Client client;

        public static async Task<Supabase.Client> GetClient()
        {
            if (client == null)
            {
                var options = new Supabase.SupabaseOptions
                {
                    AutoConnectRealtime = true,
                };

                client = new Supabase.Client(SUPABASE_URL, SUPABASE_ANON_KEY, options);
                await client.InitializeAsync();
            }
            return client;
        }
    }
}