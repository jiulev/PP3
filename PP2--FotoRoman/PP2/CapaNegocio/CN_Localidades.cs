using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Localidades
    {
        // Método para listar provincias
        public static List<Provincia> ListarProvincias()
        {
            return CD_Localidades.ListarProvincias();
        }

        // Método para listar localidades por provincia
        public static List<Localidad> ListarLocalidadesPorProvincia(int idProvincia)
        {
            return CD_Localidades.ListarLocalidadesPorProvincia(idProvincia);
        }

        // Método para insertar una nueva provincia
        public static int InsertarProvincia(string nombreProvincia, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(nombreProvincia))
            {
                mensaje = "El nombre de la provincia no puede estar vacío.";
                return 0;
            }

            try
            {
                return CD_Localidades.InsertarProvincia(nombreProvincia);
            }
            catch (Exception ex)
            {
                mensaje = "Error al insertar la provincia: " + ex.Message;
                return 0;
            }
        }

        // Método para insertar una nueva localidad
        public static int InsertarLocalidad(string nombreLocalidad, int idProvincia, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(nombreLocalidad))
            {
                mensaje = "El nombre de la localidad no puede estar vacío.";
                return 0;
            }

            if (idProvincia <= 0)
            {
                mensaje = "Debe seleccionar una provincia válida.";
                return 0;
            }

            try
            {
                return CD_Localidades.InsertarLocalidad(nombreLocalidad, idProvincia);
            }
            catch (Exception ex)
            {
                mensaje = "Error al insertar la localidad: " + ex.Message;
                return 0;
            }
        }
    }
}
