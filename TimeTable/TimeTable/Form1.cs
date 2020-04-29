using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace TimeTable
{
    public partial class Form1 : Form
    {

        private int removed_classes;
        public List<Targy> targy_objektumok = new List<Targy>();
        List<string> kivalasztott_targynevek = new List<string>(); 
        



        public Form1()
        {
            InitializeComponent();
        }
        
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            List<string> fileContent = new List<string>();
            List<string> osszes_targy = new List<string>();
            List<string> idopontos_targyak = new List<string>();

            var filePath = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                //Get the path of specified file
                filePath = openFileDialog1.FileName;

                
                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();
                Encoding encodingType = Encoding.GetEncoding("Windows-1250");

                StreamReader reader = new StreamReader(fileStream);//, encodingType);       //!!! ez kell bele, mert én most külön lementettem a txt-t és ott rákérdezett a kódolására de elsőre nem mentettem le külön és akkor kellett!
                while (reader.Peek() >= 0)
                {
                    fileContent.Add(reader.ReadLine());
                }

                foreach (string line in fileContent)    //ha tárgyról van szó
                {
                    //eredeti
                    if (!line.Equals("*") && !line.Contains(":"))
                    {
                        osszes_targy.Add(line);
                    }

                    //új
                    /*if ( ( line.Length > 1 && line.Substring(0, 1).Equals("*"))){      //kotlint kivéve működik, az előtt nincs csillag
                        if (line.Length == 18) {    //ha a kotlinról van szó
                            if (line.Substring(0, 6).Equals("Kotlin")) {
                                osszes_targy.Add(line);
                            }
                        }
                        osszes_targy.Add(line);                        
                    }  */                  
                }                                        
                                
     
                
                //tárgyak megjelölése ahol nem volt időpont, kell a megjelölgetés mert közben nem lehet törölni mert újrasorszámozódik (asszem) meg akkor nem tudnánk kiírni hogy hány tárgyat töröltünk
                for (int i = 0; i < fileContent.Count-1; i++)   //utolsó elemet nem kell nézni
                {
                    if ((osszes_targy.Contains(fileContent[i])) && (fileContent[i + 1].Equals("*"))) { //ha az adott sor tárgy és a rákövetkező elem csillag (vagyis nincs hozzá időpont)
                        fileContent[i] = fileContent[i].Insert(0, "?"); //új stringgel tér vissza
                        fileContent[i + 1] = fileContent[i + 1].Insert(0, "?");
                    }
                }

                //tárgyak törlése ahol nem volt időpont
                removed_classes = fileContent.RemoveAll(StartsWithQuestionMark) / 2;               



                //itt már a fileContent nem tartalmazza azokat a tárgyakat amikhez nincs időpont         
                
                foreach (string line in fileContent)
                {
                    if (!line.Equals("*") && !line.Contains(":"))
                    {
                        idopontos_targyak.Add(line);
                    }
                }

                for (int i = 0; i < idopontos_targyak.Count; i++)
                {
                    listBoxLeft.Items.Insert(i, idopontos_targyak[i]);
                }


                //classokba olvasás
                foreach (string ora in idopontos_targyak)
                {
                    Targy t = new Targy(ora);
                    targy_objektumok.Add(t);
                    int idx = fileContent.IndexOf(ora); //megkeresi hogy a fileContent-ben hol van ez az óra
                    ++idx;                                    //+1 mert különben saját magát is nézné, ami nem * tehát kurzusnak venné

                    try
                    {
                        for (int i = idx; i < fileContent.Count() - 1; i++)
                        {
                            if (fileContent[i].Equals("*")) //ha csillag
                            { 
                                break;
                            }
                            else   //ha kurzus
                            {     
                                Kurzus k = new Kurzus(fileContent[i]);
                                t.Kurzus_listahoz_adas(k);
                                k.Ora_neve = t.Nev;
                            }
                        }
                    }
                    catch(ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    
                    }
                }


                //ez csak egy teszt hogy sikerült-e a példányosítás
                for (int i = 0; i < idopontos_targyak.Count(); i++)
                {
                    //testLabel.Text += targy_objektumok[i].ToString() + "\n";
                }




            }
        }

        private bool StartsWithQuestionMark(String s)
        {
            return s.ToLower().StartsWith("?");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxLeft.SelectionMode = SelectionMode.MultiExtended;
            listBoxRight.SelectionMode = SelectionMode.MultiExtended;
        }

        private void sendItemToRightBtn_Click(object sender, EventArgs e)
        {

            //if left side item is selected, add it to the right side
            for (int i = 0; i <= listBoxLeft.Items.Count - 1; i++)
            {
                if (listBoxLeft.GetSelected(i) == true)     //if the item has been selected
                {
                    listBoxRight.Items.Add(listBoxLeft.Items[i]);   //then we add it tho the rightListBox
                }
            }

            //now invert the scan to remove the same items from the left list
            //has to be inverted because if we remove #5 before #2 that's sad
            for (int i = listBoxLeft.Items.Count - 1; i >= 0; i--)
            {
                if (listBoxLeft.GetSelected(i) == true)
                {
                    listBoxLeft.Items.RemoveAt(i);
                }
            }
        }

        private void sendItemToLeftBtn_Click(object sender, EventArgs e)
        {
            //the same as moveRightBtn_Click
            for (int i = 0; i <= listBoxRight.Items.Count - 1; i++)
            {
                if (listBoxRight.GetSelected(i) == true)
                {
                    listBoxLeft.Items.Add(listBoxRight.Items[i]);
                }
            }

            for (int i = listBoxRight.Items.Count - 1; i >= 0; i--)
            {
                if (listBoxRight.GetSelected(i) == true)
                {
                    listBoxRight.Items.RemoveAt(i);
                }
            }
        }


        private void targyakKivalasztBtn_Click(object sender, EventArgs e)
        {
            List<Targy> kivalasztott_targy_objektumok = new List<Targy>();

            //listboxból kivesszük a tárgyak neveit
            foreach (string item in listBoxRight.Items) {
                kivalasztott_targynevek.Add(item);
            }

            //és megkeressük a tárgy_objektumokban, létrejön a kiválasztott_tárgy_objektumok lista
            foreach (string line in kivalasztott_targynevek) {
                for (int i = 0; i < targy_objektumok.Count(); i++) {
                    if (targy_objektumok[i].Nev.Equals(line)) {
                        kivalasztott_targy_objektumok.Add(targy_objektumok[i]);
                        
                    }
                }
            }

            //és azt át kéne adni a másik formnak
            atad(kivalasztott_targy_objektumok);
                                   

        }




        private void atad(List<Targy> kivalasztott_targy_objektumok) {

            //Orarend orarend = new Orarend(kivalasztott_targy_objektumok);  //példányosítás
            //orarend.Show();
            int x = variaciok_megszamolasa(kivalasztott_targy_objektumok);

            midform mf = new midform(kivalasztott_targy_objektumok,x);
            mf.Show();
            this.Hide();


        }


        public int variaciok_megszamolasa(List<Targy> targyak)
        {

            int n = 1;
            foreach (Targy t in targyak)
            {
                n *= t.getKurzusSzam();
            }
            return n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBoxRight.Items.Count == 0)
            {
                targyakKivalasztBtn.Visible = false;
                targyakKivalasztBtn.Enabled = false;
            }
            else {
                targyakKivalasztBtn.Visible = true;
                targyakKivalasztBtn.Enabled = true;
            }
        }
    }
}
