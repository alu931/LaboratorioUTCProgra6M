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
        private readonly IUsuarioService usuarioService;

        public RegistrarseModel(IUsuarioService usuarioService)
        {

            this.usuarioService = usuarioService;
        }

        [FromBody]
        [BindProperty]
        public UsuarioEntity Entity { get; set; } = new UsuarioEntity();

        public async Task<IActionResult> OnPost()
        {

            try
            {
                var result = await usuarioService.Registrar(Entity);

               
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
