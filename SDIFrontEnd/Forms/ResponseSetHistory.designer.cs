namespace SDIFrontEnd
{
    partial class ResponseSetHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResponseSetHistory));
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.cmdPrev = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbWordingPrev = new System.Windows.Forms.RichTextBox();
            this.rtbWording = new System.Windows.Forms.RichTextBox();
            this.rtbWordingNext = new System.Windows.Forms.RichTextBox();
            this.navWordings = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtChangeTypePrev = new System.Windows.Forms.TextBox();
            this.txtChangeType = new System.Windows.Forms.TextBox();
            this.txtChangeTypeNext = new System.Windows.Forms.TextBox();
            this.txtUpdateDatePrev = new System.Windows.Forms.TextBox();
            this.txtUpdateDate = new System.Windows.Forms.TextBox();
            this.txtUpdateDateNext = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.navWordings)).BeginInit();
            this.navWordings.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(529, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 0;
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(357, 12);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(100, 20);
            this.txtFieldName.TabIndex = 1;
            // 
            // cmdPrev
            // 
          //  this.cmdPrev.Image = global::QuestionHistory.Properties.Resources.leftArrow;
            this.cmdPrev.Location = new System.Drawing.Point(12, 141);
            this.cmdPrev.Name = "cmdPrev";
            this.cmdPrev.Size = new System.Drawing.Size(52, 58);
            this.cmdPrev.TabIndex = 5;
            this.cmdPrev.Text = "<-";
            this.cmdPrev.UseVisualStyleBackColor = true;
            this.cmdPrev.Click += new System.EventHandler(this.cmdPrev_Click);
            // 
            // cmdNext
            // 
           // this.cmdNext.Image = global::QuestionHistory.Properties.Resources.rightArrow;
            this.cmdNext.Location = new System.Drawing.Point(966, 141);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(59, 58);
            this.cmdNext.TabIndex = 6;
            this.cmdNext.Text = "->";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "RespName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Resp Type";
            // 
            // rtbWordingPrev
            // 
            this.rtbWordingPrev.Location = new System.Drawing.Point(70, 86);
            this.rtbWordingPrev.Name = "rtbWordingPrev";
            this.rtbWordingPrev.Size = new System.Drawing.Size(280, 249);
            this.rtbWordingPrev.TabIndex = 9;
            this.rtbWordingPrev.Text = "";
            // 
            // rtbWording
            // 
            this.rtbWording.Location = new System.Drawing.Point(375, 86);
            this.rtbWording.Name = "rtbWording";
            this.rtbWording.Size = new System.Drawing.Size(280, 249);
            this.rtbWording.TabIndex = 10;
            this.rtbWording.Text = "";
            // 
            // rtbWordingNext
            // 
            this.rtbWordingNext.Location = new System.Drawing.Point(680, 86);
            this.rtbWordingNext.Name = "rtbWordingNext";
            this.rtbWordingNext.Size = new System.Drawing.Size(280, 249);
            this.rtbWordingNext.TabIndex = 11;
            this.rtbWordingNext.Text = "";
            // 
            // navWordings
            // 
            this.navWordings.AddNewItem = null;
            this.navWordings.CountItem = this.bindingNavigatorCountItem;
            this.navWordings.DeleteItem = null;
            this.navWordings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navWordings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.navWordings.Location = new System.Drawing.Point(0, 350);
            this.navWordings.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.navWordings.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.navWordings.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.navWordings.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.navWordings.Name = "navWordings";
            this.navWordings.PositionItem = this.bindingNavigatorPositionItem;
            this.navWordings.Size = new System.Drawing.Size(1036, 25);
            this.navWordings.TabIndex = 12;
            this.navWordings.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtChangeTypePrev
            // 
            this.txtChangeTypePrev.Location = new System.Drawing.Point(285, 57);
            this.txtChangeTypePrev.Name = "txtChangeTypePrev";
            this.txtChangeTypePrev.Size = new System.Drawing.Size(65, 20);
            this.txtChangeTypePrev.TabIndex = 16;
            // 
            // txtChangeType
            // 
            this.txtChangeType.Location = new System.Drawing.Point(590, 57);
            this.txtChangeType.Name = "txtChangeType";
            this.txtChangeType.Size = new System.Drawing.Size(65, 20);
            this.txtChangeType.TabIndex = 17;
            // 
            // txtChangeTypeNext
            // 
            this.txtChangeTypeNext.Location = new System.Drawing.Point(895, 57);
            this.txtChangeTypeNext.Name = "txtChangeTypeNext";
            this.txtChangeTypeNext.Size = new System.Drawing.Size(65, 20);
            this.txtChangeTypeNext.TabIndex = 18;
            // 
            // txtUpdateDatePrev
            // 
            this.txtUpdateDatePrev.Location = new System.Drawing.Point(70, 57);
            this.txtUpdateDatePrev.Name = "txtUpdateDatePrev";
            this.txtUpdateDatePrev.Size = new System.Drawing.Size(209, 20);
            this.txtUpdateDatePrev.TabIndex = 19;
            // 
            // txtUpdateDate
            // 
            this.txtUpdateDate.Location = new System.Drawing.Point(375, 57);
            this.txtUpdateDate.Name = "txtUpdateDate";
            this.txtUpdateDate.Size = new System.Drawing.Size(209, 20);
            this.txtUpdateDate.TabIndex = 20;
            // 
            // txtUpdateDateNext
            // 
            this.txtUpdateDateNext.Location = new System.Drawing.Point(680, 57);
            this.txtUpdateDateNext.Name = "txtUpdateDateNext";
            this.txtUpdateDateNext.Size = new System.Drawing.Size(209, 20);
            this.txtUpdateDateNext.TabIndex = 21;
            // 
            // ResponseSetHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 375);
            this.Controls.Add(this.txtUpdateDateNext);
            this.Controls.Add(this.txtUpdateDate);
            this.Controls.Add(this.txtUpdateDatePrev);
            this.Controls.Add(this.txtChangeTypeNext);
            this.Controls.Add(this.txtChangeType);
            this.Controls.Add(this.txtChangeTypePrev);
            this.Controls.Add(this.navWordings);
            this.Controls.Add(this.rtbWordingNext);
            this.Controls.Add(this.rtbWording);
            this.Controls.Add(this.rtbWordingPrev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdPrev);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.txtID);
            this.Name = "ResponseSetHistory";
            this.Text = "Response History";
            ((System.ComponentModel.ISupportInitialize)(this.navWordings)).EndInit();
            this.navWordings.ResumeLayout(false);
            this.navWordings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.Button cmdPrev;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbWordingPrev;
        private System.Windows.Forms.RichTextBox rtbWording;
        private System.Windows.Forms.RichTextBox rtbWordingNext;
        private System.Windows.Forms.BindingNavigator navWordings;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox txtChangeTypePrev;
        private System.Windows.Forms.TextBox txtChangeType;
        private System.Windows.Forms.TextBox txtChangeTypeNext;
        private System.Windows.Forms.TextBox txtUpdateDatePrev;
        private System.Windows.Forms.TextBox txtUpdateDate;
        private System.Windows.Forms.TextBox txtUpdateDateNext;
    }
}