using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;
using ITCReportLib;
using FM = FormManager;

namespace SDIFrontEnd
{
    public enum OperationType { Undefined, Add, Move, Delete }
    /// <summary>
    /// Displays one or more surveys and their products as lists. Each list can contain a refVarName on each line that represents a "match" between products and/or surveys
    /// </summary>
    public partial class ParallelQuestions : Form
    {
        // currently displayed records for the chosen surveys
        List<ParallelQuestion> Records;
        // all product labels for the chosen surveys
        List<ProductLabel> ProductLabels;
        // product labels to be included in the list as column
        List<ProductLabel> ShownProducts;

        // records to be deleted
        private List<ParallelQuestion> Deletes;
        // records that were moved to a new location (i.e. the match ID exists)
        private List<ParallelQuestion> Moves;
        // records that were added (i.e. the match ID does not exist)
        private List<ParallelQuestion> Adds;

        private int newCounter = -1; // placeholder matchID for new records

        List<Survey> Surveys; // the list of chosen surveys
        OperationType op = OperationType.Undefined;

        ListViewItem ReferenceListItem;
        ListViewItem.ListViewSubItem ReferenceSubItem;
        ParallelQuestion ReferenceQuestion;
        Point ReferencePoint;
        Picker<SurveyQuestion> Picker;

        public ParallelQuestions()
        {
            InitializeComponent();

            Adds = new List<ParallelQuestion>();
            Moves = new List<ParallelQuestion>();
            Deletes = new List<ParallelQuestion>();

            cboSurvey.ValueMember = "SID";
            cboSurvey.DisplayMember = "SurveyCode";
            cboSurvey.DataSource = new List<Survey>(Globals.AllSurveys);
            cboSurvey.SelectedItem = null;
    

            Surveys = new List<Survey>();
            Records = new List<ParallelQuestion>();
            ProductLabels = new List<ProductLabel>();
            ShownProducts = new List<ProductLabel>();
           
            ReferenceQuestion = new ParallelQuestion();
            ReferencePoint = new Point();
        }

        #region events 

        private void cmdAddSurvey_Click(object sender, EventArgs e)
        {
            if (cboSurvey.SelectedItem == null) return;

            Survey toAdd = (Survey)cboSurvey.SelectedItem;

            Surveys.Add(toAdd);
            dgvSurveys.Rows.Add(toAdd.SurveyCode);

            RefreshProducts();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Records.Count == 0) return;

            SaveRecords();

            ClearList();

            GetData(Surveys);

            MakeList();

