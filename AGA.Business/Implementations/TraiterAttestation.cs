using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
using Novacode;
using System.Diagnostics;
using AGA.Common.Entities;
using AGA.Services.Interfaces;
using AGA;
using AGA.Common.DTO.Models;
using Microsoft.AspNet.Http;

namespace AGA.Business.Implementations
{
    /// <summary>
    /// Classe responsable de la génération, téléchargement et impression des attestations
    /// </summary>
    public class TraiterAttestation : ITraiterAttestation
    {
        #region Public
        /// <summary>
        /// Génére une attestation de congé (fichier .docx) 
        /// </summary>
        /// <param name="attestationConge">une attestation de congé</param>
        /// <returns>Le fichier de l'attestation de congé</returns>
        public MemoryStream GenererAttestationConge(AttestationConge attestationConge)
        {
            DocX template = this.getTemplate("AttestationConge");
            Dictionary<String, String> dictionnaireTokens = new Dictionary<string, string>();

            dictionnaireTokens.Add("%nom%", attestationConge.Demande.Collaborateur.Nom);
            dictionnaireTokens.Add("%prenom%", attestationConge.Demande.Collaborateur.Prenom);
            dictionnaireTokens.Add("%date%", String.Format("DD/MM/YYYY", DateTime.Now));
            dictionnaireTokens.Add("%civilite%", attestationConge.Demande.Collaborateur.Civilite.Label);
            dictionnaireTokens.Add("%dateDebut%", String.Format("DD/MM/YYYY", attestationConge.DateDebut));
            dictionnaireTokens.Add("%dateFin%", String.Format("DD/MM/YYYY", attestationConge.DateFin));
            dictionnaireTokens.Add("%adresse%", attestationConge.Demande.Collaborateur.Adresse);

            return Generer(dictionnaireTokens, template);
        }

        /// <summary>
        /// Génére une attestation de irrévocable de salaire (fichier .docx) 
        /// </summary>
        /// <param name="attestationIrrevocableSalaire">une attestation irrévocable de salaire</param>
        /// <returns>Le fichier de l'attestation irrévocable de salaire</returns>
        public MemoryStream GenererAttestationIrrevocableSalaire(AttestationIrrevocableSalaire attestationIrrevocableSalaire)
        {
            DocX template = this.getTemplate("AttestationIrrevocableSalaire");
            Dictionary<String, String> dictionnaireTokens = new Dictionary<string, string>();

            dictionnaireTokens.Add("%nom%", attestationIrrevocableSalaire.Collaborateur.Nom);
            dictionnaireTokens.Add("%prenom%", attestationIrrevocableSalaire.Collaborateur.Prenom);
            dictionnaireTokens.Add("%civilite%", attestationIrrevocableSalaire.Collaborateur.Civilite.Label);
            dictionnaireTokens.Add("%banque%", attestationIrrevocableSalaire.Collaborateur.Banque);
            dictionnaireTokens.Add("%dateDebutTravail%", String.Format("DD/MM/YYYY", attestationIrrevocableSalaire.Collaborateur.DateDebutTravail));
            dictionnaireTokens.Add("%date%", String.Format("DD/MM/YYYY", DateTime.Now));
            dictionnaireTokens.Add("%compte%", attestationIrrevocableSalaire.NumeroCompte);

            return Generer(dictionnaireTokens, template);
        }

        /// <summary>
        /// Génére une attestation de salaire (fichier .docx)
        /// </summary>
        /// <param name="attestationSalaire">une attestation de salaire</param>
        /// <returns>Le fichier de l'attestation de salaire</returns>
        public MemoryStream GenererAttestationSalaire(AttestationSalaire attestationSalaire)
        {
            DocX template = this.getTemplate("AttestationSalaire");
            Dictionary<String, String> dictionnaireTokens = new Dictionary<string, string>();

            dictionnaireTokens.Add("%nom%", attestationSalaire.Collaborateur.Nom);
            dictionnaireTokens.Add("%prenom%", attestationSalaire.Collaborateur.Prenom);
            dictionnaireTokens.Add("%civilite%", attestationSalaire.Collaborateur.Civilite.Label);
            dictionnaireTokens.Add("%poste%", attestationSalaire.Collaborateur.Poste);
            dictionnaireTokens.Add("%adresse", attestationSalaire.Collaborateur.Adresse);
            dictionnaireTokens.Add("%salaire%", attestationSalaire.Salaire.ToString());
            dictionnaireTokens.Add("%date%", String.Format("DD/MM/YYYY", DateTime.Now));

            return Generer(dictionnaireTokens, template);
        }

