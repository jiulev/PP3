using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CapaNegocio
{
    public static class MercadoPagoService
    {
        private const string AccessToken = "APP_USR-1099076097713998-060519-0d8f653ce0c132f1848ba753bb9b7aa9-2481996688"; // ✅ tu token sandbox

        public static async Task<string> GenerarLinkPago(string titulo, decimal monto)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

                var body = new
                {
                    items = new[]
                    {
                        new
                        {
                            title = titulo,
                            quantity = 1,
                            unit_price = monto
                        }
                    },
                    back_urls = new
                    {
                        success = "https://www.google.com", // 🔁 redirección de prueba
                        failure = "https://www.google.com"
                    },
                    auto_return = "approved"
                };

                var json = JsonConvert.SerializeObject(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://api.mercadopago.com/checkout/preferences", content);
                var result = await response.Content.ReadAsStringAsync();

                dynamic respuesta = JsonConvert.DeserializeObject(result);
                return respuesta.init_point; // 🔁 link generado
            }
        }
    }
}
