using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private void summaryTitleText_TextChanged(object sender, EventArgs e)
        {            
            myPaper.summary.title = summaryTitleText.Text;
        }

        private void abstractTitleText_TextChanged(object sender, EventArgs e)
        {
            myPaper.abstractConfig.title = abstractTitleText.Text;
        }

        private void conclusionTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.conclusion.title = conclusionTitleEnter.Text;
        }

        private void summaryContent_TextChanged(object sender, EventArgs e)
        {
            startSelection = summaryContent.SelectionStart;
            endSelection = summaryContent.SelectionLength + summaryContent.SelectionStart;

            bool boldStarted = false;
            bool italicStarted = false;
            bool underlineStarted = false;
            bool indentStarted = false;
            string formattedSummary = "";
            string currentFont = "";
            string currentSize = "";
            
            for (int i = 0; i < summaryContent.Text.Length; i++)
            {
                summaryContent.Select(i, 1);
                if (summaryContent.SelectionIndent == 40 && summaryContent.SelectionHangingIndent == 0 && !indentStarted)
                {
                    formattedSummary += '\v';
                    indentStarted = true;
                }
                else if ((summaryContent.SelectionIndent != 40 || summaryContent.SelectionHangingIndent != 0) && indentStarted)
                {
                    formattedSummary += '\v';
                    indentStarted = false;
                }
                if (summaryContent.SelectionFont.Bold && !boldStarted)
                {
                    formattedSummary += '\b';
                    boldStarted = true;
                }
                else if (!summaryContent.SelectionFont.Bold && boldStarted)
                {
                    formattedSummary += '\b';
                    boldStarted = false;
                }
                if (summaryContent.SelectionFont.Italic && !italicStarted)
                {
                    formattedSummary += '\a';
                    italicStarted = true;
                }
                else if (!summaryContent.SelectionFont.Italic && italicStarted)
                {
                    formattedSummary += '\a';
                    italicStarted = false;
                }
                if (summaryContent.SelectionFont.Underline && !underlineStarted)
                {
                    formattedSummary += '\f';
                    underlineStarted = true;
                }
                else if (!summaryContent.SelectionFont.Underline && underlineStarted)
                {
                    formattedSummary += '\f';
                    underlineStarted = false;
                }
                if (!summaryContent.SelectionFont.Name.Equals(currentFont))
                {
                    currentFont = summaryContent.SelectionFont.Name;
                    formattedSummary += "\\ffffffffff\\" + currentFont + "\\ffffffffffff\\";
                }
                if (!summaryContent.SelectionFont.Size.ToString().Equals(currentSize))
                {
                    currentSize = summaryContent.SelectionFont.Size.ToString();
                    formattedSummary += "\\ssssssssss\\" + currentSize + "\\ssssssssssss\\";
                }
                if (summaryContent.SelectedText.Equals('\n'.ToString()))
                {
                    if (boldStarted)
                    {
                        formattedSummary += '\b';
                    }
                    if (italicStarted)
                    {
                        formattedSummary += '\a';
                    }
                    if (underlineStarted)
                    {
                        formattedSummary += '\f';
                    }
                    if (indentStarted)
                    {
                        formattedSummary += '\v';
                    }
                    indentStarted = false;
                    boldStarted = false;
                    italicStarted = false;
                    underlineStarted = false;
                }
                formattedSummary += summaryContent.Text[i];
                if (summaryContent.SelectedText.Equals('\n'.ToString()))
                {
                    formattedSummary += "\\ffffffffff\\" + summaryContent.SelectionFont.Name + "\\ffffffffffff\\";
                    formattedSummary += "\\ssssssssss\\" + summaryContent.SelectionFont.Size.ToString() + "\\ssssssssssss\\";
                }
            }
            myPaper.summary.content = formattedSummary;
        }

        private void abstractContent_TextChanged(object sender, EventArgs e)
        {
            startSelection = abstractContent.SelectionStart;
            endSelection = abstractContent.SelectionLength + abstractContent.SelectionStart;
            bool boldStarted = false;
            bool italicStarted = false;
            bool underlineStarted = false;
            bool indentStarted = false;
            string formattedAbstract = "";
            string currentFont = "";
            string currentSize = "";
            for (int i = 0; i < abstractContent.Text.Length; i++)
            {
                abstractContent.Select(i, 1);
                if (abstractContent.SelectionIndent == 40 && abstractContent.SelectionHangingIndent == 0 && !indentStarted)
                {
                    formattedAbstract += '\v';
                    indentStarted = true;
                }
                else if ((abstractContent.SelectionIndent != 40 || abstractContent.SelectionHangingIndent != 0) && indentStarted)
                {
                    formattedAbstract += '\v';
                    indentStarted = false;
                }
                if (abstractContent.SelectionFont.Bold && !boldStarted)
                {
                    formattedAbstract += '\b';
                    boldStarted = true;
                }
                else if (!abstractContent.SelectionFont.Bold && boldStarted)
                {
                    formattedAbstract += '\b';
                    boldStarted = false;
                }
                if (abstractContent.SelectionFont.Italic && !italicStarted)
                {
                    formattedAbstract += '\a';
                    italicStarted = true;
                }
                else if (!abstractContent.SelectionFont.Italic && italicStarted)
                {
                    formattedAbstract += '\a';
                    italicStarted = false;
                }
                if (abstractContent.SelectionFont.Underline && !underlineStarted)
                {
                    formattedAbstract += '\f';
                    underlineStarted = true;
                }
                else if (!abstractContent.SelectionFont.Underline && underlineStarted)
                {
                    formattedAbstract += '\f';
                    underlineStarted = false;
                }
                if (!abstractContent.SelectionFont.Name.Equals(currentFont))
                {
                    currentFont = abstractContent.SelectionFont.Name;
                    formattedAbstract += "\\ffffffffff\\" + currentFont + "\\ffffffffffff\\";

                }
                if (!abstractContent.SelectionFont.Size.ToString().Equals(currentSize))
                {
                    currentSize = abstractContent.SelectionFont.Size.ToString();
                    formattedAbstract += "\\ssssssssss\\" + currentSize + "\\ssssssssssss\\";
                }
                if (abstractContent.SelectedText.Equals('\n'.ToString()))
                {
                    if (boldStarted)
                    {
                        formattedAbstract += '\b';
                    }
                    if (italicStarted)
                    {
                        formattedAbstract += '\a';
                    }
                    if (underlineStarted)
                    {
                        formattedAbstract += '\f';
                    }
                    if (indentStarted)
                    {
                        formattedAbstract += '\v';
                    }
                    indentStarted = false;
                    boldStarted = false;
                    italicStarted = false;
                    underlineStarted = false;
                }
                formattedAbstract += abstractContent.Text[i];
                if (abstractContent.SelectedText.Equals('\n'.ToString()))
                {
                    formattedAbstract += "\\ffffffffff\\" + abstractContent.SelectionFont.Name + "\\ffffffffffff\\";
                    formattedAbstract += "\\ssssssssss\\" + abstractContent.SelectionFont.Size.ToString() + "\\ssssssssssss\\";
                }
            }
            myPaper.abstractConfig.content = formattedAbstract;
        }

        private void conclusionContent_TextChanged(object sender, EventArgs e)
        {
            startSelection = conclusionContent.SelectionStart;
            endSelection = conclusionContent.SelectionLength + conclusionContent.SelectionStart;
            bool boldStarted = false;
            bool italicStarted = false;
            bool underlineStarted = false;
            bool indentStarted = false;
            string formattedConclusion = "";
            string currentFont = "";
            string currentSize = "";
            for (int i = 0; i < conclusionContent.Text.Length; i++)
            {
                conclusionContent.Select(i, 1);
                if (conclusionContent.SelectionIndent == 40 && conclusionContent.SelectionHangingIndent == 0 && !indentStarted)
                {
                    formattedConclusion += '\v';
                    indentStarted = true;
                }
                else if ((conclusionContent.SelectionIndent != 40 || conclusionContent.SelectionHangingIndent != 0) && indentStarted)
                {
                    formattedConclusion += '\v';
                    indentStarted = false;
                }
                if (conclusionContent.SelectionFont.Bold && !boldStarted)
                {
                    formattedConclusion += '\b';
                    boldStarted = true;
                }
                else if (!conclusionContent.SelectionFont.Bold && boldStarted)
                {
                    formattedConclusion += '\b';
                    boldStarted = false;
                }
                if (conclusionContent.SelectionFont.Italic && !italicStarted)
                {
                    formattedConclusion += '\a';
                    italicStarted = true;
                }
                else if (!conclusionContent.SelectionFont.Italic && italicStarted)
                {
                    formattedConclusion += '\a';
                    italicStarted = false;
                }
                if (conclusionContent.SelectionFont.Underline && !underlineStarted)
                {
                    formattedConclusion += '\f';
                    underlineStarted = true;
                }
                else if (!conclusionContent.SelectionFont.Underline && underlineStarted)
                {
                    formattedConclusion += '\f';
                    underlineStarted = false;
                }
                if (!conclusionContent.SelectionFont.Name.Equals(currentFont))
                {
                    currentFont = conclusionContent.SelectionFont.Name;
                    formattedConclusion += "\\ffffffffff\\" + currentFont + "\\ffffffffffff\\";
                }
                if (!conclusionContent.SelectionFont.Size.ToString().Equals(currentSize))
                {
                    currentSize = conclusionContent.SelectionFont.Size.ToString();
                    formattedConclusion += "\\ssssssssss\\" + currentSize + "\\ssssssssssss\\";
                }
                if (conclusionContent.SelectedText.Equals('\n'.ToString()))
                {
                    if (boldStarted)
                    {
                        formattedConclusion += '\b';
                    }
                    if (italicStarted)
                    {
                        formattedConclusion += '\a';
                    }
                    if (underlineStarted)
                    {
                        formattedConclusion += '\f';
                    }
                    if (indentStarted)
                    {
                        formattedConclusion += '\v';
                    }
                    indentStarted = false;
                    boldStarted = false;
                    italicStarted = false;
                    underlineStarted = false;
                }
                formattedConclusion += conclusionContent.Text[i];
                if (conclusionContent.SelectedText.Equals('\n'.ToString()))
                {
                    formattedConclusion += "\\ffffffffff\\" + conclusionContent.SelectionFont.Name + "\\ffffffffffff\\";
                    formattedConclusion += "\\ssssssssss\\" + conclusionContent.SelectionFont.Size.ToString() + "\\ssssssssssss\\";
                }
            }
            myPaper.conclusion.conclusionContent = formattedConclusion;
        }

        private void conclusionOwnPageCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.conclusion.onOwnPage = conclusionOwnPageCheck.Checked;
        }

        private void sectionLabelBeforeRadio_Changed(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.sectionLabelOnOwnLine = sectionLabelBeforeRadio.Checked;
            myPaper.sectionsConfig.sectionLabelInlineWithText = !sectionLabelBeforeRadio.Checked;
        }

        private void sectionLabelInLineRadio_Changed(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.sectionLabelInlineWithText = sectionLabelInLineRadio.Checked;
            myPaper.sectionsConfig.sectionLabelOnOwnLine = !sectionLabelInLineRadio.Checked;
        }

        private void subsectionLabelBeforeRadio_Changed(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsectionLabelOnOwnLine = subsectionLabelBeforeRadio.Checked;
            myPaper.sectionsConfig.subsectionLabelInlineWithText = !subsectionLabelBeforeRadio.Checked;
        }

        private void subsectionLabelInLineRadio_Changed(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsectionLabelInlineWithText = subsectionLabelInLineRadio.Checked;
            myPaper.sectionsConfig.subsectionLabelOnOwnLine = !subsectionLabelInLineRadio.Checked;
        }

        private void subsubsectionLabelBeforeRadio_Changed(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsubsectionLabelOnOwnLine = subsubsectionLabelBeforeRadio.Checked;
            myPaper.sectionsConfig.subsubsectionLabelInlineWithText = !subsubsectionLabelBeforeRadio.Checked;
        }

        private void subsubsectionLabelInLineRadio_Changed(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsubsectionLabelInlineWithText = subsubsectionLabelInLineRadio.Checked;
            myPaper.sectionsConfig.subsubsectionLabelOnOwnLine = !subsubsectionLabelInLineRadio.Checked;
        }

        private void paperTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.titleOfPaper = paperTitleEnter.Text;
        }

        private void generalDefaultButton_Click(object sender, EventArgs e)
        {
            //Set default settings for general section
        }

        private void titlePageTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.titlePage.title = titlePageTitleEnter.Text;
        }

        private void titlePageNameEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.titlePage.name = titlePageNameEnter.Text;
        }

        private void titlePageClassEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.titlePage.className = titlePageClassEnter.Text;
        }

        private void titlePageProfessorEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.titlePage.professor = titlePageProfessorEnter.Text;
        }

        private void titlePageSchoolEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.titlePage.school = titlePageSchoolEnter.Text;
        }

        private void titlePageDateEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.titlePage.date = titlePageDateEnter.Text;
        }

        private void titlePageLeftAllignRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageLeftAllignRadio.Checked)
            {
                myPaper.titlePage.alignment = "left";
            }
        }

        private void titlePageCenterRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageCenterRadio.Checked)
            {
                myPaper.titlePage.alignment = "center";
            }
        }

        private void titlePageRightAllignRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageRightAllignRadio.Checked)
            {
                myPaper.titlePage.alignment = "right";
            }
        }

        private void titlePageTopRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageTopRadio.Checked)
            {
                myPaper.titlePage.position = "top";
            }
        }

        private void titlePageMiddleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageMiddleRadio.Checked)
            {
                myPaper.titlePage.position = "middle";
            }
        }

        private void titlePageBottomRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageBottomRadio.Checked)
            {
                myPaper.titlePage.position = "bottom";
            }
        }

        private void titlePageDefaultButton_Click(object sender, EventArgs e)
        {
            //Set default settings for title page
        }

        private void summaryOwnPageCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.summary.onOwnPage = summaryOwnPageCheck.Checked;
        }

        private void summaryTitleBoldCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.summary.titleBold = summaryTitleBoldCheck.Checked;
        }

        private void summaryTitleFontChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.summary.titleFont = summaryTitleFontChoose.Text;
        }

        private void summaryTitleSizeChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.summary.titleSize = Convert.ToInt32(summaryTitleSizeChoose.Text);
        }

        private void summaryTitleColorButton_Click(object sender, EventArgs e)
        {
            //Change Title Color
        }

        private void summaryDefaultButton_Click(object sender, EventArgs e)
        {
            //Set default settings for summary
        }

        private void headerLeftTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.leftTitleText = headerLeftTitleEnter.Text;
        }

        private void headerLeftNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.header.leftPageNumStart = Convert.ToInt32(headerLeftNumberEnter.Value);
        }

        private void headerLeftOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.leftOtherText = headerLeftOtherEnter.Text;
        }

        private void headerCenterTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.centerTitleText = headerCenterTitleEnter.Text;
        }

        private void headerCenterNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.header.centerPageNumStart = Convert.ToInt32(headerCenterNumberEnter.Value);
        }

        private void headerCenterOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.centerOtherText = headerCenterOtherEnter.Text;
        }

        private void headerRightTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.rightTitleText = headerRightTitleEnter.Text;
        }

        private void headerRightNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.header.rightPageNumStart = Convert.ToInt32(headerRightNumberEnter.Value);
        }

        private void headerRightOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.rightOtherText = headerRightOtherEnter.Text;
        }

        private void headerFirstPageUseRunningHeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.header.useRunningHead = headerFirstPageUseRunningHeadCheck.Checked;
        }

        private void headerFirstLeftTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.firstLeftTitleText = headerFirstLeftTitleEnter.Text;
        }

        private void headerFirstLeftNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.header.firstLeftPageNumStart = Convert.ToInt32(headerFirstLeftNumberEnter.Value);
        }

        private void headerFirstLeftOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.firstLeftOtherText = headerFirstLeftOtherEnter.Text;
        }

        private void headerFirstCenterTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.firstCenterTitleText = headerFirstCenterTitleEnter.Text;
        }

        private void headerFirstCenterNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.header.firstCenterPageNumStart = Convert.ToInt32(headerFirstCenterNumberEnter.Value);
        }

        private void headerFirstCenterOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.firstCenterOtherText = headerFirstCenterOtherEnter.Text;
        }

        private void headerFirstRightTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.firstRightTitleText = headerFirstRightTitleEnter.Text;
        }

        private void headerFirstRightNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.header.firstCenterPageNumStart = Convert.ToInt32(headerFirstCenterNumberEnter.Value);
        }

        private void headerFirstRightOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.header.firstRightOtherText = headerFirstRightOtherEnter.Text;
        }

        private void headerDefaultButton_Click(object sender, EventArgs e)
        {
            //Set default settings for header
        }

        private void footerLeftTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.leftTitleText = footerLeftTitleEnter.Text;
        }

        private void footerLeftNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.footer.leftPageNumStart = Convert.ToInt32(footerLeftNumberEnter.Value);
        }

        private void footerLeftOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.rightOtherText = footerLeftOtherEnter.Text;
        }

        private void footerCenterTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.centerTitleText = footerCenterTitleEnter.Text;
        }

        private void footerCenterNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.footer.centerPageNumStart = Convert.ToInt32(footerCenterNumberEnter.Value);
        }

        private void footerCenterOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.centerOtherText = footerCenterOtherEnter.Text;
        }

        private void footerRightTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.rightTitleText = footerRightTitleEnter.Text;
        }

        private void footerRightNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.footer.rightPageNumStart = Convert.ToInt32(footerRightNumberEnter.Value);
        }

        private void footerRightOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.rightOtherText = footerRightOtherEnter.Text;
        }

        private void footerFirstPageUseRunningHeadCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.footer.useRunningHead = footerFirstPageUseRunningHeadCheck.Checked;
        }

        private void footerFirstLeftTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.firstLeftTitleText = footerFirstLeftTitleEnter.Text;
        }

        private void footerFirstLeftNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.footer.firstLeftPageNumStart = Convert.ToInt32(footerFirstLeftNumberEnter.Value);
        }

        private void footerFirstLeftOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.firstLeftOtherText = footerFirstLeftOtherEnter.Text;
        }

        private void footerFirstCenterTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.firstCenterTitleText = footerFirstCenterTitleEnter.Text;
        }

        private void footerFirstCenterNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.footer.firstCenterPageNumStart = Convert.ToInt32(footerFirstCenterNumberEnter.Value);
        }

        private void footerFirstCenterOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.firstCenterOtherText = footerFirstCenterOtherEnter.Text;
        }

        private void footerFirstRightTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.firstRightTitleText = footerFirstRightTitleEnter.Text;
        }

        private void footerFirstRightNumberEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.footer.firstRightPageNumStart = Convert.ToInt32(footerFirstRightNumberEnter.Value);
        }

        private void footerFirstRightOtherEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.footer.firstRightOtherText = footerFirstRightOtherEnter.Text;
        }

        private void newPageForEachSectionRadio_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.newPageBetween = newPageForEachSectionRadio.Checked;
            myPaper.sectionsConfig.noSpaceBetween = !newPageForEachSectionRadio.Checked;
        }

        private void noSpaceBetweenSectionsRadio_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.newPageBetween = !newPageForEachSectionRadio.Checked;
            myPaper.sectionsConfig.noSpaceBetween = newPageForEachSectionRadio.Checked;
        }

        private void sectionLabelBoldCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.sectionLabelBold = sectionLabelBoldCheck.Checked;
        }

        private void sectionLabelBullettedCheck_CheckedChanged(object sender, EventArgs e)
        {
            //Not sure I want to even make this an option
        }

        private void sectionLabelFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.sectionLabelFont = sectionLabelFont.Text;
        }

        private void sectionLabelSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.sectionLabelSize = Convert.ToInt32(sectionLabelSize.Text);
        }

        private void sectionLabelColorButton_Click(object sender, EventArgs e)
        {
            //Choose Section Label Color
        }

        private void subsectionLabelColorButton_Click(object sender, EventArgs e)
        {
            //Choose Subsection Label Color
        }

        private void subsectionLabelSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsectionLabelSize = Convert.ToInt32(subsectionLabelSize.Text);
        }

        private void subsectionLabelFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsectionLabelFont = subsectionLabelFont.Text;
        }

        private void subsectionLabelBulletted_CheckedChanged(object sender, EventArgs e)
        {
            //Not sure I want to even make this an option
        }

        private void subsectionLabelBoldCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsectionLabelBold = subsectionLabelBoldCheck.Checked;
        }

        private void subsubsectionLabelBoldCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsubsectionLabelBold = subsubsectionLabelBoldCheck.Checked;
        }

        private void subsubsectionLabelBullettedCheck_CheckedChanged(object sender, EventArgs e)
        {
            //Not sure I want to even make this an option
        }

        private void subsubsectionLabelFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsubsectionLabelFont = subsubsectionLabelFont.Text;
        }

        private void subsubsectionLabelSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsubsectionLabelSize = Convert.ToInt32(subsubsectionLabelSize.Text);
        }

        private void subsubsectionLabelButton_Click(object sender, EventArgs e)
        {
            //Choose Subsubsection Label Color
        }

        private void conclusionTitleBoldCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.conclusion.boldTitle = conclusionTitleBoldCheck.Checked;
        }

        private void conclusionTitleFontChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.conclusion.titleFont = conclusionTitleFontChoose.Text;
        }

        private void conclusionTitleSizeChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.conclusion.titleSize = Convert.ToInt32(conclusionTitleSizeChoose.Text);
        }

        private void conclusionTitleColorButton_Click(object sender, EventArgs e)
        {
            //Choose Conclusion Label Color
        }

        private void conclusionDefaultButton_Click(object sender, EventArgs e)
        {
            //Set default settings for conclusion
        }

        private void referencesTitleEnter_TextChanged(object sender, EventArgs e)
        {
            myPaper.references.title = referencesTitleEnter.Text;
        }

        private void referencesTitleBoldCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.references.boldTitle = referencesTitleBoldCheck.Checked;
        }

        private void referencesTitleFontChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.references.titleFont = referencesTitleFontChoose.Text;
        }

        private void referencesTitleSizeChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.references.titleSize = Convert.ToInt32(referencesTitleSizeChoose.Text);
        }

        private void referencesTitleColorButton_Click(object sender, EventArgs e)
        {
            //Choose References Label Color
        }

        private void referencesIndentTabsEnter_ValueChanged(object sender, EventArgs e)
        {
            myPaper.references.tabsHangingIndent = Convert.ToInt32(referencesIndentTabsEnter.Value);
        }

        private void referencesEmptyLineBetweenCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.references.emptyLineBetweenReferences = referencesEmptyLineBetweenCheck.Checked;
        }

        private void referencesOrderChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.references.orderBy = referencesOrderChoose.Text;
        }

        private void referencesDefaultButton_Click(object sender, EventArgs e)
        {
            //Set default settings for references
        }

        private void abstractTitleBoldCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.abstractConfig.titleBold = abstractTitleBoldCheck.Checked;
        }

        private void abstractOwnPageCheck_CheckedChanged(object sender, EventArgs e)
        {
            myPaper.abstractConfig.onOwnPage = abstractOwnPageCheck.Checked;
        }

        private void summaryTitleAlignSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.summary.titleAlign = summaryTitleAlignSelect.Text;
        }

        private void abstractTitleAlignSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.abstractConfig.titleAlign = abstractTitleAlignSelect.Text;
        }

        private void sectionLabelAlignChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.sectionLabelAlignment = sectionLabelAlignChoose.Text;
        }

        private void subsectionLabelAlignChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsectionLabelAlignment = subsectionLabelAlignChoose.Text;
        }

        private void subsubsectionLabelAlignChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.sectionsConfig.subsubsectionLabelAlignment = subsubsectionLabelAlignChoose.Text;
        }

        private void referencesTitleAlignChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.references.titleAlign = referencesTitleAlignChoose.Text;
        }

        private void conclusionTitleAlignChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPaper.conclusion.titleAlign = conclusionTitleAlignChoose.Text;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            paperTitleEnter.Text = "Researched Argument: Is the Robot Better than Me?";
            apaRadio.Checked = true;
            titlePageIncludeCheck.Checked = true;
            abstractIncludeCheck.Checked = true;
            headerIncludeCheck.Checked = true;
            conclusionIncludeCheck.Checked = true;
            referencesIncludeCheck.Checked = true;

            titlePageTitleCheck.Checked = true;
            titlePageNameCheck.Checked = true;
            titlePageClassCheck.Checked = true;
            titlePageSchoolCheck.Checked = true;
            titlePageDateCheck.Checked = true;
            titlePageTitleEnter.Text = "Researched Argument: Is the Robot Better than Me?";
            titlePageNameEnter.Text = "Jared Beagley";
            titlePageClassEnter.Text = "FDENG 201";
            titlePageSchoolEnter.Text = "Brigham Young University - Idaho";
            //titlePageDateEnter.Value = new DateTime();

            titlePageLeftAllignRadio.Checked = true;
            titlePageCenterRadio.Checked = true;

            titlePageTopRadio.Checked = true;
            titlePageMiddleRadio.Checked = true;

            abstractOwnPageCheck.Checked = true;
            abstractIncludeTitleCheck.Checked = true;
            abstractTitleAlignSelect.SelectedIndex = 1;
            abstractTitleBoldCheck.Checked = true;

            headerCenterEmptyRadio.Checked = true;
            headerLeftTitleRadio.Checked = true;
            headerRightNumberRadio.Checked = true;
            headerLeftTitleEnter.Text = "Researched Argument: Is the Robot Better than Me?";
            headerRightNumberEnter.Value = 1;
            headerDiffFirstPageCheck.Checked = true;
            headerFirstPageUseRunningHeadCheck.Checked = true;

            conclusionOwnPageCheck.Checked = true;
            conclusionIncludeTitleCheck.Checked = true;
            conclusionTitleAlignChoose.SelectedIndex = 1;
            conclusionTitleBoldCheck.Checked = true;

            referencesTitleIncludeCheck.Checked = true;
            referencesTitleBoldCheck.Checked = true;
            referencesTitleEnter.Text = "References";
            referencesHangingIndentCheck.Checked = true;

            abstractTitleText.Text = "Abstract";
            abstractContent.Text = "";
            abstractContent.Text = "This paper addresses the question of whether or not the increase in technology and automated equipment is helping or hurting the economy.  It asserts that the increase is helping to create far more jobs than it ever took away, and it is boosting the quality of life tremendously.  It talks about the effects this technological and innovative wave has had in the past with such businesses as the cotton gin, Henry Ford Motor Company, and the various music devices, and how they have helped each generation to have more jobs and a better quality of life.  It also talks about what is projected for the future in technology and automation.  It ends by talking about what experts have projected concerning the amazing effect this upsurge is having.";

            section1LabelEnter.Text = "Section 1";
            section1Content.Text = "";
            section1Content.Text = "Throughout all history there have always been those that have been worried about the increase in technology.  This is evident in the last 40 years by movies about robots taking over the world, always leaving that fear in the viewer’s mind.  Yet still we continue progressing and advancing our technology, and it is replacing more and more jobs daily, yet it is also creating more and more different and diverse jobs every day. This then begs the question: “Is this advancement of technology helping or hurting the public workforce as a whole?” In order to understand this, we need to understand not just the numbers of how many jobs are being lost and created, but what kind of jobs they are, and what qualifications are now necessary for said jobs.  In this constantly advancing world, each person must choose where they stand on this issue because it will affect everyone in some way.  Though this increase in technology has replaced some human labor, it has aided the human race in its advancement and educational progress, and it will continue to create more jobs than it could ever take away.";
            section1AddSubsectionButton.PerformClick();
            
            //Button subsection1AddSubsub = (Button)Controls.Find("section1Subsection1AddSubsubsectionButton", true)[0];
            //subsection1AddSubsub.PerformClick();
            includeSectionLabelsCheck.Checked = true;
            sectionLabelAlignChoose.SelectedIndex = 1;
            sectionLabelBoldCheck.Checked = true;
            sectionLabelBeforeRadio.Checked = true;
            includeSubsectionLabelCheck.Checked = true;
            subsectionLabelAlignChoose.SelectedIndex = 0;
            subsectionLabelBoldCheck.Checked = true;
            subsectionLabelBeforeRadio.Checked = true;
            includeSubsubsectionLabelCheck.Checked = true;
            subsubsectionLabelBoldCheck.Checked = true;
            subsubsectionLabelInLineRadio.Checked = true;

            //TextBox subsectionLabelEnter = (TextBox)Controls.Find("section1Subsection1LabelEnter", true)[0];
            //subsectionLabelEnter.Text = "Subsection 1";
            //RichTextBox subsectionContent = (RichTextBox)Controls.Find("section1Subsection1Content", true)[0];
            //subsectionContent.Text = "Let us look first to the past.  In the late 1700’s, cotton was a very valuable produce and many large plantations were growing it.  The problem was that the cotton plant had very sharp edges that could cut the picker’s hands with ease, and it also contained many hard to remove seeds, taking hours to remove one at a time.  According to History.com, “[t]he average cotton picker could remove the seeds from only about one pound of short-staple cotton per day” (2010).  Then along came Eli Whitney.  He patented a revolutionary machine called the cotton gin.  This machine could receive cotton and, in a relatively short amount of time, digest it, removing all of the seeds and producing the clean product.  Did this invention take away some jobs? Absolutely it did.  No longer was it necessary to hire tons of people and use many of the laborers’ hours, which could be spent doing other things, to do the task the machine could do in a fraction of the time.  However, in the end did it benefit everyone?  Of course it did.  This invention made the work so much more efficient that it “could remove the seeds from 50 pounds of cotton in a single day” (history.com, 2010).  Not only were the cotton pickers’ hands better protected, but cotton harvesting and production was far smoother and more effective, causing the price of cotton to drop and the making of clothes to be less expensive. This, in turn, provided jobs for more clothing makers, factory workers, and many, many others.\nNow move forward a few years to the early 1900’s and a man named Henry Ford.Ford worked at an auto shop and eventually owned his own business which he titled Ford Motor Company.  He had many amazing ideas and helped to develop what we now know as an assembly line.  Before this, each car was very expensive because it took so many people and so much time to put them together, but then the idea came to assign each person a specific job dealing with the construction of the car.When they were done with their job, they would then pass it on to the next person so that he or she could do his or her part.This earliest form of an assembly line increased productivity and made the new line of cars less expensive, so even the average man could afford their own automobile.So, did this new way of thinking take some jobs away? You bet!There were less people needed to construct a car and therefore some may have lost their jobs, but in the end far more were gained. Just look at how many jobs it has created!According to CorporateFord.com, Ford’s official site used to print its reports, Ford Motor Company has “166,000 employees and about 70 plants worldwide” (2012).That is not to mention the other auto companies that borrowed off of this idea and all the auto mechanics that are now in business because your average worker could now afford a car.";

            //TextBox subsubsectionLabelEnter = (TextBox)Controls.Find("section1Subsection1Subsubsection1LabelEnter", true)[0];
            //subsubsectionLabelEnter.Text = "Subsubsection 1";
            //RichTextBox subsubsectionContent = (RichTextBox)Controls.Find("section1Subsection1Subsubsection1Content", true)[0];
            //subsubsectionContent.Text = "Let us look first to the past.  In the late 1700’s, cotton was a very valuable produce and many large plantations were growing it.  The problem was that the cotton plant had very sharp edges that could cut the picker’s hands with ease, and it also contained many hard to remove seeds, taking hours to remove one at a time.  According to History.com, “[t]he average cotton picker could remove the seeds from only about one pound of short-staple cotton per day” (2010).  Then along came Eli Whitney.  He patented a revolutionary machine called the cotton gin.  This machine could receive cotton and, in a relatively short amount of time, digest it, removing all of the seeds and producing the clean product.  Did this invention take away some jobs? Absolutely it did.  No longer was it necessary to hire tons of people and use many of the laborers’ hours, which could be spent doing other things, to do the task the machine could do in a fraction of the time.  However, in the end did it benefit everyone?  Of course it did.  This invention made the work so much more efficient that it “could remove the seeds from 50 pounds of cotton in a single day” (history.com, 2010).  Not only were the cotton pickers’ hands better protected, but cotton harvesting and production was far smoother and more effective, causing the price of cotton to drop and the making of clothes to be less expensive. This, in turn, provided jobs for more clothing makers, factory workers, and many, many others.\nNow move forward a few years to the early 1900’s and a man named Henry Ford.Ford worked at an auto shop and eventually owned his own business which he titled Ford Motor Company.  He had many amazing ideas and helped to develop what we now know as an assembly line.  Before this, each car was very expensive because it took so many people and so much time to put them together, but then the idea came to assign each person a specific job dealing with the construction of the car.When they were done with their job, they would then pass it on to the next person so that he or she could do his or her part.This earliest form of an assembly line increased productivity and made the new line of cars less expensive, so even the average man could afford their own automobile.So, did this new way of thinking take some jobs away? You bet!There were less people needed to construct a car and therefore some may have lost their jobs, but in the end far more were gained. Just look at how many jobs it has created!According to CorporateFord.com, Ford’s official site used to print its reports, Ford Motor Company has “166,000 employees and about 70 plants worldwide” (2012).That is not to mention the other auto companies that borrowed off of this idea and all the auto mechanics that are now in business because your average worker could now afford a car.";

            conclusionTitleEnter.Text = "Conclusion";
            conclusionContent.Text = "";
            conclusionContent.Text = "Through all of this, we see the consistent pattern.  Whether it be the past, or the present, things remain the same.  Though some jobs may be lost, allowing people to continue forward with their ideas and innovations will help the economy, and the public as a whole, far more than it could ever hurt it.  Some may say, “Yes, let’s keep technology increasing. It’s ok as long as it doesn’t take away my job!”  You cannot have it both ways.  Who has the right to say, “I know you’ve come up with a new, more efficient way of doing something, but some people may have to change jobs, so you can’t use it”? Can you imagine what would have happened if Eli Whitney or Henry Ford would have been told that? I am sure we would be having a great time riding our horses to work every day.  Quality of life will improve, and cost of goods will go down. For every job taken by technology, many more are created, and, in this constantly growing world, we need all we can get.";
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            RichTextBox boxToEdit = (RichTextBox)Controls.Find(lastEntered, true)[0];
            int startedIndex = boxToEdit.SelectionStart;
            int selectLength = boxToEdit.SelectionLength;

            if (boxToEdit.SelectedRtf.Contains("\\b") && !boxToEdit.SelectedRtf.Contains("\\b "))
            {                
                for (int i = 0; i < selectLength; i++)
                {
                    boxToEdit.SelectionStart = startedIndex + i;
                    boxToEdit.SelectionLength = 1;
                    if (boxToEdit.SelectionFont.Italic && boxToEdit.SelectionFont.Underline)
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Italic | FontStyle.Underline);
                    }
                    else if (boxToEdit.SelectionFont.Italic)
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Italic);
                    }
                    else if (boxToEdit.SelectionFont.Underline)
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Underline);
                    }
                    else
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Regular);
                    }
                }
            }
            else
            {
                for (int i = 0; i < selectLength; i++)
                {
                    boxToEdit.SelectionStart = startedIndex + i;
                    boxToEdit.SelectionLength = 1;
                    boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Bold | boxToEdit.SelectionFont.Style);
                }
            }

            boxToEdit.SelectionStart = startedIndex;
            boxToEdit.SelectionLength = selectLength;
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            RichTextBox boxToEdit = (RichTextBox)Controls.Find(lastEntered, true)[0];
            int startedIndex = boxToEdit.SelectionStart;
            int selectLength = boxToEdit.SelectionLength;

            if (boxToEdit.SelectedRtf.Contains("\\i") && !boxToEdit.SelectedRtf.Contains("\\i "))
            {
                for (var i = 0; i < selectLength; i++)
                {
                    boxToEdit.SelectionStart = startedIndex + i;
                    boxToEdit.SelectionLength = 1;
                    if (boxToEdit.SelectionFont.Bold && boxToEdit.SelectionFont.Underline)
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Bold | FontStyle.Underline);
                    }
                    else if (boxToEdit.SelectionFont.Bold)
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Bold);
                    }
                    else if (boxToEdit.SelectionFont.Underline)
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Underline);
                    }
                    else
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Regular);
                    }
                }
            }
            else
            {
                for (var i = 0; i < selectLength; i++)
                {
                    boxToEdit.SelectionStart = startedIndex + i;
                    boxToEdit.SelectionLength = 1;
                    boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Italic | boxToEdit.SelectionFont.Style);
                }
            }

            boxToEdit.SelectionStart = startedIndex;
            boxToEdit.SelectionLength = selectLength;
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            RichTextBox boxToEdit = (RichTextBox)Controls.Find(lastEntered, true)[0];
            int startedIndex = boxToEdit.SelectionStart;
            int selectLength = boxToEdit.SelectionLength;

            if (boxToEdit.SelectedRtf.Contains("\\ul") && !boxToEdit.SelectedRtf.Contains("\\ul "))
            {
                for (var i = 0; i < selectLength; i++)
                {
                    boxToEdit.SelectionStart = startedIndex + i;
                    boxToEdit.SelectionLength = 1;
                    if (boxToEdit.SelectionFont.Bold && boxToEdit.SelectionFont.Italic)
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Bold | FontStyle.Italic);
                    }
                    else if (boxToEdit.SelectionFont.Bold)
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Bold);
                    }
                    else if (boxToEdit.SelectionFont.Italic)
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Italic);
                    }
                    else
                    {
                        boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Regular);
                    }
                }
            }
            else
            {
                for (var i = 0; i < selectLength; i++)
                {
                    boxToEdit.SelectionStart = startedIndex + i;
                    boxToEdit.SelectionLength = 1;
                    boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont, FontStyle.Underline | boxToEdit.SelectionFont.Style);
                }
            }

            boxToEdit.SelectionStart = startedIndex;
            boxToEdit.SelectionLength = selectLength;
        }
        
        private void summaryLast(object sender, EventArgs e)
        {
            lastEntered = "summaryContent";

        }

        private void abstractLast(object sender, EventArgs e)
        {
            lastEntered = "abstractContent";
        }

        private void conclusionLast(object sender, EventArgs e)
        {
            lastEntered = "conclusionContent";
        }

        private void sectionLast(object sender, EventArgs e)
        {
            int sectionIndex = Convert.ToInt32(((RichTextBox)sender).Tag);
            lastEntered = "section" + sectionIndex + "Content";
        }

        private void subsectionLast(object sender, EventArgs e)
        {
            string tag = (string)((RichTextBox)sender).Tag;
            string[] indexes = tag.Split(',');
            int sectionIndex = Convert.ToInt32(indexes[0]);
            int subsectionIndex = Convert.ToInt32(indexes[1]);
            lastEntered = "section" + sectionIndex + "Subsection" + subsectionIndex + "Content";
        }

        private void subsubsectionLast(object sender, EventArgs e)
        {
            string tag = (string)((RichTextBox)sender).Tag;
            string[] indexes = tag.Split(',');
            int sectionIndex = Convert.ToInt32(indexes[0]);
            int subsectionIndex = Convert.ToInt32(indexes[1]);
            int subsubsectionIndex = Convert.ToInt32(indexes[2]);
            lastEntered = "section" + sectionIndex + "Subsection" + subsectionIndex + "Subsubsection" + subsubsectionIndex + "Content";
        }

        private void changeFont(object sender, EventArgs e)
        {
            RichTextBox boxToEdit = (RichTextBox)Controls.Find(lastEntered, true)[0];
            boxToEdit.Focus();
            boxToEdit.SelectionStart = startSelection;
            boxToEdit.SelectionLength = endSelection - startSelection;

            for (int i = 0; i < endSelection - startSelection; i++)
            {
                boxToEdit.Select(startSelection + i, 1);
                boxToEdit.SelectionFont = new Font(fontSelect.SelectedItem.ToString(), boxToEdit.SelectionFont.Size, boxToEdit.SelectionFont.Style);                
            }
            boxToEdit.SelectionStart = startSelection;
            boxToEdit.SelectionLength = endSelection - startSelection;
        }

        private void changeSize(object sender, EventArgs e)
        {
            RichTextBox boxToEdit = (RichTextBox)Controls.Find(lastEntered, true)[0];
            boxToEdit.Focus();
            boxToEdit.SelectionStart = startSelection;
            boxToEdit.SelectionLength = endSelection - startSelection;

            for (int i = 0; i < endSelection - startSelection; i++)
            {
                boxToEdit.Select(startSelection + i, 1);
                boxToEdit.SelectionFont = new Font(boxToEdit.SelectionFont.FontFamily.Name, (float)Convert.ToDouble(fontSize.SelectedItem), boxToEdit.SelectionFont.Style);
            }
            boxToEdit.SelectionStart = startSelection;
            boxToEdit.SelectionLength = endSelection - startSelection;
        }

        private void addReferenceButton_Click(object sender, EventArgs e)
        {
            if (lastEntered.Length > 0)
            {
                if (apaRadio.Checked)
                {
                    var referencePopup = new ReferenceAdder(this);
                    referencePopup.ShowDialog(this);
                }
                else if (mlaRadio.Checked)
                {
                    var citationPopup = new CitationAdder(this);
                    citationPopup.ShowDialog(this);
                }
            }            
            else
            {
                MessageBox.Show("Choose where you want to have the quote or citation inserted and then select to insert the citation.\n");
            }            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (myPaper.titleOfPaper != null && myPaper.titleOfPaper.Length > 0)
            {
                saveFile.FileName = myPaper.titleOfPaper + ".write";
            }
            else
            {
                saveFile.FileName = "newProject.write";
            }
            saveFile.ShowDialog(this);                        
        }

        private void saveFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fileName = saveFile.FileName;
            if (fileName.Length > 0)
            {
                if (fileName.Length > 6)
                {
                    string ext = fileName[fileName.Length - 6].ToString() + fileName[fileName.Length - 5].ToString() + fileName[fileName.Length - 4].ToString() + fileName[fileName.Length - 3].ToString() + fileName[fileName.Length - 2].ToString() + fileName[fileName.Length - 1].ToString();
                    if (!ext.Equals(".write"))
                    {
                        fileName += ".write";
                    }
                }
                else
                {
                    fileName += ".write";
                }
                XDocument xDocument = null;
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { CheckCharacters = false };
                using (XmlWriter writer = XmlWriter.Create(fileName, xmlWriterSettings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Paper");

                    /*General Paper Configurations*/
                    writer.WriteElementString("PaperTitle", myPaper.titleOfPaper.ToString());
                    string apaMla = "";
                    if (myPaper.isAPA)
                    {
                        apaMla = "APA";
                    }
                    else if (myPaper.isMLA)
                    {
                        apaMla = "MLA";
                    }
                    writer.WriteElementString("APAMLA", apaMla);
                    writer.WriteElementString("IncludeTitlePage", myPaper.includeTitlePage.ToString());
                    writer.WriteElementString("IncludeSummary", myPaper.includeSummary.ToString());
                    writer.WriteElementString("IncludeAbstract", myPaper.includeAbstract.ToString());
                    writer.WriteElementString("IncludeHeader", myPaper.includeHeader.ToString());
                    writer.WriteElementString("IncludeConclusion", myPaper.includeConclusion.ToString());
                    writer.WriteElementString("IncludeReferences", myPaper.includeReferences.ToString());

                    /*Title Page Configurations*/
                    writer.WriteElementString("TitlePageIncludeTitle", myPaper.titlePage.includeTitle.ToString());
                    writer.WriteElementString("TitlePageIncludeName", myPaper.titlePage.includeName.ToString());
                    writer.WriteElementString("TitlePageIncludeClass", myPaper.titlePage.includeClass.ToString());
                    writer.WriteElementString("TitlePageIncludeProfessor", myPaper.titlePage.includeProfessor.ToString());
                    writer.WriteElementString("TitlePageIncludeSchool", myPaper.titlePage.includeSchool.ToString());
                    writer.WriteElementString("TitlePageIncludeDate", myPaper.titlePage.includeDate.ToString());
                    writer.WriteElementString("TitlePageTitle", myPaper.titlePage.title.ToString());
                    writer.WriteElementString("TitlePageName", myPaper.titlePage.name.ToString());
                    writer.WriteElementString("TitlePageClass", myPaper.titlePage.className.ToString());
                    writer.WriteElementString("TitlePageProfessor", myPaper.titlePage.professor.ToString());
                    writer.WriteElementString("TitlePageSchool", myPaper.titlePage.school.ToString());
                    writer.WriteElementString("TitlePageDate", myPaper.titlePage.date.ToString());
                    writer.WriteElementString("TitlePageAlignment", myPaper.titlePage.alignment);
                    foreach (string item in myPaper.titlePage.titlePageOrder)
                    {
                        writer.WriteElementString("TitlePageItem", item);
                    }

                    /*Summary Configurations*/
                    writer.WriteElementString("SummaryOwnPage", myPaper.summary.onOwnPage.ToString());
                    writer.WriteElementString("SummaryIncludeTitle", myPaper.summary.includeTitle.ToString());
                    writer.WriteElementString("SummaryTitle", myPaper.summary.title);
                    writer.WriteElementString("SummaryBoldTitle", myPaper.summary.titleBold.ToString());
                    writer.WriteElementString("SummaryTitleFont", myPaper.summary.titleFont);
                    writer.WriteElementString("SummaryTitleSize", myPaper.summary.titleSize.ToString());
                    writer.WriteElementString("SummaryTitleColor", myPaper.summary.titleColor);
                    writer.WriteElementString("SummaryTitleAlign", myPaper.summary.titleAlign);
                    writer.WriteElementString("SummaryContent", myPaper.summary.content);

                    /*Abstract Configurations*/
                    writer.WriteElementString("AbstractOwnPage", myPaper.abstractConfig.onOwnPage.ToString());
                    writer.WriteElementString("AbstractIncludeTitle", myPaper.abstractConfig.includeTitle.ToString());
                    writer.WriteElementString("AbstractTitle", myPaper.abstractConfig.title);
                    writer.WriteElementString("AbstractBoldTitle", myPaper.abstractConfig.titleBold.ToString());
                    writer.WriteElementString("AbstractTitleFont", myPaper.abstractConfig.titleFont);
                    writer.WriteElementString("AbstractTitleSize", myPaper.abstractConfig.titleSize.ToString());
                    writer.WriteElementString("AbstractTitleColor", myPaper.abstractConfig.titleColor);
                    writer.WriteElementString("AbstractTitleAlign", myPaper.abstractConfig.titleAlign);
                    writer.WriteElementString("AbstractContent", myPaper.abstractConfig.content);

                    /*Header Configurations*/
                    writer.WriteElementString("HeaderDifferentFirst", myPaper.header.differentFirstPage.ToString());
                    writer.WriteElementString("HeaderUseRunningHead", myPaper.header.useRunningHead.ToString());
                    writer.WriteElementString("HeaderLeftTitle", myPaper.header.leftTitle.ToString());
                    writer.WriteElementString("HeaderLeftPageNum", myPaper.header.leftPageNum.ToString());
                    writer.WriteElementString("HeaderLeftOther", myPaper.header.leftOther.ToString());
                    writer.WriteElementString("HeaderLeftNone", myPaper.header.leftNone.ToString());
                    writer.WriteElementString("HeaderCenterTitle", myPaper.header.centerTitle.ToString());
                    writer.WriteElementString("HeaderCenterPageNum", myPaper.header.centerPageNum.ToString());
                    writer.WriteElementString("HeaderCenterOther", myPaper.header.centerOther.ToString());
                    writer.WriteElementString("HeaderCenterNone", myPaper.header.centerNone.ToString());
                    writer.WriteElementString("HeaderRightTitle", myPaper.header.rightTitle.ToString());
                    writer.WriteElementString("HeaderRightPageNum", myPaper.header.rightPageNum.ToString());
                    writer.WriteElementString("HeaderRightOther", myPaper.header.rightOther.ToString());
                    writer.WriteElementString("HeaderRightNone", myPaper.header.rightNone.ToString());
                    writer.WriteElementString("HeaderFirstLeftTitle", myPaper.header.firstLeftTitle.ToString());
                    writer.WriteElementString("HeaderFirstLeftPageNum", myPaper.header.firstLeftPageNum.ToString());
                    writer.WriteElementString("HeaderFirstLeftOther", myPaper.header.firstLeftOther.ToString());
                    writer.WriteElementString("HeaderFirstLeftNone", myPaper.header.firstLeftNone.ToString());                                              
                    writer.WriteElementString("HeaderFirstCenterTitle", myPaper.header.firstCenterTitle.ToString());
                    writer.WriteElementString("HeaderFirstCenterPageNum", myPaper.header.firstCenterPageNum.ToString());
                    writer.WriteElementString("HeaderFirstCenterOther", myPaper.header.firstCenterOther.ToString());
                    writer.WriteElementString("HeaderFirstCenterNone", myPaper.header.firstCenterNone.ToString());                                               
                    writer.WriteElementString("HeaderFirstRightTitle", myPaper.header.firstRightTitle.ToString());
                    writer.WriteElementString("HeaderFirstRightPageNum", myPaper.header.firstRightPageNum.ToString());
                    writer.WriteElementString("HeaderFirstRightOther", myPaper.header.firstRightOther.ToString());
                    writer.WriteElementString("HeaderFirstRightNone", myPaper.header.firstRightNone.ToString());
                    writer.WriteElementString("HeaderEnterLeftTitle", myPaper.header.leftTitleText);
                    writer.WriteElementString("HeaderEnterLeftPageStart", myPaper.header.leftPageNumStart.ToString());
                    writer.WriteElementString("HeaderEnterLeftOther", myPaper.header.leftOtherText);
                    writer.WriteElementString("HeaderEnterCenterTitle", myPaper.header.centerTitleText);
                    writer.WriteElementString("HeaderEnterCenterPageStart", myPaper.header.centerPageNumStart.ToString());
                    writer.WriteElementString("HeaderEnterCenterOther", myPaper.header.centerOtherText);
                    writer.WriteElementString("HeaderEnterRightTitle", myPaper.header.rightTitleText);
                    writer.WriteElementString("HeaderEnterRightPageStart", myPaper.header.rightPageNumStart.ToString());
                    writer.WriteElementString("HeaderEnterRightOther", myPaper.header.rightOtherText);
                    writer.WriteElementString("HeaderEnterFirstLeftTitle", myPaper.header.firstLeftTitleText);
                    writer.WriteElementString("HeaderEnterFirstLeftPageStart", myPaper.header.firstLeftPageNumStart.ToString());
                    writer.WriteElementString("HeaderEnterFirstLeftOther", myPaper.header.firstLeftOtherText);                                              
                    writer.WriteElementString("HeaderEnterFirstCenterTitle", myPaper.header.firstCenterTitleText);
                    writer.WriteElementString("HeaderEnterFirstCenterPageStart", myPaper.header.firstCenterPageNumStart.ToString());
                    writer.WriteElementString("HeaderEnterFirstCenterOther", myPaper.header.firstCenterOtherText);                                            
                    writer.WriteElementString("HeaderEnterFirstRightTitle", myPaper.header.firstRightTitleText);
                    writer.WriteElementString("HeaderEnterFirstRightPageStart", myPaper.header.firstRightPageNumStart.ToString());
                    writer.WriteElementString("HeaderEnterFirstRightOther", myPaper.header.firstRightOtherText);

                    /*References Configurations*/
                    writer.WriteElementString("ReferencesIncludeTitle", myPaper.references.includeTitle.ToString());
                    writer.WriteElementString("ReferencesTitle", myPaper.references.title);
                    writer.WriteElementString("ReferencesTitleAlign", myPaper.references.titleAlign);
                    writer.WriteElementString("ReferencesBoldTitle", myPaper.references.boldTitle.ToString());
                    writer.WriteElementString("ReferencesTitleFont", myPaper.references.titleFont);
                    writer.WriteElementString("ReferencesTitleSize", myPaper.references.titleSize.ToString());
                    writer.WriteElementString("ReferencesTitleColor", myPaper.references.titleColor);
                    writer.WriteElementString("ReferencesHangingIndent", myPaper.references.hangingIndent.ToString());
                    writer.WriteElementString("ReferencesNumTabsHanging", myPaper.references.tabsHangingIndent.ToString());
                    writer.WriteElementString("ReferencesEmptyLineBetween", myPaper.references.emptyLineBetweenReferences.ToString());
                    writer.WriteElementString("ReferencesOrderBy", myPaper.references.orderBy);
                    foreach (Reference reference in myPaper.references.references)
                    {
                        writer.WriteStartElement("Reference");
                        writer.WriteElementString("Formatted", reference.formattedReference);
                        writer.WriteElementString("Type", reference.type);
                        writer.WriteElementString("PublicationDate", reference.publicationDate);
                        writer.WriteElementString("Title", reference.title);
                        writer.WriteElementString("Publisher", reference.publisher);
                        writer.WriteElementString("PublishLocation", reference.publishLocation);
                        writer.WriteElementString("Edition", reference.edition);
                        writer.WriteElementString("Section", reference.section);
                        writer.WriteElementString("Volume", reference.volume);
                        writer.WriteElementString("Issue", reference.issue);
                        writer.WriteElementString("StartPage", reference.startPage);
                        writer.WriteElementString("EndPage", reference.endPage);
                        writer.WriteElementString("OriginalPublishDate", reference.originalPublishDate);
                        writer.WriteElementString("Source", reference.source);
                        writer.WriteElementString("RetrievedFrom", reference.retrievedFrom);
                        writer.WriteElementString("Doi", reference.doi);
                        writer.WriteElementString("InterviewDate", reference.interviewDate);
                        writer.WriteElementString("Number", reference.number);
                        writer.WriteElementString("ReviewTitle", reference.reviewTitle);
                        writer.WriteElementString("RetrieveDate", reference.retrieveDate);
                        writer.WriteElementString("Accession", reference.accession);
                        writer.WriteElementString("Institution", reference.institution);
                        writer.WriteElementString("Location", reference.location);
                        writer.WriteElementString("Organization", reference.organization);
                        writer.WriteElementString("Studio", reference.studio);
                        writer.WriteElementString("RecordDate", reference.recordDate);
                        writer.WriteElementString("AccessedOn", reference.accessedOn);
                        writer.WriteElementString("ScreenName", reference.screenName);
                        writer.WriteElementString("Meeting", reference.meeting);
                        writer.WriteElementString("Venue", reference.venue);
                        writer.WriteElementString("Format", reference.format);
                        writer.WriteElementString("CallLetters", reference.callLetters);
                        writer.WriteElementString("Season", reference.season);
                        writer.WriteElementString("Episode", reference.episode);
                        writer.WriteElementString("ArtistName", reference.artistName);
                        foreach (Author author in reference.authors)
                        {
                            writer.WriteStartElement("Author");
                            writer.WriteElementString("FirstName", author.firstName);
                            writer.WriteElementString("MiddleName", author.middleName);
                            writer.WriteElementString("LastName", author.lastName);
                            writer.WriteElementString("CompleteName", author.completeName);
                            writer.WriteEndElement();
                        }
                        foreach (Author author in reference.translators)
                        {
                            writer.WriteStartElement("Translator");
                            writer.WriteElementString("FirstName", author.firstName);
                            writer.WriteElementString("MiddleName", author.middleName);
                            writer.WriteElementString("LastName", author.lastName);
                            writer.WriteElementString("CompleteName", author.completeName);
                            writer.WriteEndElement();
                        }
                        foreach (Author author in reference.interviewers)
                        {
                            writer.WriteStartElement("Interviewer");
                            writer.WriteElementString("FirstName", author.firstName);
                            writer.WriteElementString("MiddleName", author.middleName);
                            writer.WriteElementString("LastName", author.lastName);
                            writer.WriteElementString("CompleteName", author.completeName);
                            writer.WriteEndElement();
                        }
                        foreach (Author author in reference.interviewees)
                        {
                            writer.WriteStartElement("Interviewee");
                            writer.WriteElementString("FirstName", author.firstName);
                            writer.WriteElementString("MiddleName", author.middleName);
                            writer.WriteElementString("LastName", author.lastName);
                            writer.WriteElementString("CompleteName", author.completeName);
                            writer.WriteEndElement();
                        }
                        foreach (Author author in reference.reviewers)
                        {
                            writer.WriteStartElement("Reviewer");
                            writer.WriteElementString("FirstName", author.firstName);
                            writer.WriteElementString("MiddleName", author.middleName);
                            writer.WriteElementString("LastName", author.lastName);
                            writer.WriteElementString("CompleteName", author.completeName);
                            writer.WriteEndElement();
                        }
                        writer.WriteStartElement("Producer");
                        writer.WriteElementString("FirstName", reference.producer.firstName);
                        writer.WriteElementString("MiddleName", reference.producer.middleName);
                        writer.WriteElementString("LastName", reference.producer.lastName);
                        writer.WriteElementString("CompleteName", reference.producer.completeName);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Director");
                        writer.WriteElementString("FirstName", reference.director.firstName);
                        writer.WriteElementString("MiddleName", reference.director.middleName);
                        writer.WriteElementString("LastName", reference.director.lastName);
                        writer.WriteElementString("CompleteName", reference.director.completeName);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Writer");
                        writer.WriteElementString("FirstName", reference.writer.firstName);
                        writer.WriteElementString("MiddleName", reference.writer.middleName);
                        writer.WriteElementString("LastName", reference.writer.lastName);
                        writer.WriteElementString("CompleteName", reference.writer.completeName);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Artist");
                        writer.WriteElementString("FirstName", reference.artist.firstName);
                        writer.WriteElementString("MiddleName", reference.artist.middleName);
                        writer.WriteElementString("LastName", reference.artist.lastName);
                        writer.WriteElementString("CompleteName", reference.artist.completeName);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Editor");
                        writer.WriteElementString("FirstName", reference.editor.firstName);
                        writer.WriteElementString("MiddleName", reference.editor.middleName);
                        writer.WriteElementString("LastName", reference.editor.lastName);
                        writer.WriteElementString("CompleteName", reference.editor.completeName);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Communicator");
                        writer.WriteElementString("FirstName", reference.communicator.firstName);
                        writer.WriteElementString("MiddleName", reference.communicator.middleName);
                        writer.WriteElementString("LastName", reference.communicator.lastName);
                        writer.WriteElementString("CompleteName", reference.communicator.completeName);
                        writer.WriteEndElement();
                        writer.WriteStartElement("Receiver");
                        writer.WriteElementString("FirstName", reference.receiver.firstName);
                        writer.WriteElementString("MiddleName", reference.receiver.middleName);
                        writer.WriteElementString("LastName", reference.receiver.lastName);
                        writer.WriteElementString("CompleteName", reference.receiver.completeName);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }

                    /*Sections Configurations*/
                    writer.WriteElementString("SectionsBlankLineBetweem", myPaper.sectionsConfig.blankLineBetween.ToString());
                    writer.WriteElementString("SectionsNewPageBetween", myPaper.sectionsConfig.newPageBetween.ToString());
                    writer.WriteElementString("SectionsNoSpaceBetween", myPaper.sectionsConfig.noSpaceBetween.ToString());
                    writer.WriteElementString("SectionsIncludeSectionLabel", myPaper.sectionsConfig.includeSectionLabels.ToString());
                    writer.WriteElementString("SectionsIncludeSubsectionLabel", myPaper.sectionsConfig.includeSubsectionLabels.ToString());
                    writer.WriteElementString("SectionsIncludeSubsubsectionLabel", myPaper.sectionsConfig.includeSubsubsectionLabels.ToString());
                    writer.WriteElementString("SectionLabelInline", myPaper.sectionsConfig.sectionLabelInlineWithText.ToString());
                    writer.WriteElementString("SectionLabelOwnLine", myPaper.sectionsConfig.sectionLabelOnOwnLine.ToString());
                    writer.WriteElementString("SectionLabelBold", myPaper.sectionsConfig.sectionLabelBold.ToString());
                    writer.WriteElementString("SectionLabelAlign", myPaper.sectionsConfig.sectionLabelAlignment);
                    writer.WriteElementString("SectionLabelFont", myPaper.sectionsConfig.sectionLabelFont);
                    writer.WriteElementString("SectionLabelSize", myPaper.sectionsConfig.sectionLabelSize.ToString());
                    writer.WriteElementString("SectionLabelColor", myPaper.sectionsConfig.sectionLabelColor);
                    writer.WriteElementString("SubsectionLabelInline", myPaper.sectionsConfig.subsectionLabelInlineWithText.ToString());
                    writer.WriteElementString("SubsectionLabelOwnLine", myPaper.sectionsConfig.subsectionLabelOnOwnLine.ToString());
                    writer.WriteElementString("SubsectionLabelBold", myPaper.sectionsConfig.subsectionLabelBold.ToString());
                    writer.WriteElementString("SubsectionLabelAlign", myPaper.sectionsConfig.subsectionLabelAlignment);
                    writer.WriteElementString("SubsectionLabelFont", myPaper.sectionsConfig.subsectionLabelFont);
                    writer.WriteElementString("SubsectionLabelSize", myPaper.sectionsConfig.subsectionLabelSize.ToString());
                    writer.WriteElementString("SubsectionLabelColor", myPaper.sectionsConfig.subsectionLabelColor);                                                
                    writer.WriteElementString("SubsubsectionLabelInline", myPaper.sectionsConfig.subsubsectionLabelInlineWithText.ToString());
                    writer.WriteElementString("SubsubsectionLabelOwnLine", myPaper.sectionsConfig.subsubsectionLabelOnOwnLine.ToString());
                    writer.WriteElementString("SubsubsectionLabelBold", myPaper.sectionsConfig.subsubsectionLabelBold.ToString());
                    writer.WriteElementString("SubsubsectionLabelAlign", myPaper.sectionsConfig.subsubsectionLabelAlignment);
                    writer.WriteElementString("SubsubsectionLabelFont", myPaper.sectionsConfig.subsubsectionLabelFont);
                    writer.WriteElementString("SubsubsectionLabelSize", myPaper.sectionsConfig.subsubsectionLabelSize.ToString());
                    writer.WriteElementString("SubsubsectionLabelColor", myPaper.sectionsConfig.subsubsectionLabelColor);                    
                    foreach (Section section in myPaper.sections)
                    {
                        writer.WriteStartElement("SectionElement");
                        writer.WriteElementString("Content", section.content);
                        writer.WriteElementString("Title", section.title);
                        writer.WriteElementString("Index", section.index.ToString());
                        foreach(SubSection subsection in section.subSections)
                        {
                            writer.WriteStartElement("Subsection");
                            writer.WriteElementString("Content", subsection.content);
                            writer.WriteElementString("Title", subsection.title);
                            writer.WriteElementString("Index", subsection.index.ToString());
                            foreach (SubSubSection subsubsection in subsection.subsubSections)
                            {
                                writer.WriteStartElement("Subsubsection");
                                writer.WriteElementString("Content", subsubsection.content);
                                writer.WriteElementString("Title", subsubsection.title);
                                writer.WriteElementString("Index", subsubsection.index.ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }

                    /*Conclusion Configurations*/
                    writer.WriteElementString("ConclusionOnOwnPage", myPaper.conclusion.onOwnPage.ToString());
                    writer.WriteElementString("ConclusionIncludeTitle", myPaper.conclusion.includeTitle.ToString());
                    writer.WriteElementString("ConclusionTitle", myPaper.conclusion.title);
                    writer.WriteElementString("ConclusionTitleAlign", myPaper.conclusion.titleAlign);
                    writer.WriteElementString("ConclusionBoldTitle", myPaper.conclusion.boldTitle.ToString());
                    writer.WriteElementString("ConclusionTitleFont", myPaper.conclusion.titleFont);
                    writer.WriteElementString("ConclusionTitleSize", myPaper.conclusion.titleSize.ToString());
                    writer.WriteElementString("ConclusionTitleColor", myPaper.conclusion.titleColor);
                    writer.WriteElementString("ConclusionContent", myPaper.conclusion.conclusionContent);

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                MessageBox.Show("Your project has been saved!\n");
            }
            else
            {
                MessageBox.Show("Enter the name you would like to use to store the file.\n");
            }      
        }

        private void openFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool inReference = false;
            bool newReference = false;
            Reference reference = new Reference();
            bool inReferenceAuthor = false;
            bool newReferenceAuthor = false;
            Author author = new Author();
            bool inReferenceTranslator = false;
            bool newReferenceTranslator = false;
            Author translator = new Author();
            bool inReferenceInterviewer = false;
            bool newReferenceInterviewer = false;
            Author interviewer = new Author();
            bool inReferenceInterviewee = false;
            bool newReferenceInterviewee = false;
            Author interviewee = new Author();
            bool inReferenceReviewer = false;
            bool newReferenceReviewer = false;
            Author reviewer = new Author();
            bool inReferenceProducer = false;
            bool newReferenceProducer = false;
            Author producer = new Author();
            bool inReferenceDirector = false;
            bool newReferenceDirector = false;
            Author director = new Author();
            bool inReferenceWriter = false;
            bool newReferenceWriter = false;
            Author writer = new Author();
            bool inReferenceArtist = false;
            bool newReferenceArtist = false;
            Author artist = new Author();
            bool inReferenceEditor = false;
            bool newReferenceEditor = false;
            Author editor = new Author();
            bool inReferenceCommunicator = false;
            bool newReferenceCommunicator = false;
            Author communcator = new Author();
            bool inReferenceReceiver = false;
            bool newReferenceReceiver = false;
            Author receiver = new Author();
            bool inSection = false;
            bool newSection = false;
            bool inSubsection = false;
            bool newSubsection = false;
            bool inSubsubsection = false;
            bool newSubsubsection = false;
            Section section = new Section();
            int numSections = 1;
            int numSectionsStarted = 0;
            int numSubsections = 0;
            int numSubsectionsStarted = 0;
            int numSubsubsections = 0;
            int numSubsubsectionsStarted = 0;


            string fileName = openFile.FileName;
            XDocument xDocument = null;
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings { CheckCharacters = false };
            using (XmlReader reader = XmlReader.Create(fileName, xmlReaderSettings))
            {
                while (reader.Read())
                {
                    //// Only detect start elements.
                    if (reader.IsStartElement() && !reader.IsEmptyElement)
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "PaperTitle":
                                if (reader.Read())
                                {
                                    paperTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "APAMLA":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("APA"))
                                    {
                                        apaRadio.Checked = true;
                                    }
                                    else if (reader.Value.Equals("MLA"))
                                    {
                                        mlaRadio.Checked = true;
                                    }
                                }
                                break;
                            case "IncludeTitlePage":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        titlePageIncludeCheck.Checked = true;
                                    }
                                    else
                                    {
                                        titlePageIncludeCheck.Checked = false;
                                    }
                                }
                                break;
                            case "IncludeSummary":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        summaryIncludeCheck.Checked = true;
                                    }
                                    else
                                    {
                                        summaryIncludeCheck.Checked = false;
                                    }
                                }
                                break;
                            case "IncludeAbstract":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        abstractIncludeCheck.Checked = true;
                                    }
                                    else
                                    {
                                        abstractIncludeCheck.Checked = false;
                                    }
                                }
                                break;
                            case "IncludeHeader":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerIncludeCheck.Checked = true;
                                    }
                                    else
                                    {
                                        headerIncludeCheck.Checked = false;
                                    }
                                }
                                break;
                            case "IncludeConclusion":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        conclusionIncludeCheck.Checked = true;
                                    }
                                    else
                                    {
                                        conclusionIncludeCheck.Checked = false;
                                    }
                                }
                                break;
                            case "IncludeReferences":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        referencesIncludeCheck.Checked = true;
                                    }
                                    else
                                    {
                                        referencesIncludeCheck.Checked = false;
                                    }
                                }
                                break;
                            case "TitlePageIncludeTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        titlePageTitleCheck.Checked = true;
                                    }
                                    else
                                    {
                                        titlePageTitleCheck.Checked = false;
                                    }
                                }
                                break;
                            case "TitlePageIncludeName":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        titlePageNameCheck.Checked = true;
                                    }
                                    else
                                    {
                                        titlePageNameCheck.Checked = false;
                                    }
                                }
                                break;
                            case "TitlePageIncludeClass":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        titlePageClassCheck.Checked = true;
                                    }
                                    else
                                    {
                                        titlePageClassCheck.Checked = false;
                                    }
                                }
                                break;
                            case "TitlePageIncludeProfessor":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        titlePageProfessorCheck.Checked = true;
                                    }
                                    else
                                    {
                                        titlePageProfessorCheck.Checked = false;
                                    }
                                }
                                break;
                            case "TitlePageIncludeSchool":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        titlePageSchoolCheck.Checked = true;
                                    }
                                    else
                                    {
                                        titlePageSchoolCheck.Checked = false;
                                    }
                                }
                                break;
                            case "TitlePageIncludeDate":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        titlePageDateCheck.Checked = true;
                                    }
                                    else
                                    {
                                        titlePageDateCheck.Checked = false;
                                    }
                                }
                                break;
                            case "TitlePageTitle":
                                if (reader.Read())
                                {
                                    titlePageTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "TitlePageName":
                                if (reader.Read())
                                {
                                    titlePageNameEnter.Text = reader.Value;
                                }
                                break;
                            case "TitlePageClass":
                                if (reader.Read())
                                {
                                    titlePageClassEnter.Text = reader.Value;
                                }
                                break;
                            case "TitlePageProfessor":
                                if (reader.Read())
                                {
                                    titlePageProfessorEnter.Text = reader.Value;
                                }
                                break;
                            case "TitlePageSchool":
                                if (reader.Read())
                                {
                                    titlePageSchoolEnter.Text = reader.Value;
                                }
                                break;
                            case "TitlePageDate":
                                if (reader.Read())
                                {
                                    titlePageDateEnter.Text = reader.Value;
                                }
                                break;
                            case "TitlePageAlignment":
                                if (reader.Read())
                                {
                                    string alignment = reader.Value;
                                    if (alignment.Equals("left"))
                                    {
                                        titlePageLeftAllignRadio.Checked = true;
                                    }
                                    else if (alignment.Equals("center"))
                                    {
                                        titlePageCenterRadio.Checked = true;
                                    }
                                    else if (alignment.Equals("right"))
                                    {
                                        titlePageRightAllignRadio.Checked = true;
                                    }
                                }
                                break;
                            case "TitlePageItem":
                                //TODO Adjust order based on order
                                //if (reader.Read())
                                //{
                                //    myPaper.titlePage.titlePageOrder.Add(reader.Value);
                                //}
                                break;
                            case "SummaryOwnPage":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        summaryOwnPageCheck.Checked = true;
                                    }
                                    else
                                    {
                                        summaryOwnPageCheck.Checked = false;
                                    }
                                }
                                break;
                            case "SummaryIncludeTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        summaryIncludeTitleCheck.Checked = true;
                                    }
                                    else
                                    {
                                        summaryIncludeTitleCheck.Checked = false;
                                    }
                                }
                                break;
                            case "SummaryTitle":
                                if (reader.Read())
                                {
                                    summaryTitleText.Text = reader.Value;
                                }
                                break;
                            case "SummaryBoldTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        summaryTitleBoldCheck.Checked = true;
                                    }
                                    else
                                    {
                                        summaryTitleBoldCheck.Checked = false;
                                    }
                                }
                                break;
                            case "SummaryTitleFont":
                                if (reader.Read())
                                {
                                    summaryTitleFontChoose.Text = reader.Value;
                                }
                                break;
                            case "SummaryTitleSize":
                                if (reader.Read())
                                {
                                    summaryTitleSizeChoose.Text = reader.Value;
                                }
                                break;
                            case "SummaryTitleColor":
                                if (reader.Read())
                                {
                                    summaryTitleColorText.Text = reader.Value;
                                }
                                break;
                            case "SummaryTitleAlign":
                                if (reader.Read())
                                {
                                    summaryTitleAlignSelect.Text = reader.Value;
                                }
                                break;
                            case "SummaryContent":
                                if (reader.Read())
                                {
                                    summaryContent.Text = reader.Value;
                                }
                                break;
                            case "AbstractOwnPage":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        abstractOwnPageCheck.Checked = true;
                                    }
                                    else
                                    {
                                        abstractOwnPageCheck.Checked = false;
                                    }
                                }
                                break;
                            case "AbstractIncludeTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        abstractIncludeTitleCheck.Checked = true;
                                    }
                                    else
                                    {
                                        abstractIncludeTitleCheck.Checked = false;
                                    }
                                }
                                break;
                            case "AbstractTitle":
                                if (reader.Read())
                                {
                                    abstractTitleText.Text = reader.Value;
                                }
                                break;
                            case "AbstractBoldTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        abstractTitleBoldCheck.Checked = true;
                                    }
                                    else
                                    {
                                        abstractTitleBoldCheck.Checked = false;
                                    }
                                }
                                break;
                            case "AbstractTitleFont":
                                if (reader.Read())
                                {
                                    abstractTitleFontChoose.Text = reader.Value;
                                }
                                break;
                            case "AbstractTitleSize":
                                if (reader.Read())
                                {
                                    abstractTitleSizeChoose.Text = reader.Value;
                                }
                                break;
                            case "AbstractTitleColor":
                                if (reader.Read())
                                {
                                    abstractTitleColorText.Text = reader.Value;
                                }
                                break;
                            case "AbstractTitleAlign":
                                if (reader.Read())
                                {
                                    abstractTitleAlignSelect.Text = reader.Value;
                                }
                                break;
                            case "AbstractContent":
                                if (reader.Read())
                                {
                                    abstractContent.Text = reader.Value;
                                }
                                break;
                            case "HeaderDifferentFirst":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerDiffFirstPageCheck.Checked = true;
                                    }
                                    else
                                    {
                                        headerDiffFirstPageCheck.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderUseRunningHead":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstPageUseRunningHeadCheck.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstPageUseRunningHeadCheck.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderLeftTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerLeftTitleRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerLeftTitleRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderLeftPageNum":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerLeftNumberRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerLeftNumberRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderLeftOther":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerLeftOtherRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerLeftOtherRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderLeftNone":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerLeftEmptyRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerLeftEmptyRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderCenterTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerCenterTitleRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerCenterTitleRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderCenterPageNum":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerCenterNumberRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerCenterNumberRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderCenterOther":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerCenterOtherRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerCenterOtherRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderCenterNone":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerCenterEmptyRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerCenterEmptyRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderRightTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerRightTitleRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerRightTitleRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderRightPageNum":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerRightNumberRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerRightNumberRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderRightOther":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerRightOtherRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerRightOtherRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderRightNone":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerRightEmptyRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerRightEmptyRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstLeftTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstLeftTitleRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstLeftTitleRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstLeftPageNum":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstLeftNumberRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstLeftNumberRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstLeftOther":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstLeftOtherRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstLeftOtherRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstLeftNone":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstLeftEmptyRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstLeftEmptyRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstCenterTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstCenterTitleRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstCenterTitleRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstCenterPageNum":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstCenterNumberRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstCenterNumberRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstCenterOther":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstCenterOtherRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstCenterOtherRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstCenterNone":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstCenterEmptyRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstCenterEmptyRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstRightTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstRightTitleRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstRightTitleRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstRightPageNum":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstRightNumberRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstRightNumberRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstRightOther":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstRightOtherRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstRightOtherRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderFirstRightNone":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        headerFirstRightEmptyRadio.Checked = true;
                                    }
                                    else
                                    {
                                        headerFirstRightEmptyRadio.Checked = false;
                                    }
                                }
                                break;
                            case "HeaderEnterLeftTitle":
                                if (reader.Read())
                                {
                                    headerLeftTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterLeftPageStart":
                                if (reader.Read())
                                {
                                    headerLeftNumberEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterLeftOther":
                                if (reader.Read())
                                {
                                    headerLeftOtherEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterCenterTitle":
                                if (reader.Read())
                                {
                                    headerCenterTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterCenterPageStart":
                                if (reader.Read())
                                {
                                    headerCenterNumberEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterCenterOther":
                                if (reader.Read())
                                {
                                    headerCenterOtherEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterRightTitle":
                                if (reader.Read())
                                {
                                    headerRightTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterRightPageStart":
                                if (reader.Read())
                                {
                                    headerRightNumberEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterRightOther":
                                if (reader.Read())
                                {
                                    headerRightOtherEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterFirstLeftTitle":
                                if (reader.Read())
                                {
                                    headerFirstLeftTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterFirstLeftPageStart":
                                if (reader.Read())
                                {
                                    headerFirstLeftNumberEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterFirstLeftOther":
                                if (reader.Read())
                                {
                                    headerFirstLeftOtherEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterFirstCenterTitle":
                                if (reader.Read())
                                {
                                    headerFirstCenterTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterFirstCenterPageStart":
                                if (reader.Read())
                                {
                                    headerFirstCenterNumberEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterFirstCenterOther":
                                if (reader.Read())
                                {
                                    headerFirstCenterOtherEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterFirstRightTitle":
                                if (reader.Read())
                                {
                                    headerFirstRightTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterFirstRightPageStart":
                                if (reader.Read())
                                {
                                    headerFirstRightNumberEnter.Text = reader.Value;
                                }
                                break;
                            case "HeaderEnterFirstRightOther":
                                if (reader.Read())
                                {
                                    headerFirstRightOtherEnter.Text = reader.Value;
                                }
                                break;
                            case "ReferencesIncludeTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        referencesTitleIncludeCheck.Checked = true;
                                    }
                                    else
                                    {
                                        referencesTitleIncludeCheck.Checked = false;
                                    }
                                }
                                break;
                            case "ReferencesTitle":
                                if (reader.Read())
                                {
                                    referencesTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "ReferencesTitleAlign":
                                if (reader.Read())
                                {
                                    referencesTitleAlignChoose.Text = reader.Value;
                                }
                                break;
                            case "ReferencesBoldTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        referencesTitleBoldCheck.Checked = true;
                                    }
                                    else
                                    {
                                        referencesTitleBoldCheck.Checked = false;
                                    }
                                }
                                break;
                            case "ReferencesTitleFont":
                                if (reader.Read())
                                {
                                    referencesTitleFontChoose.Text = reader.Value;
                                }
                                break;
                            case "ReferencesTitleSize":
                                if (reader.Read())
                                {
                                    referencesTitleSizeChoose.Text = reader.Value;
                                }
                                break;
                            case "ReferencesTitleColor":
                                if (reader.Read())
                                {
                                    referencesTitleColorText.Text = reader.Value;
                                }
                                break;
                            case "ReferencesHangingIndent":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        referencesHangingIndentCheck.Checked = true;
                                    }
                                    else
                                    {
                                        referencesHangingIndentCheck.Checked = false;
                                    }
                                }
                                break;
                            case "ReferencesNumTabsHanging":
                                if (reader.Read())
                                {
                                    referencesIndentTabsEnter.Text = reader.Value;
                                }
                                break;
                            case "ReferencesEmptyLineBetween":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        referencesEmptyLineBetweenCheck.Checked = true;
                                    }
                                    else
                                    {
                                        referencesEmptyLineBetweenCheck.Checked = false;
                                    }
                                }
                                break;
                            case "ReferencesOrderBy":
                                if (reader.Read())
                                {
                                    referencesOrderChoose.Text = reader.Value;
                                }
                                break;
                            case "Reference":
                                if (inReference)
                                {
                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                    myPaper.references.references.Add(reference);
                                }
                                inReference = true;
                                reference = new Reference();
                                break;
                            case "Formatted":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.formattedReference = reader.Value;
                                    }
                                }
                                break;
                            case "Type":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.type = reader.Value;
                                    }
                                }
                                break;
                            case "PublicationDate":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.publicationDate = reader.Value;
                                    }
                                }
                                break;
                            case "Title":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.title = reader.Value;
                                    }
                                }
                                break;
                            case "Publisher":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.publisher = reader.Value;
                                    }
                                }
                                break;
                            case "PublishLocation":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.publishLocation = reader.Value;
                                    }
                                }
                                break;
                            case "Edition":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.edition = reader.Value;
                                    }
                                }
                                break;
                            case "Section":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.section = reader.Value;
                                    }
                                }
                                break;
                            case "Volume":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.volume = reader.Value;
                                    }
                                }
                                break;
                            case "Issue":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.issue = reader.Value;
                                    }
                                }
                                break;
                            case "StartPage":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.startPage = reader.Value;
                                    }
                                }
                                break;
                            case "EndPage":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.endPage = reader.Value;
                                    }
                                }
                                break;
                            case "OriginalPublishDate":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.originalPublishDate = reader.Value;
                                    }
                                }
                                break;
                            case "Source":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.source = reader.Value;
                                    }
                                }
                                break;
                            case "RetrievedFrom":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.retrievedFrom = reader.Value;
                                    }
                                }
                                break;
                            case "Doi":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.doi = reader.Value;
                                    }
                                }
                                break;
                            case "InterviewDate":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.interviewDate = reader.Value;
                                    }
                                }
                                break;
                            case "Number":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.number = reader.Value;
                                    }
                                }
                                break;
                            case "ReviewTitle":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.reviewTitle = reader.Value;
                                    }
                                }
                                break;
                            case "RetrieveDate":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.retrieveDate = reader.Value;
                                    }
                                }
                                break;
                            case "Accession":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.accession = reader.Value;
                                    }
                                }
                                break;
                            case "Institution":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.institution = reader.Value;
                                    }
                                }
                                break;
                            case "Location":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.location = reader.Value;
                                    }
                                }
                                break;
                            case "Organization":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.organization = reader.Value;
                                    }
                                }
                                break;
                            case "Studio":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.studio = reader.Value;
                                    }
                                }
                                break;
                            case "RecordDate":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.recordDate = reader.Value;
                                    }
                                }
                                break;
                            case "AccessedOn":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.accessedOn = reader.Value;
                                    }
                                }
                                break;
                            case "ScreenName":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.screenName = reader.Value;
                                    }
                                }
                                break;
                            case "Meeting":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.meeting = reader.Value;
                                    }
                                }
                                break;
                            case "Venue":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.venue = reader.Value;
                                    }
                                }
                                break;
                            case "Format":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.format = reader.Value;
                                    }
                                }
                                break;
                            case "CallLetters":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.callLetters = reader.Value;
                                    }
                                }
                                break;
                            case "Season":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.season = reader.Value;
                                    }
                                }
                                break;
                            case "Episode":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.episode = reader.Value;
                                    }
                                }
                                break;
                            case "ArtistName":
                                if (reader.Read())
                                {
                                    if (inReference)
                                    {
                                        reference.artistName = reader.Value;
                                    }
                                }
                                break;
                            case "Author":
                                if (inReference)
                                {
                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                    }
                                    author = new Author();
                                    inReferenceAuthor = true;

                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Translator":
                                if (inReference)
                                {
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                    }
                                    translator = new Author();
                                    inReferenceTranslator = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Interviewer":
                                if (inReference)
                                {
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                    }
                                    interviewer = new Author();
                                    inReferenceInterviewer = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Interviewee":
                                if (inReference)
                                {
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                    }
                                    interviewee = new Author();
                                    inReferenceInterviewee = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Reviewer":
                                if (inReference)
                                {
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                    }
                                    reviewer = new Author();
                                    inReferenceReviewer = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Producer":
                                if (inReference)
                                {
                                    producer = new Author();
                                    inReferenceProducer = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Director":
                                if (inReference)
                                {
                                    director = new Author();
                                    inReferenceDirector = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Writer":
                                if (inReference)
                                {
                                    writer = new Author();
                                    inReferenceWriter = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Artist":
                                if (inReference)
                                {
                                    artist = new Author();
                                    inReferenceArtist = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Editor":
                                if (inReference)
                                {
                                    editor = new Author();
                                    inReferenceEditor = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Communicator":
                                if (inReference)
                                {
                                    communcator = new Author();
                                    inReferenceCommunicator = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceReceiver)
                                    {
                                        inReferenceReceiver = false;
                                    }
                                }
                                break;
                            case "Receiver":
                                if (inReference)
                                {
                                    receiver = new Author();
                                    inReferenceReceiver = true;

                                    if (inReferenceAuthor)
                                    {
                                        reference.authors.Add(author);
                                        inReferenceAuthor = false;
                                    }
                                    if (inReferenceTranslator)
                                    {
                                        reference.translators.Add(translator);
                                        inReferenceTranslator = false;
                                    }
                                    if (inReferenceInterviewer)
                                    {
                                        reference.interviewers.Add(interviewer);
                                        inReferenceInterviewer = false;
                                    }
                                    if (inReferenceInterviewee)
                                    {
                                        reference.interviewees.Add(interviewee);
                                        inReferenceInterviewee = false;
                                    }
                                    if (inReferenceReviewer)
                                    {
                                        reference.reviewers.Add(reviewer);
                                        inReferenceReviewer = false;
                                    }
                                    if (inReferenceProducer)
                                    {
                                        inReferenceProducer = false;
                                    }
                                    if (inReferenceDirector)
                                    {
                                        inReferenceDirector = false;
                                    }
                                    if (inReferenceWriter)
                                    {
                                        inReferenceWriter = false;
                                    }
                                    if (inReferenceArtist)
                                    {
                                        inReferenceArtist = false;
                                    }
                                    if (inReferenceEditor)
                                    {
                                        inReferenceEditor = false;
                                    }
                                    if (inReferenceCommunicator)
                                    {
                                        inReferenceCommunicator = false;
                                    }
                                }
                                break;
                            case "FirstName":
                                if (reader.Read())
                                {
                                    if (inReferenceAuthor)
                                    {
                                        author.firstName = reader.Value;
                                    }
                                    else if (inReferenceTranslator)
                                    {
                                        translator.firstName = reader.Value;
                                    }
                                    else if (inReferenceInterviewer)
                                    {
                                        interviewer.firstName = reader.Value;
                                    }
                                    else if (inReferenceInterviewee)
                                    {
                                        interviewee.firstName = reader.Value;
                                    }
                                    else if (inReferenceReviewer)
                                    {
                                        reviewer.firstName = reader.Value;
                                    }
                                    else if (inReferenceProducer)
                                    {
                                        producer.firstName = reader.Value;
                                    }
                                    else if (inReferenceDirector)
                                    {
                                        director.firstName = reader.Value;
                                    }
                                    else if (inReferenceWriter)
                                    {
                                        writer.firstName = reader.Value;
                                    }
                                    else if (inReferenceArtist)
                                    {
                                        artist.firstName = reader.Value;
                                    }
                                    else if (inReferenceEditor)
                                    {
                                        editor.firstName = reader.Value;
                                    }
                                    else if (inReferenceCommunicator)
                                    {
                                        communcator.firstName = reader.Value;
                                    }
                                    else if (inReferenceReceiver)
                                    {
                                        receiver.firstName = reader.Value;
                                    }
                                }
                                break;
                            case "MiddleName":
                                if (reader.Read())
                                {
                                    if (inReferenceAuthor)
                                    {
                                        author.middleName = reader.Value;
                                    }
                                    else if (inReferenceTranslator)
                                    {
                                        translator.middleName = reader.Value;
                                    }
                                    else if (inReferenceInterviewer)
                                    {
                                        interviewer.middleName = reader.Value;
                                    }
                                    else if (inReferenceInterviewee)
                                    {
                                        interviewee.middleName = reader.Value;
                                    }
                                    else if (inReferenceReviewer)
                                    {
                                        reviewer.middleName = reader.Value;
                                    }
                                    else if (inReferenceProducer)
                                    {
                                        producer.middleName = reader.Value;
                                    }
                                    else if (inReferenceDirector)
                                    {
                                        director.middleName = reader.Value;
                                    }
                                    else if (inReferenceWriter)
                                    {
                                        writer.middleName = reader.Value;
                                    }
                                    else if (inReferenceArtist)
                                    {
                                        artist.middleName = reader.Value;
                                    }
                                    else if (inReferenceEditor)
                                    {
                                        editor.middleName = reader.Value;
                                    }
                                    else if (inReferenceCommunicator)
                                    {
                                        communcator.middleName = reader.Value;
                                    }
                                    else if (inReferenceReceiver)
                                    {
                                        receiver.middleName = reader.Value;
                                    }
                                }
                                break;
                            case "LastName":
                                if (reader.Read())
                                {
                                    if (inReferenceAuthor)
                                    {
                                        author.lastName = reader.Value;
                                    }
                                    else if (inReferenceTranslator)
                                    {
                                        translator.lastName = reader.Value;
                                    }
                                    else if (inReferenceInterviewer)
                                    {
                                        interviewer.lastName = reader.Value;
                                    }
                                    else if (inReferenceInterviewee)
                                    {
                                        interviewee.lastName = reader.Value;
                                    }
                                    else if (inReferenceReviewer)
                                    {
                                        reviewer.lastName = reader.Value;
                                    }
                                    else if (inReferenceProducer)
                                    {
                                        producer.lastName = reader.Value;
                                    }
                                    else if (inReferenceDirector)
                                    {
                                        director.lastName = reader.Value;
                                    }
                                    else if (inReferenceWriter)
                                    {
                                        writer.lastName = reader.Value;
                                    }
                                    else if (inReferenceArtist)
                                    {
                                        artist.lastName = reader.Value;
                                    }
                                    else if (inReferenceEditor)
                                    {
                                        editor.lastName = reader.Value;
                                    }
                                    else if (inReferenceCommunicator)
                                    {
                                        communcator.lastName = reader.Value;
                                    }
                                    else if (inReferenceReceiver)
                                    {
                                        receiver.lastName = reader.Value;
                                    }
                                }
                                break;
                            case "CompleteName":
                                if (reader.Read())
                                {
                                    if (inReferenceAuthor)
                                    {
                                        author.completeName = reader.Value;
                                    }
                                    else if (inReferenceTranslator)
                                    {
                                        translator.completeName = reader.Value;
                                    }
                                    else if (inReferenceInterviewer)
                                    {
                                        interviewer.completeName = reader.Value;
                                    }
                                    else if (inReferenceInterviewee)
                                    {
                                        interviewee.completeName = reader.Value;
                                    }
                                    else if (inReferenceReviewer)
                                    {
                                        reviewer.completeName = reader.Value;
                                    }
                                    else if (inReferenceProducer)
                                    {
                                        producer.completeName = reader.Value;
                                    }
                                    else if (inReferenceDirector)
                                    {
                                        director.completeName = reader.Value;
                                    }
                                    else if (inReferenceWriter)
                                    {
                                        writer.completeName = reader.Value;
                                    }
                                    else if (inReferenceArtist)
                                    {
                                        artist.completeName = reader.Value;
                                    }
                                    else if (inReferenceEditor)
                                    {
                                        editor.completeName = reader.Value;
                                    }
                                    else if (inReferenceCommunicator)
                                    {
                                        communcator.completeName = reader.Value;
                                    }
                                    else if (inReferenceReceiver)
                                    {
                                        receiver.completeName = reader.Value;
                                    }
                                }
                                break;
                            case "SectionsBlankLineBetweem":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        blankLineBetweenSectionsRadio.Checked = true;
                                    }
                                    else
                                    {
                                        blankLineBetweenSectionsRadio.Checked = false;
                                    }
                                }
                                break;
                            case "SectionsNewPageBetween":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        newPageForEachSectionRadio.Checked = true;
                                    }
                                    else
                                    {
                                        newPageForEachSectionRadio.Checked = false;
                                    }
                                }
                                break;
                            case "SectionsNoSpaceBetween":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        noSpaceBetweenSectionsRadio.Checked = true;
                                    }
                                    else
                                    {
                                        noSpaceBetweenSectionsRadio.Checked = false;
                                    }
                                }
                                break;
                            case "SectionsIncludeSectionLabel":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        includeSectionLabelsCheck.Checked = true;
                                    }
                                    else
                                    {
                                        includeSectionLabelsCheck.Checked = false;
                                    }
                                }
                                break;
                            case "SectionsIncludeSubsectionLabel":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        includeSubsectionLabelCheck.Checked = true;
                                    }
                                    else
                                    {
                                        includeSubsectionLabelCheck.Checked = false;
                                    }
                                }
                                break;
                            case "SectionsIncludeSubsubsectionLabel":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        includeSubsubsectionLabelCheck.Checked = true;
                                    }
                                    else
                                    {
                                        includeSubsubsectionLabelCheck.Checked = false;
                                    }
                                }
                                break;
                            case "SectionLabelInline":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        sectionLabelInLineRadio.Checked = true;
                                    }
                                    else
                                    {
                                        sectionLabelInLineRadio.Checked = false;
                                    }
                                }
                                break;
                            case "SectionLabelOwnLine":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        sectionLabelBeforeRadio.Checked = true;
                                    }
                                    else
                                    {
                                        sectionLabelBeforeRadio.Checked = false;
                                    }
                                }
                                break;
                            case "SectionLabelBold":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        sectionLabelBoldCheck.Checked = true;
                                    }
                                    else
                                    {
                                        sectionLabelBoldCheck.Checked = false;
                                    }
                                }
                                break;
                            case "SectionLabelAlign":
                                if (reader.Read())
                                {
                                    sectionLabelAlignChoose.Text = reader.Value;
                                }
                                break;
                            case "SectionLabelFont":
                                if (reader.Read())
                                {
                                    sectionLabelFont.Text = reader.Value;
                                }
                                break;
                            case "SectionLabelSize":
                                if (reader.Read())
                                {
                                    sectionLabelSize.Text = reader.Value;
                                }
                                break;
                            case "SectionLabelColor":
                                if (reader.Read())
                                {
                                    sectionLabelColorText.Text = reader.Value;
                                }
                                break;
                            case "SubsectionLabelInline":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        subsectionLabelInLineRadio.Checked = true;
                                    }
                                    else
                                    {
                                        subsectionLabelInLineRadio.Checked = false;
                                    }
                                }
                                break;
                            case "SubsectionLabelOwnLine":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        subsectionLabelBeforeRadio.Checked = true;
                                    }
                                    else
                                    {
                                        subsectionLabelBeforeRadio.Checked = false;
                                    }
                                }
                                break;
                            case "SubsectionLabelBold":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        subsectionLabelBoldCheck.Checked = true;
                                    }
                                    else
                                    {
                                        subsectionLabelBoldCheck.Checked = false;
                                    }
                                }
                                break;
                            case "SubsectionLabelAlign":
                                if (reader.Read())
                                {
                                    subsectionLabelAlignChoose.Text = reader.Value;
                                }
                                break;
                            case "SubsectionLabelFont":
                                if (reader.Read())
                                {
                                    subsectionLabelFont.Text = reader.Value;
                                }
                                break;
                            case "SubsectionLabelSize":
                                if (reader.Read())
                                {
                                    subsectionLabelSize.Text = reader.Value;
                                }
                                break;
                            case "SubsectionLabelColor":
                                if (reader.Read())
                                {
                                    subsectionLabelColorText.Text = reader.Value;
                                }
                                break;
                            case "SubsubsectionLabelInline":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        subsubsectionLabelInLineRadio.Checked = true;
                                    }
                                    else
                                    {
                                        subsubsectionLabelInLineRadio.Checked = false;
                                    }
                                }
                                break;
                            case "SubsubsectionLabelOwnLine":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        subsubsectionLabelBeforeRadio.Checked = true;
                                    }
                                    else
                                    {
                                        subsubsectionLabelBeforeRadio.Checked = false;
                                    }
                                }
                                break;
                            case "SubsubsectionLabelBold":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        subsubsectionLabelBoldCheck.Checked = true;
                                    }
                                    else
                                    {
                                        subsubsectionLabelBoldCheck.Checked = false;
                                    }
                                }
                                break;
                            case "SubsubsectionLabelAlign":
                                if (reader.Read())
                                {
                                    subsubsectionLabelAlignChoose.Text = reader.Value;
                                }
                                break;
                            case "SubsubsectionLabelFont":
                                if (reader.Read())
                                {
                                    subsubsectionLabelFont.Text = reader.Value;
                                }
                                break;
                            case "SubsubsectionLabelSize":
                                if (reader.Read())
                                {
                                    subsubsectionLabelSize.Text = reader.Value;
                                }
                                break;
                            case "SubsubsectionLabelColor":
                                if (reader.Read())
                                {
                                    subsubsectionLabelColorText.Text = reader.Value;
                                }
                                break;

                            //TODO Add section objects here
                            case "SectionElement":
                                numSectionsStarted++;
                                if (numSections < numSectionsStarted)
                                {
                                    addSectionButton.PerformClick();
                                    numSections++;
                                }
                                inSection = true;
                                inSubsection = false;
                                inSubsubsection = false;
                                break;

                            case "ConclusionOnOwnPage":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        conclusionOwnPageCheck.Checked = true;
                                    }
                                    else
                                    {
                                        conclusionOwnPageCheck.Checked = false;
                                    }
                                }
                                break;
                            case "ConclusionIncludeTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        conclusionIncludeTitleCheck.Checked = true;
                                    }
                                    else
                                    {
                                        conclusionIncludeTitleCheck.Checked = false;
                                    }
                                }
                                break;
                            case "ConclusionTitle":
                                if (reader.Read())
                                {
                                    conclusionTitleEnter.Text = reader.Value;
                                }
                                break;
                            case "ConclusionTitleAlign":
                                if (reader.Read())
                                {
                                    conclusionTitleAlignChoose.Text = reader.Value;
                                }
                                break;
                            case "ConclusionBoldTitle":
                                if (reader.Read())
                                {
                                    if (reader.Value.Equals("True"))
                                    {
                                        conclusionTitleBoldCheck.Checked = true;
                                    }
                                    else
                                    {
                                        conclusionTitleBoldCheck.Checked = false;
                                    }
                                }
                                break;
                            case "ConclusionTitleFont":
                                if (reader.Read())
                                {
                                    conclusionTitleFontChoose.Text = reader.Value;
                                }
                                break;
                            case "ConclusionTitleSize":
                                if (reader.Read())
                                {
                                    conclusionTitleSizeChoose.Text = reader.Value;
                                }
                                break;
                            case "ConclusionTitleColor":
                                if (reader.Read())
                                {
                                    conclusionTitleColorText.Text = reader.Value;
                                }
                                break;
                            case "ConclusionContent":
                                if (reader.Read())
                                {
                                    conclusionContent.Text = reader.Value;
                                }
                                break;

                        }
                    }                    
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
        }
    }
}
