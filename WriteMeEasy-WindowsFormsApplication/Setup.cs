using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
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

            myPaper.sections.Add(new Section(new List<SubSection>(), "", "", 1));
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

            for (int i = 1; i <= myPaper.sections.Count; i++)
            {
                GroupBox sectionGroupBox = (GroupBox)Controls.Find("section" + i + "groupBox", true)[0];
                sectionGroupBox.Width = sectionWidth1In;
                Panel sectionContentPanel = (Panel)Controls.Find("section" + i + "ContentPanel", true)[0];
                sectionContentPanel.Width = sectionWidth2In;
                ToolStripContainer sectionToolStripContainer = (ToolStripContainer)Controls.Find("section" + i + "ToolStripContainer", true)[0];
                sectionToolStripContainer.Width = sectionWidth2In;
                RichTextBox sectionContent = (RichTextBox)Controls.Find("section" + i + "Content", true)[0];
                sectionContent.Width = sectionWidth3InTextBox;
                for (int j = 1; j <= myPaper.sections[i - 1].subSections.Count; j++)
                {
                    GroupBox subsectionGroupBox = (GroupBox)Controls.Find("section" + i + "Subsection" + j + "GroupBox", true)[0];
                    subsectionGroupBox.Width = sectionWidth2In;
                    Panel subsectionContentPanel = (Panel)Controls.Find("section" + i + "Subsection" + j + "ContentPanel", true)[0];
                    subsectionContentPanel.Width = sectionWidth3In;
                    ToolStripContainer subsectionToolStripContainer = (ToolStripContainer)Controls.Find("section" + i + "Subsection" + j + "ToolStripContainer", true)[0];
                    subsectionToolStripContainer.Width = sectionWidth3In;
                    RichTextBox subsectionContent = (RichTextBox)Controls.Find("section" + i + "Subsection" + j + "Content", true)[0];
                    subsectionContent.Width = sectionWidth4InTextBox;
                    for (int k = 1; k <= myPaper.sections[i - 1].subSections[j - 1].subsubSections.Count; k++)
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
    }
}
