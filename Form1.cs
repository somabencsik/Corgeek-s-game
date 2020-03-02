using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table_Layout_Panel_Trying
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addCourseBtn_Click(object sender, EventArgs e)
        {


            string id = "";
            string startHour;
            string endHour;

            id = DayComboBox.Text.Substring(0, 3);



            string startHourTemp = StartTimeComboBox.SelectedItem.ToString();
            startHour = startHourTemp.Substring(0, 2);      //pl 8 vagy 10
            id += startHour;        //pl Mon09 vagy Tue10
            int startHourInt = Int32.Parse(startHour);

            string endHourTemp = EndTimeComboBox.SelectedItem.ToString();
            endHour = endHourTemp.Substring(0, 2);      //pl 10, 16
            int endHourInt = Int32.Parse(endHour);

            trmplabel.Text = startHour;
            label15.Text = endHour;

            int duration = endHourInt - startHourInt;
            
            
                       


            foreach (Control control in TimeTable.Controls) {    
                if (control.Name == id){
                    if (control.BackColor != Color.Pink)
                    {
                        control.Text = CourseNameTxtBox.Text;
                        control.BackColor = Color.Pink;
                        
                    }
                    else
                    {
                        MessageBox.Show("There is a course here already!");
                    }
                }
            }

        }
    }
}
