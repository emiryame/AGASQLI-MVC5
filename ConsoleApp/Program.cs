using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;
using System.IO;
using AGA.Business;
using AGA.Data;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var context = new AGA.Data.AGADataBaseContainer();
            //List<AGA.Data.Demande> demandesList = new List<AGA.Data.Demande>();
            //demandesList = context.DemandeSet.Where(d => d.Statut.Code == "EnAttente").ToList();

            //TraiterDemande demandeService = new TraiterDemande();
            //demandeService.GetDemandesEnAttenteList();

            //String str = "Votre %typeAttestation% est prête !";
            //str=str.Replace("%typeAttestation%", "Attestation salaire");
            //str = str.Replace("%ttt%", "du n importe quoi");
            //Console.WriteLine(str);
            //Console.ReadLine();

            //new AGA.Business.Notification().Notifier("melhammouti@sqli.com", "Test", "BodyMail test..");
            //var cnt = new AGADataBaseContainer();
            //TypeAttestation att = cnt.TypeAttestationSet.FirstOrDefault(i => i.Id == 1);
            //File.WriteAllBytes(@"C:\Users\Miryame\Documents\doc.docx", att.Template);

            //byte[] buffer = System.IO.File.ReadAllBytes(@"C:\Users\Miryame\Documents\Visual Studio 2015\Projects\AGASQLI\AGA.Business\Templates\ReponseLettreDemission.docx");
            //TypeAttestation att = new TypeAttestation();
            //att.Label = "Reponse Lettre Demission";
            //att.Template = buffer;
            //var cnt = new AGADataBaseContainer();
            //cnt.TypeAttestationSet.Add(att);
            //cnt.SaveChanges();

            //Dictionary<String, String> dicoTokens = new Dictionary<string, string>();
            //dicoTokens.Add("%Nom%", "Elhammouti");
            //dicoTokens.Add("%Prenom%", "Meryem");
            //dicoTokens.Add("%Adresse%", "A82");

            //DocX template = DocX.Load(@"C:\Users\Miryame\Documents\doc.docx");
            //Console.WriteLine(new TraiterAttestation().Generer(dicoTokens,template));
            //Console.ReadLine();
        }
    }
}
