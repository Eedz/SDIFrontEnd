using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using ITCLib;

namespace SDIFrontEnd
{
    public partial class SeriesBuilder : Form
    {
        WordingEntryForm frmWordings;
        ITCLib.SeriesBuilder builder = new ITCLib.SeriesBuilder();
        SurveyQuestion currentMember;
        SurveyQuestion seriesWordings;
        
        BindingSource bs;
        BindingSource bsSeries;

        public List<SurveyQuestion> QuestionsToAdd { get => builder.SeriesMembers; }
        public string DestinationQnum;
        public Survey DestinationSurvey;

        public SeriesBuilder(Survey survey, string qnum)
        {
            InitializeComponent();

            FillLists();

            currentMember = new SurveyQuestion();
            DestinationSurvey = survey;
            DestinationQnum = qnum;
            seriesWordings = new SurveyQuestion();
            builder.StartingQnum = qnum + "a";
            BindProperties();
        }

        private void FillLists()
        {
            cboFieldName.Items.AddRange(new string[] { 
                string.Empty, 
                "PreP", "PreI", "PreA", "PstI", "PstP", 
                "RespOptions", "NRCodes",
                "Topic", "Content", "Product"
            });

            cboContent.DisplayMember = "LabelText";
            cboContent.ValueMember = "ID";
            cboContent.DataSource = new List<ContentLabel>(Globals.AllContentLabels);

            cboTopic.DisplayMember = "LabelText";
            cboTopic.ValueMember = "ID";
            cboTopic.DataSource = new List<TopicLabel>(Globals.AllTopicLabels);

            cboDomain.DisplayMember = "LabelText";
            cboDomain.ValueMember = "ID";
            cboDomain.DataSource = new List<DomainLabel>(Globals.AllDomainLabels);

            cboProduct.DisplayMember = "LabelText";
            cboProduct.ValueMember = "ID";
            cboProduct.DataSource = new List<ProductLabel>(Globals.AllProductLabels);

        }

        private void BindProperties()
        {
            bs = new BindingSource();
            bs.DataSource = currentMember;

            txtLitQ.DataBindings.Add("Text", bs, "LitQW.WordID");

            txtPreP.DataBindings.Add("Text", bs, "PrePW.WordID");
            txtPreI.DataBindings.Add("Text", bs, "PreIW.WordID");
            txtPreA.DataBindings.Add("Text", bs, "PreAW.WordID");
            txtPstP.DataBindings.Add("Text", bs, "PstPW.WordID");
            txtPstI.DataBindings.Add("Text", bs, "PstIW.WordID");

            txtRO.DataBindings.Add("Text", bs, "RespOptionsS.RespSetName");
            txtNR.DataBindings.Add("Text", bs, "NRCodesS.RespSetName");

            txtVarLabel.DataBindings.Add("Text", bs, "VarName.Varlabel");
            cboContent.DataBindings.Add("SelectedItem", bs, "VarName.Content");
            cboTopic.DataBindings.Add("SelectedItem", bs, "VarName.Topic");
            cboDomain.DataBindings.Add("SelectedItem",bs, "VarName.Domain");
            cboProduct.DataBindings.Add("SelectedItem", bs, "VarName.Product");

            bsSeries = new BindingSource();
            bsSeries.DataSource = seriesWordings;

            txtSeriesPreP.DataBindings.Add("Text", bsSeries, "PrePW.WordID");
            txtSeriesPreI.DataBindings.Add("Text", bsSeries, "PreIW.WordID");
            txtSeriesPreA.DataBindings.Add("Text", bsSeries, "PreAW.WordID");
            txtSeriesPstP.DataBindings.Add("Text", bsSeries, "PstPW.WordID");
            txtSeriesPstI.DataBindings.Add("Text", bsSeries, "PstIW.WordID");

            txtSeriesRO.DataBindings.Add("Text", bsSeries, "RespOptionsS.RespSetName");
            txtSeriesNR.DataBindings.Add("Text", bsSeries, "NRCodesS.RespSetName");
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            builder.SeriesMembers.Clear();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string varname = txtNewVarName.Text;

            if (varname.Length > 2 && char.IsLetter(varname[0]) && char.IsLetter(varname[1]))
                varname = varname.Substring(0, 2).ToUpper() + varname.Substring(2);

            if (DestinationSurvey.QuestionByRefVar(varname) !=null)
            {
                MessageBox.Show(DestinationSurvey.SurveyCode + " already contains " + varname);
                return;
            }

            SurveyQuestion question = new SurveyQuestion();
            question.SurveyCode = DestinationSurvey.SurveyCode;

            question.VarName = new VariableName(varname);

            string newVarCC = Utilities.ChangeCC(question.VarName.VarName, DestinationSurvey.CountryCode);
            question.VarName.VarName = newVarCC;
            question.VarName.RefVarName = Utilities.ChangeCC(newVarCC);
            question.Qnum = DestinationQnum;
            question.LitQW.WordingText = "new member";
            builder.AddMember(question);

            ListViewItem item = new ListViewItem(new string[] { question.Qnum, question.VarName.VarName, question.LitQW.WordingText });
            item.Tag = question;
            lstSeries.Items.Add(item);

            currentMember = question;
        }