            Display();
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            //add   
            op = OperationType.Add;
            // check if item already exists there
            if (ReferenceQuestion != null && !string.IsNullOrEmpty(ReferenceQuestion.Question.VarName.VarName))
            {
                if (MessageBox.Show("Are you sure want to replace " + ReferenceQuestion.Question.VarName.VarName, "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            ListViewItem targetItem = lstMatches.GetItemAt(ReferencePoint.X, ReferencePoint.Y);

            // show quetion list
            // get survey
            Survey survey;
            if (ReferenceQuestion == null)
                survey = Surveys.FirstOrDefault(x => x.SurveyCode.Equals(targetItem.GetSubItemAt(ReferencePoint.X, ReferencePoint.Y).Tag));
            else
                survey = Surveys.FirstOrDefault(x => x.SurveyCode.Equals(ReferenceQuestion.Question.SurveyCode));

            if (survey == null)
                return;

            var sourceList = new List<SurveyQuestion>(survey.Questions);
            sourceList = sourceList.OrderBy(x => x.VarName.RefVarName).ToList();
            
            Picker = new Picker<SurveyQuestion>(sourceList, "VarName.RefVarName", "ID", "VarName");
            Picker.Left = ReferencePoint.X;
            Picker.Top = ReferencePoint.Y;
            Picker.ShowDialog();

            if (Picker.Data == null)
                return;

            ParallelQuestion newPQ = new ParallelQuestion();
            newPQ.MatchID = (int)targetItem.Tag;
            newPQ.Question = Picker.Data;
            survey.Questions.Remove(Picker.Data);

            targetItem.GetSubItemAt(ReferencePoint.X, ReferencePoint.Y).Text = newPQ.Question.VarName.RefVarName;
            targetItem.GetSubItemAt(ReferencePoint.X, ReferencePoint.Y).Tag = newPQ;

            Adds.Add(newPQ);

            if (ReferenceQuestion!=null)
                Deletes.Add(ReferenceQuestion);

            op = OperationType.Undefined;
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            //delete

            if (string.IsNullOrEmpty(ReferenceSubItem.Text))
                return;

            ReferenceSubItem.Text = string.Empty;
            ReferenceSubItem.Tag = ReferenceQuestion.Question.SurveyCode;



            Deletes.Add(ReferenceQuestion);


        }

        private void toolStripMove_Click(object sender, EventArgs e)
        {
            //move
            lstMatches.Tag = "Move";
            op = OperationType.Move;
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            ShownProducts.Clear();

            foreach (DataGridViewRow row in dgvSurveys.Rows)
            {
                foreach (DataGridViewColumn column in dgvSurveys.Columns)
                {
                    if (column.Index == 0) continue;
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[column.Name];
                    if (!(bool)cell.FormattedValue) continue;

                    ProductLabel product = ProductLabels.First(x => x.ID == (int)column.Tag);

                    if (!ShownProducts.Contains(product)) ShownProducts.Add(product);
                }
            }

            if (Surveys.Count == 0 || ShownProducts.Count==0) return;
            ClearList();

            GetData(Surveys);

            MakeList();

            Display();
        }

        private void lstMatches_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                Point clientPoint = lstMatches.PointToClient(new Point(e.X, e.Y));
                SetReferenceItem(e.X, e.Y);

            }
            else if (e.Button == MouseButtons.Left)
            {
                if (op == OperationType.Move)
                {
                    ListViewItem targetItem = lstMatches.GetItemAt(e.X, e.Y);
                    ListViewItem.ListViewSubItem subitem = targetItem.GetSubItemAt(e.X, e.Y);
                    ListViewItem sourceItem = lstMatches.GetItemAt(ReferencePoint.X, ReferencePoint.Y);
                    ListViewItem.ListViewSubItem sourceSubItem = sourceItem.GetSubItemAt(ReferencePoint.X, ReferencePoint.Y);

                    DropListItem(targetItem, subitem, sourceItem, sourceSubItem);
                }
            }
        }

        private void cmdAddMatch_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            items.Add(newCounter.ToString());
            foreach(Survey survey in Surveys)
            {
                foreach (ProductLabel product in ShownProducts)
                {
                    items.Add(survey.SurveyCode);
                }
            }
            ListViewItem newItem = new ListViewItem(items.ToArray());

            foreach(ListViewItem.ListViewSubItem subitem in newItem.SubItems)
            {
                subitem.Tag = subitem.Text;
                subitem.Text = string.Empty;
            }
            newItem.Text = "(New)";
            newItem.Tag = newCounter;

            newCounter++;
            lstMatches.Items.Add(newItem);
            newItem.EnsureVisible();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintReport();
            
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ParallelQuestions_FormClosed(object sender, FormClosedEventArgs e)
        {
            FM.FormManager.Remove(this);
        }

        #endregion

        #region Methods

