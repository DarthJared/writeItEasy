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
        private bool conclusionActive;
        private bool referencesActive;
        private SortedDictionary<string, int> titlePageOrder = new SortedDictionary<string, int>();
        private SortedDictionary<int, string> orderTitlePage = new SortedDictionary<int, string>();
        public static PaperConfig myPaper = new PaperConfig();
        public string lastEntered;
        public int startSelection;
        public int endSelection;

        private void lowerSection(int pixelsDown, string startSection)
        {
            if (startSection.Equals("GENERAL"))
            {
                if (titlePageActive)
                {
                    titlePagePanel.Location = new Point(0, titlePagePanel.Location.Y + pixelsDown);
                }
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y + pixelsDown);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y + pixelsDown);
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
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y + pixelsDown);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y + pixelsDown);
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
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y - pixelsUp);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y - pixelsUp);
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
                if (abstractActive)
                {
                    abstractPanel.Location = new Point(0, abstractPanel.Location.Y - pixelsUp);
                }
                if (headerActive)
                {
                    headerPanel.Location = new Point(0, headerPanel.Location.Y - pixelsUp);
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

        private bool adjusted = false;

        private void apaGeneral()
        {
            titlePageIncludeCheck.Checked = true;
            abstractIncludeCheck.Checked = true;
            headerIncludeCheck.Checked = true;
            conclusionIncludeCheck.Checked = true;
            referencesIncludeCheck.Checked = true;
        }

        private void apaTitlePage()
        {
            titlePageTitleCheck.Checked = true;
            titlePageNameCheck.Checked = true;
            titlePageSchoolCheck.Checked = true;
            titlePageClassCheck.Checked = false;
            titlePageProfessorCheck.Checked = false;
            titlePageDateCheck.Checked = false;
            titlePageCenterRadio.Checked = true;
            titleOwnPageCheck.Checked = true;
            //TODO Make sure they are ordered correctly
        }

        private void apaAbstract()
        {
            abstractOwnPageCheck.Checked = true;
            abstractIncludeTitleCheck.Checked = true;
            abstractTitleAlignSelect.Text = "Center";
            abstractTitleBoldCheck.Checked = false;
            abstractTitleFontChoose.Text = "Times New Roman";
            abstractTitleSizeChoose.Text = "12";
            abstractTitleColorText.BackColor = Color.FromArgb(255, 0, 0, 0);
            if (abstractTitleText.Text.Length < 1)
            {
                abstractTitleText.Text = "Abstract";
            }
        }

        private void apaHeader()
        {
            headerLeftTitleRadio.Checked = true;
            headerLeftTitleEnter.Text = paperTitleEnter.Text;
            headerRightNumberRadio.Checked = true;
            headerDiffFirstPageCheck.Checked = true;
            headerFirstPageUseRunningHeadCheck.Checked = true;
            headerFirstPageMoreCheck.Checked = false;
        }

        private void apaSections()
        {
            noSpaceBetweenSectionsRadio.Checked = true;
            includeSectionLabelsCheck.Checked = true;
            sectionLabelAlignChoose.Text = "Center";
            sectionLabelBeforeRadio.Checked = true;
            sectionLabelBoldCheck.Checked = true;
            sectionLabelItalicizedCheck.Checked = false;
            sectionLabelFont.Text = "Times New Roman";
            sectionLabelSize.Text = "12";
            sectionLabelColorText.BackColor = Color.FromArgb(255, 0, 0, 0);

            includeSubsectionLabelCheck.Checked = true;
            subsectionLabelAlignChoose.Text = "Left";
            subsectionLabelBeforeRadio.Checked = true;
            subsectionLabelBoldCheck.Checked = true;
            subsectionLabelItalicizedCheck.Checked = false;
            subsectionLabelFont.Text = "Times New Roman";
            subsectionLabelSize.Text = "12";
            subsectionLabelColorText.BackColor = Color.FromArgb(255, 0, 0, 0);

            includeSubsubsectionLabelCheck.Checked = true;
            subsubsectionLabelAlignChoose.Text = "";
            subsubsectionLabelInLineRadio.Checked = true;
            subsubsectionLabelBoldCheck.Checked = true;
            subsubsectionLabelItalicizedCheck.Checked = false;
            subsubsectionLabelFont.Text = "Times New Roman";
            subsubsectionLabelSize.Text = "12";
            subsubsectionLabelColorText.BackColor = Color.FromArgb(255, 0, 0, 0);
        }

        private void apaConclusion()
        {
            conclusionOwnPageCheck.Checked = false;
            conclusionIncludeTitleCheck.Checked = true;
            conclusionTitleAlignChoose.Text = "Center";
            conclusionTitleBoldCheck.Checked = true;
            conclusionTitleFontChoose.Text = "Times New Roman";
            conclusionTitleSizeChoose.Text = "12";
            conclusionTitleColorText.BackColor = Color.FromArgb(255, 0, 0, 0);
            if (conclusionTitleEnter.Text.Length < 1)
            {
                conclusionTitleEnter.Text = "Conclusion";
            }
        }

        private void apaReferences()
        {
            referencesTitleIncludeCheck.Checked = true;
            referencesTitleAlignChoose.Text = "Center";
            referencesTitleBoldCheck.Checked = false;
            referencesTitleEnter.Text = "References";
            referencesTitleFontChoose.Text = "Times New Roman";
            referencesTitleSizeChoose.Text = "12";
            referencesTitleColorText.BackColor = Color.FromArgb(255, 0, 0, 0);
            referencesHangingIndentCheck.Checked = true;
            referencesIndentTabsEnter.Value = 1;
            referencesEmptyLineBetweenCheck.Checked = false;
            referencesOrderChoose.Text = "Alphabetically A-Z";
        }
        private void mlaGeneral()
        {
            titlePageIncludeCheck.Checked = true;
            abstractIncludeCheck.Checked = false;
            headerIncludeCheck.Checked = true;
            conclusionIncludeCheck.Checked = true;
            referencesIncludeCheck.Checked = true;
        }

        private void mlaTitlePage()
        {
            titlePageNameCheck.Checked = true;
            titlePageProfessorCheck.Checked = true;
            titlePageClassCheck.Checked = true;
            titlePageDateCheck.Checked = true;
            titlePageTitleCheck.Checked = false;
            titlePageSchoolCheck.Checked = false;
            titlePageLeftAllignRadio.Checked = true;
            titleInfoTopFirstPageCheck.Checked = true;
            //TODO Make sure they are ordered correctly
        }

        private void mlaHeader()
        {
            headerLeftEmptyRadio.Checked = true;
            headerLeftTitleEnter.Text = paperTitleEnter.Text;
            headerRightNumNameRadio.Checked = true;
            headerDiffFirstPageCheck.Checked = false;
        }

        private void mlaSections()
        {
            blankLineBetweenSectionsRadio.Checked = true;
            includeSectionLabelsCheck.Checked = true;
            sectionLabelAlignChoose.Text = "Center";
            sectionLabelBeforeRadio.Checked = true;
            sectionLabelBoldCheck.Checked = false;
            sectionLabelItalicizedCheck.Checked = false;
            sectionLabelFont.Text = "Times New Roman";
            sectionLabelSize.Text = "12";
            sectionLabelColorText.BackColor = Color.FromArgb(255, 0, 0, 0);

            includeSubsectionLabelCheck.Checked = true;
            subsectionLabelAlignChoose.Text = "Left";
            subsectionLabelBeforeRadio.Checked = true;
            subsectionLabelBoldCheck.Checked = false;
            subsectionLabelItalicizedCheck.Checked = false;
            subsectionLabelFont.Text = "Book Antiqua";
            subsectionLabelSize.Text = "12";
            subsectionLabelColorText.BackColor = Color.FromArgb(255, 0, 0, 0);

            includeSubsubsectionLabelCheck.Checked = true;
            subsubsectionLabelAlignChoose.Text = "";
            subsubsectionLabelInLineRadio.Checked = true;
            subsubsectionLabelBoldCheck.Checked = false;
            subsubsectionLabelItalicizedCheck.Checked = true;
            subsubsectionLabelFont.Text = "Times New Roman";
            subsubsectionLabelSize.Text = "12";
            subsubsectionLabelColorText.BackColor = Color.FromArgb(255, 0, 0, 0);
        }

        private void mlaConclusion()
        {
            conclusionOwnPageCheck.Checked = false;
            conclusionIncludeTitleCheck.Checked = true;
            conclusionTitleAlignChoose.Text = "Left";
            conclusionTitleBoldCheck.Checked = false;
            conclusionTitleFontChoose.Text = "Book Antiqua";
            conclusionTitleSizeChoose.Text = "12";
            if (conclusionTitleEnter.Text.Length < 1)
            {
                conclusionTitleEnter.Text = "Conclusion";
            }
            conclusionTitleColorText.BackColor = Color.FromArgb(255, 0, 0, 0);
        }

        private void mlaReferences()
        {
            referencesTitleIncludeCheck.Checked = true;
            referencesTitleAlignChoose.Text = "Left";
            referencesTitleBoldCheck.Checked = false;
            referencesTitleEnter.Text = "Works Cited";
            referencesTitleFontChoose.Text = "Times New Roman";
            referencesTitleSizeChoose.Text = "12";
            referencesTitleColorText.BackColor = Color.FromArgb(255, 0, 0, 0);
            referencesHangingIndentCheck.Checked = true;
            referencesIndentTabsEnter.Value = 1;
            referencesEmptyLineBetweenCheck.Checked = false;
            referencesOrderChoose.Text = "Alphabetically A-Z";
        }

        private void apaMla_Changed(object sender, EventArgs e)
        {
            string newButtonText;
            if (apaRadio.Checked)
            {
                newButtonText = "APA Defaults";
                apaGeneral();
                apaTitlePage();
                apaAbstract();
                apaHeader();
                apaSections();
                
                if (!adjusted && !subsectionLabelGroupBox.Visible && !subsubsectionLabelGroupBox.Visible)
                {
                    adjusted = true;
                    sectionsDefaultButton.Location = new Point(sectionsDefaultButton.Location.X, sectionsDefaultButton.Location.Y - 480);
                    sectionsOptionsGroupBox.Height -= 480;
                    sectionsPanel.Height -= 480;
                    raiseSection(480, "SECTIONS");
                }
                else if ((!adjusted && !subsectionLabelGroupBox.Visible) ||
                    (!adjusted && !subsubsectionLabelGroupBox.Visible))
                {
                    adjusted = true;
                    sectionsDefaultButton.Location = new Point(sectionsDefaultButton.Location.X, sectionsDefaultButton.Location.Y - 240);
                    sectionsOptionsGroupBox.Height -= 240;
                    sectionsPanel.Height -= 240;
                    raiseSection(240, "SECTIONS");
                }

                apaConclusion();
                apaReferences();
            }
            else
            {
                newButtonText = "MLA Defaults";
                mlaGeneral();
                mlaTitlePage();
                mlaHeader();
                mlaSections();

                if (!adjusted && !subsectionLabelGroupBox.Visible && !subsubsectionLabelGroupBox.Visible)
                {
                    adjusted = true;
                    sectionsDefaultButton.Location = new Point(sectionsDefaultButton.Location.X, sectionsDefaultButton.Location.Y - 480);
                    sectionsOptionsGroupBox.Height -= 480;
                    sectionsPanel.Height -= 480;
                    raiseSection(480, "SECTIONS");
                }
                else if ((!adjusted && !subsectionLabelGroupBox.Visible) ||
                    (!adjusted && !subsubsectionLabelGroupBox.Visible))
                {
                    adjusted = true;
                    sectionsDefaultButton.Location = new Point(sectionsDefaultButton.Location.X, sectionsDefaultButton.Location.Y - 240);
                    sectionsOptionsGroupBox.Height -= 240;
                    sectionsPanel.Height -= 240;
                    raiseSection(240, "SECTIONS");
                }

                mlaConclusion();
                mlaReferences();
            }
            generalDefaultButton.Text = newButtonText;
            titlePageDefaultButton.Text = newButtonText;
            abstractDefaultButton.Text = newButtonText;
            headerDefaultButton.Text = newButtonText;
            sectionsDefaultButton.Text = newButtonText;
            conclusionDefaultButton.Text = newButtonText;
            referencesDefaultButton.Text = newButtonText;
        }
    }
}
