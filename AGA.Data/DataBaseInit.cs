using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGA.DAL
{
    /// <summary>
    /// Remplir AGADataBase avec un jeu de données 
    /// </summary>
    public class DataBaseInit
    {
        private AGADataBaseContainer context = new AGADataBaseContainer();
        /// <summary>
        /// Initilaiser la base de données avec un jeu de données
        /// </summary>
        public DataBaseInit()
        {
            //Mail Template
            MailTemplate mailEnAttente= context.MailTemplateSet.Add(new MailTemplate() { Code = "EnAttente", Objet = "Demande d'attestation créée", Contenu = "%civilite% %nom% %prenom% votre %typeAttestation% a bien été créée." });
            MailTemplate mailEnCours= context.MailTemplateSet.Add(new MailTemplate() { Code = "EnCours", Objet = "Demande en cours de traitement", Contenu = "%civilite% %nom% %prenom% est en cours de traitement." });
            MailTemplate mailPrete=context.MailTemplateSet.Add(new MailTemplate() { Code = "Prete", Objet = "Demande prête", Contenu = "%civilite% %nom% %prenom%, Nous vous informons que votre demande est prête." });
            MailTemplate mailRejetee=context.MailTemplateSet.Add(new MailTemplate() { Code = "Assistante", Objet = "Demandes d'attestation en attente", Contenu = "Vous avez %nombre% demandes en attente de votre traitement." });
            MailTemplate mailResponsable = context.MailTemplateSet.Add(new MailTemplate() { Code = "Responsable", Objet = "Demandes d'autorisations en attente", Contenu = "Une demande de %typeAttestation% soumise par %nom% %prenom% est en attente de votre décision." });

            //Statut
            Statut statutEnAttente = context.StatutSet.Add(new Statut() { Code = "EnAttente", Label = "En attente", MailTemplate = mailEnAttente });
            Statut statutEnCours = context.StatutSet.Add(new Statut() { Code = "EnCours", Label = "En cours", MailTemplate = mailEnCours });
            Statut statutPrete = context.StatutSet.Add(new Statut() { Code = "Prete", Label = "Prête", MailTemplate = mailPrete });
            Statut statutRejetee = context.StatutSet.Add(new Statut() { Code = "Rejetee", Label = "Rejetée", MailTemplate = mailRejetee });

            //Civilite
            Civilite civiliteMme = context.CiviliteSet.Add(new Civilite() {Code="Mme", Label="Madame"});
            Civilite civiliteM = context.CiviliteSet.Add(new Civilite() { Code = "M", Label = "Monsieur" });

            //TypeAttestation
            TypeAttestation attestationSalaire = context.TypeAttestationSet.Add(new TypeAttestation() {Code="AttestationSalaire", Label="Attestation Salaire", Template=File.ReadAllBytes(@"C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI.mvc5\AGA.Business\Templates\AttestationSalaire.docx")});
            TypeAttestation attestationConge = context.TypeAttestationSet.Add(new TypeAttestation() { Code = "AttestationSalaire", Label = "Attestation Salaire", Template = File.ReadAllBytes(@"C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI.mvc5\AGA.Business\Templates\AttestationConge.docx") });
            TypeAttestation attestationIrrevocableSalaire = context.TypeAttestationSet.Add(new TypeAttestation() { Code = "AttestationIrrevocableSalaire", Label = "Attestation Irrevocable de Salaire", Template = File.ReadAllBytes(@"C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI.mvc5\AGA.Business\Templates\AttestationIrrevocableSalaire.docx") });
            TypeAttestation attestationStage = context.TypeAttestationSet.Add(new TypeAttestation() { Code = "AttestationStage", Label = "Attestation Stage", Template = File.ReadAllBytes(@"C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI.mvc5\AGA.Business\Templates\AttestationStage.docx") });
            TypeAttestation attestationTravail = context.TypeAttestationSet.Add(new TypeAttestation() { Code = "AttestationTravail", Label = "Attestation Travail", Template = File.ReadAllBytes(@"C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI.mvc5\AGA.Business\Templates\AttestationTravail.docx") });
            TypeAttestation autorisationCoursVacation = context.TypeAttestationSet.Add(new TypeAttestation() { Code = "AutorisationCoursVacation", Label = "Autorisation Cours Vacation", Template = File.ReadAllBytes(@"C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI.mvc5\AGA.Business\Templates\AutorisationCoursVacation.docx") });
            TypeAttestation autorisationPoursuiteEtudes = context.TypeAttestationSet.Add(new TypeAttestation() { Code = "AutorisationPoursuiteEtudes", Label = "Autorisation de Poursuite d'Etudes", Template = File.ReadAllBytes(@"C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI.mvc5\AGA.Business\Templates\AutorisationPoursuiteEtudes.docx") });
            TypeAttestation reponseLettreDemission = context.TypeAttestationSet.Add(new TypeAttestation() { Code = "ReponseLettreDemission", Label = "Reponse à la Lettre de Démission", Template = File.ReadAllBytes(@"C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI.mvc5\AGA.Business\Templates\ReponseLettreDemission.docx") });

            //Collaborateur
            Collaborateur MeryemCollaborateur = context.CollaborateurSet.Add(new Collaborateur() {Adresse="A82", Banque="Banque populaire", Cin="F67315", Civilite=civiliteMme, Cnss="CLDZ89ZEE7", DateDebutTravail=DateTime.Parse("15/02/2016"), IsEligible=true, Nom="Elhammouti" , Prenom="Meryem", Poste="Collaborateur" });
            Collaborateur AsmaeCollaborateur = context.CollaborateurSet.Add(new Collaborateur() { Adresse = "NB322", Banque = "Attijari wafabank", Cin = "E6328", Civilite = civiliteMme, Cnss = "KJGZF87823B", DateDebutTravail = DateTime.Parse("07/02/2016"), IsEligible = true, Nom = "Makrat", Prenom = "Asmae", Poste = "Collaborateur" });
            Collaborateur FouadCollaborateur = context.CollaborateurSet.Add(new Collaborateur() { Adresse = "G3532", Banque = "Banque populaire", Cin = "DHZ829", Civilite = civiliteM, Cnss = "D2362BS29J", DateDebutTravail = DateTime.Parse("01/03/2016"), IsEligible = false, Nom = "Aziouz", Prenom = "Fouad", Poste = "Collaborateur" });

            //Assitante
            Collaborateur ImaneCollaborateur = context.CollaborateurSet.Add(new Collaborateur() { Adresse = "TE8632", Banque = "BMCE", Cin = "H8372", Civilite = civiliteMme, Cnss = "JDZG823B8", DateDebutTravail = DateTime.Parse("01/02/2016"), IsEligible = false, Nom = "Baba", Prenom = "Imane", Poste = "Assistante" });

            //Demande
            Demande demandeMeryem = context.DemandeSet.Add(new Demande() { Collaborateur = MeryemCollaborateur, DateCreation = DateTime.Now, Statut = statutEnAttente, TypeAttestation = attestationSalaire });
            Demande demandeFouad = context.DemandeSet.Add(new Demande() { Collaborateur = FouadCollaborateur, DateCreation = DateTime.Now, Statut = statutEnAttente, TypeAttestation = attestationIrrevocableSalaire });
            Demande demandeAsmae = context.DemandeSet.Add(new Demande() { Collaborateur = AsmaeCollaborateur, DateCreation = DateTime.Now, Statut = statutEnAttente, TypeAttestation = autorisationCoursVacation });

            context.SaveChanges();
            context.Dispose();
        }
    }
}
