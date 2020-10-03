using EmpresaX.Permisos.Core.Permisos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaX.Permisos.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public interface IPermisoRepository
    {
    }
    public class PermisoRepository: Repository<Permiso>, IPermisoRepository
    {
        public PermisoRepository(PermisosDbContext context) : base(context)
        {
        }
    }
}
