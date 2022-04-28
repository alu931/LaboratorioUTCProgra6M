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
    public class LoginModel : PageModel
    {
        
        private readonly IUsuarioService usuarioService;

        public LoginModel(IUsuarioService  usuarioService)
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
                var result = await usuarioService.Login(Entity);

                if (result.CodeError==0)
                {

                    HttpContext.Session.Set<UsuarioEntity>(IApp.UsuarioSession, result);
                    return new JsonResult(result);
                }
                else
                {
                    return new JsonResult(result);

                }


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });

                throw;
            }
        
        
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();

            return Redirect("../Login");
        }
        public void OnGet()
        {
        }
    }
}
