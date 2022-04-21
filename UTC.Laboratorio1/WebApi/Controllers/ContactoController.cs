using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBL;
using Entity;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoService contactoService;

        public ContactoController(IContactoService contactoService)
        {
            this.contactoService = contactoService;
        }


        [HttpGet]
        public async Task<IEnumerable<ContactoEntity>> Get()
        {
            try
            {
                return await contactoService.Get();
            }
            catch (Exception ex)
            {

                return new List<ContactoEntity>();
            }



        }

        [HttpGet("{id}")]
        public async Task<DBEntity> Get(int id)
        {
            try
            {
                return await contactoService.GetById( new ContactoEntity { IdContacto=id});
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }



        }


        [HttpPost]
        public async Task<DBEntity> Create(ContactoEntity entity)
        {
            try
            {
                return await contactoService.Create( entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }



        }

        [HttpPut]
        public async Task<DBEntity> Update(ContactoEntity entity)
        {
            try
            {
                return await contactoService.Update(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }



        }


        [HttpDelete("{id}")]
        public async Task<DBEntity> Delete(int id)
        {
            try
            {
                return await contactoService.Delete(new ContactoEntity { IdContacto = id });
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }



        }


    }
}
