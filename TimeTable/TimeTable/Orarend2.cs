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
    public partial class Orarend2 : Form
    {
        private List<Targy> kivalasztott_targy_objektumok = new List<Targy>();
        private Random rnd = new Random();
        private int variaciok_szama;
        private bool[] utkozesek;
        private int hanyadik_variaciot_nezzuk_eppen;

        private List<int> uj_lista = new List<int>() { };
        public int getUj_lista_count() {
            return uj_lista.Count();
        }
        


        private Kurzus[,] matrix;


        //konstruktor
        public Orarend2(List<Targy> targyobjektumok)
        {
            InitializeComponent();

            

            kivalasztott_targy_objektumok = targyobjektumok;


            variaciok_megszamolasa(kivalasztott_targy_objektumok);
            //MessageBox.Show("variációk: " + variaciok_szama.ToString()); 

            utkozesek = new bool[variaciok_szama];
            PreviousButton.Visible = false;

            //Id generálás
            int sorId = 0;
            foreach (Targy t in kivalasztott_targy_objektumok)
            {
                int oszlopId = 0;
                foreach (Kurzus k in t.kurzus_lista)
                {
                    k.SetId(sorId, oszlopId);
                    oszlopId++;
                }
                sorId++;
            }


            matrix = new Kurzus[variaciok_szama, kivalasztott_targy_objektumok.Count()];

            Matrix_generalasa();


            PreviousButton.Enabled = false;
            if (variaciok_szama > 1)
            {
                NextButton.Enabled = true;
            }

            Vannak_e_utkozesek();

            //szerintem ez nem kell de nem merem kivenni
            /*if (uj_lista.Count == 0)
            {
                MessageBox.Show("Sajnos ezeket a tárgyakat nem tudod ütközés nélkül felvenni");
                Form1 f1 = new Form1();
                *//*f1.Show();
                this.Close();*//*
                Environment.Exit(0);        //nem mukodik, ezert be kell zarni
            }*/

            
            hanyadik_variaciot_nezzuk_eppen = uj_lista[0];

            szamLabel.Text = uj_lista.Count().ToString();

            Kurzus[] egy_variacio = new Kurzus[kivalasztott_targy_objektumok.Count()];
            for (int i = 0; i < kivalasztott_targy_objektumok.Count(); i++)
            {
                egy_variacio[i] = matrix[hanyadik_variaciot_nezzuk_eppen, i];
            }

            orarendgeneralas(egy_variacio);
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


        public void orarendgeneralas(Kurzus[] kurzusok)
        {
            List<String[]> utkozo_targyak_nevei = new List<string[]>();

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
                        {   //ha pl megtalálta a H9-es labelt 
                            if (control.Text != "")
                            {
                                string[] utkozo_par = new string[2];
                                utkozo_par[0] = control.Text;
                                utkozo_par[1] = k.Ora_neve;
                                utkozo_targyak_nevei.Add(utkozo_par);

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


                            int szamok = Int32.Parse(temp_id.Substring(temp_id.Length - 2));  //kivettük az utolsó 2 betűt(8)

                            int szamok_temp = szamok + 1; 
                            temp_id = temp_id.Replace(temp_id.Substring(temp_id.Length - 2), szamok_temp.ToString("00"));

                            idotartam -= 1;
                        }
                    }
                }

            }
           
        }



        public void Vannak_e_utkozesek()
        {
            for (int i = 0; i < variaciok_szama; i++)
            {
                hanyadik_variaciot_nezzuk_eppen = i;
                Kurzus[] kurzus_sor = new Kurzus[kivalasztott_targy_objektumok.Count()];
                for (int j = 0; j < kivalasztott_targy_objektumok.Count();j++)
                {
                    kurzus_sor[j] = matrix[i,j];
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
                        {   //ha pl megtalálta a H9-es labelt 
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


        private void NextButton_Click(object sender, EventArgs e)
        {
            int x = uj_lista.IndexOf(hanyadik_variaciot_nezzuk_eppen);
            hanyadik_variaciot_nezzuk_eppen = uj_lista[x+1];
            if (hanyadik_variaciot_nezzuk_eppen >= uj_lista.Last())
            {
                NextButton.Enabled = false;
                NextButton.Visible = false;
            }
            if (hanyadik_variaciot_nezzuk_eppen > 0)
            {
                PreviousButton.Enabled = true;
                PreviousButton.Visible = true;
            }

            torles();

            Kurzus[] egy_variacio = new Kurzus[kivalasztott_targy_objektumok.Count()];
            for (int i = 0; i < kivalasztott_targy_objektumok.Count(); i++)
            {
                egy_variacio[i] = matrix[hanyadik_variaciot_nezzuk_eppen, i];
            }

            orarendgeneralas(egy_variacio);

        }


        

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            int x = uj_lista.IndexOf(hanyadik_variaciot_nezzuk_eppen);
            hanyadik_variaciot_nezzuk_eppen = uj_lista[x - 1];

            if (hanyadik_variaciot_nezzuk_eppen <= uj_lista.First())
            {
                PreviousButton.Enabled = false;
                PreviousButton.Visible = false;
            }
            if (hanyadik_variaciot_nezzuk_eppen < uj_lista.Last())
            {
                NextButton.Enabled = true;
                NextButton.Visible = true;
            }

            torles();

            Kurzus[] egy_variacio = new Kurzus[kivalasztott_targy_objektumok.Count()];
            for (int i = 0; i < kivalasztott_targy_objektumok.Count(); i++)
            {
                egy_variacio[i] = matrix[hanyadik_variaciot_nezzuk_eppen, i];
            }
            orarendgeneralas(egy_variacio);
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

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            int x = hanyadik_variaciot_nezzuk_eppen + 1;
            timerlabel.Text = "Variáció: " + x.ToString() + "/" + variaciok_szama.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }







        //tooltipek

        private void H08_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H08, H08.Text);
        }

        private void H09_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H09, H09.Text);
        }

        private void H10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H10, H10.Text);
        }

        private void H11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H11, H11.Text);
        }


        private void H12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H12, H12.Text);
        }

        private void H13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H13, H13.Text);
        }

        private void H14_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H14, H14.Text);
        }

        private void H15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H15, H15.Text);
        }

        private void H16_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H16, H16.Text);
        }

        private void H17_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H17, H17.Text);
        }

        private void H18_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H18, H18.Text);
        }

        private void H19_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(H19, H19.Text);
        }

        private void K08_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K08, K08.Text);
        }

        private void K09_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K09, K09.Text);
        }

        private void K10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K10, K10.Text);
        }

        private void K11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K11, K11.Text);
        }

        private void K12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K12, K12.Text);
        }

        private void K13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K13, K13.Text);
        }

        private void K14_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K14, K14.Text);
        }

        private void K15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K15, K15.Text);
        }

        private void K16_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K16, K16.Text);
        }

        private void K17_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K17, K17.Text);
        }

        private void K18_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K18, K18.Text);
        }

        private void K19_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(K19, K19.Text);
        }

        private void SZE08_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE08, SZE08.Text);
        }

        private void SZE09_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE09, SZE09.Text);
        }

        private void SZE10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE10, SZE10.Text);
        }

        private void SZE11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE11, SZE11.Text);
        }

        private void SZE12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE12, SZE12.Text);
        }

        private void SZE13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE13, SZE13.Text);
        }

        private void SZE14_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE14, SZE14.Text);
        }

        private void SZE15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE15, SZE15.Text);
        }

        private void SZE16_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE16, SZE16.Text);
        }

        private void SZE17_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE17, SZE17.Text);
        }

        private void SZE18_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE18, SZE18.Text);
        }

        private void SZE19_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SZE19, SZE19.Text);
        }

        private void CS08_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS08, CS08.Text);
        }

        private void CS09_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS09, CS09.Text);
        }

        private void CS10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS10, CS10.Text);
        }

        private void CS11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS11, CS11.Text);
        }

        private void CS12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS12, CS12.Text);
        }

        private void CS13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS13, CS13.Text);
        }

        private void CS14_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS14, CS14.Text);
        }

        private void CS15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS15, CS15.Text);
        }

        private void CS16_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS16, CS16.Text);
        }

        private void CS17_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS17, CS17.Text);
        }

        private void CS18_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS18, CS18.Text);
        }

        private void CS19_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CS19, CS19.Text);
        }

        private void P08_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P08, P08.Text);
        }

        private void P09_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P09, P09.Text);
        }

        private void P10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P10, P10.Text);
        }

        private void P11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P11, P11.Text);
        }

        private void P12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P12, P12.Text);
        }

        private void P13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P13, P13.Text);
        }

        private void P14_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P14, P14.Text);
        }

        private void P15_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P15, P15.Text);
        }

        private void P16_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P16, P16.Text);
        }

        private void P17_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P17, P17.Text);
        }

        private void P18_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P18, P18.Text);
        }

        private void P19_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(P19, P19.Text);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void H08_MouseHover_1(object sender, EventArgs e)
        {

        }

       
    }
}
