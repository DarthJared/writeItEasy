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
    }
}
