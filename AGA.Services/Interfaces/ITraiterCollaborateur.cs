using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;
using System.IO;
using System.ServiceModel;

namespace AGA.Services.Interfaces
{
    /// <summary>
    /// Classe permettant de traiter les collaborateurs, assistantes, stagiaires
    /// </summary>
    [ServiceContract]
    public interface ITraiterCollaborateur
    {
        /// <summary>
        /// Génére le mail d'un collaborateur à partir de son nom et pénom
        /// </summary>
        /// <param name="collaborateur">Le collaborateur</param>
        /// <returns>Le mail du collaborateur</returns>
        [OperationContract]
        String GetEmail(Collaborateur collaborateur);

        /// <summary>
        /// Génére la liste de mail d'un ensemble de collaborateur
        /// </summary>
        /// <param name="collaborateurList">La liste de collaborateur</param>
        /// <returns>La liste de mail</returns>
        [OperationContract]
        List<String> GetEmailList(List<Collaborateur> collaborateurList);

        /// <summary>
        /// Obtient la liste des collaborateurs ayant comme poste "assistante"
        /// </summary>
        /// <returns>La liste des assistantes</returns>
        [OperationContract]
        List<Collaborateur> GetAssistantesList();

        /// <summary>
        /// Obtient la liste des stagiaires à partir d'un fichier excel avec le pattern suivant :
        /// 1-On commence par la première ligne.
        /// 2- Colonne 1= civilite, colonne 2= nom, colonn3= prenom, colonne4= cin, colonne5= adresse, colonne6= date début de stage, colonne7=ddate de fin de stage
        /// </summary>
        /// <param name="fichierExcel">le fichier excel .xlsx</param>
        /// <returns>La liste des stagiaires</returns>
        [OperationContract]
        List<Stagiaire> GetStagiairesList(FileStream fichierExcel);

        /// <summary>
        /// Obtient la liste des stagiaires PFE depuis la base de données
        /// </summary>
        /// <returns>La liste des stagiaires PFE</returns>
        [OperationContract]
        List<Stagiaire> GetStagiairesPfeList();

        /// <summary>
        /// Cherche la liste des collaborateur non eligibles pour l'attestation irrévocable de salaire
        /// </summary>
        /// <returns>La liste des collaborateurs non eligibles</returns>
        [OperationContract]
        List<Collaborateur> GetCollaborateursNonEligiblesList();
    }
}
