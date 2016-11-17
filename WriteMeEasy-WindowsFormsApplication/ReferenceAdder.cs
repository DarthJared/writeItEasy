﻿using System;
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
            sourceInfoPanel.Controls.Clear();
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
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 50);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 50);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Date:";
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
            else if (bookNoAuth.Checked)
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
                
                Label bookTitleLabel = new Label();
                bookTitleLabel.Text = "Title:";
                sourceInfoPanel.Controls.Add(bookTitleLabel);
                bookTitleLabel.Location = new Point(0, 0);

                TextBox titleEnter = new TextBox();
                titleEnter.Name = "titleEnter";
                sourceInfoPanel.Controls.Add(titleEnter);
                titleEnter.Location = new Point(109, 0);
                titleEnter.Width = 150;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 25);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 25);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Date:";
                sourceInfoPanel.Controls.Add(publishDateLabel);
                publishDateLabel.Location = new Point(0, 50);

                TextBox publishDateEnter = new TextBox();
                publishDateEnter.Name = "publishDateEnter";
                sourceInfoPanel.Controls.Add(publishDateEnter);
                publishDateEnter.Location = new Point(109, 50);
                publishDateEnter.Width = 150;

                Label editionLabel = new Label();
                editionLabel.Text = "Edition:";
                sourceInfoPanel.Controls.Add(editionLabel);
                editionLabel.Location = new Point(0, 75);

                TextBox editionEnter = new TextBox();
                editionEnter.Name = "editionEnter";
                sourceInfoPanel.Controls.Add(editionEnter);
                editionEnter.Location = new Point(109, 75);
                editionEnter.Width = 150;
            }
            else if (bookByOrg.Checked)
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

                Label authorLabel = new Label();
                authorLabel.Text = "Organization:";
                sourceInfoPanel.Controls.Add(authorLabel);
                authorLabel.Location = new Point(0, 0);

                TextBox authorEnter = new TextBox();
                authorEnter.Name = "authorEnter";
                sourceInfoPanel.Controls.Add(authorEnter);
                authorEnter.Location = new Point(109, 0);
                authorEnter.Width = 150;

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
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 50);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(109, 50);
                publisherEnter.Width = 150;

                Label publishDateLabel = new Label();
                publishDateLabel.Text = "Publication Date:";
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
            else if (encyclopedia.Checked)
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

                Label publicationYearLabel = new Label();
                publicationYearLabel.Text = "Year of Publication:";
                sourceInfoPanel.Controls.Add(publicationYearLabel);
                publicationYearLabel.Location = new Point(0, 25);

                TextBox publicationYearEnter = new TextBox();
                publicationYearEnter.Name = "publicationYearEnter";
                sourceInfoPanel.Controls.Add(publicationYearEnter);
                publicationYearEnter.Location = new Point(180, 25);
                publicationYearEnter.Width = 150;

                Label sectionNameLabel = new Label();
                sectionNameLabel.Text = "Section Referenced:";
                sourceInfoPanel.Controls.Add(sectionNameLabel);
                sectionNameLabel.Location = new Point(0, 50);

                TextBox sectionNameEnter = new TextBox();
                sectionNameEnter.Name = "sectionNameEnter";
                sourceInfoPanel.Controls.Add(sectionNameEnter);
                sectionNameEnter.Location = new Point(180, 50);
                sectionNameEnter.Width = 150;

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

                Label volumeLabel = new Label();
                volumeLabel.Text = "Volume:";
                sourceInfoPanel.Controls.Add(volumeLabel);
                volumeLabel.Location = new Point(0, 100);

                TextBox volumeEnter = new TextBox();
                volumeEnter.Name = "volumeEnter";
                sourceInfoPanel.Controls.Add(volumeEnter);
                volumeEnter.Location = new Point(180, 100);
                volumeEnter.Width = 150;

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
                pageEndLabel.Location = new Point(0, 125);

                TextBox pageEndEnter = new TextBox();
                pageEndEnter.Name = "pageEndEnter";
                sourceInfoPanel.Controls.Add(pageEndEnter);
                pageEndEnter.Location = new Point(180, 125);
                pageEndEnter.Width = 150;

                Label publishLocationLabel = new Label();
                publishLocationLabel.Text = "Publication Location:";
                sourceInfoPanel.Controls.Add(publishLocationLabel);
                publishLocationLabel.Location = new Point(0, 150);

                TextBox publicationLocationEnter = new TextBox();
                publicationLocationEnter.Name = "publicationLocationEnter";
                sourceInfoPanel.Controls.Add(publicationLocationEnter);
                publicationLocationEnter.Location = new Point(180, 150);
                publicationLocationEnter.Width = 150;

                Label publisherLabel = new Label();
                publisherLabel.Text = "Publisher Name:";
                sourceInfoPanel.Controls.Add(publisherLabel);
                publisherLabel.Location = new Point(0, 175);

                TextBox publisherEnter = new TextBox();
                publisherEnter.Name = "publisherEnter";
                sourceInfoPanel.Controls.Add(publisherEnter);
                publisherEnter.Location = new Point(180, 175);
                publisherEnter.Width = 150;
            }
            else if (translated.Checked)
            {
                removeInsideInfo();


                
            }
            else if (magazine.Checked)
            {
                removeInsideInfo();

            }
            else if (newspaper.Checked)
            {
                removeInsideInfo();

            }
            else if (anonymous.Checked)
            {
                removeInsideInfo();

            }
            else if (journal.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineJournal.Checked)
            {
                removeInsideInfo();

            }
            else if (onlinePeriodical.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineNewspaper.Checked)
            {
                removeInsideInfo();

            }
            else if (electronicBook.Checked)
            {
                removeInsideInfo();

            }
            else if (kindle.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineBibliography.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineInterview.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineEncyclopedia.Checked)
            {
                removeInsideInfo();

            }
            else if (forumDiscussion.Checked)
            {
                removeInsideInfo();

            }
            else if (bookReview.Checked)
            {
                removeInsideInfo();

            }
            else if (blog.Checked)
            {
                removeInsideInfo();

            }
            else if (wiki.Checked)
            {
                removeInsideInfo();

            }
            else if (webDoc.Checked)
            {
                removeInsideInfo();

            }
            else if (onlineDissertation.Checked)
            {
                removeInsideInfo();

            }
            else if (publishedDissertation.Checked)
            {
                removeInsideInfo();

            }
            else if (unpublishedDissertation.Checked)
            {
                removeInsideInfo();

            } 
            else if (privateOrgReport.Checked)
            {
                removeInsideInfo();

            }
            else if (governmentDocument.Checked)
            {
                removeInsideInfo();

            }
            else if (review.Checked)
            {
                removeInsideInfo();

            }
            else if (lectureNotesSlides.Checked)
            {
                removeInsideInfo();

            }
            else if (audioPodcast.Checked)
            {
                removeInsideInfo();

            }
            else if (videoPodcast.Checked)
            {
                removeInsideInfo();

            }
            else if (motionPicture.Checked)
            {
                removeInsideInfo();

            }
            else if (tvBroadcast.Checked)
            {
                removeInsideInfo();

            }
            else if (tvEpisode.Checked)
            {
                removeInsideInfo();

            }
            else if (music.Checked)
            {
                removeInsideInfo();

            }
            else if (interview.Checked)
            {
                removeInsideInfo();

            }
            else if (email.Checked)
            {
                removeInsideInfo();

            }
            else if (personal.Checked)
            {
                removeInsideInfo();

            }
            else if (letterToEditor.Checked)
            {
                removeInsideInfo();

            }
            else
            {

            }
        }

        
    }
}
