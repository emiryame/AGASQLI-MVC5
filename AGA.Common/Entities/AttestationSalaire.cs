using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.Common.Entities
{
    /// <summary>
    /// Représente une attestation de salaire (non persistant dans la BD)
    /// </summary>
    [DataContract]
    public class AttestationSalaire : Attestation
    {
        [DataMember]
        public Double Salaire { get; set; }
    }
}
