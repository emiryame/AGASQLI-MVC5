using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.DTO.Models
{
    /// <summary>
    /// Représente un stagiaire (persistant dans la BD)
    /// </summary>
    [DataContract]
    public class Stagiaire
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Prenom { get; set; }
        [DataMember]
        public string Adresse { get; set; }
        [DataMember]
        public string Cin { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateDebut { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateFin { get; set; }
        [DataMember]
        public virtual Civilite Civilite { get; set; }
    }
}
