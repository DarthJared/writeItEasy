using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private void abstractIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
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
                addSpace("section1GroupBox", 295, "contentPanel", "CONTENT");
                abstractContentGroupBox.Location = new Point(9, section1groupBox.Location.Y - 295);
                abstractContentGroupBox.Visible = true;

                abstractPanel.Visible = true;
                lowerSection(sectionHeight, "ABSTRACT");
                abstractActive = true;
            }
            /*Unchecked*/
            else
            {
                addSpace("section1GroupBox", -295, "contentPanel", "CONTENT");
                abstractContentGroupBox.Visible = false;

                abstractPanel.Visible = false;
                raiseSection(sectionHeight, "ABSTRACT");
                abstractActive = false;
            }
        }

        private void abstractIncludeTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (abstractIncludeTitleCheck.Checked)
            {
                abstractTitleGroupBox.Height = 150;
                abstractDefaultButton.Location = new Point(9, 198);
                abstractOptionsGroupBox.Height += 105;
                abstractPanel.Height += 105;
                abstractTitleLabel.Enabled = true;
                abstractTitleText.Enabled = true;
                abstractTitleAlignLabel.Visible = true;
                abstractTitleAlignSelect.Visible = true;
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
                abstractTitleAlignLabel.Visible = false;
                abstractTitleAlignSelect.Visible = false;
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
