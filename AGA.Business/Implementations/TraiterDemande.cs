using AGA.Common.DTO.Mapping;
using AGA.Common.DTO.Models;
using AGA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace AGA.Business.Implementations
{
    /// <summary>
    /// La classe permet de changer les statuts des demandes, récupèrer des demandes selon un critère..
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TraiterDemande :ITraiterDemande
    {
        /// <summary>
        /// Retourne la liste des demandes "En Attente"
        /// </summary>
        /// <returns>Liste des demandes</returns>
        public List<Demande> GetDemandesEnAttenteList()
        {
            var context = new DAL.AGADataBaseContainer();
            List<DAL.Demande> demandesList = new List<DAL.Demande>();
            demandesList=context.DemandeSet.Where(d => d.Statut.Code == "EnAttente").ToList();

            return DemandeMapping.EntityToDto(demandesList);    
        }

        /// <summary>
        /// Retourne le nombre de demande en attente (non traitées encore)
        /// </summary>
        /// <returns></returns>
        public int GetNombreDemandesEnAttente()
        {
            return this.GetDemandesEnAttenteList().Count();
        }
        
        /// <summary>
        /// Retourne toutes les demandes faites par un collaborateur donné
        /// </summary>
        /// <param name="idCollaborateur">L'id du collaborateur</param>
        /// <returns>La liste des demandes</returns>
        public List<Demande> GetDemandesListParCollaborateur(int idCollaborateur)
        {
            var context = new DAL.AGADataBaseContainer();
            List<DAL.Demande> demandesList=context.DemandeSet.Where(d => d.Collaborateur.Id == idCollaborateur).ToList();

            return DemandeMapping.EntityToDto(demandesList);
        }

        /// <summary>
        /// Retourne la liste des demandes en cours de traitement par une assistante donnée
        /// </summary>
        /// <param name="idAssistante">L'id de l'assistante</param>
        /// <returns>La liste des demandes</returns>
        public List<Demande> GetDemandesEnCoursParAssistante(int idAssistante)
        {
            var context = new DAL.AGADataBaseContainer();
            List<DAL.Demande> demandesList = context.DemandeSet.Where(d => d.Assistante.Id == idAssistante && d.Statut.Code=="EnCours").ToList();

            return DemandeMapping.EntityToDto(demandesList);
        }

        /// <summary>
        ///Assigner le traitement d'une liste de demandes à une assistante
        /// </summary>
        /// <param name="demandesList">La liste de demandes</param>
        /// <param name="idAssistante">L'id de l'assitante dans la BD</param>
        public void AjouterDemandesListAssistante(List<Demande> demandesList, int idAssistante)
        {
            demandesList.ForEach(d => this.AjouterDemandeAssitante(d, idAssistante));
        }


        /// <summary>
        /// Change le statut d'une demande à "En cours"
        /// </summary>
        /// <param name="demande">La demande</param>
        public void ChangerStatutEnCours(Demande demande)
        {
            ChangerStatut(demande,"EnCours");
        }

        /// <summary>
        /// Change le statut d'une liste de demandes à "En cours"
        /// </summary>
        /// <param name="demandesList">La liste des demandes</param>
        public void ChangerStatutEnCoursList(List<Demande> demandesList)
        {
            demandesList.ForEach(d => ChangerStatutEnCours(d));
        }

        /// <summary>
        /// Change le statut d'une demande à "Prete"
        /// </summary>
        /// <param name="demande">La demande</param>
        public void ChangerStatutPrete(Demande demande)
        {
            ChangerStatut(demande, "Prete");
        }

        /// <summary>
        /// Change le statut d'une liste de demandes à "Prete"
        /// </summary>
        /// <param name="demandesList">La liste des demandes</param>
        public void ChangerStatutPreteList(List<Demande> demandesList)
        {
            demandesList.ForEach(d=>ChangerStatutPrete(d));
        }



        /// <summary>
        /// Change le statut d'une demande à "Rejetee"
        /// </summary>
        /// <param name="demande">La demande</param>
        public void ChangerStatutRejetee(Demande demande)
        {
            ChangerStatut(demande, "Rejetee");
        }

        /// <summary>
        /// Change le statut d'une liste de demandes à "Rejetee"
        /// </summary>
        /// <param name="demandesList">La liste de demandes</param>
        public void ChangerStatutRejeteeList(List<Demande> demandesList)
        {
            demandesList.ForEach(d=>ChangerStatutRejetee(d));
        }

        /// <summary>
        /// Attribuer la dateTime courante à la date de début de traitement d'une demande
        /// </summary>
        /// <param name="demande">La demande</param>
        public void AjouterDateDebutTraitement(Demande demande)
        {
            var context= new DAL.AGADataBaseContainer();
            DAL.Demande demandeData=context.DemandeSet.FirstOrDefault(d => d.Id == demande.Id);

            demandeData.DateDebutTraitement = DateTime.Now;

            context.Entry(demandeData).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// Attribuer la dateTime courante à la date de début de traitement d'une liste de demande
        /// </summary>
        /// <param name="demandesList">La demande</param>
        public void AjouterDateDebutTraitementList(List<Demande> demandesList)
        {
            demandesList.ForEach(d => this.AjouterDateDebutTraitement(d));
        }

        private void AjouterDemandeAssitante(Demande demande, int idAssistante)
        {
            var context = new DAL.AGADataBaseContainer();
            DAL.Collaborateur assistanteData = context.CollaborateurSet.FirstOrDefault(c => c.Id == idAssistante);

            DAL.Demande demandeData = context.DemandeSet.FirstOrDefault(d => d.Id == demande.Id);
            demandeData.Assistante = assistanteData;

            context.Entry(demandeData).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// Changer le statut d'une demande dans la BD
        /// </summary>
        /// <param name="demande">La demande</param>
        /// <param name="codeStatut">Le code du Statut BD</param>
        private void ChangerStatut(Demande demande, String codeStatut)
        {
            var context = new DAL.AGADataBaseContainer();
            DAL.Statut statutData = context.StatutSet.FirstOrDefault(s => s.Code == codeStatut);
            DAL.Demande demandeData=context.DemandeSet.FirstOrDefault(d => d.Id == demande.Id);

            demandeData.Statut = statutData;
            context.Entry(demandeData).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();    
        }
    }
}
