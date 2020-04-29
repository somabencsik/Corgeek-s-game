using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable
{
    public class Kurzus
    {
        private string nap;     
        private int kezdo_ora;
        private int vege_ora;
        private string ora_neve;

        //variációk generálásához kell
        private int[] id = new int[2];

        private string egeszSor;

        public Kurzus(string egesz_sor) {
            egeszSor = egesz_sor;
            Sor_szetszedese(egeszSor);
        }

        public string IdToString()
        {
            return "(" + id[0].ToString() + "," + id[1].ToString() + ")";
        }
        public int getRowId() {
            return id[0];
        }
        public int getColoumnId()
        {
            return id[1];
        }
           

        



        public void SetId(int a, int b)
        {
            id[0] = a;
            id[1] = b;
        }

        private void Sor_szetszedese(string sor) {
            //nap
            //keressük meg az első kettőspontot
            int kettospont_idx = sor.IndexOf(':');
            Nap = sor.Substring(0, kettospont_idx);     

            //kezdő óra
            Kezdo_ora = Int32.Parse(sor.Substring(kettospont_idx + 1, 2));

            //vége óra
            int kotojel_idx = sor.IndexOf('-');
            Vege_ora = Int32.Parse(sor.Substring(kotojel_idx + 1, 2));

            
        }

        public string EgeszSor
        {
            get { return egeszSor; }
            set { egeszSor = value; }
        }

        public string Nap { get => nap; set => nap = value; }
        public int Kezdo_ora { get => kezdo_ora; set => kezdo_ora = value; }
        public int Vege_ora { get => vege_ora; set => vege_ora = value; }
        public string EgeszSor1 { get => egeszSor; set => egeszSor = value; }
        public string Ora_neve { get => ora_neve; set => ora_neve = value; }

        public override string ToString()
        {
            return "Nap: " + Nap + " Kezdo ora: " + Kezdo_ora + " Vege ora: " + Vege_ora;
        }
    }
}
