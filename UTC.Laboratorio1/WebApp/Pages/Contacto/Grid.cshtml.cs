using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Contacto
{
    public class GridModel : PageModel
    {

        private readonly ServiceApi service;

        public GridModel(ServiceApi service)
        {
            this.service = service;
        }



        //private readonly IContactoService contactoService;

        //public GridModel(IContactoService contactoService)
        //{
        //    this.contactoService = contactoService;
        //}

        public IEnumerable<ContactoEntity> GridList { get; set; } = new List<ContactoEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await service.ContactoGet();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        //public async Task<JsonResult> OnDeleteEliminar(int id)
        //{
        //    try
        //    {
        //        var result = await contactoService.Delete(new()
        //        {
        //            IdContacto = id
        //        }
        //        );

        //        return new JsonResult(result);
        //    }

        //    catch (Exception ex)
        //    {

        //        return new JsonResult(new DBEntity 

        //        { CodeError=ex.HResult, MsgError=ex.Message});
        //    }
        //}



    }
}
