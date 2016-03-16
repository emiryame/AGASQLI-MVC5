
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/16/2016 17:46:50
-- Generated from EDMX file: C:\Users\Miryame\documents\visual studio 2015\Projects\AGASQLI\AGASQLI.Data\DataBase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AGASQLI1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DemandeStatut]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DemandeSet] DROP CONSTRAINT [FK_DemandeStatut];
GO
IF OBJECT_ID(N'[dbo].[FK_DemandeTypeAttestation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DemandeSet] DROP CONSTRAINT [FK_DemandeTypeAttestation];
GO
IF OBJECT_ID(N'[dbo].[FK_DemandeCollaborateur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DemandeSet] DROP CONSTRAINT [FK_DemandeCollaborateur];
GO
IF OBJECT_ID(N'[dbo].[FK_DemandeAssistante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DemandeSet] DROP CONSTRAINT [FK_DemandeAssistante];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DemandeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DemandeSet];
GO
IF OBJECT_ID(N'[dbo].[StatutSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatutSet];
GO
IF OBJECT_ID(N'[dbo].[TypeAttestationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeAttestationSet];
GO
IF OBJECT_ID(N'[dbo].[CollaborateurSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollaborateurSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DemandeSet'
CREATE TABLE [dbo].[DemandeSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [dateCreation] datetime  NOT NULL,
    [dateDebutTraitement] datetime  NULL,
    [dateFinTraitement] datetime  NULL,
    [Statut_id] int  NOT NULL,
    [TypeAttestation_id] int  NOT NULL,
    [Collaborateur_id] int  NOT NULL,
    [Assistante_id] int  NULL
);
GO

-- Creating table 'StatutSet'
CREATE TABLE [dbo].[StatutSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [label] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TypeAttestationSet'
CREATE TABLE [dbo].[TypeAttestationSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [label] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CollaborateurSet'
CREATE TABLE [dbo].[CollaborateurSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nom] nvarchar(max)  NOT NULL,
    [prenom] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [cin] nvarchar(max)  NULL,
    [cnss] nvarchar(max)  NULL,
    [banque] nvarchar(max)  NULL,
    [estEligible] bit  NOT NULL,
    [poste] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [PK_DemandeSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'StatutSet'
ALTER TABLE [dbo].[StatutSet]
ADD CONSTRAINT [PK_StatutSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TypeAttestationSet'
ALTER TABLE [dbo].[TypeAttestationSet]
ADD CONSTRAINT [PK_TypeAttestationSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CollaborateurSet'
ALTER TABLE [dbo].[CollaborateurSet]
ADD CONSTRAINT [PK_CollaborateurSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Statut_id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [FK_DemandeStatut]
    FOREIGN KEY ([Statut_id])
    REFERENCES [dbo].[StatutSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DemandeStatut'
CREATE INDEX [IX_FK_DemandeStatut]
ON [dbo].[DemandeSet]
    ([Statut_id]);
GO

-- Creating foreign key on [TypeAttestation_id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [FK_DemandeTypeAttestation]
    FOREIGN KEY ([TypeAttestation_id])
    REFERENCES [dbo].[TypeAttestationSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DemandeTypeAttestation'
CREATE INDEX [IX_FK_DemandeTypeAttestation]
ON [dbo].[DemandeSet]
    ([TypeAttestation_id]);
GO

-- Creating foreign key on [Collaborateur_id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [FK_DemandeCollaborateur]
    FOREIGN KEY ([Collaborateur_id])
    REFERENCES [dbo].[CollaborateurSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DemandeCollaborateur'
CREATE INDEX [IX_FK_DemandeCollaborateur]
ON [dbo].[DemandeSet]
    ([Collaborateur_id]);
GO

-- Creating foreign key on [Assistante_id] in table 'DemandeSet'
ALTER TABLE [dbo].[DemandeSet]
ADD CONSTRAINT [FK_DemandeAssistante]
    FOREIGN KEY ([Assistante_id])
    REFERENCES [dbo].[CollaborateurSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DemandeAssistante'
CREATE INDEX [IX_FK_DemandeAssistante]
ON [dbo].[DemandeSet]
    ([Assistante_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------