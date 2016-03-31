using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGA.Common.DTO.Models;

namespace AGASQLI.ViewModels
{
    public class DemandeViewModel
    {
        public DemandeViewModel()
        {
            Demande = new Demande();
            IsChecked = false;
        }
        public DemandeViewModel(Demande demande)
        {
            if (demande != null)
            {
                Demande = demande;
                IsChecked = false;
            }
        }
        public Demande Demande { get; set; }
        public bool IsChecked { get; set; }
    }
}