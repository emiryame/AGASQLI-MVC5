using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.DTO.Models
{
    /// <summary>
    /// Représente la civilité avec code et label (persistant dans la BD)
    /// </summary>
    [DataContract]
    public class Civilite
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Label { get; set; }
    }
}
