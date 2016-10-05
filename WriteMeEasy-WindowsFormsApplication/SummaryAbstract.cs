using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private void summaryIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.includeSummary = summaryIncludeCheck.Checked;
            int sectionHeight;
            if (sections.TryGetValue("SUMMARY", out sectionHeight)) { }
            int generalSectionHeight;
            if (sections.TryGetValue("GENERAL", out generalSectionHeight)) { }
            int titlePageSectionHeight = 0;
            if (titlePageActive)
            {
                if (sections.TryGetValue("TITLE_PAGE", out titlePageSectionHeight)) { }
            }

            int genY = generalPanel.Location.Y;
            summaryPanel.Location = new Point(0,
                generalSectionHeight +
                titlePageSectionHeight +
                genY);

            /*Checked*/
            if (summaryIncludeCheck.Checked)
            {                
                if (abstractIncludeCheck.Checked)
                {
                    addSpace("abstractContentGroupBox", 312, "contentPanel", "CONTENT");
                }
                else
                {
                    addSpace("section1GroupBox", 312, "contentPanel", "CONTENT");
                }
                summaryContentGroupBox.Location = new Point(9, 36);
                summaryContentGroupBox.Visible = true;

                summaryPanel.Visible = true;
                lowerSection(sectionHeight, "SUMMARY");
                summaryActive = true;
            }
            /*Unchecked*/
            else
            {
                if (abstractIncludeCheck.Checked)
                {
                    addSpace("abstractContentGroupBox", -312, "contentPanel", "CONTENT");
                }
                else
                {
                    addSpace("section1GroupBox", -312, "contentPanel", "CONTENT");
                }
                summaryContentGroupBox.Visible = false;

                summaryPanel.Visible = false;
                raiseSection(sectionHeight, "SUMMARY");
                summaryActive = false;
            }
            checkContentPanelHeight();
        }

        private void abstractIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.includeAbstract = abstractIncludeCheck.Checked;
            int sectionHeight;
            if (sections.TryGetValue("ABSTRACT", out sectionHeight)) { }

            int generalSectionHeight;
            if (sections.TryGetValue("GENERAL", out generalSectionHeight)) { }
            int titlePageSectionHeight = 0;
            if (titlePageActive)
            {
                if (sections.TryGetValue("TITLE_PAGE", out titlePageSectionHeight)) { }
            }
            int summarySectionHeight = 0;
            if (summaryActive)
            {
                if (sections.TryGetValue("SUMMARY", out summarySectionHeight)) { }
            }

            int genY = generalPanel.Location.Y;
            abstractPanel.Location = new Point(0,
                generalSectionHeight +
                titlePageSectionHeight +
                summarySectionHeight +
                genY);

            /*Checked*/
            if (abstractIncludeCheck.Checked)
            {
                addSpace("section1GroupBox", 312, "contentPanel", "CONTENT");
                abstractContentGroupBox.Location = new Point(9, section1groupBox.Location.Y - 312);
                abstractContentGroupBox.Visible = true;

                abstractPanel.Visible = true;
                lowerSection(sectionHeight, "ABSTRACT");
                abstractActive = true;
            }
            /*Unchecked*/
            else
            {
                addSpace("section1GroupBox", -312, "contentPanel", "CONTENT");
                abstractContentGroupBox.Visible = false;

                abstractPanel.Visible = false;
                raiseSection(sectionHeight, "ABSTRACT");
                abstractActive = false;
            }
            checkContentPanelHeight();
        }

        private void summaryIncludeTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.summary.includeTitle = summaryIncludeTitleCheck.Checked;
            if (summaryIncludeTitleCheck.Checked)
            {
                summaryTitleGroupBox.Height = 150;
                summaryDefaultButton.Location = new Point(9, 198);
                summaryOptionsGroupBox.Height += 105;
                summaryPanel.Height += 105;
                summaryTitleTextLabel.Enabled = true;
                summaryTitleText.Enabled = true;
                summaryTitleBoldCheck.Visible = true;
                summaryTitleFontLabel.Visible = true;
                summaryTitleFontChoose.Visible = true;
                summaryTitleSizeLabel.Visible = true;
                summaryTitleSizeChoose.Visible = true;
                summaryTitleColorLabel.Visible = true;
                summaryTitleColorText.Visible = true;
                summaryTitleColorButton.Visible = true;
                lowerSection(105, "SUMMARY");
                sections["SUMMARY"] += 105;
            }
            else
            {
                summaryTitleTextLabel.Enabled = false;
                summaryTitleText.Enabled = false;
                summaryTitleBoldCheck.Visible = false;
                summaryTitleFontLabel.Visible = false;
                summaryTitleFontChoose.Visible = false;
                summaryTitleSizeLabel.Visible = false;
                summaryTitleSizeChoose.Visible = false;
                summaryTitleColorLabel.Visible = false;
                summaryTitleColorText.Visible = false;
                summaryTitleColorButton.Visible = false;
                summaryTitleGroupBox.Height = 45;
                summaryDefaultButton.Location = new Point(9, 93);
                summaryOptionsGroupBox.Height = 125;
                summaryPanel.Height -= 105;
                raiseSection(105, "SUMMARY");
                sections["SUMMARY"] -= 105;
            }
        }

        private void abstractIncludeTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.abstractConfig.includeTitle = abstractIncludeTitleCheck.Checked;
            if (abstractIncludeTitleCheck.Checked)
            {
                abstractTitleGroupBox.Height = 150;
                abstractDefaultButton.Location = new Point(9, 198);
                abstractOptionsGroupBox.Height += 105;
                abstractPanel.Height += 105;
                abstractTitleLabel.Enabled = true;
                abstractTitleText.Enabled = true;
                abstractTitleBoldCheck.Visible = true;
                abstractTitleFontLabel.Visible = true;
                abstractTitleFontChoose.Visible = true;
                abstractTitleSizeLabel.Visible = true;
                abstractTitleSizeChoose.Visible = true;
                abstractTitleColorLabel.Visible = true;
                abstractTitleColorText.Visible = true;
                abstractTitleColorButton.Visible = true;
                lowerSection(105, "ABSTRACT");
                sections["ABSTRACT"] += 105;
            }
            else
            {
                abstractTitleLabel.Enabled = false;
                abstractTitleText.Enabled = false;
                abstractTitleBoldCheck.Visible = false;
                abstractTitleFontLabel.Visible = false;
                abstractTitleFontChoose.Visible = false;
                abstractTitleSizeLabel.Visible = false;
                abstractTitleSizeChoose.Visible = false;
                abstractTitleColorLabel.Visible = false;
                abstractTitleColorText.Visible = false;
                abstractTitleColorButton.Visible = false;
                abstractTitleGroupBox.Height = 45;
                abstractDefaultButton.Location = new Point(9, 93);
                abstractOptionsGroupBox.Height = 125;
                abstractPanel.Height -= 105;
                raiseSection(105, "ABSTRACT");
                sections["ABSTRACT"] -= 105;
            }
        }
    }
}