        /// <summary>
        /// Génére une attestation de stage (fichier .docx) 
        /// </summary>
        /// <param name="attestationStage">une attestation de stage</param>
        /// <returns>Le fichier de l'attestation de stage</returns>
        public MemoryStream GenererAttestationStage(AttestationStage attestationStage)
        {
            DocX template = this.getTemplate("AttestationStage");
            Dictionary<String, String> dictionnaireTokens = new Dictionary<string, string>();

            dictionnaireTokens.Add("%nom%", attestationStage.Stagiaire.Nom);
            dictionnaireTokens.Add("%prenom%", attestationStage.Stagiaire.Prenom);
            dictionnaireTokens.Add("%date%", String.Format("DD/MM/YYYY", DateTime.Now));
            dictionnaireTokens.Add("%civilite%", attestationStage.Stagiaire.Civilite.Label);
            dictionnaireTokens.Add("%cin%", attestationStage.Stagiaire.Cin);
            dictionnaireTokens.Add("%adresse%", attestationStage.Stagiaire.Adresse);

            return Generer(dictionnaireTokens, template);
        }

        /// <summary>
        /// Génére une attestation de travail (fichier .docx)
        /// </summary>
        /// <param name="attestationTravail">une attestation de travail</param>
        /// <returns>Le fichier de l'attestation de salaire</returns>
        public MemoryStream GenererAttestationTravail(AttestationTravail attestationTravail)
        {
            DocX template = this.getTemplate("AttestationTravail");
            Dictionary<String, String> dictionnaireTokens = new Dictionary<string, string>();

            dictionnaireTokens.Add("%nom%", attestationTravail.Collaborateur.Nom);
            dictionnaireTokens.Add("%prenom%", attestationTravail.Collaborateur.Prenom);
            dictionnaireTokens.Add("%civilite%", attestationTravail.Collaborateur.Civilite.Label);
            dictionnaireTokens.Add("%adresse%", attestationTravail.Collaborateur.Adresse);
            dictionnaireTokens.Add("%date%", String.Format("DD/MM/YYYY", DateTime.Now));
            dictionnaireTokens.Add("%cin%", attestationTravail.Collaborateur.Cin);
            dictionnaireTokens.Add("%cnss%", attestationTravail.Collaborateur.Cnss);
            dictionnaireTokens.Add("%poste%", attestationTravail.Collaborateur.Poste);
            dictionnaireTokens.Add("%dateDebutTravail%", String.Format("DD/MM/YYYY", attestationTravail.Collaborateur.DateDebutTravail));

            return Generer(dictionnaireTokens, template);
        }

        /// <summary>
        /// Génére une autorisation de cours de vacation (fichier .docx)
        /// </summary>
        /// <param name="autorisationCoursVacation">une autorisation de cours de vacation</param>
        /// <returns>Le fichier de l'autorisation de cours de vacation</returns>
        public MemoryStream GenererAutorisationCoursVacation(AutorisationCoursVacation autorisationCoursVacation)
        {
            DocX template = this.getTemplate("AttestationCoursVacation");
            Dictionary<String, String> dictionnaireTokens = new Dictionary<string, string>();

            dictionnaireTokens.Add("%nom%", autorisationCoursVacation.Demande.Collaborateur.Nom);
            dictionnaireTokens.Add("%prenom%", autorisationCoursVacation.Demande.Collaborateur.Prenom);
            dictionnaireTokens.Add("%civilite%", autorisationCoursVacation.Demande.Collaborateur.Civilite.Label);
            dictionnaireTokens.Add("%cin%", autorisationCoursVacation.Demande.Collaborateur.Cin);
            dictionnaireTokens.Add("%date%", String.Format("DD/MM/YYYY", DateTime.Now));
            dictionnaireTokens.Add("%etablissement%", autorisationCoursVacation.Etablissement);
            dictionnaireTokens.Add("%anneeScolaire%", autorisationCoursVacation.AnneeScolaire);

            return Generer(dictionnaireTokens, template);
        }

        /// <summary>
        /// Génére une autorisation de poursuite d'études (fichier .docx)
        /// </summary>
        /// <param name="autorisationPoursuiteEtudes">une autorisation de poursuite d'études</param>
        /// <returns>Le fichier de l'autorisation de poursuite d'études</returns>
        public MemoryStream GenrerAutorisationPoursuiteEtudes(AutorisationPoursuiteEtudes autorisationPoursuiteEtudes)
        {
            DocX template = this.getTemplate("AttestationPoursuiteEtudes");
            Dictionary<String, String> dictionnaireTokens = new Dictionary<string, string>();

            dictionnaireTokens.Add("%nom%", autorisationPoursuiteEtudes.Demande.Collaborateur.Nom);
            dictionnaireTokens.Add("%prenom%", autorisationPoursuiteEtudes.Demande.Collaborateur.Prenom);
            dictionnaireTokens.Add("%civilite%", autorisationPoursuiteEtudes.Demande.Collaborateur.Civilite.Label);
            dictionnaireTokens.Add("%cin%", autorisationPoursuiteEtudes.Demande.Collaborateur.Cin);
            dictionnaireTokens.Add("%etablissement%", autorisationPoursuiteEtudes.Etablissement);
            dictionnaireTokens.Add("%anneeScolaire%", autorisationPoursuiteEtudes.AnneeScolaire);
            dictionnaireTokens.Add("%date%", String.Format("DD/MM/YYYY", DateTime.Now));

            return Generer(dictionnaireTokens, template);
        }

