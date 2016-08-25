using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private SortedDictionary<string, int> sections = new SortedDictionary<string, int>();
        private bool titlePageActive;
        private bool summaryActive;
        private bool abstractActive;
        private bool headerActive;
        private bool footerActive;
        private bool conclusionActive;
        private bool referencesActive;
        private SortedDictionary<string, int> titlePageOrder = new SortedDictionary<string, int>();
        private SortedDictionary<int, string> orderTitlePage = new SortedDictionary<int, string>();
        private List<Section> contentSections = new List<Section>();

        public Form1()
        {
            InitializeComponent();
            Height = 600;
            Width = 1000;
            WindowState = FormWindowState.Maximized;

            sections.Add("GENERAL", 590);
            sections.Add("TITLE_PAGE", 475);
            sections.Add("SUMMARY", 545);
            sections.Add("ABSTRACT", 545);
            sections.Add("HEADER", 825);
            sections.Add("FOOTER", 825);
            sections.Add("SECTIONS", 865);
            sections.Add("CONCLUSION", 545);
            sections.Add("REFERENCES", 407);

            titlePageOrder.Add("TITLE", 1);
            titlePageOrder.Add("NAME", 2);
            titlePageOrder.Add("CLASS", 3);
            titlePageOrder.Add("PROFESSOR", 4);
            titlePageOrder.Add("SCHOOL", 5);
            titlePageOrder.Add("DATE", 6);

            orderTitlePage.Add(1, "TITLE");
            orderTitlePage.Add(2, "NAME");
            orderTitlePage.Add(3, "CLASS");
            orderTitlePage.Add(4, "PROFESSOR");
            orderTitlePage.Add(5, "SCHOOL");
            orderTitlePage.Add(6, "DATE");

            titlePageActive = false;
            summaryActive = false;
            abstractActive = false;
            headerActive = false;
            footerActive = false;
            conclusionActive = false;
            referencesActive = false;

            titlePagePanel.Visible = false;
            summaryPanel.Visible = false;
            abstractPanel.Visible = false;
            headerPanel.Visible = false;
            footerPanel.Visible = false;
            conclusionPanel.Visible = false;
            referencesPanel.Visible = false;

            sectionsPanel.Location = new Point(0, generalPanel.Location.Y + generalPanel.Height);

            summaryTitleGroupBox.Height = 45;
            summaryDefaultButton.Location = new Point(9, 93);
            summaryOptionsGroupBox.Height = 125;
            summaryContentGroupBox.Location = new Point(9, 174);
            summaryPanel.Height = 440;
            sections["SUMMARY"] = 440;

            abstractTitleGroupBox.Height = 45;
            abstractDefaultButton.Location = new Point(9, 93);
            abstractOptionsGroupBox.Height = 125;
            abstractContentGroupBox.Location = new Point(9, 174);
            abstractPanel.Height = 440;
            sections["ABSTRACT"] = 440;

            headerFirstPageGroupBox.Height = 40;
            headerOptionsGroupBox.Height = 494;
            headerDefaultButton.Location = new Point(9, 535);
            headerPanel.Height = 571;
            sections["HEADER"] = 571;

            footerFirstPageGroupBox.Height = 40;
            footerOptionsGroupBox.Height = 494;
            footerDefaultButton.Location = new Point(9, 535);
            footerPanel.Height = 571;
            sections["FOOTER"] = 571;

            sectionLabelGroupBox.Height = 45;
            sectionsDefaultButton.Location = new Point(9, 179);
            sectionsOptionsGroupBox.Height = 212;
            section1groupBox.Location = new Point(9, 268);
            section1contentLabel.Location = new Point(6, 22);
            section1ContentPanel.Location = new Point(9, 40);
            section1AddSubsectionButton.Location = new Point(9, 259);
            section1groupBox.Height = 292;
            addSectionButton.Location = new Point(9, 562);
            sectionsPanel.Height = 595;
            sections["SECTIONS"] = 595;

            conclusionTitleGroupBox.Height = 45;
            conclusionDefaultButton.Location = new Point(9, 93);
            conclusionOptionsGroupBox.Height = 125;
            conclusionContentGroupBox.Location = new Point(9, 174);
            conclusionPanel.Height = 440;
            sections["CONCLUSION"] = 440;

            referencesDefaultButton.Location = new Point(9, 233);
            referencesOptionsGroupBox.Height = 185;
            referencesOrderChoose.Location = new Point(44, 152);
            referencesOrderLabel.Location = new Point(6, 155);
            referencesEmptyLineBetweenCheck.Location = new Point(9, 129);
            referencesPanel.Height = 270;
            sections["REFERENCES"] = 270;

            contentSections.Add(new Section(new List<SubSection>(), "", "", 1));
        }

        private void resizeEvent(object sender, EventArgs e)
        {
            TableLayoutPanelCellPosition rightPos = tableLayoutPanel1.GetCellPosition(tableLayoutPanel2);
            int rightPanelWidth = tableLayoutPanel1.GetColumnWidths()[rightPos.Column];
            int rightPanelHeight = tableLayoutPanel1.GetRowHeights()[rightPos.Row];
            tableLayoutPanel2.Width = rightPanelWidth - 6;
            tableLayoutPanel2.Height = rightPanelHeight - 6;

            previewPanel.Width = rightPanelWidth - 12;
            TableLayoutPanelCellPosition innerPos = tableLayoutPanel2.GetCellPosition(previewPanel);
            int innerHeight = tableLayoutPanel2.GetRowHeights()[innerPos.Row];
            previewPanel.Height = innerHeight - 6;

            finalizePanel.Width = rightPanelWidth - 12;

            TableLayoutPanelCellPosition leftPos = tableLayoutPanel1.GetCellPosition(sectionPanel);
            int panelWidth = tableLayoutPanel1.GetColumnWidths()[leftPos.Column];
            int panelHeight = tableLayoutPanel1.GetRowHeights()[leftPos.Row];
            sectionPanel.Width = panelWidth - 6;
            sectionPanel.Height = panelHeight - 6;

            int sectionWidth = panelWidth - 23;
            int sectionWidth1In = sectionWidth - 25;
            int sectionWidth2In = sectionWidth1In - 18;
            int sectionWidth3In = sectionWidth2In - 18;
            int sectionWidth4In = sectionWidth3In - 18;
            int sectionWidth3InTextBox = sectionWidth2In - 3;

            generalPanel.Width = sectionWidth;
            paperTitleGroupBox.Width = sectionWidth1In;
            apaMlaGroupBox.Width = sectionWidth1In;
            includeInPapeGroupBox.Width = sectionWidth1In;
            paperFormattingGroupBox.Width = sectionWidth1In;

            titlePagePanel.Width = sectionWidth;
            titlePageIncludeGroupBox.Width = sectionWidth1In;
            titlePageAllignGroupBox.Width = sectionWidth1In;
            titlePagePositionGroupBox.Width = sectionWidth1In;

            summaryPanel.Width = sectionWidth;
            summaryOptionsGroupBox.Width = sectionWidth1In;
            summaryTitleGroupBox.Width = sectionWidth2In;
            summaryContentGroupBox.Width = sectionWidth1In;
            summaryContentPanel.Width = sectionWidth2In;
            summaryToolStripContainer.Width = sectionWidth2In;
            summaryContent.Width = sectionWidth3InTextBox;

            abstractPanel.Width = sectionWidth;
            abstractOptionsGroupBox.Width = sectionWidth1In;
            abstractTitleGroupBox.Width = sectionWidth2In;
            abstractContentGroupBox.Width = sectionWidth1In;
            abstractContentPanel.Width = sectionWidth2In;
            abstractContentToolStripContainer.Width = sectionWidth2In;
            abstractContent.Width = sectionWidth3InTextBox;

            headerPanel.Width = sectionWidth;
            headerOptionsGroupBox.Width = sectionWidth1In;
            headerLeftGroupBox.Width = sectionWidth2In;
            headerCenterGroupBox.Width = sectionWidth2In;
            headerRightGroupBox.Width = sectionWidth2In;
            headerFirstPageGroupBox.Width = sectionWidth2In;
            headerFirstPageLeftGroupBox.Width = sectionWidth3In;
            headerFirstPageCenterGroupBox.Width = sectionWidth3In;
            headerFirstPageRightGroupBox.Width = sectionWidth3In;

            footerPanel.Width = sectionWidth;
            footerOptionsGroupBox.Width = sectionWidth1In;
            footerLeftGroupBox.Width = sectionWidth2In;
            footerCenterGroupBox.Width = sectionWidth2In;
            footerRightGroupBox.Width = sectionWidth2In;
            footerFirstPageGroupBox.Width = sectionWidth2In;
            footerFirstPageLeftGroupBox.Width = sectionWidth3In;
            footerFirstPageCenterGroupBox.Width = sectionWidth3In;
            footerFirstPageRightGroupBox.Width = sectionWidth3In;

            sectionsPanel.Width = sectionWidth;
            sectionsOptionsGroupBox.Width = sectionWidth1In;
            section1groupBox.Width = sectionWidth1In;
            section1ContentPanel.Width = sectionWidth2In;
            section1ToolStripContainer.Width = sectionWidth2In;
            section1Content.Width = sectionWidth3InTextBox;
            betweenSectionsGroupBox.Width = sectionWidth2In;
            sectionLabelGroupBox.Width = sectionWidth2In;
            sectionLabelLocationGroupBox.Width = sectionWidth3In;
            sectionLabelStyleGroupBox.Width = sectionWidth3In;

            conclusionPanel.Width = sectionWidth;
            conclusionOptionsGroupBox.Width = sectionWidth1In;
            conclusionTitleGroupBox.Width = sectionWidth2In;
            conclusionContentGroupBox.Width = sectionWidth1In;
            conclusionContentPanel.Width = sectionWidth2In;
            conclusionToolStripContainer.Width = sectionWidth2In;
            conclusionContent.Width = sectionWidth3InTextBox;

            referencesPanel.Width = sectionWidth;
            referencesOptionsGroupBox.Width = sectionWidth1In;
            referencesTitleGroupBox.Width = sectionWidth2In;
            referencesIndentationGroupBox.Width = sectionWidth2In;

            writeButton.Location = new Point(finalizePanel.Width - 125, 8);
        }

        private void lowerSection(int pixelsDown, string startSection)
        {
            if (startSection.Equals("GENERAL"))
            {
                if (titlePageActive)
                {
                    titlePagePanel.Location = new Point(0, titlePagePanel.Location.Y + pixelsDown);
                }
                if (summaryActive)
                {
                    summaryPanel.Location = new Point(0, summaryPanel.Location.Y + pixelsDown);
                }
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y + pixelsDown);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y + pixelsDown);
                }
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y + pixelsDown);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + pixelsDown);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + pixelsDown);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y + pixelsDown);
                }
            }
            else if (startSection.Equals("TITLE_PAGE"))
            {
                if (summaryActive)
                {
                    summaryPanel.Location = new Point(0, summaryPanel.Location.Y + pixelsDown);
                }
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y + pixelsDown);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y + pixelsDown);
                }
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y + pixelsDown);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + pixelsDown);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + pixelsDown);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y + pixelsDown);
                }
            }
            else if (startSection.Equals("SUMMARY"))
            {
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y + pixelsDown);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y + pixelsDown);
                }
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y + pixelsDown);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + pixelsDown);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + pixelsDown);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y + pixelsDown);
                }
            }
            else if (startSection.Equals("ABSTRACT"))
            {
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y + pixelsDown);
                }
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y + pixelsDown);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + pixelsDown);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + pixelsDown);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y + pixelsDown);
                }
            }
            else if (startSection.Equals("HEADER"))
            {
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y + pixelsDown);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + pixelsDown);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + pixelsDown);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y + pixelsDown);
                }
            }
            else if (startSection.Equals("FOOTER"))
            {
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + pixelsDown);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + pixelsDown);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y + pixelsDown);
                }
            }
            else if (startSection.Equals("SECTIONS"))
            {
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + pixelsDown);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y + pixelsDown);
                }
            }
            else if (startSection.Equals("CONCLUSION"))
            {
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y + pixelsDown);
                }
            }
        }

        private void raiseSection(int pixelsUp, string startSection)
        {
            if (startSection.Equals("GENERAL"))
            {
                if (titlePageActive)
                {
                    titlePagePanel.Location = new Point(0, titlePagePanel.Location.Y - pixelsUp);
                }
                if (summaryActive)
                {
                    summaryPanel.Location = new Point(0, summaryPanel.Location.Y - pixelsUp);
                }
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y - pixelsUp);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y - pixelsUp);
                }
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y - pixelsUp);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - pixelsUp);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - pixelsUp);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y - pixelsUp);
                }
            }
            else if (startSection.Equals("TITLE_PAGE"))
            {
                if (summaryActive)
                {
                    summaryPanel.Location = new Point(0, summaryPanel.Location.Y - pixelsUp);
                }
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y - pixelsUp);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y - pixelsUp);
                }
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y - pixelsUp);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - pixelsUp);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - pixelsUp);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y - pixelsUp);
                }
            }
            else if (startSection.Equals("SUMMARY"))
            {
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y - pixelsUp);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y - pixelsUp);
                }
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y - pixelsUp);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - pixelsUp);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - pixelsUp);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y - pixelsUp);
                }
            }
            else if (startSection.Equals("ABSTRACT"))
            {
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y - pixelsUp);
                }
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y - pixelsUp);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - pixelsUp);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - pixelsUp);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y - pixelsUp);
                }
            }
            else if (startSection.Equals("HEADER"))
            {
                if (footerActive)
                {
                    footerPanel.Location = new Point(0, footerPanel.Location.Y - pixelsUp);
                }
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - pixelsUp);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - pixelsUp);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y - pixelsUp);
                }
            }
            else if (startSection.Equals("FOOTER"))
            {
                sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - pixelsUp);
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - pixelsUp);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y - pixelsUp);
                }
            }
            else if (startSection.Equals("SECTIONS"))
            {
                if (conclusionActive)
                {
                    conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - pixelsUp);
                }
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y - pixelsUp);
                }
            }
            else if (startSection.Equals("CONCLUSION"))
            {
                if (referencesActive)
                {
                    referencesPanel.Location = new Point(0, referencesPanel.Location.Y - pixelsUp);
                }
            }
        }

        private void titlePageIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            int sectionHeight;
            if (sections.TryGetValue("TITLE_PAGE", out sectionHeight)) { }
            int generalSectionHeight;
            if (sections.TryGetValue("GENERAL", out generalSectionHeight)) { }
            int genY = generalPanel.Location.Y;
            titlePagePanel.Location = new Point(0, generalSectionHeight + genY);

            /*Checked*/
            if (titlePageIncludeCheck.Checked)
            {
                titlePagePanel.Visible = true;
                lowerSection(sectionHeight, "TITLE_PAGE");
                titlePageActive = true;
            }
            /*Unchecked*/
            else
            {
                titlePagePanel.Visible = false;
                raiseSection(sectionHeight, "TITLE_PAGE");
                titlePageActive = false;
            }
        }

        private void summaryIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
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
                summaryPanel.Visible = true;
                lowerSection(sectionHeight, "SUMMARY");
                summaryActive = true;
            }
            /*Unchecked*/
            else
            {
                summaryPanel.Visible = false;
                raiseSection(sectionHeight, "SUMMARY");
                summaryActive = false;
            }
        }

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
                abstractPanel.Visible = true;
                lowerSection(sectionHeight, "ABSTRACT");
                abstractActive = true;
            }
            /*Unchecked*/
            else
            {
                abstractPanel.Visible = false;
                raiseSection(sectionHeight, "ABSTRACT");
                abstractActive = false;
            }
        }

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

        private void footerIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
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
                footerPanel.Visible = true;
                lowerSection(sectionHeight, "FOOTER");
                footerActive = true;
            }
            /*Unchecked*/
            else
            {
                footerPanel.Visible = false;
                raiseSection(sectionHeight, "FOOTER");
                footerActive = false;
            }
        }

        private void conclusionIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
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
                conclusionPanel.Visible = true;
                lowerSection(sectionHeight, "CONCLUSION");
                conclusionActive = true;
            }
            /*Unchecked*/
            else
            {
                conclusionPanel.Visible = false;
                raiseSection(sectionHeight, "CONCLUSION");
                conclusionActive = false;
            }
        }

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

        private void apaMla_Changed(object sender, EventArgs e)
        {
            string newButtonText;
            if (apaRadio.Checked)
            {
                newButtonText = "APA Defaults";
            }
            else
            {
                newButtonText = "MLA Defaults";
            }
            generalDefaultButton.Text = newButtonText;
            titlePageDefaultButton.Text = newButtonText;
            summaryDefaultButton.Text = newButtonText;
            abstractDefaultButton.Text = newButtonText;
            headerDefaultButton.Text = newButtonText;
            footerDefaultButton.Text = newButtonText;
            sectionsDefaultButton.Text = newButtonText;
            conclusionDefaultButton.Text = newButtonText;
            referencesDefaultButton.Text = newButtonText;
        }

        private void titleUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("TITLE");
        }

        private void nameUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("NAME");
        }

        private void classUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("CLASS");
        }

        private void professorUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("PROFESSOR");
        }

        private void schoolUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("SCHOOL");
        }

        private void dateUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("DATE");
        }

        private void titleDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("TITLE");
        }

        private void nameDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("NAME");
        }

        private void classDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("CLASS");
        }

        private void professorDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("PROFESSOR");
        }

        private void schoolDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("SCHOOL");
        }

        private void dateDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("DATE");
        }

        private void titlePageDown(string option)
        {
            int index;
            if (titlePageOrder.TryGetValue(option, out index)) { }
            if (index < 6)
            {
                string oneMore;
                if (orderTitlePage.TryGetValue(index + 1, out oneMore)) { }
                titlePageOrder[oneMore] = index;
                titlePageOrder[option] = index + 1;
                orderTitlePage[index] = oneMore;
                orderTitlePage[index + 1] = option;
            }
            reOrderTitlePage();
        }

        private void titlePageUp(string option)
        {
            int index;
            if (titlePageOrder.TryGetValue(option, out index)) { }
            if (index > 1)
            {
                string oneLess;
                if (orderTitlePage.TryGetValue(index - 1, out oneLess)) { }
                titlePageOrder[oneLess] = index;
                titlePageOrder[option] = index - 1;
                orderTitlePage[index] = oneLess;
                orderTitlePage[index - 1] = option;
            }
            reOrderTitlePage();
        }

        private void reOrderTitlePage()
        {
            for (int i = 1; i <= 6; i++)
            {
                int yOffset = 23 * (i - 1);
                string toPosition;
                if (orderTitlePage.TryGetValue(i, out toPosition)) { }
                switch (toPosition)
                {
                    case "TITLE":
                        titleUpButton.Location = new Point(9, 19 + yOffset);
                        titleDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageTitleCheck.Location = new Point(41, 19 + yOffset);
                        titlePageTitleLabel.Location = new Point(176, 20 + yOffset);
                        titlePageTitleEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "NAME":
                        nameUpButton.Location = new Point(9, 19 + yOffset);
                        nameDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageNameCheck.Location = new Point(41, 19 + yOffset);
                        titlePageNameLabel.Location = new Point(168, 20 + yOffset);
                        titlePageNameEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "CLASS":
                        classUpButton.Location = new Point(9, 19 + yOffset);
                        classDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageClassCheck.Location = new Point(41, 19 + yOffset);
                        titlePageClassLabel.Location = new Point(171, 20 + yOffset);
                        titlePageClassEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "PROFESSOR":
                        professorUpButton.Location = new Point(9, 19 + yOffset);
                        professorDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageProfessorCheck.Location = new Point(41, 19 + yOffset);
                        titlePageProfessorLabel.Location = new Point(152, 20 + yOffset);
                        titlePageProfessorEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "SCHOOL":
                        schoolUpButton.Location = new Point(9, 19 + yOffset);
                        schoolDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageSchoolCheck.Location = new Point(41, 19 + yOffset);
                        titlePageSchoolLabel.Location = new Point(162, 20 + yOffset);
                        titlePageSchoolEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "DATE":
                        dateUpButton.Location = new Point(9, 19 + yOffset);
                        dateDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageDateCheck.Location = new Point(41, 19 + yOffset);
                        titlePageDateLabel.Location = new Point(172, 20 + yOffset);
                        titlePageDateEnter.Location = new Point(212, 17 + yOffset);
                        break;
                }
            }
        }

        private void titlePageTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageTitleCheck.Checked)
            {
                titlePageTitleLabel.Visible = true;
                titlePageTitleEnter.Visible = true;
            }
            else
            {
                titlePageTitleLabel.Visible = false;
                titlePageTitleEnter.Visible = false;
            }
        }

        private void titlePageNameCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageNameCheck.Checked)
            {
                titlePageNameLabel.Visible = true;
                titlePageNameEnter.Visible = true;
            }
            else
            {
                titlePageNameLabel.Visible = false;
                titlePageNameEnter.Visible = false;
            }
        }

        private void titlePageClassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageClassCheck.Checked)
            {
                titlePageClassLabel.Visible = true;
                titlePageClassEnter.Visible = true;
            }
            else
            {
                titlePageClassLabel.Visible = false;
                titlePageClassEnter.Visible = false;
            }
        }

        private void titlePageProfessorCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageProfessorCheck.Checked)
            {
                titlePageProfessorLabel.Visible = true;
                titlePageProfessorEnter.Visible = true;
            }
            else
            {
                titlePageProfessorLabel.Visible = false;
                titlePageProfessorEnter.Visible = false;
            }
        }

        private void titlePageSchoolCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageSchoolCheck.Checked)
            {
                titlePageSchoolLabel.Visible = true;
                titlePageSchoolEnter.Visible = true;
            }
            else
            {
                titlePageSchoolLabel.Visible = false;
                titlePageSchoolEnter.Visible = false;
            }
        }

        private void titlePageDateCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageDateCheck.Checked)
            {
                titlePageDateLabel.Visible = true;
                titlePageDateEnter.Visible = true;
            }
            else
            {
                titlePageDateLabel.Visible = false;
                titlePageDateEnter.Visible = false;
            }
        }

        private void summaryIncludeTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (summaryIncludeTitleCheck.Checked)
            {
                summaryTitleGroupBox.Height = 150;
                summaryDefaultButton.Location = new Point(9, 198);
                summaryOptionsGroupBox.Height = 230;
                summaryContentGroupBox.Location = new Point(9, 279);
                summaryPanel.Height = 545;
                summaryTitleTextLabel.Visible = true;
                summaryTitleText.Visible = true;
                summaryTitleBoldCheck.Visible = true;
                summaryTitleFontLabel.Visible = true;
                summaryTitleFontChoose.Visible = true;
                summaryTitleSizeLabel.Visible = true;
                summaryTitleSizeChoose.Visible = true;
                summaryTitleColorLabel.Visible = true;
                summaryTitleColorText.Visible = true;
                summaryTitleColorButton.Visible = true;
                lowerSection(105, "SUMMARY");
                sections["SUMMARY"] = 545;
            }
            else
            {
                summaryTitleTextLabel.Visible = false;
                summaryTitleText.Visible = false;
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
                summaryContentGroupBox.Location = new Point(9, 174);
                summaryPanel.Height = 440;
                raiseSection(105, "SUMMARY");
                sections["SUMMARY"] = 440;
            }
        }

        private void abstractIncludeTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (abstractIncludeTitleCheck.Checked)
            {
                abstractTitleGroupBox.Height = 150;
                abstractDefaultButton.Location = new Point(9, 198);
                abstractOptionsGroupBox.Height = 230;
                abstractContentGroupBox.Location = new Point(9, 279);
                abstractPanel.Height = 545;
                abstractTitleLabel.Visible = true;
                abstractTitleText.Visible = true;
                abstractTitleBoldCheck.Visible = true;
                abstractTitleFontLabel.Visible = true;
                abstractTitleFontChoose.Visible = true;
                abstractTitleSizeLabel.Visible = true;
                abstractTitleSizeChoose.Visible = true;
                abstractTitleColorLabel.Visible = true;
                abstractTitleColorText.Visible = true;
                abstractTitleColorButton.Visible = true;
                lowerSection(105, "ABSTRACT");
                sections["ABSTRACT"] = 545;
            }
            else
            {
                abstractTitleLabel.Visible = false;
                abstractTitleText.Visible = false;
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
                abstractContentGroupBox.Location = new Point(9, 174);
                abstractPanel.Height = 440;
                raiseSection(105, "ABSTRACT");
                sections["ABSTRACT"] = 440;
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

        private void includeSectionLabelsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (includeSectionLabelsCheck.Checked)
            {
                lowerSection(270, "SECTIONS");
                sections["SECTIONS"] = 865;
                sectionsPanel.Height = 865;
                addSectionButton.Location = new Point(9, 832);
                section1AddSubsectionButton.Location = new Point(9, 282);
                section1ContentPanel.Location = new Point(9, 67);
                section1contentLabel.Location = new Point(6, 49);
                section1groupBox.Height = 315;
                section1groupBox.Location = new Point(9, 511);
                sectionsOptionsGroupBox.Height = 455;
                sectionsDefaultButton.Location = new Point(9, 422);
                sectionLabelGroupBox.Height = 288;
                sectionLabelLocationGroupBox.Visible = true;
                sectionLabelStyleGroupBox.Visible = true;
                section1LabelLabel.Visible = true;
                section1LabelEnter.Visible = true;
            }
            else
            {
                sectionLabelLocationGroupBox.Visible = false;
                sectionLabelStyleGroupBox.Visible = false;
                section1LabelLabel.Visible = false;
                section1LabelEnter.Visible = false;
                sectionLabelGroupBox.Height = 45;
                sectionsDefaultButton.Location = new Point(9, 179);
                sectionsOptionsGroupBox.Height = 212;
                section1groupBox.Location = new Point(9, 268);
                section1contentLabel.Location = new Point(6, 22);
                section1ContentPanel.Location = new Point(9, 40);
                section1AddSubsectionButton.Location = new Point(9, 259);
                section1groupBox.Height = 292;
                addSectionButton.Location = new Point(9, 562);
                sectionsPanel.Height = 595;
                sections["SECTIONS"] = 595;
                raiseSection(270, "SECTIONS");
            }
        }

        private void conclusionIncludeTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (conclusionIncludeTitleCheck.Checked)
            {
                lowerSection(105, "CONCLUSION");
                sections["CONCLUSION"] = 545;
                conclusionPanel.Height = 545;
                conclusionContentGroupBox.Location = new Point(9, 279);
                conclusionDefaultButton.Location = new Point(9, 198);
                conclusionOptionsGroupBox.Height = 230;
                conclusionTitleGroupBox.Height = 150;
                conclusionTitleLabel.Visible = true;
                conclusionTitleEnter.Visible = true;
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
                conclusionTitleLabel.Visible = false;
                conclusionTitleEnter.Visible = false;
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
                conclusionContentGroupBox.Location = new Point(9, 174);
                conclusionPanel.Height = 440;
                sections["CONCLUSION"] = 440;
                raiseSection(105, "CONCLUSION");
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

        private void sectionAddSubsectionButton_Click(object sender, EventArgs e)
        {
            SubSection subSectionToAdd = new SubSection();
            
            int sectionIndex = Convert.ToInt32(((Button)sender).Tag);
            int subsectionIndex = 0;

            foreach (Section section in contentSections)
            {
                if (section.index == sectionIndex)
                {
                    subsectionIndex = section.subSections.Count + 1;
                    subSectionToAdd.index = subsectionIndex;
                    section.subSections.Add(subSectionToAdd);
                }
            }

            GroupBox subSectionToAddGroupBox = new GroupBox();
            subSectionToAddGroupBox.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "GroupBox";
            subSectionToAddGroupBox.Text = "Subsection " + subsectionIndex;            

            GroupBox sectionToAddTo = (GroupBox)this.Controls.Find("section" + sectionIndex + "groupBox", true)[0];
            sectionToAddTo.Controls.Add(subSectionToAddGroupBox);
            subSectionToAddGroupBox.Height = 260;
            subSectionToAddGroupBox.Width = sectionToAddTo.Width - 18;
            subSectionToAddGroupBox.Font = new Font(subSectionToAddGroupBox.Font, FontStyle.Regular);

            Label subsectionContentLabel = new Label();
            subsectionContentLabel.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "ContentLabel";
            subsectionContentLabel.Text = "Content:";
            subsectionContentLabel.Size = new Size(47, 13);
            subSectionToAddGroupBox.Controls.Add(subsectionContentLabel);
            subsectionContentLabel.Location = new Point(6, 22);

            Panel subsectionContentPanel = new Panel();
            subsectionContentPanel.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "ContentPanel";
            subsectionContentPanel.Height = 210;
            subsectionContentPanel.Width = subSectionToAddGroupBox.Width - 18;
            subSectionToAddGroupBox.Controls.Add(subsectionContentPanel);
            subsectionContentPanel.Location = new Point(9, 40);

            ToolStripContainer subsectionToolStripContainer = new ToolStripContainer();
            subsectionToolStripContainer.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "ToolStripContainer";
            subsectionToolStripContainer.Size = subsectionContentPanel.Size;

            ToolStrip subsectionToolStrip = new ToolStrip();
            subsectionToolStrip.RenderMode = ToolStripRenderMode.System;
            subsectionToolStrip.Size = new Size(43, 25);
            subsectionToolStripContainer.TopToolStripPanel.Controls.Add(subsectionToolStrip);
            subsectionContentPanel.Controls.Add(subsectionToolStripContainer);

            RichTextBox subsectionContent = new RichTextBox();
            subsectionContent.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Content";
            subsectionContent.Size = new Size(subsectionToolStripContainer.ContentPanel.Width - 3, subsectionToolStripContainer.ContentPanel.Height - 3);
            subsectionToolStripContainer.ContentPanel.Controls.Add(subsectionContent);
            subsectionContent.Location = new Point(0, 0);

            lowerSection(265, "SECTIONS");
            sectionsPanel.Height = sectionsPanel.Height + 265;
            addSectionButton.Location = new Point(9, addSectionButton.Location.Y + 265);
            sectionToAddTo.Height = sectionToAddTo.Height + 265;
            ((Button)sender).Location = new Point(9, ((Button)sender).Location.Y + 265);
            subSectionToAddGroupBox.Location = new Point(9, 255 + ((subsectionIndex - 1) * 265));
        }
    }
}
