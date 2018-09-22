﻿using System;
using System.Windows.Forms;

namespace RTLSpectrumAnalyzerGUI
{
    public partial class quickStartForm : Form
    {
        Form1 mainForm;

        public quickStartForm(Form1 mainForm)
        {
            this.mainForm = mainForm;

            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainForm.transitionAnalysesMode = checkBox2.Checked;

            if (!checkBox2.Checked && !checkBox3.Checked)
                mainForm.checkBox9.Checked = false;

            if (checkBox1.Checked)
                mainForm.checkBox8.Checked = mainForm.checkBox13.Checked = mainForm.showGraphs = checkBox1.Checked;
            else
            {
                mainForm.checkBox8.Checked = mainForm.showGraphs = checkBox1.Checked;
                mainForm.checkBox13.Checked = true;
            }

            if (checkBox10.Checked)
                mainForm.LoadData("session.rtl");                
            else
            {
                mainForm.textBox1.Text = textBox1.Text;
                mainForm.textBox2.Text = textBox2.Text;
                mainForm.textBox3.Text = textBox3.Text;                

                mainForm.ActivateSettings();
            }

            if (mainForm.transitionAnalysesMode)
            {
                /////////mainForm.InitializeTransitionSignalsToBeAnalysed(10, mainForm.dataLowerFrequency, mainForm.dataUpperFrequency);                
                mainForm.InitializeTransitionSignalsToBeAnalysed(Form1.MAX_TRANSITION_SCANS, mainForm.dataLowerFrequency, mainForm.dataUpperFrequency);
            }

            mainForm.RecordSeries2();

            this.Hide();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                textBox1.Enabled = textBox2.Enabled  = textBox3.Enabled = false;
            }
            else
                textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox3.Checked = false;
        }
    }
}
