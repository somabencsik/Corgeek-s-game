using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable
{
    public class Targy
    {
        private string nev;
        public List<Kurzus> kurzus_lista = new List<Kurzus>();
        

        public Targy(string n) {
            nev = n;
        }

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        internal List<Kurzus> Kurzus_lista { get => kurzus_lista; set => kurzus_lista = value; }

        public void Kurzus_listahoz_adas(Kurzus kurzus) {
            Kurzus_lista.Add(kurzus);
            kurzus.Ora_neve = Nev;
        }


        //szerintem ez nem fog kelleni de azért meghagyom
        /*public string Kurzus_lista_kiirasa() {
            string returned="";
            foreach (Kurzus k in kurzus_lista) {
                returned += k.EgeszSor + "\n";
            }
            return returned;
        }*/

        public override string ToString()
        {
            string x = "Targy neve: " + nev;
            foreach (Kurzus k in Kurzus_lista)
            {
                x += k.ToString() + " ";
            }
            return x;
        }


        public int getKurzusSzam()
        {
            int i = 0;
            foreach (Kurzus k in kurzus_lista) {
                i++;
            }
            return i;
        }

      

    }
}
