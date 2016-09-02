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

            sections.Add("GENERAL", 440);
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
            summaryPanel.Height = 174;
            sections["SUMMARY"] = 174;

            abstractTitleGroupBox.Height = 45;
            abstractDefaultButton.Location = new Point(9, 93);
            abstractOptionsGroupBox.Height = 125;
            abstractPanel.Height = 174;
            sections["ABSTRACT"] = 174;

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
            sectionsPanel.Height = 266;
            sections["SECTIONS"] = 266;

            conclusionTitleGroupBox.Height = 45;
            conclusionDefaultButton.Location = new Point(9, 93);
            conclusionOptionsGroupBox.Height = 125;            
            conclusionPanel.Height = 172;
            sections["CONCLUSION"] = 172;

            referencesDefaultButton.Location = new Point(9, 233);
            referencesOptionsGroupBox.Height = 185;
            referencesOrderChoose.Location = new Point(44, 152);
            referencesOrderLabel.Location = new Point(6, 155);
            referencesEmptyLineBetweenCheck.Location = new Point(9, 129);
            referencesPanel.Height = 270;
            sections["REFERENCES"] = 270;
            
            section1groupBox.Location = new Point(9, 33);
            section1contentLabel.Location = new Point(6, 49);
            section1ContentPanel.Location = new Point(9, 67);
            section1AddSubsectionButton.Location = new Point(9, 282);
            section1groupBox.Height = 315;
            addSectionButton.Location = new Point(9, 353);
            contentPanel.Height = 404;

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

            TableLayoutPanelCellPosition leftPos = tableLayoutPanel1.GetCellPosition(sectionTabControl);
            int panelWidth = tableLayoutPanel1.GetColumnWidths()[leftPos.Column];
            int panelHeight = tableLayoutPanel1.GetRowHeights()[leftPos.Row];
            sectionTabControl.Width = panelWidth - 6;
            sectionTabControl.Height = panelHeight - 6;

            int sectionWidth = panelWidth - 31;
            int sectionWidth1In = sectionWidth - 25;
            int sectionWidth2In = sectionWidth1In - 18;
            int sectionWidth3In = sectionWidth2In - 18;
            int sectionWidth4In = sectionWidth3In - 18;
            int sectionWidth3InTextBox = sectionWidth2In - 3;
            int sectionWidth4InTextBox = sectionWidth3In - 3;
            int sectionWidth5InTextBox = sectionWidth4In - 3;

            generalPanel.Width = sectionWidth;
            paperTitleGroupBox.Width = sectionWidth1In;
            apaMlaGroupBox.Width = sectionWidth1In;
            includeInPapeGroupBox.Width = sectionWidth1In;

            titlePagePanel.Width = sectionWidth;
            titlePageIncludeGroupBox.Width = sectionWidth1In;
            titlePageAllignGroupBox.Width = sectionWidth1In;
            titlePagePositionGroupBox.Width = sectionWidth1In;

            summaryPanel.Width = sectionWidth;
            summaryOptionsGroupBox.Width = sectionWidth1In;
            summaryTitleGroupBox.Width = sectionWidth2In;
            
            abstractPanel.Width = sectionWidth;
            abstractOptionsGroupBox.Width = sectionWidth1In;
            abstractTitleGroupBox.Width = sectionWidth2In;            

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
            betweenSectionsGroupBox.Width = sectionWidth2In;
            sectionLabelGroupBox.Width = sectionWidth2In;
            sectionLabelLocationGroupBox.Width = sectionWidth3In;
            sectionLabelStyleGroupBox.Width = sectionWidth3In;
            subsectionLabelGroupBox.Width = sectionWidth2In;
            subsectionLabelLocationGroupBox.Width = sectionWidth3In;
            subsectionLabelStyleGroupBox.Width = sectionWidth3In;
            subsubsectionLabelGroupBox.Width = sectionWidth2In;
            subsubsectionLabelLocationGroupBox.Width = sectionWidth3In;
            subsubsectionLabelStyleGroupBox.Width = sectionWidth3In;

            conclusionPanel.Width = sectionWidth;
            conclusionOptionsGroupBox.Width = sectionWidth1In;
            conclusionTitleGroupBox.Width = sectionWidth2In;

            referencesPanel.Width = sectionWidth;
            referencesOptionsGroupBox.Width = sectionWidth1In;
            referencesTitleGroupBox.Width = sectionWidth2In;
            referencesIndentationGroupBox.Width = sectionWidth2In;

            contentPanel.Width = sectionWidth;
            summaryContentGroupBox.Width = sectionWidth1In;
            summaryContentPanel.Width = sectionWidth2In;
            summaryToolStripContainer.Width = sectionWidth2In;
            summaryContent.Width = sectionWidth3InTextBox;
            abstractContentGroupBox.Width = sectionWidth1In;
            abstractContentPanel.Width = sectionWidth2In;
            abstractContentToolStripContainer.Width = sectionWidth2In;
            abstractContent.Width = sectionWidth3InTextBox;
            conclusionContentGroupBox.Width = sectionWidth1In;
            conclusionContentPanel.Width = sectionWidth2In;
            conclusionToolStripContainer.Width = sectionWidth2In;
            conclusionContent.Width = sectionWidth3InTextBox;

            for (int i = 1; i <= contentSections.Count; i++)
            {
                GroupBox sectionGroupBox = (GroupBox)Controls.Find("section" + i + "groupBox", true)[0];
                sectionGroupBox.Width = sectionWidth1In;
                Panel sectionContentPanel = (Panel)Controls.Find("section" + i + "ContentPanel", true)[0];
                sectionContentPanel.Width = sectionWidth2In;
                ToolStripContainer sectionToolStripContainer = (ToolStripContainer)Controls.Find("section" + i + "ToolStripContainer", true)[0];
                sectionToolStripContainer.Width = sectionWidth2In;
                RichTextBox sectionContent = (RichTextBox)Controls.Find("section" + i + "Content", true)[0];
                sectionContent.Width = sectionWidth3InTextBox;
                for (int j = 1; j <= contentSections[i - 1].subSections.Count; j++)
                {
                    GroupBox subsectionGroupBox = (GroupBox)Controls.Find("section" + i + "Subsection" + j + "GroupBox", true)[0];
                    subsectionGroupBox.Width = sectionWidth2In;
                    Panel subsectionContentPanel = (Panel)Controls.Find("section" + i + "Subsection" + j + "ContentPanel", true)[0];
                    subsectionContentPanel.Width = sectionWidth3In;
                    ToolStripContainer subsectionToolStripContainer = (ToolStripContainer)Controls.Find("section" + i + "Subsection" + j + "ToolStripContainer", true)[0];
                    subsectionToolStripContainer.Width = sectionWidth3In;
                    RichTextBox subsectionContent = (RichTextBox)Controls.Find("section" + i + "Subsection" + j + "Content", true)[0];
                    subsectionContent.Width = sectionWidth4InTextBox;
                    for (int k = 1; k <= contentSections[i - 1].subSections[j - 1].subsubSections.Count; k++)
                    {
                        GroupBox subsubsectionGroupBox = (GroupBox)Controls.Find("section" + i + "Subsection" + j + "Subsubsection" + k + "GroupBox", true)[0];
                        subsubsectionGroupBox.Width = sectionWidth3In;
                        Panel subsubsectionContentPanel = (Panel)Controls.Find("section" + i + "Subsection" + j + "Subsubsection" + k + "ContentPanel", true)[0];
                        subsubsectionContentPanel.Width = sectionWidth4In;
                        ToolStripContainer subsubsectionToolStripContainer = (ToolStripContainer)Controls.Find("section" + i + "Subsection" + j + "Subsubsection" + k + "ToolStripContainer", true)[0];
                        subsubsectionToolStripContainer.Width = sectionWidth4In;
                        RichTextBox subsubsectionContent = (RichTextBox)Controls.Find("section" + i + "Subsection" + j + "Subsubsection" + k + "Content", true)[0];
                        subsubsectionContent.Width = sectionWidth5InTextBox;
                    }
                }
            }
            sectionTabControl.ItemSize = new Size((sectionTabControl.Width - 10) / 2, 25);

            checkContentPanelHeight();

            writeButton.Location = new Point(finalizePanel.Width - 125, 8);
        }

        private void checkContentPanelHeight()
        {
            int newHeight = 0;
            foreach (Control control in contentPanel.Controls)
            {
                if (control.Location.Y + control.Height + 20 > newHeight && control.Visible)
                {
                    newHeight = control.Location.Y + control.Height + 20;
                }
            }
            if (newHeight <= sectionTabControl.Height - 30)
            {
                newHeight = sectionTabControl.Height - 30;
            }  
            contentPanel.Height = newHeight;
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
                contentPanel.Height += 312;
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
                contentPanel.Height -= 312;
                conclusionContentGroupBox.Visible = false;

                conclusionPanel.Visible = false;
                raiseSection(sectionHeight, "CONCLUSION");
                conclusionActive = false;
            }
            checkContentPanelHeight();
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
                sections["SUMMARY"] -=105;
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
            int numSections = contentSections.Count;
            int sectionMult = numSections * 27;
            int totalSpace = 243 + sectionMult;
            if (includeSectionLabelsCheck.Checked)
            {
                lowerSection(243, "SECTIONS");
                sections["SECTIONS"] += 243;

                for (int i = 1; i <= numSections; i++)
                {
                    Label sectionLabelLabel = (Label)Controls.Find("section" + i + "LabelLabel", true)[0];
                    sectionLabelLabel.Enabled = true;
                    TextBox sectionLabelEnter = (TextBox)Controls.Find("section" + i + "LabelEnter", true)[0];
                    sectionLabelEnter.Enabled = true;
                }

                addSpace("sectionsDefaultButton", 243, "sectionsPanel", "SECTIONS");     
                sectionLabelGroupBox.Height = 288;
                sectionLabelLocationGroupBox.Visible = true;
                sectionLabelStyleGroupBox.Visible = true;
            }
            else
            {
                raiseSection(243, "SECTIONS");
                sections["SECTIONS"] -= 243;

                for (int i = 1; i <= numSections; i++)
                {
                    Label sectionLabelLabel = (Label)Controls.Find("section" + i + "LabelLabel", true)[0];
                    sectionLabelLabel.Enabled = false;
                    TextBox sectionLabelEnter = (TextBox)Controls.Find("section" + i + "LabelEnter", true)[0];
                    sectionLabelEnter.Enabled = false;
                }

                addSpace("sectionsDefaultButton", -243, "sectionsPanel", "SECTIONS");
                sectionLabelGroupBox.Height = 45;
                sectionLabelLocationGroupBox.Visible = false;
                sectionLabelStyleGroupBox.Visible = false;
            }
            subsectionLabelGroupBox.Location = new Point(9, sectionLabelGroupBox.Location.Y + sectionLabelGroupBox.Height + 13);
            subsubsectionLabelGroupBox.Location = new Point(9, subsectionLabelGroupBox.Location.Y + subsectionLabelGroupBox.Height + 13);
        }

        private void conclusionIncludeTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
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
            if (!subsectionLabelGroupBox.Visible)
            {
                addSpace("sectionsDefaultButton", 56, "sectionsPanel", "SECTIONS");
                subsectionLabelGroupBox.Location = new Point(9, sectionLabelGroupBox.Location.Y + sectionLabelGroupBox.Height + 8);
                subsectionLabelGroupBox.Visible = true;
            }
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

            GroupBox sectionToAddTo = (GroupBox)Controls.Find("section" + sectionIndex + "groupBox", true)[0];
            Control starter = Controls.Find("section" + sectionIndex + "AddSubsectionButton", true)[0];
            GroupBox subsectionToAdd = new GroupBox();
            subsectionToAdd.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "GroupBox";
            subsectionToAdd.Text = "Subsection " + subsectionIndex;
            sectionToAddTo.Controls.Add(subsectionToAdd);

            Label subsectionLabelLabel = new Label();
            subsectionLabelLabel.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "LabelLabel";
            subsectionLabelLabel.Text = "Subsection Label:";
            subsectionToAdd.Controls.Add(subsectionLabelLabel);
            subsectionLabelLabel.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            subsectionLabelLabel.Location = new Point(6, 22);

            TextBox subsectionLabelEnter = new TextBox();
            subsectionLabelEnter.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "LabelEnter";
            subsectionToAdd.Controls.Add(subsectionLabelEnter);
            subsectionLabelEnter.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            subsectionLabelEnter.Location = new Point(110, 19);
            subsectionLabelEnter.Width = 185;

            if (!includeSubsectionLabelCheck.Checked)
            {
                subsectionLabelLabel.Enabled = false;
                subsectionLabelEnter.Enabled = false;
            }

            Label subsectionContentLabel = new Label();
            subsectionContentLabel.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "ContentLabel";
            subsectionContentLabel.Text = "Content:";            
            subsectionToAdd.Controls.Add(subsectionContentLabel);
            subsectionContentLabel.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            subsectionContentLabel.BackColor = Color.Transparent;

            Panel subsectionContentPanel = new Panel();
            subsectionContentPanel.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "ContentPanel";            
            subsectionToAdd.Controls.Add(subsectionContentPanel);

            ToolStripContainer subsectionToolStripContainer = new ToolStripContainer();
            subsectionToolStripContainer.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "toolstripcontainer";            

            ToolStrip subsectionToolStrip = new ToolStrip();
            subsectionToolStrip.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "toolstrip";
            subsectionToolStrip.RenderMode = ToolStripRenderMode.System;
            subsectionToolStrip.Size = new Size(43, 25);
            subsectionToolStripContainer.TopToolStripPanel.Controls.Add(subsectionToolStrip);
            subsectionContentPanel.Controls.Add(subsectionToolStripContainer);

            RichTextBox subsectionContent = new RichTextBox();
            subsectionContent.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Content";            
            subsectionToolStripContainer.ContentPanel.Controls.Add(subsectionContent);
            subsectionContent.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            subsectionContent.Location = new Point(0, 0);

            Button addSubsubsectionButton = new Button();
            addSubsubsectionButton.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "AddSubsubsectionButton";
            addSubsubsectionButton.Text = "Add Subsubsection";
            addSubsubsectionButton.Size = new Size(130, 23);
            addSubsubsectionButton.BackColor = Color.Gainsboro;
            addSubsubsectionButton.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            addSubsubsectionButton.Tag = sectionIndex + "," + subsectionIndex;
            addSubsubsectionButton.Click += new EventHandler(subsectionAddSubsubsectionButton_Click);

            addSpace("section" + sectionIndex + "AddSubsectionButton", 315, "contentPanel", "CONTENT");       
            subsectionToAdd.Location = new Point(9, starter.Location.Y - 310);
            subsectionToAdd.Size = new Size(sectionToAddTo.Width - 18, 305);
            subsectionToAdd.Font = new Font(subsectionToAdd.Font, FontStyle.Regular);            
            subsectionContentLabel.Location = new Point(6, 49);
            subsectionContentPanel.Location = new Point(9, 73);
            subsectionContentPanel.Size = new Size(subsectionToAdd.Width - 18, 189);
            subsectionToolStripContainer.Size = subsectionContentPanel.Size;
            subsectionContent.Size = new Size(subsectionToolStripContainer.ContentPanel.Width - 3, subsectionToolStripContainer.ContentPanel.Height - 3);
            subsectionToAdd.Controls.Add(addSubsubsectionButton);
            addSubsubsectionButton.Location = new Point(9, 272);
            checkContentPanelHeight();
        }

        /* startDropName - Highest object that needs to be lowered
         * totalHeightIncrease - Height that everything needs to be adjusted
         * panelName - Name of part of write it easy being added to
         * dictionaryName - Name of part of write it easy stored in sorted dictionary
         */
        public void addSpace(string startDropName, int totalHeightIncrease, string panelName, string dictionaryName)
        {
            Control starter = Controls.Find(startDropName, true)[0];
            loopParents(starter, totalHeightIncrease, panelName, true);
            //sections[dictionaryName] += totalHeightIncrease;
            //lowerSection(totalHeightIncrease, dictionaryName);
        }

        public void loopParents(Control highestControl, int heightChange, string nameCheck, bool changeHighest)
        {
            Control parent = highestControl.Parent;
            parent.Height += heightChange;
            int checkY = highestControl.Location.Y;
            foreach (Control childControl in parent.Controls)
            {
                if ((changeHighest && childControl.Location.Y >= checkY) || 
                    (!changeHighest && childControl.Location.Y > checkY))
                {
                    childControl.Location = new Point(childControl.Location.X, childControl.Location.Y + heightChange);
                }
            }
            if (!parent.Name.Equals(nameCheck))
            {
                loopParents(parent, heightChange, nameCheck, false);
            }
        }

        private void addSectionButton_Click(object sender, EventArgs e)
        {
            Section newSection = new Section();
            newSection.index = contentSections.Count + 1;
            contentSections.Add(newSection);

            GroupBox newSectionGroupBox = new GroupBox();
            newSectionGroupBox.Name = "section" + newSection.index + "groupBox";
            newSectionGroupBox.Text = "Section " + newSection.index;
            newSectionGroupBox.Font = new Font("Microsoft Sans Serif", (float)9.75, FontStyle.Bold);
            contentPanel.Controls.Add(newSectionGroupBox);

            Label newSectionLabelLabel = new Label();
            newSectionLabelLabel.Name = "section" + newSection.index + "LabelLabel";
            newSectionLabelLabel.Text = "Section Label:";            

            TextBox newSectionLabelEnter = new TextBox();
            newSectionLabelEnter.Name = "section" + newSection.index + "LabelEnter";
            newSectionLabelEnter.Size = new Size(185, 20);
            newSectionGroupBox.Controls.Add(newSectionLabelEnter);
            newSectionLabelEnter.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            newSectionLabelEnter.Location = new Point(81, 19);

            if (!includeSectionLabelsCheck.Checked)
            {
                newSectionLabelLabel.Enabled = false;
                newSectionLabelEnter.Enabled = false;
            }

            newSectionGroupBox.Controls.Add(newSectionLabelLabel);
            newSectionLabelLabel.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            newSectionLabelLabel.Location = new Point(6, 22);

            Label newSectionContentLabel = new Label();
            newSectionContentLabel.Name = "section" + newSection.index + "contentLabel";
            newSectionContentLabel.Text = "Content:";
            newSectionGroupBox.Controls.Add(newSectionContentLabel);
            newSectionContentLabel.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);

            Panel newSectionContentPanel = new Panel();
            newSectionContentPanel.Name = "section" + newSection.index + "ContentPanel";
            newSectionGroupBox.Controls.Add(newSectionContentPanel);

            ToolStripContainer newSectionToolStripContainer = new ToolStripContainer();
            newSectionToolStripContainer.Name = "section" + newSection.index + "ToolStripContainer";
            newSectionContentPanel.Controls.Add(newSectionToolStripContainer);

            ToolStrip newSectionToolStrip = new ToolStrip();
            newSectionToolStrip.Name = "section" + newSection.index + "ToolStrip";
            newSectionToolStrip.RenderMode = ToolStripRenderMode.System;
            newSectionToolStrip.Size = new Size(43, 25);
            newSectionToolStripContainer.TopToolStripPanel.Controls.Add(newSectionToolStrip);

            RichTextBox newSectionContent = new RichTextBox();
            newSectionContent.Name = "section" + newSection.index + "Content";
            newSectionToolStripContainer.ContentPanel.Controls.Add(newSectionContent);
            newSectionContent.Location = new Point(0, 0);
            newSectionContent.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);

            Button newSectionAddSubsectionButton = new Button();
            newSectionAddSubsectionButton.Name = "section" + newSection.index + "AddSubsectionButton";
            newSectionAddSubsectionButton.Text = "Add Subsection";
            newSectionAddSubsectionButton.Size = new Size(130, 23);
            newSectionAddSubsectionButton.BackColor = Color.Gainsboro;
            newSectionGroupBox.Controls.Add(newSectionAddSubsectionButton);
            newSectionGroupBox.Controls.Add(newSectionContentLabel);
            newSectionAddSubsectionButton.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            newSectionAddSubsectionButton.Tag = newSection.index;
            newSectionAddSubsectionButton.Click += new EventHandler(sectionAddSubsectionButton_Click);

            addSpace("addSectionButton", 335, "contentPanel", "CONTENT");
            newSectionGroupBox.Size = new Size(615, 315);
            newSectionGroupBox.Location = new Point(9, addSectionButton.Location.Y - 321);
            newSectionLabelLabel.Visible = true;
            newSectionLabelEnter.Visible = true;
            newSectionContentLabel.Location = new Point(6, 49);
            newSectionContentPanel.Size = new Size(newSectionGroupBox.Width - 18, 210);
            newSectionContentPanel.Location = new Point(9, 67);
            newSectionToolStripContainer.Size = newSectionContentPanel.Size;
            newSectionContent.Size = new Size(newSectionToolStripContainer.ContentPanel.Width - 3, newSectionToolStripContainer.ContentPanel.Height - 3);
            newSectionAddSubsectionButton.Location = new Point(9, 282);
            checkContentPanelHeight();
        }

        private void includeSubsectionLabelCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (includeSubsectionLabelCheck.Checked)
            {
                addSpace("sectionsDefaultButton", 243, "sectionsPanel", "SECTIONS");
                subsectionLabelGroupBox.Height = 288;
                subsectionLabelLocationGroupBox.Visible = true;
                subsectionLabelStyleGroupBox.Visible = true;
                for (int i = 1; i <= contentSections.Count; i++)
                {
                    for (int j = 1; j <= contentSections[i - 1].subSections.Count; j++)
                    {
                        Label subsectionLabelLabel = (Label)Controls.Find("section" + i + "Subsection" + j + "LabelLabel", true)[0];
                        subsectionLabelLabel.Enabled = true;
                        TextBox subsectionLabelTextBox = (TextBox)Controls.Find("section" + i + "Subsection" + j + "LabelEnter", true)[0];
                        subsectionLabelTextBox.Enabled = true;
                    }
                }
            }
            else
            {
                addSpace("sectionsDefaultButton", -243, "sectionsPanel", "SECTIONS");
                subsectionLabelGroupBox.Height = 45;
                subsectionLabelLocationGroupBox.Visible = false;
                subsectionLabelStyleGroupBox.Visible = false;
                for (int i = 1; i <= contentSections.Count; i++)
                {
                    for (int j = 1; j <= contentSections[i - 1].subSections.Count; j++)
                    {
                        Label subsectionLabelLabel = (Label)Controls.Find("section" + i + "Subsection" + j + "LabelLabel", true)[0];
                        subsectionLabelLabel.Enabled = false;
                        TextBox subsectionLabelTextBox = (TextBox)Controls.Find("section" + i + "Subsection" + j + "LabelEnter", true)[0];
                        subsectionLabelTextBox.Enabled = false;
                    }
                }
            }
            subsubsectionLabelGroupBox.Location = new Point(9, subsectionLabelGroupBox.Location.Y + subsectionLabelGroupBox.Height + 13);
        }

        private void includeSubsubsectionLabelCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (includeSubsubsectionLabelCheck.Checked)
            {
                addSpace("sectionsDefaultButton", 243, "sectionsPanel", "SECTIONS");
                subsubsectionLabelGroupBox.Height = 288;
                subsubsectionLabelLocationGroupBox.Visible = true;
                subsubsectionLabelStyleGroupBox.Visible = true;
                for (int i = 1; i <= contentSections.Count; i++)
                {
                    for (int j = 1; j <= contentSections[i - 1].subSections.Count; j++)
                    {
                        for (int k = 1; k <= contentSections[i - 1].subSections[j - 1].subsubSections.Count; k++)
                        {
                            Label subsubsectionLabelLabel = (Label)Controls.Find("section" + i + "Subsection" + j + "Subsubsection" + k + "LabelLabel", true)[0];
                            subsubsectionLabelLabel.Enabled = true;
                            TextBox subsubsectionLabelTextBox = (TextBox)Controls.Find("section" + i + "Subsection" + j + "Subsubsection" + k + "LabelEnter", true)[0];
                            subsubsectionLabelTextBox.Enabled = true;
                        }                        
                    }
                }
            }
            else
            {
                addSpace("sectionsDefaultButton", -243, "sectionsPanel", "SECTIONS");
                subsubsectionLabelGroupBox.Height = 45;
                subsubsectionLabelLocationGroupBox.Visible = false;
                subsubsectionLabelStyleGroupBox.Visible = false;
                for (int i = 1; i <= contentSections.Count; i++)
                {
                    for (int j = 1; j <= contentSections[i - 1].subSections.Count; j++)
                    {
                        for (int k = 1; k <= contentSections[i - 1].subSections[j - 1].subsubSections.Count; k++)
                        {
                            Label subsubsectionLabelLabel = (Label)Controls.Find("section" + i + "Subsection" + j + "Subsubsection" + k + "LabelLabel", true)[0];
                            subsubsectionLabelLabel.Enabled = false;
                            TextBox subsubsectionLabelTextBox = (TextBox)Controls.Find("section" + i + "Subsection" + j + "Subsubsection" + k + "LabelEnter", true)[0];
                            subsubsectionLabelTextBox.Enabled = false;
                        }
                    }
                }
            }
        }

        private void subsectionAddSubsubsectionButton_Click(object sender, EventArgs e)
        {
            if (!subsubsectionLabelGroupBox.Visible)
            {
                addSpace("sectionsDefaultButton", 56, "sectionsPanel", "SECTIONS");
                subsubsectionLabelGroupBox.Location = new Point(9, subsectionLabelGroupBox.Location.Y + subsectionLabelGroupBox.Height + 8);
                subsubsectionLabelGroupBox.Visible = true;
            }
            SubSubSection subsubSectionToAdd = new SubSubSection();

            string tag = (string)((Button)sender).Tag;
            string[] indexes = tag.Split(',');

            int sectionIndex = Convert.ToInt32(indexes[0]);
            int subsectionIndex = Convert.ToInt32(indexes[1]);
            int subsubsectionIndex = 0;
            foreach (Section section in contentSections)
            {
                if (section.index == sectionIndex)
                {
                    foreach (SubSection subsection in section.subSections)
                    {
                        if (subsection.index == subsectionIndex)
                        {
                            subsubsectionIndex = subsection.subsubSections.Count + 1;
                            subsubSectionToAdd.index = subsubsectionIndex;
                            subsection.subsubSections.Add(subsubSectionToAdd);
                        }
                    }   
                }
            }

            GroupBox subsectionToAddTo = (GroupBox)Controls.Find("section" + sectionIndex + "Subsection" + subsectionIndex + "GroupBox", true)[0];
            Control starter = Controls.Find("section" + sectionIndex + "Subsection" + subsectionIndex + "AddSubsubsectionButton", true)[0];
            GroupBox subsubsectionToAdd = new GroupBox();
            subsubsectionToAdd.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Subsubsection" + subsubsectionIndex + "GroupBox";
            subsubsectionToAdd.Text = "Subsubsection " + subsubsectionIndex;
            subsectionToAddTo.Controls.Add(subsubsectionToAdd);

            Label subsubsectionLabelLabel = new Label();
            subsubsectionLabelLabel.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Subsubsection" + subsubsectionIndex + "LabelLabel";
            subsubsectionLabelLabel.Text = "Subsubsection Label:";
            subsubsectionToAdd.Controls.Add(subsubsectionLabelLabel);
            subsubsectionLabelLabel.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            subsubsectionLabelLabel.Location = new Point(6, 22);
            subsubsectionLabelLabel.Size = new Size(110, 13);

            TextBox subsubsectionLabelEnter = new TextBox();
            subsubsectionLabelEnter.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Subsubsection" + subsubsectionIndex + "LabelEnter";
            subsubsectionToAdd.Controls.Add(subsubsectionLabelEnter);
            subsubsectionLabelEnter.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            subsubsectionLabelEnter.Location = new Point(122, 19);
            subsubsectionLabelEnter.Width = 185;

            if (!includeSubsubsectionLabelCheck.Checked)
            {
                subsubsectionLabelLabel.Enabled = false;
                subsubsectionLabelEnter.Enabled = false;
            }

            Label subsubsectionContentLabel = new Label();
            subsubsectionContentLabel.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Subsubsection" + subsubsectionIndex + "ContentLabel";
            subsubsectionContentLabel.Text = "Content:";
            subsubsectionToAdd.Controls.Add(subsubsectionContentLabel);
            subsubsectionContentLabel.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            subsubsectionContentLabel.BackColor = Color.Transparent;

            Panel subsubsectionContentPanel = new Panel();
            subsubsectionContentPanel.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Subsubsection" + subsubsectionIndex + "ContentPanel";
            subsubsectionToAdd.Controls.Add(subsubsectionContentPanel);

            ToolStripContainer subsubsectionToolStripContainer = new ToolStripContainer();
            subsubsectionToolStripContainer.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Subsubsection" + subsubsectionIndex + "toolstripcontainer";

            ToolStrip subsubsectionToolStrip = new ToolStrip();
            subsubsectionToolStrip.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Subsubsection" + subsubsectionIndex + "toolstrip";
            subsubsectionToolStrip.RenderMode = ToolStripRenderMode.System;
            subsubsectionToolStrip.Size = new Size(43, 25);
            subsubsectionToolStripContainer.TopToolStripPanel.Controls.Add(subsubsectionToolStrip);
            subsubsectionContentPanel.Controls.Add(subsubsectionToolStripContainer);

            RichTextBox subsubsectionContent = new RichTextBox();
            subsubsectionContent.Name = "section" + sectionIndex + "Subsection" + subsectionIndex + "Subsubsection" + subsubsectionIndex + "Content";
            subsubsectionToolStripContainer.ContentPanel.Controls.Add(subsubsectionContent);
            subsubsectionContent.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            subsubsectionContent.Location = new Point(0, 0);

            addSpace("section" + sectionIndex + "Subsection" + subsubsectionIndex + "AddSubsubsectionButton", 282, "contentPanel", "CONTENT");
            subsubsectionToAdd.Location = new Point(9, starter.Location.Y - 277);
            subsubsectionToAdd.Size = new Size(subsectionToAddTo.Width - 18, 272);
            subsubsectionToAdd.Font = new Font(subsubsectionToAdd.Font, FontStyle.Regular);
            subsubsectionContentLabel.Location = new Point(6, 49);
            subsubsectionContentPanel.Location = new Point(9, 73);
            subsubsectionContentPanel.Size = new Size(subsubsectionToAdd.Width - 18, 189);
            subsubsectionToolStripContainer.Size = subsubsectionContentPanel.Size;
            subsubsectionContent.Size = new Size(subsubsectionToolStripContainer.ContentPanel.Width - 3, subsubsectionToolStripContainer.ContentPanel.Height - 3);
            checkContentPanelHeight();

            Console.WriteLine(subsubsectionLabelLabel.Text);
        }

        private void sectionTabControl_Change(object sender, EventArgs e)
        {
            checkContentPanelHeight();
        }
    }
}
