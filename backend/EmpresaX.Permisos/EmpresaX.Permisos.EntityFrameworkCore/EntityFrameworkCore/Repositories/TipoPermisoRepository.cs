using EmpresaX.Permisos.Core.Permisos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaX.Permisos.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public interface ITipoPermisoRepository
    {
    }
    public class TipoPermisoRepository : Repository<TipoPermiso>, ITipoPermisoRepository
    {
        public TipoPermisoRepository(PermisosDbContext context) : base(context)
        {
        }
    }
}
