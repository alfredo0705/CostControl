using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
    public class FallbackController : Controller
    {
        public ActionResult Index()
        {
            var path = Request.Path.Value;

            // Evitar que Swagger sea interceptado
            if (path.StartsWith("/swagger"))
            {
                return NotFound();  // Deja que el middleware de Swagger maneje la petición
            }

            // Evitar que las solicitudes a archivos estáticos sean procesadas como fallback
            if (path.Contains("."))
            {
                return NotFound(); 
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/browser", "index.html");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            return PhysicalFile(filePath, "text/html");
        }
    }
}
