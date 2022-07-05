﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;

namespace ISISFrontEnd
{
    public partial class NewWaveEntry : Form
    {
        public StudyWaveRecord NewWave;
        List<StudyRecord> StudyList;

        BindingSource bs;

        public NewWaveEntry()
        {
            InitializeComponent();

            StudyList = Globals.AllStudies;

            NewWave = new StudyWaveRecord();
            bs = new BindingSource();
            bs.DataSource = NewWave;

            cboProject.DataSource = StudyList;
            cboProject.DisplayMember = "StudyName";
            cboProject.ValueMember = "ID";

            BindProperties();
        }

        private void BindProperties()
        {
            txtID.DataBindings.Add(new Binding("Text", bs, "ID"));
            txtWaveNumber.DataBindings.Add(new Binding("Text", bs, "Wave"));
            chkEnglishRouting.DataBindings.Add(new Binding("Checked", bs, "EnglishRouting"));
            txtCountries.DataBindings.Add(new Binding("Text", bs, "Countries"));
            txtWaveCode.DataBindings.Add(new Binding("Text", bs, "WaveCode"));
            cboProject.DataBindings.Add(new Binding("SelectedValue", bs, "StudyID"));
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (DBAction.InsertStudyWave(NewWave) == 1)
            {
                MessageBox.Show("Error creating new wave.");
                return;
            }
            Globals.AllWaves.Add(NewWave);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cboProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProject.SelectedItem == null)
                return;

            NewWave.ISO_Code = ((Study)cboProject.SelectedItem).ISO_Code;
        }

        private void cmdNewStudy_Click(object sender, EventArgs e)
        {
            NewStudyEntry frm = new NewStudyEntry();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                StudyList.Add(frm.NewStudy);
                cboProject.DataSource = null;
                cboProject.DataSource = StudyList;
                cboProject.SelectedValue = frm.NewStudy.ID;
            }
        }
    }
}