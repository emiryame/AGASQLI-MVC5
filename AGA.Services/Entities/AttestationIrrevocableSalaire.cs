using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.Services.Entities
{
    /// <summary>
    /// Représente une attestation irrévocable de salaire (non persistant dans la BD)
    /// </summary>
    [DataContract]
    public class AttestationIrrevocableSalaire : Attestation
    {
        [DataMember]
        public DateTime DateRemiseMainLibre { get; set; }
        [DataMember]
        public String NumeroCompte { get; set; }
    }
}
