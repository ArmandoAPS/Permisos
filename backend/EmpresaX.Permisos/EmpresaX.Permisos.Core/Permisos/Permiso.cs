using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpresaX.Permisos.Core.Permisos
{
    public class Permiso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreEmpleado { get; set; }

        [Required]
        [StringLength(100)]
        public string ApellidosEmpleado { get; set; }

        [Required]
        public int TipoPermisoId { get; set; }

        public virtual TipoPermiso TipoPermiso { get; set; }

        [Required]
        public DateTime FechaPermiso { get; set; }

    }
}
