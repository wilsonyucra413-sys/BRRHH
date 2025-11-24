using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class AsistenciaMapeador
    {
        public static AsistenciaDTO toAsistenciaDTO(this Asistencia asistencia)
        {
            return new AsistenciaDTO()
            {
                Fecha = asistencia.Fecha,
                HoraEntrada = asistencia.HoraEntrada,
                HoraSalida = asistencia.HoraSalida
            }; 
        }
    }
}