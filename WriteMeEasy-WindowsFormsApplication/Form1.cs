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
    }
}
