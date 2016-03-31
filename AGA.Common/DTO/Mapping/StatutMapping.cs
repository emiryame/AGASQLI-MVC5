using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;

namespace AGA.Common.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets statut "Data" et "DTO"
    /// </summary>
    public static class StatutMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet statut data en un objet statut DTO
        /// </summary>
        /// <param name="statut">statut Data</param>
        /// <returns>statut DTO</returns>
        public static Statut EntityToDto(DAL.Statut statut)
        {
            Statut statutDto = new Statut();

            if (statut!=null)
            {
                statutDto.Id = statut.Id;
                statutDto.Label = statut.Label;
                statutDto.Code = statut.Code;
                statutDto.MailTemplate = MailTemplateMapping.EntityToDto(statut.MailTemplate);
            }

            return statutDto;
        }

        /// <summary>
        /// Permet la convertion d'un objet statut DTO en un objet statut Data
        /// </summary>
        /// <param name="statut">statut DTO</param>
        /// <returns>statut Data</returns>
        public static DAL.Statut DtoToEntity(Statut statut)
        {
            DAL.Statut statutData = new DAL.Statut();

            if (statut != null)
            {
                statutData.Id = statut.Id;
                statutData.Label = statut.Label;
                statutData.Code = statut.Code;
                statutData.MailTemplate = MailTemplateMapping.DtoToEntity(statut.MailTemplate);
            }

            return statutData;
        }
    }
}
