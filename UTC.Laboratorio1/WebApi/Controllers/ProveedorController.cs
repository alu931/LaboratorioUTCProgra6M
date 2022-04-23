using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBL;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService proveedor;

        public ProveedorController(IProveedorService proveedor)
        {
            this.proveedor = proveedor;
        }


        [HttpGet("Lista")]
        public async Task<IEnumerable<ProveedorEntity>> GetLista()
        {
            try
            {
                return await proveedor.GetLista();
            }
            catch (Exception ex)
            {

                return new List<ProveedorEntity>();
            }



        }

    }
}
