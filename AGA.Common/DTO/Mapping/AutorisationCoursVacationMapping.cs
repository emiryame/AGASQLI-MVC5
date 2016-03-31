using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;
using AGA;

namespace AGA.Common.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets autorisationCoursVacation "Data" et "DTO"
    /// </summary>
    public static class AutorisationCoursVacationMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet autorisationCoursVacation data en un objet autorisationCousVacation DTO
        /// </summary>
        /// <param name="autorisationCoursVacation">autorisationCoursVacation Data</param>
        /// <returns>autorisationCoursVacation DTO</returns>
        public static AutorisationCoursVacation EntityToDto(DAL.AutorisationCoursVacation autorisationCoursVacation)
        {
            AutorisationCoursVacation autorisationCoursVacationDto = new AutorisationCoursVacation();

            if (autorisationCoursVacation != null)
            {
                autorisationCoursVacationDto.AnneeScolaire = autorisationCoursVacation.AnneeScolaire;
                autorisationCoursVacationDto.Etablissement = autorisationCoursVacation.Etablissement;
                autorisationCoursVacationDto.Id = autorisationCoursVacation.Id;
                autorisationCoursVacationDto.Demande = DemandeMapping.EntityToDto(autorisationCoursVacation.Demande);
            }

            return autorisationCoursVacationDto;
        }
    }
}
