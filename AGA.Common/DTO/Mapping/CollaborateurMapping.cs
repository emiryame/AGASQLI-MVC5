using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;

namespace AGA.Common.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets collaborateur "Data" et "DTO"
    /// </summary>
    public static class CollaborateurMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet collaborateur data en un objet collaborateur DTO
        /// </summary>
        /// <param name="collaborateur">collaborateur data</param>
        /// <returns>L'objet collaborateur DTO</returns>
        public static Collaborateur EntityToDto(DAL.Collaborateur collaborateur)
        {
            Collaborateur collaborateurDto = new Collaborateur();

            if (collaborateur != null)
            {
                collaborateurDto.Banque = collaborateur.Banque;
                collaborateurDto.Cin = collaborateur.Cin;
                collaborateurDto.Cnss = collaborateur.Cnss;
                collaborateurDto.DateDebutTravail = collaborateur.DateDebutTravail;
                collaborateurDto.Id = collaborateur.Id;
                collaborateurDto.IsEligible = collaborateur.IsEligible;
                collaborateurDto.Nom = collaborateur.Nom;
                collaborateurDto.Poste = collaborateur.Poste;
                collaborateurDto.Prenom = collaborateur.Prenom;
                collaborateurDto.Adresse = collaborateur.Adresse;
                collaborateurDto.Civilite = CiviliteMapping.EntityToDto(collaborateur.Civilite);
            }

            return collaborateurDto;
        }

        /// <summary>
        /// Permet la convertion d'une liste de collaborateurs data en une liste de collaborateurs DTO
        /// </summary>
        /// <param name="collaborateursList">La liste des collaborateur Data</param>
        /// <returns>La liste de collaborateurs DTO</returns>
        public static List<Collaborateur> EntityToDto(List<DAL.Collaborateur> collaborateursList)
        {
            List<Collaborateur> listCollaborateurDto = new List<Collaborateur>();
            collaborateursList.ForEach(c => listCollaborateurDto.Add(EntityToDto(c)));
            return listCollaborateurDto;
        }

        /// <summary>
        /// Permet la convertion d'un objet collaborateur DTO en un objet collaborateur Data
        /// </summary>
        /// <param name="collaborateur">collaborateur DTO</param>
        /// <returns>L'objet collaborateur Data</returns>
        public static DAL.Collaborateur DtoToEntity(Collaborateur collaborateur)
        {
            DAL.Collaborateur collaborateurData = new DAL.Collaborateur();
            if (collaborateur != null)
            {
                collaborateurData.Banque = collaborateur.Banque;
                collaborateurData.Cin = collaborateur.Cin;
                collaborateurData.Cnss = collaborateur.Cnss;
                collaborateurData.DateDebutTravail = collaborateur.DateDebutTravail;
                collaborateurData.Id = collaborateur.Id;
                collaborateurData.IsEligible = collaborateur.IsEligible;
                collaborateurData.Nom = collaborateur.Nom;
                collaborateurData.Poste = collaborateur.Poste;
                collaborateurData.Prenom = collaborateur.Prenom;
                collaborateurData.Adresse = collaborateur.Adresse;
                collaborateurData.Civilite = CiviliteMapping.DtoToEntity(collaborateur.Civilite);
            }
            return collaborateurData;
        }
    }
}
