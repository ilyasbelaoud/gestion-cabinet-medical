using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCabinetMedical
{
    [Serializable]
    public class Patient
    {
        private int codePatient;
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private string sexe;
        private string adresse;
        private string tel;
        private string email;
        private RendezVous rendezVous;

        public Patient() { }

        public Patient(int codePatient, string nom, string prenom, DateTime dateNaissance, string sexe, string adresse, string tel, string email)
        {
            this.codePatient = codePatient;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance.Date;
            this.sexe = sexe;
            this.adresse = adresse;
            this.tel = tel;
            this.email = email;
            this.rendezVous = null;
        }

        public int CodePatient { get => codePatient; set => codePatient = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Email { get => email; set => email = value; }
        public RendezVous RendezVous { get => rendezVous; set => rendezVous = value; }

        public override bool Equals(object obj)
        {
            Patient p = (Patient)obj;
            if ((this.Nom.ToLower()==p.Nom.ToLower()) && (this.Prenom.ToLower()==p.Prenom.ToLower())) return true;
            return false;
        }
        public override string ToString()
        {
            return $"Code Patient: {this.codePatient}; Full Name: {this.nom} {this.prenom}; Birthday: {this.dateNaissance.ToShortDateString()}; Gender: {this.sexe}; Address: {this.adresse}; Phone Number: {this.tel}; E-mail: {this.email}";
        }
    }
}
