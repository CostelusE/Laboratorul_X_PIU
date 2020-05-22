﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class AgendaFormular : Form
    {
        public AgendaFormular()
        {
            InitializeComponent();
            controlHome1.BringToFront();


        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonHome.Height;
            panelLeft.Top = buttonHome.Top;
            controlHome1.BringToFront();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonInsert.Height;
            panelLeft.Top = buttonInsert.Top;
            control_Insert1.BringToFront();


        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonDisplay.Height;
            panelLeft.Top = buttonDisplay.Top;
            control_Display1.BringToFront();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
       
            panelLeft.Height = buttonSearch.Height;
            panelLeft.Top = buttonSearch.Top;
            control_Search1.BringToFront();
            
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