        private void LoadList()
        {
            lstSeries.Items.Clear();
            foreach (SurveyQuestion member in builder.SeriesMembers)
            {
                ListViewItem item = new ListViewItem(new string[] { member.Qnum, member.VarName.VarName, member.LitQW.WordingText });
                item.Tag = member;
                lstSeries.Items.Add(item);
            }
        }

        private void lstSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSeries.SelectedItems.Count == 0) return;
            currentMember = (SurveyQuestion)lstSeries.SelectedItems[0].Tag;
            bs.DataSource = currentMember;
            bs.ResetBindings(false);
            LoadQuestion();
        }

        private void cmdApplyWording_Click(object sender, EventArgs e)
        {
            string field = (string)cboFieldName.SelectedItem;
            object selectedWording = cboWording.SelectedItem;

            Wording wording = selectedWording as Wording;
            ResponseSet response = selectedWording as ResponseSet;
            TopicLabel topic = selectedWording as TopicLabel;
            DomainLabel domain = selectedWording as DomainLabel;
            ProductLabel product = selectedWording as ProductLabel;

            switch (field)
            {
                case "PreP":
                    builder.SetPreP(new Wording(wording.WordID, wording.Type, wording.WordingText));
                    break;
                case "PreI":
                    builder.SetPreI(new Wording(wording.WordID, wording.Type, wording.WordingText));
                    break;
                case "PreA":
                    builder.SetPreA(new Wording(wording.WordID, wording.Type, wording.WordingText));
                    break;
                case "PstI":
                    builder.SetPstI(new Wording(wording.WordID, wording.Type, wording.WordingText));
                    break;
                case "PstP":
                    builder.SetPstP(new Wording(wording.WordID, wording.Type, wording.WordingText));
                    break;
                case "RespOptions":
                    builder.SetRespOptions(new ResponseSet(response.RespSetName, response.Type, response.RespList));
                    break;
                case "NRCodes":
                    builder.SetNRCodes(new ResponseSet(response.RespSetName, response.Type, response.RespList));
                    break;
                case "Topic":
                    builder.SetTopic(new TopicLabel(topic.ID, topic.LabelText));
                    break;
                case "Domain":
                    builder.SetDomain(new DomainLabel(domain.ID, domain.LabelText));
                    break;
                case "Product":
                    builder.SetProduct(new ProductLabel(product.ID, product.LabelText));
                    break;
            }

            LoadList();
        }

        private void cboFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string field = (string)cboFieldName.SelectedItem;
            switch (field)
            {
                case "PreP":
                case "PreI":
                case "PreA":
                case "LitQ":
                case "PstI":  
                case "PstP":
                    SetWordingList(field);
                    break;
                case "RespOptions":
                case "NRCodes":
                    SetResponseList(field);
                    break;
                case "Topic":
                    SetTopicList();
                    break;
                case "Domain":
                    SetDomainList();
                    break;
                case "Product":
                    SetProductList();
                    break;
            }
        }

        private void SetWordingList(string type)
        {
            cboWording.DataSource = null;
            cboWording.DisplayMember = "WordID";
            cboWording.ValueMember = "WordID";
            cboWording.DataSource = Globals.GetWordingList(type);
        }

        private void SetResponseList(string type)
        {
            cboWording.DataSource = null;
            cboWording.DisplayMember = "RespSetName";
            cboWording.ValueMember = "RespSetName";
            cboWording.DataSource = Globals.GetResponseList(type);
        }

        private void SetTopicList()
        {
            cboWording.DataSource = null;
            cboWording.DisplayMember = "LabeLText";
            cboWording.ValueMember = "ID";
            cboWording.DataSource = Globals.AllTopicLabels;
        }

        private void SetDomainList()
        {
            cboWording.DataSource = null;
            cboWording.DisplayMember = "LabeLText";
            cboWording.ValueMember = "ID";
            cboWording.DataSource = Globals.AllDomainLabels;
        }

        private void SetProductList()
        {
            cboWording.DataSource = null;
            cboWording.DisplayMember = "LabeLText";
            cboWording.ValueMember = "ID";
            cboWording.DataSource = Globals.AllProductLabels;
        }

        private void cboWording_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbWordingText.Rtf = null;

            if (cboWording.SelectedItem is Wording)
                rtbWordingText.Rtf = HtmlRtfConverter.Converter.HTMLToRtf(((Wording)cboWording.SelectedItem).WordingText);
            else if (cboWording.SelectedItem is ResponseSet)
                rtbWordingText.Rtf = HtmlRtfConverter.Converter.HTMLToRtf(((ResponseSet)cboWording.SelectedItem).RespList);
                
            //else if (cboWording.SelectedItem is TopicLabel)
            //    rtbWordingText.Text = ((TopicLabel)cboWording.SelectedItem).LabelText;
            //else if (cboWording.SelectedItem is DomainLabel)
            //    rtbWordingText.Text = ((DomainLabel)cboWording.SelectedItem).LabelText;
            //else if (cboWording.SelectedItem is ProductLabel)
            //    rtbWordingText.Text = ((ProductLabel)cboWording.SelectedItem).LabelText;

            rtbWordingText.Enabled = cboWording.SelectedItem is Wording || cboWording.SelectedItem is ResponseSet;
        }

        private void LoadQuestion()
        {
            rtbMemberText.Rtf = HtmlRtfConverter.Converter.HTMLToRtf(currentMember.GetQuestionTextHTML(true, true));
            rtbSeriesText.Rtf = HtmlRtfConverter.Converter.HTMLToRtf(seriesWordings.GetQuestionTextHTML(true, true));
        }

        /// <summary>
        /// Opens the wording form popup to a specific wording.
        /// </summary>
        /// <param name="wording">The wording that will appear in the form.</param>
        public void OpenWordingForm(Wording wording)
        {
            if (frmWordings != null)
                frmWordings.Close();

            frmWordings = new WordingEntryForm(wording);
            frmWordings.ShowDialog();

            if (frmWordings.DialogResult == DialogResult.OK)
                UpdateWording(frmWordings.CurrentRecord.Item);
            else
                UpdateWordingText(frmWordings.CurrentRecord.Item);

            LoadQuestion();
        }

        private void MemberWording_Validated(object sender, EventArgs e)
        {
            LoadList();
            LoadQuestion();
        }

        private void MemberWording_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            string wordingNum = txt.Text;

            if (wordingNum.Any(x => char.IsLetter(x)))
            {
                MessageBox.Show("Invalid entry. Use numbers only.");
                e.Cancel = true;
                txt.Undo();
            }

            switch (txt.Name)
            {
                case "txtPreP":
                    Wording prep = Globals.AllPreP.FirstOrDefault(x => x.WordID == Int32.Parse(wordingNum));
                    if (prep == null)
                    {
                        MessageBox.Show($"Invalid entry. PreP# {wordingNum} does not exist.", "Error");
                        e.Cancel = true;
                        txt.Undo();
                        return;
                    }
                    currentMember.PrePW = prep;
                    break;
                case "txtPreI":
                    Wording prei = Globals.AllPreI.FirstOrDefault(x => x.WordID == Int32.Parse(wordingNum));
                    if (prei == null)
                    {
                        MessageBox.Show($"Invalid entry. PreI# {wordingNum} does not exist.", "Error");
                        e.Cancel = true;
                        txt.Undo();
                        return;
                    }
                    currentMember.PreIW = prei;
                    break;
                case "txtPreA":
                    Wording prea = Globals.AllPreA.FirstOrDefault(x => x.WordID == Int32.Parse(wordingNum));
                    if (prea == null)
                    {
                        MessageBox.Show($"Invalid entry. PreA# {wordingNum} does not exist.", "Error");
                        e.Cancel = true;
                        txt.Undo();
                        return;
                    }
                    currentMember.PreAW = prea;
                    break;
                case "txtLitQ":
                    Wording litq = Globals.AllLitQ.FirstOrDefault(x => x.WordID == Int32.Parse(wordingNum));
                    if (litq == null)
                    {
                        MessageBox.Show($"Invalid entry. LitQ# {wordingNum} does not exist.", "Error");
                        e.Cancel = true;
                        txt.Undo();
                        return;
                    }
                    currentMember.LitQW = litq;
                    break;
                case "txtPstI":
                    Wording psti = Globals.AllPstI.FirstOrDefault(x => x.WordID == Int32.Parse(wordingNum));
                    if (psti == null)
                    {
                        MessageBox.Show($"Invalid entry. PstI# {wordingNum} does not exist.", "Error");
                        e.Cancel = true;
                        txt.Undo();
                        return;
                    }
                    currentMember.PstIW = psti;
                    break;
                case "txtPstP":
                    Wording pstp = Globals.AllPstP.FirstOrDefault(x => x.WordID == Int32.Parse(wordingNum));
                    if (pstp == null)
                    {
                        MessageBox.Show($"Invalid entry. PstP# {wordingNum} does not exist.", "Error");
                        e.Cancel = true;
                        txt.Undo();
                        return;
                    }
                    currentMember.PreIW = pstp;
                    break;
            }
        }

        private void MemberResponse_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            string respSetName = txt.Text;

            switch (txt.Name)
            {
                case "txtRO":
                    ResponseSet ro = Globals.AllRespOptions.FirstOrDefault(x => x.RespSetName.ToLower().Equals(respSetName.ToLower()));
                    if (ro == null)
                    {
                        MessageBox.Show($"Invalid entry. Response set '{respSetName}' does not exist.", "Error");
                        e.Cancel = true;
                        txt.Undo();
                        return;
                    }
                    currentMember.RespOptionsS = ro;
                    break;
                case "txtNR":
                    ResponseSet nr = Globals.AllNRCodes.FirstOrDefault(x => x.RespSetName.ToLower().Equals(respSetName.ToLower()));
                    if (nr == null)
                    {
                        MessageBox.Show($"Invalid entry. Non-response set '{respSetName}' does not exist.", "Error");
                        e.Cancel = true;
                        txt.Undo();
                        return;
                    }
                    currentMember.NRCodesS = nr;
                    break;
            }
        }

        private void txtPreP_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenWordingForm(currentMember.PrePW);
        }

        private void txtPreI_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenWordingForm(currentMember.PreIW);
        }

        private void txtPreA_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenWordingForm(currentMember.PreAW);
        }

        private void txtLitQ_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenWordingForm(currentMember.LitQW);
        }

        private void txtRO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ResponseOptionUsage frm = new ResponseOptionUsage(currentMember.RespOptionsS);

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
                UpdateResponseSet(frm.CurrentRecord.Item);
            else
                UpdateResponseSetText(frm.CurrentRecord.Item);

            LoadQuestion();
        }

        private void txtNR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ResponseOptionUsage frm = new ResponseOptionUsage(currentMember.NRCodesS);

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
                UpdateResponseSet(frm.CurrentRecord.Item);
            else
                UpdateResponseSetText(frm.CurrentRecord.Item);

            LoadQuestion();
        }

        private void txtPstI_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenWordingForm(currentMember.PstIW);
        }

        private void txtPstP_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenWordingForm(currentMember.PstPW);
        }

        private void UpdateWording(Wording wording)
        {
            switch (wording.FieldType)
            {
                case "PreP":
                    if (wording.Equals(currentMember.PrePW))
                        currentMember.PrePW.WordingText = wording.WordingText;
                    else
                        currentMember.PrePW = wording;

                    break;
                case "PreI":
                    if (wording.Equals(currentMember.PreIW))
                        currentMember.PreIW.WordingText = wording.WordingText;
                    else
                        currentMember.PreIW = wording;

                    break;
                case "PreA":
                    if (wording.Equals(currentMember.PreAW))
                        currentMember.PreAW.WordingText = wording.WordingText;
                    else
                        currentMember.PreAW = wording;

                    break;
                case "LitQ":
                    if (wording.Equals(currentMember.LitQW))
                        currentMember.LitQW.WordingText = wording.WordingText;
                    else
                        currentMember.LitQW = wording;

                    break;
                case "PstI":
                    if (wording.Equals(currentMember.PstIW))
                        currentMember.PstIW.WordingText = wording.WordingText;
                    else
                        currentMember.PstIW = wording;

                    break;
                case "PstP":
                    if (wording.Equals(currentMember.PstPW))
                        currentMember.PstPW.WordingText = wording.WordingText;
                    else
                        currentMember.PstPW = wording;

                    break;
            }
            bs.ResetBindings(false);
        }

        private void UpdateWordingText(Wording wording)
        {
            switch (wording.FieldType)
            {
                case "PreP":
                    var prep = Globals.AllPreP.FirstOrDefault(x => x.WordID == currentMember.PrePW.WordID);
                    if (prep != null)
                        currentMember.PrePW.WordingText = prep.WordingText;
                    break;
                case "PreI":
                    var prei = Globals.AllPreI.FirstOrDefault(x => x.WordID == currentMember.PreIW.WordID);
                    if (prei != null)
                        currentMember.PreIW.WordingText = prei.WordingText;

                    break;
                case "PreA":
                    var prea = Globals.AllPreA.FirstOrDefault(x => x.WordID == currentMember.PreAW.WordID);
                    if (prea != null)
                        currentMember.PreAW.WordingText = prea.WordingText;

                    break;
                case "LitQ":
                    var litq = Globals.AllLitQ.FirstOrDefault(x => x.WordID == currentMember.LitQW.WordID);
                    if (litq != null)
                        currentMember.LitQW.WordingText = litq.WordingText;

                    break;
                case "PstI":
                    var psti = Globals.AllPstI.FirstOrDefault(x => x.WordID == currentMember.PstIW.WordID);
                    if (psti != null)
                        currentMember.PstIW.WordingText = psti.WordingText;

                    break;
                case "PstP":
                    var pstp = Globals.AllPstP.FirstOrDefault(x => x.WordID == currentMember.PstPW.WordID);
                    if (pstp != null)
                        currentMember.PstPW.WordingText = pstp.WordingText;

                    break;
            }
            bs.ResetBindings(false);
        }

        private void UpdateResponseSet(ResponseSet response)
        {
            switch (response.FieldType)
            {
                case "RespOptions":
                    if (response.Equals(currentMember.RespOptionsS))
                        currentMember.RespOptionsS.RespList = response.RespList;
                    else
                        currentMember.RespOptionsS = response;

                    break;
                case "NRCodes":
                    if (response.Equals(currentMember.NRCodesS))
                        currentMember.NRCodesS.RespList = response.RespList;
                    else
                        currentMember.NRCodesS = response;
                    break;
            }
        }

        private void UpdateResponseSetText(ResponseSet response)
        {
            switch (response.FieldType)
            {
                case "RespOptions":
                    var ro = Globals.AllRespOptions.FirstOrDefault(x => x.RespSetName.Equals(currentMember.RespOptionsS.RespSetName));
                    if (ro != null)
                        currentMember.RespOptionsS.RespList = ro.RespList;

                    break;
                case "NRCodes":
                    var nr = Globals.AllNRCodes.FirstOrDefault(x => x.RespSetName.Equals(currentMember.NRCodesS.RespSetName));
                    if (nr != null)
                        currentMember.NRCodesS.RespList = nr.RespList;

                    break;
            }
        }
    }
}
