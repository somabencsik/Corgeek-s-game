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
    public partial class midform : Form
    {
        private List<Targy> kivalasztott_targy_objektumok = new List<Targy>();
  
        //uj
        private int ujlistacount;

        public midform(List<Targy> t, int variacio_szam)
        {
            InitializeComponent();
            kivalasztott_targy_objektumok = t;

            MidFormTempTimeTable mft = new MidFormTempTimeTable(kivalasztott_targy_objektumok);
            ujlistacount = mft.getUj_lista_count();
            
            mfLabel.Text = variacio_szam + " órarend variáció van, abból "+ ujlistacount+" ütközés mentes. Mindet végig szeretnéd nézni?";
            if (ujlistacount == 0) {
                utkMentesRadio.Text += " \n (ez most nem lehetséges)";
                utkMentesRadio.Enabled = false;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (osszesRadio.Checked)
            {
                Orarend orarend = new Orarend(kivalasztott_targy_objektumok);
                orarend.Show();
                this.Hide();
            }
            if (utkMentesRadio.Checked)
            {
                Orarend2 orarend2 = new Orarend2(kivalasztott_targy_objektumok);
                orarend2.Show();
                this.Hide();
            }
        }
    }
}
