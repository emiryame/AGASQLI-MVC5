using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.Common.DTO.Models
{
    /// <summary>
    /// Représente le statut d'une demande : Son état d'avancement (persistant dans la BD)
    /// </summary>
    [DataContract]
    public class Statut
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Statut()
        {
            MailTemplate = new MailTemplate();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Label { get; set; }
        [DataMember]
        public virtual MailTemplate MailTemplate { get; set; }
    }
}
