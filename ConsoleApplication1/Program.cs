using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGA.Common.DTO.Mapping;
using AGA.Common.DTO.Models;
using AGA.Business.Implementations;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AGA.DAL.AGADataBaseContainer();
            AGA.DAL.Demande demandeData = context.DemandeSet.FirstOrDefault(d => d.Id == 1);
            Demande demande=DemandeMapping.EntityToDto(demandeData);

            Notification service = new Notification();
            service.NotifierCollaborateur(demande);
            // service.Notifier("emiyame@gmail.com", "test", "AlTessst");
        }
    }
}
