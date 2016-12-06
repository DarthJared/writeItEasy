using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private void conclusionIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.includeConclusion = conclusionIncludeCheck.Checked;
            int sectionHeight;
            if (sections.TryGetValue("CONCLUSION", out sectionHeight)) { }

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
            int abstractSectionHeight = 0;
            if (abstractActive)
            {
                if (sections.TryGetValue("ABSTRACT", out abstractSectionHeight)) { }
            }
            int headerSectionHeight = 0;
            if (headerActive)
            {
                if (sections.TryGetValue("HEADER", out headerSectionHeight)) { }
            }
            int footerSectionHeight = 0;
            if (footerActive)
            {
                if (sections.TryGetValue("FOOTER", out footerSectionHeight)) { }
            }
            int sectionsSectionHeight;
            if (sections.TryGetValue("SECTIONS", out sectionsSectionHeight)) { }

            int genY = generalPanel.Location.Y;
            conclusionPanel.Location = new Point(0,
                generalSectionHeight +
                titlePageSectionHeight +
                summarySectionHeight +
                abstractSectionHeight +
                headerSectionHeight +
                footerSectionHeight +
                sectionsSectionHeight +
                genY);

            /*Checked*/
            if (conclusionIncludeCheck.Checked)
            {
                myPaper.includeConclusion = true;
                contentPanel.Height += 295;
                int newY = addSectionButton.Location.Y + addSectionButton.Height + 20;
                conclusionContentGroupBox.Location = new Point(9, newY);
                conclusionContentGroupBox.Visible = true;

                conclusionPanel.Visible = true;
                lowerSection(sectionHeight, "CONCLUSION");
                conclusionActive = true;
            }
            /*Unchecked*/
            else
            {
                myPaper.includeConclusion = false;
                contentPanel.Height -= 295;
                conclusionContentGroupBox.Visible = false;

                conclusionPanel.Visible = false;
                raiseSection(sectionHeight, "CONCLUSION");
                conclusionActive = false;
            }         
        }

        private void conclusionIncludeTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.conclusion.includeTitle = conclusionIncludeTitleCheck.Checked;
            if (conclusionIncludeTitleCheck.Checked)
            {
                lowerSection(105, "CONCLUSION");
                sections["CONCLUSION"] += 105;
                conclusionPanel.Height += 105;
                conclusionDefaultButton.Location = new Point(9, 198);
                conclusionOptionsGroupBox.Height = 230;
                conclusionTitleGroupBox.Height = 150;
                conclusionTitleLabel.Enabled = true;
                conclusionTitleEnter.Enabled = true;
                conclusionTitleAlignChoose.Visible = true;
                conclusionTitleAlignLabel.Visible = true;
                conclusionTitleBoldCheck.Visible = true;
                conclusionTitleFontLabel.Visible = true;
                conclusionTitleFontChoose.Visible = true;
                conclusionTitleSizeLabel.Visible = true;
                conclusionTitleSizeChoose.Visible = true;
                conclusionTitleColorLabel.Visible = true;
                conclusionTitleColorText.Visible = true;
                conclusionTitleColorButton.Visible = true;
            }
            else
            {
                conclusionTitleLabel.Enabled = false;
                conclusionTitleEnter.Enabled = false;
                conclusionTitleAlignChoose.Visible = false;
                conclusionTitleAlignLabel.Visible = false;
                conclusionTitleBoldCheck.Visible = false;
                conclusionTitleFontLabel.Visible = false;
                conclusionTitleFontChoose.Visible = false;
                conclusionTitleSizeLabel.Visible = false;
                conclusionTitleSizeChoose.Visible = false;
                conclusionTitleColorLabel.Visible = false;
                conclusionTitleColorText.Visible = false;
                conclusionTitleColorButton.Visible = false;
                conclusionTitleGroupBox.Height = 45;
                conclusionDefaultButton.Location = new Point(9, 93);
                conclusionOptionsGroupBox.Height = 125;
                conclusionPanel.Height -= 105;
                sections["CONCLUSION"] -= 105;
                raiseSection(105, "CONCLUSION");
            }
        }
    }
}
