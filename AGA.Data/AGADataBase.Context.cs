﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGA.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AGADataBaseContainer : DbContext
    {
        public AGADataBaseContainer()
            : base("name=AGADataBaseContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Demande> DemandeSet { get; set; }
        public virtual DbSet<TypeAttestation> TypeAttestationSet { get; set; }
        public virtual DbSet<Statut> StatutSet { get; set; }
        public virtual DbSet<Collaborateur> CollaborateurSet { get; set; }
        public virtual DbSet<AttestationConge> AttestationCongeSet { get; set; }
        public virtual DbSet<MailTemplate> MailTemplateSet { get; set; }
        public virtual DbSet<AutorisationPoursuiteEtudes> AutorisationPoursuiteEtudesSet { get; set; }
        public virtual DbSet<AutorisationCoursVacation> AutorisationCoursVacationSet { get; set; }
        public virtual DbSet<Civilite> CiviliteSet { get; set; }
        public virtual DbSet<Stagiaire> StagiaireSet { get; set; }
    }
}