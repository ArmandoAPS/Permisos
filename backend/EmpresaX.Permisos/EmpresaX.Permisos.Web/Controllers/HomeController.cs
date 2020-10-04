using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaX.Permisos.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public string Index()
        {
            return "<html><body><h1>Empresa x: Solicitudes de Permisos</h1></body></html>";
        }
    }
}