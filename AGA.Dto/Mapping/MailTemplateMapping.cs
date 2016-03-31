using AGA.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGA.DTO.Mapping
{
    /// <summary>
    /// Classe pour le mapping entre les objets mailtemplate "Data" et "DTO"
    /// </summary>
    public static class MailTemplateMapping
    {
        /// <summary>
        /// Permet la convertion d'un objet mailTemplate data en un objet mailTemplate DTO
        /// </summary>
        /// <param name="mailTemplate">mailTemplate Data</param>
        /// <returns>mailTemplate DTO</returns>
        public static MailTemplate EntityToDto(Data.MailTemplate mailTemplate)
        {
            MailTemplate mailTemplateDto = new MailTemplate();

            if (mailTemplate!=null)
            {
                mailTemplateDto.Code = mailTemplate.Code;
                mailTemplateDto.Contenu = mailTemplate.Contenu;
                mailTemplateDto.Id = mailTemplate.Id;
                mailTemplateDto.Objet = mailTemplate.Objet;
            }

            return mailTemplateDto;
        }

        /// <summary>
        /// Permet la convertion d'un objet mailTemplate DTO en un objet mailTemplate Data
        /// </summary>
        /// <param name="mailTemplate">mailTemplate Data</param>
        /// <returns>mailTemplate DTO</returns>
        public static Data.MailTemplate DtoToEntity(MailTemplate mailTemplate)
        {
            Data.MailTemplate mailTemplateData = new Data.MailTemplate();

            if (mailTemplate != null)
            {
                mailTemplateData.Code = mailTemplate.Code;
                mailTemplateData.Contenu = mailTemplate.Contenu;
                mailTemplateData.Id = mailTemplate.Id;
                mailTemplateData.Objet = mailTemplate.Objet;
            }

            return mailTemplateData;
        }
    }
}
