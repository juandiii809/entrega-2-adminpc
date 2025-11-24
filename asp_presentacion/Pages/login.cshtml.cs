using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace asp_presentacion.Pages
{
    
    public class loginModel : PageModel
    {
        
        // Inyección directa de las dependencias necesarias
        private readonly TokenAplicacion _tokenAplicacion;
        private readonly IConexion _iConexion;

        // Constructor para inyección de dependencias
        public loginModel(TokenAplicacion tokenAplicacion, IConexion iConexion)
        {
            _tokenAplicacion = tokenAplicacion;
            _iConexion = iConexion;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Required(ErrorMessage = "El usuario es obligatorio.")]
            [Display(Name = "Usuario")]
            public string Usuario { get; set; } = string.Empty;

            [Required(ErrorMessage = "La clave es obligatoria.")]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Contraseña { get; set; } = string.Empty;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // PASO 1: Usar TokenAplicacion para verificar las credenciales (tu lógica existente).
            var usuarioIntento = new Usuario { Nombre = Input.Usuario, Contraseña = Input.Contraseña };
            string llaveObtenida = _tokenAplicacion.Llave(usuarioIntento);

            if (!string.IsNullOrEmpty(llaveObtenida))
            {
                // PASO 2: Si la llave se obtiene, significa que las credenciales son correctas.
                // Obtenemos el objeto Usuario completo para crear los Claims.
                Usuario? usuarioVerificado = _iConexion.Usuario!
                    .FirstOrDefault(x => x.Nombre == Input.Usuario && x.Contraseña == Input.Contraseña);

                if (usuarioVerificado != null)
                {
                    // 3. Crear Claims y emitir la Cookie
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuarioVerificado.Id.ToString()),
                        new Claim(ClaimTypes.Name, usuarioVerificado.Nombre!),
                        // new Claim(ClaimTypes.Role, "Admin"), // Si tu Usuario tiene Rol
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                    await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

                    return LocalRedirect("/");
                }
            }

            // Si la verificación falla o el usuario no se encuentra (aunque es redundante si Llave() funciona)
            ModelState.AddModelError(string.Empty, "Usuario o contraseña inválidos.");
            return Page();
        }
    }
}

