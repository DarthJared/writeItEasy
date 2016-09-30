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
            myPaper.includeHeader = headerIncludeCheck.Checked;
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
                myPaper.includeHeader = true;
                headerPanel.Visible = true;
                lowerSection(sectionHeight, "HEADER");
                headerActive = true;
            }
            /*Unchecked*/
            else
            {
                myPaper.includeHeader = false;
                headerPanel.Visible = false;
                raiseSection(sectionHeight, "HEADER");
                headerActive = false;
            }
        }

        private void footerIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.includeFooter = footerIncludeCheck.Checked;
            int sectionHeight;
            if (sections.TryGetValue("FOOTER", out sectionHeight)) { }

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

            int genY = generalPanel.Location.Y;
            footerPanel.Location = new Point(0,
                generalSectionHeight +
                titlePageSectionHeight +
                summarySectionHeight +
                abstractSectionHeight +
                headerSectionHeight +
                genY);

            /*Checked*/
            if (footerIncludeCheck.Checked)
            {
                myPaper.includeFooter = true;
                footerPanel.Visible = true;
                lowerSection(sectionHeight, "FOOTER");
                footerActive = true;
            }
            /*Unchecked*/
            else
            {
                myPaper.includeFooter = false;
                footerPanel.Visible = false;
                raiseSection(sectionHeight, "FOOTER");
                footerActive = false;
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
            myPaper.header.differentFirstPage = headerDiffFirstPageCheck.Checked;
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
                myPaper.header.leftTitle = true;
                myPaper.header.leftPageNum = false;
                myPaper.header.leftOther = false;

                headerLeftTitleLabel.Visible = true;
                headerLeftTitleEnter.Visible = true;
                headerLeftNumberLabel.Visible = false;
                headerLeftNumberEnter.Visible = false;
                headerLeftOtherLabel.Visible = false;
                headerLeftOtherEnter.Visible = false;
            }
            else if (headerLeftNumberRadio.Checked)
            {
                myPaper.header.leftTitle = false;
                myPaper.header.leftPageNum = true;
                myPaper.header.leftOther = false;

                headerLeftTitleLabel.Visible = false;
                headerLeftTitleEnter.Visible = false;
                headerLeftNumberLabel.Visible = true;
                headerLeftNumberEnter.Visible = true;
                headerLeftOtherLabel.Visible = false;
                headerLeftOtherEnter.Visible = false;
            }
            else if (headerLeftOtherRadio.Checked)
            {
                myPaper.header.leftTitle = false;
                myPaper.header.leftPageNum = false;
                myPaper.header.leftOther = true;

                headerLeftTitleLabel.Visible = false;
                headerLeftTitleEnter.Visible = false;
                headerLeftNumberLabel.Visible = false;
                headerLeftNumberEnter.Visible = false;
                headerLeftOtherLabel.Visible = true;
                headerLeftOtherEnter.Visible = true;
            }
            else if (headerLeftEmptyRadio.Checked)
            {
                myPaper.header.leftTitle = false;
                myPaper.header.leftPageNum = false;
                myPaper.header.leftOther = false;

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
                myPaper.header.centerTitle = true;
                myPaper.header.centerPageNum = false;
                myPaper.header.centerOther = false;

                headerCenterTitleLabel.Visible = true;
                headerCenterTitleEnter.Visible = true;
                headerCenterNumberLabel.Visible = false;
                headerCenterNumberEnter.Visible = false;
                headerCenterOtherLabel.Visible = false;
                headerCenterOtherEnter.Visible = false;
            }
            else if (headerCenterNumberRadio.Checked)
            {
                myPaper.header.centerTitle = false;
                myPaper.header.centerPageNum = true;
                myPaper.header.centerOther = false;

                headerCenterTitleLabel.Visible = false;
                headerCenterTitleEnter.Visible = false;
                headerCenterNumberLabel.Visible = true;
                headerCenterNumberEnter.Visible = true;
                headerCenterOtherLabel.Visible = false;
                headerCenterOtherEnter.Visible = false;
            }
            else if (headerCenterOtherRadio.Checked)
            {
                myPaper.header.centerTitle = false;
                myPaper.header.centerPageNum = false;
                myPaper.header.centerOther = true;

                headerCenterTitleLabel.Visible = false;
                headerCenterTitleEnter.Visible = false;
                headerCenterNumberLabel.Visible = false;
                headerCenterNumberEnter.Visible = false;
                headerCenterOtherLabel.Visible = true;
                headerCenterOtherEnter.Visible = true;
            }
            else if (headerCenterEmptyRadio.Checked)
            {
                myPaper.header.centerTitle = false;
                myPaper.header.centerPageNum = false;
                myPaper.header.centerOther = false;

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
                myPaper.header.rightTitle = true;
                myPaper.header.rightPageNum = false;
                myPaper.header.rightOther = false;

                headerRightTitleLabel.Visible = true;
                headerRightTitleEnter.Visible = true;
                headerRightNumberLabel.Visible = false;
                headerRightNumberEnter.Visible = false;
                headerRightOtherLabel.Visible = false;
                headerRightOtherEnter.Visible = false;
            }
            else if (headerRightNumberRadio.Checked)
            {
                myPaper.header.rightTitle = false;
                myPaper.header.rightPageNum = true;
                myPaper.header.rightOther = false;

                headerRightTitleLabel.Visible = false;
                headerRightTitleEnter.Visible = false;
                headerRightNumberLabel.Visible = true;
                headerRightNumberEnter.Visible = true;
                headerRightOtherLabel.Visible = false;
                headerRightOtherEnter.Visible = false;
            }
            else if (headerRightOtherRadio.Checked)
            {
                myPaper.header.rightTitle = false;
                myPaper.header.rightPageNum = false;
                myPaper.header.rightOther = true;

                headerRightTitleLabel.Visible = false;
                headerRightTitleEnter.Visible = false;
                headerRightNumberLabel.Visible = false;
                headerRightNumberEnter.Visible = false;
                headerRightOtherLabel.Visible = true;
                headerRightOtherEnter.Visible = true;
            }
            else if (headerRightEmptyRadio.Checked)
            {
                myPaper.header.rightTitle = false;
                myPaper.header.rightPageNum = false;
                myPaper.header.rightOther = false;

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
                myPaper.header.firstLeftTitle = true;
                myPaper.header.firstLeftPageNum = false;
                myPaper.header.firstLeftOther = false;

                headerFirstLeftTitleLabel.Visible = true;
                headerFirstLeftTitleEnter.Visible = true;
                headerFirstLeftNumberLabel.Visible = false;
                headerFirstLeftNumberEnter.Visible = false;
                headerFirstLeftOtherLabel.Visible = false;
                headerFirstLeftOtherEnter.Visible = false;
            }
            else if (headerFirstLeftNumberRadio.Checked)
            {
                myPaper.header.firstLeftTitle = false;
                myPaper.header.firstLeftPageNum = true;
                myPaper.header.firstLeftOther = false;

                headerFirstLeftTitleLabel.Visible = false;
                headerFirstLeftTitleEnter.Visible = false;
                headerFirstLeftNumberLabel.Visible = true;
                headerFirstLeftNumberEnter.Visible = true;
                headerFirstLeftOtherLabel.Visible = false;
                headerFirstLeftOtherEnter.Visible = false;
            }
            else if (headerFirstLeftOtherRadio.Checked)
            {
                myPaper.header.firstLeftTitle = false;
                myPaper.header.firstLeftPageNum = false;
                myPaper.header.firstLeftOther = true;

                headerFirstLeftTitleLabel.Visible = false;
                headerFirstLeftTitleEnter.Visible = false;
                headerFirstLeftNumberLabel.Visible = false;
                headerFirstLeftNumberEnter.Visible = false;
                headerFirstLeftOtherLabel.Visible = true;
                headerFirstLeftOtherEnter.Visible = true;
            }
            else if (headerFirstLeftEmptyRadio.Checked)
            {
                myPaper.header.firstLeftTitle = false;
                myPaper.header.firstLeftPageNum = false;
                myPaper.header.firstLeftOther = false;

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
                myPaper.header.firstCenterTitle = true;
                myPaper.header.firstCenterPageNum = false;
                myPaper.header.firstCenterOther = false;

                headerFirstCenterTitleLabel.Visible = true;
                headerFirstCenterTitleEnter.Visible = true;
                headerFirstCenterNumberLabel.Visible = false;
                headerFirstCenterNumberEnter.Visible = false;
                headerFirstCenterOtherLabel.Visible = false;
                headerFirstCenterOtherEnter.Visible = false;
            }
            else if (headerFirstCenterNumberRadio.Checked)
            {
                myPaper.header.firstCenterTitle = false;
                myPaper.header.firstCenterPageNum = true;
                myPaper.header.firstCenterOther = false;

                headerFirstCenterTitleLabel.Visible = false;
                headerFirstCenterTitleEnter.Visible = false;
                headerFirstCenterNumberLabel.Visible = true;
                headerFirstCenterNumberEnter.Visible = true;
                headerFirstCenterOtherLabel.Visible = false;
                headerFirstCenterOtherEnter.Visible = false;
            }
            else if (headerFirstCenterOtherRadio.Checked)
            {
                myPaper.header.firstCenterTitle = false;
                myPaper.header.firstCenterPageNum = false;
                myPaper.header.firstCenterOther = true;

                headerFirstCenterTitleLabel.Visible = false;
                headerFirstCenterTitleEnter.Visible = false;
                headerFirstCenterNumberLabel.Visible = false;
                headerFirstCenterNumberEnter.Visible = false;
                headerFirstCenterOtherLabel.Visible = true;
                headerFirstCenterOtherEnter.Visible = true;
            }
            else if (headerFirstCenterEmptyRadio.Checked)
            {
                myPaper.header.firstCenterTitle = false;
                myPaper.header.firstCenterPageNum = false;
                myPaper.header.firstCenterOther = false;

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
                myPaper.header.firstRightTitle = true;
                myPaper.header.firstRightPageNum = false;
                myPaper.header.firstRightOther = false;

                headerFirstRightTitleLabel.Visible = true;
                headerFirstRightTitleEnter.Visible = true;
                headerFirstRightNumberLabel.Visible = false;
                headerFirstRightNumberEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
            }
            else if (headerFirstRightNumberRadio.Checked)
            {
                myPaper.header.firstRightTitle = false;
                myPaper.header.firstRightPageNum = true;
                myPaper.header.firstRightOther = false;

                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightNumberLabel.Visible = true;
                headerFirstRightNumberEnter.Visible = true;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
            }
            else if (headerFirstRightOtherRadio.Checked)
            {
                myPaper.header.firstRightTitle = false;
                myPaper.header.firstRightPageNum = false;
                myPaper.header.firstRightOther = true;

                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightNumberLabel.Visible = false;
                headerFirstRightNumberEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = true;
                headerFirstRightOtherEnter.Visible = true;
            }
            else if (headerFirstRightEmptyRadio.Checked)
            {
                myPaper.header.firstRightTitle = false;
                myPaper.header.firstRightPageNum = false;
                myPaper.header.firstRightOther = false;

                headerFirstRightTitleLabel.Visible = false;
                headerFirstRightTitleEnter.Visible = false;
                headerFirstRightNumberLabel.Visible = false;
                headerFirstRightNumberEnter.Visible = false;
                headerFirstRightOtherLabel.Visible = false;
                headerFirstRightOtherEnter.Visible = false;
            }
        }

        private void footerLeftChanged(object sender, EventArgs e)
        {
            if (footerLeftTitleRadio.Checked)
            {
                footerLeftTitleLabel.Visible = true;
                footerLeftTitleEnter.Visible = true;
                footerLeftNumberLabel.Visible = false;
                footerLeftNumberEnter.Visible = false;
                footerLeftOtherLabel.Visible = false;
                footerLeftOtherEnter.Visible = false;
            }
            else if (footerLeftNumberRadio.Checked)
            {
                footerLeftTitleLabel.Visible = false;
                footerLeftTitleEnter.Visible = false;
                footerLeftNumberLabel.Visible = true;
                footerLeftNumberEnter.Visible = true;
                footerLeftOtherLabel.Visible = false;
                footerLeftOtherEnter.Visible = false;
            }
            else if (footerLeftOtherRadio.Checked)
            {
                footerLeftTitleLabel.Visible = false;
                footerLeftTitleEnter.Visible = false;
                footerLeftNumberLabel.Visible = false;
                footerLeftNumberEnter.Visible = false;
                footerLeftOtherLabel.Visible = true;
                footerLeftOtherEnter.Visible = true;
            }
            else if (footerLeftEmptyRadio.Checked)
            {
                footerLeftTitleLabel.Visible = false;
                footerLeftTitleEnter.Visible = false;
                footerLeftNumberLabel.Visible = false;
                footerLeftNumberEnter.Visible = false;
                footerLeftOtherLabel.Visible = false;
                footerLeftOtherEnter.Visible = false;
            }
        }

        private void footerCenterChanged(object sender, EventArgs e)
        {
            if (footerCenterTitleRadio.Checked)
            {
                footerCenterTitleLabel.Visible = true;
                footerCenterTitleEnter.Visible = true;
                footerCenterNumberLabel.Visible = false;
                footerCenterNumberEnter.Visible = false;
                footerCenterOtherLabel.Visible = false;
                footerCenterOtherEnter.Visible = false;
            }
            else if (footerCenterNumberRadio.Checked)
            {
                footerCenterTitleLabel.Visible = false;
                footerCenterTitleEnter.Visible = false;
                footerCenterNumberLabel.Visible = true;
                footerCenterNumberEnter.Visible = true;
                footerCenterOtherLabel.Visible = false;
                footerCenterOtherEnter.Visible = false;
            }
            else if (footerCenterOtherRadio.Checked)
            {
                footerCenterTitleLabel.Visible = false;
                footerCenterTitleEnter.Visible = false;
                footerCenterNumberLabel.Visible = false;
                footerCenterNumberEnter.Visible = false;
                footerCenterOtherLabel.Visible = true;
                footerCenterOtherEnter.Visible = true;
            }
            else if (footerCenterEmptyRadio.Checked)
            {
                footerCenterTitleLabel.Visible = false;
                footerCenterTitleEnter.Visible = false;
                footerCenterNumberLabel.Visible = false;
                footerCenterNumberEnter.Visible = false;
                footerCenterOtherLabel.Visible = false;
                footerCenterOtherEnter.Visible = false;
            }
        }

        private void footerRightChanged(object sender, EventArgs e)
        {
            if (footerRightTitleRadio.Checked)
            {
                footerRightTitleLabel.Visible = true;
                footerRightTitleEnter.Visible = true;
                footerRightNumberLabel.Visible = false;
                footerRightNumberEnter.Visible = false;
                footerRightOtherLabel.Visible = false;
                footerRightOtherEnter.Visible = false;
            }
            else if (footerRightNumberRadio.Checked)
            {
                footerRightTitleLabel.Visible = false;
                footerRightTitleEnter.Visible = false;
                footerRightNumberLabel.Visible = true;
                footerRightNumberEnter.Visible = true;
                footerRightOtherLabel.Visible = false;
                footerRightOtherEnter.Visible = false;
            }
            else if (footerRightOtherRadio.Checked)
            {
                footerRightTitleLabel.Visible = false;
                footerRightTitleEnter.Visible = false;
                footerRightNumberLabel.Visible = false;
                footerRightNumberEnter.Visible = false;
                footerRightOtherLabel.Visible = true;
                footerRightOtherEnter.Visible = true;
            }
            else if (footerRightEmptyRadio.Checked)
            {
                footerRightTitleLabel.Visible = false;
                footerRightTitleEnter.Visible = false;
                footerRightNumberLabel.Visible = false;
                footerRightNumberEnter.Visible = false;
                footerRightOtherLabel.Visible = false;
                footerRightOtherEnter.Visible = false;
            }
        }

        private void footerFirstLeftChanged(object sender, EventArgs e)
        {
            if (footerFirstLeftTitleRadio.Checked)
            {
                footerFirstLeftTitleLabel.Visible = true;
                footerFirstLeftTitleEnter.Visible = true;
                footerFirstLeftNumberLabel.Visible = false;
                footerFirstLeftNumberEnter.Visible = false;
                footerFirstLeftOtherLabel.Visible = false;
                footerFirstLeftOtherEnter.Visible = false;
            }
            else if (footerFirstLeftNumberRadio.Checked)
            {
                footerFirstLeftTitleLabel.Visible = false;
                footerFirstLeftTitleEnter.Visible = false;
                footerFirstLeftNumberLabel.Visible = true;
                footerFirstLeftNumberEnter.Visible = true;
                footerFirstLeftOtherLabel.Visible = false;
                footerFirstLeftOtherEnter.Visible = false;
            }
            else if (footerFirstLeftOtherRadio.Checked)
            {
                footerFirstLeftTitleLabel.Visible = false;
                footerFirstLeftTitleEnter.Visible = false;
                footerFirstLeftNumberLabel.Visible = false;
                footerFirstLeftNumberEnter.Visible = false;
                footerFirstLeftOtherLabel.Visible = true;
                footerFirstLeftOtherEnter.Visible = true;
            }
            else if (footerFirstLeftEmptyRadio.Checked)
            {
                footerFirstLeftTitleLabel.Visible = false;
                footerFirstLeftTitleEnter.Visible = false;
                footerFirstLeftNumberLabel.Visible = false;
                footerFirstLeftNumberEnter.Visible = false;
                footerFirstLeftOtherLabel.Visible = false;
                footerFirstLeftOtherEnter.Visible = false;
            }
        }

        private void footerFirstCenterChanged(object sender, EventArgs e)
        {
            if (footerFirstCenterTitleRadio.Checked)
            {
                footerFirstCenterTitleLabel.Visible = true;
                footerFirstCenterTitleEnter.Visible = true;
                footerFirstCenterNumberLabel.Visible = false;
                footerFirstCenterNumberEnter.Visible = false;
                footerFirstCenterOtherLabel.Visible = false;
                footerFirstCenterOtherEnter.Visible = false;
            }
            else if (footerFirstCenterNumberRadio.Checked)
            {
                footerFirstCenterTitleLabel.Visible = false;
                footerFirstCenterTitleEnter.Visible = false;
                footerFirstCenterNumberLabel.Visible = true;
                footerFirstCenterNumberEnter.Visible = true;
                footerFirstCenterOtherLabel.Visible = false;
                footerFirstCenterOtherEnter.Visible = false;
            }
            else if (footerFirstCenterOtherRadio.Checked)
            {
                footerFirstCenterTitleLabel.Visible = false;
                footerFirstCenterTitleEnter.Visible = false;
                footerFirstCenterNumberLabel.Visible = false;
                footerFirstCenterNumberEnter.Visible = false;
                footerFirstCenterOtherLabel.Visible = true;
                footerFirstCenterOtherEnter.Visible = true;
            }
            else if (footerFirstCenterEmptyRadio.Checked)
            {
                footerFirstCenterTitleLabel.Visible = false;
                footerFirstCenterTitleEnter.Visible = false;
                footerFirstCenterNumberLabel.Visible = false;
                footerFirstCenterNumberEnter.Visible = false;
                footerFirstCenterOtherLabel.Visible = false;
                footerFirstCenterOtherEnter.Visible = false;
            }
        }

        private void footerFirstRightChanged(object sender, EventArgs e)
        {
            if (footerFirstRightTitleRadio.Checked)
            {
                footerFirstRightTitleLabel.Visible = true;
                footerFirstRightTitleEnter.Visible = true;
                footerFirstRightNumberLabel.Visible = false;
                footerFirstRightNumberEnter.Visible = false;
                footerFirstRightOtherLabel.Visible = false;
                footerFirstRightOtherEnter.Visible = false;
            }
            else if (footerFirstRightNumberRadio.Checked)
            {
                footerFirstRightTitleLabel.Visible = false;
                footerFirstRightTitleEnter.Visible = false;
                footerFirstRightNumberLabel.Visible = true;
                footerFirstRightNumberEnter.Visible = true;
                footerFirstRightOtherLabel.Visible = false;
                footerFirstRightOtherEnter.Visible = false;
            }
            else if (footerFirstRightOtherRadio.Checked)
            {
                footerFirstRightTitleLabel.Visible = false;
                footerFirstRightTitleEnter.Visible = false;
                footerFirstRightNumberLabel.Visible = false;
                footerFirstRightNumberEnter.Visible = false;
                footerFirstRightOtherLabel.Visible = true;
                footerFirstRightOtherEnter.Visible = true;
            }
            else if (footerFirstRightEmptyRadio.Checked)
            {
                footerFirstRightTitleLabel.Visible = false;
                footerFirstRightTitleEnter.Visible = false;
                footerFirstRightNumberLabel.Visible = false;
                footerFirstRightNumberEnter.Visible = false;
                footerFirstRightOtherLabel.Visible = false;
                footerFirstRightOtherEnter.Visible = false;
            }
        }

        private void footerFirstPageUseMoreCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (footerFirstPageUseMoreCheck.Checked)
            {
                lowerSection(384, "FOOTER");
                sections["FOOTER"] = 1005;
                footerPanel.Height = 1005;
                footerDefaultButton.Location = new Point(9, 969);
                footerOptionsGroupBox.Height = 928;
                footerFirstPageGroupBox.Height = 474;
                footerFirstPageLeftGroupBox.Visible = true;
                footerFirstPageCenterGroupBox.Visible = true;
                footerFirstPageRightGroupBox.Visible = true;
            }
            else
            {
                footerFirstPageLeftGroupBox.Visible = false;
                footerFirstPageCenterGroupBox.Visible = false;
                footerFirstPageRightGroupBox.Visible = false;
                footerFirstPageGroupBox.Height = 90;
                footerOptionsGroupBox.Height = 544;
                footerDefaultButton.Location = new Point(9, 585);
                footerPanel.Height = 621;
                sections["FOOTER"] = 621;
                raiseSection(384, "FOOTER");
            }
        }

        private void footerFirstPageDiffCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (footerFirstPageDiffCheck.Checked)
            {
                if (footerFirstPageUseMoreCheck.Checked)
                {
                    lowerSection(434, "FOOTER");
                    sections["FOOTER"] = 1005;
                    footerPanel.Height = 1005;
                    footerDefaultButton.Location = new Point(9, 969);
                    footerOptionsGroupBox.Height = 928;
                    footerFirstPageGroupBox.Height = 474;
                    footerFirstPageLeftGroupBox.Visible = true;
                    footerFirstPageCenterGroupBox.Visible = true;
                    footerFirstPageRightGroupBox.Visible = true;
                }
                else
                {
                    lowerSection(50, "FOOTER");
                    sections["FOOTER"] = 621;
                    footerPanel.Height = 621;
                    footerDefaultButton.Location = new Point(9, 585);
                    footerOptionsGroupBox.Height = 544;
                    footerFirstPageGroupBox.Height = 90;
                }
                footerFirstPageUseRunningHeadCheck.Visible = true;
                footerFirstPageUseMoreCheck.Visible = true;
            }
            else
            {
                if (footerFirstPageUseMoreCheck.Checked)
                {
                    footerFirstPageLeftGroupBox.Visible = false;
                    footerFirstPageCenterGroupBox.Visible = false;
                    footerFirstPageRightGroupBox.Visible = false;
                    raiseSection(434, "FOOTER");
                }
                else
                {
                    raiseSection(50, "FOOTER");
                }
                footerFirstPageUseRunningHeadCheck.Visible = false;
                footerFirstPageUseMoreCheck.Visible = false;
                footerFirstPageGroupBox.Height = 40;
                footerOptionsGroupBox.Height = 494;
                footerDefaultButton.Location = new Point(9, 535);
                footerPanel.Height = 571;
                sections["FOOTER"] = 571;
            }
        }
    }
}
