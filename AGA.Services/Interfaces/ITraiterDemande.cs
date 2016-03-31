using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;
using System.ServiceModel;

namespace AGA.Services.Interfaces
{
    /// <summary>
    /// Permet de changer les statuts des demandes, récupèrer des demandes selon un critère..
    /// </summary>
    [ServiceContract]
    public interface ITraiterDemande
    {
        /// <summary>
        /// Retourne la liste des demandes "En Attente"
        /// </summary>
        /// <returns>Liste des demandes</returns>
        [OperationContract]
        List<Demande> GetDemandesEnAttenteList();

        /// <summary>
        /// Retourne le nombre de demande en attente (non traitées encore)
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int GetNombreDemandesEnAttente();

        /// <summary>
        /// Retourne toutes les demandes faites par un collaborateur donné
        /// </summary>
        /// <param name="idCollaborateur">L'id du collaborateur</param>
        /// <returns>La liste des demandes</returns>
        [OperationContract]
        List<Demande> GetDemandesListParCollaborateur(int idCollaborateur);

        /// <summary>
        /// Retourne la liste des demandes en cours de traitement par une assistante donnée
        /// </summary>
        /// <param name="idAssistante">L'id de l'assistante</param>
        /// <returns>La liste des demandes</returns>
        [OperationContract]
        List<Demande> GetDemandesEnCoursParAssistante(int idAssistante);

        /// <summary>
        ///Assigner le traitement d'une liste de demandes à une assistante
        /// </summary>
        /// <param name="demandesList">La liste de demandes</param>
        /// <param name="idAssistante">L'id de l'assitante dans la BD</param>
        [OperationContract]
        void AjouterDemandesListAssistante(List<Demande> demandesList, int idAssistante);

        /// <summary>
        /// Change le statut d'une demande à "En cours"
        /// </summary>
        /// <param name="demande">La demande</param>
        [OperationContract]
        void ChangerStatutEnCours(Demande demande);

        /// <summary>
        /// Change le statut d'une liste de demandes à "En cours"
        /// </summary>
        /// <param name="demandeList">La liste des demandes</param>
        [OperationContract]
        void ChangerStatutEnCoursList(List<Demande> demandesList);

        /// <summary>
        /// Change le statut d'une demande à "Prete"
        /// </summary>
        /// <param name="demande">La demande</param>
        [OperationContract]
        void ChangerStatutPrete(Demande demande);

        /// <summary>
        /// Change le statut d'une liste de demandes à "Prête"
        /// </summary>
        /// <param name="demandesList">La liste des demandes</param>
        [OperationContract]
        void ChangerStatutPreteList(List<Demande> demandesList);

        /// <summary>
        /// Change le statut d'une demande à "Rejetee"
        /// </summary>
        /// <param name="demande">La demande</param>
        [OperationContract]
        void ChangerStatutRejetee(Demande demande);

        /// <summary>
        /// Change le statut d'une liste de demandes à "Rejetee"
        /// </summary>
        /// <param name="demandesList">La liste des demandes</param>
        [OperationContract]
        void ChangerStatutRejeteeList(List<Demande> demandesList);

    }
}