        void DropListItem(ListViewItem targetItem, ListViewItem.ListViewSubItem targetSubItem, ListViewItem sourceItem, ListViewItem.ListViewSubItem sourceSubItem)
        {
            string targetMatchID = targetItem.Text;

            // the incoming item
            ParallelQuestion incoming = sourceSubItem.Tag as ParallelQuestion;
            // the taget location question
            ParallelQuestion existing = targetSubItem.Tag as ParallelQuestion;

            // tried to move an empty item
            if (string.IsNullOrEmpty(sourceSubItem.Text))
            {
                op = OperationType.Undefined;
                return;
            }

            if (existing == null)
            {
                if (!incoming.Question.SurveyCode.Equals((string)targetSubItem.Tag))
                {
                    op = OperationType.Undefined;
                    return;
                }
            }
            else
            {
                if (!incoming.Question.SurveyCode.Equals((string)existing.Question.SurveyCode))
                {
                    op = OperationType.Undefined;
                    return;
                }
            }

            // create a new paralell question and associate it with the target location
            ParallelQuestion newPQ = new ParallelQuestion();
            newPQ.MatchID = int.Parse(targetMatchID);
            newPQ.Question.ID = incoming.Question.ID;
            newPQ.Question.VarName = incoming.Question.VarName;
            newPQ.Question.SurveyCode = incoming.Question.SurveyCode;

            targetSubItem.Text = newPQ.Question.VarName.RefVarName;
            targetSubItem.Tag = newPQ;

            if (int.Parse(targetMatchID) < 0)
                Adds.Add(newPQ);
            else 
                Moves.Add(newPQ);

            // remove the parallel question from the original location
            sourceSubItem.Text = string.Empty;
            sourceSubItem.Tag = newPQ.Question.SurveyCode;

            if (existing != null && existing.ID > 0)
                Deletes.Add(existing);

            if (incoming.ID > 0)
                Deletes.Add(incoming);
        }

