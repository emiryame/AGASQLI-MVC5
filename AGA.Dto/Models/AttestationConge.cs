using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.DTO.Models
{
    /// <summary>
    /// Représente une attestation de congé (persistant dans la BD)
    /// </summary>
    [DataContract]
    public class AttestationConge
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DateDebut { get; set; }
        [DataMember]
        public string DateFin { get; set; }
        [DataMember]
        public virtual Demande Demande { get; set; }
    }
}
