using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private void headerIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            int sectionHeight;
            if (sections.TryGetValue("HEADER", out sectionHeight)) { }

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

            int genY = generalPanel.Location.Y;
            headerPanel.Location = new Point(0,
                generalSectionHeight +
                titlePageSectionHeight +
                summarySectionHeight +
                abstractSectionHeight +
                genY);

            /*Checked*/
            if (headerIncludeCheck.Checked)
            {
                headerPanel.Visible = true;
                lowerSection(sectionHeight, "HEADER");
                headerActive = true;
            }
            /*Unchecked*/
            else
            {
                headerPanel.Visible = false;
                raiseSection(sectionHeight, "HEADER");
                headerActive = false;
            }
        }

        private void headerFirstPageMoreCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (headerFirstPageMoreCheck.Checked)
            {
                lowerSection(339, "HEADER");
                sections["HEADER"] = 865;
                headerPanel.Height = 865;
                headerDefaultButton.Location = new Point(9, 829);
                headerOptionsGroupBox.Height = 788;
                headerFirstPageGroupBox.Height = 424;
                headerFirstPageLeftGroupBox.Visible = true;
                headerFirstPageRightGroupBox.Visible = true;
            }
            else
            {
                headerFirstPageLeftGroupBox.Visible = false;
                headerFirstPageRightGroupBox.Visible = false;
                headerFirstPageGroupBox.Height = 90;
                headerOptionsGroupBox.Height = 449;
                headerDefaultButton.Location = new Point(9, 490);
                headerPanel.Height = 526;
                sections["HEADER"] = 526;
                raiseSection(339, "HEADER");
            }
        }

        private void headerDiffFirstPageCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (headerDiffFirstPageCheck.Checked)
            {
                if (headerFirstPageMoreCheck.Checked)
                {
                    lowerSection(384, "HEADER");
                    sections["HEADER"] = 865;
                    headerPanel.Height = 865;
                    headerDefaultButton.Location = new Point(9, 829);
                    headerOptionsGroupBox.Height = 788;
                    headerFirstPageGroupBox.Height = 424;
                    headerFirstPageLeftGroupBox.Visible = true;
                    headerFirstPageRightGroupBox.Visible = true;
                }
                else
                {
                    lowerSection(45, "HEADER");
                    sections["HEADER"] = 526;
                    headerPanel.Height = 526;
                    headerDefaultButton.Location = new Point(9, 490);
                    headerOptionsGroupBox.Height = 449;
                    headerFirstPageGroupBox.Height = 90;
                }
                headerFirstPageUseRunningHeadCheck.Visible = true;
                headerFirstPageMoreCheck.Visible = true;
            }
            else
            {
                if (headerFirstPageMoreCheck.Checked)
                {
                    headerFirstPageLeftGroupBox.Visible = false;
                    headerFirstPageRightGroupBox.Visible = false;
                    raiseSection(384, "HEADER");
                }
                else
                {
                    raiseSection(45, "HEADER");
                }
                headerFirstPageUseRunningHeadCheck.Visible = false;
                headerFirstPageMoreCheck.Visible = false;
                headerFirstPageGroupBox.Height = 40;
                headerOptionsGroupBox.Height = 404;
                headerDefaultButton.Location = new Point(9, 445);
                headerPanel.Height = 481;
                sections["HEADER"] = 481;
            }
        }

        private void headerLeftChanged(object sender, EventArgs e)
        {
            if (headerLeftTitleRadio.Checked)
            {
                headerLeftTitleLabel.Visible = true;
                headerLeftTitleEnter.Visible = true;
                headerLeftOtherLabel.Visible = false;
                headerLeftOtherEnter.Visible = false;
                headerLeftLastNameLabel.Visible = false;
                headerLeftLastNameEnter.Visible = false;
            }
            else if (headerLeftNumberRadio.Checked)
            {
                headerLeftTitleLabel.Visible = false;
                headerLeftTitleEnter.Visible = false;
                headerLeftOtherLabel.Visible = false;
                headerLeftOtherEnter.Visible = false;
                headerLeftLastNameLabel.Visible = false;
                headerLeftLastNameEnter.Visible = false;
            }
            else if (headerLeftOtherRadio.Checked)
            {
                headerLeftTitleLabel.Visible = false;
                headerLeftTitleEnter.Visible = false;
                headerLeftOtherLabel.Visible = true;
                headerLeftOtherEnter.Visible = true;
                headerLeftLastNameLabel.Visible = false;
                headerLeftLastNameEnter.Visible = false;
            }
            else if (headerLeftNumNameRadio.Checked)
            {
                headerLeftTitleLabel.Visible = false;
                headerLeftTitleEnter.Visible = false;
                headerLeftOtherLabel.Visible = false;
                headerLeftOtherEnter.Visible = false;
                headerLeftLastNameLabel.Visible = true;
                headerLeftLastNameEnter.Visible = true;
            }
            else if (headerLeftEmptyRadio.Checked)
            {
                headerLeftTitleLabel.Visible = false;
                headerLeftTitleEnter.Visible = false;
                headerLeftOtherLabel.Visible = false;
                headerLeftOtherEnter.Visible = false;
                headerLeftLastNameLabel.Visible = false;
                headerLeftLastNameEnter.Visible = false;
            }
        }

        private void headerRightChanged(object sender, EventArgs e)
        {
            if (headerRightTitleRadio.Checked)
            {
                headerRightTitleLabel.Visible = true;
                headerRightTitleEnter.Visible = true;
                headerRightOtherLabel.Visible = false;
                headerRightOtherEnter.Visible = false;
                headerRightLastNameLabel.Visible = false;
                headerRightLastNameEnter.Visible = false;
            }
            else if (headerRightNumberRadio.Checked)
            {
                headerRightTitleLabel.Visible = false;
                headerRightTitleEnter.Visible = false;
                headerRightOtherLabel.Visible = false;
                headerRightOtherEnter.Visible = false;
                headerRightLastNameLabel.Visible = false;
                headerRightLastNameEnter.Visible = false;
            }
            else if (headerRightOtherRadio.Checked)
            {
                headerRightTitleLabel.Visible = false;
                headerRightTitleEnter.Visible = false;
                headerRightOtherLabel.Visible = true;
                headerRightOtherEnter.Visible = true;
                headerRightLastNameLabel.Visible = false;
                headerRightLastNameEnter.Visible = false;
            }
            else if (headerRightNumNameRadio.Checked)
            {
                headerRightTitleLabel.Visible = false;
                headerRightTitleEnter.Visible = false;
                headerRightOtherLabel.Visible = false;
                headerRightOtherEnter.Visible = false;
                headerRightLastNameLabel.Visible = true;
                headerRightLastNameEnter.Visible = true;
            }
            else if (headerRightEmptyRadio.Checked)
            {
                headerRightTitleLabel.Visible = false;
                headerRightTitleEnter.Visible = false;
                headerRightOtherLabel.Visible = false;
                headerRightOtherEnter.Visible = false;
                headerRightLastNameLabel.Visible = false;
                headerRightLastNameEnter.Visible = false;
            }
        }

        private void headerFirstLeftChanged(object sender, EventArgs e)
        {
            if (headerFirstLeftTitleRadio.Checked)
            {
                headerFirstLeftTitleLabel.Visible = true;
                headerFirstLeftTitleEnter.Visible = true;
                headerFirstLeftOtherLabel.Visible = false;
                headerFirstLeftOtherEnter.Visible = false;
                headerFirstLeftLastNameLabel.Visible = false;
                headerFirstLeftLastNameEnter.Visible = false;
            }
            else if (headerFirstLeftNumberRadio.Checked)
            {
                headerFirstLeftTitleLabel.Visible = false;
                headerFirstLeftTitleEnter.Visible = false;
                headerFirstLeftOtherLabel.Visible = false;
                headerFirstLeftOtherEnter.Visible = false;
                headerFirstLeftLastNameLabel.Visible = false;
                headerFirstLeftLastNameEnter.Visible = false;
            }
            else if (headerFirstLeftOtherRadio.Checked)
            {
                headerFirstLeftTitleLabel.Visible = false;
                headerFirstLeftTitleEnter.Visible = false;
                headerFirstLeftOtherLabel.Visible = true;
                headerFirstLeftOtherEnter.Visible = true;
                headerFirstLeftLastNameLabel.Visible = false;
                headerFirstLeftLastNameEnter.Visible = false;
            }
            else if (headerFirstLeftPageNumberLastNameRadio.Checked)
            {
                headerFirstLeftTitleLabel.Visible = false;
                headerFirstLeftTitleEnter.Visible = false;
                headerFirstLeftOtherLabel.Visible = false;
                headerFirstLeftOtherEnter.Visible = false;
                headerFirstLeftLastNameLabel.Visible = true;
                headerFirstLeftLastNameEnter.Visible = true;
            }
            else if (headerFirstLeftEmptyRadio.Checked)
            {
                headerFirstLeftTitleLabel.Visible = false;
                headerFirstLeftTitleEnter.Visible = false;
                headerFirstLeftOtherLabel.Visible = false;
                headerFirstLeftOtherEnter.Visible = false;
                headerFirstLeftLastNameLabel.Visible = false;
                headerFirstLeftLastNameEnter.Visible = false;
            }
        }

        private void headerFirstRightChanged(object sender, EventArgs e)
        {
            if (headerFirstRightTitleRadio.Checked)
            {
                headerFirstRightTitleLabel.Visible = true;
                headerFirstRightTitleEnter.Visible = true;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
                headerFirstRightLastNameLabel.Visible = false;
                headerFirstRightLastNameEnter.Visible = false;
            }
            else if (headerFirstRightNumberRadio.Checked)
            {
                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
                headerFirstRightLastNameLabel.Visible = false;
                headerFirstRightLastNameEnter.Visible = false;
            }
            else if (headerFirstRightOtherRadio.Checked)
            {
                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = true;
                headerFirstRightOtherEnter.Visible = true;
                headerFirstRightLastNameLabel.Visible = false;
                headerFirstRightLastNameEnter.Visible = false;
            }
            else if (headerFirstRightPageNumberLastNameRadio.Checked)
            {
                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
                headerFirstRightLastNameLabel.Visible = true;
                headerFirstRightLastNameEnter.Visible = true;
            }
            else if (headerFirstRightEmptyRadio.Checked)
            {
                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
                headerFirstRightLastNameLabel.Visible = false;
                headerFirstRightLastNameEnter.Visible = false;
            }
        }        
    }
}