        /// <summary>
        /// Fills the listviews with Varnames. Each row represents a MatchID with each VarName under its appropriate product label. 
        /// Each subitem's tag is set to the parallel question object. Blank subitems are tagged with their survey code.
        /// </summary>
        void Display()
        {
            var matches = Records.GroupBy(x => x.MatchID);
            foreach (var match in matches)
            {
                var questions = match.Select(x => x);

                List<string> items = new List<string>();
                items.Add(match.Key.ToString());

                foreach (Survey survey in Surveys)
                {
                    foreach (ProductLabel product in ShownProducts)
                    {
                        var question = questions.FirstOrDefault(x => x.Question.SurveyCode.Equals(survey.SurveyCode) && x.Question.VarName.Product.ID==product.ID);
                        
                        if (question == null)
                        {
                            items.Add(string.Empty);
                        }
                        else
                        {
                            items.Add(question.Question.VarName.RefVarName);
                        }
                    }
                }
                ListViewItem li =new ListViewItem( items.ToArray());
                li.Tag = match.Key;
                foreach (ListViewItem.ListViewSubItem item in li.SubItems)
                {
                    var q = questions.FirstOrDefault(x => x.Question.VarName.RefVarName.Equals(item.Text));
                    if (q == null) continue;
                    item.Tag = q;
                }
                
                lstMatches.Items.Add(li);
            }
            
            foreach (ListViewItem item in lstMatches.Items)
            {
                int columnCounter = 1;
                for (int s = 0; s < Surveys.Count; s++)
                {
                    for (int p = 0; p < ShownProducts.Count; p++)
                    {
                        if (string.IsNullOrEmpty(item.SubItems[columnCounter].Text))
                            item.SubItems[columnCounter].Tag = Surveys[s].SurveyCode;

                        columnCounter++;
                    }
                }
            }

            lstMatches.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        /// Add a listview for each product in the survey. Then resize the panel so they are all visible.
        /// </summary>
        void MakeList()
        {
            foreach (DataGridViewRow row in dgvSurveys.Rows)
            {
                Survey survey = Surveys.First(x => x.SurveyCode == (string)row.Cells[0].Value);
                foreach (DataGridViewColumn column in dgvSurveys.Columns)
                {
                    if (column.Index == 0) continue;
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[column.Name];
                    if (!(bool)cell.FormattedValue) continue;

                    ColumnHeader listColumn = new ColumnHeader();

                    ProductLabel product = ProductLabels.First(x => x.ID == (int)column.Tag);

                    if (!ShownProducts.Contains(product)) ShownProducts.Add(product);

                    listColumn.Name = "ch" + survey.SurveyCode + "_" + product.LabelText;
                    listColumn.Text = survey.SurveyCode + " " + product.LabelText;
                    listColumn.Tag = product.ID;

                    lstMatches.Columns.Add(listColumn);
                }
            }
        }

        private void ClearList()
        {
            lstMatches.Items.Clear();
            for (int i = 1; i < lstMatches.Columns.Count; )
            {
                lstMatches.Columns.RemoveAt(i);
            }
        }

        private void GetData(List<Survey> surveys)
        {
            foreach (Survey survey in surveys)
            {
                survey.Questions.AddRange(DBAction.GetSurveyQuestions(survey));
                var records = DBAction.GetParallelQuestions(survey.SurveyCode);
                Records.AddRange(records);
                foreach (ParallelQuestion pq in records)
                {
                    var mainListQ = survey.Questions.FirstOrDefault(x => x.ID == pq.Question.ID);

                    if (mainListQ != null)
                    {
                        pq.Question = mainListQ;
                        survey.Questions.Remove(mainListQ);
                    }
                }
            }
        }

        void RefreshProducts()
        {
            foreach (Survey survey in Surveys)
            {
                var products = DBAction.GetProductLabels(survey.SurveyCode);
                products = products.Except(ProductLabels).ToList();
                ProductLabels.AddRange(products);

                foreach (ProductLabel product in products)
                {
                    DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                    col.Name = "ch" + product.ID;
                    col.HeaderText = product.LabelText;
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    col.Tag = product.ID;
                    dgvSurveys.Columns.Add(col);
                }
            }
        }

        void SetReferenceItem(int x, int y)
        {
            ReferenceListItem = lstMatches.GetItemAt(x, y);
            ReferenceSubItem = ReferenceListItem.GetSubItemAt(x, y);
            ReferencePoint = new Point(x, y);

            if (string.IsNullOrEmpty(ReferenceSubItem.Text))
                ReferenceQuestion = null;
            else
                ReferenceQuestion = (ParallelQuestion)ReferenceSubItem.Tag;
        }

        private void SaveRecords()
        {
            foreach (ParallelQuestion pq in Deletes)
            {
                DBAction.DeleteRecord(pq);
            }

            foreach (ParallelQuestion pq in Moves)
            {
                DBAction.InsertParallelQuestion(pq);
            }

            foreach(var match in Adds.GroupBy(x => x))
            {
                List<ParallelQuestion> questions = match.Select(x => x).ToList();
                DBAction.InsertParallelQuestion(questions);
            }
        }

        private void PrintReport()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Match"));
            foreach (Survey survey in Surveys)
            {
                foreach (ProductLabel product in ShownProducts)
                {
                    DataColumn column = new DataColumn(survey.SurveyCode + " " + product.LabelText);
                    table.Columns.Add(column);
                }
            }

            var matches = Records.GroupBy(x => x.MatchID);
            foreach (var match in matches)
            {
                var questions = match.Select(x => x);

                List<string> items = new List<string>();
                items.Add(match.Key.ToString());

                foreach (Survey survey in Surveys)
                {
                    foreach (ProductLabel product in ShownProducts)
                    {
                        var question = questions.FirstOrDefault(x => x.Question.SurveyCode.Equals(survey.SurveyCode) && x.Question.VarName.Product.ID == product.ID);

                        if (question == null)
                        {
                            items.Add(string.Empty);
                        }
                        else
                        {
                            items.Add(question.Question.VarName.RefVarName + "\r\n" + question.Question.GetQuestionText());
                        }
                    }

                }
                DataRow row = table.NewRow();
                row.ItemArray = items.ToArray();



                table.Rows.Add(row);
            }

            DataTableReport report = new DataTableReport(table, "Parallel Questions");

            report.CreateReport();
        }

        #endregion

        

        

        

        

        
    }


}
