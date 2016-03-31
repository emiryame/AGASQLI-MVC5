using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.DTO.Models;
using AGA.Services.Entities;
using Novacode;
using Microsoft.AspNet.Http;
using System.ServiceModel;

namespace AGA.Services
{
    /// <summary>
    /// Interface permettant de générer, télécharger et imprimer les attestations
    /// </summary>
    [ServiceContract]
    public interface ITraiterAttestation
    {
        /// <summary>
        /// Génére une attestation de congé (fichier .docx) 
        /// </summary>
        /// <param name="attestationConge">une attestation de congé</param>
        /// <returns>Le fichier .docx de l'attestation de congé</returns>
        [OperationContract]
        DocX GenererAttestationConge(AttestationConge attestationConge);

        /// <summary>
        /// Génére une attestation de irrévocable de salaire (fichier .docx) 
        /// </summary>
        /// <param name="attestationIrrevocableSalaire">une attestation irrévocable de salaire</param>
        /// <returns>Le fichier .docx de l'attestation irrévocable de salaire</returns>
        [OperationContract]
        DocX GenererAttestationIrrevocableSalaire(AttestationIrrevocableSalaire attestationIrrevocableSalaire);

        /// <summary>
        /// Génére une attestation de salaire (fichier .docx)
        /// </summary>
        /// <param name="attestationSalaire">une attestation de salaire</param>
        /// <returns>Le fichier .docx de l'attestation de salaire</returns>
        [OperationContract]
        DocX GenererAttestationSalaire(AttestationSalaire attestationSalaire);

        /// <summary>
        /// Génére une attestation de stage (fichier .docx) 
        /// </summary>
        /// <param name="attestationStage">une attestation de stage</param>
        /// <returns>Le fichier .docx de l'attestation de stage</returns>
        [OperationContract]
        DocX GenererAttestationStage(AttestationStage attestationStage);

        /// <summary>
        /// Génére une attestation de travail (fichier .docx)
        /// </summary>
        /// <param name="attestationTravail">une attestation de travail</param>
        /// <returns>Le fichier .docx de l'attestation de salaire</returns>
        [OperationContract]
        DocX GenererAttestationTravail(AttestationTravail attestationTravail);

        /// <summary>
        /// Génére une autorisation de cours de vacation (fichier .docx)
        /// </summary>
        /// <param name="autorisationCoursVacation">une autorisation de cours de vacation</param>
        /// <returns>Le fichier .docx de l'autorisation de cours de vacation</returns>
        [OperationContract]
        DocX GenererAutorisationCoursVacation(AutorisationCoursVacation autorisationCoursVacation);

        /// <summary>
        /// Génére une autorisation de poursuite d'études (fichier .docx)
        /// </summary>
        /// <param name="autorisationPoursuiteEtudes">une autorisation de poursuite d'études</param>
        /// <returns>Le fichier .docx de l'autorisation de poursuite d'études</returns>
        [OperationContract]
        DocX GenrerAutorisationPoursuiteEtudes(AutorisationPoursuiteEtudes autorisationPoursuiteEtudes);


        /// <summary>
        /// Génére une "réponse à la lettre de démission" en fichier docx
        /// </summary>
        /// <param name="reponseLettreDemission">La réponse de la lettre de démission</param>
        /// <returns>le fichier docx "réponse à la lettre de démission"</returns>
        [OperationContract]
        DocX GenererReponseLettreDemission(ReponseLettreDemission reponseLettreDemission);

        /// <summary>
        /// Telecharge un document .doc
        /// </summary>
        /// <param name="Response">la reponse http</param>
        /// <param name="document">le document à télécharger</param>
        [OperationContract]
        void Telecharger(HttpResponse Response, DocX document);
    }
}