        /// <summary>
        /// Génére une "réponse à la lettre de démission" en fichier
        /// </summary>
        /// <param name="reponseLettreDemission">La réponse de la lettre de démission</param>
        /// <returns>le fichier "réponse à la lettre de démission"</returns>
        public MemoryStream GenererReponseLettreDemission(ReponseLettreDemission reponseLettreDemission)
        {
            DocX template = this.getTemplate("ReponseLettreDemission");
            Dictionary<String, String> dictionnaireTokens = new Dictionary<string, string>();

            dictionnaireTokens.Add("%nom%", reponseLettreDemission.Collaborateur.Nom);
            dictionnaireTokens.Add("%prenom%", reponseLettreDemission.Collaborateur.Prenom);
            dictionnaireTokens.Add("%civilite%", reponseLettreDemission.Collaborateur.Civilite.Label);
            dictionnaireTokens.Add("%adresse%", reponseLettreDemission.Collaborateur.Adresse);
            dictionnaireTokens.Add("%date%", String.Format("DD/MM/YYYY", DateTime.Now));
            dictionnaireTokens.Add("%dateFinContrat%", String.Format("DD/MM/YYYY", reponseLettreDemission.DateFinContrat));
            dictionnaireTokens.Add("%dateReceptionDemande%", String.Format("DD/MM/YYYY", reponseLettreDemission.DateReceptionDemande));
            dictionnaireTokens.Add("%ref%", reponseLettreDemission.Reference);

            return Generer(dictionnaireTokens, template);
        }

        /// <summary>
        /// Telecharge un document .doc
        /// </summary>
        /// <param name="Response">la reponse http</param>
        /// <param name="document">le document à télécharger</param>
        //TODO : (Fermeture de la reponse)?
        public void Telecharger(HttpResponse Response, MemoryStream documentStream)
        {
            Response.Headers.Clear();
            Response.Headers.Add("content-disposition", @"attachment; filename=\attestation.doc\");
            Response.ContentType = "application/msword";
            documentStream.WriteTo(Response.Body);
            //Response.End();
        }


        //TODO: Installer  Word et utiliser l API Interop
        public void Imprimer(DocX document)
        {
            //String documentLocation = Path.GetTempFileName();
            //document.SaveAs(documentLocation);

            //ProcessStartInfo info = new ProcessStartInfo(documentLocation);
            //info.Verb = "Print";
            //info.CreateNoWindow = true;
            //info.WindowStyle = ProcessWindowStyle.Hidden;
            //Process.Start(info);
        }
        #endregion

        #region Private

        /// <summary>
        /// Crée un document (.docx) à partir d'une templace avec des tokens (mot remplacé, mot remplaçant)
        /// </summary>
        /// <param name="dictionnaireTokens">Dictionnaire des mots (remplacé, remplaçant) </param>
        /// <param name="template">Le doc word template ou aura lieu le remplacement</param>
        /// <returns>Le chemin complet du document modifié (.docx)</returns>
        private MemoryStream Generer(Dictionary<String, String> dictionnaireTokens, DocX template)
        {
            DocX outputDoc = template.Copy();

            for (int i = 0; i < dictionnaireTokens.Count; i++)
            {
                outputDoc.ReplaceText(dictionnaireTokens.Keys.ElementAt(i), dictionnaireTokens.Values.ElementAt(i));
            }

            MemoryStream memoryStream = new MemoryStream();
            outputDoc.SaveAs(memoryStream);

            return memoryStream;
        }



        /// <summary>
        /// Récupère la template d'une attestation depuis la base donnée
        /// </summary>
        /// <param name="attestationCode">le code du type d'attestation dans la BD</param>
        /// <returns>Le Docx de la template</returns>
        private DocX getTemplate(String attestationCode)
        {
            var context = new DAL.AGADataBaseContainer();
            DAL.TypeAttestation typeAttestation = context.TypeAttestationSet.FirstOrDefault(type => type.Code == attestationCode);
            context.Dispose();

            String pathTmp = Path.GetTempFileName();
            File.WriteAllBytes(pathTmp, typeAttestation.Template);

            return DocX.Load(pathTmp);
        }
        #endregion
        
    }
}
