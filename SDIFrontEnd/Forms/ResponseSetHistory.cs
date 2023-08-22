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

namespace SDIFrontEnd
{
    // TODO add user name
    public partial class ResponseSetHistory : Form
    {
        public string FieldName { get; set; }
        
        public string SetID { get; set; }

        List<AuditResponse> history;

        BindingSource bs, bsPrev, bsNext;

        public ResponseSetHistory(string fieldname, string id)
        {
            InitializeComponent();

            this.MouseWheel += WordingHistory_MouseWheel;

            FieldName = fieldname;
            SetID = id;

            txtFieldName.DataBindings.Add(new Binding("Text", this, "FieldName"));
            txtID.DataBindings.Add(new Binding("Text", this, "ID"));

            bs = new BindingSource();
            bsPrev = new BindingSource();
            bsNext = new BindingSource();

            bs.PositionChanged += Bs_PositionChanged;

            history = new List<AuditResponse>();

            GetHistory(SetID);

            if (history.Count == 0)
            {
                MessageBox.Show("No audit records found for this wording.");
                this.Close();
            }

            bsPrev.DataSource = history;
            bsNext.DataSource = history;
            bs.DataSource = history;


            navWordings.BindingSource = bs;
            navWordings.Refresh();
        }

        private void WordingHistory_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }
        }

        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            MoveRecord();
        }

        private void MoveRecord()
        {
            if (bs.Position == 0)
            {
                bsPrev.Position = 0;
                // hide previous question
                rtbWordingPrev.Visible = false;
                txtUpdateDatePrev.Visible = false;
                txtChangeTypePrev.Visible = false;
            }
            else
            {
                bsPrev.Position = bs.Position - 1;
                rtbWordingPrev.Visible = true;
                txtUpdateDatePrev.Visible = true;
                txtChangeTypePrev.Visible = true;
            }

            if (bs.Position == bs.Count - 1)
            {
                bsNext.Position = bs.Count - 1;
                rtbWordingNext.Visible = false;
                txtUpdateDateNext.Visible = false;
                txtChangeTypeNext.Visible = false;
            }
            else
            {
                bsNext.Position = bs.Position + 1;
                rtbWordingNext.Visible = true;
                txtUpdateDateNext.Visible = true;
                txtChangeTypeNext.Visible = true;
            }

            AuditResponse previous = (AuditResponse)bsPrev.Current;
            AuditResponse current = (AuditResponse)bs.Current;
            AuditResponse next = (AuditResponse)bsNext.Current;

            rtbWordingPrev.Rtf = previous.WordingRTF;
            rtbWording.Rtf = current.WordingRTF;
            rtbWordingNext.Rtf = next.WordingRTF;

            foreach (Control c in this.Controls)
                c.DataBindings.Clear();

            txtID.DataBindings.Add(new Binding("Text", bs, "ID"));
            txtFieldName.DataBindings.Add(new Binding("Text", bs, "WordingType"));

            txtUpdateDate.DataBindings.Add(new Binding("Text", current, "UpdateDate"));
            txtUpdateDatePrev.DataBindings.Add(new Binding("Text", previous, "UpdateDate"));
            txtUpdateDateNext.DataBindings.Add(new Binding("Text", next, "UpdateDate"));

            txtChangeType.DataBindings.Add(new Binding("Text", current, "ChangeType"));
            txtChangeTypePrev.DataBindings.Add(new Binding("Text", previous, "ChangeType"));
            txtChangeTypeNext.DataBindings.Add(new Binding("Text", next, "ChangeType"));
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            bs.Position++;
        }



        private void cmdPrev_Click(object sender, EventArgs e)
        {
            bs.Position--;
        }

        private void GetHistory(string setID)
        {
            history.Clear();
            AuditResponse previous = new AuditResponse();
            previous.WordingType = FieldName;

            // get audit entries for certain primary key 
            var entries = DBAction.GetWordingHistory(FieldName, setID);

            // for each individual Day in the audit entries
            var days = from entry in entries
                       group entry by entry.UpdateDate.Date into newGroup
                       orderby newGroup.Key
                       select newGroup;

            // create a new question
            foreach (var day in days)
            {
                AuditResponse sq = new AuditResponse()
                {
                    ID = previous.ID,
                    UpdateDate = previous.UpdateDate
                };

                if (!string.IsNullOrEmpty(previous.Wording))
                    sq.Wording = string.Copy(previous.Wording);
                if (!string.IsNullOrEmpty(previous.WordingType))
                    sq.WordingType = string.Copy(previous.WordingType);

                // go through the entries for the day always overwriting with the newest value
                foreach (AuditEntry entry in day)
                {
                    sq.UpdateDate = entry.UpdateDate.Date;
                    sq.ChangeType = entry.Type;
                    switch (entry.FieldName)
                    {
                        case "RespName":
                        case "NRName":
                            sq.ID = entry.NewValue;
                            break;
                        case "RespOptions":
                        case "NRCodes":
                            sq.Wording = entry.NewValue;
                            break;
                    }

                }
                previous = sq;
                history.Add(sq);

            }


        }
    }
}
