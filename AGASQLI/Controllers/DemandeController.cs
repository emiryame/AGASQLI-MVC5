using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGA.Services;
using AGA.Business;
using AGA.DTO.Models;
using AGASQLI.ViewModels;

namespace AGASQLI.Controllers
{
    public class DemandeController : Controller
    {
        private AGA.Data.AGADataBaseContainer db = new AGA.Data.AGADataBaseContainer();

        // GET: Demandes
        //TODO: A netoyer..
        public ActionResult EnAttente()
        {
            AGASQLI.Services.TraiterDemandeClient demandeService = new AGASQLI.Services.TraiterDemandeClient();
            //ITraiterDemande demandeService = new TraiterDemande();
            List<Demande> demandesList = new List<Demande>();
            demandesList = demandeService.GetDemandesEnAttenteList().ToList();

            List<DemandeViewModel> demandesViewModelList = new List<DemandeViewModel>();
            demandesList.ForEach(d => demandesViewModelList.Add(new DemandeViewModel(d)));
            demandeService.Close();

            return View(demandesViewModelList);
        }

        [HttpPost]
        public ActionResult EnAttente(List<DemandeViewModel> demandesViewModelList)
        {
            //List<DemandeViewModel> demandesViewModelCheckedList = new List<DemandeViewModel>();
            //demandesViewModelCheckedList=demandesViewModelList.Where(d => d.IsChecked == false).ToList();
            //List<Demande> demandesList = new List<Demande>();
            //if(demandesList!=null)
            //    demandesViewModelCheckedList.ForEach(d => demandesList.Add(d.Demande));

            //ITraiterDemande demandeService = new TraiterDemande();
            //demandeService.AjouterDemandesListAssistante(demandesList, 4);
            return RedirectToAction("EnAttente");
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
