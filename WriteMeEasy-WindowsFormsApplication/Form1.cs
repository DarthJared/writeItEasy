using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        string[] sections;

        public Form1()
        {
            InitializeComponent();
            Height = 600;
            Width = 1000;
            sections = new string[7] {
                "TITLE_PAGE",
                "SUMMARY",
                "ABSTRACT",
                "HEADER",
                "SECTIONS",
                "CONCLUSION",
                "REFERENCES"
            };
        }

        private void titlePageIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            //if (titlePageIncludeCheck.Checked)
            //{
            //    //Lower the rest and add the elements
            //    generalPanel.Height += 100;
            //    lowerSections(100, "TITLE_PAGE");

            //}
            //else
            //{
            //    //raise the rest and remove the elements                
            //    raiseSections(100, "TITLE_PAGE");
            //    generalPanel.Height -= 100;
            //}
        }

        //private void testLower(object sender, EventArgs e)
        //{
        //    lowerSections(100, "HEADER");
        //}

        //private void testRaise(object sender, EventArgs e)
        //{
        //    raiseSections(100, "HEADER");
        //}

        private void resizeEvent(object sender, EventArgs e)
        {
            int sectionWidth = sectionPanel.Width - 17;
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

        //private void lowerSections(int numPixels, string sectionName)
        //{
        //    if (sectionName.Equals("TITLE_PAGE"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            summaryPanel.Location = new Point(0, summaryPanel.Location.Y + 2);
        //            abstractPanel.Location = new Point(0, abstractPanel.Location.Y + 2);
        //            headerPanel.Location = new Point(0, headerPanel.Location.Y + 2);
        //            sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + 2);
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y + 2);
        //        }
        //    }
        //    else if (sectionName.Equals("SUMMARY"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            abstractPanel.Location = new Point(0, abstractPanel.Location.Y + 2);
        //            headerPanel.Location = new Point(0, headerPanel.Location.Y + 2);
        //            sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + 2);
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y + 2);
        //        }
        //    }
        //    else if (sectionName.Equals("ABSTRACT"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            headerPanel.Location = new Point(0, headerPanel.Location.Y + 2);
        //            sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + 2);
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y + 2);
        //        }
        //    }
        //    else if (sectionName.Equals("HEADER"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y + 2);
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y + 2);
        //        }
        //    }
        //    else if (sectionName.Equals("SECTIONS"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y + 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y + 2);
        //        }
        //    }
        //    else if (sectionName.Equals("CONCLUSION"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y + 2);
        //        }
        //    }
        //}

        //private void raiseSections(int numPixels, string sectionName)
        //{
        //    if (sectionName.Equals("TITLE_PAGE"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            summaryPanel.Location = new Point(0, summaryPanel.Location.Y - 2);
        //            abstractPanel.Location = new Point(0, abstractPanel.Location.Y - 2);
        //            headerPanel.Location = new Point(0, headerPanel.Location.Y - 2);
        //            sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - 2);
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y - 2);
        //        }
        //    }
        //    else if (sectionName.Equals("SUMMARY"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            abstractPanel.Location = new Point(0, abstractPanel.Location.Y - 2);
        //            headerPanel.Location = new Point(0, headerPanel.Location.Y - 2);
        //            sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - 2);
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y - 2);
        //        }
        //    }
        //    else if (sectionName.Equals("ABSTRACT"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            headerPanel.Location = new Point(0, headerPanel.Location.Y - 2);
        //            sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - 2);
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y - 2);
        //        }
        //    }
        //    else if (sectionName.Equals("HEADER"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            sectionsPanel.Location = new Point(0, sectionsPanel.Location.Y - 2);
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y - 2);
        //        }
        //    }
        //    else if (sectionName.Equals("SECTIONS"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            conclusionPanel.Location = new Point(0, conclusionPanel.Location.Y - 2);
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y - 2);
        //        }
        //    }
        //    else if (sectionName.Equals("CONCLUSION"))
        //    {
        //        for (int i = 0; i < numPixels; i += 2)
        //        {
        //            referencesPanel.Location = new Point(0, referencesPanel.Location.Y - 2);
        //        }
        //    }
        //}
    }
}
