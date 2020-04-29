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

        public midform(List<Targy> t, int variacio_szam)
        {
            InitializeComponent();
            kivalasztott_targy_objektumok = t;
            mfLabel.Text = variacio_szam + " db variáció van. Mindet végig szeretnéd nézni?";
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
