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
        private static PaperConfig myPaper = new PaperConfig();
        private string lastEntered;

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

        /* startDropName - Highest object that needs to be lowered
         * totalHeightIncrease - Height that everything needs to be adjusted
         * panelName - Name of part of write it easy being added to
         * dictionaryName - Name of part of write it easy stored in sorted dictionary
         */
        public void addSpace(string startDropName, int totalHeightIncrease, string panelName, string dictionaryName)
        {
            Control starter = Controls.Find(startDropName, true)[0];
            loopParents(starter, totalHeightIncrease, panelName, true);
            if (!panelName.Equals("contentPanel"))
            {
                sections[dictionaryName] += totalHeightIncrease;
                lowerSection(totalHeightIncrease, dictionaryName);
            }
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

        private void sectionTabControl_Change(object sender, EventArgs e)
        {
            checkContentPanelHeight();
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
    }
}
