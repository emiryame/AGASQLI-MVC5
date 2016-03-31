
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/26/2016 21:40:39
-- Generated from EDMX file: C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI.mvc5\AGA.Data\AGADataBase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AGASQLIDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DemandeTypeAttestation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DemandeSet] DROP CONSTRAINT [FK_DemandeTypeAttestation];
GO
IF OBJECT_ID(N'[dbo].[FK_AttestationCongeDemande]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AttestationCongeSet] DROP CONSTRAINT [FK_AttestationCongeDemande];
GO
IF OBJECT_ID(N'[dbo].[FK_CollaborateurDemande]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DemandeSet] DROP CONSTRAINT [FK_CollaborateurDemande];
GO
IF OBJECT_ID(N'[dbo].[FK_DemandeStatut]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DemandeSet] DROP CONSTRAINT [FK_DemandeStatut];
GO
IF OBJECT_ID(N'[dbo].[FK_CollaborateurAssistante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DemandeSet] DROP CONSTRAINT [FK_CollaborateurAssistante];
GO
IF OBJECT_ID(N'[dbo].[FK_AutorisationCoursVacationDemande]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutorisationCoursVacationSet] DROP CONSTRAINT [FK_AutorisationCoursVacationDemande];
GO
IF OBJECT_ID(N'[dbo].[FK_DemandeAutorisationPoursuiteEtudes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutorisationPoursuiteEtudesSet] DROP CONSTRAINT [FK_DemandeAutorisationPoursuiteEtudes];
GO
IF OBJECT_ID(N'[dbo].[FK_CollaborateurCivilite]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollaborateurSet] DROP CONSTRAINT [FK_CollaborateurCivilite];
GO
IF OBJECT_ID(N'[dbo].[FK_StatutMailTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StatutSet] DROP CONSTRAINT [FK_StatutMailTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_StagiaireCivilite]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StagiaireSet] DROP CONSTRAINT [FK_StagiaireCivilite];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DemandeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DemandeSet];
GO
IF OBJECT_ID(N'[dbo].[TypeAttestationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeAttestationSet];
GO
IF OBJECT_ID(N'[dbo].[StatutSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatutSet];
GO
IF OBJECT_ID(N'[dbo].[CollaborateurSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollaborateurSet];
GO
IF OBJECT_ID(N'[dbo].[AttestationCongeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AttestationCongeSet];
GO
IF OBJECT_ID(N'[dbo].[MailTemplateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailTemplateSet];
GO
IF OBJECT_ID(N'[dbo].[AutorisationPoursuiteEtudesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutorisationPoursuiteEtudesSet];
GO
IF OBJECT_ID(N'[dbo].[AutorisationCoursVacationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutorisationCoursVacationSet];
GO
IF OBJECT_ID(N'[dbo].[CiviliteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CiviliteSet];
GO
IF OBJECT_ID(N'[dbo].[StagiaireSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StagiaireSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DemandeSet'
CREATE TABLE [dbo].[DemandeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateCreation] datetime  NOT NULL,
    [DateDebutTraitement] datetime  NULL,
    [DateFinTraitement] datetime  NULL,
    [TypeAttestation_Id] int  NOT NULL,
    [Collaborateur_Id] int  NOT NULL,
    [Statut_Id] int  NOT NULL,
    [Assistante_Id] int  NULL
);
GO

-- Creating table 'TypeAttestationSet'
CREATE TABLE [dbo].[TypeAttestationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Label] nvarchar(max)  NOT NULL,
    [Template] varbinary(max)  NULL
);
GO

-- Creating table 'StatutSet'
CREATE TABLE [dbo].[StatutSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Label] nvarchar(max)  NOT NULL,
    [MailTemplate_Id] int  NOT NULL
);
GO

-- Creating table 'CollaborateurSet'
CREATE TABLE [dbo].[CollaborateurSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Prenom] nvarchar(max)  NOT NULL,
    [Cin] nvarchar(max)  NULL,
    [Cnss] nvarchar(max)  NULL,
    [Poste] nvarchar(max)  NULL,
    [DateDebutTravail] datetime  NULL,
    [Banque] nvarchar(max)  NULL,
    [IsEligible] bit  NOT NULL,
    [Adresse] nvarchar(max)  NULL,
    [Civilite_Id] int  NOT NULL
);
GO

-- Creating table 'AttestationCongeSet'
CREATE TABLE [dbo].[AttestationCongeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateDebut] nvarchar(max)  NOT NULL,
    [DateFin] nvarchar(max)  NOT NULL,
    [Demande_Id] int  NOT NULL
);
GO

-- Creating table 'MailTemplateSet'
CREATE TABLE [dbo].[MailTemplateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Objet] nvarchar(max)  NOT NULL,
    [Contenu] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AutorisationPoursuiteEtudesSet'
CREATE TABLE [dbo].[AutorisationPoursuiteEtudesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Etablissement] nvarchar(max)  NOT NULL,
    [AnneeScolaire] nvarchar(max)  NOT NULL,
    [Demande_Id] int  NOT NULL
);
GO

-- Creating table 'AutorisationCoursVacationSet'
CREATE TABLE [dbo].[AutorisationCoursVacationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Etablissement] nvarchar(max)  NOT NULL,
    [AnneeScolaire] nvarchar(max)  NOT NULL,
    [Demande_Id] int  NOT NULL
);
GO

-- Creating table 'CiviliteSet'
CREATE TABLE [dbo].[CiviliteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Label] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StagiaireSet'
CREATE TABLE [dbo].[StagiaireSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Prenom] nvarchar(max)  NOT NULL,
    [Adresse] nvarchar(max)  NULL,
    [Cin] nvarchar(max)  NULL,
    [DateDebut] datetime  NULL,
    [DateFin] datetime  NULL,
    [Civilite_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [PK_DemandeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeAttestationSet'
ALTER TABLE [dbo].[TypeAttestationSet]
ADD CONSTRAINT [PK_TypeAttestationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatutSet'
ALTER TABLE [dbo].[StatutSet]
ADD CONSTRAINT [PK_StatutSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CollaborateurSet'
ALTER TABLE [dbo].[CollaborateurSet]
ADD CONSTRAINT [PK_CollaborateurSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AttestationCongeSet'
ALTER TABLE [dbo].[AttestationCongeSet]
ADD CONSTRAINT [PK_AttestationCongeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailTemplateSet'
ALTER TABLE [dbo].[MailTemplateSet]
ADD CONSTRAINT [PK_MailTemplateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AutorisationPoursuiteEtudesSet'
ALTER TABLE [dbo].[AutorisationPoursuiteEtudesSet]
ADD CONSTRAINT [PK_AutorisationPoursuiteEtudesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AutorisationCoursVacationSet'
ALTER TABLE [dbo].[AutorisationCoursVacationSet]
ADD CONSTRAINT [PK_AutorisationCoursVacationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CiviliteSet'
ALTER TABLE [dbo].[CiviliteSet]
ADD CONSTRAINT [PK_CiviliteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StagiaireSet'
ALTER TABLE [dbo].[StagiaireSet]
ADD CONSTRAINT [PK_StagiaireSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TypeAttestation_Id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [FK_DemandeTypeAttestation]
    FOREIGN KEY ([TypeAttestation_Id])
    REFERENCES [dbo].[TypeAttestationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DemandeTypeAttestation'
CREATE INDEX [IX_FK_DemandeTypeAttestation]
ON [dbo].[DemandeSet]
    ([TypeAttestation_Id]);
GO

-- Creating foreign key on [Demande_Id] in table 'AttestationCongeSet'
ALTER TABLE [dbo].[AttestationCongeSet]
ADD CONSTRAINT [FK_AttestationCongeDemande]
    FOREIGN KEY ([Demande_Id])
    REFERENCES [dbo].[DemandeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AttestationCongeDemande'
CREATE INDEX [IX_FK_AttestationCongeDemande]
ON [dbo].[AttestationCongeSet]
    ([Demande_Id]);
GO

-- Creating foreign key on [Collaborateur_Id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [FK_CollaborateurDemande]
    FOREIGN KEY ([Collaborateur_Id])
    REFERENCES [dbo].[CollaborateurSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CollaborateurDemande'
CREATE INDEX [IX_FK_CollaborateurDemande]
ON [dbo].[DemandeSet]
    ([Collaborateur_Id]);
GO

-- Creating foreign key on [Statut_Id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [FK_DemandeStatut]
    FOREIGN KEY ([Statut_Id])
    REFERENCES [dbo].[StatutSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DemandeStatut'
CREATE INDEX [IX_FK_DemandeStatut]
ON [dbo].[DemandeSet]
    ([Statut_Id]);
GO

-- Creating foreign key on [Assistante_Id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [FK_CollaborateurAssistante]
    FOREIGN KEY ([Assistante_Id])
    REFERENCES [dbo].[CollaborateurSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CollaborateurAssistante'
CREATE INDEX [IX_FK_CollaborateurAssistante]
ON [dbo].[DemandeSet]
    ([Assistante_Id]);
GO

-- Creating foreign key on [Demande_Id] in table 'AutorisationCoursVacationSet'
ALTER TABLE [dbo].[AutorisationCoursVacationSet]
ADD CONSTRAINT [FK_AutorisationCoursVacationDemande]
    FOREIGN KEY ([Demande_Id])
    REFERENCES [dbo].[DemandeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutorisationCoursVacationDemande'
CREATE INDEX [IX_FK_AutorisationCoursVacationDemande]
ON [dbo].[AutorisationCoursVacationSet]
    ([Demande_Id]);
GO

-- Creating foreign key on [Demande_Id] in table 'AutorisationPoursuiteEtudesSet'
ALTER TABLE [dbo].[AutorisationPoursuiteEtudesSet]
ADD CONSTRAINT [FK_DemandeAutorisationPoursuiteEtudes]
    FOREIGN KEY ([Demande_Id])
    REFERENCES [dbo].[DemandeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DemandeAutorisationPoursuiteEtudes'
CREATE INDEX [IX_FK_DemandeAutorisationPoursuiteEtudes]
ON [dbo].[AutorisationPoursuiteEtudesSet]
    ([Demande_Id]);
GO

-- Creating foreign key on [Civilite_Id] in table 'CollaborateurSet'
ALTER TABLE [dbo].[CollaborateurSet]
ADD CONSTRAINT [FK_CollaborateurCivilite]
    FOREIGN KEY ([Civilite_Id])
    REFERENCES [dbo].[CiviliteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CollaborateurCivilite'
CREATE INDEX [IX_FK_CollaborateurCivilite]
ON [dbo].[CollaborateurSet]
    ([Civilite_Id]);
GO

-- Creating foreign key on [MailTemplate_Id] in table 'StatutSet'
ALTER TABLE [dbo].[StatutSet]
ADD CONSTRAINT [FK_StatutMailTemplate]
    FOREIGN KEY ([MailTemplate_Id])
    REFERENCES [dbo].[MailTemplateSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StatutMailTemplate'
CREATE INDEX [IX_FK_StatutMailTemplate]
ON [dbo].[StatutSet]
    ([MailTemplate_Id]);
GO

-- Creating foreign key on [Civilite_Id] in table 'StagiaireSet'
ALTER TABLE [dbo].[StagiaireSet]
ADD CONSTRAINT [FK_StagiaireCivilite]
    FOREIGN KEY ([Civilite_Id])
    REFERENCES [dbo].[CiviliteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StagiaireCivilite'
CREATE INDEX [IX_FK_StagiaireCivilite]
ON [dbo].[StagiaireSet]
    ([Civilite_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------