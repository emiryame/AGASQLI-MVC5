using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;

namespace AGA.Common.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets typeAttestation "Data" et "DTO"
    /// </summary>
    public static class TypeAttestationMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet typeAttestation data en un objet typeAttestation DTO
        /// </summary>
        /// <param name="statut">typeAttestation Data</param>
        /// <returns>typeAttestation DTO</returns>
        public static TypeAttestation EntityToDto(DAL.TypeAttestation typeAttestation)
        {
            TypeAttestation typeAttestationDto = new TypeAttestation();

            if (typeAttestation!=null)
            {
                typeAttestationDto.Id = typeAttestation.Id;
                typeAttestationDto.Label = typeAttestation.Label;
                typeAttestationDto.Template = typeAttestation.Template;
                typeAttestationDto.Code = typeAttestation.Code;
            }

            return typeAttestationDto;
        }

        /// <summary>
        /// Permet la convertion d'un objet typeAttestation DTO en un objet typeAttestation Data
        /// </summary>
        /// <param name="statut">typeAttestation DTO</param>
        /// <returns>typeAttestation Data</returns>
        public static DAL.TypeAttestation DtoToEntity(TypeAttestation typeAttestation)
        {
            DAL.TypeAttestation typeAttestationData = new DAL.TypeAttestation();

            if (typeAttestation != null)
            {
                typeAttestationData.Id = typeAttestation.Id;
                typeAttestationData.Label = typeAttestation.Label;
                typeAttestationData.Template = typeAttestation.Template;
                typeAttestationData.Code = typeAttestation.Code;
            }

            return typeAttestationData;
        }
    }
}
