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
                lowerSection(384, "HEADER");
                sections["HEADER"] = 1005;
                headerPanel.Height = 1005;
                headerDefaultButton.Location = new Point(9, 969);
                headerOptionsGroupBox.Height = 928;
                headerFirstPageGroupBox.Height = 474;
                headerFirstPageLeftGroupBox.Visible = true;
                headerFirstPageCenterGroupBox.Visible = true;
                headerFirstPageRightGroupBox.Visible = true;
            }
            else
            {
                headerFirstPageLeftGroupBox.Visible = false;
                headerFirstPageCenterGroupBox.Visible = false;
                headerFirstPageRightGroupBox.Visible = false;
                headerFirstPageGroupBox.Height = 90;
                headerOptionsGroupBox.Height = 544;
                headerDefaultButton.Location = new Point(9, 585);
                headerPanel.Height = 621;
                sections["HEADER"] = 621;
                raiseSection(384, "HEADER");
            }
        }

        private void headerDiffFirstPageCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (headerDiffFirstPageCheck.Checked)
            {
                if (headerFirstPageMoreCheck.Checked)
                {
                    lowerSection(434, "HEADER");
                    sections["HEADER"] = 1005;
                    headerPanel.Height = 1005;
                    headerDefaultButton.Location = new Point(9, 969);
                    headerOptionsGroupBox.Height = 928;
                    headerFirstPageGroupBox.Height = 474;
                    headerFirstPageLeftGroupBox.Visible = true;
                    headerFirstPageCenterGroupBox.Visible = true;
                    headerFirstPageRightGroupBox.Visible = true;
                }
                else
                {
                    lowerSection(50, "HEADER");
                    sections["HEADER"] = 621;
                    headerPanel.Height = 621;
                    headerDefaultButton.Location = new Point(9, 585);
                    headerOptionsGroupBox.Height = 544;
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
                    headerFirstPageCenterGroupBox.Visible = false;
                    headerFirstPageRightGroupBox.Visible = false;
                    raiseSection(434, "HEADER");
                }
                else
                {
                    raiseSection(50, "HEADER");
                }
                headerFirstPageUseRunningHeadCheck.Visible = false;
                headerFirstPageMoreCheck.Visible = false;
                headerFirstPageGroupBox.Height = 40;
                headerOptionsGroupBox.Height = 494;
                headerDefaultButton.Location = new Point(9, 535);
                headerPanel.Height = 571;
                sections["HEADER"] = 571;
            }
        }

        private void headerLeftChanged(object sender, EventArgs e)
        {
            if (headerLeftTitleRadio.Checked)
            {
                headerLeftTitleLabel.Visible = true;
                headerLeftTitleEnter.Visible = true;
                headerLeftNumberLabel.Visible = false;
                headerLeftNumberEnter.Visible = false;
                headerLeftOtherLabel.Visible = false;
                headerLeftOtherEnter.Visible = false;
            }
            else if (headerLeftNumberRadio.Checked)
            {
                 headerLeftTitleLabel.Visible = false;
                headerLeftTitleEnter.Visible = false;
                headerLeftNumberLabel.Visible = true;
                headerLeftNumberEnter.Visible = true;
                headerLeftOtherLabel.Visible = false;
                headerLeftOtherEnter.Visible = false;
            }
            else if (headerLeftOtherRadio.Checked)
            {
                headerLeftTitleLabel.Visible = false;
                headerLeftTitleEnter.Visible = false;
                headerLeftNumberLabel.Visible = false;
                headerLeftNumberEnter.Visible = false;
                headerLeftOtherLabel.Visible = true;
                headerLeftOtherEnter.Visible = true;
            }
            else if (headerLeftEmptyRadio.Checked)
            {
                headerLeftTitleLabel.Visible = false;
                headerLeftTitleEnter.Visible = false;
                headerLeftNumberLabel.Visible = false;
                headerLeftNumberEnter.Visible = false;
                headerLeftOtherLabel.Visible = false;
                headerLeftOtherEnter.Visible = false;
            }
        }

        private void headerCenterChanged(object sender, EventArgs e)
        {
            if (headerCenterTitleRadio.Checked)
            {
                headerCenterTitleLabel.Visible = true;
                headerCenterTitleEnter.Visible = true;
                headerCenterNumberLabel.Visible = false;
                headerCenterNumberEnter.Visible = false;
                headerCenterOtherLabel.Visible = false;
                headerCenterOtherEnter.Visible = false;
            }
            else if (headerCenterNumberRadio.Checked)
            {
                headerCenterTitleLabel.Visible = false;
                headerCenterTitleEnter.Visible = false;
                headerCenterNumberLabel.Visible = true;
                headerCenterNumberEnter.Visible = true;
                headerCenterOtherLabel.Visible = false;
                headerCenterOtherEnter.Visible = false;
            }
            else if (headerCenterOtherRadio.Checked)
            {
                headerCenterTitleLabel.Visible = false;
                headerCenterTitleEnter.Visible = false;
                headerCenterNumberLabel.Visible = false;
                headerCenterNumberEnter.Visible = false;
                headerCenterOtherLabel.Visible = true;
                headerCenterOtherEnter.Visible = true;
            }
            else if (headerCenterEmptyRadio.Checked)
            {
                headerCenterTitleLabel.Visible = false;
                headerCenterTitleEnter.Visible = false;
                headerCenterNumberLabel.Visible = false;
                headerCenterNumberEnter.Visible = false;
                headerCenterOtherLabel.Visible = false;
                headerCenterOtherEnter.Visible = false;
            }
        }

        private void headerRightChanged(object sender, EventArgs e)
        {
            if (headerRightTitleRadio.Checked)
            {
                headerRightTitleLabel.Visible = true;
                headerRightTitleEnter.Visible = true;
                headerRightNumberLabel.Visible = false;
                headerRightNumberEnter.Visible = false;
                headerRightOtherLabel.Visible = false;
                headerRightOtherEnter.Visible = false;
            }
            else if (headerRightNumberRadio.Checked)
            {
                headerRightTitleLabel.Visible = false;
                headerRightTitleEnter.Visible = false;
                headerRightNumberLabel.Visible = true;
                headerRightNumberEnter.Visible = true;
                headerRightOtherLabel.Visible = false;
                headerRightOtherEnter.Visible = false;
            }
            else if (headerRightOtherRadio.Checked)
            {
                headerRightTitleLabel.Visible = false;
                headerRightTitleEnter.Visible = false;
                headerRightNumberLabel.Visible = false;
                headerRightNumberEnter.Visible = false;
                headerRightOtherLabel.Visible = true;
                headerRightOtherEnter.Visible = true;
            }
            else if (headerRightEmptyRadio.Checked)
            {
                headerRightTitleLabel.Visible = false;
                headerRightTitleEnter.Visible = false;
                headerRightNumberLabel.Visible = false;
                headerRightNumberEnter.Visible = false;
                headerRightOtherLabel.Visible = false;
                headerRightOtherEnter.Visible = false;
            }
        }

        private void headerFirstLeftChanged(object sender, EventArgs e)
        {
            if (headerFirstLeftTitleRadio.Checked)
            {
                headerFirstLeftTitleLabel.Visible = true;
                headerFirstLeftTitleEnter.Visible = true;
                headerFirstLeftNumberLabel.Visible = false;
                headerFirstLeftNumberEnter.Visible = false;
                headerFirstLeftOtherLabel.Visible = false;
                headerFirstLeftOtherEnter.Visible = false;
            }
            else if (headerFirstLeftNumberRadio.Checked)
            {
                headerFirstLeftTitleLabel.Visible = false;
                headerFirstLeftTitleEnter.Visible = false;
                headerFirstLeftNumberLabel.Visible = true;
                headerFirstLeftNumberEnter.Visible = true;
                headerFirstLeftOtherLabel.Visible = false;
                headerFirstLeftOtherEnter.Visible = false;
            }
            else if (headerFirstLeftOtherRadio.Checked)
            {
                headerFirstLeftTitleLabel.Visible = false;
                headerFirstLeftTitleEnter.Visible = false;
                headerFirstLeftNumberLabel.Visible = false;
                headerFirstLeftNumberEnter.Visible = false;
                headerFirstLeftOtherLabel.Visible = true;
                headerFirstLeftOtherEnter.Visible = true;
            }
            else if (headerFirstLeftEmptyRadio.Checked)
            {
                headerFirstLeftTitleLabel.Visible = false;
                headerFirstLeftTitleEnter.Visible = false;
                headerFirstLeftNumberLabel.Visible = false;
                headerFirstLeftNumberEnter.Visible = false;
                headerFirstLeftOtherLabel.Visible = false;
                headerFirstLeftOtherEnter.Visible = false;
            }
        }

        private void headerFirstCenterChanged(object sender, EventArgs e)
        {
            if (headerFirstCenterTitleRadio.Checked)
            {
                headerFirstCenterTitleLabel.Visible = true;
                headerFirstCenterTitleEnter.Visible = true;
                headerFirstCenterNumberLabel.Visible = false;
                headerFirstCenterNumberEnter.Visible = false;
                headerFirstCenterOtherLabel.Visible = false;
                headerFirstCenterOtherEnter.Visible = false;
            }
            else if (headerFirstCenterNumberRadio.Checked)
            {
                headerFirstCenterTitleLabel.Visible = false;
                headerFirstCenterTitleEnter.Visible = false;
                headerFirstCenterNumberLabel.Visible = true;
                headerFirstCenterNumberEnter.Visible = true;
                headerFirstCenterOtherLabel.Visible = false;
                headerFirstCenterOtherEnter.Visible = false;
            }
            else if (headerFirstCenterOtherRadio.Checked)
            {
                headerFirstCenterTitleLabel.Visible = false;
                headerFirstCenterTitleEnter.Visible = false;
                headerFirstCenterNumberLabel.Visible = false;
                headerFirstCenterNumberEnter.Visible = false;
                headerFirstCenterOtherLabel.Visible = true;
                headerFirstCenterOtherEnter.Visible = true;
            }
            else if (headerFirstCenterEmptyRadio.Checked)
            {
                headerFirstCenterTitleLabel.Visible = false;
                headerFirstCenterTitleEnter.Visible = false;
                headerFirstCenterNumberLabel.Visible = false;
                headerFirstCenterNumberEnter.Visible = false;
                headerFirstCenterOtherLabel.Visible = false;
                headerFirstCenterOtherEnter.Visible = false;
            }
        }

        private void headerFirstRightChanged(object sender, EventArgs e)
        {
            if (headerFirstRightTitleRadio.Checked)
            {
                headerFirstRightTitleLabel.Visible = true;
                headerFirstRightTitleEnter.Visible = true;
                headerFirstRightNumberLabel.Visible = false;
                headerFirstRightNumberEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
            }
            else if (headerFirstRightNumberRadio.Checked)
            {
                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightNumberLabel.Visible = true;
                headerFirstRightNumberEnter.Visible = true;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
            }
            else if (headerFirstRightOtherRadio.Checked)
            {
                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightNumberLabel.Visible = false;
                headerFirstRightNumberEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = true;
                headerFirstRightOtherEnter.Visible = true;
            }
            else if (headerFirstRightEmptyRadio.Checked)
            {
                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightNumberLabel.Visible = false;
                headerFirstRightNumberEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
            }
        }        
    }
}
