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
    public partial class CitationAdder : Form
    {
        public CitationAdder()
        {
            InitializeComponent();

            this.Width = 1909;
            this.Height = 1447;
            sourceInfoGroupBox.Height = 155;
            sourceInfoPanel.Height = 135;

            book.Checked = false;
            book.Checked = true;
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
            translatorLabel.Location = new Point(0, Convert.ToInt32(numAuth) * 25);

            TextBox translatorFirstEnter = new TextBox();
            translatorFirstEnter.Name = "translatorFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(translatorFirstEnter);
            translatorFirstEnter.Location = new Point(firstTranslator.Location.X, Convert.ToInt32(numAuth) * 25);
            translatorFirstEnter.Width = 100;

            TextBox translatorMiddleEnter = new TextBox();
            translatorMiddleEnter.Name = "translatorMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(translatorMiddleEnter);
            translatorMiddleEnter.Location = new Point(middleTranslator.Location.X, Convert.ToInt32(numAuth) * 25);
            translatorMiddleEnter.Width = 100;

            TextBox translatorLastEnter = new TextBox();
            translatorLastEnter.Name = "translatorLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(translatorLastEnter);
            translatorLastEnter.Location = new Point(lastTranslator.Location.X, Convert.ToInt32(numAuth) * 25);
            translatorLastEnter.Width = 100;

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

            TextBox intervieweeMiddleEnter = new TextBox();
            intervieweeMiddleEnter.Name = "intervieweeMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(intervieweeMiddleEnter);
            intervieweeMiddleEnter.Location = new Point(middleInterviewee.Location.X, Convert.ToInt32(numInterviewer) * 25);
            intervieweeMiddleEnter.Width = 100;

            TextBox intervieweeLastEnter = new TextBox();
            intervieweeLastEnter.Name = "intervieweeLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(intervieweeLastEnter);
            intervieweeLastEnter.Location = new Point(lastInterviewee.Location.X, Convert.ToInt32(numInterviewer) * 25);
            intervieweeLastEnter.Width = 100;

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

            TextBox interviewerMiddleEnter = new TextBox();
            interviewerMiddleEnter.Name = "interviewerMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(interviewerMiddleEnter);
            interviewerMiddleEnter.Location = new Point(middleInterviewer.Location.X, 0);
            interviewerMiddleEnter.Width = 100;

            TextBox interviewerLastEnter = new TextBox();
            interviewerLastEnter.Name = "interviewerLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(interviewerLastEnter);
            interviewerLastEnter.Location = new Point(lastInterviewer.Location.X, 0);
            interviewerLastEnter.Width = 100;

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

            TextBox presenterMiddleEnter = new TextBox();
            presenterMiddleEnter.Name = "presenterMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(presenterMiddleEnter);
            presenterMiddleEnter.Location = new Point(middlePresenter.Location.X, 0);
            presenterMiddleEnter.Width = 100;

            TextBox presenterLastEnter = new TextBox();
            presenterLastEnter.Name = "presenterLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(presenterLastEnter);
            presenterLastEnter.Location = new Point(lastPresenter.Location.X, 0);
            presenterLastEnter.Width = 100;

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

            TextBox authorMiddleEnter = new TextBox();
            authorMiddleEnter.Name = "authorMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorMiddleEnter);
            authorMiddleEnter.Location = new Point(middleAuthor.Location.X, 0);
            authorMiddleEnter.Width = 100;

            TextBox authorLastEnter = new TextBox();
            authorLastEnter.Name = "authorLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorLastEnter);
            authorLastEnter.Location = new Point(lastAuthor.Location.X, 0);
            authorLastEnter.Width = 100;

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
            authorLabel.Text = "Original Author:";
            sourceInfoPanel.Controls.Add(authorLabel);
            authorLabel.Location = new Point(0, 0);

            TextBox authorFirstEnter = new TextBox();
            authorFirstEnter.Name = "authorFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorFirstEnter);
            authorFirstEnter.Location = new Point(firstAuthor.Location.X, 0);
            authorFirstEnter.Width = 100;

            TextBox authorMiddleEnter = new TextBox();
            authorMiddleEnter.Name = "authorMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorMiddleEnter);
            authorMiddleEnter.Location = new Point(middleAuthor.Location.X, 0);
            authorMiddleEnter.Width = 100;

            TextBox authorLastEnter = new TextBox();
            authorLastEnter.Name = "authorLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorLastEnter);
            authorLastEnter.Location = new Point(lastAuthor.Location.X, 0);
            authorLastEnter.Width = 100;

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
            authorLabel.Location = new Point(0, Convert.ToInt32(numRev) * 25 + 50);
            authorLabel.Width = 180;

            TextBox authorFirstEnter = new TextBox();
            authorFirstEnter.Name = "authorFirstEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorFirstEnter);
            authorFirstEnter.Location = new Point(firstAuthor.Location.X, Convert.ToInt32(numRev) * 25 + 50);
            authorFirstEnter.Width = 100;

            TextBox authorMiddleEnter = new TextBox();
            authorMiddleEnter.Name = "authorMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorMiddleEnter);
            authorMiddleEnter.Location = new Point(middleAuthor.Location.X, Convert.ToInt32(numRev) * 25 + 50);
            authorMiddleEnter.Width = 100;

            TextBox authorLastEnter = new TextBox();
            authorLastEnter.Name = "authorLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(authorLastEnter);
            authorLastEnter.Location = new Point(lastAuthor.Location.X, Convert.ToInt32(numRev) * 25 + 50);
            authorLastEnter.Width = 100;

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

            TextBox reviewerMiddleEnter = new TextBox();
            reviewerMiddleEnter.Name = "reviewerMiddleEnter" + newIndex;
            sourceInfoPanel.Controls.Add(reviewerMiddleEnter);
            reviewerMiddleEnter.Location = new Point(middleReviewer.Location.X, 0);
            reviewerMiddleEnter.Width = 100;

            TextBox reviewerLastEnter = new TextBox();
            reviewerLastEnter.Name = "reviewerLastEnter" + newIndex;
            sourceInfoPanel.Controls.Add(reviewerLastEnter);
            reviewerLastEnter.Location = new Point(lastReviewer.Location.X, 0);
            reviewerLastEnter.Width = 100;

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

                moveTo("quoteContentGroupBox", 354);
            }
            else
            {
                sourceInfoPanel.Height = getSourceInfoHeight(newNum);
                sourceInfoGroupBox.Height = getSourceInfoHeight(newNum) + 25;
                sourceInfoPanel.VerticalScroll.Value = 0;
                sourceInfoPanel.AutoScroll = false;

                moveTo("quoteContentGroupBox", getSourceInfoHeight(newNum) + 219);
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
            if (book.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 219);
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

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 50);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 50);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 75);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 75);
                publishDateEnter.Width = 150;

                Label editionLabel = new Label();
                editionLabel.Text = "Edition:";
                sourceInfoPanel.Controls.Add(editionLabel);
                editionLabel.Location = new Point(0, 100);

                TextBox editionEnter = new TextBox();
                editionEnter.Name = "editionEnter";
                sourceInfoPanel.Controls.Add(editionEnter);
                editionEnter.Location = new Point(109, 100);
                editionEnter.Width = 150;
            }
            else if (shortStory.Checked)
            {
                removeInsideInfo();
                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 219);
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

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label collectionTitleLabel = new Label();
                collectionTitleLabel.Text = "Collection Title:";
                sourceInfoPanel.Controls.Add(collectionTitleLabel);
                collectionTitleLabel.Location = new Point(0, 50);

                TextBox collectionTitleEnter = new TextBox();
                collectionTitleEnter.Name = "collectionTitleEnter";
                sourceInfoPanel.Controls.Add(collectionTitleEnter);
                collectionTitleEnter.Location = new Point(109, 50);
                collectionTitleEnter.Width = 150;

                Label editorLabel = new Label();
                editorLabel.Text = "Editor:";
                sourceInfoPanel.Controls.Add(editorLabel);
                editorLabel.Location = new Point(0, 75);

                TextBox editorFirstEnter = new TextBox();
                editorFirstEnter.Name = "editorFirstEnter";
                sourceInfoPanel.Controls.Add(editorFirstEnter);
                editorFirstEnter.Location = new Point(109, 75);
                editorFirstEnter.Width = 100;

                TextBox editorMiddleEnter = new TextBox();
                editorMiddleEnter.Name = "editorMiddleEnter";
                sourceInfoPanel.Controls.Add(editorMiddleEnter);
                editorMiddleEnter.Location = new Point(224, 75);
                editorMiddleEnter.Width = 100;

                TextBox editorLastEnter = new TextBox();
                editorLastEnter.Name = "editorLastEnter";
                sourceInfoPanel.Controls.Add(editorLastEnter);
                editorLastEnter.Location = new Point(339, 75);
                editorLastEnter.Width = 100;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 100);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 100);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 125);                

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 125);
                publishDateEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 150);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 150);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 175);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 175);
                pageEndEnter.Width = 150;
            }
            else if (editorial.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 219);
                }

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

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label sourceLabel = new Label();
                sourceLabel.Text = "Source Name:";
                sourceInfoPanel.Controls.Add(sourceLabel);
                sourceLabel.Location = new Point(0, 50);

                TextBox sourceEnter = new TextBox();
                sourceEnter.Name = "sourceEnter";
                sourceInfoPanel.Controls.Add(sourceEnter);
                sourceEnter.Location = new Point(109, 50);
                sourceEnter.Width = 150;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Publication Date:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 75);
                publicationDateLabel.Width = 109;

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 75);
                publicationDateEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 100);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 100);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 125);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 125);
                pageEndEnter.Width = 150;
            }
            else if (encyclopedia.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 219);
                }
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

                Label bookNameLabel = new Label();
                bookNameLabel.Text = "Title of Encyclopedia/Dictionary:";
                sourceInfoPanel.Controls.Add(bookNameLabel);
                bookNameLabel.Location = new Point(0, 25);
                bookNameLabel.Width = 180;

                TextBox bookNameEnter = new TextBox();
                bookNameEnter.Name = "bookNameEnter";
                sourceInfoPanel.Controls.Add(bookNameEnter);
                bookNameEnter.Location = new Point(180, 25);
                bookNameEnter.Width = 150;

                Label editionLabel = new Label();
                editionLabel.Text = "Edition:";
                sourceInfoPanel.Controls.Add(editionLabel);
                editionLabel.Location = new Point(0, 50);

                TextBox editionEnter = new TextBox();
                editionEnter.Name = "editionEnter";
                sourceInfoPanel.Controls.Add(editionEnter);
                editionEnter.Location = new Point(180, 50);
                editionEnter.Width = 150;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 75);

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(180, 75);
                publicationDateEnter.Width = 150;
            }
            else if (translated.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 219);
                }
                sourceInfoGroupBox.Tag = "1,5,1";

                Label authorLabel = new Label();
                authorLabel.Text = "Original Author:";
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

                Button authorTransAdder = new Button();
                authorTransAdder.Name = "authorTransAdderButton";
                authorTransAdder.Text = "Add an Author";
                authorTransAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorTransAdder);
                authorTransAdder.Location = new Point(459, 0);
                authorTransAdder.Click += new EventHandler(authorTransAdderButton_Click);

                Label translatorLabel = new Label();
                translatorLabel.Text = "Translator Name:";
                sourceInfoPanel.Controls.Add(translatorLabel);
                translatorLabel.Location = new Point(0, 25);

                TextBox translatorFirstEnter = new TextBox();
                translatorFirstEnter.Name = "translatorFirstEnter1";
                sourceInfoPanel.Controls.Add(translatorFirstEnter);
                translatorFirstEnter.Location = new Point(109, 25);
                translatorFirstEnter.Width = 100;

                TextBox translatorMiddleEnter = new TextBox();
                translatorMiddleEnter.Name = "translatorMiddleEnter1";
                sourceInfoPanel.Controls.Add(translatorMiddleEnter);
                translatorMiddleEnter.Location = new Point(224, 25);
                translatorMiddleEnter.Width = 100;

                TextBox translatorLastEnter = new TextBox();
                translatorLastEnter.Name = "translatorLastEnter1";
                sourceInfoPanel.Controls.Add(translatorLastEnter);
                translatorLastEnter.Location = new Point(339, 25);
                translatorLastEnter.Width = 100;

                Button translatorAdder = new Button();
                translatorAdder.Name = "translatorAdderButton";
                translatorAdder.Text = "Add an Translator";
                translatorAdder.Width = 120;
                sourceInfoPanel.Controls.Add(translatorAdder);
                translatorAdder.Location = new Point(459, 25);
                translatorAdder.Click += new EventHandler(translatorAdderButton_Click);

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 50);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 50);
                titleEnter.Width = 150;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 75);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 75);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Date:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 100);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 100);
                publishDateEnter.Width = 150;
            }
            else if (magazine.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(5) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(5);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(5) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(5) + 219);
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

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label magazineNameLabel = new Label();
                magazineNameLabel.Text = "Magazine Name:";
                sourceInfoPanel.Controls.Add(magazineNameLabel);
                magazineNameLabel.Location = new Point(0, 50);

                TextBox magazineNameEnter = new TextBox();
                magazineNameEnter.Name = "magazineNameEnter";
                sourceInfoPanel.Controls.Add(magazineNameEnter);
                magazineNameEnter.Location = new Point(109, 50);
                magazineNameEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 75);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 75);
                publishDateEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 100);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 100);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 125);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 125);
                pageEndEnter.Width = 150;
            }
            else if (newspaper.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 219);
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

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label newspaperNameLabel = new Label();
                newspaperNameLabel.Text = "Newspaper Name:";
                sourceInfoPanel.Controls.Add(newspaperNameLabel);
                newspaperNameLabel.Location = new Point(0, 50);

                TextBox newspaperNameEnter = new TextBox();
                newspaperNameEnter.Name = "newspaperNameEnter";
                sourceInfoPanel.Controls.Add(newspaperNameEnter);
                newspaperNameEnter.Location = new Point(109, 50);
                newspaperNameEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 75);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 75);
                publishDateEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 100);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 100);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 125);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 125);
                pageEndEnter.Width = 150;

            }
            else if (journal.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 219);
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

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label journalNameLabel = new Label();
                journalNameLabel.Text = "Journal Name:";
                sourceInfoPanel.Controls.Add(journalNameLabel);
                journalNameLabel.Location = new Point(0, 50);

                TextBox journalNameEnter = new TextBox();
                journalNameEnter.Name = "journalNameEnter";
                sourceInfoPanel.Controls.Add(journalNameEnter);
                journalNameEnter.Location = new Point(109, 50);
                journalNameEnter.Width = 150;

                Label volumeNumberLabel = new Label();
                volumeNumberLabel.Text = "Volume Number:";
                sourceInfoPanel.Controls.Add(volumeNumberLabel);
                volumeNumberLabel.Location = new Point(0, 75);

                TextBox volumeNumberEnter = new TextBox();
                volumeNumberEnter.Name = "volumeNumberEnter";
                sourceInfoPanel.Controls.Add(volumeNumberEnter);
                volumeNumberEnter.Location = new Point(109, 75);
                volumeNumberEnter.Width = 150;

                Label issueNumberLabel = new Label();
                issueNumberLabel.Text = "Issue Number:";
                sourceInfoPanel.Controls.Add(issueNumberLabel);
                issueNumberLabel.Location = new Point(0, 100);

                TextBox issueNumberEnter = new TextBox();
                issueNumberEnter.Name = "issueNumberEnter";
                sourceInfoPanel.Controls.Add(issueNumberEnter);
                issueNumberEnter.Location = new Point(109, 100);
                issueNumberEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 125);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 125);
                publishDateEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 150);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 150);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 175);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 175);
                pageEndEnter.Width = 150;

            }
            else if (onlineOnlyJournal.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 219);
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

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label journalNameLabel = new Label();
                journalNameLabel.Text = "Journal Name:";
                sourceInfoPanel.Controls.Add(journalNameLabel);
                journalNameLabel.Location = new Point(0, 50);

                TextBox journalNameEnter = new TextBox();
                journalNameEnter.Name = "journalNameEnter";
                sourceInfoPanel.Controls.Add(journalNameEnter);
                journalNameEnter.Location = new Point(109, 50);
                journalNameEnter.Width = 150;

                Label volumeNumberLabel = new Label();
                volumeNumberLabel.Text = "Volume Number:";
                sourceInfoPanel.Controls.Add(volumeNumberLabel);
                volumeNumberLabel.Location = new Point(0, 75);

                TextBox volumeNumberEnter = new TextBox();
                volumeNumberEnter.Name = "volumeNumberEnter";
                sourceInfoPanel.Controls.Add(volumeNumberEnter);
                volumeNumberEnter.Location = new Point(109, 75);
                volumeNumberEnter.Width = 150;

                Label issueNumberLabel = new Label();
                issueNumberLabel.Text = "Issue Number:";
                sourceInfoPanel.Controls.Add(issueNumberLabel);
                issueNumberLabel.Location = new Point(0, 100);

                TextBox issueNumberEnter = new TextBox();
                issueNumberEnter.Name = "issueNumberEnter";
                sourceInfoPanel.Controls.Add(issueNumberEnter);
                issueNumberEnter.Location = new Point(109, 100);
                issueNumberEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 125);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 125);
                publishDateEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 150);

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 150);
                retrievedFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 175);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(109, 175);
                accessedEnter.Width = 150;
            }
            else if (onlinePeriodical.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(7) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(7);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(7) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(7) + 219);
                }
                sourceInfoGroupBox.Tag = "1,7";

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

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label periodicalNameLabel = new Label();
                periodicalNameLabel.Text = "Periodical Name:";
                sourceInfoPanel.Controls.Add(periodicalNameLabel);
                periodicalNameLabel.Location = new Point(0, 50);

                TextBox periodicalNameEnter = new TextBox();
                periodicalNameEnter.Name = "periodicalNameEnter";
                sourceInfoPanel.Controls.Add(periodicalNameEnter);
                periodicalNameEnter.Location = new Point(109, 50);
                periodicalNameEnter.Width = 150;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 75);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 75);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 100);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 100);
                publishDateEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 125);

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 125);
                retrievedFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 150);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(109, 150);
                accessedEnter.Width = 150;
            }
            else if (onlineNewspaper.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(8) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(8);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(8) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(8) + 219);
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

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label newspaperNameLabel = new Label();
                newspaperNameLabel.Text = "Newspaper Name:";
                sourceInfoPanel.Controls.Add(newspaperNameLabel);
                newspaperNameLabel.Location = new Point(0, 50);

                TextBox newspaperNameEnter = new TextBox();
                newspaperNameEnter.Name = "newspaperNameEnter";
                sourceInfoPanel.Controls.Add(newspaperNameEnter);
                newspaperNameEnter.Location = new Point(109, 50);
                newspaperNameEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 75);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 75);
                publishDateEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 100);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 100);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 125);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 125);
                pageEndEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 150);

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 150);
                retrievedFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 175);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(109, 175);
                accessedEnter.Width = 150;
            }
            else if (website.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 219);
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

                Label titleLabel = new Label();
                titleLabel.Text = "Page Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label mainTitleLabel = new Label();
                mainTitleLabel.Text = "Main Site Title:";
                sourceInfoPanel.Controls.Add(mainTitleLabel);
                mainTitleLabel.Location = new Point(0, 50);
                mainTitleLabel.Width = 109;

                TextBox mainTitleEnter = new TextBox();
                mainTitleEnter.Name = "mainTitleEnter";
                sourceInfoPanel.Controls.Add(mainTitleEnter);
                mainTitleEnter.Location = new Point(109, 50);
                mainTitleEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 75);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 75);
                publishDateEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 100);

                TextBox retrieveFromEnter = new TextBox();
                retrieveFromEnter.Name = "retrieveFromEnter";
                sourceInfoPanel.Controls.Add(retrieveFromEnter);
                retrieveFromEnter.Location = new Point(109, 100);
                retrieveFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Access On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 125);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(109, 125);
                accessedEnter.Width = 150;
            }
            else if (onlinePrintJournal.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(10) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(10);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(10) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(10) + 219);
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

                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Article Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label journalNameLabel = new Label();
                journalNameLabel.Text = "Journal Name:";
                sourceInfoPanel.Controls.Add(journalNameLabel);
                journalNameLabel.Location = new Point(0, 50);

                TextBox journalNameEnter = new TextBox();
                journalNameEnter.Name = "journalNameEnter";
                sourceInfoPanel.Controls.Add(journalNameEnter);
                journalNameEnter.Location = new Point(109, 50);
                journalNameEnter.Width = 150;

                Label volumeNumberLabel = new Label();
                volumeNumberLabel.Text = "Volume Number:";
                sourceInfoPanel.Controls.Add(volumeNumberLabel);
                volumeNumberLabel.Location = new Point(0, 75);

                TextBox volumeNumberEnter = new TextBox();
                volumeNumberEnter.Name = "volumeNumberEnter";
                sourceInfoPanel.Controls.Add(volumeNumberEnter);
                volumeNumberEnter.Location = new Point(109, 75);
                volumeNumberEnter.Width = 150;

                Label issueNumberLabel = new Label();
                issueNumberLabel.Text = "Issue Number:";
                sourceInfoPanel.Controls.Add(issueNumberLabel);
                issueNumberLabel.Location = new Point(0, 100);

                TextBox issueNumberEnter = new TextBox();
                issueNumberEnter.Name = "issueNumberEnter";
                sourceInfoPanel.Controls.Add(issueNumberEnter);
                issueNumberEnter.Location = new Point(109, 100);
                issueNumberEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 125);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 125);
                publishDateEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 150);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(109, 150);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 175);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(109, 175);
                pageEndEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 200);

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 200);
                retrievedFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 225);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(109, 225);
                accessedEnter.Width = 150;
            }
            else if (onlineEncyclopedia.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 219);
                }
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

                Label bookNameLabel = new Label();
                bookNameLabel.Text = "Title of Encyclopedia/Dictionary:";
                sourceInfoPanel.Controls.Add(bookNameLabel);
                bookNameLabel.Location = new Point(0, 25);
                bookNameLabel.Width = 180;

                TextBox bookNameEnter = new TextBox();
                bookNameEnter.Name = "bookNameEnter";
                sourceInfoPanel.Controls.Add(bookNameEnter);
                bookNameEnter.Location = new Point(180, 25);
                bookNameEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 50);

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(180, 50);
                retrievedFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 75);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(180, 75);
                accessedEnter.Width = 150;
            }
            else if (blogDiscussion.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(7) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(7);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(7) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(7) + 219);
                }
                sourceInfoGroupBox.Tag = "1,7,1";

                Label posterLabel = new Label();
                posterLabel.Text = "Person Posting Name:";
                sourceInfoPanel.Controls.Add(posterLabel);
                posterLabel.Location = new Point(0, 0);
                posterLabel.Width = 180;

                TextBox posterFirstEnter = new TextBox();
                posterFirstEnter.Name = "posterFirstEnter";
                sourceInfoPanel.Controls.Add(posterFirstEnter);
                posterFirstEnter.Location = new Point(180, 0);
                posterFirstEnter.Width = 100;

                TextBox posterMiddleEnter = new TextBox();
                posterMiddleEnter.Name = "posterMiddleEnter";
                sourceInfoPanel.Controls.Add(posterMiddleEnter);
                posterMiddleEnter.Location = new Point(295, 0);
                posterMiddleEnter.Width = 100;

                TextBox posterLastEnter = new TextBox();
                posterLastEnter.Name = "posterLastEnter";
                sourceInfoPanel.Controls.Add(posterLastEnter);
                posterLastEnter.Location = new Point(410, 0);
                posterLastEnter.Width = 100;

                Label posterScreenLabel = new Label();
                posterScreenLabel.Text = "Person Posting Screen Name:";
                sourceInfoPanel.Controls.Add(posterScreenLabel);
                posterScreenLabel.Location = new Point(0, 25);
                posterScreenLabel.Width = 180;

                TextBox posterScreenEnter = new TextBox();
                posterScreenEnter.Name = "posterScreenEnter";
                sourceInfoPanel.Controls.Add(posterScreenEnter);
                posterScreenEnter.Location = new Point(180, 25);
                posterScreenEnter.Width = 150;                

                Label postTitleLabel = new Label();
                postTitleLabel.Text = "Post Title:";
                sourceInfoPanel.Controls.Add(postTitleLabel);
                postTitleLabel.Location = new Point(0, 50);

                TextBox postTitleEnter = new TextBox();
                postTitleEnter.Name = "postTitleEnter";
                sourceInfoPanel.Controls.Add(postTitleEnter);
                postTitleEnter.Location = new Point(180, 50);
                postTitleEnter.Width = 150;

                Label websiteLabel = new Label();
                websiteLabel.Text = "Name of Website:";
                sourceInfoPanel.Controls.Add(websiteLabel);
                websiteLabel.Location = new Point(0, 75);

                TextBox websiteEnter = new TextBox();
                websiteEnter.Name = "websiteEnter";
                sourceInfoPanel.Controls.Add(websiteEnter);
                websiteEnter.Location = new Point(180, 75);
                websiteEnter.Width = 150;

                Label postDateLabel = new Label();
                postDateLabel.Text = "Date Posted:";
                sourceInfoPanel.Controls.Add(postDateLabel);
                postDateLabel.Location = new Point(0, 100);

                TextBox postDateEnter = new TextBox();
                postDateEnter.Name = "postDateEnter";
                sourceInfoPanel.Controls.Add(postDateEnter);
                postDateEnter.Location = new Point(180, 100);
                postDateEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 125);

                TextBox retrieveFromEnter = new TextBox();
                retrieveFromEnter.Name = "retrieveFromEnter";
                sourceInfoPanel.Controls.Add(retrieveFromEnter);
                retrieveFromEnter.Location = new Point(180, 125);
                retrieveFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 150);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(180, 150);
                accessedEnter.Width = 150;
            }
            else if (publishedDissertation.Checked || publishedThesis.Checked || unpublishedDissertation.Checked || unpublishedThesis.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 219);
                }
                sourceInfoGroupBox.Tag = "1,6";

                Label authorLabel = new Label();
                authorLabel.Text = "Author:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(150, 0);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(265, 0);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(380, 0);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "authorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 100;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(500, 0);
                authorAdder.Click += new EventHandler(authorAdderButton_Click);

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 25);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(150, 25);
                titleEnter.Width = 150;

                Label schoolLabel = new Label();
                schoolLabel.Text = "School:";
                sourceInfoPanel.Controls.Add(schoolLabel);
                schoolLabel.Location = new Point(0, 50);
                schoolLabel.Width = 150;

                TextBox schoolEnter = new TextBox();
                schoolEnter.Name = "schoolEnter";
                sourceInfoPanel.Controls.Add(schoolEnter);
                schoolEnter.Location = new Point(150, 50);
                schoolEnter.Width = 150;

                Label yearAwardedLabel = new Label();
                yearAwardedLabel.Text = "Year Degree Awarded:";
                sourceInfoPanel.Controls.Add(yearAwardedLabel);
                yearAwardedLabel.Location = new Point(0, 75);
                yearAwardedLabel.Width = 150;

                TextBox yearAwardedEnter = new TextBox();
                yearAwardedEnter.Name = "yearAwardedEnter";
                sourceInfoPanel.Controls.Add(yearAwardedEnter);
                yearAwardedEnter.Location = new Point(150, 75);
                yearAwardedEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 100);
                retrievedFromLabel.Width = 150;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(150, 100);
                retrievedFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 125);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(150, 125);
                accessedEnter.Width = 150;
            }
            else if (governmentDocument.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 219);
                }

                Label authorLabel = new Label();
                authorLabel.Text = "Written By:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorEnter = new TextBox();
                authorEnter.Name = "authorEnter";
                sourceInfoPanel.Controls.Add(authorEnter);
                authorEnter.Location = new Point(109, 0);
                authorEnter.Width = 150;

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 50);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 50);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 75);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 75);
                publishDateEnter.Width = 150;

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

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 125);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(109, 125);
                accessedEnter.Width = 150;
            }
            else if (review.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(9) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(9);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(9) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(9) + 219);
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

                Label titleLabel = new Label();
                titleLabel.Text = "Review Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 25);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(180, 25);
                titleEnter.Width = 150;

                Label reviewedTitleLabel = new Label();
                reviewedTitleLabel.Text = "Title of Work Reviewed:";
                sourceInfoPanel.Controls.Add(reviewedTitleLabel);
                reviewedTitleLabel.Location = new Point(0, 50);
                reviewedTitleLabel.Width = 180;

                TextBox reviewedTitleEnter = new TextBox();
                reviewedTitleEnter.Name = "reviewedTitleEnter";
                sourceInfoPanel.Controls.Add(reviewedTitleEnter);
                reviewedTitleEnter.Location = new Point(180, 50);
                reviewedTitleEnter.Width = 150;

                Label authorLabel = new Label();
                authorLabel.Text = "Original Author Name:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 75);
                authorLabel.Width = 180;

                TextBox authorFirstEnter = new TextBox();
                authorFirstEnter.Name = "authorFirstEnter1";
                sourceInfoPanel.Controls.Add(authorFirstEnter);
                authorFirstEnter.Location = new Point(180, 75);
                authorFirstEnter.Width = 100;

                TextBox authorMiddleEnter = new TextBox();
                authorMiddleEnter.Name = "authorMiddleEnter1";
                sourceInfoPanel.Controls.Add(authorMiddleEnter);
                authorMiddleEnter.Location = new Point(295, 75);
                authorMiddleEnter.Width = 100;

                TextBox authorLastEnter = new TextBox();
                authorLastEnter.Name = "authorLastEnter1";
                sourceInfoPanel.Controls.Add(authorLastEnter);
                authorLastEnter.Location = new Point(410, 75);
                authorLastEnter.Width = 100;

                Button authorAdder = new Button();
                authorAdder.Name = "originalAuthorAdderButton";
                authorAdder.Text = "Add an Author";
                authorAdder.Width = 110;
                sourceInfoPanel.Controls.Add(authorAdder);
                authorAdder.Location = new Point(530, 75);
                authorAdder.Click += new EventHandler(originalAuthorAdderButton_Click);

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Year:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 100);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(180, 100);
                publishDateEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 125);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(180, 125);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 150);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(180, 150);
                pageEndEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 175);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(180, 175);
                retrievedFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 200);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(180, 200);
                accessedEnter.Width = 150;
            }
            else if (presentation.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(9) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(9);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(9) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(9) + 219);
                }
                sourceInfoGroupBox.Tag = "1,9";

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

                Label titleLabel = new Label();
                titleLabel.Text = "Presentation Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 25);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label meetingLabel = new Label();
                meetingLabel.Text = "Meeting Name:";
                sourceInfoPanel.Controls.Add(meetingLabel);
                meetingLabel.Location = new Point(0, 50);
                meetingLabel.Width = 109;

                TextBox meetingEnter = new TextBox();
                meetingEnter.Name = "meetingEnter";
                sourceInfoPanel.Controls.Add(meetingEnter);
                meetingEnter.Location = new Point(109, 50);
                meetingEnter.Width = 150;

                Label dateLabel = new Label();
                dateLabel.Text = "Date Given:";
                sourceInfoPanel.Controls.Add(dateLabel);
                dateLabel.Location = new Point(0, 75);
                dateLabel.Width = 109;

                TextBox dateEnter = new TextBox();
                dateEnter.Name = "dateEnter";
                sourceInfoPanel.Controls.Add(dateEnter);
                dateEnter.Location = new Point(109, 75);
                dateEnter.Width = 150;

                Label venueLabel = new Label();
                venueLabel.Text = "Venue:";
                sourceInfoPanel.Controls.Add(venueLabel);
                venueLabel.Location = new Point(0, 100);
                venueLabel.Width = 109;

                TextBox venueEnter = new TextBox();
                venueEnter.Name = "venueEnter";
                sourceInfoPanel.Controls.Add(venueEnter);
                venueEnter.Location = new Point(109, 100);
                venueEnter.Width = 150;

                Label locationLabel = new Label();
                locationLabel.Text = "City and State:";
                sourceInfoPanel.Controls.Add(locationLabel);
                locationLabel.Location = new Point(0, 125);
                locationLabel.Width = 109;

                TextBox locationEnter = new TextBox();
                locationEnter.Name = "locationEnter";
                sourceInfoPanel.Controls.Add(locationEnter);
                locationEnter.Location = new Point(109, 125);
                locationEnter.Width = 150;

                Label formatLabel = new Label();
                formatLabel.Text = "Format:";
                sourceInfoPanel.Controls.Add(formatLabel);
                formatLabel.Location = new Point(0, 150);

                TextBox formatEnter = new TextBox();
                formatEnter.Name = "formatEnter";
                sourceInfoPanel.Controls.Add(formatEnter);
                formatEnter.Location = new Point(109, 150);
                formatEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 175);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 175);
                retrievedFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 200);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(109, 200);
                accessedEnter.Width = 150;
            }
            else if (movie.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 219);
                }
                sourceInfoGroupBox.Tag = "1,4";

                Label titleLabel = new Label();
                titleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 0);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 0);
                titleEnter.Width = 150;

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

                Label distributorLabel = new Label();
                distributorLabel.Text = "Distributor:";
                sourceInfoPanel.Controls.Add(distributorLabel);
                distributorLabel.Location = new Point(0, 50);
                distributorLabel.Width = 109;

                TextBox distributorEnter = new TextBox();
                distributorEnter.Name = "distributorEnter";
                sourceInfoPanel.Controls.Add(distributorEnter);
                distributorEnter.Location = new Point(109, 50);
                distributorEnter.Width = 150;

                Label releaseLabel = new Label();
                releaseLabel.Text = "Release Year:";
                sourceInfoPanel.Controls.Add(releaseLabel);
                releaseLabel.Location = new Point(0, 75);
                releaseLabel.Width = 109;

                TextBox releaseEnter = new TextBox();
                releaseEnter.Name = "releaseEnter";
                sourceInfoPanel.Controls.Add(releaseEnter);
                releaseEnter.Location = new Point(109, 75);
                releaseEnter.Width = 150;
            }
            else if (tvEpisode.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 219);
                }
                sourceInfoGroupBox.Tag = "1,6";

                Label titleLabel = new Label();
                titleLabel.Text = "Episode Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 0);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 0);
                titleEnter.Width = 150;

                Label seriesTitleLabel = new Label();
                seriesTitleLabel.Text = "Series Title:";
                sourceInfoPanel.Controls.Add(seriesTitleLabel);
                seriesTitleLabel.Location = new Point(0, 25);
                seriesTitleLabel.Width = 109;

                TextBox seriesTitleEnter = new TextBox();
                seriesTitleEnter.Name = "seriesTitleEnter";
                sourceInfoPanel.Controls.Add(seriesTitleEnter);
                seriesTitleEnter.Location = new Point(109, 25);
                seriesTitleEnter.Width = 150;

                Label networkLabel = new Label();
                networkLabel.Text = "Network:";
                sourceInfoPanel.Controls.Add(networkLabel);
                networkLabel.Location = new Point(0, 50);
                networkLabel.Width = 109;

                TextBox networkEnter = new TextBox();
                networkEnter.Name = "networkEnter";
                sourceInfoPanel.Controls.Add(networkEnter);
                networkEnter.Location = new Point(109, 50);
                networkEnter.Width = 150;

                Label lettersLabel = new Label();
                lettersLabel.Text = "Call Letters:";
                sourceInfoPanel.Controls.Add(lettersLabel);
                lettersLabel.Location = new Point(0, 75);
                lettersLabel.Width = 109;

                TextBox lettersEnter = new TextBox();
                lettersEnter.Name = "lettersEnter";
                sourceInfoPanel.Controls.Add(lettersEnter);
                lettersEnter.Location = new Point(109, 75);
                lettersEnter.Width = 150;

                Label originLabel = new Label();
                originLabel.Text = "City, State of Origin:";
                sourceInfoPanel.Controls.Add(originLabel);
                originLabel.Location = new Point(0, 100);
                originLabel.Width = 109;

                TextBox originEnter = new TextBox();
                originEnter.Name = "originEnter";
                sourceInfoPanel.Controls.Add(originEnter);
                originEnter.Location = new Point(109, 100);
                originEnter.Width = 150;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Production Date:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 125);
                publicationDateLabel.Width = 109;

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(109, 125);
                publicationDateEnter.Width = 150;
            }
            else if (music.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(7) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(7);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(7) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(7) + 219);
                }
                sourceInfoGroupBox.Tag = "1,7";

                Label artistLabel = new Label();
                artistLabel.Text = "Artist:";
                sourceInfoPanel.Controls.Add(artistLabel);
                artistLabel.Location = new Point(0, 0);

                TextBox artistFirstEnter = new TextBox();
                artistFirstEnter.Name = "artistFirstEnter";
                sourceInfoPanel.Controls.Add(artistFirstEnter);
                artistFirstEnter.Location = new Point(109, 0);
                artistFirstEnter.Width = 100;

                TextBox artistMiddleEnter = new TextBox();
                artistMiddleEnter.Name = "artistMiddleEnter";
                sourceInfoPanel.Controls.Add(artistMiddleEnter);
                artistMiddleEnter.Location = new Point(224, 0);
                artistMiddleEnter.Width = 100;

                TextBox artistLastEnter = new TextBox();
                artistLastEnter.Name = "artistLastEnter";
                sourceInfoPanel.Controls.Add(artistLastEnter);
                artistLastEnter.Location = new Point(339, 0);
                artistLastEnter.Width = 100;

                Label titleLabel = new Label();
                titleLabel.Text = "Song Title:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 25);
                titleLabel.Width = 109;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 25);
                titleEnter.Width = 150;

                Label albumTitleLabel = new Label();
                albumTitleLabel.Text = "Album:";
                sourceInfoPanel.Controls.Add(albumTitleLabel);
                albumTitleLabel.Location = new Point(0, 50);
                albumTitleLabel.Width = 109;

                TextBox albumTitleEnter = new TextBox();
                albumTitleEnter.Name = "albumTitleEnter";
                sourceInfoPanel.Controls.Add(albumTitleEnter);
                albumTitleEnter.Location = new Point(109, 50);
                albumTitleEnter.Width = 150;

                Label manufacturerLabel = new Label();
                manufacturerLabel.Text = "Recording Manufacturer:";
                sourceInfoPanel.Controls.Add(manufacturerLabel);
                manufacturerLabel.Location = new Point(0, 75);
                manufacturerLabel.Width = 109;

                TextBox manufacturerEnter = new TextBox();
                manufacturerEnter.Name = "manufacturerEnter";
                sourceInfoPanel.Controls.Add(manufacturerEnter);
                manufacturerEnter.Location = new Point(109, 75);
                manufacturerEnter.Width = 150;

                Label copyrightDateLabel = new Label();
                copyrightDateLabel.Text = "Copyright Date:";
                sourceInfoPanel.Controls.Add(copyrightDateLabel);
                copyrightDateLabel.Location = new Point(0, 100);
                copyrightDateLabel.Width = 109;

                TextBox copyrightDateEnter = new TextBox();
                copyrightDateEnter.Name = "copyrightDateEnter";
                sourceInfoPanel.Controls.Add(copyrightDateEnter);
                copyrightDateEnter.Location = new Point(109, 100);
                copyrightDateEnter.Width = 150;

                Label retrievedFromLabel = new Label();
                retrievedFromLabel.Text = "Retrieved From:";
                sourceInfoPanel.Controls.Add(retrievedFromLabel);
                retrievedFromLabel.Location = new Point(0, 125);
                retrievedFromLabel.Width = 109;

                TextBox retrievedFromEnter = new TextBox();
                retrievedFromEnter.Name = "retrievedFromEnter";
                sourceInfoPanel.Controls.Add(retrievedFromEnter);
                retrievedFromEnter.Location = new Point(109, 125);
                retrievedFromEnter.Width = 150;

                Label accessedLabel = new Label();
                accessedLabel.Text = "Accessed On:";
                sourceInfoPanel.Controls.Add(accessedLabel);
                accessedLabel.Location = new Point(0, 150);

                TextBox accessedEnter = new TextBox();
                accessedEnter.Name = "accessedEnter";
                sourceInfoPanel.Controls.Add(accessedEnter);
                accessedEnter.Location = new Point(109, 150);
                accessedEnter.Width = 150;
            }
            else if (interview.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(2) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(2);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(2) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(2) + 219);
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

                if (getSourceInfoHeight(4) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(4);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(4) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(4) + 219);
                }
                sourceInfoGroupBox.Tag = "1,4";

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

                Label subjectLabel = new Label();
                subjectLabel.Text = "Subject Line:";
                sourceInfoPanel.Controls.Add(subjectLabel);
                subjectLabel.Location = new Point(0, 25);
                subjectLabel.Width = 109;

                TextBox subjectEnter = new TextBox();
                subjectEnter.Name = "subjectEnter";
                sourceInfoPanel.Controls.Add(subjectEnter);
                subjectEnter.Location = new Point(109, 25);
                subjectEnter.Width = 150;

                Label receiverLabel = new Label();
                receiverLabel.Text = "Receiver:";
                sourceInfoPanel.Controls.Add(receiverLabel);
                receiverLabel.Location = new Point(0, 50);
                receiverLabel.Width = 109;

                TextBox receiverFirstEnter = new TextBox();
                receiverFirstEnter.Name = "receiverFirstEnter";
                sourceInfoPanel.Controls.Add(receiverFirstEnter);
                receiverFirstEnter.Location = new Point(109, 50);
                receiverFirstEnter.Width = 100;

                TextBox receiverMiddleEnter = new TextBox();
                receiverMiddleEnter.Name = "receiverMiddleEnter";
                sourceInfoPanel.Controls.Add(receiverMiddleEnter);
                receiverMiddleEnter.Location = new Point(224, 50);
                receiverMiddleEnter.Width = 100;

                TextBox receiverLastEnter = new TextBox();
                receiverLastEnter.Name = "receiverLastEnter";
                sourceInfoPanel.Controls.Add(receiverLastEnter);
                receiverLastEnter.Location = new Point(339, 50);
                receiverLastEnter.Width = 100;

                Label dateLabel = new Label();
                dateLabel.Text = "Email Date:";
                sourceInfoPanel.Controls.Add(dateLabel);
                dateLabel.Location = new Point(0, 75);
                dateLabel.Width = 109;

                TextBox dateEnter = new TextBox();
                dateEnter.Name = "dateEnter";
                sourceInfoPanel.Controls.Add(dateEnter);
                dateEnter.Location = new Point(109, 75);
                dateEnter.Width = 150;
            }
            else if (letterToEditor.Checked)
            {
                removeInsideInfo();

                if (getSourceInfoHeight(6) > 135)
                {
                    sourceInfoPanel.Height = 135;
                    sourceInfoGroupBox.Height = 160;
                    sourceInfoPanel.AutoScroll = true;

                    moveTo("quoteContentGroupBox", 354);
                }
                else
                {
                    sourceInfoPanel.Height = getSourceInfoHeight(6);
                    sourceInfoGroupBox.Height = getSourceInfoHeight(6) + 25;
                    sourceInfoPanel.VerticalScroll.Value = 0;
                    sourceInfoPanel.AutoScroll = false;

                    moveTo("quoteContentGroupBox", getSourceInfoHeight(6) + 219);
                }
                sourceInfoGroupBox.Tag = "1,6";

                Label authorLabel = new Label();
                authorLabel.Text = "Writer:";
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

                Label titleLabel = new Label();
                titleLabel.Text = "Title of Letter:";
                sourceInfoPanel.Controls.Add(titleLabel);
                titleLabel.Location = new Point(0, 25);
                titleLabel.Width = 180;

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(180, 25);
                titleEnter.Width = 150;

                Label wherePublishedLabel = new Label();
                wherePublishedLabel.Text = "Work that Published the Letter:";
                sourceInfoPanel.Controls.Add(wherePublishedLabel);
                wherePublishedLabel.Location = new Point(0, 50);
                wherePublishedLabel.Width = 180;

                TextBox wherePublishedEnter = new TextBox();
                wherePublishedEnter.Name = "wherePublishedEnter";
                sourceInfoPanel.Controls.Add(wherePublishedEnter);
                wherePublishedEnter.Location = new Point(180, 50);
                wherePublishedEnter.Width = 150;

                Label publicationDateLabel = new Label();
                publicationDateLabel.Text = "Date of Publication:";
                sourceInfoPanel.Controls.Add(publicationDateLabel);
                publicationDateLabel.Location = new Point(0, 75);

                TextBox publicationDateEnter = new TextBox();
                publicationDateEnter.Name = "publicationDateEnter";
                sourceInfoPanel.Controls.Add(publicationDateEnter);
                publicationDateEnter.Location = new Point(180, 75);
                publicationDateEnter.Width = 150;

                Label pageStartLabel = new Label();
                pageStartLabel.Text = "Start Page:";
                sourceInfoPanel.Controls.Add(pageStartLabel);
                pageStartLabel.Location = new Point(0, 100);

                TextBox pageStartEnter = new TextBox();
                pageStartEnter.Name = "pageStartEnter";
                sourceInfoPanel.Controls.Add(pageStartEnter);
                pageStartEnter.Location = new Point(180, 100);
                pageStartEnter.Width = 150;

                Label pageEndLabel = new Label();
                pageEndLabel.Text = "End Page:";
                sourceInfoPanel.Controls.Add(pageEndLabel);
                pageEndLabel.Location = new Point(0, 125);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(180, 125);
                pageEndEnter.Width = 150;
            }
            else
            {

            }
        }
    }
}
