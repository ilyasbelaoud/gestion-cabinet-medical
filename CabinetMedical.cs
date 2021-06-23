using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace GestionCabinetMedical
{
    [Serializable]
    public class CabinetMedical
    {
        private List<Patient> listPatient = new List<Patient>();
        private List<RendezVous> listRendezVous = new List<RendezVous>();

        public List<Patient> ListPatient { get => listPatient; set => listPatient = value; }
        public List<RendezVous> ListRendezVous { get => listRendezVous; set => listRendezVous = value; }

        public CabinetMedical() { }

        public Patient TrouverPatient(int codePatient)
        {
            foreach (Patient p in this.ListPatient)
            {
                if (p.CodePatient == codePatient) return p;
            }
            return null;
        }

        public Patient TrouverPatient(string nomComplet)
        {
            foreach (Patient p in this.ListPatient)
            {
                if ((p.Nom+" "+p.Prenom).ToLower() == nomComplet.ToLower()) return p;
            }
            return null;
        }

        public void AjouterRDV(RendezVous r)
        {
            bool occupe = false;
            foreach (RendezVous rv in this.ListRendezVous)
            {
                if ((r.DateRendezVous.Date == rv.DateRendezVous.Date) && (r.HeureRendezVous == rv.HeureRendezVous)) occupe = true; 
            }
            if (occupe) throw new Exception("La date du rendez vous est occupe");
            else this.ListRendezVous.Add(r);
        }

        public RendezVous TrouverRendezVous(int codePatient)
        {
            foreach (RendezVous rv in this.ListRendezVous)
            {
                if (rv.CodePatient == codePatient) return rv;
            }
            return null;
        }
    }
}
