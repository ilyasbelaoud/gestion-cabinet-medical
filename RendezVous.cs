using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCabinetMedical
{
    [Serializable]

    public class RendezVous
    {
        private int codePatient;
        private DateTime dateRendezVous;
        private string heureRendezVous;
        private string observation;
        public RendezVous() { }

        public RendezVous(int codePatient, DateTime dateRendezVous, string heureRendezVous,string observation)
        {
            this.codePatient = codePatient;
            this.dateRendezVous = dateRendezVous;
            this.heureRendezVous = heureRendezVous;
            this.observation = observation;
        }

        public int CodePatient { get => codePatient; set => codePatient = value; }
        public DateTime DateRendezVous { get => dateRendezVous; set => dateRendezVous = value; }
        public string HeureRendezVous { get => heureRendezVous; set => heureRendezVous = value; }
        public string Observation { get => observation; set => observation = value; }

        public override string ToString()
        {
            return "Code Patient: " + this.codePatient + "\t   Date Rendez-Vous: " + this.dateRendezVous.ToShortDateString() + "\t   Heure Rendez-Vous: "+this.heureRendezVous+ "\tObservation: "+this.observation ;
        }
    }
}
