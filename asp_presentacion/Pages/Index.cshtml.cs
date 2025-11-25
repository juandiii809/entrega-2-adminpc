using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Usuario { get; set; }
        [BindProperty] public string? Contrasena { get; set; }
        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }
        public void OnPostBtClean()
        {
            try
            {
                Usuario = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Usuario) &&
                string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }
                if ("admin.123" != Usuario + "." + Contrasena)
                {
                    OnPostBtClean();
                    return;
                }
                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Usuario!);
                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}