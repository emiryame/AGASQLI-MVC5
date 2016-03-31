using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.Common.DTO.Models
{
    /// <summary>
    /// Représente une atemplate de mail à envoyer lors des notifications (persistant dans la BD)
    /// </summary>
    [DataContract]
    public class MailTemplate
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Objet { get; set; }
        [DataMember]
        public string Contenu { get; set; }
    }
}
