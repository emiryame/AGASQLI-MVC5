﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGA.Common.Entities
{
    /// <summary>
    /// Représente une attestation de travail (non persistant dans la BD)
    /// </summary>
    [DataContract]
    public class AttestationTravail : Attestation
    {
    }
}
