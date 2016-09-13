using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private void referencesIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            int sectionHeight;
            if (sections.TryGetValue("REFERENCES", out sectionHeight)) { }

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
            int conclusionSectionHeight = 0;
            if (conclusionActive)
            {
                if (sections.TryGetValue("CONCLUSION", out conclusionSectionHeight)) { }
            }

            int genY = generalPanel.Location.Y;
            referencesPanel.Location = new Point(0,
                generalSectionHeight +
                titlePageSectionHeight +
                summarySectionHeight +
                abstractSectionHeight +
                headerSectionHeight +
                footerSectionHeight +
                sectionsSectionHeight +
                conclusionSectionHeight +
                genY);

            /*Checked*/
            if (referencesIncludeCheck.Checked)
            {
                referencesPanel.Visible = true;
                lowerSection(sectionHeight, "REFERENCES");
                referencesActive = true;
            }
            /*Unchecked*/
            else
            {
                referencesPanel.Visible = false;
                raiseSection(sectionHeight, "REFERENCES");
                referencesActive = false;
            }
        }

        private void referencesTitleIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (referencesTitleIncludeCheck.Checked)
            {
                lowerSection(105, "REFERENCES");

                referencesIndentationGroupBox.Location = new Point(9, 178);
                referencesTitleGroupBox.Height = 150;
                referencesTitleLabel.Visible = true;
                referencesTitleEnter.Visible = true;
                referencesTitleBoldCheck.Visible = true;
                referencesTitleFontLabel.Visible = true;
                referencesTitleFontChoose.Visible = true;
                referencesTitleSizeLabel.Visible = true;
                referencesTitleSizeChoose.Visible = true;
                referencesTitleColorLabel.Visible = true;
                referencesTitleColorText.Visible = true;
                referencesTitleColorButton.Visible = true;
                if (referencesHangingIndentCheck.Checked)
                {
                    referencesDefaultButton.Location = new Point(9, 365);
                    referencesOptionsGroupBox.Height = 317;
                    referencesOrderChoose.Location = new Point(44, 284);
                    referencesOrderLabel.Location = new Point(6, 287);
                    referencesEmptyLineBetweenCheck.Location = new Point(9, 261);
                    referencesPanel.Height = 407;
                    sections["REFERENCES"] = 407;
                }
                else
                {
                    referencesDefaultButton.Location = new Point(9, 338);
                    referencesOptionsGroupBox.Height = 290;
                    referencesOrderChoose.Location = new Point(44, 257);
                    referencesOrderLabel.Location = new Point(6, 260);
                    referencesEmptyLineBetweenCheck.Location = new Point(9, 234);
                    referencesPanel.Height = 375;
                    sections["REFERENCES"] = 375;
                }

            }
            else
            {
                if (referencesHangingIndentCheck.Checked)
                {
                    referencesDefaultButton.Location = new Point(9, 260);
                    referencesOptionsGroupBox.Height = 212;
                    referencesOrderChoose.Location = new Point(44, 179);
                    referencesOrderLabel.Location = new Point(6, 182);
                    referencesEmptyLineBetweenCheck.Location = new Point(9, 156);
                    referencesPanel.Height = 302;
                    sections["REFERENCES"] = 302;
                }
                else
                {
                    referencesDefaultButton.Location = new Point(9, 233);
                    referencesOptionsGroupBox.Height = 185;
                    referencesOrderChoose.Location = new Point(44, 152);
                    referencesOrderLabel.Location = new Point(6, 155);
                    referencesEmptyLineBetweenCheck.Location = new Point(9, 129);
                    referencesPanel.Height = 270;
                    sections["REFERENCES"] = 270;
                }
                raiseSection(105, "REFERENCES");
                referencesTitleLabel.Visible = false;
                referencesTitleEnter.Visible = false;
                referencesTitleBoldCheck.Visible = false;
                referencesTitleFontLabel.Visible = false;
                referencesTitleFontChoose.Visible = false;
                referencesTitleSizeLabel.Visible = false;
                referencesTitleSizeChoose.Visible = false;
                referencesTitleColorLabel.Visible = false;
                referencesTitleColorText.Visible = false;
                referencesTitleColorButton.Visible = false;
                referencesTitleGroupBox.Height = 45;
                referencesIndentationGroupBox.Location = new Point(9, 73);
            }
        }

        private void referencesHangingIndentCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (referencesHangingIndentCheck.Checked)
            {
                referencesIndentationGroupBox.Height = 77;
                referencesIndentTabsLabel.Visible = true;
                referencesIndentTabsEnter.Visible = true;
                lowerSection(32, "REFERENCES");
                if (referencesTitleIncludeCheck.Checked)
                {
                    referencesDefaultButton.Location = new Point(9, 365);
                    referencesOptionsGroupBox.Height = 317;
                    referencesOrderChoose.Location = new Point(44, 284);
                    referencesOrderLabel.Location = new Point(6, 287);
                    referencesEmptyLineBetweenCheck.Location = new Point(9, 261);
                    referencesPanel.Height = 407;
                    sections["REFERENCES"] = 407;
                }
                else
                {
                    referencesDefaultButton.Location = new Point(9, 260);
                    referencesOptionsGroupBox.Height = 212;
                    referencesOrderChoose.Location = new Point(44, 179);
                    referencesOrderLabel.Location = new Point(6, 182);
                    referencesEmptyLineBetweenCheck.Location = new Point(9, 156);
                    referencesPanel.Height = 302;
                    sections["REFERENCES"] = 302;
                }
            }
            else
            {
                referencesIndentTabsLabel.Visible = false;
                referencesIndentTabsEnter.Visible = false;
                referencesIndentationGroupBox.Height = 45;
                raiseSection(32, "REFERENCES");
                if (referencesTitleIncludeCheck.Checked)
                {
                    referencesDefaultButton.Location = new Point(9, 338);
                    referencesOptionsGroupBox.Height = 290;
                    referencesOrderChoose.Location = new Point(44, 257);
                    referencesOrderLabel.Location = new Point(6, 260);
                    referencesEmptyLineBetweenCheck.Location = new Point(9, 234);
                    referencesPanel.Height = 375;
                    sections["REFERENCES"] = 375;
                }
                else
                {
                    referencesDefaultButton.Location = new Point(9, 233);
                    referencesOptionsGroupBox.Height = 185;
                    referencesOrderChoose.Location = new Point(44, 152);
                    referencesOrderLabel.Location = new Point(6, 155);
                    referencesEmptyLineBetweenCheck.Location = new Point(9, 129);
                    referencesPanel.Height = 270;
                    sections["REFERENCES"] = 270;
                }
            }
        }
    }
}
