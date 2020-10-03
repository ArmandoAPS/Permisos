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
    public class PermisosController : ControllerBase
    {

        private readonly IRepository<Permiso> _permisoRepository;
        private readonly IRepository<TipoPermiso> _tipoPermisoRepository;

        public PermisosController(IRepository<Permiso> permisoRepository,
            IRepository<TipoPermiso> tipoPermisoRepository)
        {
            _permisoRepository = permisoRepository;
            _tipoPermisoRepository = tipoPermisoRepository;
        }

        [HttpGet]
        public IEnumerable<Permiso> GetAll()
        {
            return _permisoRepository.GetAll().ToList();
        }

        public Permiso Get(int id)
        {
            return _permisoRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Permiso> Create(Permiso permiso)
        {
            return await _permisoRepository.AddAsync(permiso);
        }
        public async Task<Permiso> Update(Permiso permiso)
        {
            return await _permisoRepository.UpdateAsync(permiso);
        }
        public async Task<bool> Delete(int id)
        {
            var permiso = Get(id);
            return await _permisoRepository.DeleteAsync(permiso);
        }
    }
}
