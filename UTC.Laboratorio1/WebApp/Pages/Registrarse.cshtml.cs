using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using WBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class RegistrarseModel : PageModel
    {
        private readonly IUsuariosService usuariosService;

        public RegistrarseModel(IUsuariosService usuariosService)
        {

            this.usuariosService = usuariosService;
        }

        [FromBody]
        [BindProperty]
        public UsuariosEntity Entity { get; set; } = new UsuariosEntity();

        public async Task<IActionResult> OnPost()
        {

            try
            {
                var result = await usuariosService.Registrar(Entity);

               
                   return new JsonResult(result);
              


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });

                throw;
            }


        }
    }
}
