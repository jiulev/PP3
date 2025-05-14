using System;

namespace CapaEntidad
{
    public class Categoria

    {
        public string ACTIVO { get; set; } = "A";  // A = Activo, I = Inactivo

        public int IDCATEGORIA { get; set; }  // ID autogenerado por la base de datos
        public string DESCRIPCION { get; set; } = string.Empty; // Descripción de la categoría
        public DateTime FECHACREACION { get; set; }  // Fecha de creación
    }






}

