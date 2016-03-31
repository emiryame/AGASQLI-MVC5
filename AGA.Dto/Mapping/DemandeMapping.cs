using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.DTO.Models;

namespace AGA.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets demande "Data" et "DTO"
    /// </summary>
    public static class DemandeMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet demande data en un objet demande DTO
        /// </summary>
        /// <param name="demande">demande Data</param>
        /// <returns>demande DTO</returns>
        public static Demande EntityToDto(Data.Demande demande)
        {
            Demande demandeDto = new Demande();

            if (demande!=null)
            {
                demandeDto.Assistante = CollaborateurMapping.EntityToDto(demande.Assistante);
                demandeDto.Collaborateur = CollaborateurMapping.EntityToDto(demande.Collaborateur);
                demandeDto.DateCreation = demande.DateCreation;
                demandeDto.DateDebutTraitement = demande.DateDebutTraitement;
                demandeDto.DateFinTraitement = demande.DateFinTraitement;
                demandeDto.Id = demande.Id;
                demandeDto.Statut = StatutMapping.EntityToDto(demande.Statut);
                demandeDto.TypeAttestation = TypeAttestationMapping.EntityToDto(demande.TypeAttestation);
            }

            return demandeDto;
        }

        /// <summary>
        /// Permet la convertion d'une liste de demandes data en une liste de demandes DTO
        /// </summary>
        /// <param name="demandesList">La liste de demandes Data</param>
        /// <returns>La liste de demandes DTO</returns>
        public static List<Demande> EntityToDto(List<Data.Demande> demandesList)
        {
            List<Demande> demandesListDto = new List<Demande>();
            demandesList.ForEach(d => demandesListDto.Add(DemandeMapping.EntityToDto(d)));

            return demandesListDto;
        }

        /// <summary>
        /// Permet la convertion d'un objet demande DTO en un objet demande Data
        /// </summary>
        /// <param name="demande">demande DTO</param>
        /// <returns>Demande Data</returns>
        public static Data.Demande DtoToEntity(Demande demande)
        {
            Data.Demande demandeData = new Data.Demande();
            
            if(demande != null)
            {
                demandeData.Assistante = CollaborateurMapping.DtoToEntity(demande.Assistante);
                demandeData.Collaborateur = CollaborateurMapping.DtoToEntity(demande.Collaborateur);
                demandeData.DateCreation = demande.DateCreation;
                demandeData.DateDebutTraitement = demande.DateDebutTraitement;
                demandeData.DateFinTraitement = demande.DateFinTraitement;
                demandeData.Id = demandeData.Id;
                demandeData.Statut = StatutMapping.DtoToEntity(demande.Statut);
                demandeData.TypeAttestation = TypeAttestationMapping.DtoToEntity(demande.TypeAttestation);
            }
            return demandeData;
        }

        /// <summary>
        /// Permet la convertion d'une liste de demandes DTO en une liste de demandes Data
        /// </summary>
        /// <param name="demandesList">La liste des demandes DTO</param>
        /// <returns>La liste des demandes Data</returns>
        public static List<Data.Demande> DtoToEntity(List<Demande> demandesList)
        {
            List<Data.Demande> demandesListData = new List<Data.Demande>();
            demandesList.ForEach(d => demandesListData.Add(DemandeMapping.DtoToEntity(d)));

            return demandesListData;
        }
    }
}
