﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Models;
using System.Runtime.Serialization;

namespace AGA.Common.Entities
{
    /// <summary>
    /// Représente une attestation quelconque : Ce que partage toutes les attestations et autorisations
    /// </summary>
    [DataContract]
    public class Attestation
    {
        [DataMember]
        public Collaborateur Collaborateur { get; set; }
    }
}
