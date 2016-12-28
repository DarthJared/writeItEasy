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
    public partial class ReferenceAdder : Form
    {
        public Form1 mainForm;
        public ReferenceAdder()
        {
            InitializeComponent();

            this.Width = 1909;
            this.Height = 1447;
            sourceInfoGroupBox.Height = 155;
            sourceInfoPanel.Height = 135;

            bookAuth.Checked = false;
            bookAuth.Checked = true;
        }

        public ReferenceAdder(Form1 form1)
        {
            InitializeComponent();

            this.Width = 1909;
            this.Height = 1447;
            sourceInfoGroupBox.Height = 155;
            sourceInfoPanel.Height = 135;

            bookAuth.Checked = false;
            bookAuth.Checked = true;

            mainForm = form1;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int getSourceInfoHeight(int numSourceInfo)
        {
            return (numSourceInfo * 25) + 5;
        }

        private void removeInsideInfo()
        {
            sourceInfoPanel.VerticalScroll.Value = 0;
            sourceInfoPanel.Controls.Clear();
        }

        private void translatorAdderButton_Click(object sender, EventArgs e)
        {
            Control firstTranslator = Controls.Find("translatorFirstEnter1", true)[0];
            Control middleTranslator = Controls.Find("translatorMiddleEnter1", true)[0];
            Control lastTranslator = Controls.Find("translatorLastEnter1", true)[0];
            sourceInfoPanel.VerticalScroll.Value = 0;
            string numAuth = sourceInfoGroupBox.Tag.ToString().Split(',')[0];
            string numPieces = sourceInfoGroupBox.Tag.ToString().Split(',')[1];
            string numTranslator = sourceInfoGroupBox.Tag.ToString().Split(',')[2];
            string newIndex = (Convert.ToInt32(numTranslator) + 1).ToString();
            string newPieces = (Convert.ToInt32(numPieces) + 1).ToString();
            addAuthor(Convert.ToInt32(newPieces), 25, "translatorFirstEnter" + numTranslator);
            Button addTranslatorButton = (Button)Controls.Find("translatorAdderButton", true)[0];
            addTranslatorButton.Location = new Point(addTranslatorButton.Location.X, addTranslatorButton.Location.Y - 25);

            Label translatorLabel = new Label();
            translatorLabel.Text = "Translator Name:";
            sourceInfoPanel.Controls.Add(translatorLabel);
            translatorLabel.Location = new Point(0, Convert.ToInt32(numAuth) * 25 + 50);

            TextBox translatorFirstEnter = new TextBox();
            translatorFirstEnter.Name = "translatorFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(translatorFirstEnter);
            translatorFirstEnter.Location = new Point(firstTranslator.Location.X, Convert.ToInt32(numAuth) * 25 + 50);
            translatorFirstEnter.Width = 100;
            translatorFirstEnter.Text = "First";
            translatorFirstEnter.ForeColor = Color.DimGray;
            translatorFirstEnter.Tag = "First";
            translatorFirstEnter.Enter += new EventHandler(removePlaceholderText);
            translatorFirstEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox translatorMiddleEnter = new TextBox();
            translatorMiddleEnter.Name = "translatorMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(translatorMiddleEnter);
            translatorMiddleEnter.Location = new Point(middleTranslator.Location.X, Convert.ToInt32(numAuth) * 25 + 50);
            translatorMiddleEnter.Width = 100;
            translatorMiddleEnter.Text = "Middle";
            translatorMiddleEnter.ForeColor = Color.DimGray;
            translatorMiddleEnter.Tag = "Middle";
            translatorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
            translatorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox translatorLastEnter = new TextBox();
            translatorLastEnter.Name = "translatorLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(translatorLastEnter);
            translatorLastEnter.Location = new Point(lastTranslator.Location.X, Convert.ToInt32(numAuth) * 25 + 50);
            translatorLastEnter.Width = 100;
            translatorLastEnter.Text = "Last";
            translatorLastEnter.ForeColor = Color.DimGray;
            translatorLastEnter.Tag = "Last";
            translatorLastEnter.Enter += new EventHandler(removePlaceholderText);
            translatorLastEnter.Leave += new EventHandler(addPlaceholderText);

            sourceInfoGroupBox.Tag = numAuth + "," + newPieces + "," + newIndex;
        }

        private void intervieweeAdderButton_Click(object sender, EventArgs e)
        {
            Control firstInterviewee = Controls.Find("intervieweeFirstEnter1", true)[0];
            Control middleInterviewee = Controls.Find("intervieweeMiddleEnter1", true)[0];
            Control lastInterviewee = Controls.Find("intervieweeLastEnter1", true)[0];
            sourceInfoPanel.VerticalScroll.Value = 0;
            string numInterviewer = sourceInfoGroupBox.Tag.ToString().Split(',')[0];
            string numPieces = sourceInfoGroupBox.Tag.ToString().Split(',')[1];
            string numInterviewee = sourceInfoGroupBox.Tag.ToString().Split(',')[2];
            string newIndex = (Convert.ToInt32(numInterviewee) + 1).ToString();
            string newPieces = (Convert.ToInt32(numPieces) + 1).ToString();
            addAuthor(Convert.ToInt32(newPieces), 25, "intervieweeFirstEnter" + numInterviewee);
            Button addIntervieweeButton = (Button)Controls.Find("intervieweeAdderButton", true)[0];
            addIntervieweeButton.Location = new Point(addIntervieweeButton.Location.X, addIntervieweeButton.Location.Y - 25);

            Label intervieweeLabel = new Label();
            intervieweeLabel.Text = "Interviewee:";
            sourceInfoPanel.Controls.Add(intervieweeLabel);
            intervieweeLabel.Location = new Point(0, Convert.ToInt32(numInterviewer) * 25);

            TextBox intervieweeFirstEnter = new TextBox();
            intervieweeFirstEnter.Name = "intervieweeFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(intervieweeFirstEnter);
            intervieweeFirstEnter.Location = new Point(firstInterviewee.Location.X, Convert.ToInt32(numInterviewer) * 25);
            intervieweeFirstEnter.Width = 100;
            intervieweeFirstEnter.Text = "First";
            intervieweeFirstEnter.ForeColor = Color.DimGray;
            intervieweeFirstEnter.Tag = "First";
            intervieweeFirstEnter.Enter += new EventHandler(removePlaceholderText);
            intervieweeFirstEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox intervieweeMiddleEnter = new TextBox();
            intervieweeMiddleEnter.Name = "intervieweeMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(intervieweeMiddleEnter);
            intervieweeMiddleEnter.Location = new Point(middleInterviewee.Location.X, Convert.ToInt32(numInterviewer) * 25);
            intervieweeMiddleEnter.Width = 100;
            intervieweeMiddleEnter.Text = "Middle";
            intervieweeMiddleEnter.ForeColor = Color.DimGray;
            intervieweeMiddleEnter.Tag = "Middle";
            intervieweeMiddleEnter.Enter += new EventHandler(removePlaceholderText);
            intervieweeMiddleEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox intervieweeLastEnter = new TextBox();
            intervieweeLastEnter.Name = "intervieweeLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(intervieweeLastEnter);
            intervieweeLastEnter.Location = new Point(lastInterviewee.Location.X, Convert.ToInt32(numInterviewer) * 25);
            intervieweeLastEnter.Width = 100;
            intervieweeLastEnter.Text = "Last";
            intervieweeLastEnter.ForeColor = Color.DimGray;
            intervieweeLastEnter.Tag = "Last";
            intervieweeLastEnter.Enter += new EventHandler(removePlaceholderText);
            intervieweeLastEnter.Leave += new EventHandler(addPlaceholderText);

            sourceInfoGroupBox.Tag = numInterviewer + "," + newPieces + "," + newIndex;
        }

        private void interviewerAdderButton_Click(object sender, EventArgs e)
        {
            Control firstInterviewer = Controls.Find("interviewerFirstEnter1", true)[0];
            Control middleInterviewer = Controls.Find("interviewerMiddleEnter1", true)[0];
            Control lastInterviewer = Controls.Find("interviewerLastEnter1", true)[0];
            sourceInfoPanel.VerticalScroll.Value = 0;
            string numInterviewer = sourceInfoGroupBox.Tag.ToString().Split(',')[0];
            string numPieces = sourceInfoGroupBox.Tag.ToString().Split(',')[1];
            string numInterviewee = sourceInfoGroupBox.Tag.ToString().Split(',')[2];
            string newIndex = (Convert.ToInt32(numInterviewer) + 1).ToString();
            string newPieces = (Convert.ToInt32(numPieces) + 1).ToString();
            addAuthor(Convert.ToInt32(newPieces), 25, "interviewerFirstEnter" + numInterviewer);
            Button addInterviewerButton = (Button)Controls.Find("interviewerAdderButton", true)[0];
            addInterviewerButton.Location = new Point(addInterviewerButton.Location.X, addInterviewerButton.Location.Y - 25);

            Label interviewerLabel = new Label();
            interviewerLabel.Text = "Interviewer:";
            sourceInfoPanel.Controls.Add(interviewerLabel);
            interviewerLabel.Location = new Point(0, 0);

            TextBox interviewerFirstEnter = new TextBox();
            interviewerFirstEnter.Name = "interviewerFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(interviewerFirstEnter);
            interviewerFirstEnter.Location = new Point(firstInterviewer.Location.X, 0);
            interviewerFirstEnter.Width = 100;
            interviewerFirstEnter.Text = "First";
            interviewerFirstEnter.ForeColor = Color.DimGray;
            interviewerFirstEnter.Tag = "First";
            interviewerFirstEnter.Enter += new EventHandler(removePlaceholderText);
            interviewerFirstEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox interviewerMiddleEnter = new TextBox();
            interviewerMiddleEnter.Name = "interviewerMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(interviewerMiddleEnter);
            interviewerMiddleEnter.Location = new Point(middleInterviewer.Location.X, 0);
            interviewerMiddleEnter.Width = 100;
            interviewerMiddleEnter.Text = "Middle";
            interviewerMiddleEnter.ForeColor = Color.DimGray;
            interviewerMiddleEnter.Tag = "Middle";
            interviewerMiddleEnter.Enter += new EventHandler(removePlaceholderText);
            interviewerMiddleEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox interviewerLastEnter = new TextBox();
            interviewerLastEnter.Name = "interviewerLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(interviewerLastEnter);
            interviewerLastEnter.Location = new Point(lastInterviewer.Location.X, 0);
            interviewerLastEnter.Width = 100;
            interviewerLastEnter.Text = "Last";
            interviewerLastEnter.ForeColor = Color.DimGray;
            interviewerLastEnter.Tag = "Last";
            interviewerLastEnter.Enter += new EventHandler(removePlaceholderText);
            interviewerLastEnter.Leave += new EventHandler(addPlaceholderText);

            sourceInfoGroupBox.Tag = newIndex + "," + newPieces + "," + numInterviewee;
        }

        private void presenterAdderButton_Click(object sender, EventArgs e)
        {
            Control firstPresenter = Controls.Find("presenterFirstEnter1", true)[0];
            Control middlePresenter = Controls.Find("presenterMiddleEnter1", true)[0];
            Control lastPresenter = Controls.Find("presenterLastEnter1", true)[0];
            sourceInfoPanel.VerticalScroll.Value = 0;
            string numPres = sourceInfoGroupBox.Tag.ToString().Split(',')[0];
            string numPieces = sourceInfoGroupBox.Tag.ToString().Split(',')[1];
            string newIndex = (Convert.ToInt32(numPres) + 1).ToString();
            string newPieces = (Convert.ToInt32(numPieces) + 1).ToString();
            addAuthor(Convert.ToInt32(newPieces), 25, "presenterFirstEnter" + numPres);
            Button addPresenterButton = (Button)Controls.Find("presenterAdderButton", true)[0];
            addPresenterButton.Location = new Point(addPresenterButton.Location.X, addPresenterButton.Location.Y - 25);

            Label presenterLabel = new Label();
            presenterLabel.Text = "Presenter:";
            sourceInfoPanel.Controls.Add(presenterLabel);
            presenterLabel.Location = new Point(0, 0);

            TextBox presenterFirstEnter = new TextBox();
            presenterFirstEnter.Name = "presenterFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(presenterFirstEnter);
            presenterFirstEnter.Location = new Point(firstPresenter.Location.X, 0);
            presenterFirstEnter.Width = 100;
            presenterFirstEnter.Text = "First";
            presenterFirstEnter.ForeColor = Color.DimGray;
            presenterFirstEnter.Tag = "First";
            presenterFirstEnter.Enter += new EventHandler(removePlaceholderText);
            presenterFirstEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox presenterMiddleEnter = new TextBox();
            presenterMiddleEnter.Name = "presenterMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(presenterMiddleEnter);
            presenterMiddleEnter.Location = new Point(middlePresenter.Location.X, 0);
            presenterMiddleEnter.Width = 100;
            presenterMiddleEnter.Text = "Middle";
            presenterMiddleEnter.ForeColor = Color.DimGray;
            presenterMiddleEnter.Tag = "Middle";
            presenterMiddleEnter.Enter += new EventHandler(removePlaceholderText);
            presenterMiddleEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox presenterLastEnter = new TextBox();
            presenterLastEnter.Name = "presenterLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(presenterLastEnter);
            presenterLastEnter.Location = new Point(lastPresenter.Location.X, 0);
            presenterLastEnter.Width = 100;
            presenterLastEnter.Text = "Last";
            presenterLastEnter.ForeColor = Color.DimGray;
            presenterLastEnter.Tag = "Last";
            presenterLastEnter.Enter += new EventHandler(removePlaceholderText);
            presenterLastEnter.Leave += new EventHandler(addPlaceholderText);

            sourceInfoGroupBox.Tag = newIndex + "," + newPieces;
        }

        private void authorAdderButton_Click(object sender, EventArgs e)
        {
            Control firstAuthor = Controls.Find("authorFirstEnter1", true)[0];
            Control middleAuthor = Controls.Find("authorMiddleEnter1", true)[0];
            Control lastAuthor = Controls.Find("authorLastEnter1", true)[0];
            sourceInfoPanel.VerticalScroll.Value = 0;
            string numAuth = sourceInfoGroupBox.Tag.ToString().Split(',')[0];
            string numPieces = sourceInfoGroupBox.Tag.ToString().Split(',')[1];
            string newIndex = (Convert.ToInt32(numAuth) + 1).ToString();
            string newPieces = (Convert.ToInt32(numPieces) + 1).ToString();
            addAuthor(Convert.ToInt32(newPieces), 25, "authorFirstEnter" + numAuth);
            Button addAuthorButton = (Button)Controls.Find("authorAdderButton", true)[0];
            addAuthorButton.Location = new Point(addAuthorButton.Location.X, addAuthorButton.Location.Y - 25);

            Label authorLabel = new Label();
            authorLabel.Text = "Author:";
            sourceInfoPanel.Controls.Add(authorLabel);
            authorLabel.Location = new Point(0, 0);

            TextBox authorFirstEnter = new TextBox();
            authorFirstEnter.Name = "authorFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorFirstEnter);
            authorFirstEnter.Location = new Point(firstAuthor.Location.X, 0);
            authorFirstEnter.Width = 100;
            authorFirstEnter.Text = "First";
            authorFirstEnter.ForeColor = Color.DimGray;
            authorFirstEnter.Tag = "First";
            authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
            authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox authorMiddleEnter = new TextBox();
            authorMiddleEnter.Name = "authorMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorMiddleEnter);
            authorMiddleEnter.Location = new Point(middleAuthor.Location.X, 0);
            authorMiddleEnter.Width = 100;
            authorMiddleEnter.Text = "Middle";
            authorMiddleEnter.ForeColor = Color.DimGray;
            authorMiddleEnter.Tag = "Middle";
            authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
            authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox authorLastEnter = new TextBox();
            authorLastEnter.Name = "authorLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorLastEnter);
            authorLastEnter.Location = new Point(lastAuthor.Location.X, 0);
            authorLastEnter.Width = 100;
            authorLastEnter.Text = "Last";
            authorLastEnter.ForeColor = Color.DimGray;
            authorLastEnter.Tag = "Last";
            authorLastEnter.Enter += new EventHandler(removePlaceholderText);
            authorLastEnter.Leave += new EventHandler(addPlaceholderText);

            sourceInfoGroupBox.Tag = newIndex + "," + newPieces;
        }
        private void authorTransAdderButton_Click(object sender, EventArgs e)
        {
            Control firstAuthor = Controls.Find("authorFirstEnter1", true)[0];
            Control middleAuthor = Controls.Find("authorMiddleEnter1", true)[0];
            Control lastAuthor = Controls.Find("authorLastEnter1", true)[0];
            sourceInfoPanel.VerticalScroll.Value = 0;
            string numAuth = sourceInfoGroupBox.Tag.ToString().Split(',')[0];
            string numPieces = sourceInfoGroupBox.Tag.ToString().Split(',')[1];
            string numTrans = sourceInfoGroupBox.Tag.ToString().Split(',')[2];
            string newIndex = (Convert.ToInt32(numAuth) + 1).ToString();
            string newPieces = (Convert.ToInt32(numPieces) + 1).ToString();
            addAuthor(Convert.ToInt32(newPieces), 25, "authorFirstEnter" + numAuth);
            Button addAuthorButton = (Button)Controls.Find("authorTransAdderButton", true)[0];
            addAuthorButton.Location = new Point(addAuthorButton.Location.X, addAuthorButton.Location.Y - 25);

            Label authorLabel = new Label();
            authorLabel.Text = "Author:";
            sourceInfoPanel.Controls.Add(authorLabel);
            authorLabel.Location = new Point(0, 0);

            TextBox authorFirstEnter = new TextBox();
            authorFirstEnter.Name = "authorFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorFirstEnter);
            authorFirstEnter.Location = new Point(firstAuthor.Location.X, 0);
            authorFirstEnter.Width = 100;
            authorFirstEnter.Text = "First";
            authorFirstEnter.ForeColor = Color.DimGray;
            authorFirstEnter.Tag = "First";
            authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
            authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox authorMiddleEnter = new TextBox();
            authorMiddleEnter.Name = "authorMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorMiddleEnter);
            authorMiddleEnter.Location = new Point(middleAuthor.Location.X, 0);
            authorMiddleEnter.Width = 100;
            authorMiddleEnter.Text = "Middle";
            authorMiddleEnter.ForeColor = Color.DimGray;
            authorMiddleEnter.Tag = "Middle";
            authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
            authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox authorLastEnter = new TextBox();
            authorLastEnter.Name = "authorLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorLastEnter);
            authorLastEnter.Location = new Point(lastAuthor.Location.X, 0);
            authorLastEnter.Width = 100;
            authorLastEnter.Text = "Last";
            authorLastEnter.ForeColor = Color.DimGray;
            authorLastEnter.Tag = "Last";
            authorLastEnter.Enter += new EventHandler(removePlaceholderText);
            authorLastEnter.Leave += new EventHandler(addPlaceholderText);

            sourceInfoGroupBox.Tag = newIndex + "," + newPieces + "," + numTrans;
        }

        private void originalAuthorAdderButton_Click(object sender, EventArgs e)
        {
            Control firstAuthor = Controls.Find("authorFirstEnter1", true)[0];
            Control middleAuthor = Controls.Find("authorMiddleEnter1", true)[0];
            Control lastAuthor = Controls.Find("authorLastEnter1", true)[0];
            sourceInfoPanel.VerticalScroll.Value = 0;
            string numRev = sourceInfoGroupBox.Tag.ToString().Split(',')[0];
            string numPieces = sourceInfoGroupBox.Tag.ToString().Split(',')[1];
            string numAuth = sourceInfoGroupBox.Tag.ToString().Split(',')[2];
            string newIndex = (Convert.ToInt32(numAuth) + 1).ToString();
            string newPieces = (Convert.ToInt32(numPieces) + 1).ToString();
            addAuthor(Convert.ToInt32(newPieces), 25, "authorFirstEnter" + numAuth);
            Button originalAuthorAdderButton = (Button)Controls.Find("originalAuthorAdderButton", true)[0];
            originalAuthorAdderButton.Location = new Point(originalAuthorAdderButton.Location.X, originalAuthorAdderButton.Location.Y - 25);

            Label authorLabel = new Label();
            authorLabel.Text = "Original Author Name:";
            sourceInfoPanel.Controls.Add(authorLabel);
            authorLabel.Location = new Point(0, Convert.ToInt32(numRev) * 25 + 75);
            authorLabel.Width = 180;

            TextBox authorFirstEnter = new TextBox();
            authorFirstEnter.Name = "authorFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorFirstEnter);
            authorFirstEnter.Location = new Point(firstAuthor.Location.X, Convert.ToInt32(numRev) * 25 + 75);
            authorFirstEnter.Width = 100;
            authorFirstEnter.Text = "First";
            authorFirstEnter.ForeColor = Color.DimGray;
            authorFirstEnter.Tag = "First";
            authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
            authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox authorMiddleEnter = new TextBox();
            authorMiddleEnter.Name = "authorMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorMiddleEnter);
            authorMiddleEnter.Location = new Point(middleAuthor.Location.X, Convert.ToInt32(numRev) * 25 + 75);
            authorMiddleEnter.Width = 100;
            authorMiddleEnter.Text = "Middle";
            authorMiddleEnter.ForeColor = Color.DimGray;
            authorMiddleEnter.Tag = "Middle";
            authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
            authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox authorLastEnter = new TextBox();
            authorLastEnter.Name = "authorLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorLastEnter);
            authorLastEnter.Location = new Point(lastAuthor.Location.X, Convert.ToInt32(numRev) * 25 + 75);
            authorLastEnter.Width = 100;
            authorLastEnter.Text = "Last";
            authorLastEnter.ForeColor = Color.DimGray;
            authorLastEnter.Tag = "Last";
            authorLastEnter.Enter += new EventHandler(removePlaceholderText);
            authorLastEnter.Leave += new EventHandler(addPlaceholderText);

            sourceInfoGroupBox.Tag = numRev + "," + newPieces + "," + newIndex;
        }

        private void reviewerAdderButton_Click(object sender, EventArgs e)
        {
            Control firstReviewer = Controls.Find("reviewerFirstEnter1", true)[0];
            Control middleReviewer = Controls.Find("reviewerMiddleEnter1", true)[0];
            Control lastReviewer = Controls.Find("reviewerLastEnter1", true)[0];
            sourceInfoPanel.VerticalScroll.Value = 0;
            string numRev = sourceInfoGroupBox.Tag.ToString().Split(',')[0];
            string numPieces = sourceInfoGroupBox.Tag.ToString().Split(',')[1];
            string numOrigAuth = sourceInfoGroupBox.Tag.ToString().Split(',')[2];
            string newIndex = (Convert.ToInt32(numRev) + 1).ToString();
            string newPieces = (Convert.ToInt32(numPieces) + 1).ToString();
            addAuthor(Convert.ToInt32(newPieces), 25, "reviewerFirstEnter" + numRev);
            Button addReviewerButton = (Button)Controls.Find("reviewerAdderButton", true)[0];
            addReviewerButton.Location = new Point(addReviewerButton.Location.X, addReviewerButton.Location.Y - 25);

            Label reviewerLabel = new Label();
            reviewerLabel.Text = "Reviewer:";
            sourceInfoPanel.Controls.Add(reviewerLabel);
            reviewerLabel.Location = new Point(0, 0);

            TextBox reviewerFirstEnter = new TextBox();
            reviewerFirstEnter.Name = "reviewerFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(reviewerFirstEnter);
            reviewerFirstEnter.Location = new Point(firstReviewer.Location.X, 0);
            reviewerFirstEnter.Width = 100;
            reviewerFirstEnter.Text = "First";
            reviewerFirstEnter.ForeColor = Color.DimGray;
            reviewerFirstEnter.Tag = "First";
            reviewerFirstEnter.Enter += new EventHandler(removePlaceholderText);
            reviewerFirstEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox reviewerMiddleEnter = new TextBox();
            reviewerMiddleEnter.Name = "reviewerMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(reviewerMiddleEnter);
            reviewerMiddleEnter.Location = new Point(middleReviewer.Location.X, 0);
            reviewerMiddleEnter.Width = 100;
            reviewerMiddleEnter.Text = "Middle";
            reviewerMiddleEnter.ForeColor = Color.DimGray;
            reviewerMiddleEnter.Tag = "Middle";
            reviewerMiddleEnter.Enter += new EventHandler(removePlaceholderText);
            reviewerMiddleEnter.Leave += new EventHandler(addPlaceholderText);

            TextBox reviewerLastEnter = new TextBox();
            reviewerLastEnter.Name = "reviewerLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(reviewerLastEnter);
            reviewerLastEnter.Location = new Point(lastReviewer.Location.X, 0);
            reviewerLastEnter.Width = 100;
            reviewerLastEnter.Text = "Last";
            reviewerLastEnter.ForeColor = Color.DimGray;
            reviewerLastEnter.Tag = "Last";
            reviewerLastEnter.Enter += new EventHandler(removePlaceholderText);
            reviewerLastEnter.Leave += new EventHandler(addPlaceholderText);

            sourceInfoGroupBox.Tag = newIndex + "," + newPieces + "," + numOrigAuth;
        }

        //highestControlName is the highest thing to lower
        private void addAuthor(int newNum, int pixels, string highestControlName)
        {
            Control highest = Controls.Find(highestControlName, true)[0];
            int highestY = highest.Location.Y;
            Control parent = highest.Parent;

            foreach (Control child in parent.Controls)
            {
                if (child.Location.Y >= highestY)
                {
                    child.Location = new Point(child.Location.X, child.Location.Y + pixels);
                }
            }

            if (getSourceInfoHeight(newNum) > 135)
            {
                sourceInfoPanel.Height = 135;
                sourceInfoGroupBox.Height = 160;
                sourceInfoPanel.AutoScroll = true;

                moveTo("quoteContentGroupBox", 434);
            }
            else
            {
                sourceInfoPanel.Height = getSourceInfoHeight(newNum);
                sourceInfoGroupBox.Height = getSourceInfoHeight(newNum) + 25;
                sourceInfoPanel.VerticalScroll.Value = 0;
                sourceInfoPanel.AutoScroll = false;

                moveTo("quoteContentGroupBox", getSourceInfoHeight(newNum) + 299);
            }
        }

        private void moveTo(string controlName, int yPos)
        {
            Control controlToMove = Controls.Find(controlName, true)[0];
            int yDiff = yPos - controlToMove.Location.Y;
            int topY = controlToMove.Location.Y;
            Control parent = controlToMove.Parent;

            foreach (Control child in parent.Controls)
            {
                if (child.Location.Y >= topY)
                {
                    child.Location = new Point(child.Location.X, child.Location.Y + yDiff);
                }
            }
            parent.Height += yDiff;
        }        

        private void referenceTypeChange(object sender, EventArgs e)
        {
            if (bookAuth.Checked)
            {
                removeInsideInfo(); 

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 299);
                }
                sourceInfoGroupBox.Tag = "1,6";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;
                authorFirstEnter.Text = "First";
                authorFirstEnter.ForeColor = Color.DimGray;
                authorFirstEnter.Tag = "First";
                authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
                authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;
                authorMiddleEnter.Text = "Middle";
                authorMiddleEnter.ForeColor = Color.DimGray;
                authorMiddleEnter.Tag = "Middle";
                authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
                authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;
                authorLastEnter.Text = "Last";
                authorLastEnter.ForeColor = Color.DimGray;
                authorLastEnter.Tag = "Last";
                authorLastEnter.Enter += new EventHandler(removePlaceholderText);
                authorLastEnter.Leave += new EventHandler(addPlaceholderText);

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);                

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;
                publishDateEnter.Text = "YYYY";
                publishDateEnter.ForeColor = Color.DimGray;
                publishDateEnter.Tag = "YYYY";
                publishDateEnter.Enter += new EventHandler(removePlaceholderText);
                publishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);
                
                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;
                titleEnter.Text = "Title";
                titleEnter.ForeColor = Color.DimGray;
                titleEnter.Tag = "Title";
                titleEnter.Enter += new EventHandler(removePlaceholderText);
                titleEnter.Leave += new EventHandler(addPlaceholderText);

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 75);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 75);
                publisherEnter.Width = 150;
                publisherEnter.Text = "Publisher";
                publisherEnter.ForeColor = Color.DimGray;
                publisherEnter.Tag = "Publisher";
                publisherEnter.Enter += new EventHandler(removePlaceholderText);
                publisherEnter.Leave += new EventHandler(addPlaceholderText);

                Label publishLocationLabel = new Label();
                publishLocationLabel.Text = "Publication Location:";
                sourceInfoPanel.Controls.Add(publishLocationLabel);
                publishLocationLabel.Location = new Point(0, 100);
                publishLocationLabel.Width = 109;

                TextBox publishLocationEnter = new TextBox();
                publishLocationEnter.Name = "publishLocationEnter";
                sourceInfoPanel.Controls.Add(publishLocationEnter);
                publishLocationEnter.Location = new Point(109, 100);
                publishLocationEnter.Width = 150;
                publishLocationEnter.Text = "Location";
                publishLocationEnter.ForeColor = Color.DimGray;
                publishLocationEnter.Tag = "Location";
                publishLocationEnter.Enter += new EventHandler(removePlaceholderText);
                publishLocationEnter.Leave += new EventHandler(addPlaceholderText);

                Label editionLabel = new Label();
                editionLabel.Text = "Edition:";
                sourceInfoPanel.Controls.Add(editionLabel);
                editionLabel.Location = new Point(0, 125);

                TextBox editionEnter = new TextBox();
                editionEnter.Name = "editionEnter";
                sourceInfoPanel.Controls.Add(editionEnter);
                editionEnter.Location = new Point(109, 125);
                editionEnter.Width = 150;
                editionEnter.Text = "ex. 1st";
                editionEnter.ForeColor = Color.DimGray;
                editionEnter.Tag = "ex. 1st";
                editionEnter.Enter += new EventHandler(removePlaceholderText);
                editionEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (bookNoAuth.Checked)
            {
                removeInsideInfo();
                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 0);                

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 0);
                publishDateEnter.Width = 150;
                publishDateEnter.Text = "YYYY";
                publishDateEnter.ForeColor = Color.DimGray;
                publishDateEnter.Tag = "YYYY";
                publishDateEnter.Enter += new EventHandler(removePlaceholderText);
                publishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;
                titleEnter.Text = "Title";
                titleEnter.ForeColor = Color.DimGray;
                titleEnter.Tag = "Title";
                titleEnter.Enter += new EventHandler(removePlaceholderText);
                titleEnter.Leave += new EventHandler(addPlaceholderText);

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 50);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 50);
                publisherEnter.Width = 150;
                publisherEnter.Text = "Publisher";
                publisherEnter.ForeColor = Color.DimGray;
                publisherEnter.Tag = "Publisher";
                publisherEnter.Enter += new EventHandler(removePlaceholderText);
                publisherEnter.Leave += new EventHandler(addPlaceholderText);

                Label publishLocationLabel = new Label();
                publishLocationLabel.Text = "Publication Location:";
                sourceInfoPanel.Controls.Add(publishLocationLabel);
                publishLocationLabel.Location = new Point(0, 75);
                publishLocationLabel.Width = 109;

                TextBox publishLocationEnter = new TextBox();
                publishLocationEnter.Name = "publishLocationEnter";
                sourceInfoPanel.Controls.Add(publishLocationEnter);
                publishLocationEnter.Location = new Point(109, 75);
                publishLocationEnter.Width = 150;
                publishLocationEnter.Text = "Location";
                publishLocationEnter.ForeColor = Color.DimGray;
                publishLocationEnter.Tag = "Location";
                publishLocationEnter.Enter += new EventHandler(removePlaceholderText);
                publishLocationEnter.Leave += new EventHandler(addPlaceholderText);

                Label editionLabel = new Label();
                editionLabel.Text = "Edition:";
                sourceInfoPanel.Controls.Add(editionLabel);
                editionLabel.Location = new Point(0, 100);

                TextBox editionEnter = new TextBox();
                editionEnter.Name = "editionEnter";
                sourceInfoPanel.Controls.Add(editionEnter);
                editionEnter.Location = new Point(109, 100);
                editionEnter.Width = 150;
                editionEnter.Text = "ex. 1st";
                editionEnter.ForeColor = Color.DimGray;
                editionEnter.Tag = "ex. 1st";
                editionEnter.Enter += new EventHandler(removePlaceholderText);
                editionEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (bookByOrg.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 299);
                }

                Label authorLabel = new Label();
                authorLabel.Text = "Organization:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorEnter = new TextBox();
                authorEnter.Name = "authorEnter";
                sourceInfoPanel.Controls.Add(authorEnter);
                authorEnter.Location = new Point(109, 0);
                authorEnter.Width = 150;
                authorEnter.Text = "Organization";
                authorEnter.ForeColor = Color.DimGray;
                authorEnter.Tag = "Organization";
                authorEnter.Enter += new EventHandler(removePlaceholderText);
                authorEnter.Leave += new EventHandler(addPlaceholderText);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;
                publishDateEnter.Text = "YYYY";
                publishDateEnter.ForeColor = Color.DimGray;
                publishDateEnter.Tag = "YYYY";
                publishDateEnter.Enter += new EventHandler(removePlaceholderText);
                publishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;
                titleEnter.Text = "Title";
                titleEnter.ForeColor = Color.DimGray;
                titleEnter.Tag = "Title";
                titleEnter.Enter += new EventHandler(removePlaceholderText);
                titleEnter.Leave += new EventHandler(addPlaceholderText);

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 75);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 75);
                publisherEnter.Width = 150;
                publisherEnter.Text = "Publisher";
                publisherEnter.ForeColor = Color.DimGray;
                publisherEnter.Tag = "Publisher";
                publisherEnter.Enter += new EventHandler(removePlaceholderText);
                publisherEnter.Leave += new EventHandler(addPlaceholderText);

                Label publishLocationLabel = new Label();
                publishLocationLabel.Text = "Publication Location:";
                sourceInfoPanel.Controls.Add(publishLocationLabel);
                publishLocationLabel.Location = new Point(0, 100);
                publishLocationLabel.Width = 109;

                TextBox publishLocationEnter = new TextBox();
                publishLocationEnter.Name = "publishLocationEnter";
                sourceInfoPanel.Controls.Add(publishLocationEnter);
                publishLocationEnter.Location = new Point(109, 100);
                publishLocationEnter.Width = 150;
                publishLocationEnter.Text = "Location";
                publishLocationEnter.ForeColor = Color.DimGray;
                publishLocationEnter.Tag = "Location";
                publishLocationEnter.Enter += new EventHandler(removePlaceholderText);
                publishLocationEnter.Leave += new EventHandler(addPlaceholderText);

                Label editionLabel = new Label();
                editionLabel.Text = "Edition:";
                sourceInfoPanel.Controls.Add(editionLabel);
                editionLabel.Location = new Point(0, 125);

                TextBox editionEnter = new TextBox();
                editionEnter.Name = "editionEnter";
                sourceInfoPanel.Controls.Add(editionEnter);
                editionEnter.Location = new Point(109, 125);
                editionEnter.Width = 150;
                editionEnter.Text = "ex. 1st";
                editionEnter.ForeColor = Color.DimGray;
                editionEnter.Tag = "ex. 1st";
                editionEnter.Enter += new EventHandler(removePlaceholderText);
                editionEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (encyclopedia.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(9) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(9);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(9) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(9) + 299);
                }
                sourceInfoGroupBox.Tag = "1,9";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(180, 0);
                authorFirstEnter.Width = 100;
                authorFirstEnter.Text = "First";
                authorFirstEnter.ForeColor = Color.DimGray;
                authorFirstEnter.Tag = "First";
                authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
                authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(295, 0);
                authorMiddleEnter.Width = 100;
                authorMiddleEnter.Text = "Middle";
                authorMiddleEnter.ForeColor = Color.DimGray;
                authorMiddleEnter.Tag = "Middle";
                authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
                authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(410, 0);
                authorLastEnter.Width = 100;
                authorLastEnter.Text = "Last";
                authorLastEnter.ForeColor = Color.DimGray;
                authorLastEnter.Tag = "Last";
                authorLastEnter.Enter += new EventHandler(removePlaceholderText);
                authorLastEnter.Leave += new EventHandler(addPlaceholderText);

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(530, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publicationYearLabel = new Label();
                publicationYearLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publicationYearLabel);
                publicationYearLabel.Location = new Point(0, 25);

                TextBox publicationYearEnter = new TextBox();
                publicationYearEnter.Name = "publicationYearEnter";
                sourceInfoPanel.Controls.Add(publicationYearEnter);
                publicationYearEnter.Location = new Point(180, 25);
                publicationYearEnter.Width = 150;
                publicationYearEnter.Text = "YYYY";
                publicationYearEnter.ForeColor = Color.DimGray;
                publicationYearEnter.Tag = "YYYY";
                publicationYearEnter.Enter += new EventHandler(removePlaceholderText);
                publicationYearEnter.Leave += new EventHandler(addPlaceholderText);

                Label sectionNameLabel = new Label();
                sectionNameLabel.Text = "Section or Word Referenced:";
                sourceInfoPanel.Controls.Add(sectionNameLabel);
                sectionNameLabel.Location = new Point(0, 50);
                sectionNameLabel.Width = 180;

                TextBox sectionNameEnter = new TextBox();
                sectionNameEnter.Name = "sectionNameEnter";
                sourceInfoPanel.Controls.Add(sectionNameEnter);
                sectionNameEnter.Location = new Point(180, 50);
                sectionNameEnter.Width = 150;
                sectionNameEnter.Text = "ex. History";
                sectionNameEnter.ForeColor = Color.DimGray;
                sectionNameEnter.Tag = "ex. History";
                sectionNameEnter.Enter += new EventHandler(removePlaceholderText);
                sectionNameEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookNameLabel = new Label();
                bookNameLabel.Text = "Title of Encyclopedia/Dictionary:";
                sourceInfoPanel.Controls.Add(bookNameLabel);
                bookNameLabel.Location = new Point(0, 75);
                bookNameLabel.Width = 180;

                TextBox bookNameEnter = new TextBox();
                bookNameEnter.Name = "bookNameEnter";
                sourceInfoPanel.Controls.Add(bookNameEnter);
                bookNameEnter.Location = new Point(180, 75);
                bookNameEnter.Width = 150;
                bookNameEnter.Text = "ex. Webster Dictionary";
                bookNameEnter.ForeColor = Color.DimGray;
                bookNameEnter.Tag = "ex. Webster Dictionary";
                bookNameEnter.Enter += new EventHandler(removePlaceholderText);
                bookNameEnter.Leave += new EventHandler(addPlaceholderText);

                Label volumeLabel = new Label();
                volumeLabel.Text = "Volume:";
                sourceInfoPanel.Controls.Add(volumeLabel);
                volumeLabel.Location = new Point(0, 100);

                TextBox volumeEnter = new TextBox();
                volumeEnter.Name = "volumeEnter";
                sourceInfoPanel.Controls.Add(volumeEnter);
                volumeEnter.Location = new Point(180, 100);
                volumeEnter.Width = 150;
                volumeEnter.Text = "Volume Number";
                volumeEnter.ForeColor = Color.DimGray;
                volumeEnter.Tag = "Volume Number";
                volumeEnter.Enter += new EventHandler(removePlaceholderText);
                volumeEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 125);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(180, 125);
                pageStartEnter.Width = 150;
                pageStartEnter.Text = "Start Page";
                pageStartEnter.ForeColor = Color.DimGray;
                pageStartEnter.Tag = "Start Page";
                pageStartEnter.Enter += new EventHandler(removePlaceholderText);
                pageStartEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 150);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(180, 150);
                pageEndEnter.Width = 150;
                pageEndEnter.Text = "End Page";
                pageEndEnter.ForeColor = Color.DimGray;
                pageEndEnter.Tag = "End Page";
                pageEndEnter.Enter += new EventHandler(removePlaceholderText);
                pageEndEnter.Leave += new EventHandler(addPlaceholderText);

                Label publishLocationLabel = new Label();
                publishLocationLabel.Text = "Publication Location:";
                sourceInfoPanel.Controls.Add(publishLocationLabel);
                publishLocationLabel.Location = new Point(0, 175);
                publishLocationLabel.Width = 180;

                TextBox publicationLocationEnter = new TextBox();
                publicationLocationEnter.Name = "publicationLocationEnter";
                sourceInfoPanel.Controls.Add(publicationLocationEnter);
                publicationLocationEnter.Location = new Point(180, 175);
                publicationLocationEnter.Width = 150;
                publicationLocationEnter.Text = "Location";
                publicationLocationEnter.ForeColor = Color.DimGray;
                publicationLocationEnter.Tag = "Location";
                publicationLocationEnter.Enter += new EventHandler(removePlaceholderText);
                publicationLocationEnter.Leave += new EventHandler(addPlaceholderText);

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 200);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(180, 200);
                publisherEnter.Width = 150;
                publisherEnter.Text = "Publisher";
                publisherEnter.ForeColor = Color.DimGray;
                publisherEnter.Tag = "Publisher";
                publisherEnter.Enter += new EventHandler(removePlaceholderText);
                publisherEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (translated.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 299);
                }
                sourceInfoGroupBox.Tag = "1,8,1";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(180, 0);
                authorFirstEnter.Width = 100;
                authorFirstEnter.Text = "First";
                authorFirstEnter.ForeColor = Color.DimGray;
                authorFirstEnter.Tag = "First";
                authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
                authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(295, 0);
                authorMiddleEnter.Width = 100;
                authorMiddleEnter.Text = "Middle";
                authorMiddleEnter.ForeColor = Color.DimGray;
                authorMiddleEnter.Tag = "Middle";
                authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
                authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(410, 0);
                authorLastEnter.Width = 100;
                authorLastEnter.Text = "Last";
                authorLastEnter.ForeColor = Color.DimGray;
                authorLastEnter.Tag = "Last";
                authorLastEnter.Enter += new EventHandler(removePlaceholderText);
                authorLastEnter.Leave += new EventHandler(addPlaceholderText);

                Button authorTransAdder = new Button();
                authorTransAdder.Name = "authorTransAdderButton";
                authorTransAdder.Text = "Add an Author";
                authorTransAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorTransAdder);
                authorTransAdder.Location = new Point(530, 0);
                authorTransAdder.Click += new EventHandler(authorTransAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Year:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(180, 25);
                publishDateEnter.Width = 150;
                publishDateEnter.Text = "YYYY";
                publishDateEnter.ForeColor = Color.DimGray;
                publishDateEnter.Tag = "YYYY";
                publishDateEnter.Enter += new EventHandler(removePlaceholderText);
                publishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(180, 50);
                titleEnter.Width = 150;
                titleEnter.Text = "Title";
                titleEnter.ForeColor = Color.DimGray;
                titleEnter.Tag = "Title";
                titleEnter.Enter += new EventHandler(removePlaceholderText);
                titleEnter.Leave += new EventHandler(addPlaceholderText);

                Label translatorLabel = new Label();
                translatorLabel.Text = "Translator Name:";
                sourceInfoPanel.Controls.Add(translatorLabel);
                translatorLabel.Location = new Point(0, 75);

                TextBox translatorFirstEnter = new TextBox();
                translatorFirstEnter.Name = "translatorFirstEnter1";
                sourceInfoPanel.Controls.Add(translatorFirstEnter);
                translatorFirstEnter.Location = new Point(180, 75);
                translatorFirstEnter.Width = 100;
                translatorFirstEnter.Text = "First";
                translatorFirstEnter.ForeColor = Color.DimGray;
                translatorFirstEnter.Tag = "First";
                translatorFirstEnter.Enter += new EventHandler(removePlaceholderText);
                translatorFirstEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox translatorMiddleEnter = new TextBox();
                translatorMiddleEnter.Name = "translatorMiddleEnter1";
                sourceInfoPanel.Controls.Add(translatorMiddleEnter);
                translatorMiddleEnter.Location = new Point(295, 75);
                translatorMiddleEnter.Width = 100;
                translatorMiddleEnter.Text = "Middle";
                translatorMiddleEnter.ForeColor = Color.DimGray;
                translatorMiddleEnter.Tag = "Middle";
                translatorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
                translatorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox translatorLastEnter = new TextBox();
                translatorLastEnter.Name = "translatorLastEnter1";
                sourceInfoPanel.Controls.Add(translatorLastEnter);
                translatorLastEnter.Location = new Point(410, 75);
                translatorLastEnter.Width = 100;
                translatorLastEnter.Text = "Last";
                translatorLastEnter.ForeColor = Color.DimGray;
                translatorLastEnter.Tag = "Last";
                translatorLastEnter.Enter += new EventHandler(removePlaceholderText);
                translatorLastEnter.Leave += new EventHandler(addPlaceholderText);

                Button translatorAdder = new Button();
                translatorAdder.Name = "translatorAdderButton";
                translatorAdder.Text = "Add an Translator";
                translatorAdder.Width = 110;
                sourceInfoPanel.Controls.Add(translatorAdder);
                translatorAdder.Location = new Point(530, 75);
                translatorAdder.Click += new EventHandler(translatorAdderButton_Click);

                Label publishLocationLabel = new Label();
                publishLocationLabel.Text = "Publication Location:";
                sourceInfoPanel.Controls.Add(publishLocationLabel);
                publishLocationLabel.Location = new Point(0, 100);
                publishLocationLabel.Width = 109;

                TextBox publishLocationEnter = new TextBox();
                publishLocationEnter.Name = "publishLocationEnter";
                sourceInfoPanel.Controls.Add(publishLocationEnter);
                publishLocationEnter.Location = new Point(180, 100);
                publishLocationEnter.Width = 150;
                publishLocationEnter.Text = "Location";
                publishLocationEnter.ForeColor = Color.DimGray;
                publishLocationEnter.Tag = "Location";
                publishLocationEnter.Enter += new EventHandler(removePlaceholderText);
                publishLocationEnter.Leave += new EventHandler(addPlaceholderText);

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 125);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(180, 125);
                publisherEnter.Width = 150;
                publisherEnter.Text = "Publisher";
                publisherEnter.ForeColor = Color.DimGray;
                publisherEnter.Tag = "Publisher";
                publisherEnter.Enter += new EventHandler(removePlaceholderText);
                publisherEnter.Leave += new EventHandler(addPlaceholderText);

                Label originalPublishDateLabel = new Label();
                originalPublishDateLabel.Text = "Original Publication Year:";
                sourceInfoPanel.Controls.Add(originalPublishDateLabel);
                originalPublishDateLabel.Location = new Point(0, 150);
                originalPublishDateLabel.Width = 180;

                TextBox originalPublishDateEnter = new TextBox();
                originalPublishDateEnter.Name = "originalPublishDateEnter";
                sourceInfoPanel.Controls.Add(originalPublishDateEnter);
                originalPublishDateEnter.Location = new Point(180, 150);
                originalPublishDateEnter.Width = 150;
                originalPublishDateEnter.Text = "YYYY";
                originalPublishDateEnter.ForeColor = Color.DimGray;
                originalPublishDateEnter.Tag = "YYYY";
                originalPublishDateEnter.Enter += new EventHandler(removePlaceholderText);
                originalPublishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label editionLabel = new Label();
                editionLabel.Text = "Edition:";
                sourceInfoPanel.Controls.Add(editionLabel);
                editionLabel.Location = new Point(0, 175);

                TextBox editionEnter = new TextBox();
                editionEnter.Name = "editionEnter";
                sourceInfoPanel.Controls.Add(editionEnter);
                editionEnter.Location = new Point(180, 175);
                editionEnter.Width = 150;
                editionEnter.Text = "ex. 1st";
                editionEnter.ForeColor = Color.DimGray;
                editionEnter.Tag = "ex. 1st";
                editionEnter.Enter += new EventHandler(removePlaceholderText);
                editionEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (magazine.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 299);
                }
                sourceInfoGroupBox.Tag = "1,8";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;
                authorFirstEnter.Text = "First";
                authorFirstEnter.ForeColor = Color.DimGray;
                authorFirstEnter.Tag = "First";
                authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
                authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;
                authorMiddleEnter.Text = "Middle";
                authorMiddleEnter.ForeColor = Color.DimGray;
                authorMiddleEnter.Tag = "Middle";
                authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
                authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;
                authorLastEnter.Text = "Last";
                authorLastEnter.ForeColor = Color.DimGray;
                authorLastEnter.Tag = "Last";
                authorLastEnter.Enter += new EventHandler(removePlaceholderText);
                authorLastEnter.Leave += new EventHandler(addPlaceholderText);

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;
                publishDateEnter.Text = "YYYY, Mmmm DD or YYYY";
                publishDateEnter.ForeColor = Color.DimGray;
                publishDateEnter.Tag = "YYYY, Mmmm DD or YYYY";
                publishDateEnter.Enter += new EventHandler(removePlaceholderText);
                publishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;
                titleEnter.Text = "Title";
                titleEnter.ForeColor = Color.DimGray;
                titleEnter.Tag = "Title";
                titleEnter.Enter += new EventHandler(removePlaceholderText);
                titleEnter.Leave += new EventHandler(addPlaceholderText);

                Label magazineNameLabel = new Label();
                magazineNameLabel.Text = "Magazine Name:";
                sourceInfoPanel.Controls.Add(magazineNameLabel);
                magazineNameLabel.Location = new Point(0, 75);

                TextBox magazineNameEnter = new TextBox();
                magazineNameEnter.Name = "magazineNameEnter";
                sourceInfoPanel.Controls.Add(magazineNameEnter);
                magazineNameEnter.Location = new Point(109, 75);
                magazineNameEnter.Width = 150;
                magazineNameEnter.Text = "Name";
                magazineNameEnter.ForeColor = Color.DimGray;
                magazineNameEnter.Tag = "Name";
                magazineNameEnter.Enter += new EventHandler(removePlaceholderText);
                magazineNameEnter.Leave += new EventHandler(addPlaceholderText);

                Label volumeNumberLabel = new Label();
                volumeNumberLabel.Text = "Volume Number:";
                sourceInfoPanel.Controls.Add(volumeNumberLabel);
                volumeNumberLabel.Location = new Point(0, 100);

                TextBox volumeNumberEnter = new TextBox();
                volumeNumberEnter.Name = "volumeNumberEnter";
                sourceInfoPanel.Controls.Add(volumeNumberEnter);
                volumeNumberEnter.Location = new Point(109, 100);
                volumeNumberEnter.Width = 150;
                volumeNumberEnter.Text = "Volume";
                volumeNumberEnter.ForeColor = Color.DimGray;
                volumeNumberEnter.Tag = "Volume";
                volumeNumberEnter.Enter += new EventHandler(removePlaceholderText);
                volumeNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label issueNumberLabel = new Label();
                issueNumberLabel.Text = "Issue Number:";
                sourceInfoPanel.Controls.Add(issueNumberLabel);
                issueNumberLabel.Location = new Point(0, 125);

                TextBox issueNumberEnter = new TextBox();
                issueNumberEnter.Name = "issueNumberEnter";
                sourceInfoPanel.Controls.Add(issueNumberEnter);
                issueNumberEnter.Location = new Point(109, 125);
                issueNumberEnter.Width = 150;
                issueNumberEnter.Text = "Issue";
                issueNumberEnter.ForeColor = Color.DimGray;
                issueNumberEnter.Tag = "Issue";
                issueNumberEnter.Enter += new EventHandler(removePlaceholderText);
                issueNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 150);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 150);
                pageStartEnter.Width = 150;
                pageStartEnter.Text = "Start Page";
                pageStartEnter.ForeColor = Color.DimGray;
                pageStartEnter.Tag = "Start Page";
                pageStartEnter.Enter += new EventHandler(removePlaceholderText);
                pageStartEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 175);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 175);
                pageEndEnter.Width = 150;
                pageEndEnter.Text = "End Page";
                pageEndEnter.ForeColor = Color.DimGray;
                pageEndEnter.Tag = "End Page";
                pageEndEnter.Enter += new EventHandler(removePlaceholderText);
                pageEndEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (newspaper.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 299);
                }
                sourceInfoGroupBox.Tag = "1,8";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;
                authorFirstEnter.Text = "First";
                authorFirstEnter.ForeColor = Color.DimGray;
                authorFirstEnter.Tag = "First";
                authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
                authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;
                authorMiddleEnter.Text = "Middle";
                authorMiddleEnter.ForeColor = Color.DimGray;
                authorMiddleEnter.Tag = "Middle";
                authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
                authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;
                authorLastEnter.Text = "Last";
                authorLastEnter.ForeColor = Color.DimGray;
                authorLastEnter.Tag = "Last";
                authorLastEnter.Enter += new EventHandler(removePlaceholderText);
                authorLastEnter.Leave += new EventHandler(addPlaceholderText);

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;
                publishDateEnter.Text = "YYYY, Mmmm DD or YYYY";
                publishDateEnter.ForeColor = Color.DimGray;
                publishDateEnter.Tag = "YYYY, Mmmm DD or YYYY";
                publishDateEnter.Enter += new EventHandler(removePlaceholderText);
                publishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;
                titleEnter.Text = "Title";
                titleEnter.ForeColor = Color.DimGray;
                titleEnter.Tag = "Title";
                titleEnter.Enter += new EventHandler(removePlaceholderText);
                titleEnter.Leave += new EventHandler(addPlaceholderText);

                Label newspaperNameLabel = new Label();
                newspaperNameLabel.Text = "Newspaper Name:";
                sourceInfoPanel.Controls.Add(newspaperNameLabel);
                newspaperNameLabel.Location = new Point(0, 75);

                TextBox newspaperNameEnter = new TextBox();
                newspaperNameEnter.Name = "newspaperNameEnter";
                sourceInfoPanel.Controls.Add(newspaperNameEnter);
                newspaperNameEnter.Location = new Point(109, 75);
                newspaperNameEnter.Width = 150;
                newspaperNameEnter.Text = "Name";
                newspaperNameEnter.ForeColor = Color.DimGray;
                newspaperNameEnter.Tag = "Name";
                newspaperNameEnter.Enter += new EventHandler(removePlaceholderText);
                newspaperNameEnter.Leave += new EventHandler(addPlaceholderText);

                Label volumeNumberLabel = new Label();
                volumeNumberLabel.Text = "Volume Number:";
                sourceInfoPanel.Controls.Add(volumeNumberLabel);
                volumeNumberLabel.Location = new Point(0, 100);

                TextBox volumeNumberEnter = new TextBox();
                volumeNumberEnter.Name = "volumeNumberEnter";
                sourceInfoPanel.Controls.Add(volumeNumberEnter);
                volumeNumberEnter.Location = new Point(109, 100);
                volumeNumberEnter.Width = 150;
                volumeNumberEnter.Text = "Volume";
                volumeNumberEnter.ForeColor = Color.DimGray;
                volumeNumberEnter.Tag = "Volume";
                volumeNumberEnter.Enter += new EventHandler(removePlaceholderText);
                volumeNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label issueNumberLabel = new Label();
                issueNumberLabel.Text = "Issue Number:";
                sourceInfoPanel.Controls.Add(issueNumberLabel);
                issueNumberLabel.Location = new Point(0, 125);

                TextBox issueNumberEnter = new TextBox();
                issueNumberEnter.Name = "issueNumberEnter";
                sourceInfoPanel.Controls.Add(issueNumberEnter);
                issueNumberEnter.Location = new Point(109, 125);
                issueNumberEnter.Width = 150;
                issueNumberEnter.Text = "Issue";
                issueNumberEnter.ForeColor = Color.DimGray;
                issueNumberEnter.Tag = "Issue";
                issueNumberEnter.Enter += new EventHandler(removePlaceholderText);
                issueNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 150);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 150);
                pageStartEnter.Width = 150;
                pageStartEnter.Text = "Start Page";
                pageStartEnter.ForeColor = Color.DimGray;
                pageStartEnter.Tag = "Start Page";
                pageStartEnter.Enter += new EventHandler(removePlaceholderText);
                pageStartEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 175);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 175);
                pageEndEnter.Width = 150;
                pageEndEnter.Text = "End Page";
                pageEndEnter.ForeColor = Color.DimGray;
                pageEndEnter.Tag = "End Page";
                pageEndEnter.Enter += new EventHandler(removePlaceholderText);
                pageEndEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (journal.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 299);
                }
                sourceInfoGroupBox.Tag = "1,8";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;
                authorFirstEnter.Text = "First";
                authorFirstEnter.ForeColor = Color.DimGray;
                authorFirstEnter.Tag = "First";
                authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
                authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;
                authorMiddleEnter.Text = "Middle";
                authorMiddleEnter.ForeColor = Color.DimGray;
                authorMiddleEnter.Tag = "Middle";
                authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
                authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;
                authorLastEnter.Text = "Last";
                authorLastEnter.ForeColor = Color.DimGray;
                authorLastEnter.Tag = "Last";
                authorLastEnter.Enter += new EventHandler(removePlaceholderText);
                authorLastEnter.Leave += new EventHandler(addPlaceholderText);

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;
                publishDateEnter.Text = "YYYY";
                publishDateEnter.ForeColor = Color.DimGray;
                publishDateEnter.Tag = "YYYY";
                publishDateEnter.Enter += new EventHandler(removePlaceholderText);
                publishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;
                titleEnter.Text = "Title";
                titleEnter.ForeColor = Color.DimGray;
                titleEnter.Tag = "Title";
                titleEnter.Enter += new EventHandler(removePlaceholderText);
                titleEnter.Leave += new EventHandler(addPlaceholderText);

                Label journalNameLabel = new Label();
                journalNameLabel.Text = "Journal Name:";
                sourceInfoPanel.Controls.Add(journalNameLabel);
                journalNameLabel.Location = new Point(0, 75);

                TextBox journalNameEnter = new TextBox();
                journalNameEnter.Name = "journalNameEnter";
                sourceInfoPanel.Controls.Add(journalNameEnter);
                journalNameEnter.Location = new Point(109, 75);
                journalNameEnter.Width = 150;
                journalNameEnter.Text = "Name";
                journalNameEnter.ForeColor = Color.DimGray;
                journalNameEnter.Tag = "Name";
                journalNameEnter.Enter += new EventHandler(removePlaceholderText);
                journalNameEnter.Leave += new EventHandler(addPlaceholderText);

                Label volumeNumberLabel = new Label();
                volumeNumberLabel.Text = "Volume Number:";
                sourceInfoPanel.Controls.Add(volumeNumberLabel);
                volumeNumberLabel.Location = new Point(0, 100);

                TextBox volumeNumberEnter = new TextBox();
                volumeNumberEnter.Name = "volumeNumberEnter";
                sourceInfoPanel.Controls.Add(volumeNumberEnter);
                volumeNumberEnter.Location = new Point(109, 100);
                volumeNumberEnter.Width = 150;
                volumeNumberEnter.Text = "Volume";
                volumeNumberEnter.ForeColor = Color.DimGray;
                volumeNumberEnter.Tag = "Volume";
                volumeNumberEnter.Enter += new EventHandler(removePlaceholderText);
                volumeNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label issueNumberLabel = new Label();
                issueNumberLabel.Text = "Issue Number:";
                sourceInfoPanel.Controls.Add(issueNumberLabel);
                issueNumberLabel.Location = new Point(0, 125);

                TextBox issueNumberEnter = new TextBox();
                issueNumberEnter.Name = "issueNumberEnter";
                sourceInfoPanel.Controls.Add(issueNumberEnter);
                issueNumberEnter.Location = new Point(109, 125);
                issueNumberEnter.Width = 150;
                issueNumberEnter.Text = "Issue";
                issueNumberEnter.ForeColor = Color.DimGray;
                issueNumberEnter.Tag = "Issue";
                issueNumberEnter.Enter += new EventHandler(removePlaceholderText);
                issueNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 150);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 150);
                pageStartEnter.Width = 150;
                pageStartEnter.Text = "Start Page";
                pageStartEnter.ForeColor = Color.DimGray;
                pageStartEnter.Tag = "Start Page";
                pageStartEnter.Enter += new EventHandler(removePlaceholderText);
                pageStartEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 175);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 175);
                pageEndEnter.Width = 150;
                pageEndEnter.Text = "End Page";
                pageEndEnter.ForeColor = Color.DimGray;
                pageEndEnter.Tag = "End Page";
                pageEndEnter.Enter += new EventHandler(removePlaceholderText);
                pageEndEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (onlineJournal.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(10) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(10);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(10) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(10) + 299);
                }
                sourceInfoGroupBox.Tag = "1,10";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;
                authorFirstEnter.Text = "First";
                authorFirstEnter.ForeColor = Color.DimGray;
                authorFirstEnter.Tag = "First";
                authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
                authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;
                authorMiddleEnter.Text = "Middle";
                authorMiddleEnter.ForeColor = Color.DimGray;
                authorMiddleEnter.Tag = "Middle";
                authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
                authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;
                authorLastEnter.Text = "Last";
                authorLastEnter.ForeColor = Color.DimGray;
                authorLastEnter.Tag = "Last";
                authorLastEnter.Enter += new EventHandler(removePlaceholderText);
                authorLastEnter.Leave += new EventHandler(addPlaceholderText);

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;
                publishDateEnter.Text = "YYYY";
                publishDateEnter.ForeColor = Color.DimGray;
                publishDateEnter.Tag = "YYYY";
                publishDateEnter.Enter += new EventHandler(removePlaceholderText);
                publishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;
                titleEnter.Text = "Title";
                titleEnter.ForeColor = Color.DimGray;
                titleEnter.Tag = "Title";
                titleEnter.Enter += new EventHandler(removePlaceholderText);
                titleEnter.Leave += new EventHandler(addPlaceholderText);

                Label journalNameLabel = new Label();
                journalNameLabel.Text = "Journal Name:";
                sourceInfoPanel.Controls.Add(journalNameLabel);
                journalNameLabel.Location = new Point(0, 75);

                TextBox journalNameEnter = new TextBox();
                journalNameEnter.Name = "journalNameEnter";
                sourceInfoPanel.Controls.Add(journalNameEnter);
                journalNameEnter.Location = new Point(109, 75);
                journalNameEnter.Width = 150;
                journalNameEnter.Text = "Name";
                journalNameEnter.ForeColor = Color.DimGray;
                journalNameEnter.Tag = "Name";
                journalNameEnter.Enter += new EventHandler(removePlaceholderText);
                journalNameEnter.Leave += new EventHandler(addPlaceholderText);

                Label volumeNumberLabel = new Label();
                volumeNumberLabel.Text = "Volume Number:";
                sourceInfoPanel.Controls.Add(volumeNumberLabel);
                volumeNumberLabel.Location = new Point(0, 100);

                TextBox volumeNumberEnter = new TextBox();
                volumeNumberEnter.Name = "volumeNumberEnter";
                sourceInfoPanel.Controls.Add(volumeNumberEnter);
                volumeNumberEnter.Location = new Point(109, 100);
                volumeNumberEnter.Width = 150;
                volumeNumberEnter.Text = "Volume";
                volumeNumberEnter.ForeColor = Color.DimGray;
                volumeNumberEnter.Tag = "Volume";
                volumeNumberEnter.Enter += new EventHandler(removePlaceholderText);
                volumeNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label issueNumberLabel = new Label();
                issueNumberLabel.Text = "Issue Number:";
                sourceInfoPanel.Controls.Add(issueNumberLabel);
                issueNumberLabel.Location = new Point(0, 125);

                TextBox issueNumberEnter = new TextBox();
                issueNumberEnter.Name = "issueNumberEnter";
                sourceInfoPanel.Controls.Add(issueNumberEnter);
                issueNumberEnter.Location = new Point(109, 125);
                issueNumberEnter.Width = 150;
                issueNumberEnter.Text = "Issue";
                issueNumberEnter.ForeColor = Color.DimGray;
                issueNumberEnter.Tag = "Issue";
                issueNumberEnter.Enter += new EventHandler(removePlaceholderText);
                issueNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 150);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 150);
                pageStartEnter.Width = 150;
                pageStartEnter.Text = "Start Page";
                pageStartEnter.ForeColor = Color.DimGray;
                pageStartEnter.Tag = "Start Page";
                pageStartEnter.Enter += new EventHandler(removePlaceholderText);
                pageStartEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 175);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 175);
                pageEndEnter.Width = 150;
                pageEndEnter.Text = "End Page";
                pageEndEnter.ForeColor = Color.DimGray;
                pageEndEnter.Tag = "End Page";
                pageEndEnter.Enter += new EventHandler(removePlaceholderText);
                pageEndEnter.Leave += new EventHandler(addPlaceholderText);

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 200);

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 200);
                retrievedFromEnter.Width = 150;
                retrievedFromEnter.Text = "ex. www.journals.com/journal";
                retrievedFromEnter.ForeColor = Color.DimGray;
                retrievedFromEnter.Tag = "ex. www.journals.com/journal";
                retrievedFromEnter.Enter += new EventHandler(removePlaceholderText);
                retrievedFromEnter.Leave += new EventHandler(addPlaceholderText);

                Label doiLabel = new Label();
                doiLabel.Text = "DOI:";
                sourceInfoPanel.Controls.Add(doiLabel);
                doiLabel.Location = new Point(0, 225);

                TextBox doiEnter = new TextBox();
                doiEnter.Name = "doiEnter";
                sourceInfoPanel.Controls.Add(doiEnter);
                doiEnter.Location = new Point(109, 225);
                doiEnter.Width = 150;
                doiEnter.Text = "ex. 10.1108/03090560710821161 or http://dx.doi.org/10.1016/j.appdev.2012.05.005";
                doiEnter.ForeColor = Color.DimGray;
                doiEnter.Tag = "ex. 10.1108/03090560710821161 or http://dx.doi.org/10.1016/j.appdev.2012.05.005";
                doiEnter.Enter += new EventHandler(removePlaceholderText);
                doiEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (onlinePeriodical.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(10) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(10);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(10) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(10) + 299);
                }
                sourceInfoGroupBox.Tag = "1,10";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;
                authorFirstEnter.Text = "First";
                authorFirstEnter.ForeColor = Color.DimGray;
                authorFirstEnter.Tag = "First";
                authorFirstEnter.Enter += new EventHandler(removePlaceholderText);
                authorFirstEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;
                authorMiddleEnter.Text = "Middle";
                authorMiddleEnter.ForeColor = Color.DimGray;
                authorMiddleEnter.Tag = "Middle";
                authorMiddleEnter.Enter += new EventHandler(removePlaceholderText);
                authorMiddleEnter.Leave += new EventHandler(addPlaceholderText);

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;
                authorLastEnter.Text = "Last";
                authorLastEnter.ForeColor = Color.DimGray;
                authorLastEnter.Tag = "Last";
                authorLastEnter.Enter += new EventHandler(removePlaceholderText);
                authorLastEnter.Leave += new EventHandler(addPlaceholderText);

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;
                publishDateEnter.Text = "YYYY";
                publishDateEnter.ForeColor = Color.DimGray;
                publishDateEnter.Tag = "YYYY";
                publishDateEnter.Enter += new EventHandler(removePlaceholderText);
                publishDateEnter.Leave += new EventHandler(addPlaceholderText);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;
                titleEnter.Text = "Title";
                titleEnter.ForeColor = Color.DimGray;
                titleEnter.Tag = "Title";
                titleEnter.Enter += new EventHandler(removePlaceholderText);
                titleEnter.Leave += new EventHandler(addPlaceholderText);

                Label periodicalNameLabel = new Label();
                periodicalNameLabel.Text = "Periodical Name:";
                sourceInfoPanel.Controls.Add(periodicalNameLabel);
                periodicalNameLabel.Location = new Point(0, 75);

                TextBox periodicalNameEnter = new TextBox();
                periodicalNameEnter.Name = "periodicalNameEnter";
                sourceInfoPanel.Controls.Add(periodicalNameEnter);
                periodicalNameEnter.Location = new Point(109, 75);
                periodicalNameEnter.Width = 150;
                periodicalNameEnter.Text = "Name";
                periodicalNameEnter.ForeColor = Color.DimGray;
                periodicalNameEnter.Tag = "Name";
                periodicalNameEnter.Enter += new EventHandler(removePlaceholderText);
                periodicalNameEnter.Leave += new EventHandler(addPlaceholderText);

                Label volumeNumberLabel = new Label();
                volumeNumberLabel.Text = "Volume Number:";
                sourceInfoPanel.Controls.Add(volumeNumberLabel);
                volumeNumberLabel.Location = new Point(0, 100);

                TextBox volumeNumberEnter = new TextBox();
                volumeNumberEnter.Name = "volumeNumberEnter";
                sourceInfoPanel.Controls.Add(volumeNumberEnter);
                volumeNumberEnter.Location = new Point(109, 100);
                volumeNumberEnter.Width = 150;
                volumeNumberEnter.Text = "Volume";
                volumeNumberEnter.ForeColor = Color.DimGray;
                volumeNumberEnter.Tag = "Volume";
                volumeNumberEnter.Enter += new EventHandler(removePlaceholderText);
                volumeNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label issueNumberLabel = new Label();
                issueNumberLabel.Text = "Issue Number:";
                sourceInfoPanel.Controls.Add(issueNumberLabel);
                issueNumberLabel.Location = new Point(0, 125);

                TextBox issueNumberEnter = new TextBox();
                issueNumberEnter.Name = "issueNumberEnter";
                sourceInfoPanel.Controls.Add(issueNumberEnter);
                issueNumberEnter.Location = new Point(109, 125);
                issueNumberEnter.Width = 150;
                issueNumberEnter.Text = "Issue";
                issueNumberEnter.ForeColor = Color.DimGray;
                issueNumberEnter.Tag = "Issue";
                issueNumberEnter.Enter += new EventHandler(removePlaceholderText);
                issueNumberEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 150);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 150);
                pageStartEnter.Width = 150;
                pageStartEnter.Text = "Start Page";
                pageStartEnter.ForeColor = Color.DimGray;
                pageStartEnter.Tag = "Start Page";
                pageStartEnter.Enter += new EventHandler(removePlaceholderText);
                pageStartEnter.Leave += new EventHandler(addPlaceholderText);

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 175);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 175);
                pageEndEnter.Width = 150;
                pageEndEnter.Text = "End Page";
                pageEndEnter.ForeColor = Color.DimGray;
                pageEndEnter.Tag = "End Page";
                pageEndEnter.Enter += new EventHandler(removePlaceholderText);
                pageEndEnter.Leave += new EventHandler(addPlaceholderText);

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 200);

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 200);
                retrievedFromEnter.Width = 150;
                retrievedFromEnter.Text = "ex. www.journals.com/journal";
                retrievedFromEnter.ForeColor = Color.DimGray;
                retrievedFromEnter.Tag = "ex. www.journals.com/journal";
                retrievedFromEnter.Enter += new EventHandler(removePlaceholderText);
                retrievedFromEnter.Leave += new EventHandler(addPlaceholderText);

                Label doiLabel = new Label();
                doiLabel.Text = "DOI:";
                sourceInfoPanel.Controls.Add(doiLabel);
                doiLabel.Location = new Point(0, 225);

                TextBox doiEnter = new TextBox();
                doiEnter.Name = "doiEnter";
                sourceInfoPanel.Controls.Add(doiEnter);
                doiEnter.Location = new Point(109, 225);
                doiEnter.Width = 150;
                doiEnter.Text = "ex. 10.1108/03090560710821161 or http://dx.doi.org/10.1016/j.appdev.2012.05.005";
                doiEnter.ForeColor = Color.DimGray;
                doiEnter.Tag = "ex. 10.1108/03090560710821161 or http://dx.doi.org/10.1016/j.appdev.2012.05.005";
                doiEnter.Enter += new EventHandler(removePlaceholderText);
                doiEnter.Leave += new EventHandler(addPlaceholderText);
            }
            else if (onlineNewspaper.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }
                sourceInfoGroupBox.Tag = "1,4";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label newspaperNameLabel = new Label();
                newspaperNameLabel.Text = "Newspaper Name:";
                sourceInfoPanel.Controls.Add(newspaperNameLabel);
                newspaperNameLabel.Location = new Point(0, 75);

                TextBox newspaperNameEnter = new TextBox();
                newspaperNameEnter.Name = "newspaperNameEnter";
                sourceInfoPanel.Controls.Add(newspaperNameEnter);
                newspaperNameEnter.Location = new Point(109, 75);
                newspaperNameEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 100);

                TextBox retrieveFromEnter = new TextBox();
                retrieveFromEnter.Name = "retrieveFromEnter";
                sourceInfoPanel.Controls.Add(retrieveFromEnter);
                retrieveFromEnter.Location = new Point(109, 100);
                retrieveFromEnter.Width = 150;
            }
            else if (electronicBook.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 299);
                }
                sourceInfoGroupBox.Tag = "1,4";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Book Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;
                
                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 75);

                TextBox retrieveFromEnter = new TextBox();
                retrieveFromEnter.Name = "retrieveFromEnter";
                sourceInfoPanel.Controls.Add(retrieveFromEnter);
                retrieveFromEnter.Location = new Point(109, 75);
                retrieveFromEnter.Width = 150;
            }
            else if (kindle.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }
                sourceInfoGroupBox.Tag = "1,5";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Book Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label doiLabel = new Label();
                doiLabel.Text = "DOI:";
                sourceInfoPanel.Controls.Add(doiLabel);
                doiLabel.Location = new Point(0, 75);

                TextBox doiEnter = new TextBox();
                doiEnter.Name = "doiEnter";
                sourceInfoPanel.Controls.Add(doiEnter);
                doiEnter.Location = new Point(109, 75);
                doiEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 100);

                TextBox retrieveFromEnter = new TextBox();
                retrieveFromEnter.Name = "retrieveFromEnter";
                sourceInfoPanel.Controls.Add(retrieveFromEnter);
                retrieveFromEnter.Location = new Point(109, 100);
                retrieveFromEnter.Width = 150;
            }
            else if (onlineBibliography.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 299);
                }
                sourceInfoGroupBox.Tag = "1,4";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Book Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 75);

                TextBox retrieveFromEnter = new TextBox();
                retrieveFromEnter.Name = "retrieveFromEnter";
                sourceInfoPanel.Controls.Add(retrieveFromEnter);
                retrieveFromEnter.Location = new Point(109, 75);
                retrieveFromEnter.Width = 150;
            }
            else if (onlineInterview.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }
                sourceInfoGroupBox.Tag = "1,5,1";

                Label interviewerLabel = new Label();
                interviewerLabel.Text = "Interviewer:";
                sourceInfoPanel.Controls.Add(interviewerLabel);
                interviewerLabel.Location = new Point(0, 0);

                TextBox interviewerFirstEnter = new TextBox();
                interviewerFirstEnter.Name = "interviewerFirstEnter1";
                sourceInfoPanel.Controls.Add(interviewerFirstEnter);
                interviewerFirstEnter.Location = new Point(109, 0);
                interviewerFirstEnter.Width = 100;

                TextBox interviewerMiddleEnter = new TextBox();
                interviewerMiddleEnter.Name = "interviewerMiddleEnter1";
                sourceInfoPanel.Controls.Add(interviewerMiddleEnter);
                interviewerMiddleEnter.Location = new Point(224, 0);
                interviewerMiddleEnter.Width = 100;

                TextBox interviewerLastEnter = new TextBox();
                interviewerLastEnter.Name = "interviewerLastEnter1";
                sourceInfoPanel.Controls.Add(interviewerLastEnter);
                interviewerLastEnter.Location = new Point(339, 0);
                interviewerLastEnter.Width = 100;

                Button interviewerAdder = new Button();
                interviewerAdder.Name = "interviewerAdderButton";
                interviewerAdder.Text = "Add an Interviewer";
                interviewerAdder.Width = 150;
                sourceInfoPanel.Controls.Add(interviewerAdder);
                interviewerAdder.Location = new Point(459, 0);
                interviewerAdder.Click += new EventHandler(interviewerAdderButton_Click);

                Label intervieweeLabel = new Label();
                intervieweeLabel.Text = "Interviewee:";
                sourceInfoPanel.Controls.Add(intervieweeLabel);
                intervieweeLabel.Location = new Point(0, 25);

                TextBox intervieweeFirstEnter = new TextBox();
                intervieweeFirstEnter.Name = "intervieweeFirstEnter1";
                sourceInfoPanel.Controls.Add(intervieweeFirstEnter);
                intervieweeFirstEnter.Location = new Point(109, 25);
                intervieweeFirstEnter.Width = 100;

                TextBox intervieweeMiddleEnter = new TextBox();
                intervieweeMiddleEnter.Name = "intervieweeMiddleEnter1";
                sourceInfoPanel.Controls.Add(intervieweeMiddleEnter);
                intervieweeMiddleEnter.Location = new Point(224, 25);
                intervieweeMiddleEnter.Width = 100;

                TextBox intervieweeLastEnter = new TextBox();
                intervieweeLastEnter.Name = "intervieweeLastEnter1";
                sourceInfoPanel.Controls.Add(intervieweeLastEnter);
                intervieweeLastEnter.Location = new Point(339, 25);
                intervieweeLastEnter.Width = 100;

                Button intervieweeAdder = new Button();
                intervieweeAdder.Name = "intervieweeAdderButton";
                intervieweeAdder.Text = "Add an Interviewee";
                intervieweeAdder.Width = 150;
                sourceInfoPanel.Controls.Add(intervieweeAdder);
                intervieweeAdder.Location = new Point(459, 25);
                intervieweeAdder.Click += new EventHandler(intervieweeAdderButton_Click);

                Label interviewDateLabel = new Label();
                interviewDateLabel.Text = "Date of Interview:";
                sourceInfoPanel.Controls.Add(interviewDateLabel);
                interviewDateLabel.Location = new Point(0, 50);

                TextBox interviewDateEnter = new TextBox();
                interviewDateEnter.Name = "interviewDateEnter";
                sourceInfoPanel.Controls.Add(interviewDateEnter);
                interviewDateEnter.Location = new Point(109, 50);
                interviewDateEnter.Width = 150;

                Label interviewTitleLabel = new Label();
                interviewTitleLabel.Text = "Interview Title:";
                sourceInfoPanel.Controls.Add(interviewTitleLabel);
                interviewTitleLabel.Location = new Point(0, 75);

                TextBox interviewTitleEnter = new TextBox();
                interviewTitleEnter.Name = "interviewTitleEnter";
                sourceInfoPanel.Controls.Add(interviewTitleEnter);
                interviewTitleEnter.Location = new Point(109, 75);
                interviewTitleEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 100);

                TextBox retrieveFromEnter = new TextBox();
                retrieveFromEnter.Name = "retrieveFromEnter";
                sourceInfoPanel.Controls.Add(retrieveFromEnter);
                retrieveFromEnter.Location = new Point(109, 100);
                retrieveFromEnter.Width = 150;
            }
            else if (onlineEncyclopedia.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 299);
                }
                sourceInfoGroupBox.Tag = "1,4";

                Label sectionNameLabel = new Label();
                sectionNameLabel.Text = "Section or Word Referenced:";
                sourceInfoPanel.Controls.Add(sectionNameLabel);
                sectionNameLabel.Location = new Point(0, 0);
                sectionNameLabel.Width = 180;

                TextBox sectionNameEnter = new TextBox();
                sectionNameEnter.Name = "sectionNameEnter";
                sourceInfoPanel.Controls.Add(sectionNameEnter);
                sectionNameEnter.Location = new Point(180, 0);
                sectionNameEnter.Width = 150;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Publication Date:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 25);
                publicationDateLabel.Width = 180;

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(180, 25);
                publicationDateEnter.Width = 150;

                Label nameLabel = new Label();
                nameLabel.Text = "Name of Encyclopedia/Dictionary:";
                sourceInfoPanel.Controls.Add(nameLabel);
                nameLabel.Location = new Point(0, 50);

                TextBox nameEnter = new TextBox();
                nameEnter.Name = "nameEnter";
                sourceInfoPanel.Controls.Add(nameEnter);
                nameEnter.Location = new Point(180, 50);
                nameEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 75);

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(180, 75);
                retrievedFromEnter.Width = 150;
            }
            else if (forumDiscussion.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }
                sourceInfoGroupBox.Tag = "1,5,1";

                Label posterLabel = new Label();
                posterLabel.Text = "Person Posting:";
                sourceInfoPanel.Controls.Add(posterLabel);
                posterLabel.Location = new Point(0, 0);

                TextBox posterFirstEnter = new TextBox();
                posterFirstEnter.Name = "posterFirstEnter";
                sourceInfoPanel.Controls.Add(posterFirstEnter);
                posterFirstEnter.Location = new Point(109, 0);
                posterFirstEnter.Width = 100;

                TextBox posterMiddleEnter = new TextBox();
                posterMiddleEnter.Name = "posterMiddleEnter";
                sourceInfoPanel.Controls.Add(posterMiddleEnter);
                posterMiddleEnter.Location = new Point(224, 0);
                posterMiddleEnter.Width = 100;

                TextBox posterLastEnter = new TextBox();
                posterLastEnter.Name = "posterLastEnter";
                sourceInfoPanel.Controls.Add(posterLastEnter);
                posterLastEnter.Location = new Point(339, 0);
                posterLastEnter.Width = 100;

                Label postDateLabel = new Label();
                postDateLabel.Text = "Date Posted:";
                sourceInfoPanel.Controls.Add(postDateLabel);
                postDateLabel.Location = new Point(0, 25);

                TextBox postDateEnter = new TextBox();
                postDateEnter.Name = "postDateEnter";
                sourceInfoPanel.Controls.Add(postDateEnter);
                postDateEnter.Location = new Point(109, 25);
                postDateEnter.Width = 150;

                Label messageTitleLabel = new Label();
                messageTitleLabel.Text = "Message Title:";
                sourceInfoPanel.Controls.Add(messageTitleLabel);
                messageTitleLabel.Location = new Point(0, 50);

                TextBox messageTitleEnter = new TextBox();
                messageTitleEnter.Name = "messageTitleEnter";
                sourceInfoPanel.Controls.Add(messageTitleEnter);
                messageTitleEnter.Location = new Point(109, 50);
                messageTitleEnter.Width = 150;

                Label messageNumberLabel = new Label();
                messageNumberLabel.Text = "Message Number:";
                sourceInfoPanel.Controls.Add(messageNumberLabel);
                messageNumberLabel.Location = new Point(0, 75);

                TextBox messageNumberEnter = new TextBox();
                messageNumberEnter.Name = "messageNumberEnter";
                sourceInfoPanel.Controls.Add(messageNumberEnter);
                messageNumberEnter.Location = new Point(109, 75);
                messageNumberEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 100);

                TextBox retrieveFromEnter = new TextBox();
                retrieveFromEnter.Name = "retrieveFromEnter";
                sourceInfoPanel.Controls.Add(retrieveFromEnter);
                retrieveFromEnter.Location = new Point(109, 100);
                retrieveFromEnter.Width = 150;
            }
            else if (bookReview.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(10) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(10);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(10) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(10) + 299);
                }
                sourceInfoGroupBox.Tag = "1,9";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 25);

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 25);
                publicationDateEnter.Width = 150;

                Label reviewTitleLabel = new Label();
                reviewTitleLabel.Text = "Review Title:";
                sourceInfoPanel.Controls.Add(reviewTitleLabel);
                reviewTitleLabel.Location = new Point(0, 50);
                reviewTitleLabel.Width = 109;

                TextBox reviewTitleEnter = new TextBox();
                reviewTitleEnter.Name = "reviewTitleEnter";
                sourceInfoPanel.Controls.Add(reviewTitleEnter);
                reviewTitleEnter.Location = new Point(109, 50);
                reviewTitleEnter.Width = 150;

                Label reviewedLabel = new Label();
                reviewedLabel.Text = "Title Being Reviewed:";
                sourceInfoPanel.Controls.Add(reviewedLabel);
                reviewedLabel.Location = new Point(0, 75);
                reviewedLabel.Width = 109;

                TextBox reviewedEnter = new TextBox();
                reviewedEnter.Name = "reviewedEnter";
                sourceInfoPanel.Controls.Add(reviewedEnter);
                reviewedEnter.Location = new Point(109, 75);
                reviewedEnter.Width = 150;

                Label sourceReviewingLabel = new Label();
                sourceReviewingLabel.Text = "Source of Review:";
                sourceInfoPanel.Controls.Add(sourceReviewingLabel);
                sourceReviewingLabel.Location = new Point(0, 100);
                sourceReviewingLabel.Width = 109;

                TextBox sourceReviewingEnter = new TextBox();
                sourceReviewingEnter.Name = "sourceReviewingEnter";
                sourceInfoPanel.Controls.Add(sourceReviewingEnter);
                sourceReviewingEnter.Location = new Point(109, 100);
                sourceReviewingEnter.Width = 150;

                Label volumeLabel = new Label();
                volumeLabel.Text = "Volume:";
                sourceInfoPanel.Controls.Add(volumeLabel);
                volumeLabel.Location = new Point(0, 125);

                TextBox volumeEnter = new TextBox();
                volumeEnter.Name = "volumeEnter";
                sourceInfoPanel.Controls.Add(volumeEnter);
                volumeEnter.Location = new Point(109, 125);
                volumeEnter.Width = 150;

                Label issueLabel = new Label();
                issueLabel.Text = "Issue:";
                sourceInfoPanel.Controls.Add(issueLabel);
                issueLabel.Location = new Point(0, 150);

                TextBox issueEnter = new TextBox();
                issueEnter.Name = "issueEnter";
                sourceInfoPanel.Controls.Add(issueEnter);
                issueEnter.Location = new Point(109, 150);
                issueEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 175);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 175);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 200);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 200);
                pageEndEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 225);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 225);
                retrievedFromEnter.Width = 150;
            }
            else if (blog.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }
                sourceInfoGroupBox.Tag = "1,5";

                Label authorLabel = new Label();
                authorLabel.Text = "Person Posting:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;

                Label postDateLabel = new Label();
                postDateLabel.Text = "Date Posted:";
                sourceInfoPanel.Controls.Add(postDateLabel);
                postDateLabel.Location = new Point(0, 25);

                TextBox postDateEnter = new TextBox();
                postDateEnter.Name = "postDateEnter";
                sourceInfoPanel.Controls.Add(postDateEnter);
                postDateEnter.Location = new Point(109, 25);
                postDateEnter.Width = 150;

                Label messageTitleLabel = new Label();
                messageTitleLabel.Text = "Post Title:";
                sourceInfoPanel.Controls.Add(messageTitleLabel);
                messageTitleLabel.Location = new Point(0, 50);
                messageTitleLabel.Width = 109;

                TextBox messageTitleEnter = new TextBox();
                messageTitleEnter.Name = "messageTitleEnter";
                sourceInfoPanel.Controls.Add(messageTitleEnter);
                messageTitleEnter.Location = new Point(109, 50);
                messageTitleEnter.Width = 150;

                Label typeLabel = new Label();
                typeLabel.Text = "Source of Reference:";
                sourceInfoPanel.Controls.Add(typeLabel);
                typeLabel.Location = new Point(0, 75);
                typeLabel.Width = 109;

                TextBox typeEnter = new TextBox();
                typeEnter.Name = "typeEnter";
                sourceInfoPanel.Controls.Add(typeEnter);
                typeEnter.Location = new Point(109, 75);
                typeEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 100);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 100);
                retrievedFromEnter.Width = 150;
            }
            else if (wiki.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 299);
                }
                sourceInfoGroupBox.Tag = "1,4";

                Label titleLabel = new Label();
                titleLabel.Text = "Wiki Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 0);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 0);
                titleEnter.Width = 150;

                Label postDateLabel = new Label();
                postDateLabel.Text = "Date Posted:";
                sourceInfoPanel.Controls.Add(postDateLabel);
                postDateLabel.Location = new Point(0, 25);

                TextBox postDateEnter = new TextBox();
                postDateEnter.Name = "postDateEnter";
                sourceInfoPanel.Controls.Add(postDateEnter);
                postDateEnter.Location = new Point(109, 25);
                postDateEnter.Width = 150;

                Label retrievedDateLabel = new Label();
                retrievedDateLabel.Text = "Date Retrieved:";
                sourceInfoPanel.Controls.Add(retrievedDateLabel);
                retrievedDateLabel.Location = new Point(0, 50);

                TextBox retrievedDateEnter = new TextBox();
                retrievedDateEnter.Name = "retrievedDateEnter";
                sourceInfoPanel.Controls.Add(retrievedDateEnter);
                retrievedDateEnter.Location = new Point(109, 50);
                retrievedDateEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 75);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 75);
                retrievedFromEnter.Width = 150;
            }
            else if (webDoc.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 299);
                }
                sourceInfoGroupBox.Tag = "1,4";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 25);

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 25);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 50);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 75);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 75);
                retrievedFromEnter.Width = 150;
            }
            else if (onlineDissertation.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 299);
                }
                sourceInfoGroupBox.Tag = "1,4";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 25);

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 25);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 50);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 75);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 75);
                retrievedFromEnter.Width = 150;
            }
            else if (publishedDissertation.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }
                sourceInfoGroupBox.Tag = "1,5";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(180, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(295, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(410, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(530, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 25);

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(180, 25);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 50);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(180, 50);
                titleEnter.Width = 150;

                Label sourceLabel = new Label();
                sourceLabel.Text = "Source:";
                sourceInfoPanel.Controls.Add(sourceLabel);
                sourceLabel.Location = new Point(0, 75);
                sourceLabel.Width = 109;

                TextBox sourceEnter = new TextBox();
                sourceEnter.Name = "sourceEnter";
                sourceInfoPanel.Controls.Add(sourceEnter);
                sourceEnter.Location = new Point(180, 75);
                sourceEnter.Width = 150;

                Label accessionLabel = new Label();
                accessionLabel.Text = "Accession/Order Number:";
                sourceInfoPanel.Controls.Add(accessionLabel);
                accessionLabel.Location = new Point(0, 100);
                accessionLabel.Width = 180;

                TextBox accessionEnter = new TextBox();
                accessionEnter.Name = "accessionEnter";
                sourceInfoPanel.Controls.Add(accessionEnter);
                accessionEnter.Location = new Point(180, 100);
                accessionEnter.Width = 150;
            }
            else if (unpublishedDissertation.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }
                sourceInfoGroupBox.Tag = "1,5";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(109, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(224, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(339, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(459, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 25);

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 25);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 50);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label institutionNameLabel = new Label();
                institutionNameLabel.Text = "Institution Name:";
                sourceInfoPanel.Controls.Add(institutionNameLabel);
                institutionNameLabel.Location = new Point(0, 75);
                institutionNameLabel.Width = 109;

                TextBox institutionNameEnter = new TextBox();
                institutionNameEnter.Name = "institutionNameEnter";
                sourceInfoPanel.Controls.Add(institutionNameEnter);
                institutionNameEnter.Location = new Point(109, 75);
                institutionNameEnter.Width = 150;

                Label locationLabel = new Label();
                locationLabel.Text = "Location:";
                sourceInfoPanel.Controls.Add(locationLabel);
                locationLabel.Location = new Point(0, 100);
                locationLabel.Width = 109;

                TextBox locationEnter = new TextBox();
                locationEnter.Name = "locationEnter";
                sourceInfoPanel.Controls.Add(locationEnter);
                locationEnter.Location = new Point(109, 100);
                locationEnter.Width = 150;
            }             
            else if (governmentDocument.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 299);
                }

                Label authorLabel = new Label();
                authorLabel.Text = "Organization:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorEnter = new TextBox();
                authorEnter.Name = "authorEnter";
                sourceInfoPanel.Controls.Add(authorEnter);
                authorEnter.Location = new Point(109, 0);
                authorEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 25);
                publishDateEnter.Width = 150;

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label publicationNumberLabel = new Label();
                publicationNumberLabel.Text = "Publication Number:";
                sourceInfoPanel.Controls.Add(publicationNumberLabel);
                publicationNumberLabel.Location = new Point(0, 75);
                publicationNumberLabel.Width = 109;

                TextBox publicationNumberEnter = new TextBox();
                publicationNumberEnter.Name = "publicationNumberEnter";
                sourceInfoPanel.Controls.Add(publicationNumberEnter);
                publicationNumberEnter.Location = new Point(109, 75);
                publicationNumberEnter.Width = 150;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 100);
                publisherLabel.Width = 109;

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 100);
                publisherEnter.Width = 150;

                Label publishLocationLabel = new Label();
                publishLocationLabel.Text = "Publication Location:";
                sourceInfoPanel.Controls.Add(publishLocationLabel);
                publishLocationLabel.Location = new Point(0, 125);
                publishLocationLabel.Width = 109;

                TextBox publishLocationEnter = new TextBox();
                publishLocationEnter.Name = "publishLocationEnter";
                sourceInfoPanel.Controls.Add(publishLocationEnter);
                publishLocationEnter.Location = new Point(109, 125);
                publishLocationEnter.Width = 150;
            }
            else if (review.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(10) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(10);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(10) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(10) + 299);
                }
                sourceInfoGroupBox.Tag = "1,10,1";

                Label reviewerLabel = new Label();
                reviewerLabel.Text = "Reviewer:";
                sourceInfoPanel.Controls.Add(reviewerLabel);
                reviewerLabel.Location = new Point(0, 0);

                TextBox reviewerFirstEnter = new TextBox();
                reviewerFirstEnter.Name = "reviewerFirstEnter1";
                sourceInfoPanel.Controls.Add(reviewerFirstEnter);
                reviewerFirstEnter.Location = new Point(180, 0);
                reviewerFirstEnter.Width = 100;

                TextBox reviewerMiddleEnter = new TextBox();
                reviewerMiddleEnter.Name = "reviewerMiddleEnter1";
                sourceInfoPanel.Controls.Add(reviewerMiddleEnter);
                reviewerMiddleEnter.Location = new Point(295, 0);
                reviewerMiddleEnter.Width = 100;

                TextBox reviewerLastEnter = new TextBox();
                reviewerLastEnter.Name = "reviewerLastEnter1";
                sourceInfoPanel.Controls.Add(reviewerLastEnter);
                reviewerLastEnter.Location = new Point(410, 0);
                reviewerLastEnter.Width = 100;

                Button reviewerAdder = new Button();
                reviewerAdder.Name = "reviewerAdderButton";
                reviewerAdder.Text = "Add an Reviewer";
                reviewerAdder.Width = 110;
                sourceInfoPanel.Controls.Add(reviewerAdder);
                reviewerAdder.Location = new Point(530, 0);
                reviewerAdder.Click += new EventHandler(reviewerAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Year:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 25);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(180, 25);
                publishDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Review Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(180, 50);
                titleEnter.Width = 150;

                Label reviewedTitleLabel = new Label();
                reviewedTitleLabel.Text = "Title of Work Reviewed:";
                sourceInfoPanel.Controls.Add(reviewedTitleLabel);
                reviewedTitleLabel.Location = new Point(0, 75);
                reviewedTitleLabel.Width = 180;

                TextBox reviewedTitleEnter = new TextBox();
                reviewedTitleEnter.Name = "reviewedTitleEnter";
                sourceInfoPanel.Controls.Add(reviewedTitleEnter);
                reviewedTitleEnter.Location = new Point(180, 75);
                reviewedTitleEnter.Width = 150;

                Label authorLabel = new Label();
                authorLabel.Text = "Original Author Name:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 100);
                authorLabel.Width = 180;

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(180, 100);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(295, 100);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(410, 100);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "originalAuthorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 110;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(530, 100);
                authorAdder.Click += new EventHandler(originalAuthorAdderButton_Click);

                Label sourceLabel = new Label();
                sourceLabel.Text = "Source of Review:";
                sourceInfoPanel.Controls.Add(sourceLabel);
                sourceLabel.Location = new Point(0, 125);
                sourceLabel.Width = 109;

                TextBox sourceEnter = new TextBox();
                sourceEnter.Name = "sourceEnter";
                sourceInfoPanel.Controls.Add(sourceEnter);
                sourceEnter.Location = new Point(180, 125);
                sourceEnter.Width = 150;

                Label volumeLabel = new Label();
                volumeLabel.Text = "Volume:";
                sourceInfoPanel.Controls.Add(volumeLabel);
                volumeLabel.Location = new Point(0, 150);

                TextBox volumeEnter = new TextBox();
                volumeEnter.Name = "volumeEnter";
                sourceInfoPanel.Controls.Add(volumeEnter);
                volumeEnter.Location = new Point(180, 150);
                volumeEnter.Width = 150;

                Label issueLabel = new Label();
                issueLabel.Text = "Issue:";
                sourceInfoPanel.Controls.Add(issueLabel);
                issueLabel.Location = new Point(0, 175);

                TextBox issueEnter = new TextBox();
                issueEnter.Name = "issueEnter";
                sourceInfoPanel.Controls.Add(issueEnter);
                issueEnter.Location = new Point(180, 175);
                issueEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 200);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(180, 200);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 225);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(180, 225);
                pageEndEnter.Width = 150;
            }
            else if (lectureNotesSlides.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }
                sourceInfoGroupBox.Tag = "1,5";

                Label presenterLabel = new Label();
                presenterLabel.Text = "Presenter:";
                sourceInfoPanel.Controls.Add(presenterLabel);
                presenterLabel.Location = new Point(0, 0);

                TextBox presenterFirstEnter = new TextBox();
                presenterFirstEnter.Name = "presenterFirstEnter1";
                sourceInfoPanel.Controls.Add(presenterFirstEnter);
                presenterFirstEnter.Location = new Point(109, 0);
                presenterFirstEnter.Width = 100;

                TextBox presenterMiddleEnter = new TextBox();
                presenterMiddleEnter.Name = "presenterMiddleEnter1";
                sourceInfoPanel.Controls.Add(presenterMiddleEnter);
                presenterMiddleEnter.Location = new Point(224, 0);
                presenterMiddleEnter.Width = 100;

                TextBox presenterLastEnter = new TextBox();
                presenterLastEnter.Name = "presenterLastEnter1";
                sourceInfoPanel.Controls.Add(presenterLastEnter);
                presenterLastEnter.Location = new Point(339, 0);
                presenterLastEnter.Width = 100;

                Button presenterAdder = new Button();
                presenterAdder.Name = "presenterAdderButton";
                presenterAdder.Text = "Add a Presenter";
                presenterAdder.Width = 100;
                sourceInfoPanel.Controls.Add(presenterAdder);
                presenterAdder.Location = new Point(459, 0);
                presenterAdder.Click += new EventHandler(presenterAdderButton_Click);

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Publication Date:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 25);
                publicationDateLabel.Width = 109;

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 25);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Presentation Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 50);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label formatLabel = new Label();
                formatLabel.Text = "File Format:";
                sourceInfoPanel.Controls.Add(formatLabel);
                formatLabel.Location = new Point(0, 75);

                TextBox formatEnter = new TextBox();
                formatEnter.Name = "formatEnter";
                sourceInfoPanel.Controls.Add(formatEnter);
                formatEnter.Location = new Point(109, 75);
                formatEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 100);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 100);
                retrievedFromEnter.Width = 150;
            }
            else if (audioPodcast.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 299);
                }
                sourceInfoGroupBox.Tag = "1,5";

                Label presenterLabel = new Label();
                presenterLabel.Text = "Presenter:";
                sourceInfoPanel.Controls.Add(presenterLabel);
                presenterLabel.Location = new Point(0, 0);

                TextBox presenterFirstEnter = new TextBox();
                presenterFirstEnter.Name = "presenterFirstEnter1";
                sourceInfoPanel.Controls.Add(presenterFirstEnter);
                presenterFirstEnter.Location = new Point(109, 0);
                presenterFirstEnter.Width = 100;

                TextBox presenterMiddleEnter = new TextBox();
                presenterMiddleEnter.Name = "presenterMiddleEnter1";
                sourceInfoPanel.Controls.Add(presenterMiddleEnter);
                presenterMiddleEnter.Location = new Point(224, 0);
                presenterMiddleEnter.Width = 100;

                TextBox presenterLastEnter = new TextBox();
                presenterLastEnter.Name = "presenterLastEnter1";
                sourceInfoPanel.Controls.Add(presenterLastEnter);
                presenterLastEnter.Location = new Point(339, 0);
                presenterLastEnter.Width = 100;

                Button presenterAdder = new Button();
                presenterAdder.Name = "presenterAdderButton";
                presenterAdder.Text = "Add a Presenter";
                presenterAdder.Width = 100;
                sourceInfoPanel.Controls.Add(presenterAdder);
                presenterAdder.Location = new Point(459, 0);
                presenterAdder.Click += new EventHandler(presenterAdderButton_Click);

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Publication Date:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 25);
                publicationDateLabel.Width = 109;

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 25);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 50);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label hostLabel = new Label();
                hostLabel.Text = "Podcast Host:";
                sourceInfoPanel.Controls.Add(hostLabel);
                hostLabel.Location = new Point(0, 75);

                TextBox hostEnter = new TextBox();
                hostEnter.Name = "hostEnter";
                sourceInfoPanel.Controls.Add(hostEnter);
                hostEnter.Location = new Point(109, 75);
                hostEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 100);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 100);
                retrievedFromEnter.Width = 150;
            }
            else if (videoPodcast.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(7) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(7);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(7) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(7) + 299);
                }
                sourceInfoGroupBox.Tag = "1,7";

                Label producerLabel = new Label();
                producerLabel.Text = "Producer:";
                sourceInfoPanel.Controls.Add(producerLabel);
                producerLabel.Location = new Point(0, 0);

                TextBox producerFirstEnter = new TextBox();
                producerFirstEnter.Name = "producerFirstEnter";
                sourceInfoPanel.Controls.Add(producerFirstEnter);
                producerFirstEnter.Location = new Point(109, 0);
                producerFirstEnter.Width = 100;

                TextBox producerMiddleEnter = new TextBox();
                producerMiddleEnter.Name = "producerMiddleEnter";
                sourceInfoPanel.Controls.Add(producerMiddleEnter);
                producerMiddleEnter.Location = new Point(224, 0);
                producerMiddleEnter.Width = 100;

                TextBox producerLastEnter = new TextBox();
                producerLastEnter.Name = "producerLastEnter";
                sourceInfoPanel.Controls.Add(producerLastEnter);
                producerLastEnter.Location = new Point(339, 0);
                producerLastEnter.Width = 100;

                Label directorLabel = new Label();
                directorLabel.Text = "Director:";
                sourceInfoPanel.Controls.Add(directorLabel);
                directorLabel.Location = new Point(0, 25);

                TextBox directorFirstEnter = new TextBox();
                directorFirstEnter.Name = "directorFirstEnter";
                sourceInfoPanel.Controls.Add(directorFirstEnter);
                directorFirstEnter.Location = new Point(109, 25);
                directorFirstEnter.Width = 100;

                TextBox directorMiddleEnter = new TextBox();
                directorMiddleEnter.Name = "directorMiddleEnter";
                sourceInfoPanel.Controls.Add(directorMiddleEnter);
                directorMiddleEnter.Location = new Point(224, 25);
                directorMiddleEnter.Width = 100;

                TextBox directorLastEnter = new TextBox();
                directorLastEnter.Name = "directorLastEnter";
                sourceInfoPanel.Controls.Add(directorLastEnter);
                directorLastEnter.Location = new Point(339, 25);
                directorLastEnter.Width = 100;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Production Date:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 50);
                publicationDateLabel.Width = 109;

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 50);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 75);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 75);
                titleEnter.Width = 150;

                Label espisodeNumberLabel = new Label();
                espisodeNumberLabel.Text = "Episode Number:";
                sourceInfoPanel.Controls.Add(espisodeNumberLabel);
                espisodeNumberLabel.Location = new Point(0, 100);
                espisodeNumberLabel.Width = 109;

                TextBox episodeNumberEnter = new TextBox();
                episodeNumberEnter.Name = "episodeNumberEnter";
                sourceInfoPanel.Controls.Add(episodeNumberEnter);
                episodeNumberEnter.Location = new Point(109, 100);
                episodeNumberEnter.Width = 150;

                Label sourceLabel = new Label();
                sourceLabel.Text = "Podcast Source:";
                sourceInfoPanel.Controls.Add(sourceLabel);
                sourceLabel.Location = new Point(0, 125);

                TextBox sourceEnter = new TextBox();
                sourceEnter.Name = "sourceEnter";
                sourceInfoPanel.Controls.Add(sourceEnter);
                sourceEnter.Location = new Point(109, 125);
                sourceEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 150);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 150);
                retrievedFromEnter.Width = 150;
            }
            else if (motionPicture.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 299);
                }
                sourceInfoGroupBox.Tag = "1,6";

                Label producerLabel = new Label();
                producerLabel.Text = "Producer:";
                sourceInfoPanel.Controls.Add(producerLabel);
                producerLabel.Location = new Point(0, 0);

                TextBox producerFirstEnter = new TextBox();
                producerFirstEnter.Name = "producerFirstEnter";
                sourceInfoPanel.Controls.Add(producerFirstEnter);
                producerFirstEnter.Location = new Point(109, 0);
                producerFirstEnter.Width = 100;

                TextBox producerMiddleEnter = new TextBox();
                producerMiddleEnter.Name = "producerMiddleEnter";
                sourceInfoPanel.Controls.Add(producerMiddleEnter);
                producerMiddleEnter.Location = new Point(224, 0);
                producerMiddleEnter.Width = 100;

                TextBox producerLastEnter = new TextBox();
                producerLastEnter.Name = "producerLastEnter";
                sourceInfoPanel.Controls.Add(producerLastEnter);
                producerLastEnter.Location = new Point(339, 0);
                producerLastEnter.Width = 100;

                Label directorLabel = new Label();
                directorLabel.Text = "Director:";
                sourceInfoPanel.Controls.Add(directorLabel);
                directorLabel.Location = new Point(0, 25);

                TextBox directorFirstEnter = new TextBox();
                directorFirstEnter.Name = "directorFirstEnter";
                sourceInfoPanel.Controls.Add(directorFirstEnter);
                directorFirstEnter.Location = new Point(109, 25);
                directorFirstEnter.Width = 100;

                TextBox directorMiddleEnter = new TextBox();
                directorMiddleEnter.Name = "directorMiddleEnter";
                sourceInfoPanel.Controls.Add(directorMiddleEnter);
                directorMiddleEnter.Location = new Point(224, 25);
                directorMiddleEnter.Width = 100;

                TextBox directorLastEnter = new TextBox();
                directorLastEnter.Name = "directorLastEnter";
                sourceInfoPanel.Controls.Add(directorLastEnter);
                directorLastEnter.Location = new Point(339, 25);
                directorLastEnter.Width = 100;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Production Date:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 50);
                publicationDateLabel.Width = 109;

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 50);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 75);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 75);
                titleEnter.Width = 150;

                Label countryLabel = new Label();
                countryLabel.Text = "Country of Origin:";
                sourceInfoPanel.Controls.Add(countryLabel);
                countryLabel.Location = new Point(0, 100);
                countryLabel.Width = 109;

                TextBox countryEnter = new TextBox();
                countryEnter.Name = "countryEnter";
                sourceInfoPanel.Controls.Add(countryEnter);
                countryEnter.Location = new Point(109, 100);
                countryEnter.Width = 150;

                Label studioLabel = new Label();
                studioLabel.Text = "Studio/Distributor:";
                sourceInfoPanel.Controls.Add(studioLabel);
                studioLabel.Location = new Point(0, 125);
                studioLabel.Width = 109;

                TextBox studioEnter = new TextBox();
                studioEnter.Name = "studioEnter";
                sourceInfoPanel.Controls.Add(studioEnter);
                studioEnter.Location = new Point(109, 125);
                studioEnter.Width = 150;
            }
            else if (tvBroadcast.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 299);
                }
                sourceInfoGroupBox.Tag = "1,6";

                Label producerLabel = new Label();
                producerLabel.Text = "Producer:";
                sourceInfoPanel.Controls.Add(producerLabel);
                producerLabel.Location = new Point(0, 0);

                TextBox producerFirstEnter = new TextBox();
                producerFirstEnter.Name = "producerFirstEnter";
                sourceInfoPanel.Controls.Add(producerFirstEnter);
                producerFirstEnter.Location = new Point(109, 0);
                producerFirstEnter.Width = 100;

                TextBox producerMiddleEnter = new TextBox();
                producerMiddleEnter.Name = "producerMiddleEnter";
                sourceInfoPanel.Controls.Add(producerMiddleEnter);
                producerMiddleEnter.Location = new Point(224, 0);
                producerMiddleEnter.Width = 100;

                TextBox producerLastEnter = new TextBox();
                producerLastEnter.Name = "producerLastEnter";
                sourceInfoPanel.Controls.Add(producerLastEnter);
                producerLastEnter.Location = new Point(339, 0);
                producerLastEnter.Width = 100;

                Label directorLabel = new Label();
                directorLabel.Text = "Director:";
                sourceInfoPanel.Controls.Add(directorLabel);
                directorLabel.Location = new Point(0, 25);

                TextBox directorFirstEnter = new TextBox();
                directorFirstEnter.Name = "directorFirstEnter";
                sourceInfoPanel.Controls.Add(directorFirstEnter);
                directorFirstEnter.Location = new Point(109, 25);
                directorFirstEnter.Width = 100;

                TextBox directorMiddleEnter = new TextBox();
                directorMiddleEnter.Name = "directorMiddleEnter";
                sourceInfoPanel.Controls.Add(directorMiddleEnter);
                directorMiddleEnter.Location = new Point(224, 25);
                directorMiddleEnter.Width = 100;

                TextBox directorLastEnter = new TextBox();
                directorLastEnter.Name = "directorLastEnter";
                sourceInfoPanel.Controls.Add(directorLastEnter);
                directorLastEnter.Location = new Point(339, 25);
                directorLastEnter.Width = 100;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Production Date:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 50);
                publicationDateLabel.Width = 109;

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 50);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 75);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 75);
                titleEnter.Width = 150;

                Label locationLabel = new Label();
                locationLabel.Text = "Location:";
                sourceInfoPanel.Controls.Add(locationLabel);
                locationLabel.Location = new Point(0, 100);
                locationLabel.Width = 109;

                TextBox locationEnter = new TextBox();
                locationEnter.Name = "locationEnter";
                sourceInfoPanel.Controls.Add(locationEnter);
                locationEnter.Location = new Point(109, 100);
                locationEnter.Width = 150;

                Label broadcasterLabel = new Label();
                broadcasterLabel.Text = "Broadcaster:";
                sourceInfoPanel.Controls.Add(broadcasterLabel);
                broadcasterLabel.Location = new Point(0, 125);
                broadcasterLabel.Width = 109;

                TextBox broadcasterEnter = new TextBox();
                broadcasterEnter.Name = "broadcasterEnter";
                sourceInfoPanel.Controls.Add(broadcasterEnter);
                broadcasterEnter.Location = new Point(109, 125);
                broadcasterEnter.Width = 150;
            }
            else if (tvEpisode.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 299);
                }
                sourceInfoGroupBox.Tag = "1,8";

                Label writerLabel = new Label();
                writerLabel.Text = "Writer:";
                sourceInfoPanel.Controls.Add(writerLabel);
                writerLabel.Location = new Point(0, 0);

                TextBox writerFirstEnter = new TextBox();
                writerFirstEnter.Name = "writerFirstEnter";
                sourceInfoPanel.Controls.Add(writerFirstEnter);
                writerFirstEnter.Location = new Point(109, 0);
                writerFirstEnter.Width = 100;

                TextBox writerMiddleEnter = new TextBox();
                writerMiddleEnter.Name = "writerMiddleEnter";
                sourceInfoPanel.Controls.Add(writerMiddleEnter);
                writerMiddleEnter.Location = new Point(224, 0);
                writerMiddleEnter.Width = 100;

                TextBox writerLastEnter = new TextBox();
                writerLastEnter.Name = "writerLastEnter";
                sourceInfoPanel.Controls.Add(writerLastEnter);
                writerLastEnter.Location = new Point(339, 0);
                writerLastEnter.Width = 100;

                Label directorLabel = new Label();
                directorLabel.Text = "Director:";
                sourceInfoPanel.Controls.Add(directorLabel);
                directorLabel.Location = new Point(0, 25);

                TextBox directorFirstEnter = new TextBox();
                directorFirstEnter.Name = "directorFirstEnter";
                sourceInfoPanel.Controls.Add(directorFirstEnter);
                directorFirstEnter.Location = new Point(109, 25);
                directorFirstEnter.Width = 100;

                TextBox directorMiddleEnter = new TextBox();
                directorMiddleEnter.Name = "directorMiddleEnter";
                sourceInfoPanel.Controls.Add(directorMiddleEnter);
                directorMiddleEnter.Location = new Point(224, 25);
                directorMiddleEnter.Width = 100;

                TextBox directorLastEnter = new TextBox();
                directorLastEnter.Name = "directorLastEnter";
                sourceInfoPanel.Controls.Add(directorLastEnter);
                directorLastEnter.Location = new Point(339, 25);
                directorLastEnter.Width = 100;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Production Date:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 50);
                publicationDateLabel.Width = 109;

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 50);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Episode Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 75);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 75);
                titleEnter.Width = 150;

                Label producerLabel = new Label();
                producerLabel.Text = "Producer:";
                sourceInfoPanel.Controls.Add(producerLabel);
                producerLabel.Location = new Point(0, 100);

                TextBox producerFirstEnter = new TextBox();
                producerFirstEnter.Name = "producerFirstEnter";
                sourceInfoPanel.Controls.Add(producerFirstEnter);
                producerFirstEnter.Location = new Point(109, 100);
                producerFirstEnter.Width = 100;

                TextBox producerMiddleEnter = new TextBox();
                producerMiddleEnter.Name = "producerMiddleEnter";
                sourceInfoPanel.Controls.Add(producerMiddleEnter);
                producerMiddleEnter.Location = new Point(224, 100);
                producerMiddleEnter.Width = 100;

                TextBox producerLastEnter = new TextBox();
                producerLastEnter.Name = "producerLastEnter";
                sourceInfoPanel.Controls.Add(producerLastEnter);
                producerLastEnter.Location = new Point(339, 100);
                producerLastEnter.Width = 100;

                Label seriesTitleLabel = new Label();
                seriesTitleLabel.Text = "Series Title:";
                sourceInfoPanel.Controls.Add(seriesTitleLabel);
                seriesTitleLabel.Location = new Point(0, 125);
                seriesTitleLabel.Width = 109;

                TextBox seriesTitleEnter = new TextBox();
                seriesTitleEnter.Name = "seriesTitleEnter";
                sourceInfoPanel.Controls.Add(seriesTitleEnter);
                seriesTitleEnter.Location = new Point(109, 125);
                seriesTitleEnter.Width = 150;

                Label originLabel = new Label();
                originLabel.Text = "City, State of Origin:";
                sourceInfoPanel.Controls.Add(originLabel);
                originLabel.Location = new Point(0, 150);
                originLabel.Width = 109;

                TextBox originEnter = new TextBox();
                originEnter.Name = "originEnter";
                sourceInfoPanel.Controls.Add(originEnter);
                originEnter.Location = new Point(109, 150);
                originEnter.Width = 150;

                Label studioLabel = new Label();
                studioLabel.Text = "Studio/Distributor:";
                sourceInfoPanel.Controls.Add(studioLabel);
                studioLabel.Location = new Point(0, 175);
                studioLabel.Width = 109;

                TextBox studioEnter = new TextBox();
                studioEnter.Name = "studioEnter";
                sourceInfoPanel.Controls.Add(studioEnter);
                studioEnter.Location = new Point(109, 175);
                studioEnter.Width = 150;
            }
            else if (music.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(9) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(9);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(9) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(9) + 299);
                }
                sourceInfoGroupBox.Tag = "1,9";

                Label writerLabel = new Label();
                writerLabel.Text = "Songwriter:";
                sourceInfoPanel.Controls.Add(writerLabel);
                writerLabel.Location = new Point(0, 0);

                TextBox writerFirstEnter = new TextBox();
                writerFirstEnter.Name = "writerFirstEnter";
                sourceInfoPanel.Controls.Add(writerFirstEnter);
                writerFirstEnter.Location = new Point(109, 0);
                writerFirstEnter.Width = 100;

                TextBox writerMiddleEnter = new TextBox();
                writerMiddleEnter.Name = "writerMiddleEnter";
                sourceInfoPanel.Controls.Add(writerMiddleEnter);
                writerMiddleEnter.Location = new Point(224, 0);
                writerMiddleEnter.Width = 100;

                TextBox writerLastEnter = new TextBox();
                writerLastEnter.Name = "writerLastEnter";
                sourceInfoPanel.Controls.Add(writerLastEnter);
                writerLastEnter.Location = new Point(339, 0);
                writerLastEnter.Width = 100;

                Label copyrightDateLabel = new Label();
                copyrightDateLabel.Text = "Copyright Date:";
                sourceInfoPanel.Controls.Add(copyrightDateLabel);
                copyrightDateLabel.Location = new Point(0, 25);
                copyrightDateLabel.Width = 109;

                TextBox copyrightDateEnter = new TextBox();
                copyrightDateEnter.Name = "copyrightDateEnter";
                sourceInfoPanel.Controls.Add(copyrightDateEnter);
                copyrightDateEnter.Location = new Point(109, 25);
                copyrightDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Song Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 50);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label artistLabel = new Label();
                artistLabel.Text = "Artist:";
                sourceInfoPanel.Controls.Add(artistLabel);
                artistLabel.Location = new Point(0, 75);

                TextBox artistFirstEnter = new TextBox();
                artistFirstEnter.Name = "artistFirstEnter";
                sourceInfoPanel.Controls.Add(artistFirstEnter);
                artistFirstEnter.Location = new Point(109, 75);
                artistFirstEnter.Width = 100;

                TextBox artistMiddleEnter = new TextBox();
                artistMiddleEnter.Name = "artistMiddleEnter";
                sourceInfoPanel.Controls.Add(artistMiddleEnter);
                artistMiddleEnter.Location = new Point(224, 75);
                artistMiddleEnter.Width = 100;

                TextBox artistLastEnter = new TextBox();
                artistLastEnter.Name = "artistLastEnter";
                sourceInfoPanel.Controls.Add(artistLastEnter);
                artistLastEnter.Location = new Point(339, 75);
                artistLastEnter.Width = 100;

                Label albumTitleLabel = new Label();
                albumTitleLabel.Text = "Album:";
                sourceInfoPanel.Controls.Add(albumTitleLabel);
                albumTitleLabel.Location = new Point(0, 100);
                albumTitleLabel.Width = 109;

                TextBox albumTitleEnter = new TextBox();
                albumTitleEnter.Name = "albumTitleEnter";
                sourceInfoPanel.Controls.Add(albumTitleEnter);
                albumTitleEnter.Location = new Point(109, 100);
                albumTitleEnter.Width = 150;

                Label mediumLabel = new Label();
                mediumLabel.Text = "Recording Medium:";
                sourceInfoPanel.Controls.Add(mediumLabel);
                mediumLabel.Location = new Point(0, 125);
                mediumLabel.Width = 109;

                TextBox mediumEnter = new TextBox();
                mediumEnter.Name = "mediumEnter";
                sourceInfoPanel.Controls.Add(mediumEnter);
                mediumEnter.Location = new Point(109, 125);
                mediumEnter.Width = 150;

                Label locationLabel = new Label();
                locationLabel.Text = "Recording Location:";
                sourceInfoPanel.Controls.Add(locationLabel);
                locationLabel.Location = new Point(0, 150);
                locationLabel.Width = 109;

                TextBox locationEnter = new TextBox();
                locationEnter.Name = "locationEnter";
                sourceInfoPanel.Controls.Add(locationEnter);
                locationEnter.Location = new Point(109, 150);
                locationEnter.Width = 150;

                Label labelLabel = new Label();
                labelLabel.Text = "Label:";
                sourceInfoPanel.Controls.Add(labelLabel);
                labelLabel.Location = new Point(0, 175);
                labelLabel.Width = 109;

                TextBox labelEnter = new TextBox();
                labelEnter.Name = "labelEnter";
                sourceInfoPanel.Controls.Add(labelEnter);
                labelEnter.Location = new Point(109, 175);
                labelEnter.Width = 150;

                Label recordingDateLabel = new Label();
                recordingDateLabel.Text = "Recording Date:";
                sourceInfoPanel.Controls.Add(recordingDateLabel);
                recordingDateLabel.Location = new Point(0, 200);
                recordingDateLabel.Width = 109;

                TextBox recordingDateEnter = new TextBox();
                recordingDateEnter.Name = "recordingDateEnter";
                sourceInfoPanel.Controls.Add(recordingDateEnter);
                recordingDateEnter.Location = new Point(109, 200);
                recordingDateEnter.Width = 150;
            }
            else if (interview.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(2) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(2);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(2) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(2) + 299);
                }
                sourceInfoGroupBox.Tag = "1,2";

                Label communicatorLabel = new Label();
                communicatorLabel.Text = "Person Interviewed:";
                sourceInfoPanel.Controls.Add(communicatorLabel);
                communicatorLabel.Location = new Point(0, 0);
                communicatorLabel.Width = 109;

                TextBox communicatorFirstEnter = new TextBox();
                communicatorFirstEnter.Name = "communicatorFirstEnter";
                sourceInfoPanel.Controls.Add(communicatorFirstEnter);
                communicatorFirstEnter.Location = new Point(109, 0);
                communicatorFirstEnter.Width = 100;

                TextBox communicatorMiddleEnter = new TextBox();
                communicatorMiddleEnter.Name = "communicatorMiddleEnter";
                sourceInfoPanel.Controls.Add(communicatorMiddleEnter);
                communicatorMiddleEnter.Location = new Point(224, 0);
                communicatorMiddleEnter.Width = 100;

                TextBox communicatorLastEnter = new TextBox();
                communicatorLastEnter.Name = "communicatorLastEnter";
                sourceInfoPanel.Controls.Add(communicatorLastEnter);
                communicatorLastEnter.Location = new Point(339, 0);
                communicatorLastEnter.Width = 100;

                Label dateLabel = new Label();
                dateLabel.Text = "Interview Date:";
                sourceInfoPanel.Controls.Add(dateLabel);
                dateLabel.Location = new Point(0, 25);
                dateLabel.Width = 109;

                TextBox dateEnter = new TextBox();
                dateEnter.Name = "dateEnter";
                sourceInfoPanel.Controls.Add(dateEnter);
                dateEnter.Location = new Point(109, 25);
                dateEnter.Width = 150;
            }
            else if (email.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(2) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(2);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(2) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(2) + 299);
                }
                sourceInfoGroupBox.Tag = "1,2";

                Label communicatorLabel = new Label();
                communicatorLabel.Text = "Person Emailing:";
                sourceInfoPanel.Controls.Add(communicatorLabel);
                communicatorLabel.Location = new Point(0, 0);
                communicatorLabel.Width = 109;

                TextBox communicatorFirstEnter = new TextBox();
                communicatorFirstEnter.Name = "communicatorFirstEnter";
                sourceInfoPanel.Controls.Add(communicatorFirstEnter);
                communicatorFirstEnter.Location = new Point(109, 0);
                communicatorFirstEnter.Width = 100;

                TextBox communicatorMiddleEnter = new TextBox();
                communicatorMiddleEnter.Name = "communicatorMiddleEnter";
                sourceInfoPanel.Controls.Add(communicatorMiddleEnter);
                communicatorMiddleEnter.Location = new Point(224, 0);
                communicatorMiddleEnter.Width = 100;

                TextBox communicatorLastEnter = new TextBox();
                communicatorLastEnter.Name = "communicatorLastEnter";
                sourceInfoPanel.Controls.Add(communicatorLastEnter);
                communicatorLastEnter.Location = new Point(339, 0);
                communicatorLastEnter.Width = 100;

                Label dateLabel = new Label();
                dateLabel.Text = "Email Date:";
                sourceInfoPanel.Controls.Add(dateLabel);
                dateLabel.Location = new Point(0, 25);
                dateLabel.Width = 109;

                TextBox dateEnter = new TextBox();
                dateEnter.Name = "dateEnter";
                sourceInfoPanel.Controls.Add(dateEnter);
                dateEnter.Location = new Point(109, 25);
                dateEnter.Width = 150;
            }
            else if (personal.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(2) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(2);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(2) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(2) + 299);
                }
                sourceInfoGroupBox.Tag = "1,2";

                Label communicatorLabel = new Label();
                communicatorLabel.Text = "Communicator:";
                sourceInfoPanel.Controls.Add(communicatorLabel);
                communicatorLabel.Location = new Point(0, 0);
                communicatorLabel.Width = 109;

                TextBox communicatorFirstEnter = new TextBox();
                communicatorFirstEnter.Name = "communicatorFirstEnter";
                sourceInfoPanel.Controls.Add(communicatorFirstEnter);
                communicatorFirstEnter.Location = new Point(109, 0);
                communicatorFirstEnter.Width = 100;

                TextBox communicatorMiddleEnter = new TextBox();
                communicatorMiddleEnter.Name = "communicatorMiddleEnter";
                sourceInfoPanel.Controls.Add(communicatorMiddleEnter);
                communicatorMiddleEnter.Location = new Point(224, 0);
                communicatorMiddleEnter.Width = 100;

                TextBox communicatorLastEnter = new TextBox();
                communicatorLastEnter.Name = "communicatorLastEnter";
                sourceInfoPanel.Controls.Add(communicatorLastEnter);
                communicatorLastEnter.Location = new Point(339, 0);
                communicatorLastEnter.Width = 100;

                Label dateLabel = new Label();
                dateLabel.Text = "Communication Date:";
                sourceInfoPanel.Controls.Add(dateLabel);
                dateLabel.Location = new Point(0, 25);
                dateLabel.Width = 109;

                TextBox dateEnter = new TextBox();
                dateEnter.Name = "dateEnter";
                sourceInfoPanel.Controls.Add(dateEnter);
                dateEnter.Location = new Point(109, 25);
                dateEnter.Width = 150;
            }
            else if (letterToEditor.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 434);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 299);
                }
                sourceInfoGroupBox.Tag = "1,8";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(180, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(295, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(410, 0);
                authorLastEnter.Width = 100;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 25);

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(180, 25);
                publicationDateEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title of Letter:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 50);
                titleLabel.Width = 180;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(180, 50);
                titleEnter.Width = 150;

                Label wherePublishedLabel = new Label();
                wherePublishedLabel.Text = "Work that Published the Letter:";
                sourceInfoPanel.Controls.Add(wherePublishedLabel);
                wherePublishedLabel.Location = new Point(0, 75);
                wherePublishedLabel.Width = 180;

                TextBox wherePublishedEnter = new TextBox();
                wherePublishedEnter.Name = "wherePublishedEnter";
                sourceInfoPanel.Controls.Add(wherePublishedEnter);
                wherePublishedEnter.Location = new Point(180, 75);
                wherePublishedEnter.Width = 150;

                Label volumeLabel = new Label();
                volumeLabel.Text = "Volume:";
                sourceInfoPanel.Controls.Add(volumeLabel);
                volumeLabel.Location = new Point(0, 100);

                TextBox volumeEnter = new TextBox();
                volumeEnter.Name = "volumeEnter";
                sourceInfoPanel.Controls.Add(volumeEnter);
                volumeEnter.Location = new Point(180, 100);
                volumeEnter.Width = 150;

                Label issueLabel = new Label();
                issueLabel.Text = "Issue:";
                sourceInfoPanel.Controls.Add(issueLabel);
                issueLabel.Location = new Point(0, 125);

                TextBox issueEnter = new TextBox();
                issueEnter.Name = "issueEnter";
                sourceInfoPanel.Controls.Add(issueEnter);
                issueEnter.Location = new Point(180, 125);
                issueEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 150);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(180, 150);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 175);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(180, 175);
                pageEndEnter.Width = 150;
            }
            else
            {

            }
        }

        public void addPlaceholderText(object sender, EventArgs e)
        {
            Control control = ((TextBox)sender);
            string placeholder = control.Tag.ToString();
            if (control.Text.Length < 1)
            {
                control.Text = placeholder;
                control.ForeColor = Color.DimGray;
            }
        }

        public void removePlaceholderText(object sender, EventArgs e)
        {
            Control control = ((TextBox)sender);
            string placeholder = control.Tag.ToString();
            if (control.Text.Equals(placeholder))
            {
                control.Text = "";
                control.ForeColor = Color.Black;
            }
        }

        public void removeTextForSave(TextBox textBox)
        {
            string placeholder = textBox.Tag.ToString();
            if (textBox.Text.Equals(placeholder))
            {
                textBox.Text = "";
            }
        }
    }
}
