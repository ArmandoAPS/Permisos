using EmpresaX.Permisos.Core.Permisos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaX.Permisos.EntityFrameworkCore
{
    public class PermisosDbContext: DbContext
    {
        public DbSet<TipoPermiso> TipoPermisos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }

        public PermisosDbContext()
        {
            this.Database.Migrate();
        }

        public PermisosDbContext(DbContextOptions<PermisosDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=Permisos.db");
        }
    }
}
