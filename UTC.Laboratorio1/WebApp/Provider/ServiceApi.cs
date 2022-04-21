using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp
{
    public class ServiceApi
    {
        private readonly HttpClient client;

        public ServiceApi(HttpClient client)
        {
            this.client = client;
        }


        public async Task<IEnumerable<ContactoEntity>> ContactoGet()
        {

            var result = await client.ServicioGetAsync<IEnumerable<ContactoEntity>>("api/Contacto");
            return result;

        }


        public async Task<ContactoEntity> ContactoGetById(int id)
        {
            var result = await client.ServicioGetAsync<ContactoEntity>("api/Contacto/" + id);

            if (result.CodeError is not 0) throw new Exception(result.MsgError);

            return result;

        }      

        



        public async Task<IEnumerable<ProveedorEntity>> ProveedorGetLista()
        {

            var result = await client.ServicioGetAsync<IEnumerable<ProveedorEntity>>("api/Proveedor/Lista");
            return result;

        }
    }
}
