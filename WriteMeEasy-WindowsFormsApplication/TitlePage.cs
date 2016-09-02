using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WriteMeEasy_WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private void titlePageIncludeCheck_CheckedChanged(object sender, EventArgs e)
        {
            int sectionHeight;
            if (sections.TryGetValue("TITLE_PAGE", out sectionHeight)) { }
            int generalSectionHeight;
            if (sections.TryGetValue("GENERAL", out generalSectionHeight)) { }
            int genY = generalPanel.Location.Y;
            titlePagePanel.Location = new Point(0, generalSectionHeight + genY);

            /*Checked*/
            if (titlePageIncludeCheck.Checked)
            {
                titlePagePanel.Visible = true;
                lowerSection(sectionHeight, "TITLE_PAGE");
                titlePageActive = true;
            }
            /*Unchecked*/
            else
            {
                titlePagePanel.Visible = false;
                raiseSection(sectionHeight, "TITLE_PAGE");
                titlePageActive = false;
            }
        }

        private void titleUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("TITLE");
        }

        private void nameUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("NAME");
        }

        private void classUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("CLASS");
        }

        private void professorUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("PROFESSOR");
        }

        private void schoolUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("SCHOOL");
        }

        private void dateUpButton_Click(object sender, EventArgs e)
        {
            titlePageUp("DATE");
        }

        private void titleDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("TITLE");
        }

        private void nameDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("NAME");
        }

        private void classDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("CLASS");
        }

        private void professorDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("PROFESSOR");
        }

        private void schoolDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("SCHOOL");
        }

        private void dateDownButton_Click(object sender, EventArgs e)
        {
            titlePageDown("DATE");
        }

        private void titlePageDown(string option)
        {
            int index;
            if (titlePageOrder.TryGetValue(option, out index)) { }
            if (index < 6)
            {
                string oneMore;
                if (orderTitlePage.TryGetValue(index + 1, out oneMore)) { }
                titlePageOrder[oneMore] = index;
                titlePageOrder[option] = index + 1;
                orderTitlePage[index] = oneMore;
                orderTitlePage[index + 1] = option;
            }
            reOrderTitlePage();
        }

        private void titlePageUp(string option)
        {
            int index;
            if (titlePageOrder.TryGetValue(option, out index)) { }
            if (index > 1)
            {
                string oneLess;
                if (orderTitlePage.TryGetValue(index - 1, out oneLess)) { }
                titlePageOrder[oneLess] = index;
                titlePageOrder[option] = index - 1;
                orderTitlePage[index] = oneLess;
                orderTitlePage[index - 1] = option;
            }
            reOrderTitlePage();
        }

        private void reOrderTitlePage()
        {
            for (int i = 1; i <= 6; i++)
            {
                int yOffset = 23 * (i - 1);
                string toPosition;
                if (orderTitlePage.TryGetValue(i, out toPosition)) { }
                switch (toPosition)
                {
                    case "TITLE":
                        titleUpButton.Location = new Point(9, 19 + yOffset);
                        titleDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageTitleCheck.Location = new Point(41, 19 + yOffset);
                        titlePageTitleLabel.Location = new Point(176, 20 + yOffset);
                        titlePageTitleEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "NAME":
                        nameUpButton.Location = new Point(9, 19 + yOffset);
                        nameDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageNameCheck.Location = new Point(41, 19 + yOffset);
                        titlePageNameLabel.Location = new Point(168, 20 + yOffset);
                        titlePageNameEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "CLASS":
                        classUpButton.Location = new Point(9, 19 + yOffset);
                        classDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageClassCheck.Location = new Point(41, 19 + yOffset);
                        titlePageClassLabel.Location = new Point(171, 20 + yOffset);
                        titlePageClassEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "PROFESSOR":
                        professorUpButton.Location = new Point(9, 19 + yOffset);
                        professorDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageProfessorCheck.Location = new Point(41, 19 + yOffset);
                        titlePageProfessorLabel.Location = new Point(152, 20 + yOffset);
                        titlePageProfessorEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "SCHOOL":
                        schoolUpButton.Location = new Point(9, 19 + yOffset);
                        schoolDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageSchoolCheck.Location = new Point(41, 19 + yOffset);
                        titlePageSchoolLabel.Location = new Point(162, 20 + yOffset);
                        titlePageSchoolEnter.Location = new Point(212, 17 + yOffset);
                        break;
                    case "DATE":
                        dateUpButton.Location = new Point(9, 19 + yOffset);
                        dateDownButton.Location = new Point(9, 28 + yOffset);
                        titlePageDateCheck.Location = new Point(41, 19 + yOffset);
                        titlePageDateLabel.Location = new Point(172, 20 + yOffset);
                        titlePageDateEnter.Location = new Point(212, 17 + yOffset);
                        break;
                }
            }
        }

        private void titlePageTitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageTitleCheck.Checked)
            {
                titlePageTitleLabel.Visible = true;
                titlePageTitleEnter.Visible = true;
            }
            else
            {
                titlePageTitleLabel.Visible = false;
                titlePageTitleEnter.Visible = false;
            }
        }

        private void titlePageNameCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageNameCheck.Checked)
            {
                titlePageNameLabel.Visible = true;
                titlePageNameEnter.Visible = true;
            }
            else
            {
                titlePageNameLabel.Visible = false;
                titlePageNameEnter.Visible = false;
            }
        }

        private void titlePageClassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageClassCheck.Checked)
            {
                titlePageClassLabel.Visible = true;
                titlePageClassEnter.Visible = true;
            }
            else
            {
                titlePageClassLabel.Visible = false;
                titlePageClassEnter.Visible = false;
            }
        }

        private void titlePageProfessorCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageProfessorCheck.Checked)
            {
                titlePageProfessorLabel.Visible = true;
                titlePageProfessorEnter.Visible = true;
            }
            else
            {
                titlePageProfessorLabel.Visible = false;
                titlePageProfessorEnter.Visible = false;
            }
        }

        private void titlePageSchoolCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageSchoolCheck.Checked)
            {
                titlePageSchoolLabel.Visible = true;
                titlePageSchoolEnter.Visible = true;
            }
            else
            {
                titlePageSchoolLabel.Visible = false;
                titlePageSchoolEnter.Visible = false;
            }
        }

        private void titlePageDateCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (titlePageDateCheck.Checked)
            {
                titlePageDateLabel.Visible = true;
                titlePageDateEnter.Visible = true;
            }
            else
            {
                titlePageDateLabel.Visible = false;
                titlePageDateEnter.Visible = false;
            }
        }
    }
}
