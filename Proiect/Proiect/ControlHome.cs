using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class ControlHome : UserControl
    {
        IStocareData adminPersoane = StocareFactory.GetAdministratorStocare();
        public ControlHome()
        {
            InitializeComponent();
           
        }

       

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] buf;
            string[] buf2;
            List<Agenda> persoane = adminPersoane.GetPersoane();
            string data = DateTime.Now.ToString("MM/dd/yyyy");
            foreach (Agenda pers in persoane)
            {
                buf = pers.data_nastere.Split('.');
                buf2 = data.Split('.');
               // if (buf[0] == buf2[0] && buf[1] == buf2[1])
                    //richTextBox1.Text = "Astazi este ziua lui" + pers.NumeComplet;

            }
        }
    }
}
