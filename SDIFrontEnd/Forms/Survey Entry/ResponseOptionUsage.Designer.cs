namespace SDIFrontEnd
{
    partial class ResponseOptionUsage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResponseOptionUsage));
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSearchClip = new System.Windows.Forms.Button();
            this.dgvWordingUsage = new System.Windows.Forms.DataGridView();
            this.lblUses = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.txtWordID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWordingR = new System.Windows.Forms.RichTextBox();
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
            this.cmdTextSearch = new System.Windows.Forms.Button();
            this.cmdCopyToNew = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWordingUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navWordings)).BeginInit();
            this.navWordings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(270, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(271, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Response Set Usage";
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(254, 62);
            this.cmdExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(445, 28);
            this.cmdExport.TabIndex = 4;
            this.cmdExport.Text = "Export to Survey Entry";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(705, 164);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(95, 28);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(705, 199);
            this.cmdDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(95, 28);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSearchClip
            // 
            this.cmdSearchClip.Location = new System.Drawing.Point(705, 234);
            this.cmdSearchClip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSearchClip.Name = "cmdSearchClip";
            this.cmdSearchClip.Size = new System.Drawing.Size(95, 28);
            this.cmdSearchClip.TabIndex = 7;
            this.cmdSearchClip.Text = "Clip Search";
            this.cmdSearchClip.UseVisualStyleBackColor = true;
            this.cmdSearchClip.Click += new System.EventHandler(this.cmdSearchClip_Click);
            // 
            // dgvWordingUsage
            // 
            this.dgvWordingUsage.AllowUserToAddRows = false;
            this.dgvWordingUsage.AllowUserToDeleteRows = false;
            this.dgvWordingUsage.AllowUserToResizeRows = false;
            this.dgvWordingUsage.Location = new System.Drawing.Point(11, 320);
            this.dgvWordingUsage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvWordingUsage.Name = "dgvWordingUsage";
            this.dgvWordingUsage.ReadOnly = true;
            this.dgvWordingUsage.RowHeadersVisible = false;
            this.dgvWordingUsage.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvWordingUsage.Size = new System.Drawing.Size(789, 191);
            this.dgvWordingUsage.TabIndex = 9;
            this.dgvWordingUsage.VirtualMode = true;
            this.dgvWordingUsage.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvWordingUsage_CellValueNeeded);
            // 
            // lblUses
            // 
            this.lblUses.AutoSize = true;
            this.lblUses.Location = new System.Drawing.Point(291, 300);
            this.lblUses.Name = "lblUses";
            this.lblUses.Size = new System.Drawing.Size(293, 16);
            this.lblUses.TabIndex = 10;
            this.lblUses.Text = "This response set appears in the following places.";
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(51, 65);
            this.txtFieldName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.ReadOnly = true;
            this.txtFieldName.Size = new System.Drawing.Size(74, 23);
            this.txtFieldName.TabIndex = 11;
            // 
            // txtWordID
            // 
            this.txtWordID.Location = new System.Drawing.Point(169, 63);
            this.txtWordID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWordID.Name = "txtWordID";
            this.txtWordID.Size = new System.Drawing.Size(69, 23);
            this.txtWordID.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Field";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "W#";
            // 
            // txtWordingR
            // 
            this.txtWordingR.BackColor = System.Drawing.SystemColors.Window;
            this.txtWordingR.Location = new System.Drawing.Point(11, 129);
            this.txtWordingR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWordingR.Name = "txtWordingR";
            this.txtWordingR.ReadOnly = true;
            this.txtWordingR.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtWordingR.Size = new System.Drawing.Size(688, 168);
            this.txtWordingR.TabIndex = 16;
            this.txtWordingR.Text = "";
            this.txtWordingR.Validated += new System.EventHandler(this.txtWordingR_Validated);
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
            this.navWordings.Location = new System.Drawing.Point(0, 514);
            this.navWordings.MoveFirstItem = null;
            this.navWordings.MoveLastItem = null;
            this.navWordings.MoveNextItem = null;
            this.navWordings.MovePreviousItem = null;
            this.navWordings.Name = "navWordings";
            this.navWordings.PositionItem = this.bindingNavigatorPositionItem;
            this.navWordings.Size = new System.Drawing.Size(812, 25);
            this.navWordings.TabIndex = 17;
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
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(58, 23);
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
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdTextSearch
            // 
            this.cmdTextSearch.Location = new System.Drawing.Point(705, 269);
            this.cmdTextSearch.Name = "cmdTextSearch";
            this.cmdTextSearch.Size = new System.Drawing.Size(95, 28);
            this.cmdTextSearch.TabIndex = 19;
            this.cmdTextSearch.Text = "Text Search";
            this.cmdTextSearch.UseVisualStyleBackColor = true;
            this.cmdTextSearch.Click += new System.EventHandler(this.cmdTextSearch_Click);
            // 
            // cmdCopyToNew
            // 
            this.cmdCopyToNew.Location = new System.Drawing.Point(705, 129);
            this.cmdCopyToNew.Name = "cmdCopyToNew";
            this.cmdCopyToNew.Size = new System.Drawing.Size(95, 28);
            this.cmdCopyToNew.TabIndex = 20;
            this.cmdCopyToNew.Text = "Copy To New";
            this.cmdCopyToNew.UseVisualStyleBackColor = true;
            this.cmdCopyToNew.Click += new System.EventHandler(this.cmdCopyToNew_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(652, 95);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(47, 28);
            this.cmdEdit.TabIndex = 23;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // ResponseOptionUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(217)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(812, 539);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdCopyToNew);
            this.Controls.Add(this.cmdTextSearch);
            this.Controls.Add(this.navWordings);
            this.Controls.Add(this.txtWordingR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWordID);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.lblUses);
            this.Controls.Add(this.dgvWordingUsage);
            this.Controls.Add(this.cmdSearchClip);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResponseOptionUsage";
            this.Text = "Response Set Usage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResponseOptionUsage_FormClosing);
            this.Load += new System.EventHandler(this.ResponseOptionUsage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWordingUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navWordings)).EndInit();
            this.navWordings.ResumeLayout(false);
            this.navWordings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdSearchClip;
        private System.Windows.Forms.DataGridView dgvWordingUsage;
        private System.Windows.Forms.Label lblUses;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.TextBox txtWordID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtWordingR;
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
        private System.Windows.Forms.Button cmdTextSearch;
        private System.Windows.Forms.Button cmdCopyToNew;
        private System.Windows.Forms.Button cmdEdit;
    }
}