using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDIFrontEnd
{
    public partial class ExtraRichTextBox : UserControl
    {
        public bool ShowFamilies { get; set; }
        public bool ShowSize { get; set; }
        public override string Text { get { return txtFunctionality.Text; } set { if (txtFunctionality.Text != value) txtFunctionality.Text = value; } }
        public string Rtf { get { return txtFunctionality.Rtf; } set { if (txtFunctionality.Rtf != value) txtFunctionality.Rtf = value; } }

        private bool _maskChanges;
        RichTextBox txtTextContent;

        public ExtraRichTextBox()
        {
            InitializeComponent();
            LoadData();
            txtTextContent = new RichTextBox();
            DisplayData();
        }

        private void DisplayData()
        {
            //dummy data to preview
            //txtFunctionality.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Tahoma;}{\f1\fnil\fcharset0 Times New Roman;}}\viewkind4\uc1\pard\b\f0\fs18 W\b0 indows 8.1, Windows Server 2012 R2, \b Windows\b0  8, Windows Server 2012, Windows 7, Windows Vista SP2, Windows Server 2008 (Server Core Role not supported), Windows Server 2008 \fs24 R2 (Server \fs18 Core Role \ul supported with SP1 \ulnone or later; Itanium \fs24 not supported\fs18 ).NET Framework does not support all versions of \fs26 every\f1  platform. For \f0 a list of \fs18 the supported versions, see .NET Framework System Requirements.\par}";

            GoToFirstPositionAndHighlightToolbar();
        }

        private void LoadData()
        {
            LoadRichTextEditorData();
        }

        private void LoadRichTextEditorData()
        {
            if (ShowFamilies)
            {
                string[] availableFontFamilies;

                //check to see if fonts are installed on machine
                try
                {
                    availableFontFamilies = new string[] {
                new FontFamily("Arial").Name,
                new FontFamily("Microsoft Sans Serif").Name,
                new FontFamily("Tahoma").Name,
                new FontFamily("Times New Roman").Name
                };
                }
                catch (ArgumentException e)
                {
                    throw new Exception("Font not present: " + e.Message);
                }
                cmbFontFamily.Items.AddRange(availableFontFamilies);
            }

            cmbFontFamily.Visible = ShowFamilies;

            if (ShowSize)
            {
                List<object> availableFontSizes = new List<object>();

                for (float i = 8; i <= 14; i++)
                    availableFontSizes.Add(i);

                cmbFontSize.Items.AddRange(availableFontSizes.ToArray());
            }
            cmbFontSize.Visible = ShowSize;
            
        }

        private void ckbBold_CheckedChanged(object sender, EventArgs e)
        {
            if (_maskChanges)
                return;

            ChangeOrSetFont(string.Empty, null, FontStyle.Bold, ckbBold.Checked);
            txtFunctionality.Focus();
        }

        private void ckbItalic_CheckedChanged(object sender, EventArgs e)
        {
            if (_maskChanges)
                return;

            ChangeOrSetFont(string.Empty, null, FontStyle.Italic, ckbItalic.Checked);
            txtFunctionality.Focus();
        }

        private void ckbUnderline_CheckedChanged(object sender, EventArgs e)
        {
            if (_maskChanges)
                return;

            ChangeOrSetFont(string.Empty, null, FontStyle.Underline, ckbUnderline.Checked);
            txtFunctionality.Focus();
        }

        private void cmbFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_maskChanges)
                return;

            ChangeOrSetFont(cmbFontFamily.SelectedItem.ToString(), null, null, null);
            txtFunctionality.Focus();
        }

        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_maskChanges)
                return;
            ChangeOrSetFont(null, float.Parse(cmbFontSize.SelectedItem.ToString()), null, null);
            txtFunctionality.Focus();
        }

        private void ChangeOrSetFont(string familyName, float? emSize, FontStyle? fontStyle, bool? enableFontStyle)
        {
            if (txtFunctionality.SelectionType == RichTextBoxSelectionTypes.Empty)
            {
                SetSelectionFont(familyName, emSize, fontStyle, enableFontStyle);
            }
            else
            {
                ChangeFontStyleForSelectedText(familyName, emSize, fontStyle, enableFontStyle);
            }
        }

        private void SetSelectionFont(string familyName, float? emSize, FontStyle? fontStyle, bool? enableFontStyle)
        {
            Font renderedFont = RenderFont(txtFunctionality.SelectionFont, familyName, emSize, fontStyle, enableFontStyle);
            txtFunctionality.SelectionFont = renderedFont;
        }

        private void ChangeFontStyleForSelectedText(string familyName, float? emSize, FontStyle? fontStyle, bool? enableFontStyle)
        {
            _maskChanges = true;
            try
            {
                int txtStartPosition = txtFunctionality.SelectionStart;
                int selectionLength = txtFunctionality.SelectionLength;
                if (selectionLength > 0)
                    using (RichTextBox txtTemp = new RichTextBox())
                    {
                        txtTemp.Rtf = txtFunctionality.SelectedRtf;
                        for (int i = 0; i < selectionLength; ++i)
                        {
                            txtTemp.Select(i, 1);
                            txtTemp.SelectionFont = RenderFont(txtTemp.SelectionFont, familyName, emSize, fontStyle, enableFontStyle);
                        }

                        txtTemp.Select(0, selectionLength);
                        txtFunctionality.SelectedRtf = txtTemp.SelectedRtf;
                        txtFunctionality.Select(txtStartPosition, selectionLength);
                    }
            }
            finally
            {
                _maskChanges = false;
            }
        }

        /// 

        /// Changes a font from originalFont appending other properties
        /// 

        /// Original font of text
        /// Target family name
        /// Target text Size
        /// Target font style
        /// true when enable false when disable
        /// A new font with all provided properties added/removed to original font
        private Font RenderFont(Font originalFont, string familyName, float? emSize, FontStyle? fontStyle, bool? enableFontStyle)
        {
            if (fontStyle.HasValue && fontStyle != FontStyle.Regular && fontStyle != FontStyle.Bold && fontStyle != FontStyle.Italic && fontStyle != FontStyle.Underline)
                throw new System.InvalidProgramException("Invalid style parameter to ChangeFontStyleForSelectedText");

            Font newFont;
            FontStyle? newStyle = null;
            if (fontStyle.HasValue)
            {
                if (fontStyle.HasValue && fontStyle == FontStyle.Regular)
                    newStyle = fontStyle.Value;
                else if (originalFont != null && enableFontStyle.HasValue && enableFontStyle.Value)
                    newStyle = originalFont.Style | fontStyle.Value;
                else
                    newStyle = originalFont.Style & ~fontStyle.Value;
            }

            newFont = new Font(!string.IsNullOrEmpty(familyName) ? familyName : originalFont.FontFamily.Name,
                                emSize.HasValue ? emSize.Value : originalFont.Size,
                                newStyle.HasValue ? newStyle.Value : originalFont.Style);
            return newFont;
        }

        private void txtFunctionality_SelectionChanged(object sender, EventArgs e)
        {
            if (_maskChanges)
                return;

            if (string.IsNullOrEmpty(txtFunctionality.Text))
            {
                //clear all text with its ex-formatting
                txtFunctionality.Clear();
                LoadAndSetDefaultFont();
            }
            else
            {
                ScanSelectedTextAndHighlightToolbar();
            }
        }

        private void txtFunctionality_KeyDown(object sender, KeyEventArgs e)
        {
            if (_maskChanges)
                return;

            if (e.Control && e.KeyCode == Keys.B)
            {
                ckbBold.Checked = !ckbBold.Checked;
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.I)
            {
                ckbItalic.Checked = !ckbItalic.Checked;
                e.Handled = true;
                e.SuppressKeyPress = true; //avoid executing 'Insert TAB' for CTRL + I
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                ckbUnderline.Checked = !ckbUnderline.Checked;
                e.Handled = true;
            }
        }

        private void GoToFirstPositionAndHighlightToolbar()
        {
            _maskChanges = true;
            try
            {
                if (!string.IsNullOrEmpty(txtFunctionality.Text))
                {
                    txtFunctionality.Suspend();
                    txtFunctionality.Select(0, 1);

                    using (RichTextBox txtTemp = new RichTextBox())
                    {
                        txtTemp.Rtf = txtFunctionality.SelectedRtf;
                        Font currFont = txtTemp.SelectionFont;

                        HighlightToolbar(currFont.FontFamily.Name, currFont.Size, currFont.Bold, currFont.Italic, currFont.Underline);
                    }
                    txtFunctionality.Select(0, 0);
                    txtFunctionality.Resume();
                }
                else
                {
                    LoadAndSetDefaultFont();
                }
            }
            finally
            {
                _maskChanges = false;
            }
        }

        private Font GetFontFromToolbar()
        {
            FontStyle toolbarFontStyle = new FontStyle();
            if (ckbBold.Checked)
                toolbarFontStyle |= FontStyle.Bold;
            if (ckbItalic.Checked)
                toolbarFontStyle |= FontStyle.Italic;
            if (ckbUnderline.Checked)
                toolbarFontStyle |= FontStyle.Underline;

            Font font = new Font(cmbFontFamily.SelectedItem.ToString(), (float)cmbFontSize.SelectedItem, toolbarFontStyle);
            return font;
        }

        //could be changed into an extentension 
        public string TrimLastChar(string text)
        {
            if (text.Length >= 1)
                return text.Substring(0, text.Length - 1);
            else
                return text;
        }

        private void LoadAndSetDefaultFont()
        {
            Font font = txtFunctionality.Font;
            HighlightToolbar(font.FontFamily.Name, font.Size, font.Bold, font.Italic, font.Underline);

            SetSelectionFont(font.FontFamily.Name, font.Size, font.Style, null);
        }

        private void ScanSelectedTextAndHighlightToolbar()
        {
            _maskChanges = true;
            try
            {
                if (txtFunctionality.SelectionType == RichTextBoxSelectionTypes.Empty)
                {
                    int selectionStart = txtFunctionality.SelectionStart != 0 ? txtFunctionality.SelectionStart - 1 : 0;
                    int selectionEnd = txtFunctionality.SelectionStart;

                    txtFunctionality.Suspend();
                    //case when passes to a new line - it looses font style so must get from Tooolbar
                    if (TrimLastChar(txtTextContent.Text).EndsWith("\n"))
                    {
                        txtTextContent.Select(selectionStart, 1);
                        txtTextContent.SelectionFont = GetFontFromToolbar();
                        txtTextContent.Select(selectionEnd, 0);
                    }
                    else
                    {
                        txtTextContent.Select(selectionStart, 1);
                        using (RichTextBox txtTemp = new RichTextBox())
                        {
                            txtTemp.Rtf = txtTextContent.SelectedRtf;
                            Font currFont = txtTemp.SelectionFont;

                            HighlightToolbar(currFont.FontFamily.Name, (float)Math.Truncate(currFont.Size), currFont.Bold, currFont.Italic, currFont.Underline);
                            txtTextContent.SelectionFont = currFont;
                        }
                        txtTextContent.Select(selectionEnd, 0);
                    }
                    txtFunctionality.Resume();
                }
                else
                    if (!string.IsNullOrEmpty(txtFunctionality.SelectedText))
                {
                    int txtStartPosition = txtFunctionality.SelectionStart;
                    int selectionLength = txtFunctionality.SelectionLength;

                    if (selectionLength > 0)
                        using (RichTextBox txtTemp = new RichTextBox())
                        {
                            txtTemp.Rtf = txtFunctionality.SelectedRtf;

                            if (selectionLength < 2)
                            {
                                FontFamily firstCharFontFamily = txtTemp.SelectionFont.FontFamily;
                                float firstCharSize = txtTemp.SelectionFont.Size;
                                bool isBold = txtTemp.SelectionFont.Bold;
                                bool isItalic = txtTemp.SelectionFont.Italic;
                                bool isUnderline = txtTemp.SelectionFont.Underline;

                                HighlightToolbar(firstCharFontFamily.Name, firstCharSize, isBold, isItalic, isUnderline);
                            }
                            else
                            {
                                txtTemp.Select(0, 1);
                                FontFamily firstCharFontFamily = txtTemp.SelectionFont.FontFamily;
                                float firstCharSize = txtTemp.SelectionFont.Size;
                                bool isBold = txtTemp.SelectionFont.Bold;
                                bool isItalic = txtTemp.SelectionFont.Italic;
                                bool isUnderline = txtTemp.SelectionFont.Underline;

                                bool sameFontFamily = true, sameFontSize = true;

                                for (int i = 1; i < selectionLength; i++)
                                {
                                    txtTemp.Select(i, 1);
                                    sameFontFamily = txtTemp.SelectionFont.FontFamily.Name == firstCharFontFamily.Name;
                                    sameFontSize = txtTemp.SelectionFont.Size == firstCharSize;
                                    isBold = isBold && txtTemp.SelectionFont.Bold;
                                    isItalic = isItalic && txtTemp.SelectionFont.Italic;
                                    isUnderline = isUnderline && txtTemp.SelectionFont.Underline;

                                    if (!sameFontFamily && !sameFontSize && !isBold && !isItalic && !isUnderline)
                                        break;
                                }

                                HighlightToolbar(sameFontFamily ? firstCharFontFamily.Name : string.Empty,
                                    sameFontSize ? firstCharSize : (float?)null,
                                    isBold, isItalic, isUnderline);
                            }
                        }
                }
            }
            finally
            {
                _maskChanges = false;
            }
        }

        private void HighlightToolbar(string commonFamilyName, float? emSize, bool? isBold, bool? isItalic, bool? isUnderline)
        {
            if (!string.IsNullOrEmpty(commonFamilyName))
                cmbFontFamily.SelectedItem = commonFamilyName;
            else
                cmbFontFamily.SelectedItem = null;

            if (emSize.HasValue)
                cmbFontSize.SelectedItem = (float)Math.Truncate(emSize.Value);
            else
                cmbFontSize.SelectedItem = null;

            if (isBold.HasValue)
            {
                ckbBold.CheckState = isBold.Value ? CheckState.Checked : CheckState.Unchecked;
            }
            else
                ckbBold.CheckState = CheckState.Unchecked;

            if (isItalic.HasValue)
            {
                ckbItalic.CheckState = isItalic.Value ? CheckState.Checked : CheckState.Unchecked;
            }
            else
                ckbItalic.CheckState = CheckState.Unchecked;

            if (isUnderline.HasValue)
            {
                ckbUnderline.CheckState = isUnderline.Value ? CheckState.Checked : CheckState.Unchecked;
            }
            else
                ckbUnderline.CheckState = CheckState.Unchecked;
        }
    }
}

