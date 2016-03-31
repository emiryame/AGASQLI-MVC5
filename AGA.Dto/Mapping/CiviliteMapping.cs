using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.DTO.Models;

namespace AGA.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets civilite "Data" et "DTO"
    /// </summary>
    public static class CiviliteMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet civilite data en un objet civilite DTO
        /// </summary>
        /// <param name="civilite">civilite Data</param>
        /// <returns>civilite DTO</returns>
        public static Civilite EntityToDto(Data.Civilite civilite)
        {
            Civilite civiliteDto = new Civilite();

            if (civilite!=null)
            {
                civiliteDto.Id = civilite.Id;
                civiliteDto.Label = civilite.Label;
                civiliteDto.Code = civilite.Code;
            }

            return civiliteDto;
        }

        /// <summary>
        /// Permet la convertion d'un objet civilite DTO en un objet civilite Data
        /// </summary>
        /// <param name="civilite">civilite DTO</param>
        /// <returns>civilite Data</returns>
        public static Data.Civilite DtoToEntity(Civilite civilite)
        {
            Data.Civilite civiliteData = new Data.Civilite();

            if (civilite != null)
            {
                civiliteData.Id = civilite.Id;
                civiliteData.Label = civilite.Label;
                civiliteData.Code = civilite.Code;
            }

            return civiliteData;
        }
    }
}
