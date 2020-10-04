using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaX.Permisos.Core.Permisos;
using EmpresaX.Permisos.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaX.Permisos.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisosController : ControllerBase
    {

        private readonly IRepository<TipoPermiso> _tipoPermisoRepository;

        public TipoPermisosController(IRepository<TipoPermiso> tipoPermisoRepository)
        {
            _tipoPermisoRepository = tipoPermisoRepository;
        }

        // GET: api/TipoPermisos
        [HttpGet]
        public IEnumerable<TipoPermiso> GetAll()
        {
            return _tipoPermisoRepository.GetAll().ToList();
        }

        // GET: api/TipoPermisos/5
        [HttpGet("{id}", Name = "GetTipoPermiso")]
        public TipoPermiso Get(int id)
        {
            return _tipoPermisoRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        // POST: api/TipoPermisos
        [HttpPost]
        public async void Post([FromBody] TipoPermiso tipo)
        {
            await _tipoPermisoRepository.AddAsync(tipo);
        }

        // PUT: api/TipoPermisos/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] TipoPermiso tipo)
        {
            await _tipoPermisoRepository.UpdateAsync(tipo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var tipo = _tipoPermisoRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (tipo != null)
                await _tipoPermisoRepository.DeleteAsync(tipo);
        }
    }
}
