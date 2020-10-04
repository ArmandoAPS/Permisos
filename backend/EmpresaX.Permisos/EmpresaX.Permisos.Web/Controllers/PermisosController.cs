using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaX.Permisos.Core.Permisos;
using EmpresaX.Permisos.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmpresaX.Permisos.Web.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {

        private readonly IRepository<Permiso> _permisoRepository;

        public PermisosController(IRepository<Permiso> permisoRepository)
        {
            _permisoRepository = permisoRepository;
        }

        // GET: api/Permisos
        [HttpGet]
        public IEnumerable<Permiso> GetAll()
        {
            return _permisoRepository.GetAll().ToList();
        }

        // GET: api/Permisos/5
        [HttpGet("{id}", Name = "GetPermiso")]
        public Permiso Get(int id)
        {
            return _permisoRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        // POST: api/Permisos
        [HttpPost]
        public async void Post([FromBody] Permiso permiso)
        {
            await _permisoRepository.AddAsync(permiso);
        }

        // PUT: api/Permisos/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Permiso permiso)
        {
            await _permisoRepository.UpdateAsync(permiso);
        }

        // DELETE: api/Permisos/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var permiso = _permisoRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (permiso != null)
                await _permisoRepository.DeleteAsync(permiso);
        }

    }
}
