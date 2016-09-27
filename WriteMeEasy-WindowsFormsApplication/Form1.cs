using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
            myPaper.summary.content = summaryContent.Text;
        }

        private void abstractContent_TextChanged(object sender, EventArgs e)
        {
            myPaper.abstractConfig.content = abstractContent.Text;
        }

        private void conclusionContent_TextChanged(object sender, EventArgs e)
        {
            myPaper.conclusion.conclusionContent = conclusionContent.Text;
        }

        private void conclusionOwnPageCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (conclusionOwnPageCheck.Checked)
            {
                myPaper.conclusion.onOwnPage = true;
            }
            else
            {
                myPaper.conclusion.onOwnPage = false;
            }
        }

        private void sectionLabelBeforeRadio_Changed(object sender, EventArgs e)
        {
            if (sectionLabelBeforeRadio.Checked)
            {
                myPaper.sectionsConfig.sectionLabelOnOwnLine = true;
                myPaper.sectionsConfig.sectionLabelInlineWithText = false;
            }
            else
            {
                myPaper.sectionsConfig.sectionLabelOnOwnLine = false;
                myPaper.sectionsConfig.sectionLabelInlineWithText = true;
            }
        }

        private void sectionLabelInLineRadio_Changed(object sender, EventArgs e)
        {
            if (sectionLabelInLineRadio.Checked)
            {
                myPaper.sectionsConfig.sectionLabelInlineWithText = true;
                myPaper.sectionsConfig.sectionLabelOnOwnLine = false;
            }
            else
            {
                myPaper.sectionsConfig.sectionLabelInlineWithText = false;
                myPaper.sectionsConfig.sectionLabelOnOwnLine = true;
            }
        }

        private void subsectionLabelBeforeRadio_Changed(object sender, EventArgs e)
        {
            if (subsectionLabelBeforeRadio.Checked)
            {
                myPaper.sectionsConfig.subsectionLabelOnOwnLine = true;
                myPaper.sectionsConfig.subsectionLabelInlineWithText = false;
            }
            else
            {
                myPaper.sectionsConfig.subsectionLabelOnOwnLine = false;
                myPaper.sectionsConfig.subsectionLabelInlineWithText = true;
            }
        }

        private void subsectionLabelInLineRadio_Changed(object sender, EventArgs e)
        {
            if (subsectionLabelInLineRadio.Checked)
            {
                myPaper.sectionsConfig.subsectionLabelInlineWithText = true;
                myPaper.sectionsConfig.subsectionLabelOnOwnLine = false;
            }
            else
            {
                myPaper.sectionsConfig.subsectionLabelInlineWithText = false;
                myPaper.sectionsConfig.subsectionLabelOnOwnLine = true;
            }
        }

        private void subsubsectionLabelBeforeRadio_Changed(object sender, EventArgs e)
        {
            if (subsubsectionLabelBeforeRadio.Checked)
            {
                myPaper.sectionsConfig.subsubsectionLabelOnOwnLine = true;
                myPaper.sectionsConfig.subsubsectionLabelInlineWithText = false;
            }
            else
            {
                myPaper.sectionsConfig.subsubsectionLabelOnOwnLine = false;
                myPaper.sectionsConfig.subsubsectionLabelInlineWithText = true;
            }
        }

        private void subsubsectionLabelInLineRadio_Changed(object sender, EventArgs e)
        {
            if (subsubsectionLabelInLineRadio.Checked)
            {
                myPaper.sectionsConfig.subsubsectionLabelInlineWithText = true;
                myPaper.sectionsConfig.subsubsectionLabelOnOwnLine = false;
            }
            else
            {
                myPaper.sectionsConfig.subsubsectionLabelInlineWithText = false;
                myPaper.sectionsConfig.subsubsectionLabelOnOwnLine = true;
            }
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

        }

        private void headerFirstLeftTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void headerFirstLeftNumberEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void headerFirstLeftOtherEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void headerFirstCenterTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void headerFirstCenterNumberEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void headerFirstCenterOtherEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void headerFirstRightTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void headerFirstRightNumberEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void headerFirstRightOtherEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void headerDefaultButton_Click(object sender, EventArgs e)
        {

        }

        private void footerLeftTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerLeftNumberEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void footerLeftOtherEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerCenterTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerCenterNumberEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void footerCenterOtherEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerRightTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerRightNumberEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void footerRightOtherEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstPageUseRunningHeadCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstLeftTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstLeftNumberEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstLeftOtherEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstCenterTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstCenterNumberEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstCenterOtherEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstRightTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstRightNumberEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void footerFirstRightOtherEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void newPageForEachSectionRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void noSpaceBetweenSectionsRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sectionLabelBoldCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sectionLabelBullettedCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sectionLabelFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sectionLabelSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sectionLabelColorButton_Click(object sender, EventArgs e)
        {

        }

        private void subsectionLabelColorButton_Click(object sender, EventArgs e)
        {

        }

        private void subsectionLabelSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void subsectionLabelFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void subsectionLabelBulletted_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void subsectionLabelBoldCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void subsubsectionLabelBoldCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void subsubsectionLabelBullettedCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void subsubsectionLabelFont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void subsubsectionLabelSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void subsubsectionLabelButton_Click(object sender, EventArgs e)
        {

        }

        private void conclusionTitleBoldCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void conclusionTitleFontChoose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void conclusionTitleSizeChoose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void conclusionTitleColorButton_Click(object sender, EventArgs e)
        {

        }

        private void conclusionDefaultButton_Click(object sender, EventArgs e)
        {

        }

        private void referencesTitleEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void referencesTitleBoldCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void referencesTitleFontChoose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void referencesTitleSizeChoose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void referencesTitleColorButton_Click(object sender, EventArgs e)
        {

        }

        private void referencesIndentTabsEnter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void referencesEmptyLineBetweenCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void referencesOrderChoose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void referencesDefaultButton_Click(object sender, EventArgs e)
        {

        }
    }
}
