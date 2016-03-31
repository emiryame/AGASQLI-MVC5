using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.DTO.Models
{
    /// <summary>
    /// Représente un collaborateur (persistant dans la BD)
    /// </summary>
    [DataContract]
    public class Collaborateur
    {
        public Collaborateur()
        {
            Civilite = new Civilite();
            IsEligible = true;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Prenom { get; set; }
        [DataMember]
        public string Cin { get; set; }
        [DataMember]
        public string Cnss { get; set; }
        [DataMember]
        public string Poste { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateDebutTravail { get; set; }
        [DataMember]
        public string Banque { get; set; }
        [DataMember]
        public bool IsEligible { get; set; }
        [DataMember]
        public string Adresse { get; set; }
        [DataMember]
        public virtual Civilite Civilite { get; set; }

    }
}
