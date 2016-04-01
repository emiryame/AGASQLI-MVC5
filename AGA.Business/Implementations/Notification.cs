using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;
using AGA.Services.Interfaces;
using AGA.Common.DTO.Mapping;

namespace AGA.Business.Implementations
{
    /// <summary>
    /// Envoyer des notifications mail aux collaborateurs, assistantes et responsable
    /// </summary>
    public class Notification : INotification
    {
        #region Public
        /// <summary>
        /// Notifie le collaborateur par mail de l'état d'avancement de sa demande
        /// </summary>
        /// <param name="demande">La demande</param>
        //TODO: Email Collab depuis getEmail de ITraiterCollaborateur
        public void NotifierCollaborateur(Demande demande)
        {
            //Personnaliser le mail qui sera envoyé au collaborateur
            Dictionary<String, String> dictionnaireTokens = new Dictionary<string, string>();
            dictionnaireTokens.Add("%typeAttestation%", demande.TypeAttestation.Label);
            dictionnaireTokens.Add("%civilite%", demande.Collaborateur.Civilite.Label);
            dictionnaireTokens.Add("%nom%",demande.Collaborateur.Nom);
            dictionnaireTokens.Add("%prenom%", demande.Collaborateur.Prenom);
            String contenuMail = EditTemplateText(dictionnaireTokens, demande.Statut.MailTemplate.Contenu);
            
            //Récupérer le mail du collaborateur
            ITraiterCollaborateur collaborateurService = new TraiterCollaborateur();
            String destinataire = collaborateurService.GetEmail(demande.Collaborateur);

            //Envoyer le mail au collaborateur
             this.Notifier(destinataire, demande.Statut.MailTemplate.Objet, contenuMail);
        }

        /// <summary>
        /// Notifie les collaborateurs par mail de l'état d'avancement de leurs demandes
        /// </summary>
        /// <param name="demandesList">La liste des demandes</param>
        public async void NotifierCollaborateurList(List<Demande> demandesList)
        {
            demandesList.ForEach(d => this.NotifierCollaborateur(d));
        }


        /// <summary>
        /// Notifie les assistantes par mail du nombre des demandes en attente
        /// </summary>
        public void NotifierAssistantesDemandesEnAttente()
        {
            var context = new DAL.AGADataBaseContainer();
            MailTemplate mailTemplate = MailTemplateMapping.EntityToDto(context.MailTemplateSet.FirstOrDefault(i => i.Code == "AssistanteNotif"));
            String objet = mailTemplate.Objet;
            context.Dispose();

            ITraiterDemande demandeService = new TraiterDemande();
            Dictionary<String, String> dictionnaireTokens = new Dictionary<String, String>();
            dictionnaireTokens.Add("%nombre%", demandeService.GetNombreDemandesEnAttente().ToString());
            String contenuMail = EditTemplateText(dictionnaireTokens, mailTemplate.Contenu);

            ITraiterCollaborateur collaborateurService = new TraiterCollaborateur();
            List<String> destinatairesList = collaborateurService.GetEmailList(collaborateurService.GetAssistantesList());

            this.Notifier(destinatairesList, objet, contenuMail);
        }

        /// <summary>
        /// Notifie le responsable de la demande en attente de sa décision
        /// </summary>
        /// <param name="demande">La demande</param>
        //TODO: Mail du responsable à récupérer depuis un xml des params
        public void NotifierResponsable(Demande demande)
        {
            var context = new DAL.AGADataBaseContainer();
            MailTemplate mailTemplate = MailTemplateMapping.EntityToDto(context.MailTemplateSet.FirstOrDefault(i => i.Code == "ResponsableNotif"));
            String objet = mailTemplate.Objet;
            
            Dictionary<String, String> dictionnaireTokens = new Dictionary<String, String>();

            if (demande != null)
            {
                dictionnaireTokens.Add("%typeAttestation%", demande.TypeAttestation.Label);
                dictionnaireTokens.Add("%nom%", demande.Collaborateur.Nom);
                dictionnaireTokens.Add("%prenom%", demande.Collaborateur.Prenom);
            }
            String contenuMail = EditTemplateText(dictionnaireTokens,mailTemplate.Contenu);
            this.Notifier("",objet,contenuMail);
        }

        #endregion

        #region Private
        /// <summary>
        /// Remplace dans un text (string) des tokens (string) par d'autres.
        /// </summary>
        /// <param name="dictionnaireTokens">Dictionnaire des tokens (remplacé, remplaçant)</param>
        /// <param name="text">Le text ou aura lieu le remplacement</param>
        /// <returns>Le text resultat après remplacement</returns>
        private String EditTemplateText (Dictionary<String,String> dictionnaireTokens,String text)
        {
            for(int i=0; i< dictionnaireTokens.Count(); i++)
            {
                text = text.Replace(dictionnaireTokens.Keys.ElementAt(i),dictionnaireTokens.Values.ElementAt(i));
            }
            return text;
        }

        /// <summary>
        /// Envoie ne notification par mail à un groupe de destinataire
        /// </summary>
        /// <param name="destinatairesList">La liste des mails des destinataiire</param>
        /// <param name="objet">L'objet du mail</param>
        /// <param name="contenu">Le contenu du mail</param>
        private void Notifier(List<String> destinatairesList,String objet, String contenu)
        {
            if (destinatairesList != null)
                destinatairesList.ForEach(d => this.Notifier(d, objet, contenu));
        }
        /// <summary>
        /// Envoie une notification par mail à un destinataire
        /// </summary>
        /// <param name="destinataire">L'adresse mail du destinataire</param>
        /// <param name="objet">L'objet du mail</param>
        /// <param name="contenu">Le contenu du mail</param>
        //TODO : Externaliser le mail et le password ds un fichier de params
        public void Notifier(String destinataire, String objet, String contenu)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("aga.sqli@gmail.com");
            mail.To.Add(destinataire);
            mail.Subject = objet;
            mail.Body = contenu;

            smtpServer.Port = 587;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new System.Net.NetworkCredential("aga.sqli@gmail.com", "oscare*1");

            try
            {
                smtpServer.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion
    }
}
