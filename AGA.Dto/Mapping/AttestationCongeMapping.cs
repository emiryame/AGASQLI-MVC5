using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.DTO.Models;

namespace AGA.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets attestationConge "Data" et "DTO"
    /// </summary>
    public static class AttestationCongeMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet attestationConge data en un objet attestationConge DTO
        /// </summary>
        /// <param name="attestationConge">attestationConge "Data"</param>
        /// <returns>L'objet attestationCong DTO</returns>
        public static AttestationConge EntityToDto(Data.AttestationConge attestationConge)
        {
            AttestationConge attestationCongeDto = new AttestationConge();

            if (attestationConge!=null)
            {
                attestationCongeDto.DateDebut = attestationConge.DateDebut;
                attestationCongeDto.DateFin = attestationConge.DateFin;
                attestationCongeDto.Id = attestationConge.Id;
                attestationCongeDto.Demande = DemandeMapping.EntityToDto(attestationConge.Demande);
            }
            return attestationCongeDto;
        }
   
    }
}
