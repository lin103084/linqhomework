﻿using LinqLabs.作業;
using MyHomeWork;
using Starter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmHelloLinq().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmLangForLINQ().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FrmLINQ架構介紹_InsideLINQ().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FrmLINQ_To_XXX().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FrmLinq_To_Entity().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Frm作業_1().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Frm作業_2().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Frm作業_3().Show();
        }
    }
}
