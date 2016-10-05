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
    }
}
