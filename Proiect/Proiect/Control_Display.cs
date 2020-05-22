using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;
using System.IO;
using System.Collections;





namespace Proiect
{
    public partial class Control_Display : UserControl
    {
        IStocareData adminPersoane = StocareFactory.GetAdministratorStocare();
       
        public Control_Display()
        {
            InitializeComponent();

        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            List<Agenda> persoane = adminPersoane.GetPersoane();
            AdaugaPersoaneInControlDataGridView(persoane);
        }
        

      
        private void AdaugaPersoaneInControlDataGridView(List<Agenda> persoane)
        {
            //reset continut control DataGridView
            dataGridPersoana.DataSource = null;

            //!!!! Controlul de tip DataGridView are ca sursa de date lista de obiecte de tip Student !!!
           // dataGridPersoana.DataSource = persoane;

            //personalizare sursa de date
            dataGridPersoana.DataSource = persoane.Select(s => new { s.nume,s.prenume,s.nr_telefon,s.adresa_email,s.data_nastere,s.grup,s.provenienta,s.DataActualizare }).ToList();
        }


        private void filtrareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            int ok = 0;
            List<Agenda> persoane = adminPersoane.GetPersoane();
            List<Agenda> persoane2 = new List<Agenda>();
            foreach (var pers in persoane)
                if (DateTime.Compare(dateTimePicker1.Value, pers.DataActualizare)<=0  && DateTime.Compare(dateTimePicker2.Value, pers.DataActualizare) >= 0)
                {
                    persoane2.Add(pers);
                    ok = 1;
                }
            if (ok == 0)
                dataGridPersoana.DataSource = null;
            else
                dataGridPersoana.DataSource = persoane2.Select(s => new { s.nume, s.prenume, s.nr_telefon, s.adresa_email, s.data_nastere, s.grup, s.provenienta, s.DataActualizare }).ToList();


            panel3.SendToBack();
        }


        private void salveazaDateleInFisierToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            List<Agenda> persoane = adminPersoane.GetPersoane();
            sfd.ShowDialog();
            salvareRaport(persoane, sfd.FileName);

        }


        public void salvareRaport(List<Agenda> studenti, string numeFisier)
        {
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'true' al constructorului StreamWriter indica modul 'append' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(numeFisier, true))
                {
                    foreach (Agenda s in studenti)
                    {
                        swFisierText.WriteLine(s.ConversieLaSir());
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

      
        
    }
}
