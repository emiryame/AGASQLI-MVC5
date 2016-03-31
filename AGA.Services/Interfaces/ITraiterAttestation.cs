using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;
using AGA.Common.Entities;
using Novacode;
using Microsoft.AspNet.Http;
using System.ServiceModel;
using System.IO;

namespace AGA.Services.Interfaces
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
        /// <returns>Le fichier de l'attestation de congé</returns>
        [OperationContract]
        MemoryStream GenererAttestationConge(AttestationConge attestationConge);

        /// <summary>
        /// Génére une attestation de irrévocable de salaire (fichier .docx) 
        /// </summary>
        /// <param name="attestationIrrevocableSalaire">une attestation irrévocable de salaire</param>
        /// <returns>Le fichier de l'attestation irrévocable de salaire</returns>
        [OperationContract]
        MemoryStream GenererAttestationIrrevocableSalaire(AttestationIrrevocableSalaire attestationIrrevocableSalaire);

        /// <summary>
        /// Génére une attestation de salaire (fichier .docx)
        /// </summary>
        /// <param name="attestationSalaire">une attestation de salaire</param>
        /// <returns>Le fichier de l'attestation de salaire</returns>
        [OperationContract]
        MemoryStream GenererAttestationSalaire(AttestationSalaire attestationSalaire);

        /// <summary>
        /// Génére une attestation de stage (fichier .docx) 
        /// </summary>
        /// <param name="attestationStage">une attestation de stage</param>
        /// <returns>Le fichier de l'attestation de stage</returns>
        [OperationContract]
        MemoryStream GenererAttestationStage(AttestationStage attestationStage);

        /// <summary>
        /// Génére une attestation de travail (fichier .docx)
        /// </summary>
        /// <param name="attestationTravail">une attestation de travail</param>
        /// <returns>Le fichier de l'attestation de salaire</returns>
        [OperationContract]
        MemoryStream GenererAttestationTravail(AttestationTravail attestationTravail);

        /// <summary>
        /// Génére une autorisation de cours de vacation (fichier .docx)
        /// </summary>
        /// <param name="autorisationCoursVacation">une autorisation de cours de vacation</param>
        /// <returns>Le fichier de l'autorisation de cours de vacation</returns>
        [OperationContract]
        MemoryStream GenererAutorisationCoursVacation(AutorisationCoursVacation autorisationCoursVacation);

        /// <summary>
        /// Génére une autorisation de poursuite d'études (fichier .docx)
        /// </summary>
        /// <param name="autorisationPoursuiteEtudes">une autorisation de poursuite d'études</param>
        /// <returns>Le fichier de l'autorisation de poursuite d'études</returns>
        [OperationContract]
        MemoryStream GenrerAutorisationPoursuiteEtudes(AutorisationPoursuiteEtudes autorisationPoursuiteEtudes);


        /// <summary>
        /// Génére une "réponse à la lettre de démission"  (fichier docx)
        /// </summary>
        /// <param name="reponseLettreDemission">La réponse de la lettre de démission</param>
        /// <returns>le fichier "réponse à la lettre de démission"</returns>
        [OperationContract]
        MemoryStream GenererReponseLettreDemission(ReponseLettreDemission reponseLettreDemission);

        /// <summary>
        /// Telecharge un document .doc
        /// </summary>
        /// <param name="Response">la reponse http</param>
        /// <param name="document">le document à télécharger</param>
        [OperationContract]
        void Telecharger(HttpResponse Response, MemoryStream documentStream);
    }
}
