using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.Common.Entities
{
    /// <summary>
    /// Représente une réponse à la lettre de demission (non persistant dans la BD)
    /// </summary>
    [DataContract]
    public class ReponseLettreDemission : Attestation
    {
        [DataMember]
        public DateTime DateFinContrat { get; set; }
        [DataMember]
        public DateTime DateReceptionDemande { get; set; }
        [DataMember]
        public String Reference { get; set; }
    }
}
