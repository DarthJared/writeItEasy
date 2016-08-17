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

            generalPanel.Width = sectionWidth;
            paperTitleGroupBox.Size = new Size(sectionWidth - 25, 55);
            apaMlaGroupBox.Size = new Size(sectionWidth - 25, 70);
            includeInPapeGroupBox.Size = new Size(sectionWidth - 25, 185);

            titlePagePanel.Width = sectionWidth;
            titlePageIncludeGroupBox.Width = sectionWidth - 25;
            titlePageAllignGroupBox.Width = sectionWidth - 25;
            titlePagePositionGroupBox.Width = sectionWidth - 25;

            summaryPanel.Width = sectionWidth;

            abstractPanel.Width = sectionWidth;

            headerPanel.Width = sectionWidth;

            footerPanel.Width = sectionWidth;

            sectionsPanel.Width = sectionWidth;
            sectionsOptionsGroupBox.Width = sectionWidth - 25;
            section1groupBox.Width = sectionWidth - 25;
            section1ContentPanel.Width = section1groupBox.Width - 18;
            Console.WriteLine(section1ToolStrip.Width);
            section1ToolStrip.Width = section1groupBox.Width - 18;
            Console.WriteLine(section1groupBox.Width - 18);
            Console.WriteLine(section1ToolStrip.Width);
            section1Content.Width = section1ToolStrip.Width - 3;
            Console.WriteLine(section1Content.Width + " " + section1ToolStrip.Width + " " + section1groupBox.Width);
            betweenSectionsGroupBox.Width = sectionsOptionsGroupBox.Width - 18;
            sectionLabelGroupBox.Width = sectionsOptionsGroupBox.Width - 18;
            sectionLabelLocationGroupBox.Width = sectionLabelGroupBox.Width - 18;
            sectionLabelStyleGroupBox.Width = sectionLabelGroupBox.Width - 18;

            conclusionPanel.Width = sectionWidth;

            referencesPanel.Width = sectionWidth;

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
