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
    [ApiController]
    [Route("[controller]")]
    public class TipoPermisosController : ControllerBase
    { 
        private readonly IRepository<TipoPermiso> _tipoPermisoRepository;

        public TipoPermisosController(IRepository<TipoPermiso> tipoPermisoRepository)
        {
            _tipoPermisoRepository = tipoPermisoRepository;
        }

        [HttpGet]
        public IEnumerable<TipoPermiso> GetAll()
        {
            return _tipoPermisoRepository.GetAll().ToList();
        }

        public TipoPermiso Get(int id)
        {
            return _tipoPermisoRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public async Task<TipoPermiso> Create(string descripcion)
        {
            var tipo = new TipoPermiso() { Descripcion = descripcion };
            return await _tipoPermisoRepository.AddAsync(tipo);
        }
        public async Task<TipoPermiso> Update(TipoPermiso tipo_permiso)
        {
            return await _tipoPermisoRepository.UpdateAsync(tipo_permiso);
        }
        public async Task<bool> Delete(int id)
        {
            var tipo = Get(id);
            return await _tipoPermisoRepository.DeleteAsync(tipo);
        }
    }
}
