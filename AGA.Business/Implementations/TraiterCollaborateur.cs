using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;
using AGA.Services.Interfaces;
using AGA.Common.DTO.Mapping;
using System.IO;
using Excel;
using System.Data;

namespace AGA.Business.Implementations
{
    /// <summary>
    /// Classe permettant de traiter les collaborateurs, assistantes, stagiaires
    /// </summary>
    public class TraiterCollaborateur : ITraiterCollaborateur
    {
        /// <summary>
        /// Génére le mail d'un collaborateur à partir de son nom et pénom
        /// </summary>
        /// <param name="collaborateur">Le collaborateur</param>
        /// <returns>Le mail du collaborateur</returns>
        //TODO: Email déjà existant ds la BD d'après le script sql communiqué
        public String GetEmail (Collaborateur collaborateur)
        {
            String lettrePrenom=collaborateur.Prenom.ToCharArray().ElementAt(0).ToString();
            String email = String.Concat(lettrePrenom,collaborateur.Nom, "@sqli.com");

            return email;
        }

        /// <summary>
        /// Génére la liste de mail d'un ensemble de collaborateur
        /// </summary>
        /// <param name="collaborateurList">La liste de collaborateur</param>
        /// <returns>La liste de mail</returns>
        public List<String> GetEmailList(List<Collaborateur> collaborateurList)
        {
            List<String> mailList = new List<String>();
            collaborateurList.ForEach(i => mailList.Add(GetEmail(i)));
            return mailList;
        }

        /// <summary>
        /// Obtient la liste des collaborateurs ayant comme poste "assistante"
        /// </summary>
        /// <returns>La liste des assistantes</returns>
        // TODO : Assistantes comme poste dans la db "assitante"?
        public List<Collaborateur> GetAssistantesList()
        {
            var context = new DAL.AGADataBaseContainer();
            List <DAL.Collaborateur> listeCollaborateur=context.CollaborateurSet.Where(c => c.Poste =="Assistante").ToList();
            context.Dispose();

            return CollaborateurMapping.EntityToDto(listeCollaborateur);
        }

        #region Stagiaires
        /// <summary>
        /// Obtient la liste des stagiaires à partir d'un fichier excel avec le pattern suivant :
        /// 1-On commence par la première ligne.
        /// 2- Colonne 1= civilite, colonne 2= nom, colonn3= prenom, colonne4= cin, colonne5= adresse, colonne6= date début de stage, colonne7=ddate de fin de stage
        /// </summary>
        /// <param name="fichierExcel">le fichier excel .xlsx</param>
        /// <returns>La liste des stagiaires</returns>
        public List<Stagiaire> GetStagiairesList(FileStream fichierExcel)
        {
            List<Stagiaire> stagiairesList = new List<Stagiaire>();
            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fichierExcel);

            while (reader.Read())
            {
                Stagiaire stagiaire = new Stagiaire();
                stagiaire.Civilite.Label = reader.GetString(0);
                stagiaire.Nom = reader.GetString(1);
                stagiaire.Prenom = reader.GetString(2);
                stagiaire.Cin = reader.GetString(3);
                stagiaire.Adresse = reader.GetString(4);
                stagiaire.DateDebut = DateTime.Parse(reader.GetString(5));
                stagiaire.DateFin = DateTime.Parse(reader.GetString(6));

                stagiairesList.Add(stagiaire);
            }

            return stagiairesList;
        }

        /// <summary>
        /// Obtient la liste des stagiaires PFE depuis la base de données
        /// </summary>
        /// <returns>La liste des stagiaires PFE</returns>
        public List<Stagiaire> GetStagiairesPfeList()
        {
            var context = new DAL.AGADataBaseContainer();
            List<DAL.Stagiaire> stagiairesPfeList = context.StagiaireSet.ToList();
            context.Dispose();
            return StagiaireMapping.EntityToDto(stagiairesPfeList);
        }
        #endregion

        /// <summary>
        /// Cherche la liste des collaborateur non eligibles pour l'attestation irrévocable de salaire
        /// </summary>
        /// <returns>La liste des collaborateurs non eligibles</returns>
        public List<Collaborateur> GetCollaborateursNonEligiblesList()
        {
            var context = new DAL.AGADataBaseContainer();
            List<DAL.Collaborateur> collaborateursList = context.CollaborateurSet.Where(c => c.IsEligible == false).ToList();
            context.Dispose();

            return CollaborateurMapping.EntityToDto(collaborateursList);
        }

        
    }
}
