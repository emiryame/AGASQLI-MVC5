using AGA.Common.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGA.Common.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets stagiaire "Data" et "DTO"
    /// </summary>
    public static class StagiaireMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet stagiaire data en un objet stagiaire DTO
        /// </summary>
        /// <param name="stagiaire">stagiaire Data</param>
        /// <returns>stagiaire DTO</returns>
        public static Stagiaire EntityToDto(DAL.Stagiaire stagiaire)
        {
            Stagiaire stagiaireDto = new Stagiaire();

            if (stagiaire!=null)
            {
                stagiaireDto.Adresse = stagiaire.Adresse;
                stagiaireDto.Cin = stagiaire.Cin;
                stagiaireDto.Civilite = CiviliteMapping.EntityToDto(stagiaire.Civilite);
                stagiaireDto.DateDebut = stagiaire.DateDebut;
                stagiaireDto.DateFin = stagiaire.DateFin;
                stagiaireDto.Id = stagiaire.Id;
                stagiaireDto.Nom = stagiaire.Nom;
                stagiaireDto.Prenom = stagiaire.Prenom;
            }

            return stagiaireDto;
        }

        /// <summary>
        /// Permet la conversion d'une liste de stagiaires "Data" en une liste de stagiaires "DTO"
        /// </summary>
        /// <param name="stagiairesList">La liste des stagiaires Data</param>
        /// <returns>La liste des stagiaires DTO</returns>
        public static List<Stagiaire> EntityToDto(List<DAL.Stagiaire> stagiairesList)
        {
            List<Stagiaire> stagiairesListDto = new List<Stagiaire>();
            stagiairesList.ForEach(s => stagiairesListDto.Add(EntityToDto(s)));

            return stagiairesListDto;
        }

    }
}
