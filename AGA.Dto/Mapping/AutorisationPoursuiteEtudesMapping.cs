using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.DTO.Models;

namespace AGA.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets autorisationPoursuiteEtudes "Data" et "DTO"
    /// </summary>
    public static class AutorisationPoursuiteEtudesMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet autorisationPoursuiteEtudes data en un objet autorisationPoursuiteEtudes DTO
        /// </summary>
        /// <param name="autorisationPoursuiteEtudes">autorisationPoursuiteEtudes Data</param>
        /// <returns>autorisationPoursuiteEtudes DTO</returns>
        public static AutorisationPoursuiteEtudes EntityToDto(Data.AutorisationPoursuiteEtudes autorisationPoursuiteEtudes)
        {
            AutorisationPoursuiteEtudes autorisationPoursuiteEtudesDto = new AutorisationPoursuiteEtudes();

            if (autorisationPoursuiteEtudes != null) { 
            autorisationPoursuiteEtudesDto.AnneeScolaire = autorisationPoursuiteEtudes.AnneeScolaire;
            autorisationPoursuiteEtudesDto.Etablissement = autorisationPoursuiteEtudes.Etablissement;
            autorisationPoursuiteEtudesDto.Id = autorisationPoursuiteEtudes.Id;
            autorisationPoursuiteEtudesDto.Demande = DemandeMapping.EntityToDto(autorisationPoursuiteEtudes.Demande);
            }
            return autorisationPoursuiteEtudesDto;
        }
    }
}
