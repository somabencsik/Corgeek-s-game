using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTable
{
    public partial class MidFormTempTimeTable : Form
    {
        private List<Targy> kivalasztott_targy_objektumok = new List<Targy>();
        private Random rnd = new Random();
        private int variaciok_szama;
        private bool[] utkozesek;
        private int hanyadik_variaciot_nezzuk_eppen;

        private List<int> uj_lista = new List<int>() { };
        public int getUj_lista_count()
        {
            return uj_lista.Count();
        }



        private Kurzus[,] matrix;


        //konstruktor
        public MidFormTempTimeTable(List<Targy> targyobjektumok)
        {
            InitializeComponent();



            kivalasztott_targy_objektumok = targyobjektumok;


            variaciok_megszamolasa(kivalasztott_targy_objektumok);
            //MessageBox.Show("variációk: " + variaciok_szama.ToString()); 

            utkozesek = new bool[variaciok_szama];

            //Id generálás
            int sorId = 0;
            foreach (Targy t in kivalasztott_targy_objektumok)
            {
                int oszlopId = 0;
                foreach (Kurzus k in t.kurzus_lista)
                {
                    k.SetId(sorId, oszlopId);
                    //MessageBox.Show("id generated for " + k.EgeszSor + " " + k.getRowId() + " " + k.getColoumnId());
                    oszlopId++;
                }
                sorId++;
            }


            matrix = new Kurzus[variaciok_szama, kivalasztott_targy_objektumok.Count()];

            Matrix_generalasa();



            Vannak_e_utkozesek();

            /* if (uj_lista.Count == 0) {
                 MessageBox.Show("Sajnos ezeket a tárgyakat nem tudod ütközés nélkül felvenni");
                 Form1 f1 = new Form1();
                 f1.Show();
                 this.Close();
                 //Environment.Exit(0);        //nem mukodik, ezert be kell zarni
             }*/

        }



        public void variaciok_megszamolasa(List<Targy> targyak)
        {
            int n = 1;
            foreach (Targy t in targyak)
            {
                n *= t.getKurzusSzam();
            }
            variaciok_szama = n;
        }





        public void Vannak_e_utkozesek()
        {
            for (int i = 0; i < variaciok_szama; i++)
            {
                hanyadik_variaciot_nezzuk_eppen = i;
                Kurzus[] kurzus_sor = new Kurzus[kivalasztott_targy_objektumok.Count()];
                for (int j = 0; j < kivalasztott_targy_objektumok.Count(); j++)
                {
                    kurzus_sor[j] = matrix[i, j];
                }
                orarendgeneralas_utkozesek_megszamolasara(kurzus_sor);
                torles();
            }


            for (int i = 0; i < variaciok_szama; i++)
            {
                if (utkozesek[i] == false)
                {
                    uj_lista.Add(i);     //ezek a sorai a mátrixnak amik nem ütköznek

                }
            }
            hanyadik_variaciot_nezzuk_eppen = 0;
        }



        public void orarendgeneralas_utkozesek_megszamolasara(Kurzus[] kurzusok)
        {

            foreach (Kurzus k in kurzusok)
            {
                bool nev_kiirva = false;
                Color randomColor = Color.FromArgb(16, 20, 35);
                while (randomColor == Color.FromArgb(16, 20, 35))  //nehogy ugyanaz legyen mint a háttérszín mert az nem jó
                {
                    randomColor = Color.FromArgb(rnd.Next(180), rnd.Next(180), rnd.Next(180)); //ne legyenek túl világosak színek, mert nem olvasható a fehér betű
                }

                int tempValue = k.Kezdo_ora;
                String kezd = tempValue.ToString("00");
                int idotartam = k.Vege_ora - k.Kezdo_ora;
                string id = k.Nap + kezd;
                string temp_id = id;
                while (idotartam > 0)
                {
                    foreach (Control control in TimeTable.Controls)
                    {
                        if (control.Name == temp_id && idotartam > 0)
                        { 
                            if (control.Text != "")
                            {
                                utkozesek[hanyadik_variaciot_nezzuk_eppen] = true;
                                break;
                            }
                            else
                            {
                                control.ForeColor = randomColor;
                                control.Text = k.Ora_neve;
                                utkozesek[hanyadik_variaciot_nezzuk_eppen] = false;
                            }

                            if (nev_kiirva == false)
                            {
                                control.ForeColor = Color.White;
                                control.Text = k.Ora_neve;
                                nev_kiirva = true;
                            }
                            else
                            {
                                control.ForeColor = randomColor;
                                control.Text = k.Ora_neve;
                            }


                            control.BackColor = randomColor;


                            int szamok = Int32.Parse(temp_id.Substring(temp_id.Length - 2));

                            int szamok_temp = szamok + 1;
                            temp_id = temp_id.Replace(temp_id.Substring(temp_id.Length - 2), szamok_temp.ToString("00"));

                            idotartam -= 1;
                        }
                        if (utkozesek[hanyadik_variaciot_nezzuk_eppen] == true)
                        {
                            break;
                        }
                    }
                    if (utkozesek[hanyadik_variaciot_nezzuk_eppen] == true)
                    {
                        break;
                    }

                }
                if (utkozesek[hanyadik_variaciot_nezzuk_eppen] == true)
                {
                    break;
                }
            }
        }



        public void Matrix_generalasa()
        {
            int partition = 1;  //minden oszlophoz tartozik egy partíció érték
            for (int j = 0; j < kivalasztott_targy_objektumok.Count(); j++)
            {
                //ez egy oszlop
                partition *= kivalasztott_targy_objektumok[j].getKurzusSzam();  //ha 2 kurzus van, kettő részre oszlik az oszlop, ha 3 akkor 3 stb és ez szorzódik minden oszloppal

                int[][] egy_oszlop = new int[variaciok_szama][];
                for (int i = 0; i < variaciok_szama; i++)
                {
                    egy_oszlop[i] = new int[2];
                    egy_oszlop[i][0] = -99;
                    egy_oszlop[i][1] = -99;
                }
                egy_oszlop = Matrix_oszlop_generalas(kivalasztott_targy_objektumok[j], partition, j);
                for (int i = 0; i < variaciok_szama; i++)
                {
                    //itt megyünk lefelé a variációkon egy oszlopon belül
                    foreach (Targy t in kivalasztott_targy_objektumok)
                    {
                        foreach (Kurzus k in t.kurzus_lista)
                        {
                            if (k.getRowId() == egy_oszlop[i][0] && k.getColoumnId() == egy_oszlop[i][1])
                            {
                                matrix[i, j] = k;
                            }
                        }
                    }

                }
            }
        }


        public int[][] Matrix_oszlop_generalas(Targy t, int particio_szam, int oszlop_ahol_epp_tartunk)
        {
            int[][] oszlop_array = new int[variaciok_szama][];
            for (int i = 0; i < variaciok_szama; i++)
            {
                oszlop_array[i] = new int[2];
                oszlop_array[i][0] = oszlop_ahol_epp_tartunk;
                oszlop_array[i][1] = 666;
            }
            int kurzus_szam = t.getKurzusSzam();
            int egy_particio_hossza = variaciok_szama / particio_szam;
            int[] kurzusok_oszlopID_ja_tomb = new int[kurzus_szam]; //egy tömb 0-tól addig, amennyi kurzusa van a tárgynak
            for (int i = 0; i < kurzus_szam; i++)
            {
                kurzusok_oszlopID_ja_tomb[i] = i;
            }

            int j = 0;
            int idx = 0;

            while (idx < variaciok_szama)
            {
                int particioba_beirt_szamok_darabja = 0;

                while (particioba_beirt_szamok_darabja < egy_particio_hossza)
                {
                    oszlop_array[idx][1] = kurzusok_oszlopID_ja_tomb[j];
                    idx++;
                    particioba_beirt_szamok_darabja++;
                }
                particioba_beirt_szamok_darabja = 0;
                j++;
                if (j > kurzus_szam - 1)
                {
                    j = 0;
                }
            }
            return oszlop_array;
        }




        public void torles()
        {
            foreach (Control control in TimeTable.Controls)
            {
                if (!control.Name.Substring(0, 1).Equals("_"))
                {    //hogy a nap és óra feliratokat ne törölje le
                    control.Text = "";
                    control.BackColor = Color.FromArgb(16, 20, 35);
                }
            }
        }



        private void Orarend2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }




       


    }
}
