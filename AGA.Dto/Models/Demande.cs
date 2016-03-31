using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.DTO.Models
{
    /// <summary>
    /// Représente une demande d'attestation faite par un collaborateur (persistant dans la BD)
    /// </summary>
    [DataContract]
    public class Demande
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public System.DateTime DateCreation { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateDebutTraitement { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateFinTraitement { get; set; }
        [DataMember]
        public virtual TypeAttestation TypeAttestation { get; set; }
        [DataMember]
        public virtual Collaborateur Collaborateur { get; set; }
        [DataMember]
        public virtual Statut Statut { get; set; }
        [DataMember]
        public virtual Collaborateur Assistante { get; set; }
    }
}
