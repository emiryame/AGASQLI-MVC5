using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.DTO.Models
{
    /// <summary>
    /// Représente une autorisation de poursuite d'études (persistant dans la BD)
    /// </summary>
    [DataContract]
    public class AutorisationPoursuiteEtudes
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Etablissement { get; set; }
        [DataMember]
        public string AnneeScolaire { get; set; }
        [DataMember]
        public virtual Demande Demande { get; set; }
    }
}
