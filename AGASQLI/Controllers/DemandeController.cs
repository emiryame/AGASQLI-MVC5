using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGASQLI.ServiceDemande;
using AGA.Common.DTO.Models;
using AGASQLI.ViewModels;
using AGASQLI.WorkflowAjouterAMesTaches;
using Microsoft.Practices.Unity;
using System.Activities;
using System.ServiceModel.Activities;
using System.Activities.XamlIntegration;
using AGASQLI.ServiceNotification;

namespace AGASQLI.Controllers
{
    public class DemandeController : Controller
    {
        [Dependency]
        public ITraiterDemande demandeService { get; set; }

        [Dependency]
        public INotification notificationService { get; set; }

        /// <summary>
        /// Afficher la liste des demandes en attente de traitement
        /// </summary>
        /// <returns>la vue de la rubrique EnAttente</returns>
        public ActionResult EnAttente()
        {
            List<Demande> demandesList = new List<Demande>();
            demandesList = demandeService.GetDemandesEnAttenteList().ToList();

            List<DemandeViewModel> demandesViewModelList = new List<DemandeViewModel>();
            if (demandesList != null)
                demandesList.ForEach(d => demandesViewModelList.Add(new DemandeViewModel(d)));

            return View(demandesViewModelList);
        }

        /// <summary>
        /// Ajoute la liste des demandes selectionnées à la liste des taches de l'assitante connectée
        /// </summary>
        /// <param name="demandesViewModelList">La liste des demandes à ajouter</param>
        /// <returns>la vue des demandes en attente</returns>
        //TODO: Bouchon ID Assistante!
        [HttpPost]
        public ActionResult EnAttente(List<DemandeViewModel> demandesViewModelList)
        {
            //Recupérer la liste des demandes selectionnées.
            List<DemandeViewModel> demandesViewModelCheckedList = new List<DemandeViewModel>();

            if (demandesViewModelList != null)
            {
                demandesViewModelCheckedList = demandesViewModelList.Where(d => d.IsChecked == true).ToList();
            }

            List<Demande> demandesList = new List<Demande>();
            demandesViewModelCheckedList.ForEach(d => demandesList.Add(d.Demande));

            //Démarrer le workflow: AjouterAMesTaches
            IAjouterAMesTaches workflow = new AjouterAMesTachesClient();
            var donnees = new AjouterDonnees() { demandesListEntree = demandesList.ToArray(), idAssistanteEntree = 4 };
            workflow.AjouterDonnees(new AjouterDonneesRequest(donnees));
            
            return RedirectToAction("EnAttente");
        }

        /// <summary>
        /// Affiche la liste des tâches en cours de l'assistante connectée
        /// </summary>
        /// <returns>La vue "Mes Taches"</returns>
        //TODO : remplacer le bouchon "4" par l'ID de l'assitante connectée
        public ActionResult MesTaches()
        {
            return View(demandeService.GetDemandesEnCoursParAssistante(4));
        }
        //// GET: Demandes/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //   // Demande demande = db.DemandeSet.Find(id);
        //    if (demande == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(demande);
        //}

        //// GET: Demandes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Demandes/Create
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,DateCreation,DateDebutTraitement,DateFinTraitement")] Demande demande)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.DemandeSet.Add(demande);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(demande);
        //}

        //// GET: Demandes/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Demande demande = db.DemandeSet.Find(id);
        //    if (demande == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(demande);
        //}

        //// POST: Demandes/Edit/5
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,DateCreation,DateDebutTraitement,DateFinTraitement")] Demande demande)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(demande).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(demande);
        //}

        //// GET: Demandes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Demande demande = db.DemandeSet.Find(id);
        //    if (demande == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(demande);
        //}

        //// POST: Demandes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Demande demande = db.DemandeSet.Find(id);
        //    db.DemandeSet.Remove(demande);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
